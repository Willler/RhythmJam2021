using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputFeedback : MonoBehaviour
{

    private SpriteRenderer playerSR;
    public Sprite defaultSprite;
    public Sprite inputSprite;

    public KeyCode keyForNoteInput;
    
    // Start is called before the first frame update
    void Start()
    {
        playerSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyForNoteInput))
        {
            playerSR.sprite = inputSprite;
        } 

        if (Input.GetKeyUp(keyForNoteInput))
        {
            playerSR.sprite = defaultSprite;
        }
    }
}
