using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
    public string type = "normal";

    public float health = 1f;

    public int moneyValue = 1;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {

        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            GameObject.FindObjectOfType<ScoreManager>().loseLife();
            Destroy(gameObject);
            return;
        }
        
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
        Destroy(gameObject);
    }
}
