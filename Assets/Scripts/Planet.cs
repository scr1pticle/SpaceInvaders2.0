using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Planet : MonoBehaviour
{
    public float maxDist;
    private Transform _playerTrans;
    void Start()
    {
        _playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, .3f);
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, _playerTrans.position) > maxDist) Destroy(gameObject);
    }
}
