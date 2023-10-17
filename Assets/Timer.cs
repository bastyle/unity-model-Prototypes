using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeInSec;
    // Start is called before the first frame update
    void Start()
    {
        timeInSec = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeInSec +=Time.deltaTime;
    }

    private void OnCollisionEnter(Collision col)
    {
        print(timeInSec%60);
    }
}
