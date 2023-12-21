using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Cannon : MonoBehaviour
{
    [Header("Nuke settings")]
    public int speed;
    public Transform shootingPoint;
    public Nuke prefab;


    public void Attack()
    {
        Nuke nuke = Instantiate(prefab, shootingPoint.position, shootingPoint.rotation);
        nuke.speed = speed;
    }
}
