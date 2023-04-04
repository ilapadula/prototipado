using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWeapon : MonoBehaviour
{
    public HeroBullet bulletPrefab;
    public float frequency = 1f;
    public float angle = 0f;

    private float timer = 0;


    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red, 10f);
        timer += Time.deltaTime;
        if (timer > frequency)
        {
            var bulletDirection = Quaternion.LookRotation(transform.forward) * Quaternion.AngleAxis(angle, Vector3.up);
            var bullet = Instantiate(bulletPrefab, transform.position, bulletDirection);
            timer = 0;
        }
    }
}
