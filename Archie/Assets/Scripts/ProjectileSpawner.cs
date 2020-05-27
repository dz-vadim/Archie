using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    //private Transform _player;
    public GameObject projectile;
    void Start()
    {
       // _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(projectile, transform.position, transform.rotation);

        }

        //Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
