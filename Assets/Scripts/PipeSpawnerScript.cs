using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class PipeSpawnerScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 2.0f;
    private float timer = 0;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        var aspectRatio = Screen.width / Screen.height; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            //Instantiate(pipe, new Vector3(50, Random.RandomRange(-height, height), 17.7f), transform.rotation);

            GameObject pipe = ObjectPoolScript.instance.GetPooledObject();
            if (pipe != null) {
                pipe.transform.position = new Vector3(44, Random.RandomRange(-height, height), 17.7f);
                pipe.SetActive(true);
                timer = 0; 
            }
        }
    }
}