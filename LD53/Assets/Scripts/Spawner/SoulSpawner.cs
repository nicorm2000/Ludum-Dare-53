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
        
    }

    private void SpawnSoul()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject soulGameObject = Instantiate(soul, spawnPos, Quaternion.identity);

        Destroy(soulGameObject, 10f);
    }
}
