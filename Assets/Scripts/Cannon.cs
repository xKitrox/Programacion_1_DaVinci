using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float speed;

    public Transform shootingPoint;


    public Bullet prefab;



    public void Shoot()
    {



        if (Input.GetKeyDown(KeyCode.F))
        {
            Bullet bullet = Instantiate(prefab, shootingPoint.position, shootingPoint.rotation);

            bullet.speed = speed;
        }

    }
}
