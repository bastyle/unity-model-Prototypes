using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    private float originalZ = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        originalZ=this.transform.position.z;
        //ScoretxText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosScreenCoord = Input.mousePosition;
        Vector3 mousePosWorldCoord = Camera.main.ScreenToWorldPoint(mousePosScreenCoord);



        Vector3 pos = this.transform.position;
        
        pos.x = mousePosWorldCoord.x;
        pos.z =originalZ;
        //pos.y = 1;
        this.transform.position = pos;

        
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            
            
            ((GameController)GameController._instance).AddScore(collidedWith.gameObject.GetComponent<Apple>().value);
            Destroy(collidedWith, 0.1f);
            AudioManager.PlayClip("ApplePicked");
            
        }
      
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy Basket");
        FindObjectOfType<GameController>().UpdateLives(-1);
    }
}

