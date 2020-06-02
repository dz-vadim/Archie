using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreeperBehavior : MonoBehaviour
{
    private CharacterController ch_controller;

    // Start is called before the first frame update
    private GameObject _player;
    public float speed;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        ch_controller = GetComponent<CharacterController>();

        // speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(_player.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


}
