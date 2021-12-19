using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class InputProvider : MonoBehaviour
    {
        Vector2 dragDirection;
        [SerializeField] float dragSpeed = 10f;

        public float XSpeed { get; private set; }

        public bool isPushed;
        public void OnMove(InputAction.CallbackContext context)
        {
            dragDirection = context.ReadValue<Vector2>();
        }

        public void OnPush(InputAction.CallbackContext context)
        { 
            isPushed = context.ReadValueAsButton();
        }

        private void Update()
        {
            if (isPushed)
                XSpeed = dragDirection.x * dragSpeed;
            else
                XSpeed = 0;
        }
    }
}
