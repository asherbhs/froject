using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private ITool tool;
    private Rigidbody2D rb2d;

    void Awake()
    {
        speed = 5f;
        tool = null;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.MovePosition
        (
            rb2d.position + speed * Time.fixedDeltaTime * new Vector2
            (
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
            )
        );
    }
}