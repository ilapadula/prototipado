using UnityEngine;

public class HeroBullet : MonoBehaviour
{
    public float velocity = 30f;
    private Vector3 speed;

    void Start()
    {
        speed = transform.forward * velocity;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}