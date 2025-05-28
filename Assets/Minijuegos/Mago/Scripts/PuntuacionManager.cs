using TMPro;
using UnityEngine;

public class PuntuacionManager : MonoBehaviour
{
    private int puntos = 0;
    public TextMeshProUGUI puntosTextVR; // 🔹 Referencia al texto en VR

    void Start()
    {
        puntosTextVR.text = "0"; // 🔹 Asegurar que empieza en 0
    }

    public void AgregarPunto()
    {
        puntos++;
        puntosTextVR.text = puntos.ToString(); /// 🔹 Actualiza la UI en VR
        Debug.Log("Puntos: " + puntos);
    }

    public int ObtenerPuntos()
    {
        return puntos;
    }

}
