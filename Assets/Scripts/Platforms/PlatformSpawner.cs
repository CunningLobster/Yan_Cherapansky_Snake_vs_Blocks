using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        public List<Platform> platforms = new List<Platform>();
        [SerializeField] Platform[] platformPrefabs;
        [SerializeField] Transform Level;

        Vector3 firstPlatformPosition;
        [SerializeField] GameObject firstPlatformPrefab;

        private void Start()
        {
            firstPlatformPosition = platforms[0].transform.position;

            while (platforms.Count < 3)
            {
                SpawnPlatform();
            }

        }

        public void SpawnPlatform()
        {
            Platform lastSpawnedPlatform = platforms[platforms.Count - 1];
            Platform newPlatform = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            Vector3 newPlatformPos = lastSpawnedPlatform.end.position + newPlatform.transform.position - newPlatform.origin.position;
            newPlatform = Instantiate(newPlatform, newPlatformPos, Quaternion.identity);
            newPlatform.transform.SetParent(Level);
        }

        public void RebuildLevel()
        {
            foreach (Platform platform in platforms)
            { 
                Destroy(platform.gameObject);
            }
            platforms.Clear();
            Instantiate(firstPlatformPrefab, firstPlatformPosition, Quaternion.identity);

            while (platforms.Count < 3)
            {
                SpawnPlatform();
            }

        }
    }
}