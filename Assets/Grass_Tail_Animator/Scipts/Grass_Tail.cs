using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass_Tail : MonoBehaviour
{
    public string anim_play;
    Animator GrassTail_animator;
    public bool random_start;
    private float random_count;
    public string[] grass_animations;
    public string[] tail_animations;
    public string[] other_animations;
    
    // Start is called before the first frame update
    void Start()
    {

        GrassTail_animator = gameObject.GetComponent<Animator>();
        if (random_start == true)
        {
            random_count = Random.Range(0, GrassTail_animator.GetCurrentAnimatorStateInfo(0).length);
            GrassTail_animator.Play(anim_play, 0, random_count);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
