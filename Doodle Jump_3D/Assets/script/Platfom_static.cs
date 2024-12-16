using System.Collections.Generic;
using UnityEngine;

public class Platfom_static : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform; // Ссылка на игрока (его позиция)
    public List<GameObject> ArrayPlace = new List<GameObject>(); // Список всех платформ

    private float _previousPlayerY; // Предыдущая позиция игрока по оси Y

    private void Start()
    {
        // Сохраняем начальную позицию игрока по оси Y
        _previousPlayerY = _playerTransform.position.y;
    }

    private void Update()
    {
        // Получаем текущую позицию игрока по оси Y
        float currentPlayerY = _playerTransform.position.y;

        // Проходим по списку всех платформ
        foreach (var platform in ArrayPlace)
        {
            // Проверяем, существует ли объект платформы
            if (platform != null)
            {
                // Логика переключения состояний платформ
                if (currentPlayerY > _previousPlayerY)
                {
                    PlatformActiveFalse(platform); // Делаем платформу триггером
                }
                else if (currentPlayerY < _previousPlayerY)
                {
                    PlatformActiveTrue(platform); // Возвращаем платформу в активное состояние
                }
            }
        }

        // Обновляем предыдущую позицию игрока
        _previousPlayerY = currentPlayerY;
    }

    /// <summary>
    /// Переводит платформу в состояние триггера (не активна).
    /// </summary>
    /// <param name="platform">Объект платформы</param>
    public static void PlatformActiveFalse(GameObject platform)
    {
        var collider = platform.GetComponent<BoxCollider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    /// <summary>
    /// Возвращает платформу в активное состояние (не триггер).
    /// </summary>
    /// <param name="platform">Объект платформы</param>
    public static void PlatformActiveTrue(GameObject platform)
    {
        var collider = platform.GetComponent<BoxCollider>();
        if (collider != null)
        {
            collider.isTrigger = false;
        }
    }
}