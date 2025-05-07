using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float shootForce = 500f;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(spawnPoint.forward * shootForce);
        Destroy(ball, 5f); // se destruye tras 5 segundos
    }
}
