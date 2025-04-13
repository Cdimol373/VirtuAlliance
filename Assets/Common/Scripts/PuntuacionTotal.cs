using UnityEngine;
using TMPro;

public class PuntuacionTotal : MonoBehaviour
{
    public static PuntuacionTotal instancia;  // Singleton
    public int puntuacionTotal = 0;  // Puntaje total acumulado
    public TextMeshProUGUI textoPuntuacion; // Referencia al texto de puntuación en pantalla

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int puntos)
    {
        puntuacionTotal += puntos;
        Debug.Log("Puntuación Total: " + puntuacionTotal);
        ActualizarTexto();
    }

    public int ObtenerPuntuacionTotal()
    {
        return puntuacionTotal;
    }

    void ActualizarTexto()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntuación Total: " + puntuacionTotal;
        }
    }
}
