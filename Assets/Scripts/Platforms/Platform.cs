using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] Transform origin;
        [SerializeField] Transform end;
        [SerializeField] Collider spawnPortal;

        private void Awake()
        {
            GameObject.FindObjectOfType<PlatformSpawner>().GetPlatforms().Add(this);
        }

        public Transform GetOrigin()
        { 
            return origin;
        }
        public Transform GetEnd()
        { 
            return end;
        }
    }
}
