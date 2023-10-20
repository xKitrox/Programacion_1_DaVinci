using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float movmentSpeed;
    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private Transform[] waypoints;
    public Transform droPoint;

    [SerializeField]
    private float health;

    private Player player;
    private enemyCannon enemyCannon;
    private HealthPotion prefabH;

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

    //Take contact damage
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 3)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }

    }
    //Take damage
    public void TakeDamage(int amount)
    {

        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);

            HealthPotion health = Instantiate(prefabH, droPoint.position, droPoint.rotation);
        }
        else
        {
            print("Lastimaste al enemigo, su vida es de: " + health);    
        }
    }

    //lock player and shoot
    private void Shoot()
    {
        Vector3 target = player.transform.position;

        transform.rotation = GetTargetRotation(target);
        enemyCannon.Attack();
    }

    private Quaternion GetTargetRotation(Vector3 target)
    {
        Vector3 direction = transform.position - target;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    

}
