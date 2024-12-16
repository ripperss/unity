using System.Collections.Generic;
using UnityEngine;

public class Platfom_static : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform; // ������ �� ������ (��� �������)
    public List<GameObject> ArrayPlace = new List<GameObject>(); // ������ ���� ��������

    private float _previousPlayerY; // ���������� ������� ������ �� ��� Y

    private void Start()
    {
        // ��������� ��������� ������� ������ �� ��� Y
        _previousPlayerY = _playerTransform.position.y;
    }

    private void Update()
    {
        // �������� ������� ������� ������ �� ��� Y
        float currentPlayerY = _playerTransform.position.y;

        // �������� �� ������ ���� ��������
        foreach (var platform in ArrayPlace)
        {
            // ���������, ���������� �� ������ ���������
            if (platform != null)
            {
                // ������ ������������ ��������� ��������
                if (currentPlayerY > _previousPlayerY)
                {
                    PlatformActiveFalse(platform); // ������ ��������� ���������
                }
                else if (currentPlayerY < _previousPlayerY)
                {
                    PlatformActiveTrue(platform); // ���������� ��������� � �������� ���������
                }
            }
        }

        // ��������� ���������� ������� ������
        _previousPlayerY = currentPlayerY;
    }

    /// <summary>
    /// ��������� ��������� � ��������� �������� (�� �������).
    /// </summary>
    /// <param name="platform">������ ���������</param>
    public static void PlatformActiveFalse(GameObject platform)
    {
        var collider = platform.GetComponent<BoxCollider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    /// <summary>
    /// ���������� ��������� � �������� ��������� (�� �������).
    /// </summary>
    /// <param name="platform">������ ���������</param>
    public static void PlatformActiveTrue(GameObject platform)
    {
        var collider = platform.GetComponent<BoxCollider>();
        if (collider != null)
        {
            collider.isTrigger = false;
        }
    }
}