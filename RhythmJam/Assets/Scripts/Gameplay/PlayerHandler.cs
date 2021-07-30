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

    [SerializeField] private Animator PlayerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (NoteObjectFunctionality.centerClap == true)
        //{
        //    StartCoroutine("playAndResetCenter");

        //}

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKey(KeyCode.Space))
        {
            if (isOnCenterLane)
            {
                PlayerAnimator.SetBool("CenterClapBool", true);
            }
        } else
        {
            PlayerAnimator.SetBool("CenterClapBool", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space))
        {
            if (isOnLeftLane || isOnCenterLane)
            {
                PlayerAnimator.SetBool("LeftClapBool", true);
            }
        }
        else
        {
            PlayerAnimator.SetBool("LeftClapBool", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space))
        {
            if (isOnRightLane || isOnCenterLane)
            {
                PlayerAnimator.SetBool("RightClapBool", true);
            }
        }
        else
        {
            PlayerAnimator.SetBool("RightClapBool", false);
        }


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

    //IEnumerator playAndResetCenter()
    //{
    //    PlayerAnimator.SetTrigger("ClapTrigger");
    //    yield return new WaitForSeconds(0.5f);
        
    //    NoteObjectFunctionality.centerClap = true;
    //}
     
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            
            GameManagerLevels.currentScore -= 100;
            Debug.Log(GameManagerLevels.currentScore);
            scoreText.text = "" + GameManagerLevels.currentScore;
            GameManagerLevels.currentMultiplier = 1;
            GameManagerLevels.multiplierTracker = 0;
            multiplierText.text = GameManagerLevels.currentMultiplier + "x";

            //play sound of impact here
            Destroy(other.gameObject);

        }
        else if(other.tag == "Return")
        {
            GameManager.Instance.LoadScene("Start_Screen");
        }
    }
}
