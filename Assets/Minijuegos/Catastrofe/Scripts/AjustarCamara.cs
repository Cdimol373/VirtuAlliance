using UnityEngine;

public class AjustarCamara : MonoBehaviour
{
    void Start()
    {
        Camera.main.orthographicSize = Screen.height / (float)Screen.width * 5f;
    }
}
