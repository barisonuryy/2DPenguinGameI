using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentMana : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public skill_set value;
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
        if (value.mana >= 10)
            image.color = Color.green;
        else
            image.color = Color.magenta;
        float fillValue = value.mana / value.maxMana;
        slider.value = fillValue;
    }

}
