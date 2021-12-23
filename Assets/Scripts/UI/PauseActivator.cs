using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class PauseActivator : MonoBehaviour
    {
        [SerializeField] PauseScreen pauseScreen;
        public void OnEsc(InputAction.CallbackContext context)
        {
            pauseScreen.gameObject.SetActive(true);
        }
    }
}