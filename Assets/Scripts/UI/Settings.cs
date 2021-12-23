using Control;// To Fix
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] Slider sensSlider;
        [SerializeField] Toggle soundOn;

        InputProvider inputProvider;
        public const string soundOnKey = "soundOn";

        private void Awake()
        {
            sensSlider.value = PlayerPrefs.GetFloat(InputProvider.sensKey);
            inputProvider = FindObjectOfType<InputProvider>();
            soundOn.isOn = KeyToSoundBool(PlayerPrefs.GetInt(soundOnKey, 1));
        }

        private void Update()
        {
            PlayerPrefs.SetInt(soundOnKey, SoundBoolToKey(soundOn.isOn));
            Camera.main.GetComponent<AudioListener>().enabled = soundOn.isOn;
            PlayerPrefs.SetFloat(InputProvider.sensKey, sensSlider.value);

            Debug.Log(PlayerPrefs.GetFloat(InputProvider.sensKey));
        }

        int SoundBoolToKey(bool value)
        {
            if (value)
                return 1;
            else
                return 0;
        }

        bool KeyToSoundBool(int value)
        {
            if (value == 1)
                return true;
            else
                return false;
        }
    }
}
