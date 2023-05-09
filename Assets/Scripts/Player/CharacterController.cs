using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get the movement input
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normalize the movement vector and apply the move speed
        movement = movement.normalized * moveSpeed;

        // Move the character
        rb.velocity = movement;
    }
}
