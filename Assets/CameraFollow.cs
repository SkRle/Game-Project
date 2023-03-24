using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform PlayerPos;

    private void Awake()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = new Vector2(PlayerPos.position.x, PlayerPos.position.y);
    }
}
