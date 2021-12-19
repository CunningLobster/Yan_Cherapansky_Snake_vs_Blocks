using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Segment : MonoBehaviour
    {

        CharacterController characterController;
        [SerializeField] Head head;

        void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (head == null) return;
            characterController.Move(head.characterController.velocity * Time.deltaTime);
        }
    }
}