using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public ObjectPool instance;

    [SerializeField] List<GameObject> pooledObjects = new List<GameObject>();
    
    public GameObject GetPooledObject()
    {
        int maxIterations=0;

        GameObject objectToReturn = null;

        while (objectToReturn == null)
        {
            int random = Random.Range(0, pooledObjects.Count);

            maxIterations++;

            if (maxIterations == 100)
            {
                return null;
            }

            if (!pooledObjects[random].activeInHierarchy)
            {
                return pooledObjects[random];
            }
        }
        return null;
    }
}
