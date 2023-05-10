using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Shooter : MonoBehaviour
{
    public AudioClip shoot;
    public GameObject bullet;
    public Transform shootingPoint;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
            _audio.PlayOneShot(shoot);
        }
    }
}
