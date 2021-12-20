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

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent<SnakeBuilder>(out SnakeBuilder snake)) return;
            print("Triggered");
            for (int i = 0; i < valueDisplayer.GetValue(); i++)
            {
                FindObjectOfType<SnakeBuilder>().AddBone(snake.GetBones()[snake.GetBones().Count - 1]);
            }
            Destroy(gameObject);
        }
    }
}
