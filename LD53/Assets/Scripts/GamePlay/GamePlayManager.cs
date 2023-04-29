using UnityEngine;
using Menu;
public class GamePlayManager : MonoBehaviourSingleton<GamePlayManager>
{
    [SerializeField] private int score = 5;
    [SerializeField] private int hp = 3;
    [SerializeField] private LevelProgress levelProgress = null;
    [SerializeField] private int[] levelDuration = new int[8];
    void Start()
    {
        levelProgress = new LevelProgress(()=> { GameOverManager.Get()?.GameOver(); },levelDuration[0]);
        CameraFading.CameraFade.In(3);
    }

    private void Update()
    {
        levelProgress.Update();
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
            GameOverManager.Get()?.GameOver();
        }
    }
}
