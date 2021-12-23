using Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] Slider sensSlider;

        InputProvider inputProvider;

        private void Awake()
        {
            sensSlider.value = PlayerPrefs.GetFloat(InputProvider.sensKey);
            inputProvider = FindObjectOfType<InputProvider>();
        }

        private void Update()
        {
            PlayerPrefs.SetFloat(InputProvider.sensKey, sensSlider.value);
            Debug.Log(PlayerPrefs.GetFloat(InputProvider.sensKey));
        }
    }
}
