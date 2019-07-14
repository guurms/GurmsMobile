using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardScrolling : MonoBehaviour
{
    void Update()
    {
        transform.position += Time.deltaTime * GlobalSpeed.Instance.currentSpeed * Vector3.up;
    }
}
