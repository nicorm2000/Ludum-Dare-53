using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTP : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] float distanceToTPX = 153.5f;
    [SerializeField] float distanceToTPY = 1.5f;

    Vector3 tp;

    private void Start()
    {
        tp = new Vector3(distanceToTPX, distanceToTPY, 0f);
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (gameObject.transform.position.x <= - distanceToTPX)
        {
            gameObject.transform.position = tp;
        }
    }
}
