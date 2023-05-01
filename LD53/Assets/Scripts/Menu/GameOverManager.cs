using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Menu
{
    public class GameOverManager : MonoBehaviourSingleton<GameOverManager>
    {
        [SerializeField] private TextMeshProUGUI text;
        public void GameOver()
        {
            Time.timeScale = 0;
            //PauseManager.isPause = true;
            gameObject.SetActive(true);
            text.text = new string("Souls delivered: " + GameManager.Get().score);
        }
        public void RestartGame()
        {
            Time.timeScale = 1;
            //PauseManager.isPause = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void LoadMenu()
        {
            Time.timeScale = 1;
            //PauseManager.isPause = false;
            SceneManager.LoadScene(0);
        }
    }
}
