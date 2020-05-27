using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AirmanBehavior : MonoBehaviour
{
    private float timer;
    public GameObject projectileSpawner; 
    // Start is called before the first frame update
    void Start()
    {
        projectileSpawner.SetActive(false);
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            timer = 0f;
            projectileSpawner.SetActive(true);
        }
        if (timer > 3.1f)
        {
             projectileSpawner.SetActive(false);            
        }
        timer += Time.deltaTime;
    }

    private void Shooting()
    {

    }
}
