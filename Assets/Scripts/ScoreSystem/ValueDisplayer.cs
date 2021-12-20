using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScoreSystem
{
    public class ValueDisplayer : MonoBehaviour
    {
        TMP_Text valueText;
        int value;

        private void Awake()
        {
            valueText = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            valueText.text = value.ToString();
        }

        public void SetValue(int newValue)
        {
            value = newValue;
        }
        public int GetValue()
        {
            return value;
        }
    }
}
