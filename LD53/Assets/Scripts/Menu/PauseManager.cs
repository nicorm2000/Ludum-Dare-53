using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

namespace Menu
{
    public class PauseManager : MonoBehaviour
    {
        public bool isPause = false;
        public void LoadMenu()
        {
            isPause = false;
            SceneManager.LoadScene(0);
        }

        private void OnEscape(InputValue inputValue)
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        public void Resume()
        {
            gameObject.SetActive(false);
            isPause = false;
        }

        private void Pause()
        {
            gameObject.SetActive(true);
            isPause = true;
        }
    }
}
