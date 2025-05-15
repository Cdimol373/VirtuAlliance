using UnityEngine;
using System.Collections;

public class BookFloatTrigger : MonoBehaviour
{
    public GameObject magicBook; // Referencia al libro
    public float lookTime = 3f;  // Tiempo que el jugador debe mirar el libro
    public float amplitude = 0.5f; // Altura del movimiento de flotación
    public float speed = 2.0f; // Velocidad de flotación

    private bool isLooking = false;
    private float timer = 0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = magicBook.transform.position;
    }

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == magicBook)
            {
                if (!isLooking)
                {
                    isLooking = true;
                    timer = 0f;
                }

                timer += Time.deltaTime;

                if (timer >= lookTime)
                {
                    StartCoroutine(MakeBookFloat());
                }
            }
            else
            {
                isLooking = false;
                timer = 0f;
            }
        }
    }

    IEnumerator MakeBookFloat()
    {
        while (true)
        {
            float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;
            magicBook.transform.position = new Vector3(startPos.x, newY, startPos.z);
            yield return null;
        }
    }
}
