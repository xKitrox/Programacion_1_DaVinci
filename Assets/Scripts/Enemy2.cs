using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField]
    private float movmentSpeed;
    [SerializeField]
    private float health;
    [SerializeField]
    private int damage = 5;
    public AudioSource audioSource;
    public AudioClip fireSound, damageSound, dieSound;
    private Animator animator;
    private int idMoving = Animator.StringToHash("isMoving");

    [Header("Enemy Patrol Settings")]

    [SerializeField]
    private float shootingInterval = 5f;
    [SerializeField]
    private bool canShoot = true;
    [Header("Enemy Patrol Settings")]
    [SerializeField]
    private Transform[] waypoints;
    public Transform droPoint;
    [SerializeField]
    private enemy2Cannon enemy2Cannon;
    [SerializeField]
    private float minRangeShoting = 20f;
    [SerializeField]
    private int patrolIndex = 0;

    [Header("Player and Consumables Settings")]
    [SerializeField]
    private Player player;
    [SerializeField]
    private HealthPotion prefabH;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        animator.SetBool(idMoving, true);
        if (Vector3.Distance(transform.position, player.transform.position) < minRangeShoting)
        {
            RotateTowardsPlayer();
            if (canShoot)
            {

                canShoot = false;
                StartCoroutine(shootingCooldown(shootingInterval));

            }
        }
        else
        {
            Patrol();
        }
    }


    public void Patrol()
    {
        if (waypoints.Length == 0)
        {
            return;
        }
        Transform target = waypoints[patrolIndex];

        transform.position = Vector3.MoveTowards(transform.position, target.position, movmentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            patrolIndex++;
            if (patrolIndex >= waypoints.Length)
            {
                patrolIndex = 0;
            }
        }
    }

    private void LateUpdate()
    {
        if (patrolIndex < 0)
        {
            animator.SetBool(idMoving, false);
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
            //print("Mataste al enemigo");
            HealthPotion healthPotion = Instantiate(prefabH, droPoint.position, droPoint.rotation);
        }
        else
        {
            //print("Lastimaste al enemigo, su vida es de: " + health);    
        }
    }

    //Look player
    private void RotateTowardsPlayer()
    {
        Vector3 target = player.transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, -1 * (transform.position - target));
        transform.rotation = Quaternion.LerpUnclamped(transform.rotation, targetRotation, 30 * Time.deltaTime);
    }
    //Shoot
    private IEnumerator shootingCooldown(float interval)
    {

        enemy2Cannon.Attack();
        yield return new WaitForSeconds(interval);
        canShoot = true;
    }
}
