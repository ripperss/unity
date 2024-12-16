using UnityEngine;
using UnityEngine.SceneManagement; // Для перезапуска сцены
using TMPro; // Для работы с TextMeshPro (если используешь TextMeshPro)

public class PlayerFallCheck : MonoBehaviour
{
    [SerializeField] private Transform player; // Ссылка на игрока
    [SerializeField] private float fallThreshold = -5f; // Уровень, ниже которого будет гейм-овер
    [SerializeField] private TextMeshProUGUI gameOverText; // Ссылка на текст "Game Over"
    [SerializeField] private float restartDelay = 2f; // Время задержки перед перезапуском игры

    private bool isGameOver = false; // Чтобы игра не перезапускалась несколько раз

    private void Update()
    {
        // Проверяем, упал ли игрок ниже определённого уровня
        if (player.position.y < fallThreshold && !isGameOver)
        {
            GameOver(); // Если упал, вызываем метод GameOver
        }
    }

    // Метод, вызывающий гейм-овер
    private void GameOver()
    {
        isGameOver = true; // Устанавливаем флаг, что игра окончена
        gameOverText.gameObject.SetActive(true); // Показываем текст "Game Over"
        Invoke("RestartGame", restartDelay); // Перезапускаем игру через задержку
    }

    // Метод для перезапуска игры
    private void RestartGame()
    {
        // Перезапускаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}