using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayChanging : MonoBehaviour
{

    public float rotation = 0f;
    public Vector3 angles = Vector3.forward;
    public float keySpeed = 25f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0f, 0f, 120f);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, -120f);
        }
            
    }

        
}
