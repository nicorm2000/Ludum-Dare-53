using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class GameOverManager : MonoBehaviour
    {
        public void RestartGame()
        {
            //PauseMenu.isPause = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void LoadMenu()
        {
            //PauseMenu.isPause = false;
            SceneManager.LoadScene(0);
        }
    }
}
