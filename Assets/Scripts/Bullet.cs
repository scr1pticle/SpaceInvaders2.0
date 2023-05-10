using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 4;
    public float speed;
    private Vector3 _forward = Vector3.zero;
    private float deathTime;
    private void Start()
    {
        deathTime = Time.time + lifetime;
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        if(Time.time >= deathTime) Destroy(gameObject);
    }
}
