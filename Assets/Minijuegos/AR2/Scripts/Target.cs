using UnityEngine;

public class Target : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("¡Le diste a la diana!");
            ScoreManager.Instance.AddPoint();
        }
    }
}