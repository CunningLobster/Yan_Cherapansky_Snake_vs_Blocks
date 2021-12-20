using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platforms
{
    public class SpawnPortal : MonoBehaviour
    {
        PlatformSpawner platformSpawner;

        private void Awake()
        {
            platformSpawner = GameObject.FindObjectOfType<PlatformSpawner>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                platformSpawner.SpawnPlatform();

                if (platformSpawner.platforms.Count > 5)
                {
                    Destroy(platformSpawner.platforms[0].gameObject);
                    platformSpawner.platforms.RemoveAt(0);
                }
            }
        }
    }

}
