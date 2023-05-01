using UnityEngine;
using Menu;
using TMPro;
using System.Collections;

public class GamePlayManager : MonoBehaviourSingleton<GamePlayManager>
{
    [SerializeField] private int score = 5;
    [SerializeField] private int hp = 3;
    [SerializeField] private LevelProgress levelProgress = null;
    [SerializeField] private int[] levelDuration = new int[8];
    [SerializeField] private TMP_Text extraHp;
    [SerializeField] private Movement.PlayerMovement player;
    [SerializeField] private Animator animPlayer;
    [SerializeField] private SoulSpawner spawner;
    [SerializeField] private GameObject[] souls;
    private int currentSoul = -1;


    public GameObject[] hearts;

    void Start()
    {
        levelProgress = new LevelProgress(()=> { GameOverManager.Get()?.GameOver(); },levelDuration[0]);
        CameraFading.CameraFade.In(3);
        initPlayer();
    }

    private void Update()
    {
        levelProgress.Update();
        if (hp > 3)
        {
            extraHp.text = "+" + (hp - 3).ToString();
        }
        else
        {
            extraHp.text = "+0";
        }
    }

    private void initPlayer()
    {
        player.enabled = false;
        spawner.enabled = false;
        Invoke("StartPlayer", 4);
    }
    private void StartPlayer()
    {
        player.enabled = true;
        spawner.enabled = true;
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

        switch (hp)
        {
            case 0:
                hearts[0].gameObject.SetActive(false);
                break;

            case 1:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(false);
                break;

            case 2:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(false);
                break;

            case 3:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                break;
        }
    }
}
