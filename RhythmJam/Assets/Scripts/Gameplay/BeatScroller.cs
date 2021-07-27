using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float setTempo;

    public bool gameStarted;
    

    [SerializeField] private Animator enlargeNoteAnimation;

    public float angled;
    // Start is called before the first frame update
    void Start()
    {
        setTempo = setTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                gameStarted = true;
            }
        } else
        {
            if (angled == 1f) {
                transform.position -= new Vector3((setTempo * Time.deltaTime) / 4, setTempo * Time.deltaTime, 0f);
            } else if (angled == 0f)
            {
                transform.position -= new Vector3(0f, setTempo * Time.deltaTime, 0f);
 
            } else if (angled == -1f)
            {
                transform.position -= new Vector3(-(setTempo * Time.deltaTime) / 4, setTempo * Time.deltaTime, 0f);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enlarger"))
        {
            enlargeNoteAnimation.SetBool("enlargeTrigger", true);
        }
    }
}
