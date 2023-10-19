using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healing = 5;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Player player = collision.gameObject.GetComponentInParent<Player>();
        if (player != null)
        {

            if (player.TakeHealing(healing))
            {
                Destroy(gameObject);
            }


        }

    }
    
}
