using UnityEngine;

public class SetCameraDefaults : MonoBehaviour
{
    void Start()
    {
        Camera cam = GetComponent<Camera>(); // Obtén el componente de la cámara
        if (cam != null)
        {
            // Cambia las flags para que el fondo sea sólido
            cam.clearFlags = CameraClearFlags.SolidColor;
            // Define el color de fondo (negro)
            cam.backgroundColor = Color.black;
        }
    }
}
