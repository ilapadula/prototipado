using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    public float velocity = 10f;
    public int healthPoints = 100;
    public LineRenderer lineRenderer;
    public Camera camera;
    public float friction = 0.95f;
    private Vector3 speed;
    private Vector3 direction;
    public bool moving;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Set the start point of the line
            lineRenderer.SetPosition(0, transform.position);
        }
        
        if (Input.GetMouseButton(0))
        {
            // Get the current mouse position
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition); ;

            // Set the end point of the line
            lineRenderer.SetPosition(1, mousePos);
            direction = mousePos - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
            speed = Vector3.zero;
        }

        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.SetPosition(1, transform.position);
            // aca podriamos calcular la velocidad en funcion de el vector que da la posicion final del mouse (donde hizo mouse up)


            speed = direction * velocity;
            //Debug.Log($"Speed : {speed}");


        }

        if (speed != Vector3.zero)
        {
            // esto hay que cambiarlo por un sistema que aplique inercia a una velocidad inicial

            transform.Translate(-speed * Time.deltaTime, Space.World);
            speed *= friction;
            moving = true;
        }

        if(speed == Vector3.zero)
        {
            moving = false;
        }


        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (moving)
            {
                Destroy(other.gameObject);
            }
            else
            {
                healthPoints--;
                //Debug.Log($"Health points {healthPoints}");
            }
           
        }
    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        healthPoints--;
    //        Debug.Log($"Health points {healthPoints}");
    //    }
    //}
}
