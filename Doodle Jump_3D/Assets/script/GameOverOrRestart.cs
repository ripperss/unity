using UnityEngine;
using UnityEngine.SceneManagement; // ��� ����������� �����
using TMPro; // ��� ������ � TextMeshPro (���� ����������� TextMeshPro)

public class PlayerFallCheck : MonoBehaviour
{
    [SerializeField] private Transform player; // ������ �� ������
    [SerializeField] private float fallThreshold = -5f; // �������, ���� �������� ����� ����-����
    [SerializeField] private TextMeshProUGUI gameOverText; // ������ �� ����� "Game Over"
    [SerializeField] private float restartDelay = 2f; // ����� �������� ����� ������������ ����

    private bool isGameOver = false; // ����� ���� �� ��������������� ��������� ���

    private void Update()
    {
        // ���������, ���� �� ����� ���� ������������ ������
        if (player.position.y < fallThreshold && !isGameOver)
        {
            GameOver(); // ���� ����, �������� ����� GameOver
        }
    }

    // �����, ���������� ����-����
    private void GameOver()
    {
        isGameOver = true; // ������������� ����, ��� ���� ��������
        gameOverText.gameObject.SetActive(true); // ���������� ����� "Game Over"
        Invoke("RestartGame", restartDelay); // ������������� ���� ����� ��������
    }

    // ����� ��� ����������� ����
    private void RestartGame()
    {
        // ������������� ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}