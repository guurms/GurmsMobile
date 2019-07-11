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
            //SpawnBracket();
            var bracket = SliderPool.Instance.Get();
            bracket.transform.position = new Vector3(Random.Range(-1f, 2f), -6, 0);
            bracket.gameObject.SetActive(true);
            spawnTimer = 0.6f;
            //number++;
        }
    }

    //private void SpawnBracket() 
    //{
    //    //We will need to pre-warm all our pools and edit the names inside the prefabs with this method if we want to keep this type of swipe checking. 
    //    //Gross string comparisons uuuugh
    //
    //
    //    //Want to pull from the bracketPool and place the object in the right spot and enable it
    //    var bracket = Instantiate(bracketPrefab, new Vector3(Random.Range(-1f, 2f), -6, 0), Quaternion.identity, transform);
    //    bracket.transform.GetChild(0).name = "left " + number;
    //    bracket.transform.GetChild(1).name = "right " + number;
    //}
}
