/*******************************************************
    Autor: Antonio Mateo [ lPinchol ]
    Date:  31-05-2015
********************************************************/

using UnityEngine;
using System.Collections;


public class Generator : MonoBehaviour
{
    public GameObject[] obj;
    public float minTime = 1.0f;
    public float maxTime = 2.0f;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        Instantiate(obj[Random.Range(0, obj.Length)],transform.position,Quaternion.identity);
        Invoke("Generate",Random.Range(minTime,maxTime));
    }
}