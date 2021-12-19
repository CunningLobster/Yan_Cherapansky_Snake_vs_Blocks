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

    [SerializeField] ValueDisplayer valueDisplayer;

    private void Awake()
    {
        valueDisplayer.SetValue(tails.Count);
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
                bone.GetComponent<CharacterController>().Move((previousPosition - currentBonePosition) * moveSpeed * Time.deltaTime);
                previousPosition = currentBonePosition;
            }
            else
                break;
        }
    }

    public void AddBone()
    {
        GameObject bone = Instantiate(bonePrefab, tails[tails.Count - 1].transform.position, Quaternion.identity);
        tails.Add(bone.transform);
        valueDisplayer.SetValue(tails.Count);
    }

    public void RemoveBone()
    {
        Destroy(tails[0].gameObject);
        tails.RemoveAt(0);
        valueDisplayer.SetValue(tails.Count);
    }
}
