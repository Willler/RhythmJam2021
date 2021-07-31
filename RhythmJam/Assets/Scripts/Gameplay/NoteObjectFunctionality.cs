using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectFunctionality : MonoBehaviour
{
    public bool canBePressed;
    public bool canBePressedLeft;
    public bool canBePressedRight;


    public KeyCode keyToPress;

    public GameObject noteHitEffect;

    public static bool centerClap;

    
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
                    
                    
                    if (this.transform.position.y >= -3)
                    {
                        
                        GameManagerLevels.instance.NormalHit();
                        Instantiate(noteHitEffect, transform.position, noteHitEffect.transform.rotation);
                    }
                    else if (this.transform.position.y >= -3.2)
                    {
                        
                        GameManagerLevels.instance.GoodHit();
                        Instantiate(noteHitEffect, transform.position, noteHitEffect.transform.rotation);
                    }
                    else
                    {
                        
                        GameManagerLevels.instance.PerfectHit();
                        Instantiate(noteHitEffect, transform.position, noteHitEffect.transform.rotation);
                    }

                }
            }
        } else if (PlayerHandler.isOnRightLane)
        {
            if (Input.GetKey(keyToPress) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(keyToPress))

            {
                
                if (canBePressedRight)
                {
                    gameObject.SetActive(false);
                    if (this.transform.position.y >= -3)
                    {
                        Debug.Log("Normal Hit");
                        GameManagerLevels.instance.NormalHit();
                        Instantiate(noteHitEffect, transform.position, noteHitEffect.transform.rotation);
                    }
                    else if (this.transform.position.y >= -3.2)
                    {
                        Debug.Log("Good Hit");
                        GameManagerLevels.instance.GoodHit();
                        Instantiate(noteHitEffect, transform.position, noteHitEffect.transform.rotation);
                    }
                    else
                    {
                        Debug.Log("Perfect Hit");
                        GameManagerLevels.instance.PerfectHit();
                        Instantiate(noteHitEffect, transform.position, noteHitEffect.transform.rotation);
                    }

                }
            }
        } else
        {
            if (Input.GetKey(keyToPress) && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow) && Input.GetKey(keyToPress))

            {
                
                if (canBePressed)
                {
                    StartCoroutine("CenterClapRoutine");
                    gameObject.SetActive(false);
                    
                    if (this.transform.position.y >= -3)
                    {
                        Debug.Log("Normal Hit");
                        GameManagerLevels.instance.NormalHit();
                        Instantiate(noteHitEffect, transform.position, noteHitEffect.transform.rotation);
                        
                      
                    }
                    else if (this.transform.position.y >= -3.2)
                    {
                        Debug.Log("Good Hit");
                        GameManagerLevels.instance.GoodHit();
                        Instantiate(noteHitEffect, transform.position, noteHitEffect.transform.rotation);
                        
                    }
                    else
                    {
                        Debug.Log("Perfect Hit");
                        GameManagerLevels.instance.PerfectHit();
                        Instantiate(noteHitEffect, transform.position, noteHitEffect.transform.rotation);
                        
                    }
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

        if (other.CompareTag("MissedBox"))
        {
            canBePressed = false;

            AudioManager.Instance.SFX_Note(0);
            Destroy(gameObject, 2f);
        }
    }



}
