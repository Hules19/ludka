using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float minX = -6.84f; // Minimum x position of the movement range
    public float maxX = 6.84f; // Maximum x position of the movement range
    public float speed = 5f; // Movement speed
    public GameObject enemy;

    private float targetX; // The current target x position

    private void Start()
    {
        // Set the initial target to the current x position
        targetX = transform.position.x;
    }

    private void Update()
    {
        // Calculate the desired target position within the range
        targetX += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        targetX = Mathf.Clamp(targetX, minX, maxX);

        // Move towards the target position
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == enemy)
        {
            Debug.Log("Player touched the object!");
            // Add your desired logic here when the player touches the object
        }
    }
}
    
