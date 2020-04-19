using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare46Game
{
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody2D playerRigidBody;
        //yeah.

        public Transform groundDetectionTransform;
        public float groundDetectionSize;
        public LayerMask groundLayer;
        private bool isTouchingGround;

        public float speed;
        public float jumpHeight;

        // Start is called before the first frame update
        void Start()
        {
            playerRigidBody = GetComponent<Rigidbody2D>();
            speed = 10;
            jumpHeight = 1;
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
                moveVertical = jumpHeight;
            }
            playerRigidBody.velocity = (new Vector2(moveHorizontal * speed, playerRigidBody.velocity.y + moveVertical));
        }
    }
}