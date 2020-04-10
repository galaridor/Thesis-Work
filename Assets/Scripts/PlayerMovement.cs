using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controler;

    private float speed = 15f;

    //private float gravity = -20.00f;

    //[SerializeField]
    //private Vector3 velocity;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controler.Move(move * speed * Time.deltaTime);

        //velocity.y += gravity * Time.deltaTime;

        //controler.Move(velocity * Time.deltaTime);
    }
}
