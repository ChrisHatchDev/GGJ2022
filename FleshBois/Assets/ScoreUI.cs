using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour
{
    public Text ScoreText;
    public bool GameOverVersion;

    void Start()
    {
        
    }

    void Update()
    {
        //test();
        if (GameOverVersion)
        {
            ScoreText.text = "Score: " + GameManager.Instance.score.getCurrentScore().ToString();
        } else {
            ScoreText.text = GameManager.Instance.score.getCurrentScore().ToString();
        }
    }
    void test(){
        int doThing = Random.Range(0, 100);
        if(doThing > 97){
            if(doThing == 98)
                GameManager.Instance.score.addTumor(Random.Range(0.0f, 10.0f));
            else
                GameManager.Instance.score.addDamage(Random.Range(0.0f, 10.0f));
        }
    }
}
