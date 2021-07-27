using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{

    public static bool isOnLeftLane;
    public static bool isOnRightLane;
    public static bool isOnCenterLane;
    
    private float activeHighway = 1f;

    public Text scoreText;
    public Text multiplierText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.x == 0f)
        {
            
            isOnCenterLane = true;
            isOnLeftLane = false;
            isOnRightLane = false;
        } else if (this.transform.position.x == -3.4f)
        {
            
            isOnCenterLane = false;
            isOnLeftLane = true;
            isOnRightLane = false;
        } else if (this.transform.position.x == 3.4f)
        {
            
            isOnCenterLane = false;
            isOnLeftLane = false;
            isOnRightLane = true;
        }


      
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(-3.4f, -3.4f, 0f);

                //Vector3 leftMovement;
                //leftMovement = gameObject.transform.position;
                //leftMovement.x = leftMovement.x - 3.4f;
                //gameObject.transform.position = leftMovement;
            }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(0, -3.4f, 0f);

            //Vector3 leftMovement;
            //leftMovement = gameObject.transform.position;
            //leftMovement.x = leftMovement.x - 3.4f;
            //gameObject.transform.position = leftMovement;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(3.4f, -3.4f, 0f);

            //Vector3 leftMovement;
            //leftMovement = gameObject.transform.position;
            //leftMovement.x = leftMovement.x - 3.4f;
            //gameObject.transform.position = leftMovement;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = new Vector3(0, -3.4f, 0f);

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
        if (other.tag == "Enemy")
        {
            
            GameManagerLevels.currentScore -= 100;
            Debug.Log(GameManagerLevels.currentScore);
            scoreText.text = "" + GameManagerLevels.currentScore;
            GameManagerLevels.currentMultiplier = 1;
            GameManagerLevels.multiplierTracker = 0;
            multiplierText.text = "" + GameManagerLevels.currentMultiplier;

            //play sound of impact here
            Destroy(other.gameObject);

        }
    }

 
}
