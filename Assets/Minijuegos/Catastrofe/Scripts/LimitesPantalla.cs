using UnityEngine;

public class LimitesPantalla : MonoBehaviour
{
    void Start()
    {
        CrearLimite(Vector2.left);  // Límite izquierdo
        CrearLimite(Vector2.right); // Límite derecho
        CrearLimiteInferior();      // Límite inferior
    }

    void CrearLimite(Vector2 direccion)
    {
        GameObject limite = new GameObject("Limite_" + direccion);

        // Dimensiones de la pantalla en unidades del mundo
        float altura = Camera.main.orthographicSize * 2.0f;
        float ancho = altura * Screen.width / Screen.height;

        // Posicionar los límites en los bordes laterales
        if (direccion == Vector2.left)
            limite.transform.position = new Vector3(Camera.main.transform.position.x - (ancho / 2), 0, 0);
        else if (direccion == Vector2.right)
            limite.transform.position = new Vector3(Camera.main.transform.position.x + (ancho / 2), 0, 0);

        // Agregar colisionador con tamaño adecuado
        BoxCollider2D collider = limite.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector2(0.5f, altura); // Límites laterales que cubren toda la pantalla
    }

    void CrearLimiteInferior()
    {
        GameObject limite = new GameObject("Limite_Inferior");

        // Obtener la posición del borde inferior de la pantalla
        float alturaPantalla = Camera.main.orthographicSize * 2.0f;
        float anchoPantalla = alturaPantalla * Screen.width / Screen.height;
        Vector3 bottom = Camera.main.transform.position - new Vector3(0, alturaPantalla / 2, 0);

        // Posicionar el límite en la parte inferior del fondo
        limite.transform.position = new Vector3(Camera.main.transform.position.x, bottom.y, 0);

        // Agregar BoxCollider2D para evitar que los objetos caigan fuera de la pantalla
        BoxCollider2D collider = limite.AddComponent<BoxCollider2D>();
        collider.isTrigger = false; // Cambia a `true` si solo quieres detectar sin bloquear el movimiento
        collider.size = new Vector2(anchoPantalla, 0.5f);
        limite.tag = "Limite_Inferior"; // Asegúrate de que el tag coincida con el de OnCollisionEnter2D()


        // 🟢 Debug para comprobar la nueva posición
        Debug.Log("Límite inferior creado en Y: " + bottom.y);
    }
}

