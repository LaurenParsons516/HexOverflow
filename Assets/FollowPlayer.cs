using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, -30, player.position.x + offset.z); // Camera follows the player with specified offset position
    }
}
