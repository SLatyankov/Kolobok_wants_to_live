using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] busts;
    [SerializeField] float width;
    [SerializeField] float repeatTime;
    void Start()
    {
        InvokeRepeating("AddBusts", repeatTime, repeatTime);
    }
    void AddBusts()
    {
        float x = Random.Range(-width, width);
        float z = Random.Range(-width, width);
        Instantiate(busts[Random.Range(0,busts.Length)], new Vector3(x, 0.5f, z), transform.rotation);
    }
}
