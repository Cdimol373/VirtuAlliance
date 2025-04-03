using UnityEngine;

public class AjustarLimites : MonoBehaviour
{
    void Start()
    {
        float anchoPantalla = Camera.main.orthographicSize * Camera.main.aspect * 2;
        float altoPantalla = Camera.main.orthographicSize * 2;

        transform.GetChild(0).position = new Vector3(-anchoPantalla / 2, 0, 0);
        transform.GetChild(1).position = new Vector3(anchoPantalla / 2, 0, 0);
        transform.GetChild(2).position = new Vector3(0, altoPantalla / 2, 0);
        transform.GetChild(3).position = new Vector3(0, -altoPantalla / 2, 0);
    }
}
