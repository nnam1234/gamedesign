using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public float damage = 1f;
    public float radius = 0;

    public void Chase (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Debug.Log("we hit something");
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if(radius == 0)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);

        }
        else
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider c in cols) 
            {
                Enemy e = c.GetComponent<Enemy>();
                if (e != null)
                {
                    e.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }

        //GameObject.FindObjectOfType<Enemy>().Die();
        //Destroy(gameObject);
    }
}
