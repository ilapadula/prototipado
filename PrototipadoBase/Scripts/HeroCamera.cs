using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCamera : MonoBehaviour
{
    public HeroBehaviour hero;
    private Vector3 heroRelativePosition;

    void Start()
    {
        heroRelativePosition = hero.transform.position - transform.position;
    }

    void Update()
    {
        transform.position = hero.transform.position - heroRelativePosition;
    }
}
