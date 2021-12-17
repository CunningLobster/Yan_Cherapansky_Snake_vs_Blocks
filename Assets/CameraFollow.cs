using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Transform target;
        Vector3 offset;

        private void Awake()
        {
            offset = target.position - transform.position;
        }

        void Update()
        {
            transform.position = target.position - offset;
        }
    }
}
