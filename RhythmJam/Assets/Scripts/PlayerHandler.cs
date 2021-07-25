using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{

    private bool isOnLeftLane;
    private bool isOnRightLane;
    
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


        if (!isOnLeftLane)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector3 leftMovement;
                leftMovement = gameObject.transform.position;
                leftMovement.x = leftMovement.x - 3.4f;
                gameObject.transform.position = leftMovement;
            }
        } 

        if (!isOnRightLane)
       {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector3 rightMovement;
                rightMovement = gameObject.transform.position;
                rightMovement.x = rightMovement.x + 3.4f;
                gameObject.transform.position = rightMovement;
            }
        }

      
    }
}
