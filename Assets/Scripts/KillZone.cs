using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public int fallenApples = 0;
    public int applesToDeath = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider enter....");
        if (other.gameObject.tag == "Apple")
        {
           ((GameController)GameController._instance).AppleMissed();
           Destroy(other.gameObject);
        }

    }
    private void OnTriggerEnterOri(Collider other)
    {
        Debug.Log("collider enter....");
        if (other.gameObject.tag == "Apple")
        {
            Destroy(other.gameObject);
            fallenApples++;
            if (fallenApples >= applesToDeath)
            {
                
                var baskets = FindObjectsOfType<Basket>();
                if (baskets != null && baskets.Length >0)
                {
                    Debug.Log("Destroying basket...");
                    Destroy(baskets[0].gameObject);
                    fallenApples = 0;
                }
            }

        }
            
    }
}
