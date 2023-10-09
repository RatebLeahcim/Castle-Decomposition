using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float mouseSensitivity = 2.0f;
    [SerializeField]
    private float jumpHeight = 2.0f; // How high the player can jump.
    [SerializeField]
    private float gravity = 20.0f;   // The gravity applied to the player.

    private float verticalRotation = 0;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalVelocity = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Player rotation (looking)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Player movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        moveDirection = Camera.main.transform.forward * verticalMovement + Camera.main.transform.right * horizontalMovement;
        moveDirection.Normalize();

        // Handle jumping
        if (characterController.isGrounded)
        {
            // Player is on the ground
            verticalVelocity = -gravity * Time.deltaTime;

            if (Input.GetButtonDown("Jump"))
            {
                // Apply an upward force to jump
                verticalVelocity = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
        }
        else
        {
            // Player is in the air, apply gravity
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;

        // Move the character controller
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Lock the cursor when pressing the Escape key (optional)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorLock();
        }
    }

    private void ToggleCursorLock()
    {
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = !Cursor.visible;
    }
}
