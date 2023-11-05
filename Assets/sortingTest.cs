using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortingTest : MonoBehaviour
{
    SkinnedMeshRenderer myMeshRenderer;
    MeshRenderer myRenderer2;
    // Start is called before the first frame update
    void Start()
    {
        myMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        myRenderer2 = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myRenderer2.sortingOrder = 1;
        myMeshRenderer.sortingOrder = 2;
    }
}
