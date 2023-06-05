using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D rb;
    private Animator animate;

    public float health;

    private Vector2 moveAmount;
    private bool isMirrored = false;

    private void Start(){
        animate = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < rb.position.x && !isMirrored)
        {
            animate.transform.Rotate(new Vector3(0, 180, 0));
            isMirrored = true;
        }
        else if (mousePos.x > rb.position.x && isMirrored)
        {
            animate.transform.Rotate(new Vector3(0, -180, 0));
            isMirrored = false;
        }    

        if (moveInput != Vector2.zero)
        {
            animate.SetBool("IsRunning", true);
        }
        else
        {
            animate.SetBool("IsRunning", false);
        }
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    
    public void TakeDamage (int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
