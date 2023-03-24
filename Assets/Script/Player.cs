using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    private Rigidbody2D myBody;
    public float speed;
    Vector2 Move;
    public Animator animator;



    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        Movement();

    }
    public void Movement()
    {
        Move.x = joystick.Horizontal;
        Move.y = joystick.Vertical;

        myBody.MovePosition(myBody.position + Move * speed * Time.fixedDeltaTime);

        animator.SetFloat("Horizontal", Move.x);
        animator.SetFloat("Vertical", Move.y);
        animator.SetFloat("Speed", Move.sqrMagnitude);

    }

}