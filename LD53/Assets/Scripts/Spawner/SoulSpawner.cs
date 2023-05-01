using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    [SerializeField] ObjectPool soulPool;
    [SerializeField] ObjectPool obstaclePool;

    [SerializeField] float levelDuration = 5f;
    [SerializeField] float maxTimeSoul = 5f;
    [SerializeField] float maxTimeObstacle = 5f;
    [SerializeField] float randomization = 5f;
    [SerializeField] float heightRange = 0.5f;
    [SerializeField] float speed = 0.5f;

    float timerSoul = 0;
    float timerLevel = 0;
    float timerObstacle = 0;
    float randomsurplus = 0;

    public void SetupSpawner(float _levelEnemies, float _levelSouls, float _LevelDuration, float _speed, float _randomization)
    {
        levelDuration = _LevelDuration - _speed;
        maxTimeObstacle = levelDuration * 0.98f / _levelEnemies;
       
        maxTimeSoul = levelDuration * 0.98f / _levelSouls;
        speed = _speed;
        randomization = _randomization;
        
    }

    private void Update()
    {
        if(timerLevel <= levelDuration)
        {
            if (timerSoul > maxTimeSoul)
            {
                Spawn(soulPool);
                timerSoul = 0;
            }

            if (timerObstacle > maxTimeObstacle)
            {
                Spawn(obstaclePool);
                timerObstacle = Random.Range(0, randomization);
            }

            timerSoul += Time.deltaTime;
            timerObstacle += Time.deltaTime;
            timerLevel += Time.deltaTime;

        }
        
    }

    private void Spawn(ObjectPool pool)
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pooledObject = pool.GetPooledObject();
        pooledObject.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(100 - spawnPos.y * 10);
        
        if (pooledObject != null)
        {
            pooledObject.transform.position = spawnPos;
            pooledObject.SetActive(true);
        }
    }
}
