using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketManager : MonoBehaviour
{
    private float spawnTimer;
    private float beginSpawnTimer = 1f;
    private float nextSpawnTimer;

    private void Start()
    {
        spawnTimer = 0;
        nextSpawnTimer = (beginSpawnTimer * GlobalSpeed.Instance.startSpeed) / GlobalSpeed.Instance.currentSpeed;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        nextSpawnTimer = (beginSpawnTimer * GlobalSpeed.Instance.startSpeed) / GlobalSpeed.Instance.currentSpeed;

        if (spawnTimer > nextSpawnTimer)
        {
            var bracket = LevelManager.Instance.GetRandomBracketBasedOnLevel();
            if (bracket)
            {
                bracket.transform.position = new Vector3(Random.Range(-1f, 2f), -6, 0);
                bracket.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                bracket.SetActive(true);
            }
            spawnTimer = 0;
            //spawnTimer = Mathf.Clamp(spawnTimer, 0.1f, 0.6f);
        }
    }
}
