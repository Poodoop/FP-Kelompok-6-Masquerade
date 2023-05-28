using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = playerTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            // float clampedX = mathf.Clamp(playerTransform.position.x, minX, maxX);
            // float clampedY = mathf.Clamp(playerTransform.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, playerTransform.position, speed);
        }
    }
}
