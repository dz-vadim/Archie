using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    /*
    private GameObject[] _enemies;
    private GameObject _closestEnemy;
    void Start()
    {

        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.P)) && (GameObject.FindGameObjectWithTag("Enemy")))
        {
            print(FindClosestEnemy().name);

        }
    }

    private GameObject FindClosestEnemy()
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
    */
}
