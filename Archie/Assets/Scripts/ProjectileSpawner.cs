using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private float _timer;
    public GameObject projectile;
    void Start()
    {
        _timer = 0f;
    }

    void Update()
    {
        if (_timer > 0.5f)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            _timer = 0f;
        }
        _timer += Time.deltaTime;
    }

}
