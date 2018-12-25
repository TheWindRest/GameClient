using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MotionController : MonoBehaviour {
    private Rigidbody2D Rigidbody;

    public GameObject Model;

    public float turnSpeed = 10;
    public float maxSpeed = 10;

    [HideInInspector]
    public float speed;
    public Vector3 moveDirection;
    public Vector3 movePosition;

    private void Awake()
    {
        Physics2D.gravity = Vector2.zero;
        Rigidbody = GetComponent<Rigidbody2D>();

        moveDirection = Model.transform.rotation.eulerAngles;
        movePosition = transform.position;
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        if(moveDirection != Vector3.zero)
        {
            var angel = Mathf.Atan2(-moveDirection.x, moveDirection.y) * 180 / Mathf.PI;
            var moveVector = new Vector3(0, 0, angel);
            Quaternion fin = Quaternion.Euler(moveVector);
            Model.transform.rotation = Quaternion.Slerp(Model.transform.rotation, fin, Time.deltaTime * turnSpeed);
        }
    }

    private void Move()
    {
        var moveVector = movePosition - transform.position;
        if (moveVector.sqrMagnitude >= 0.05f)
        {
            Vector3 velocity = moveVector.normalized;
            transform.position += velocity * maxSpeed * Time.fixedDeltaTime;
        }
    }
}
