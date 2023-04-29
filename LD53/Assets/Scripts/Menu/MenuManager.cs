using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CameraFading;
namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button optionsBackButton;
        [SerializeField] private Button creditsBackButton;

        [Header("Menus")]
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject creditsMenu;

        void Start()
        {
            playButton.Select();
            gameObject.SetActive(true);
            optionsMenu.SetActive(false);
            creditsMenu.SetActive(false);
            playButton.onClick.AddListener(OnPlayButtonClick);
        }

        public void OnPlayButtonClick()
        {
            CameraFade.Out(()=>SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1), 1, false, false);
        }

        public void OnOptionsButtonClick()
        {
            gameObject.SetActive(false);
            optionsMenu.SetActive(true);
            optionsBackButton.Select();
            
        }

        public void OnCreditsButtonClick()
        {
            gameObject.SetActive(false);
            creditsMenu.SetActive(true);
            creditsBackButton.Select();
        }

        public void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}