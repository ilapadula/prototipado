using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    public float velocity = 10f;
    public int healthPoints = 100;

    void Update()
    {
        var speed = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            speed += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            speed += Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            speed += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            speed += Vector3.back;
        }

        if (speed != Vector3.zero)
        {
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
