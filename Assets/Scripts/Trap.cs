using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private int damage;
    private int counter;
    private float timer;

    private void Update()
    {

        Patrol();
        
        

    }

    private Player player;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 3)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }

    }

    //Patrol

    [SerializeField]
    private float movmentSpeed;

    [SerializeField]
    private Transform[] waypoints;

    

    private int index = 0;


    public void Patrol()
    {
        if (waypoints.Length == 0)
        {
            return;
        }
        Transform target = waypoints[index];

        transform.position = Vector3.MoveTowards(transform.position, target.position, movmentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            index++;
            if (index >= waypoints.Length)
            {
                index = 0;
            }
        }
    }
}
