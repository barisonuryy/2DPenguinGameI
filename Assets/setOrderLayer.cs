using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setOrderLayer : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer m_Renderer;
    void Start()
    {
        m_Renderer=GetComponent<MeshRenderer>();
        m_Renderer.sortingOrder = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
