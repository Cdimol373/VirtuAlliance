using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject pantallaInicio;
    public Button botonIniciar;

    void Start()
    {
        pantallaInicio.SetActive(true); // ✅ Mostrar pantalla de inicio

        botonIniciar.onClick.RemoveAllListeners(); // 🔹 Limpia eventos anteriores
        botonIniciar.onClick.AddListener(IniciarTutorial); // 🔹 Asigna la función correctamente
    }


    public void IniciarTutorial()
    {
        Debug.Log("🟢 Botón presionado, iniciando tutorial...");
        pantallaInicio.SetActive(false); // Ocultar bienvenida y comenzar el tutorial
    }

}
