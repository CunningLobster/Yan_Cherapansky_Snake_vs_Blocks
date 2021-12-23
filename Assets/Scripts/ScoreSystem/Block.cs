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
        [SerializeField] ParticleSystem blockCrushEffect;

        AudioSource audioSource;

        Color color;
        Material material;

        ScoreIndicator scoreIndicator;

        private void Awake()
        {
            value = Random.Range(minValue, maxValue);

            material = GetComponent<Renderer>().material;
            color = new Color(1 - value / 35f, material.color.g, value / 35f);
            GetComponent<Renderer>().material.color = color;

            scoreIndicator = FindObjectOfType<ScoreIndicator>(true);
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
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
            blockCrushEffect.gameObject.SetActive(true);
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

                color = new Color(1 - value / 35f, material.color.g, value / 35f);
                GetComponent<Renderer>().material.color = color;

                snake.RemoveBone();
                yield return new WaitForSeconds(destroyingFrequency);
            }
        }
    }
}
