using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This should be used for diagnostic purposes to move the ball in the scene.
/// </summary>
public class BallController : MonoBehaviour
{
    public float speed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 velocity = input.normalized * speed * Time.fixedDeltaTime;
        rb.AddForce(velocity);
    }
}
