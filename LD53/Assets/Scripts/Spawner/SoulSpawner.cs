using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    [SerializeField] ObjectPool soulPool;
    [SerializeField] ObjectPool obstaclePool;

    [SerializeField] float maxTimeSoul = 5f;
    [SerializeField] float maxTimeObstacle = 5f;
    [SerializeField] float heightRange = 0.5f;

    float timer;

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (timer > maxTimeSoul)
        {
            Spawn();
            timer = 0;
        }

        if (timer > maxTimeObstacle)
        {
            Spawn();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void Spawn(ObjectPool pool)
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));

        GameObject pooledObject = pool.GetPooledObject();

        if (pooledObject != null)
        {
            pooledObject.transform.position = spawnPos;
            pooledObject.SetActive(true);
        }
    }
}
