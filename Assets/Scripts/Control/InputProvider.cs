using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control
{
    public class InputProvider : MonoBehaviour
    {
        Vector2 dragDirection;
        float senseMult = 20f;

        public const string sensKey = "sens";

        public float XSpeed { get; private set; }

        bool isPushed;
        public bool isEsc;

        private void Awake()
        {
            PlayerPrefs.SetFloat(sensKey, PlayerPrefs.GetFloat(sensKey, .5f));
        }

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
                XSpeed = dragDirection.x * PlayerPrefs.GetFloat(sensKey, 0.5f) * senseMult;
            else
                XSpeed = 0;
        }

    }
}
