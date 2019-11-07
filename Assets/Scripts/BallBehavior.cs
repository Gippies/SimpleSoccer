using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Vector3 startPosition;
    public ScoreManager scoreManager;

    Rigidbody thisRigidbody;

    void Start() {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.parent.name == "Goal West") {
            scoreManager.addScore(Goal.West);
            ResetBall();
            print("Collided object: " + other.transform.parent.name + " score: " + scoreManager.getScore(Goal.West));
        }
    }

    void ResetBall() {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.angularVelocity = Vector3.zero;
    }
}
