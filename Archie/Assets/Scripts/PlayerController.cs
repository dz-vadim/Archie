using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shootingSpawn;
    public float speedMove;

    private float gravityForce;
    private Vector3 moveVector;

    private CharacterController ch_controller;
    //private Animator ch_animator;
    private Joystick _mainJoystick;

    private GameObject[] _enemies;
    private GameObject _closestEnemy;

    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        //     ch_animator = GetComponent<Animator>();
        _mainJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }
    void Update()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        CharacterMove();
        GamingGravity();
    }
    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = _mainJoystick.Horizontal() * speedMove;
        moveVector.z = _mainJoystick.Vertical() * speedMove;
        if ((moveVector == Vector3.zero) && (GameObject.FindGameObjectWithTag("Enemy")))
        {
            transform.LookAt(FindClosestEnemy().transform);
            shootingSpawn.GetComponent<ProjectileSpawner>().enabled = true;
            shootingSpawn.GetComponent<ProjectileSpawner>().timer = 0f;
            //ch_animator.SetBool("Walk", false);
        }
        else
        {
            shootingSpawn.GetComponent<ProjectileSpawner>().enabled = false;

            //ch_animator.SetBool("Walk", false);
        }

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

    public GameObject FindClosestEnemy()
    {
        float minDistance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject thisEnemy in _enemies)
        {
            Vector3 different = thisEnemy.transform.position - position;
            float currentDistance = different.sqrMagnitude;
            if (currentDistance < minDistance)
            {
                _closestEnemy = thisEnemy;
                minDistance = currentDistance;
            }
        }
        return _closestEnemy;
    }
}


