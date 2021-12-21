using Control;
using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Snake
{
    public class SnakeBuilder : MonoBehaviour
    {
        [SerializeField] private List<Transform> bones;
        [SerializeField] private GameObject bonePrefab;
        [SerializeField] private ParticleSystem sparklesEffect;

        [SerializeField] ValueDisplayer valueDisplayer;

        [SerializeField] GameObject zeroBone;

        Vector3 startPosition;
        int startBonesCount;

        private void Awake()
        {
            valueDisplayer.SetValue(bones.Count);
            startPosition = transform.position;
            startBonesCount = bones.Count;
        }

        public void AddBone(Transform bone)
        {
            if (bones.Count == 0)
                zeroBone.SetActive(false);

            GameObject boneToAdd = Instantiate(bonePrefab, bone.position, Quaternion.identity);
            bones.Add(boneToAdd.transform);
            valueDisplayer.SetValue(bones.Count);

        }

        public void RemoveBone()
        {
            sparklesEffect.Play();

            if (bones.Count == 1)
                zeroBone.SetActive(true);

            if (bones.Count <= 0)
                Die();
            else
            {
                Destroy(bones[0].gameObject);
                bones.RemoveAt(0);
                valueDisplayer.SetValue(bones.Count);
            }
        }

        public List<Transform> GetBones()
        {
            return bones;
        }

        void Die()
        {
            FindObjectOfType<GameOverScreen>(true).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void RebuildSnake()
        {
            transform.position = startPosition;
            gameObject.SetActive(true);
            for (int i = 0; i < startBonesCount; i++)
            {
                AddBone(transform);
            }
        }
    }

}
