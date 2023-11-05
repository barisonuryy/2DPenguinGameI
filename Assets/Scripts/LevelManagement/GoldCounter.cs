using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GoldCounter : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI goldText;
    int gold;

    // Start is called before the first frame update
    void Start()
    {
        goldText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelManage s = GameObject.Find("LevelManager").GetComponent<LevelManage>();
        gold = s.score/6;
        goldText.text = "              + "+gold;
        PlayerPrefs.SetInt("goldCount", PlayerPrefs.GetInt("goldCount") + gold);



    }
    
}
