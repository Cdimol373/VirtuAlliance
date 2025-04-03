using UnityEngine;

public class AjustarPersonaje : MonoBehaviour
{
    void Start()
    {
        float worldWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        float worldHeight = Camera.main.orthographicSize * 2;

        transform.position = new Vector3(-worldWidth / 2 + 1f, -worldHeight / 2 + 1f, 0f);
    }
}
