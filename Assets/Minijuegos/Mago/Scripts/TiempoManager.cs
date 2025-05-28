using UnityEngine;
using UnityEngine.UI;
using TMPro; // Necesario para TextMeshPro




public class TiempoManager : MonoBehaviour
{
    public TextMeshProUGUI tiempoTextVR; // 🔹 Referencia al texto en VR
    public float tiempoRestante = 60f;
    public TextMeshProUGUI textoFinal; // Cambio de tipo para ser compatible
    public GameObject pantallaFinal; // Panel con mensaje final

    void Start()
    {
        pantallaFinal.SetActive(false); // Oculta la pantalla de fin al inicio
    }

    void Update()
    {
        tiempoTextVR.text = tiempoRestante.ToString("F0"); // 🔹 Formato sin decimales
        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0)
        {
            MostrarPantallaFinal();
        }
    }

    void MostrarPantallaFinal()
    {
        int puntosFinales = FindFirstObjectByType<PuntuacionManager>().ObtenerPuntos();
        textoFinal.text =  puntosFinales.ToString(); ;
        pantallaFinal.SetActive(true); // Muestra la pantalla de fin

        Time.timeScale = 0f; // Pausa el juego completamente
    }
}
