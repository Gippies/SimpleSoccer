using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Vector3 startPosition;
    public delegate void Action(Goal g);
    public event Action OnEnterGoal;

    Rigidbody thisRigidbody;

    void Start() {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.parent.name == "Goal West") {
            if (OnEnterGoal != null) {
                OnEnterGoal(Goal.West);
            }
            ResetBall();
        }
        else if (other.transform.parent.name == "Goal East") {
            if (OnEnterGoal != null) {
                OnEnterGoal(Goal.East);
            }
            ResetBall();
        }
    }

    void ResetBall() {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.angularVelocity = Vector3.zero;
    }
}
