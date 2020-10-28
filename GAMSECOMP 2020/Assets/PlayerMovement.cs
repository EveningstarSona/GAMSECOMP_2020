using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private FieldOfView fieldOfView;

    private float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //mousePosition = Input.mousePosition;
        //fieldOfView.SetAimDirection()
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
