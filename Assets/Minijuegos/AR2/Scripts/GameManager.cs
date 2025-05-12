using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText; // Asigna esto en el Inspector

    public float timeLeft = 25f;
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (isGameOver) return;

        // Restar tiempo y actualizar el texto
        timeLeft -= Time.deltaTime;
        timerText.text = "Tiempo: " + Mathf.CeilToInt(timeLeft);

        // Verificar si terminó el tiempo
        if (timeLeft <= 0)
        {
            EndGame();
        }
    }

    public void AddPoint()
    {
        if (isGameOver) return;

        score++;
        scoreText.text = "Puntos: " + score;
    }

    void EndGame()
    {
        isGameOver = true;
        timeLeft = 0;
        timerText.text = "Tiempo: 0";

        if (PuntuacionTotal.instancia != null)
        {
            PuntuacionTotal.instancia.AgregarPuntuacionTotal(score);
        }

        // Opcional: detener el tiempo si necesitas
        Time.timeScale = 1; // Asegúrate de restaurar tiempo antes de cambiar de escena

        // Cargar la escena final tras pequeña espera
        StartCoroutine(CargarPantallaFinal());
    }

    IEnumerator CargarPantallaFinal()
    {
        yield return new WaitForSeconds(1.5f); // Espera opcional para que el jugador vea el final
        SceneManager.LoadScene("PantallaFinal");
    }
}