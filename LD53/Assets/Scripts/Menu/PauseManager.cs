using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseManager : MonoBehaviourSingleton<PauseManager>
    {
        [SerializeField] private GameObject pauseMenu;
        private InputAction _pauseAction;
        private bool _isPause;
        public bool IsPause { get { return _isPause; } private set { _isPause = value; } }
        private new void Awake()
        {
            base.Awake();
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
            _isPause = true;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            _isPause = false;
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
