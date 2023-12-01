using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Player player = collision.gameObject.GetComponentInParent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
            player.WinGame();


        }

    }
}
