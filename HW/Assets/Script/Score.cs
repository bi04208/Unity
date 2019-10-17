using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue;
    public bool check = true;
    Text score;
    Text life;
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        score = GetComponent<Text>();
        StartCoroutine(WaitForIt());
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.life > 0)  
        {
            check = false;
            score.text = "Score : " + scoreValue+"\n"+ "Life : " + Player.life; 

        }
    }
    IEnumerator WaitForIt()
    {
        check = true;
        scoreValue++;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(WaitForIt());
    }
}
