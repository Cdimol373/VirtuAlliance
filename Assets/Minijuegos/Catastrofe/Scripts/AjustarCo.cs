using UnityEngine;

public class AjustarCollider : MonoBehaviour
{
    void Start()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (col == null || sr == null) return;

        // Obtener el tamaño del sprite en el mundo
        float ancho = sr.bounds.size.x;
        float altura = sr.bounds.size.y;

        // Asignar el tamaño del collider basado en el sprite
        col.size = new Vector2(ancho, altura);
        col.offset = Vector2.zero; // Centrar el collider
    }
}
