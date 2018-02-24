using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(player_motor))]
public class player_controller : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    private player_motor motor;

    void Start()
    {
        motor = GetComponent<player_motor>();
    }

    void Update()
    {
        //calculate moveiemtnv elocuty as a 3d vector
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;

        //final movement vector
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        //apply movement
        motor.Move(_velocity);

    }
}
