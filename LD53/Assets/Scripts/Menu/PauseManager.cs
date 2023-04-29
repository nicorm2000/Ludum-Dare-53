using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        private InputAction _pauseAction;

        private void Awake()
        {
            _pauseAction = new InputAction(binding: "<Keyboard>/escape");
            _pauseAction.performed += OnPause;
        }

        private void OnEnable()
        {
            _pauseAction.Enable();
        }

        private void OnDisable()
        {
            _pauseAction.Disable();
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (pauseMenu.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        
        public void LoadMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        
        public void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}
