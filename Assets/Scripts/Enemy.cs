using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 10;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;

    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHits();
    }

    void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void KillEnemy()
    {
        GameObject explosion = Instantiate(deathFX, transform.position,
                    Quaternion.identity);
        explosion.transform.parent = parent;
        Destroy(gameObject);
        scoreBoard.ScoreHit(scorePerHit);
    }

    void ProcessHits()
    {
        hits = hits - 1;
        if (hits <= 0)
        {
            KillEnemy();
        }
    }
}
