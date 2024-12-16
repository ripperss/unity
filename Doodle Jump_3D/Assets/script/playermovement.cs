using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class player : MonoBehaviour
{
    const float CONTROL_POSITION = -2.318f;
    const byte CONTROL_ROTATE = 90;
    const byte SPEED = 10;
    const byte JUMP = 20;
    const byte SPEED_MOVE = 40;
    

    public  void PlaerControl(Rigidbody player)
    {
        var Zplayer = player.transform.position.z;
        double borderRight = 7.5d;
        double borderLeft = -6;
        player.transform.localEulerAngles =new Vector3(player.position.x, CONTROL_ROTATE , player.position.z);
        player.transform.position = new Vector3(CONTROL_POSITION, player.position.y,player.position.z);
        if (Zplayer >= borderRight)
        {
            borderWorldRight(player);
        }
        else if (Zplayer <= borderLeft) 
        {
            borderWorldLeft(player);
        }       
    }
    public  void PlayerMovementLeft(Rigidbody player) 
    {
        player.transform.localEulerAngles = new Vector3(player.position.x, 180, player.position.z);
        player.AddForce((new Vector3(0, 0, -SPEED)) * Time.fixedDeltaTime * SPEED_MOVE);
    }
    public void PlayerMavementRight(Rigidbody player) 
    {
        player.transform.localEulerAngles = new Vector3(player.position.x, 0, player.position.z);
        player.AddForce(new Vector3(0, 0, SPEED) * Time.fixedDeltaTime * SPEED_MOVE);
    }
    public void Jump(Rigidbody player)
    {
        
         
            
            
        player.AddForce(new Vector3(0, 35, 0) * JUMP);
            
          
    }
    public void borderWorldRight(Rigidbody player)
    {
        short zBrderRight = -4;
        player.transform.position = new Vector3(player.position.x, player.position.y, zBrderRight);
    }
    public void borderWorldLeft(Rigidbody player) 
    {
        byte zBorderLeft = 5;
        player.transform.position = new Vector3(player.position.x, player.position.y,zBorderLeft);
    }
}
