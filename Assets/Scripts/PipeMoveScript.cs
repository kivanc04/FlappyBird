using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    private List<GameObject> pipesInUse = new();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pipesInUse.Count; i++)
        {
            pipesInUse[i].transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        }
    }
}  
 