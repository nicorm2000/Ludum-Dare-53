using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1.5f;
    [SerializeField] float heightRange = 0.5f;
    [SerializeField] GameObject soul;

    float timer;

    private void Start()
    {
        SpawnSoul();
    }

    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnSoul();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnSoul()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));

        GameObject soul = ObjectPool.instance.GetPooledObject();

        if (soul != null)
        {
            soul.transform.position = spawnPos;
            soul.SetActive(true);
        }
    }
}
