using TMPro;
using UnityEngine;

public class MostrarPuntuacionFinal : MonoBehaviour
{
    public TextMeshProUGUI textoPuntuacion;

    void Start()
    {
        // Aseguramos que la referencia sea correcta
        if (PuntuacionTotal.instancia != null)
        {
            textoPuntuacion.text = PuntuacionTotal.instancia.ObtenerPuntuacionTotal().ToString();
        }
    }
}