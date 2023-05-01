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

    float timerSoul;
    float timerObstacle;

    private void Update()
    {
        if (timerSoul > maxTimeSoul)
        {
            Spawn(soulPool);
            timerSoul = 0;
        }

        if (timerObstacle > maxTimeObstacle)
        {
            Spawn(obstaclePool);
            timerObstacle = 0;
        }

        timerSoul += Time.deltaTime;
        timerObstacle += Time.deltaTime;
    }

    private void Spawn(ObjectPool pool)
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pooledObject = pool.GetPooledObject();
        pooledObject.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(100 - spawnPos.y * 10);
        Debug.Log(pooledObject.GetComponent<SpriteRenderer>().sortingOrder + " : " + Mathf.RoundToInt(100 - spawnPos.y * 10));
        if (pooledObject != null)
        {
            pooledObject.transform.position = spawnPos;
            pooledObject.SetActive(true);
        }
    }
}
