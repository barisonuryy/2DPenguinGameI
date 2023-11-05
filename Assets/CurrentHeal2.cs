using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHeal2 : MonoBehaviour
{
    public PlayerHealth value;
    public Image image;
    private Slider slider;

    bool decrease;
    void Start()
    {

        decrease = false;
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
        float fillValue = value.health / value.maxHealth;
        slider.value = fillValue;



    }
}
