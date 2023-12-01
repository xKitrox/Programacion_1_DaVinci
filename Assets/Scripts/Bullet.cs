using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed;
    public float lifespan;
    public int damage = 5;
    private Animator animator;

    private Rigidbody2D myrigidbody2D;

    private void Awake()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Destroy(gameObject, lifespan);
        animator.SetBool("isDestroied", false);

    }

    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.Euler(0f, 0f, myrigidbody2D.rotation);
        myrigidbody2D.MovePosition(myrigidbody2D.position + speed * Time.fixedDeltaTime * (Vector2)(rotation * Vector2.up));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        animator.SetBool("isDestroied", true);
        //destroy trap
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
        }
        //damage a enemy
        else if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        //damage a player
        else if (collision.gameObject.layer == 3)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }

        else if (player != null)
        {

            player.TakeDamage(1);

        }
        
        Destroy(gameObject);
        animator.SetBool("isDestroied", false);
    }
}
