using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotSpeed = 200f;

    private void Start()
    {
        rotSpeed = PlayerPrefs.GetFloat("bombRotationsSensValue") * 100;
    }

    private void Update()
    {
         if (Input.GetMouseButton(1))
         {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.up, -rotX, Space.World);
            transform.Rotate(Vector3.forward, rotY, Space.World);
        }
    }
}