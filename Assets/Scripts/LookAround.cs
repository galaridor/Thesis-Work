using UnityEngine;

public class LookAround : MonoBehaviour
{
    //public float speedH = 2.0f;

    //public float speedV = 2.0f;

    //private float yaw = 0.0f;

    //private float pitch = 0.0f;

    [SerializeField]
    private float mouseSensitivity = 100f;

    public Transform playerBody;

    public GameObject eyes;

    private float xRotation = 0f;

    private void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("mouseSensValue") * 100;
        playerBody.transform.rotation = Quaternion.Euler(0, 0, 0);
        eyes.transform.rotation = Quaternion.Euler(0, 0, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Mathf.Deg2Rad;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Mathf.Deg2Rad;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    //private void Update()
    //{
    //    yaw += speedH * Input.GetAxis("Mouse X");
    //    pitch -= speedV * Input.GetAxis("Mouse Y");

    //    //the rotation range
    //    pitch = Mathf.Clamp(pitch, -60f, 90f);

    //    //the rotation range
    //    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    //}
}