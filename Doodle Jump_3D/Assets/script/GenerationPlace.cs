using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationPlace : MonoBehaviour
{
    [SerializeField] private GameObject _placePrefab; // Префаб объекта платформы
    [SerializeField] private Transform _placePosition; // Позиция, откуда начинается генерация
    [SerializeField] private Platfom_static _platformStatic; // Ссылка на скрипт с массивом платформ

    private bool _hasGenerated = false; // Флаг для контроля однократного создания объектов
    private float _timer = 0f; // Таймер для генерации каждые 10 секунд
    private bool _allowPeriodicGeneration = false; // Флаг для включения периодической генерации

    // Метод для генерации объекта платформы
    public GameObject GeneratePlace(GameObject prefab, Transform position)
    {
        (int x, int y, int z) = RandomizePlace(position); // Генерация случайных координат
        // Создаем объект на основе префаба
        var generatedObject = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
        generatedObject.transform.Rotate(0, 180, 0);
        // Убедимся, что объект имеет BoxCollider, если нет — добавляем его
        if (generatedObject.GetComponent<BoxCollider>() == null)
        {
            generatedObject.AddComponent<BoxCollider>();
        }

        return generatedObject; // Возвращаем созданный объект
    }

    // Метод для генерации случайных координат
    public (int, int, int) RandomizePlace(Transform positionObject)
    {
        System.Random rand = new System.Random(); // Генератор случайных чисел
        int positionPlaceY = (int)positionObject.position.y; // Получаем Y-позицию объекта
        var positionX = rand.Next(-2, -1); // Случайная координата X
        var positionZ = rand.Next(2, 4); // Случайная координата Z
        var positionY = rand.Next(positionPlaceY, positionPlaceY + 6); // Случайная координата Y
        return (positionX, positionY, positionZ); // Возвращаем сгенерированные координаты
    }

    // Метод для добавления объектов в список платформ
    public void AddToList(GameObject prefab, Transform position)
    {
        int countObject = 2; // Всегда создаем два объекта

        // Проверим, есть ли ссылка на _platformStatic
        if (_platformStatic == null)
        {
            Debug.LogError("Platfom_static не привязан к GenerationPlace!");
            return;
        }

        // Генерируем два объекта и добавляем их в список
        for (int i = 0; i < countObject; i++)
        {
            var generatedObject = GeneratePlace(prefab, position); // Генерация объекта
            if (generatedObject != null)
            {
                _platformStatic.ArrayPlace.Add(generatedObject); // Добавляем объект в список платформ
            }
        }
    }

    // Метод, вызываемый при столкновении с триггером
    private void OnTriggerStay(Collider other)
    {
        if (!_hasGenerated) // Проверяем, были ли уже созданы объекты
        {
            AddToList(_placePrefab, _placePosition); // Генерируем два объекта
            _hasGenerated = true; // Устанавливаем флаг, чтобы больше не генерировать объекты
        }
    }

    private void Update()
    {
        // Если включена периодическая генерация, увеличиваем таймер
        if (_allowPeriodicGeneration)
        {
            _timer += Time.deltaTime; // Увеличиваем таймер
            if (_timer >= 10f) // Проверяем, прошли ли 10 секунд
            {
                AddToList(_placePrefab, _placePosition); // Генерируем два объекта
                _timer = 0f; // Сбрасываем таймер
            }
        }
    }

    // Метод для включения/отключения периодической генерации
    public void EnablePeriodicGeneration(bool enable)
    {
        _allowPeriodicGeneration = enable;
    }
}