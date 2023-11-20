using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffectBlue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float slideSpeed;
    [SerializeField] GameObject verticalStick;
    [SerializeField] float rotateSpeed;
    public bool isShiftable;
    // Start is called before the first frame update
    void Start()
    {
        isShiftable = false;
    }

    // Update is called once per frame
    void Update()
    {
        float yValue = verticalStick.transform.position.y;
        float xValue = transform.GetChild(0).transform.localPosition.x;
        if (isShiftable && xValue <= 1.17f)
        {
            transform.GetChild(0).transform.Translate(Vector2.right * Time.deltaTime * slideSpeed);
        }
       else if (!isShiftable &&xValue >= 0.87f)
        {
            transform.GetChild(0).transform.Translate(Vector2.left * Time.deltaTime * slideSpeed);
        }
        if (isShiftable && yValue <= -0.5f)
        {
            verticalStick.transform.Translate(Vector2.up * Time.deltaTime * slideSpeed);
        }
        else if ( yValue >= -6.55f)
        {
            isShiftable = false;
            verticalStick.transform.Translate(Vector2.down * Time.deltaTime * slideSpeed);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            
            isShiftable = true;
            
        }
    }
  
}
