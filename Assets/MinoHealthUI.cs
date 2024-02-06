using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinoHealthUI : MonoBehaviour
{
    private Slider slider;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null)
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.root.position + offset);
    }

    public void setHealthUI(float health,float maxHealth)
    {
  
        gameObject.SetActive(health>0);
        slider.maxValue = maxHealth;
        slider.value = health;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Color.red, Color.green, slider.normalizedValue);
 




    }
}
