using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterIgnoreCollision : MonoBehaviour
{
    public GameObject airman;
    public GameObject projectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<AirmanBehavior>())
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), transform.GetComponent<Collider>());
            Physics.IgnoreCollision(collision.gameObject.GetComponentInParent<Collider>(), transform.GetComponent<Collider>());

        }
    }

}
