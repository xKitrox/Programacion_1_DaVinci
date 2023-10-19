using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float movmentSpeed;

    [SerializeField]
    private Transform[] waypoints;
    private Player player;

    private void Update()
    {
        Patrol();
    }

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
    

    /*
    private int currentWaypoint = 0;

    public void Patrol()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.2f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }


    }
    */
}
