using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{

    private bool isOnLeftLane;
    private bool isOnRightLane;
    
    private float activeHighway = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.x == 0f)
        {
            Debug.Log("In the center lane");
            isOnLeftLane = false;
            isOnRightLane = false;
        } else if (this.transform.position.x == -3.4f)
        {
            Debug.Log("In the left lane");
            isOnLeftLane = true;
            isOnRightLane = false;
        } else if (this.transform.position.x == 3.4f)
        {
            Debug.Log("In the right lane");
            isOnLeftLane = false;
            isOnRightLane = true;
        }


      
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(-3.4f, -4f, 0f);

                //Vector3 leftMovement;
                //leftMovement = gameObject.transform.position;
                //leftMovement.x = leftMovement.x - 3.4f;
                //gameObject.transform.position = leftMovement;
            }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(0, -4f, 0f);

            //Vector3 leftMovement;
            //leftMovement = gameObject.transform.position;
            //leftMovement.x = leftMovement.x - 3.4f;
            //gameObject.transform.position = leftMovement;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(3.4f, -4f, 0f);

            //Vector3 leftMovement;
            //leftMovement = gameObject.transform.position;
            //leftMovement.x = leftMovement.x - 3.4f;
            //gameObject.transform.position = leftMovement;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = new Vector3(0, -4f, 0f);

            //Vector3 leftMovement;
            //leftMovement = gameObject.transform.position;
            //leftMovement.x = leftMovement.x - 3.4f;
            //gameObject.transform.position = leftMovement;
        }




        // if (!isOnRightLane)
        //{

        //     if (isOnLeftLane)
        //     {
        //         if (Input.GetKeyDown(KeyCode.RightArrow))
        //         {
        //             Vector3 rightMovement;
        //             rightMovement = gameObject.transform.position;
        //             rightMovement.x = rightMovement.x + 6.8f;
        //             gameObject.transform.position = rightMovement;
        //         }
        //     } else 
        //     {
        //         Vector3 rightMovement;
        //         rightMovement = gameObject.transform.position;
        //         rightMovement.x = rightMovement.x + 3.4f;
        //         gameObject.transform.position = rightMovement;
        //     }
        // }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "RevealBox")
        {
            activeHighway = 1f;
        } else if (other.tag == "Highway2Box")
        {
            activeHighway = 2f;
            Debug.Log("highway 2");
        }
    }
}
