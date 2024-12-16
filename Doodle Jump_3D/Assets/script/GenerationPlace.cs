using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationPlace : MonoBehaviour
{
    [SerializeField] private GameObject _placePrefab; // ������ ������� ���������
    [SerializeField] private Transform _placePosition; // �������, ������ ���������� ���������
    [SerializeField] private Platfom_static _platformStatic; // ������ �� ������ � �������� ��������

    private bool _hasGenerated = false; // ���� ��� �������� ������������ �������� ��������
    private float _timer = 0f; // ������ ��� ��������� ������ 10 ������
    private bool _allowPeriodicGeneration = false; // ���� ��� ��������� ������������� ���������

    // ����� ��� ��������� ������� ���������
    public GameObject GeneratePlace(GameObject prefab, Transform position)
    {
        (int x, int y, int z) = RandomizePlace(position); // ��������� ��������� ���������
        // ������� ������ �� ������ �������
        var generatedObject = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
        generatedObject.transform.Rotate(0, 180, 0);
        // ��������, ��� ������ ����� BoxCollider, ���� ��� � ��������� ���
        if (generatedObject.GetComponent<BoxCollider>() == null)
        {
            generatedObject.AddComponent<BoxCollider>();
        }

        return generatedObject; // ���������� ��������� ������
    }

    // ����� ��� ��������� ��������� ���������
    public (int, int, int) RandomizePlace(Transform positionObject)
    {
        System.Random rand = new System.Random(); // ��������� ��������� �����
        int positionPlaceY = (int)positionObject.position.y; // �������� Y-������� �������
        var positionX = rand.Next(-2, -1); // ��������� ���������� X
        var positionZ = rand.Next(2, 4); // ��������� ���������� Z
        var positionY = rand.Next(positionPlaceY, positionPlaceY + 6); // ��������� ���������� Y
        return (positionX, positionY, positionZ); // ���������� ��������������� ����������
    }

    // ����� ��� ���������� �������� � ������ ��������
    public void AddToList(GameObject prefab, Transform position)
    {
        int countObject = 2; // ������ ������� ��� �������

        // ��������, ���� �� ������ �� _platformStatic
        if (_platformStatic == null)
        {
            Debug.LogError("Platfom_static �� �������� � GenerationPlace!");
            return;
        }

        // ���������� ��� ������� � ��������� �� � ������
        for (int i = 0; i < countObject; i++)
        {
            var generatedObject = GeneratePlace(prefab, position); // ��������� �������
            if (generatedObject != null)
            {
                _platformStatic.ArrayPlace.Add(generatedObject); // ��������� ������ � ������ ��������
            }
        }
    }

    // �����, ���������� ��� ������������ � ���������
    private void OnTriggerStay(Collider other)
    {
        if (!_hasGenerated) // ���������, ���� �� ��� ������� �������
        {
            AddToList(_placePrefab, _placePosition); // ���������� ��� �������
            _hasGenerated = true; // ������������� ����, ����� ������ �� ������������ �������
        }
    }

    private void Update()
    {
        // ���� �������� ������������� ���������, ����������� ������
        if (_allowPeriodicGeneration)
        {
            _timer += Time.deltaTime; // ����������� ������
            if (_timer >= 10f) // ���������, ������ �� 10 ������
            {
                AddToList(_placePrefab, _placePosition); // ���������� ��� �������
                _timer = 0f; // ���������� ������
            }
        }
    }

    // ����� ��� ���������/���������� ������������� ���������
    public void EnablePeriodicGeneration(bool enable)
    {
        _allowPeriodicGeneration = enable;
    }
}