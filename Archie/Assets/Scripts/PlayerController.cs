using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMove;
    public float jumpPower;
    private float gravityForce;
    private Vector3 moveVector;
    private CharacterController ch_controller;
    private Animator ch_animator;
    private Joystick _mainJoystick;
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        //     ch_animator = GetComponent<Animator>();
              _mainJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        GamingGravity();
    }
    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = _mainJoystick.Horizontal() * speedMove;
        moveVector.z = _mainJoystick.Vertical() * speedMove;
/*
        if (moveVector.x != 0 || moveVector.z != 0)
            ch_animator.SetBool("Walk", true);
        else ch_animator.SetBool("Walk", false);
*/
        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);
    }
    private void GamingGravity()
    {
        if (!ch_controller.isGrounded) { gravityForce -= 20f * Time.deltaTime; }
        else { gravityForce = -1f; }            
    }
}