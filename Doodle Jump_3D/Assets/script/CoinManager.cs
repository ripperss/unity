using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    public short NumberOfCoins;
    private void FixedUpdate()
    {
        WriteNumberOfCoins();
    }
    public void CoinIncrease()
    {
        NumberOfCoins++;
    }
    public  void WriteNumberOfCoins()
    {
        _coinText.text = Convert.ToString(NumberOfCoins);
    }
    private void OnEnable()
    {
        moneymove.oncoinManager += CoinIncrease;
    }
    private void OnDisable()
    {
        moneymove.oncoinManager -= CoinIncrease;
    }

}