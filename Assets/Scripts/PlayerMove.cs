using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 2.0f;

    private CharacterController controller;

    private float moveFB;
    private float moveLR;
    private float rotX;
    private float rotY;

    private bool isMoving = true;

    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        if (isMoving)
        {
            Debug.Log(transform.position);
            moveFB = Input.GetAxis("Vertical") * speed;
            moveLR = Input.GetAxis("Horizontal") * speed;

            Vector3 movement = new Vector3(moveLR, 0, moveFB);
            movement = transform.rotation * movement;

            if (movement != Vector3.zero)
            {
                controller.Move(movement * Time.deltaTime);
            }

            rotX += Input.GetAxis("Mouse X") * sensitivity;
            rotY += Input.GetAxis("Mouse Y") * sensitivity;
            rotY = Mathf.Clamp(rotY, -90f, 90f);

            transform.localRotation = Quaternion.Euler(0, rotX, 0);
        }
    }

    public void SetIsMoving(bool value)
    {
        isMoving = value;
    }
}
