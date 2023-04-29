using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class GameOverManager : MonoBehaviourSingleton<GameOverManager>
    {
        public void GameOver()
        {
            Time.timeScale = 0;
            //PauseManager.isPause = true;
            gameObject.SetActive(true);
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
