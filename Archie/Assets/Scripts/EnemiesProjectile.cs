using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesProjectile : MonoBehaviour
{
    public float speed;
    private Transform _player;
    private Vector3 _target;
    private int _damage = 20;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _target = _player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
        if (transform.position == _target)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<PlayerHealthStatus>().TakeDamege(_damage);
            print(Time.time);
        }
        if (collision.transform.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
