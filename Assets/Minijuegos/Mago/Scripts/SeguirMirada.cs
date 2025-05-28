using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SeguirMirada : MonoBehaviour
{
    public GameObject libro;
    public Transform mesaDestino;
    public float velocidadMovimiento = 3f;
    public float tiempoMirandoNecesario = 1.5f; // Tiempo mínimo mirando el libro antes de activarlo
    public float distanciaDetencion = 0.2f; // Distancia mínima para detener el movimiento
    public float tiempoEsperaAntesDeMover = 0.5f; // Tiempo de espera antes de permitir el movimiento tras regeneración

    private RaycastHit hit;
    private bool moviendoHaciaMesa = false;
    private bool miradaConfirmada = false;
    private float tiempoMirando = 0f;
    private bool enTutorial = true; // Comenzamos en modo tutorial
    private bool puedeMoverse = false; // Variable para evitar movimiento inmediato tras regeneración

    void Start()
    {
        puedeMoverse = true; // Al iniciar el juego, el libro puede moverse
    }

    public void ResetearMirada()
    {
        miradaConfirmada = false;
        tiempoMirando = 0f;
        moviendoHaciaMesa = false;
    }

    public void DesactivarMovimientoTemporal()
    {
        puedeMoverse = false;
        Invoke("ActivarMovimiento", tiempoEsperaAntesDeMover); // Espera antes de permitir el movimiento
    }

    void ActivarMovimiento()
    {
        puedeMoverse = true;
    }
    public ParticleSystem brilloEfecto; // 🔹 Arrastra `BrilloLibro` aquí desde Unity

   
    void ActivarBrillo()
    {
        brilloEfecto.Play();
        
    }


    void Update()
    {
        if (moviendoHaciaMesa || !puedeMoverse) return; // Bloquea movimiento si está en camino o en espera tras regeneración

        // 🔹 Detectar objetos físicos con Raycast
        Ray rayo = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit, Mathf.Infinity))
        {
            Debug.Log("Mirando a: " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Interactivo")) // 🔹 Detectar elementos interactivos físicos
            {
                Debug.Log("🟢 Mirada detectando un elemento interactivo físico!");
            }

            if (hit.collider.gameObject == libro)
            {
                tiempoMirando += Time.deltaTime;
                if (tiempoMirando >= tiempoMirandoNecesario)
                {
                    miradaConfirmada = true;
                }
            }
            else
            {
                tiempoMirando = 0f;
            }

            if (miradaConfirmada)
            {
                libro.transform.position = Vector3.Lerp(libro.transform.position, hit.point, Time.deltaTime * velocidadMovimiento);
            }

            if (hit.collider.gameObject == mesaDestino.gameObject)
            {
                StartCoroutine(FijarLibroEnMesa());
            }
        }

        // 🔹 Detectar UI con RaycastAll
        PointerEventData evento = new PointerEventData(EventSystem.current);
        evento.position = new Vector2(Screen.width / 2, Screen.height / 2); // 🔹 Simula la mirada en el centro

        List<RaycastResult> resultados = new List<RaycastResult>();
        EventSystem.current.RaycastAll(evento, resultados);

        foreach (RaycastResult resultado in resultados)
        {
            Debug.Log("🟢 Mirada detectando un objeto UI: " + resultado.gameObject.name);
        }
    }


    IEnumerator FijarLibroEnMesa()
    {
        moviendoHaciaMesa = true;
        float tiempo = 0f;
        Vector3 inicio = libro.transform.position;
        Vector3 destino = mesaDestino.position + new Vector3(0, 0.3f, 0); // 🔹 Ajusta la altura sobre la mesa

        Quaternion rotacionFinal = Quaternion.Euler(-89.5f, -90.0f, 90.0f); // 🔹 Aplica la rotación correcta

        while (tiempo < 1.5f)
        {
            libro.transform.position = Vector3.Lerp(inicio, destino, tiempo / 1.5f);
            libro.transform.rotation = Quaternion.Slerp(libro.transform.rotation, rotacionFinal, tiempo / 1.5f);
            tiempo += Time.deltaTime;
            yield return null;
        }

        libro.transform.position = destino;
        libro.transform.rotation = rotacionFinal; // 🔹 Fijar la rotación final

        ActivarBrillo(); // 🔹 Activa el efecto visual

        yield return new WaitForSeconds(1f); // 🔹 Espera antes de regenerarse


        if (enTutorial)
        {
            Debug.Log("✅ Tutorial completado. Iniciando el juego...");
            enTutorial = false;
            FindFirstObjectByType<SeguirMirada>().ResetearMirada();
        }
        else
        {
            FindFirstObjectByType<PuntuacionManager>().AgregarPunto();
        }

        FindFirstObjectByType<LibroController>().MoverLibroANuevaPosicion();
        FindFirstObjectByType<SeguirMirada>().DesactivarMovimientoTemporal();
        FindFirstObjectByType<SeguirMirada>().ResetearMirada();
    }



    // 🔹 Agrega esta función después de `FijarLibroEnMesa()`
    void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay sigue detectando: " + other.gameObject.name);

        if (other.gameObject == mesaDestino.gameObject)
        {
            Debug.Log("El libro está dentro de la mesa después del tutorial.");
            StartCoroutine(FijarLibroEnMesa());
        }
    }



}



