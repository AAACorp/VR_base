using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explodeEffect;
    public float explosionRadius = 5f;
    public float explosionForce = 900f;
    public float damage = 100f;

    void OnCollisionEnter(Collision collision)
    {
         Explode();
    }
    void Explode()
    {
        Instantiate(explodeEffect, transform.position, transform.rotation, gameObject.transform); 
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearObjects in colliders)
        {
            Rigidbody rb = nearObjects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            EnemyAiv2 enemies = nearObjects.GetComponent<EnemyAiv2>();
            if (enemies != null)
            {
                enemies.TakeDamage(damage);
            }

            Turrel turrels = nearObjects.GetComponent<Turrel>();
            if(turrels!=null)
            {
                turrels.DestroyTurrel();
            }
        }
        Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
        MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
        Destroy(rigid);
        Destroy(mesh);
        Destroy(gameObject, 0.5f);
    }
}
