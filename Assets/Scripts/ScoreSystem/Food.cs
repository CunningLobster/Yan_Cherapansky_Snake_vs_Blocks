using Snake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem
{
    public class Food : MonoBehaviour
    {
        [SerializeField] ValueDisplayer valueDisplayer;

        private void Awake()
        {
            valueDisplayer.SetValue(Random.Range(1, 10));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<SnakeBuilder>(out SnakeBuilder snake)) return;

            AudioSource audioSource = GetComponent<AudioSource>();

            for (int i = 0; i < valueDisplayer.GetValue(); i++)
            {
                if (snake.GetBones().Count == 0)
                    snake.AddBone(snake.transform);
                else
                    snake.AddBone(snake.GetBones()[snake.GetBones().Count - 1]);
            }

            audioSource.Play();
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, audioSource.clip.length);

            GetComponent<Collider>().enabled = false;
        }
    }
}
