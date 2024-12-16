using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class moneymove : MonoBehaviour
{

    public static Action oncoinManager;
    [SerializeField] private Transform _moneyMove;
    
    
     const short SPEDROTATE = 70;
    const byte NORMAL_ANGELS = 30;
    
    
    private void FixedUpdate()
    {
        MoneyRotate();
        
    }
    public void MoneyRotate()
    {
        float rotateZ = _moneyMove.rotation.z;
        _moneyMove.Rotate(0, 1 * Time.fixedDeltaTime * SPEDROTATE,( rotateZ + NORMAL_ANGELS) * Time.deltaTime,Space.World );
        
    }
    private void OnTriggerEnter(Collider other)
    {
        oncoinManager?.Invoke();
        Destroy(gameObject);
    }
}
