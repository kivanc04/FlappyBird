using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour {
    public Camera camera;
    public float pipeWidth = .5f;
    public float spawnRate = 2.0f;
    public float moveSpeed = 5f;
    public float MaxSpeed;
    
    private float timer = 0;
    public float height;
    private float _screenEdge;
    private List<GameObject> pipesInUse = new();
    
    void Start() {
        var aspectRatio = Screen.width / (float)Screen.height;
        _screenEdge = camera.orthographicSize * aspectRatio + pipeWidth;
    }

    void Update()
    {
        
            if (moveSpeed < MaxSpeed)
            {
                moveSpeed += 0.1f * Time.deltaTime;
            }
            for (int i = 0; i < pipesInUse.Count; i++)
            {
                pipesInUse[i].transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                if (pipesInUse[i].transform.position.x < -_screenEdge)
                {
                    DespawnPipe(pipesInUse[i]);
                }
            }


            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnPipe();
                timer = 0;
            }
        
    }
    
    public void DespawnPipe(GameObject pipe) {
        pipesInUse.Remove(pipe);
        ObjectPoolScript.instance.ReleaseObjectPool(pipe);
    }

    public void SpawnPipe() {
        var pipe = ObjectPoolScript.instance.GetPooledObject();
        if (pipe != null) {
            pipe.transform.position = new Vector3(_screenEdge, Random.RandomRange(-height, height), 0);
            pipe.SetActive(true);
        }
        pipesInUse.Add(pipe);
    }
}