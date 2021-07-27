using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject note;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        note.transform.Rotate(Vector3.forward * + 0.05f);
    }
}
