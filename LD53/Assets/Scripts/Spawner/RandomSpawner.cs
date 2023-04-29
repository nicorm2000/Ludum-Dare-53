using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    //[SerializeField] GameObject objectToSpawn;
    //[SerializeField] float spawnRate = 3f;
    //[SerializeField] float spawnDistance = 10f;
    //[SerializeField] float objectSpeed = 5f;

    //private float lastSpawnTime;
    //private Camera mainCamera;

    //private void Start()
    //{
    //    lastSpawnTime = Time.time;
    //    mainCamera = Camera.main;
    //}

    //private void Update()
    //{
    //    //Will check if it's time to spawn a new object
    //    if (Time.time - lastSpawnTime >= spawnRate)
    //    {
    //        SpawnObject();
    //        lastSpawnTime = Time.time;
    //    }
    //}

    //private void SpawnObject()
    //{
    //    //Calculate spawn position
    //    Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * spawnDistance;

    //    //Spawn object and set its speed
    //    GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    //    spawnedObject.GetComponent<Rigidbody2D>().velocity = -1f * (mainCamera.transform.right) * objectSpeed;

    //    //Check if object is out of camera view
    //    StartCoroutine(DestroyIfOutOfView(spawnedObject));
    //}

    //IEnumerator DestroyIfOutOfView(GameObject spawnedObject)
    //{
    //    while (IsInCameraView(spawnedObject))
    //    {
    //        yield return null;
    //    }
    //}

    //bool IsInCameraView(GameObject spawnedObject)
    //{
    //    //Calculate object screen position
    //    Vector3 objectScreenPosition = mainCamera.WorldToScreenPoint(spawnedObject.transform.position);

    //    //Check if object is out of camera view
    //    return objectScreenPosition.x > 0 && objectScreenPosition.x < Screen.width && objectScreenPosition.y > 0 && objectScreenPosition.y < Screen.height;
    //}
}
