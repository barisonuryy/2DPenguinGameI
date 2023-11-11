using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeKey : MonoBehaviour
{
    bool isMove;
    public bool haveKey;
   
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        haveKey = false;
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&Input.GetKey(KeyCode.E))
        {
            isMove = true;
            
            anim.Play();
        }
        
    }
    private void Update()
    {
        if (isMove)
        {
            transform.Translate((Vector2.left*Time.deltaTime*10+Vector2.up*Time.deltaTime*5),Camera.main.transform);
            Destroy(gameObject, 0.5f);
        }
    }
    private void OnDestroy()
    {
        haveKey=true;
    }


}
