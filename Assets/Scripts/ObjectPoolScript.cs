using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using static UnityEditor.MaterialProperty;

public class ObjectPoolScript : MonoBehaviour
{

    public static ObjectPoolScript instance;
    public List<GameObject> pooledObjects = new List<GameObject>();
    public int amountToPool = 10;
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

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(pipePrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }


    public GameObject GetPooledObject()
    {
        var item = pooledObjects[index % pooledObjects.Count];

        index++;
        return item;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }
    public void ReleaseObjectPool(GameObject gameObject)
    {
        if (gameObject.transform.position.x < -39.1)
        {
            gameObject.SetActive(false);
            pooledObjects.Add(gameObject);
        }
    }


}