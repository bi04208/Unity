using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        while (Player.life > 0)  
        {
            score.text = "Score : " + scoreValue;
        }
    }
}
