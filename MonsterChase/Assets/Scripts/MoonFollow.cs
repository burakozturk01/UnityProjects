using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonFollow : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;

    private string PLAYER_TAG = "Player";

    private float offset = 0f;
    private float maxOffset = 6.72f;
    private float maxX = 54.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Camera movement
    void LateUpdate()
    {
        if (!player)
            player = GameObject.FindWithTag(PLAYER_TAG).transform;

        if (!player)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        offset = (tempPos.x / maxX) * maxOffset;

        tempPos.x += offset;

        transform.position = tempPos;
    }
}
