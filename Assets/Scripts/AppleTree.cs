using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab; // meters per second
    public float maxSpeed = 2f;
    public float leftOrRightEdge = 20f;
    public float probabilityOfDirChange = 0.1f;// 10% of frames
    public float delayBetweenDropsInSecs = 0.1f;// 

    public int dir = 1;

    void Start()
    {
    //    applePrefab = GameObject.FindGameObjectWithTag("Apple");
        InvokeRepeating("DropApple",2f,delayBetweenDropsInSecs);
    }

    void Update()
    {
        //Move
        Vector3 pos = transform.position;
        pos.x += maxSpeed * dir * Time.deltaTime;
        this.transform.position = pos;
        if (pos.x < -leftOrRightEdge)
        {
            dir = 1;
        }else if (pos.x>leftOrRightEdge)
        {
            dir = -1;
        }
        else if(UnityEngine.Random.value< probabilityOfDirChange)
        {
            dir *= -1;
        }
    }

    // Update is called once per frame
    void UpdateOri()
    {
        //Move
        Vector3 pos = transform.position;
        pos.x += maxSpeed * Time.deltaTime;
        transform.position = pos;
        //Check for dir. change and change dir. if becessary
        if (pos.x < -leftOrRightEdge)
        {
            maxSpeed = Mathf.Abs(maxSpeed);
        }
        else if (pos.x > leftOrRightEdge)
        {
            maxSpeed = -Mathf.Abs(maxSpeed);
        }

    }

    public void DropApple()
    {
        Debug.Log("Dropping..");
        GameObject apple = Instantiate(applePrefab, this.transform.position, Quaternion.identity);
        AudioManager.PlayClip("Throw");
    }
}
