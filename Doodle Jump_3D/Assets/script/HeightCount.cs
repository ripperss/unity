using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeightDisplay : MonoBehaviour
{
    // ������ �� ��������� ��������� ��� ������ ������
    public Text heightText;

    // ������ �� ������
    public Transform player;

    // ������� ���������� ������
    public float updateFrequency = 1f;

    private float timer = 0f;

    void Update()
    {
        // ��������� ������ � �������� ��������
        timer += Time.deltaTime;
        if (timer >= 1f / updateFrequency)
        {
            timer = 0f;
            UpdateHeightText();
        }
    }

    // ��������� ����� � ������� ������
    private void UpdateHeightText()
    {
        // �������� ������ ������
        int height =   (int)player.position.y;

        // ����������� �����
        string heightString = $"������: {height:F2} �";

        // ��������� ����� �� ������
        heightText.text = heightString;
    }
}