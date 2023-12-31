using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentHeal : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerHealth value;
    public Image image;
    private Slider slider;
    public GameObject go;
    bool decrease;



    void Start()
    {
        decrease = false;
        slider= GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
     {
        if (go != null)
            decrease = go.GetComponent<skill_set>().isInarmor;
        else
            decrease = false;
       
        transform.localRotation= Quaternion.Euler(0,0,0);
        if (slider.value <= slider.minValue)
        {
            image.enabled= false;

        }
        if(slider.value >= slider.minValue || !image.enabled)
        {
            image.enabled = true;
        }

        if (decrease)
        {
           
            float fillValue = (go.GetComponent<skill_set>().armorcont- go.GetComponent<skill_set>().armor) /value.maxHealth;
            slider.value = fillValue;
        }
        else
        {
        
            float fillValue = value.health / value.maxHealth;
            slider.value = fillValue;
        }

    }
   
}
