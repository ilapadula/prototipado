using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public HeroBehaviour hero;
    public float enemySpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hero == null)
            return;
        transform.LookAt(hero.transform);
        var direction = (hero.transform.position - transform.position).normalized;
        transform.Translate(direction * (enemySpeed * Time.deltaTime));
    }

    
     void OnTriggerEnter(Collider other)
    {
        //Death on collition with player
        if (other.gameObject.CompareTag("Hero"))
        {
            Destroy(gameObject);
        }

    
    }
}
