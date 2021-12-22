using Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class SnakeMover : MonoBehaviour
    {
        [SerializeField] private float bonesDistance;
        [Range(0, 20), SerializeField] private float moveSpeed;
        CharacterController characterController;
        Vector3 movingVector;
        List<Transform> bones;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            bones = GetComponent<SnakeBuilder>().GetBones();
        }

        private void Update()
        {
            MoveHead(moveSpeed);
            MoveTail();
        }

        private void MoveHead(float speed)
        {
            movingVector.z = moveSpeed * Time.deltaTime;
            movingVector.x = FindObjectOfType<InputProvider>().XSpeed * Time.deltaTime;
            characterController.Move(movingVector);
        }

        private void MoveTail()
        {
            float sqrDistance = Mathf.Pow(bonesDistance, 2);
            Vector3 previousPosition = transform.position;

            foreach (var bone in bones)
            {
                if ((bone.position - previousPosition).sqrMagnitude > sqrDistance)
                {
                    Vector3 currentBonePosition = bone.position;
                    bone.GetComponent<CharacterController>().Move((previousPosition - currentBonePosition) * moveSpeed * Time.deltaTime);
                    previousPosition = currentBonePosition;
                }
                else
                    break;
            }
        }

    }
}
