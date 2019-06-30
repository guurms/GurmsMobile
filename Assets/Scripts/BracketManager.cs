using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketManager : MonoBehaviour
{
    private float spawnTimer;

    public GameObject bracketPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer < 0)
        {
            SpawnBracket();
            spawnTimer = 0.6f;
        }
    }

    private void SpawnBracket() 
    {
        //Want to pull from the bracketPool and place the object in the right spot and enable it
        Instantiate(bracketPrefab, new Vector3(Random.Range(-1f, 2f), -6, 0), Quaternion.identity, transform);
    }
}
