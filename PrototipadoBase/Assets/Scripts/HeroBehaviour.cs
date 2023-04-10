using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    public float velocity = 10f;
    public int healthPoints = 100;
    public LineRenderer lineRenderer;
    public Camera camera;
    
    void Update()
    {
        var speed = Vector3.zero;
        if (Input.GetMouseButtonDown(0))
        {
            // Set the start point of the line
            lineRenderer.SetPosition(0, transform.position);
        }
        
        if (Input.GetMouseButton(0))
        {
            // Get the current mouse position
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);;
        
            // Set the end point of the line
            lineRenderer.SetPosition(1, mousePos);

            transform.LookAt(mousePos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.SetPosition(1, transform.position);
            // aca podriamos calcular la velocidad en funcion de el vector que da la posicion final del mouse (donde hizo mouse up)
            
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
            if (transform.position.y > 0 || transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            }
            
             
            
        }

        if (speed != Vector3.zero)
        {
            // esto hay que cambiarlo por un sistema que aplique inercia a una velocidad inicial
            transform.Translate(speed.normalized * (velocity * Time.deltaTime), Space.World);
            transform.rotation = Quaternion.LookRotation(speed);
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
            healthPoints--;
            Debug.Log($"Health points {healthPoints}");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            healthPoints--;
            Debug.Log($"Health points {healthPoints}");
        }
    }
}
