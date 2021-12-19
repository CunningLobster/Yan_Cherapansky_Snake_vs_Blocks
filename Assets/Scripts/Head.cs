using System.Collections;
using UnityEngine;
using Controls;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Head : MonoBehaviour
    {
        public CharacterController characterController;
        [SerializeField] float movingSpeed = 10f;

        public Vector3 movingVector;

        [SerializeField] Transform node;

        public List<float> zPositions = new List<float>();
        public List<Vector3> velocities = new List<Vector3>();

        public bool isHead;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            velocities.Add(new Vector3(0, 0, 5f));
            zPositions.Add(transform.position.z);
        }

        private void Update()
        {
            if (!isHead) return;
            zPositions.Add(transform.position.z);
            HeadMove(characterController);
        }

        private void HeadMove(CharacterController charController)
        {
            movingVector.z = movingSpeed * Time.deltaTime;
            movingVector.x = FindObjectOfType<InputProvider>().XSpeed * Time.deltaTime;
            charController.Move(movingVector);
        }
    }
}