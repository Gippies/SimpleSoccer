using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float mouseSensitivity;
    public float kickMultiplier;
    public float kickHeightMultiplier;

    float rotateAngleX;
    float rotateAngleY;
    Camera thisCamera;

    void Start() {
        rotateAngleX = 0.0f;
        rotateAngleY = 0.0f;

        thisCamera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        MoveCamera();
        KickRigidBody();
    }

    void MoveCamera() {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"), Input.GetAxisRaw("Vertical"));
        Vector3 velocity = input.normalized * speed * Time.deltaTime;
        rotateAngleX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotateAngleY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotateAngleY = Mathf.Clamp(rotateAngleY, -90.0f, 90.0f);

        transform.Translate(velocity, Space.Self);
        transform.eulerAngles = new Vector3(rotateAngleY, rotateAngleX);
    }

    void KickRigidBody() {
        if (Input.GetMouseButtonDown(0)) {
            Ray cameraRay = thisCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(cameraRay, out hit)) {
                // the object identified by hit.transform was clicked
                if (hit.transform.gameObject.name == "SoccerBall" && Vector3.Distance(transform.position, hit.transform.position) < 3.0f) {
                    hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(cameraRay.direction * kickMultiplier + Vector3.up * kickHeightMultiplier);
                }
            }
        }
    }
}
