using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] ValueDisplayer valueDisplayer;
    [SerializeField] int value;

    [Range(0, .5f), SerializeField] float destroyingFrequency = .1f;

    private void Update()
    {
        valueDisplayer.SetValue(value);
        if (value == 0)
        { 
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<Snake>(out Snake snake)) return;
        StartCoroutine(DestroyBlock(snake));
    }

    IEnumerator DestroyBlock(Snake snake)
    {
        while (true)
        {
            value--;
            snake.RemoveBone();
            yield return new WaitForSeconds(destroyingFrequency);
        }
    }
}
