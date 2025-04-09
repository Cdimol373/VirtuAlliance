using UnityEngine;
using TMPro;

public class PuntajeManager : MonoBehaviour
{
    public static PuntajeManager Instance;

    private int puntaje = 0;
    private int contadorEsquivados = 0;  // Contador para los objetos esquivados

    public TextMeshProUGUI textoPuntaje;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional: conserva entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ObjetoEsquivado()
    {
        contadorEsquivados++; // Incrementamos el contador de esquivados
        Debug.Log("Esquivados: " + contadorEsquivados); // Verifica que el contador se incremente correctamente

        if (contadorEsquivados >= 5) // Si hemos esquivado 5 objetos, sumamos un punto
        {
            Debug.Log("Se han esquivado 5 objetos, sumando un punto"); // Verifica cuando sumamos el punto

            contadorEsquivados = 0; // Reseteamos el contador de esquivados
            SumarPunto(); // Sumamos un punto
        }
    }

    public void SumarPunto()
    {
        puntaje++; // Incrementa el puntaje
        ActualizarTexto();
        PuntuacionTotal.instancia.AgregarPuntuacionTotal(puntaje); // Actualiza el puntaje total
               
    }

    void ActualizarTexto()
    {
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntos: " + puntaje; // Muestra el puntaje en pantalla
        }
    }

    public int ObtenerPuntaje()
    {
        return puntaje;
    }
}

