using Snake;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScoreSystem
{
    public class Block : MonoBehaviour
    {
        [SerializeField] ValueDisplayer valueDisplayer;
        [SerializeField] int minValue;
        [SerializeField] int maxValue;
        int value;

        [Range(0, .5f), SerializeField] float destroyingFrequency = .1f;
        AudioSource audioSource;

        Color color;
        Material material;

        ScoreIndicator scoreIndicator;

        private void Awake()
        {
            value = Random.Range(minValue, maxValue);
            material = GetComponent<Renderer>().material;
            color = new Color(1 - value / 25f, material.color.g, value / 25f);
            GetComponent<Renderer>().material.color = color;
            scoreIndicator = FindObjectOfType<ScoreIndicator>(true);
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Keyboard.current.cKey.wasPressedThisFrame)
            {
                value--;
                color = new Color(1 - value / 25f, material.color.g, value / 25f);
                GetComponent<Renderer>().material.color = color;
            }

            if (Keyboard.current.vKey.wasPressedThisFrame)
            {
                value++;
                color = new Color(1 - value / 25f, material.color.g, value / 25f);
                GetComponent<Renderer>().material.color = color;
            }
            //print("B " + material.color.b);
            //print("R " + material.color.r);

            valueDisplayer.SetValue(value);

            if (value <= 0)
            {
                DestroyBlock();
            }
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<SnakeBuilder>(out SnakeBuilder snake)) return;

            Vector3 blockToSnake = snake.transform.position - transform.position;
            Debug.Log("blockToSnake" + blockToSnake);

            if (Vector3.Dot(blockToSnake.normalized, Vector3.back) > .7f)
            {
                StartCoroutine(DecreaseBlockValue(snake));
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            StopAllCoroutines();
        }

        private void DestroyBlock()
        {
            GetComponent<MeshRenderer>().enabled = false;
            valueDisplayer.GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, audioSource.clip.length);
        }

        IEnumerator DecreaseBlockValue(SnakeBuilder snake)
        {
            while (snake.isActiveAndEnabled && value > 0)
            {
                value--;
                scoreIndicator.AddScore();
                audioSource.Play();

                color = new Color(1 - value / 25f, material.color.g, value / 25f);
                GetComponent<Renderer>().material.color = color;

                snake.RemoveBone();
                yield return new WaitForSeconds(destroyingFrequency);
            }
        }
    }
}
