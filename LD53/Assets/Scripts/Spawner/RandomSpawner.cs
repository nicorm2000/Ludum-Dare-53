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
}
