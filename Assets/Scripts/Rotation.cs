using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 5;
    public Vector3 direction;

    void Update()
    {
        transform.Rotate(direction.normalized * speed * Time.deltaTime);
    }
}
