using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;

    public bool swapInput;

    public float movement;
    private bool jump, canJump;

    ICommand input1;
    ICommand input2;

    private void Start()
    {
        input1 = new PrimaryInput(gameObject);
        input2 = new SecondInput(gameObject);
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        GetInputs();
        Move();
    }

    private void GetInputs()
    {
        if (!swapInput) input1.Execute();
        if (swapInput) input2.Execute();
        jump = Input.GetKeyDown(KeyCode.Space);
    }

    private void Move()
    {
        if (canJump && jump) { rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse); canJump = false; }

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) canJump = true;
    }

}
