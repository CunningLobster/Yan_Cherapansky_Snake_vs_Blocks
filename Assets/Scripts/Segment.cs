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
        public float k = 0;

        [Header("Adjusting")]
        [Range(0, 50)] public float minK = 0;
        [Range(0, 50)] public float maxK = .5f;
        [Range(0, 2)] public float toNodeDistance = 1f;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {

            //movingVector = new Vector3(0, 0, movingSpeed) * Time.deltaTime;
            if (isHead)
            {
                movingVector.z = movingSpeed * Time.deltaTime;
                movingVector.x = FindObjectOfType<InputProvider>().XSpeed * Time.deltaTime;
            }
            else
            {
                movingVector.z = node.position.z - transform.position.z;
                k = Mathf.Abs(node.position.x - transform.position.x) > toNodeDistance ? maxK : minK;
                movingVector.x = (node.position.x - transform.position.x) * k * Time.deltaTime;
                print(node.position.x - transform.position.x);
            }
            characterController.Move(movingVector);

        }

        bool OnNode()
        {
            return transform.position.x == node.position.x;
        }
    }
}