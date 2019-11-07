using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float mouseSensitivity;

    float rotateAngleX;
    float rotateAngleY;

    void Start() {
        rotateAngleX = 0.0f;
        rotateAngleY = 0.0f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"), Input.GetAxisRaw("Vertical"));
        Vector3 velocity = input.normalized * speed * Time.deltaTime;
        rotateAngleX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotateAngleY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotateAngleY = Mathf.Clamp(rotateAngleY, -90.0f, 90.0f);

        transform.Translate(velocity, Space.Self);
        transform.eulerAngles = new Vector3(rotateAngleY, rotateAngleX);
    }
}
