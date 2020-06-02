using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public float timeToSpawn;
    public float timer;
    public GameObject projectile;
    void Start()
    {
        timeToSpawn = 1f;
        timer = timeToSpawn;
       // Instantiate(projectile, transform.position, transform.rotation);
    }

    void Update()
    {
        if (timer <= 0f)
        {
            timer = timeToSpawn;
            Instantiate(projectile, transform.position, transform.rotation);
        }
        timer -= Time.deltaTime;
    }

}
