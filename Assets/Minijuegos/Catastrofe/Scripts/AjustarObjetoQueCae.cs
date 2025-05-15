using UnityEngine;

public class AjustarObjetoCae : MonoBehaviour
{
    public float escalaMultiplicador = 1.5f; // Ajusta este valor para hacer los objetos m�s grandes

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        // Obtener dimensiones de la pantalla en el mundo
        float altura = Camera.main.orthographicSize * 2.0f;
        float ancho = altura * Screen.width / Screen.height;

        // Calcular escala para adaptar el tama�o del objeto
        float factorEscala = Mathf.Min(ancho / sr.bounds.size.x, altura / sr.bounds.size.y) * 0.1f;

        // Ajustar la escala del objeto multiplic�ndola para hacerlos m�s grandes
        transform.localScale = new Vector3(factorEscala * escalaMultiplicador, factorEscala * escalaMultiplicador, 1);
    }
}
