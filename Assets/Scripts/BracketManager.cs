using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketManager : MonoBehaviour
{
    private float spawnTimer;
    private int number;

    public GameObject bracketPrefab;

    void Start()
    {
        number = 0;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer < 0)
        {
            SpawnBracket();
            spawnTimer = 0.6f;
            number++;
        }
    }

    private void SpawnBracket() 
    {
        //Want to pull from the bracketPool and place the object in the right spot and enable it
        var bracket = Instantiate(bracketPrefab, new Vector3(Random.Range(-1f, 2f), -6, 0), Quaternion.identity, transform);
        bracket.transform.GetChild(0).name = "left " + number;
        bracket.transform.GetChild(1).name = "right " + number;
    }
}
