using UnityEngine;

public class HeroBullet : MonoBehaviour
{
    public float velocity = 30f;
    private Vector3 speed;
    public int damage;
    public GameObject enemyHit;

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
        if (other.gameObject.CompareTag("Enemy") && other.gameObject != enemyHit)
        {
            
            enemyHit = other.gameObject;
            other.gameObject.GetComponent<EnemyBehaviour>().OnDamaged(damage);
            Destroy(gameObject,4);
            
        }
    }
}