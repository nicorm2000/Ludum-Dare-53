using UnityEngine;
using UnityEngine.InputSystem;

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

        private void OnPause(InputAction.CallbackContext context)
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

        private void ResumeGame()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}
