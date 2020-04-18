using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigidBody;


    public Transform groundDetectionTransform;
    public float groundDetectionSize;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 boxDimensions = new Vector2(groundDetectionSize, groundDetectionSize);
        isTouchingGround = Physics2D.OverlapBox(groundDetectionTransform.position, boxDimensions, groundLayer);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 0;
        if (Input.GetAxis("Jump") >= 1 && isTouchingGround)
        {
            moveVertical = 30;
        }

        playerRigidBody.AddForce(new Vector2  (moveHorizontal, moveVertical));
    }
}
