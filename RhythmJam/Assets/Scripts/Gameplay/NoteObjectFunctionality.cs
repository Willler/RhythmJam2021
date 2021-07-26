using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectFunctionality : MonoBehaviour
{
    public bool canBePressed;
    public bool canBePressedLeft;
    public bool canBePressedRight;

    public KeyCode keyToPress;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHandler.isOnLeftLane)
        {
            if (Input.GetKey(keyToPress) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(keyToPress))

            {
                
                if (canBePressedLeft)
                {
                    gameObject.SetActive(false);
                    GameManagerLevels.instance.noteHit();
                }
            }
        } else if (PlayerHandler.isOnRightLane)
        {
            if (Input.GetKey(keyToPress) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(keyToPress))

            {
                
                if (canBePressedRight)
                {
                    gameObject.SetActive(false);
                    GameManagerLevels.instance.noteHit();
                    
                }
            }
        } else
        {
            if (Input.GetKey(keyToPress) && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow) && Input.GetKey(keyToPress))

            {
                
                if (canBePressed)
                {
                    gameObject.SetActive(false);
                    GameManagerLevels.instance.noteHit();
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (PlayerHandler.isOnLeftLane)
            {
                canBePressedLeft = true;
            } else if (PlayerHandler.isOnCenterLane)
            {
                canBePressed = true;
            } else if (PlayerHandler.isOnRightLane)
            {
                canBePressedRight = true;
            }
            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canBePressed = false;
            GameManagerLevels.instance.noteMissed();
        }
    }
}
