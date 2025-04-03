using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour
{
    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    void Start()
    {
        // Puedes inicializar variables aquí si es necesario
    }

    void Update()
    {
        // Si más adelante necesitas animaciones o controles, puedes agregarlas aquí
    }
}
