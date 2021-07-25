using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayChanging : MonoBehaviour
{
    public GameObject HighwayOne;
    public GameObject HighwayTwo;
    public GameObject HighwayThree;

    public int CurrentHighway;

    public Vector2 destinationLeft;
    public Vector2 destinationRight;
    public Vector2 destinationInPlay;

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (HighwayOne.transform.position.x == 0)
        {
            CurrentHighway = 1;
        } 
        else if (HighwayTwo.transform.position.x == 0)
        {
            CurrentHighway = 2;
        } 
        else if (HighwayThree.transform.position.x == 0)
        {
            CurrentHighway = 3;
        }

        //float lerpSpeed = speed * Time.deltaTime;

        if (CurrentHighway == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HighwayOne.transform.position = Vector2.Lerp(destinationInPlay, destinationLeft, Time.deltaTime);
                HighwayTwo.transform.position = Vector2.Lerp(destinationRight, destinationInPlay, Time.deltaTime);
                HighwayThree.transform.position = Vector2.Lerp(destinationLeft, destinationRight, Time.deltaTime);
            }
        } 
        else if (CurrentHighway == 2)
        {

        } 
        else if (CurrentHighway == 3)
        {

        }
    }
}
