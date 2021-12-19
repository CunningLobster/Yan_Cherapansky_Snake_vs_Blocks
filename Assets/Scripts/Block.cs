using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Block : MonoBehaviour
{
    [SerializeField] ValueDisplayer valueDisplayer;
    [SerializeField] int value;

    [Range(0, .5f), SerializeField] float destroyingFrequency = .1f;
    Color color;
    Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        color = new Color(1 - value /25f , material.color.g, value/ 25f);
        GetComponent<Renderer>().material.color = color;

    }

    private void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            value--;
            color = new Color(1 - value / 25f, material.color.g, value/ 25f);
            GetComponent<Renderer>().material.color = color;
        }

        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            value++;
            color = new Color(1 - value / 25f, material.color.g, value/ 25f);
            GetComponent<Renderer>().material.color = color;
        }
        print("B " + material.color.b);
        print("R " + material.color.r);

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
            color = new Color(1 - value / 25f, material.color.g, value / 25f);
            GetComponent<Renderer>().material.color = color;

            snake.RemoveBone();
            yield return new WaitForSeconds(destroyingFrequency);
        }
    }
}