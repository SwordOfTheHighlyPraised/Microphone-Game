using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementMedium : MonoBehaviour
{
    public float moveSpeed = 5;
    public float sineWaveFrequency = 2f; // Adjust the frequency of the sine wave.
    public float sineWaveAmplitude = 2f; // Adjust the amplitude of the sine wave.

    private bool reachedTurningPoint = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (!reachedTurningPoint && pos.x <= 7f)
        {
            // Slow down the enemy when it reaches x=7.
            moveSpeed = 3f;
            reachedTurningPoint = true;
        }

        if (reachedTurningPoint)
        {
            // Move the enemy in a sine wave pattern.
            float sineWaveMovement = Mathf.Sin(Time.time * sineWaveFrequency) * sineWaveAmplitude;
            pos.x -= moveSpeed * Time.fixedDeltaTime;
            pos.y += sineWaveMovement * Time.fixedDeltaTime;
        }
        else
        {
            // Move the enemy to the left until it reaches x=7.
            pos.x -= moveSpeed * Time.fixedDeltaTime;
        }

        if (pos.x < -20)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
