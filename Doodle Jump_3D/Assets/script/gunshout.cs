using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sferamove : MonoBehaviour
{
    [SerializeField] private Vector3 sferavector;
    [SerializeField] private Transform player;
    void Update()
    {
        var sferamove = Vector3.Lerp(transform.position, player.position + sferavector,Time.deltaTime);
        transform.position = sferamove;
    }
}
