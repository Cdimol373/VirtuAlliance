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
        // Puedes inicializar variables aqu� si es necesario
    }

    void Update()
    {
        // Si m�s adelante necesitas animaciones o controles, puedes agregarlas aqu�
    }
}
