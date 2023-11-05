using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectObject : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelManage collectScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject,0.1f);
            collectScore.score += 50;
        }
    }
}
