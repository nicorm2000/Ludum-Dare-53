using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] Button buttonMenu;

    private void Start()
    {
        scoreText.text = "scoreText = "+ GameManager.Get().score;
        buttonMenu.onClick.AddListener(() => { SceneManager.LoadScene(0); });
    }
}
