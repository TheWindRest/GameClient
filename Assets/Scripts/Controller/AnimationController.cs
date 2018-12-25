using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MotionController))]
public class AnimationController : MonoBehaviour {
    public GameObject Model;
    private Animator animator;
    private MotionController motionController;

    private void Awake()
    {
        animator = Model.GetComponent<Animator>();
        motionController = GetComponent<MotionController>();
    }

    void LateUpdate()
    {
        //animator.SetFloat("speed", motionController.currentSpeed / motionController.maxSpeed);
    }

    public void PlayAnimation(string animationName, float fadeTime = 0.1f)
    {
        animator.CrossFadeInFixedTime(animationName, fadeTime);
    }
}
