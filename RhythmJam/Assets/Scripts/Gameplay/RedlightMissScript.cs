using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedlightMissScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject redLight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Note")
        {
            StartCoroutine("redLightActivation");
        }
    }

    IEnumerator redLightActivation()
    {
        redLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        redLight.SetActive(false);
    }
}
