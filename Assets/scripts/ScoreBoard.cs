using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
    public void ScoreHit(int scoreincreasedby)
    {
        score = score + scoreincreasedby;
        scoreText.text = score.ToString();
    }
}
