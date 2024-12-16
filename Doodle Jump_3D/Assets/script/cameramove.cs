using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class camerf : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 ofcet;
    [SerializeField] private float _smoothing = 1f;
    [SerializeField] private float _speedCamera = 3f;

    void FixedUpdate()
    {
        float camerapos = _camera.transform.position.y;
        float playerpos = _player.position.y;
        double normalDistance = 1.5d;
        if ( playerpos   >= camerapos + normalDistance)
        {
            CameraMove();
        }
    }
    public void CameraMove()
    {
        transform.Translate( new Vector3(0, 0.9f * Time.fixedDeltaTime * _speedCamera, 0), Space.World);
    }
}
