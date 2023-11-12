using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class showKey : MonoBehaviour
{

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();  
    }

    // Update is called once per frame
    void Update()
    {

       
   
        
    }
    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }
    private void OnDisable()
    {
    StartCoroutine (FadeOut());
    }
    IEnumerator  FadeOut()
    {
        for (float f = 1.0f; f >= -0.05f; f -= 0.05f)
        {

            image.tintColor = new Color(1, 1, 1, f);
            yield return new WaitForSeconds(0.05f);
        }

    }
    IEnumerator FadeIn()
    {
        for (float f = -0.05f; f <= 1.0f; f += 0.05f)
        {

            image.tintColor = new Color(1, 1, 1, f);
            yield return new WaitForSeconds(0.05f);
        }

    }
}
