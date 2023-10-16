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
        if (player != null)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                timer = 0;
                player.TakeDamage(damage);
            }

        }

    }

    private Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponentInParent<Player>();
        if (player != null)
        {
            this.player = player;
            counter++;
            timer = 0;



        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponentInParent<Player>();
        if (player != null)
        {
            counter--;
            if (counter == 0)
            {
                this.player = null;
            }


        }

    }
}
