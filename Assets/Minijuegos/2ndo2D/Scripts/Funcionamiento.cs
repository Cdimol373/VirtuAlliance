using System.Collections;  // Necesario para usar IEnumerator y corutinas
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena

public class Funcionamiento : MonoBehaviour
{
    public GameObject patoPrefab;    // Prefab del Pato
    public TMP_Text scoreText;       // Texto del puntaje
    public TMP_Text timerText;       // Texto del tiempo
    public AudioClip disparoClip;   // Clip de sonido de disparo

    private AudioSource audioSource; // El AudioSource que se usará para reproducir el sonido
    private int score = 0;           // Puntaje
    private float timer = 25f;       // Tiempo
    private bool isPlaying = true;   // Estado del juego
    private float spawnRate = 0.5f;    // Tasa de generación de patos (cada 1 segundo)

    private RectTransform canvasRectTransform; // Para obtener las dimensiones del Canvas

    void Start()
    {
        // Asegúrate de que el GameObject que contiene el script tiene un Canvas en sus padres
        Canvas canvas = FindObjectOfType<Canvas>();

        // Verifica si el Canvas fue encontrado correctamente
        if (canvas == null)
        {
            Debug.LogError("No se encontró el Canvas en la escena.");
            return; // Detener el método si no encontramos el Canvas
        }

        // Obtener el RectTransform del Canvas
        canvasRectTransform = canvas.GetComponent<RectTransform>();

        // Comprobar si el RectTransform fue encontrado correctamente
        if (canvasRectTransform == null)
        {
            Debug.LogError("El Canvas no tiene un RectTransform. Asegúrate de que el Canvas esté configurado correctamente.");
            return;
        }

        // Asegurarse de que el prefab del pato está asignado
        if (patoPrefab == null)
        {
            Debug.LogError("El prefab del pato no está asignado en el Inspector.");
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>(); // Añadimos un AudioSource al GameManager
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + Mathf.Ceil(timer);
        StartCoroutine(SpawnPato());  // Comienza la generación de patos
    }

    void Update()
    {
        if (!isPlaying) return;

        // Reducir el tiempo
        timer -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(timer);

        // Si el tiempo se acaba, detener el juego
        if (timer <= 0f)
        {
            isPlaying = false;
            timerText.text = "Time: 0";
            ChangeScene();  // Cambiar a la escena "ARMarcos"
        }
    }

    // Método que genera los patos
    private IEnumerator SpawnPato()
    {
        while (isPlaying)
        {
            // Verificar que patoPrefab no sea null antes de intentar instanciarlo
            if (patoPrefab != null)
            {
                // Generar una posición aleatoria dentro de los límites del Canvas
                float xPos = Random.Range(-canvasRectTransform.rect.width / 2, canvasRectTransform.rect.width / 2);
                float yPos = Random.Range(-canvasRectTransform.rect.height / 2, canvasRectTransform.rect.height / 2);

                Vector2 spawnPosition = new Vector2(xPos, yPos);

                // Instanciar el pato y establecer su posición en el Canvas
                GameObject newPato = Instantiate(patoPrefab, spawnPosition, Quaternion.identity);

                // Asegurarse de que el pato sea un hijo del Canvas, no de la cámara
                newPato.transform.SetParent(canvasRectTransform, false);

                // Convertir la posición de mundo a coordenadas del Canvas
                RectTransform rectTransform = newPato.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = spawnPosition;

                // Iniciar corutina para destruir el pato después de 0.6 segundos
                Destroy(newPato, 0.6f);
            }
            else
            {
                Debug.LogError("patoPrefab no está asignado en el Inspector.");
            }

            // Esperar antes de generar otro pato
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Método para añadir puntos cuando el pato es tocado
    public void AddPoint()
    {
        if (!isPlaying) return;

        score++;
        scoreText.text = "Score: " + score;
    }

    // Método para reproducir el sonido
    public void PlayDisparoSound()
    {
        if (audioSource != null && disparoClip != null)
        {
            audioSource.PlayOneShot(disparoClip); // Reproducir el sonido del disparo
        }
    }

    // Método para cambiar de escena al final del juego
    private void ChangeScene()
    {
        // Cargar la escena llamada "ARMarcos"
        SceneManager.LoadScene("ARMarcos");
    }
}
