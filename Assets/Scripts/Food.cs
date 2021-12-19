using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] ValueDisplayer valueDisplayer;

    private void Awake()
    {
        valueDisplayer.SetValue(Random.Range(1, 10));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Snake>(out Snake snake)) return;
        print("Triggered");
        for (int i = 0; i < valueDisplayer.GetValue(); i++)
        {
            FindObjectOfType<Snake>().AddBone();
        }
        Destroy(gameObject);
    }
}
