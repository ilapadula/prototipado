using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    public float velocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(transform.right * (-velocity * Time.deltaTime));
        }
         if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * (velocity * Time.deltaTime));
        }
         if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.forward * (velocity * Time.deltaTime));
        }
         if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(transform.forward * (-velocity * Time.deltaTime));
        }
    }
}
