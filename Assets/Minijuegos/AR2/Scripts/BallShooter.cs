using UnityEngine;
using System.Collections;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public float throwForce = 50f;

    private GameObject currentBall = null;
    private bool canThrowBall = true; // Control para evitar múltiples lanzamientos

    void Update()
    {
        // Bloquear si el juego terminó
        if (GameManager.Instance != null && GameManager.Instance.timeLeft <= 0f)
            return;

        // Solo permitir lanzar si hay un toque, no hay pelota activa y está permitido lanzar
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && currentBall == null && canThrowBall)
        {
            StartCoroutine(ThrowBallWithCooldown());
        }
    }

    IEnumerator ThrowBallWithCooldown()
    {
        canThrowBall = false;
        ThrowBall(); // Lanza la pelota
        yield return new WaitForSeconds(0.3f); // Pequeño retraso para evitar toques múltiples (ajustable)
        canThrowBall = true;
    }

    void ThrowBall()
    {
        // Instanciar la pelota frente a la cámara
        currentBall = Instantiate(ballPrefab, Camera.main.transform.position + Camera.main.transform.forward * 1f, Quaternion.identity);

        // Aplicar fuerza a la pelota
        Rigidbody rb = currentBall.GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.VelocityChange);

        // Destruir tras 1.2 segundos y liberar bloqueo
        StartCoroutine(DestroyBallAfterSeconds(currentBall, 1.2f));
    }

    IEnumerator DestroyBallAfterSeconds(GameObject ball, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (ball != null)
        {
            Destroy(ball);
            currentBall = null; // Permitir lanzar otra pelota
        }
    }
}

