using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemiesProjectile : MonoBehaviour
{
    public float speed;
    private int _damage = 20;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<PlayerHealthStatus>().TakeDamege(_damage);
            print(Time.time);
            Destroy(gameObject);
        }
        else if ((collision.transform.gameObject.tag == "Enemy") )
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
