using UnityEngine;

public class GeneradorDeObjetos : MonoBehaviour
{
    public GameObject[] objetosACaer; // Array con Tomate, Pala y Barro
    public float tiempoEntreObjetos = 2f; // Tiempo de espera entre caídas

    private float limiteIzquierdo;
    private float limiteDerecho;
    private float limiteSuperior;
    private float limiteInferior;
    int objetosCreados;
    public float limiteSuperiorOffSet;

    public Camera cam; // Referencia a la cámara personalizada

    void Start()
    {
        if (cam == null)
        {
            cam = GameObject.Find("Camera").GetComponent<Camera>(); // Buscar la cámara en la escena
        }

        // Ajustamos los límites según la cámara
        AjustarLimitesPantalla();

        // Llama a la función de generar objetos repetidamente
        InvokeRepeating("GenerarObjeto", 1f, tiempoEntreObjetos);
    }

    // Ajusta los límites de la pantalla según la cámara
    void AjustarLimitesPantalla()
    {
        // Usamos ScreenToWorldPoint para obtener los límites de la cámara en el mundo
        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)); // Esquina inferior izquierda
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane)); // Esquina superior derecha

        // Asignamos los límites
        limiteIzquierdo = bottomLeft.x;
        limiteDerecho = topRight.x;
        limiteInferior = bottomLeft.y;
        limiteSuperior = topRight.y + limiteSuperiorOffSet;
    }

    void GenerarObjeto()
    {
    
        if (objetosACaer.Length == 0) return; // Evita errores si el array está vacío

        // Elige aleatoriamente un objeto para caer
        int indice = Random.Range(0, objetosACaer.Length);

        // Calcula una posición aleatoria en el eje X dentro de los límites de la cámara
        float posX = Random.Range(limiteIzquierdo, limiteDerecho);

        // La posición en Y será siempre el límite superior de la pantalla
        Vector3 spawnPos = new Vector3(posX, limiteSuperior, 0f);

        // Instancia el objeto en la posición generada
        Instantiate(objetosACaer[indice], spawnPos, Quaternion.identity);

        objetosCreados++;
        AumentoGravedad();
    }
    void AumentoGravedad()
    {
        if (objetosCreados == 5)
        {
            
            Physics2D.gravity += new Vector2(0, -0.5f); // Aumenta la gravedad con el tiempo
            Debug.Log("HOLA " + Physics2D.gravity);
            objetosCreados = 0;
        }
    }


    // Método que puedes llamar para detener la generación de objetos
    public void DetenerGeneracion()
    {
        CancelInvoke("GenerarObjeto");  // Detiene la invocación repetitiva
    }
}
