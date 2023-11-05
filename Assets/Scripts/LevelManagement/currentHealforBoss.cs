using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentHealforBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public bossHealthSystem value;
    public Image image;
    private Slider slider;



    void Start()
    {

        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
   

        transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (slider.value <= slider.minValue)
        {
            image.enabled = false;

        }
        if (slider.value >= slider.minValue || !image.enabled)
        {
            image.enabled = true;
        }
        float fillValue = value.bossHealth / value.maxHealth;
        slider.value = fillValue;
        
       
        if (value.bossHealth >150&& value.bossHealth<=200) 
        {
            image.color = Color.green;
        }
        if (value.bossHealth > 100 && value.bossHealth < 150)
        {
            image.color= Color.yellow;
        }
        if (value.bossHealth < 100)
        {
            image.color = Color.red;
        }
    }

}