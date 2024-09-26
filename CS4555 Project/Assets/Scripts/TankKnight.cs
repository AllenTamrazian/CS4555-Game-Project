using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankKnight : MonoBehaviour
{
    public float speed = 25f;
    public float rotateSpeed = 180f;
    public float gravityMultiplier = 3f;  // Controls fall speed
    public float groundCheckDistance = 1.1f;  // Distance for checking if grounded
    public float downwardForce = 5f;  // Extra downward force to prevent bouncing
    private Animator animator;
    private Rigidbody rb;
    Transform swordOnBelt;
    Transform swordInHand;
    private bool isGrounded;
    public int health = 100;
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.drag = 0f;  // Ensure drag is set to 0 for no air resistance
        swordOnBelt = FindDeepChild(transform, "Item_SwordSheath");
        swordInHand = FindDeepChild(transform, "swordInHand");
        boxCollider = GetComponent<BoxCollider>();
    }

    Transform FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;

            Transform result = FindDeepChild(child, name);
            if (result != null)
                return result;
        }
        return null;
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        float rotationAmount = 0f;
        bool isMoving = false;

        // Move forward
        if (Input.GetKey(KeyCode.I))
        {
            moveDirection = transform.forward * speed;
            isMoving = true;
        }

        // Move backward
        if (Input.GetKey(KeyCode.K))
        {
            moveDirection = -transform.forward * speed;
            isMoving = true;
        }

        // Rotate left
        if (Input.GetKey(KeyCode.J))
        {
            rotationAmount = -rotateSpeed * Time.deltaTime;
            isMoving = true;
        }

        // Rotate right
        if (Input.GetKey(KeyCode.L))
        {
            rotationAmount = rotateSpeed * Time.deltaTime;
            isMoving = true;
        }

        // Apply movement
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        // Apply rotation
        if (rotationAmount != 0f)
        {
            Quaternion turnOffset = Quaternion.Euler(0, rotationAmount, 0);
            rb.MoveRotation(rb.rotation * turnOffset);
        }

        // Set animator state based on movement
        animator.SetBool("isMoving", isMoving);

        // Sword attack (check if idle)
        if (Input.GetKey(KeyCode.U) && rb.velocity.magnitude == 0)
        {
            swordOnBelt.gameObject.SetActive(false);
            swordInHand.gameObject.SetActive(true);
            animator.SetBool("attackingIdle", true);
        }

        // Stop attack when releasing the key
        if (Input.GetKeyUp(KeyCode.U) && rb.velocity.magnitude == 0)
        {
            swordOnBelt.gameObject.SetActive(true);
            swordInHand.gameObject.SetActive(false);
            animator.SetBool("attackingIdle", false);
        }

        // Special ability
        if (Input.GetKey(KeyCode.O) && rb.velocity.magnitude == 0)
        {
            print("special attack for tank knight");
            //animator.SetBool("specialattack", true);
        }
        if (Input.GetKeyUp(KeyCode.O) && rb.velocity.magnitude == 0)
        {
            print("turn off special attack for tank knight");
            //animator.SetBool("specialattack", false);
        }

        // Stop movement animation if no keys are pressed
        if (!Input.anyKey)
        {
            animator.SetBool("isMoving", false);
        }
        animator.SetInteger("Health", health);
        if (health <= 0)
        {
            boxCollider.size = new Vector3(1.0f, 1f, 1.0f);
        }
        if (health > 0)
        {
            boxCollider.size = new Vector3(1.0f, 2.0f, 1.0f);
        }
    }

    void FixedUpdate()
    {
        ApplyCustomGravity();
        PreventBouncingOnSlopes();
    }

    // Method to apply custom gravity for faster falling
    void ApplyCustomGravity()
    {
        isGrounded = IsGrounded();

        if (!isGrounded)  // Only apply custom gravity if the character is not grounded
        {
            // Apply custom gravity by modifying the vertical velocity directly
            Vector3 velocity = rb.velocity;
            velocity.y += Physics.gravity.y * (gravityMultiplier - 1) * Time.deltaTime;
            rb.velocity = velocity;
        }
    }

    // Prevent bouncing when moving over slopes
    void PreventBouncingOnSlopes()
    {
        if (isGrounded)
        {
            // Apply a small downward force to keep the character grounded on slopes
            rb.AddForce(Vector3.down * downwardForce, ForceMode.Acceleration);

            // Prevent upward velocity to avoid bouncing
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
        }
    }

    // Ground check method
    bool IsGrounded()
    {
        // Cast a ray downwards to check if the character is close to the ground
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }
}
