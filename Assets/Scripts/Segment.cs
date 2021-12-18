using System.Collections;
using UnityEngine;
using Controls;

namespace Assets.Scripts
{
    public class Segment : MonoBehaviour
    {
        CharacterController characterController;
        [SerializeField] float movingSpeed = 10f;

        public Vector3 movingVector;

        [SerializeField] Transform node;
        [SerializeField] Segment head;

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
                movingVector.x = Mathf.Lerp(0, head.movingVector.x, .9f);
            }
            characterController.Move(movingVector);

        }

        bool OnNode()
        {
            return transform.position.x == node.position.x;
        }
    }
}