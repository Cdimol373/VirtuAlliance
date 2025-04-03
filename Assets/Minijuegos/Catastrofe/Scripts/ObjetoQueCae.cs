using UnityEngine;

public class ObjetoQueCae : MonoBehaviour // Quiere decir que este script se lo voy a poner a un objeto de la jerarquia
{
    public Animator animator;
    public Collider2D colliderPausa;

    void OnCollisionEnter2D(Collision2D col) // Funcion propia de Unity para decirle que cuando choque con el Collider haga lo que programemos. EL Collision2D es contra el collider que chocamos.
    {
        Debug.Log("Chocan");

        if (col.gameObject.CompareTag("Suelo"))
         {
                colliderPausa.enabled = false;
                    // Simular explosión o destrucción
                    animator.SetTrigger("explosion");
                }
        else if (col.gameObject.CompareTag("Mazon"))
        {
            colliderPausa.enabled = false;
            Debug.Log("ERRORRRRRR");
            col.gameObject.GetComponent<MazonMovimiento>().RestarVidasMazon();
            animator.SetTrigger("explosion");
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    
}

