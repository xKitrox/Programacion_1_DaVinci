using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCannon : MonoBehaviour
{
    public int speed;
    public Transform shootingPoint;
    public Bullet prefab;

    
    public void Shoot()
    {
        Bullet bullet = Instantiate(prefab, shootingPoint.position, shootingPoint.rotation);
        bullet.speed = speed;

    }
    public virtual void Attack()
    {
        Shoot();
    }


}
