using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScript : MonoBehaviour
{

    public static ObjectPoolScript instance;
    public List<GameObject> pooledObjects = new();
    [SerializeField] public GameObject pipePrefab;
    private float timer = 0;
    int index = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private GameObject CreateObject() {
        var obj = Instantiate(pipePrefab);
        pooledObjects.Add(obj);
        obj.SetActive(false);
        return obj;
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (pooledObjects[i].activeInHierarchy) continue;
            return pooledObjects[i];
        }
        return CreateObject();
    }
    
    public void ReleaseObjectPool(GameObject go)
    {
        go.SetActive(false);
    }


}