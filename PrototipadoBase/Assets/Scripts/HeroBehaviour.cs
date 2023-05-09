using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroBehaviour : MonoBehaviour
{
    public float velocity = 10f;
    public int healthPoints = 100;
    public LineRenderer lineRenderer;
    public Camera camera;
    public float friction = 0.1f;
    private Vector3 speed;
    private Vector3 direction;
    public bool moving;
    public float minTimeScale = 0.05f;
    public float sensitivity = 0.1f;
    public float score;
    public Text scoreText;
    public Text healthText;
    public AudioSource source;
    public AudioClip explosion;
    public AudioClip movimiento;
    public AudioClip slowmo;


    void Update()
    {

        healthText.text = "Health: " + healthPoints.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            // Set the start point of the line
            lineRenderer.SetPosition(0, transform.position);
            source.clip = slowmo;
            source.loop = true;
            source.Play();
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
            // Debug.Log($"Speed : {speed}");

            source.PlayOneShot(movimiento);
            source.Stop();
        }



        // esto hay que cambiarlo por un sistema que aplique inercia a una velocidad inicial

        
            transform.Translate(-speed * Time.deltaTime, Space.World);
            Time.timeScale = Mathf.Clamp01(minTimeScale + speed.magnitude * sensitivity);
            
            
            //Apply Friction smoothly using Lerp
            speed.x = Mathf.Lerp(speed.x, 0, friction);
            speed.y = Mathf.Lerp(speed.y, 0, friction);
            speed.z = Mathf.Lerp(speed.z, 0, friction);
            moving = true;
        


        
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
       
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            healthPoints -= 10;
            healthText.text = "Health: " + healthPoints.ToString();
            Debug.Log($"Health points {healthPoints}");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            score += 10;
            scoreText.text = "Score: " + score.ToString();
            source.PlayOneShot(explosion);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            speed = Vector3.zero;
        }
        
    }

}

