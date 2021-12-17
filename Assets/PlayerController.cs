using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        Vector2 dragDirection;
        CharacterController characterController;
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
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {

            if (isPushed)
                xSpeed = dragDirection.x * dragSpeed;
            else
                xSpeed = 0;

            Vector3 movingVector = new Vector3(xSpeed, 0, movingSpeed) * Time.deltaTime;
            characterController.Move(movingVector);
        }
    }
}
