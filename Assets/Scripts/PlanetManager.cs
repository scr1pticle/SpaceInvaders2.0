using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public float spawnRate;
    public int planets;
    /* public Vector2 spawnRangeX;
     public Vector2 spawnRangeY;
     public Vector2 spawnRangeZ;*/
    public float range = 7;
    public List<GameObject> planetList;

    private Transform _playerPos;
    private int planetsInRange;
    void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnPlanets());
    }

    private IEnumerator SpawnPlanets()
    {
        while (true)
        {
            var posX = _playerPos.transform.position.x + _playerPos.forward.x * range + Random.Range(-3, 3);
            var posY = _playerPos.transform.position.y + _playerPos.forward.y * range + Random.Range(-3, 3);
            var posZ = _playerPos.transform.position.z + _playerPos.forward.z * range + Random.Range(-3, 3);
            var pos = new Vector3(posX, posY, posZ);
            var planet = Instantiate(planetList[Random.Range(0, planetList.Count)], pos, Quaternion.identity);
            planet.transform.LookAt(_playerPos);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
