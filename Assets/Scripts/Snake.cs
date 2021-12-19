using Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private List<Transform> tails;
    [SerializeField] private float bonesDistance;
    [SerializeField] private GameObject bonePrefab;
    [Range(0, 20), SerializeField] private float moveSpeed;
    CharacterController characterController;
    Vector3 movingVector;

    [Range(0, 1), SerializeField] float interpolator = .5f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
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
        float sqrDistance = Mathf.Sqrt(bonesDistance);
        Vector3 previousPosition = transform.position;

        foreach (var bone in tails)
        {
            if ((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 currentBonePosition = bone.position;
                bone.GetComponent<CharacterController>().Move((previousPosition - currentBonePosition) * moveSpeed * 2f * Time.deltaTime);
                previousPosition = currentBonePosition;
            }
            else
                break;
        }
    }
}
