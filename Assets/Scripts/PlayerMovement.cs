using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        float vertical = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Rotate(vertical, horizontal, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Planet")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy") || other.transform.CompareTag("Bullet"))
        {
            GetComponent<Health>().TakeDamage(10);
            Destroy(other.gameObject);
        }
    }
}
