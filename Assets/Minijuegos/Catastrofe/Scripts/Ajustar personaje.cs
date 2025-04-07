using UnityEngine;

public class AjustarPersonaje : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        // Obtener dimensiones de la pantalla
        float altura = Camera.main.orthographicSize * 2.0f;
        float ancho = altura * Screen.width / Screen.height;

        // Calcular el factor de escala basado en el ancho o la altura
        float factorEscala = Mathf.Min(ancho / sr.bounds.size.x, altura / sr.bounds.size.y) * 0.1f;

        // Aplicar la escala de forma proporcional
        transform.localScale = new Vector3(factorEscala, factorEscala, 1);
    }
}

