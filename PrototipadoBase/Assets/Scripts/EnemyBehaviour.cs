using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public HeroBehaviour hero;
    public float enemySpeed = 2.0f;
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hero == null)
            return;
        var direction = (hero.transform.position - transform.position).normalized;
        transform.Translate(direction * (enemySpeed * Time.deltaTime));
    }

    public void OnDamaged(int damage)
    {
        health -= damage;
        Debug.Log(damage + ", " + health);
        if(health <= 0)
        {
            hero.OnEnemyKilled(gameObject);
            Destroy(gameObject);
        }
    }
}
