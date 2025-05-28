using UnityEngine;

public class CanvasFijo : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0, 1.5f, 3f); // 🔹 Colocado en la sala
        transform.rotation = Quaternion.identity; // 🔹 Sin rotación automática
    }
}

