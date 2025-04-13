using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioAutomatico : MonoBehaviour
{
    public string PantallaFinal; // Nombre de la escena a cargar
    public float tiempoEspera = 5f; // Tiempo en segundos antes de cambiar de escena

    void Start()
    {
        // Llamar a la funci�n de cambio de escena despu�s de `tiempoEspera` segundos
        Invoke("CambiarEscena", tiempoEspera);
    }

    void CambiarEscena()
    {
        // Cambiar a la escena especificada
        SceneManager.LoadScene(PantallaFinal);
    }
}
