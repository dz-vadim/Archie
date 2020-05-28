using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AirmanBehavior : MonoBehaviour
{
    private float _timer;
    private float _speed;
    private bool _isMoving;
    private GameObject _player;
    private Vector3 _newDirection;
    private CharacterController ch_controller;


    public GameObject projectileSpawner; 
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0f;
        _speed = 5f;
        projectileSpawner.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player");
        ch_controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > 3.0f)
        {
            SwitchState();
            _timer = 0f;
        }
        else Moving();
        _timer += Time.deltaTime;
    }

    private void Shooting()
    {
       // _timer = 0f;
        transform.LookAt(_player.transform);
        projectileSpawner.SetActive(true);
        _newDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }
    private void Moving()
    {
       // _timer = 0f;
        ch_controller.Move(_newDirection * _speed * Time.deltaTime);
        projectileSpawner.SetActive(false);
    }

    private void SwitchState()
    {
        if (_isMoving) { Shooting(); _isMoving = false; }
        else { Moving(); _isMoving = true; }
    }
}
