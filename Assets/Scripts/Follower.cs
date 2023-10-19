using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    private Transform toFollow;

    private void LateUpdate()
    {
        Vector3 position = toFollow.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
