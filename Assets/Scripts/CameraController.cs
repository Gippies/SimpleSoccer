using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    void Update() {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"), Input.GetAxisRaw("Vertical"));
        Vector3 velocity = input.normalized * speed * Time.fixedDeltaTime;
        float rotateAngle = Input.GetAxisRaw("Rotate") * rotateSpeed * Time.fixedDeltaTime;

        transform.Translate(velocity, Space.Self);
        transform.Rotate(Vector3.up, rotateAngle);
    }
}
