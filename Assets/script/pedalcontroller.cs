using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedalcontroller : MonoBehaviour
{
    public KeyCode input;
    private float targetPressed;
    private float targetRelease;
    private HingeJoint hinge;
    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring joinspring = hinge.spring;

        if (Input.GetKey(input))
        {
            joinspring.targetPosition = targetPressed;
        }
        else
        {
            joinspring.targetPosition = targetRelease;
        }
        hinge.spring = joinspring;
    }
}
