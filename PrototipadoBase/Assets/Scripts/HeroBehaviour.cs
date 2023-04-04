using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    public float maxPower = 50f;
    public float powerMultiplier = 1f;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 direction;
    private float distance;
    private float currentPower;
    private bool isDragging;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPoint = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = transform.position;
            isDragging = true;
        }

        if (isDragging)
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPoint.y = 0;
            direction = (endPoint - startPoint).normalized;
            distance = Vector3.Distance(startPoint, endPoint);

            currentPower = Mathf.Clamp(distance * powerMultiplier, 0f, maxPower);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            rb.AddForce(direction * currentPower, ForceMode.Impulse);
            currentPower = 0f;
        }
    }
}