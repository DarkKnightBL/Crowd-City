using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick floatingJoystick;

    [SerializeField] private AnimatorController animatorController;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private Rigidbody rb;

    private Vector3 moveVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = floatingJoystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = floatingJoystick.Vertical * moveSpeed * Time.deltaTime;

        if (floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            animatorController.PlayRun();
        }

        else if (floatingJoystick.Horizontal == 0 && floatingJoystick.Vertical == 0)
        {
            animatorController.PlayIdle();
        }

        rb.MovePosition(rb.position + moveVector);
    }

}
