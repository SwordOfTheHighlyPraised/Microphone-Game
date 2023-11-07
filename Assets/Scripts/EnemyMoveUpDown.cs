using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUpDown : MonoBehaviour
{
    public float moveSpeed = 5;
    public float minY = -2.0f;
    public float maxY = 2.0f;
    private bool reachedTurningPoint = false;

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if (!reachedTurningPoint && pos.x <= 7f)
        {
            reachedTurningPoint = true;
        }

        if (reachedTurningPoint)
        {
            // Move the enemy up and down in the Y-axis.
            pos.x = 7f; // Lock the X position.
            pos.y = Mathf.PingPong(Time.time * moveSpeed, maxY - minY) + minY;
        }
        else
        {
            // Continue moving to the left until reaching x=7.
            pos.x -= moveSpeed * Time.deltaTime;
        }

        if (pos.x < -20)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
