using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{ 
    Color c;
  public IEnumerator FadeOut(SpriteRenderer sr)
    {
        for (float f = 1.0f; f >= -0.05f; f -= 0.05f)
        {
            if(sr != null)
            {
                c = sr.material.color;
                c.a = f;
                sr.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
            
        }

    }
   public IEnumerator FadeIn(SpriteRenderer sr)
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            if(sr != null)
            {
                c = sr.material.color;
                c.a = f;
                sr.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
          
        }

    }
}
