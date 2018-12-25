using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MotionController))]
public class InputController : MonoBehaviour {
    private MotionController motionController;

    public string HorizontalInput = "Horizontal";
    public string VerticallInput = "Vertical";

    private float hInput;
    private float vInput;

    public Vector3 moveVector;
    public float speed;

    private void Awake()
    {
        motionController = GetComponent<MotionController>();
    }

    private void Update()
    {
        hInput = Input.GetAxis(HorizontalInput);
        vInput = Input.GetAxis(VerticallInput);
        moveVector = new Vector3(hInput, vInput, 0);

        speed = Mathf.Sqrt(hInput * hInput + vInput * vInput);
        speed = Mathf.Clamp(speed, 0, 1f);
    }
}
