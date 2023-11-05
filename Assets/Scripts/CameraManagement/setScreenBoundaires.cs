using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setScreenBoundaires : MonoBehaviour
  {
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeigth;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeigth = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewpos = transform.position;
        viewpos.x = Mathf.Clamp(viewpos.x, screenBounds.x + objectWidth, screenBounds.x * -1 + objectWidth);
        viewpos.y = Mathf.Clamp(viewpos.y, screenBounds.y + objectHeigth, screenBounds.y * -1 + objectHeigth);
        transform.position = viewpos;
    }
   
}
