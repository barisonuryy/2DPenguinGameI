using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelManage s = GameObject.Find("LevelManager").GetComponent<LevelManage>();
        score =s.score;
        scoreText.text = score.ToString();
       

      
    }
}