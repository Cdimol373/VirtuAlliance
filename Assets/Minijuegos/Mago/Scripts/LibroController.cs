using UnityEngine;
using System.Collections;

public class LibroController : MonoBehaviour
{
    public Transform[] posicionesDisponibles;
    public ParticleSystem brilloEfecto;


    public void MoverLibroANuevaPosicion()
    {
        int indice = Random.Range(0, posicionesDisponibles.Length);
        transform.position = posicionesDisponibles[indice].position;
        float alturaAleatoria = Random.Range(0.5f, 2.0f); // 🔹 Altura entre 0.5 y 2.0 metros
        transform.position += new Vector3(0, alturaAleatoria, 0);


        Debug.Log("El libro ha aparecido en una nueva posición.");
        StartCoroutine(GirarLibro());
    }

    IEnumerator GirarLibro()
    {
        float tiempo = 0f;
        Quaternion inicio = transform.rotation;
        Quaternion destino = Random.rotation; // 🔹 Rotación aleatoria

        while (tiempo < 1f) // 🔹 Duración de la animación de giro (1 segundo)
        {
            transform.rotation = Quaternion.Slerp(inicio, destino, tiempo / 1f);
            tiempo += Time.deltaTime;
            yield return null;
        }
    }
}



