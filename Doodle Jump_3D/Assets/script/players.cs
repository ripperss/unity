using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class players : MonoBehaviour

{
    [SerializeField] Rigidbody _player;
    public player playermove;
    const byte JUMP = 25;
    
    private void Awake()
    {
        _player = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        
        playermove.PlaerControl(_player);  
        if(Input.GetKey(KeyCode.A))
        {
            playermove.PlayerMovementLeft(_player);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playermove.PlayerMavementRight(_player);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

     playermove.Jump(_player);
            

    }

}
