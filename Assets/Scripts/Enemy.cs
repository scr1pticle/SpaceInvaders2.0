using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    public AudioClip shoot;
    public GameObject hands;
    public float bulletLifetime = 5;
    public float cooldown = 3;
    public float range;
    public Transform shootingPoint;
    public GameObject bullet;
    private Transform _playerTrans;
    private AudioSource _audio;

    void Start()
    {
        _playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        _audio = GetComponent<AudioSource>();
        StartCoroutine(Shoot());
    }

    void Update()
    {
        hands.transform.LookAt(_playerTrans.position);
        transform.LookAt(new Vector3(_playerTrans.position.x, transform.position.y, _playerTrans.position.z));
        if (Vector3.Distance(transform.position, _playerTrans.position) > range) StopAllCoroutines();
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(cooldown);
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        _audio.PlayOneShot(shoot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Bullet")) Destroy(gameObject);
    }
}
