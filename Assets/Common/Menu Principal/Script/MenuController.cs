using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class MenuController : MonoBehaviour
{
    // Esta función será llamada al hacer clic en el botón
    public void CargarEscenaJuego()
    {
        // Aquí pones el nombre de la escena de tu juego
        SceneManager.LoadScene("JuegoCatastrofe");  // Reemplaza "NombreDeTuEscena" por el nombre exacto de tu escena de juego
    }
}