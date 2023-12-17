using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public float hiz = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float zYonu = Input.GetAxis("Vertical")*hiz;
        float xYonu = Input.GetAxis("Horizontal")*hiz;
        zYonu *= Time.deltaTime;
        xYonu *= Time.deltaTime;
        transform.Translate(xYonu,0,zYonu);
        
    }
}
