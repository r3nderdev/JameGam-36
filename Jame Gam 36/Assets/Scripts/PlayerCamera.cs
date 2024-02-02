using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    [Header("Book")]
    public GameObject book;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Fix camera orientation when spawning
        xRotation = 0f;
    }

    private void Update()
    {
        // If the book gameobject is active in scene
        if (book.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!book.activeSelf)
        {
            // if the book isn't active run all the normal code for camera
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;

            // Limit view 
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // Rotate camera and player orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

}
