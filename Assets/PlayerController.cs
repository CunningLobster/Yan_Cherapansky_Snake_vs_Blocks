using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        Vector2 dragDirection;
        Rigidbody rb;
        [SerializeField] float movingSpeed = 10f;
        [SerializeField] float dragSpeed = 10f;

        float xSpeed;

        public bool isPushed;
        public void OnMove(InputAction.CallbackContext context)
        {
            dragDirection = context.ReadValue<Vector2>();
        }

        public void OnPush(InputAction.CallbackContext context)
        { 
            isPushed = context.ReadValueAsButton();
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector3(xSpeed, 0, movingSpeed);

            if (isPushed)
                xSpeed = dragDirection.x * dragSpeed;
            else
                xSpeed = 0;
        }
    }
}
