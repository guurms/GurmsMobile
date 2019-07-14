using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketManager : MonoBehaviour
{
    private float spawnTimer;

    public GameObject bracketPrefab;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer < 0)
        {
            var bracket = SliderPool.Instance.Get();
            bracket.transform.position = new Vector3(Random.Range(-1f, 2f), -6, 0);
            bracket.gameObject.SetActive(true);
            spawnTimer = 0.6f - ((GlobalSpeed.Instance.currentSpeed - 2f)* 0.1f);
            spawnTimer = Mathf.Clamp(spawnTimer, 0.1f, 0.6f);
        }
    }
}
