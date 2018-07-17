using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        print("Particles collided with enemy " + gameObject.name);
        Destroy(gameObject);
    }
}
