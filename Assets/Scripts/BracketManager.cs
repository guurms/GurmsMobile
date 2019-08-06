using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketManager : MonoBehaviour
{
    private float spawnTimer;
    private float beginSpawnTimer = 1f;
    private float nextSpawnTimer;

    public float yAxis = -6f;

    //private Camera ourCam;

    private void Awake()
    {
        //ourCam = Camera.main;
    }

    private void Start()
    {
        spawnTimer = 0;
        nextSpawnTimer = (beginSpawnTimer * GlobalSpeed.Instance.startSpeed) / GlobalSpeed.Instance.currentSpeed;
        //leftRaycastPosition.position = ourCam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        //rightRaycastPosition.position = ourCam.ScreenToWorldPoint(new Vector3(ourCam.pixelWidth, ourCam.pixelWidth, 0));
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
                bracket.transform.position = GetPosition(bracket);

                bracket.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                bracket.SetActive(true);
            }
            spawnTimer = 0;
            //spawnTimer = Mathf.Clamp(spawnTimer, 0.1f, 0.6f);
        }
    }

    private Vector3 GetPosition(GameObject bracket)
    {
        int random = Random.Range(0, 3);

        if(random == 0)
        {
            //Left gap
            bracket.tag = "Left";
            return new Vector3(Random.Range(-3.5f, -0.6f), yAxis, 0);
        }
        else if (random == 1)
        {
            //Middle gap
            bracket.tag = "Middle";
            return new Vector3(Random.Range(-0.6f, 0.6f), yAxis, 0);
        }
        else
        {
            //Right gap
            bracket.tag = "Right";
            return new Vector3(Random.Range(0.6f, 3.5f), yAxis, 0);
        }
    }
}
