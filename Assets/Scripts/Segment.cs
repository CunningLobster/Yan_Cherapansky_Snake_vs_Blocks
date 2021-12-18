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
        [SerializeField] CharacterController head;

        public bool isHead;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {

            movingVector = new Vector3(0, 0, movingSpeed) * Time.deltaTime;
            if (isHead)
            {
                movingVector.x = FindObjectOfType<InputProvider>().XSpeed * Time.deltaTime;
            }
            else
            {
                Debug.Log(OnNode());

                if (!OnNode())
                    movingVector.x = head.transform.position.x - transform.position.x;
            }
            characterController.Move(movingVector);

        }

        bool OnNode()
        {
            return transform.position.x == node.position.x;
        }
    }
}