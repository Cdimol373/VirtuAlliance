using UnityEngine;

public class ObjetoQueCae : MonoBehaviour // Script para objetos que caen en el juego
{
    public Animator animator;
    public Collider2D colliderPausa;

    private bool yaColisionoConLimite = false;  // Bandera para evitar contar múltiples colisiones con el límite inferior

    void OnCollisionEnter2D(Collision2D col) // Detectar colisiones con suelo o personaje
    {
        Debug.Log("Colisión con: " + col.gameObject.name + " en posición " + transform.position);

        // Verificar si colisiona con el Limite_Inferior y si no ha colisionado antes
        if (col.gameObject.CompareTag("Limite_Inferior") && !yaColisionoConLimite)
        {
            yaColisionoConLimite = true; // Establece la bandera para evitar futuras colisiones
            PuntajeManager.Instance.ObjetoEsquivado(); // Llamar a la función para sumar el punto
        }

        if (col.gameObject.CompareTag("Suelo") || col.gameObject.CompareTag("Limite_Inferior"))
        {
            colliderPausa.enabled = false;
            animator.SetTrigger("explosion");
            Invoke("DestroyObject", 2.0f); // Destruir después de la animación
        }
        else if (col.gameObject.CompareTag("Mazon"))
        {
            colliderPausa.enabled = false;
            col.gameObject.GetComponent<MazonMovimiento>().RestarVidasMazon();
            animator.SetTrigger("explosion");
            Invoke("DestroyObject", 2.0f); // Esperar para destruir
        }
    }

    void DestroyObject()
    {
        // Reseteamos la bandera cuando se destruye el objeto
        yaColisionoConLimite = false;
        Destroy(gameObject); // Eliminar el objeto después de la explosión
    }
}
