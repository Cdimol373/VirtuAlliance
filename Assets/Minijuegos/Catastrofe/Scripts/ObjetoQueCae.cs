using UnityEngine;

public class ObjetoQueCae : MonoBehaviour // Script para objetos que caen en el juego
{
    public Animator animator;
    public Collider2D colliderPausa;

    void OnCollisionEnter2D(Collision2D col) // Detectar colisiones con suelo o personaje
    {
        Debug.Log("Colisión detectada con: " + col.gameObject.name + " en posición " + transform.position);

        if (col.gameObject.CompareTag("Suelo") || col.gameObject.CompareTag("Limite_Inferior"))
        {
            colliderPausa.enabled = false;
            animator.SetTrigger("explosion");
            Invoke("DestroyObject", 0.5f); // Destruir después de la animación
        }
        else if (col.gameObject.CompareTag("Mazon"))
        {
            colliderPausa.enabled = false;
            col.gameObject.GetComponent<MazonMovimiento>().RestarVidasMazon();
            animator.SetTrigger("explosion");
            Invoke("DestroyObject", 0.5f); // Esperar para destruir
        }
        Debug.Log("Colisión con: " + col.gameObject.name + " en posición " + transform.position);
    }

  

    public void DestroyObject()
    {
        Destroy(gameObject); // Eliminar el objeto después de la explosión
    }

}
