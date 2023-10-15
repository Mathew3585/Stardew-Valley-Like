using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharaterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private List<Animator> Animator;
    private Vector2 moveInput;



    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        for (int i = 0; i < Animator.Count; i++)
        {
            Animator[i].SetBool("Walking", true);
            Animator[i].SetFloat("Up-Down", moveInput.x);
            Animator[i].SetFloat("Letf-Right", moveInput.y);
        }
        // Appliquez la force au RigidBody2D pour déplacer le personnage
        Vector2 movement = moveInput * moveSpeed;
        rb.velocity = movement;
    }

    private void Update()
    {
        if (moveInput.y == 0 && moveInput.x == 0)
        {
            for (int i = 0; i < Animator.Count; i++)
            {
                Animator[i].SetBool("Walking", false);
            }

        }
    }


    public void OnFire()
    {
        Debug.Log("Fire");
    }
}
