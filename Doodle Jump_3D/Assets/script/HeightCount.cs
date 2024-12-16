using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeightDisplay : MonoBehaviour
{
    // ссылка на текстовый компонент для вывода высоты
    public Text heightText;

    // ссылка на игрока
    public Transform player;

    // частота обновления высоты
    public float updateFrequency = 1f;

    private float timer = 0f;

    void Update()
    {
        // обновляем высоту с заданной частотой
        timer += Time.deltaTime;
        if (timer >= 1f / updateFrequency)
        {
            timer = 0f;
            UpdateHeightText();
        }
    }

    // обновляем текст с высотой игрока
    private void UpdateHeightText()
    {
        // получаем высоту игрока
        int height =   (int)player.position.y;

        // форматируем текст
        string heightString = $"Высота: {height:F2} м";

        // обновляем текст на экране
        heightText.text = heightString;
    }
}