using UnityEngine;

public class CanvasInteractivo : MonoBehaviour
{
    void Update()
    {
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f; // 🔹 Siempre visible
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward); // 🔹 Alineado con la mirada
    }
}
