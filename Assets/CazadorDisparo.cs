using UnityEngine;

public class CazadorDisparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        Instantiate(balaPrefab, puntoDisparo.position, transform.rotation);
    }
}
