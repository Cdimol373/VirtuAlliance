using UnityEngine;

public class PuntuacionTotal : MonoBehaviour
{
    public static PuntuacionTotal instancia;
    public int puntuacionTotal = 0;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

            // SIMULAR PUNTOS TEMPORALES
            puntuacionTotal = 100; // Cambia este n�mero para probar
        }
        else
        {
            Destroy(gameObject);
        }
    }

    


    public void SumarPuntos(int puntos)
    {
        puntuacionTotal += puntos;
    }

    public int ObtenerPuntuacionTotal()
    {
        return puntuacionTotal;
    }
}
