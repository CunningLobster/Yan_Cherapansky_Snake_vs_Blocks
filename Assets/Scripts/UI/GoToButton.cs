using UnityEngine;

namespace UI
{
    public class GoToButton : MonoBehaviour
    {
        [SerializeField] GameObject screenToLeave;
        [SerializeField] GameObject screenToGo;

        public void GoToNextxScreen()
        { 
            if(screenToGo != null)
                screenToGo.SetActive(true);

            screenToLeave.SetActive(false);
        }
    }

}
