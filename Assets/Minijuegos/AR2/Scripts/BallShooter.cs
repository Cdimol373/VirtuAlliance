using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public float throwForce = 50f;

    private GameObject currentBall = null;

    void Update()
    {
        // Solo permitir lanzar si hay exactamente un toque y no hay pelota activa
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && currentBall == null)
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        // Instanciar pelota frente a la cámara
        currentBall = Instantiate(
            ballPrefab,
            Camera.main.transform.position + Camera.main.transform.forward * 1f,
            Quaternion.identity
        );

        // Aplicar fuerza
        Rigidbody rb = currentBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.VelocityChange);
        }

        // Esperar y destruir
        StartCoroutine(DestroyBallAfterSeconds(currentBall, 1.2f));
    }

    System.Collections.IEnumerator DestroyBallAfterSeconds(GameObject ball, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (ball != null)
        {
            Destroy(ball);
        }

        // Permitir lanzar otra pelota
        currentBall = null;
    }
}

