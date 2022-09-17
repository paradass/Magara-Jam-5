using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chracterfollow : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }
}
