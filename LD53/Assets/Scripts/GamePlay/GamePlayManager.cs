using UnityEngine;
using Menu;
public class GamePlayManager : MonoBehaviour
{
    private static GamePlayManager instance;
    [SerializeField] private int score = 5;
    [SerializeField] private int hp = 3;
    [SerializeField] private GameOverManager gameOverManager;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        CameraFading.CameraFade.In(3);
        if(gameOverManager == null)
        {
            gameOverManager = FindObjectOfType<GameOverManager>();
        }
    }

    
    public void ModifyScore(int scoreModifier)
    {
        score += scoreModifier;
    }

    public void ModifyHp(int hpModifier)
    {
        hp += hpModifier;
        if (hp <= 0)
        {
            gameOverManager.GameOver();
        }
    }

}
