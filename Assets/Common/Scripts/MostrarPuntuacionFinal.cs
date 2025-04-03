using TMPro;
using UnityEngine;

public class MostrarPuntuacionFinal : MonoBehaviour
{
    public TextMeshProUGUI textoPuntuacion;

    void Start()
    {
        textoPuntuacion.text = PuntuacionTotal.instancia.ObtenerPuntuacionTotal().ToString();

    }
}
