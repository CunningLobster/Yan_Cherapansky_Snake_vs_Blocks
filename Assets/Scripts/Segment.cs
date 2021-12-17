using System.Collections;
using UnityEngine;
using Controls;

namespace Assets.Scripts
{
    public class Segment : MonoBehaviour
    {
        CharacterController characterController;
        [SerializeField] float movingSpeed = 10f;

        Vector3 movingVector;

        [SerializeField] Transform node;

        public bool isHead;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
                movingVector = new Vector3(FindObjectOfType<InputProvider>().XSpeed, 0, movingSpeed) * Time.deltaTime;
                characterController.Move(movingVector);
        }

    }
}