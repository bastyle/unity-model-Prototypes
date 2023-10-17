using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static  GameController _instance;

    [Header("Public Props")]
    public GameObject basketPrefab;

    public int numberOfbaskets = 3;

    public float basketYStart = -10f;
    public float basketDY= 3;

    //public Text scorePoints;
    //public Text scoreHighPoints;
    public Text basketLives;

    public Scoring scoringController;

    public List<GameObject> basketList;

    public string sceneName="";


    // Start is called before the first frame update
    void Start()
    {
       // scorePoints.text = "0";
        //scoreHighPoints.text = "0";
        basketLives.text = numberOfbaskets.ToString();
        scoringController = GameObject.Find("GUI").GetComponent<Scoring>();

        // generate baskets
        for (int i=0; i<numberOfbaskets; i++)
        {
            GameObject goBasket = Instantiate(basketPrefab);
            Vector3 basketPos = Vector3.zero;
            basketPos.y = basketYStart + i * basketDY;
            goBasket.transform.position = basketPos;
            //goBasket.GetComponent<Basket>().scorePoints = this.scorePoints;
            basketList.Add(goBasket);
        }
        _instance=this;
    }

    public void AppleMissed()
    {
        if (basketList.Count>0)
        {
            GameObject go = basketList[0];
            basketList.RemoveAt(0);
            AudioManager.PlayClip("AppleMissed"); 
            Destroy(go);
        }
        else
        {
            Debug.Log("Game Over!!");
            AudioManager.PlayClip("Game Over");
            SceneManager.LoadScene(sceneName);
        }

        
    }


   /* public void Score(int points)
    {
        int score = int.Parse(scorePoints.text);
        score += 100;
        scorePoints.text = score.ToString();
        scoreHighPoints.text = score.ToString();
    }*/

    public void UpdateLives(int lives)
    {
        numberOfbaskets += lives;
        basketLives.text = numberOfbaskets.ToString();
    }

    public void AddScore(int amount)
    {
        scoringController.score += amount;
        if (scoringController.score <= 0)
        {
            scoringController.score = 0;
        }
        scoringController.TRY_TO_SET_HIGHSCORE(scoringController.score);
    }

    void Update()
    {

    }
}
