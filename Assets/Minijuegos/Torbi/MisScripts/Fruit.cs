using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int points = 10;
    public float lifetime = 5f; // Tiempo que dura en pantalla

    private void Start()
    {
        Destroy(gameObject, lifetime); // Se destruye solo después de un tiempo
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddPoints(points);
            Destroy(gameObject);
        }
    }
}
