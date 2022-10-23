using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;

    private string PLAYER_TAG = "Player";

    [SerializeField]
    private float minX = -54.5f;

    [SerializeField]
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

        // X boundaries
        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}
