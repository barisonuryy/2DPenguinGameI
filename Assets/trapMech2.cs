using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapMech2 : MonoBehaviour
{
    [SerializeField] Transform initialP, endPoint;
    public float RotateSpeed;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Speed * Time.deltaTime, 0,0), Camera.main.transform);
        transform.Rotate(RotateSpeed* Time.deltaTime*Vector3.forward);
        if (transform.position.x <= initialP.position.x || transform.position.x >= endPoint.position.x)
        {
            Speed =- Speed;
            RotateSpeed = -RotateSpeed;
        }
    }
}
