using UnityEngine;

public class CazadorDisparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos = 0.5f;
    private float tiempoUltimoDisparo;

    void Update()
    {
        // Detecta si el botón B está presionado y controla el tiempo entre disparos
        if (ControlesUI.botonBPresionado && Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
    }
}
