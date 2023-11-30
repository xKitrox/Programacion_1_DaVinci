using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed;
    public Transform shootingPoint;
    public Bullet prefab;
    private Animator animator;
    private bool isAttacking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isAttacking = true;
    }
    public void Shoot()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("isAttacking", true);
            Bullet bullet = Instantiate(prefab, shootingPoint.position, shootingPoint.rotation);
            bullet.speed = speed;
        }
        else
        {
            animator.SetBool("isAttacking", false);

        }
    }


    private void FixedUpdate()
    {
        if (isAttacking == true)
        {
            animator.SetBool("isAttacking", false);

        }
        
    }
    private void LateUpdate()
    {
        if (isAttacking)
        {
            return;
        }
    }
}
