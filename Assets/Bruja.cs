using UnityEngine;

public class Enemigo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bala"))
        {
            Destroy(other.gameObject); // Destruye la bala
            Destroy(gameObject); // Destruye al enemigo
        }
    }
}
