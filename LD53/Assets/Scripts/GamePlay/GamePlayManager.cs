using UnityEngine;
using Menu;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviourSingleton<GamePlayManager>
{
    [SerializeField] private int hp = 0;
    [SerializeField] private LevelProgress levelProgress = null;
    [SerializeField] private int[] levelDuration = new int[8];
    [SerializeField] private Movement.PlayerMovement player;
    [SerializeField] private Animator animPlayer;
    [SerializeField] private SoulSpawner spawner;
    [SerializeField] private GameObject[] souls;
    [SerializeField] private Animator puerto1;
    [SerializeField] private Animator puerto2;
    [SerializeField] private Transform endpos;


    [SerializeField] private GameObject[] onboardSouls;

    void Start()
    {
        levelProgress = new LevelProgress(()=> { Win(); },levelDuration[0]);
        CameraFading.CameraFade.In(3);
        initPlayer();
        
    }

    private void Update()
    {
        levelProgress.Update();
    }

    private void initPlayer()
    {
        player.enabled = false;
        spawner.enabled = false;
        Invoke("StartPlayer", 3);
    }
    private void StartPlayer()
    {
        player.enabled = true;
        spawner.enabled = true;
        puerto1.Play("Start");
    }

    public void ModifyHp(int hpModifier)
    {
        hp += hpModifier;
        if (hp <= 0)
        {
            GameOverManager.Get()?.GameOver();
        }

        onboardSouls[hp].gameObject.SetActive(false);
        onboardSouls[hp-1].gameObject.SetActive(true);

    }
    private void Win()
    {
        spawner.enabled = false;
        if (puerto2!=null)
        puerto2.Play("Start");
        Invoke("InvokeCorrutine", 1);
    }
    private void InvokeCorrutine()
    {
        StartCoroutine(playerLerp());
    }

    IEnumerator playerLerp()
    {
        Vector3 pos = player.transform.position;
        Vector3 endpos = this.endpos.position;
        float cTime=0;
        do
        {
            
            if (cTime >= 1)
            {
                cTime = 1;
            }
            player.transform.position = Vector3.Lerp(pos, endpos, cTime);
            if (cTime != 1)
            {
                cTime += Time.deltaTime;
                yield return null;
            }
        } while (cTime != 1);
        GameManager.Get().score = hp;
        Debug.Log("Game over");
        SceneManager.LoadScene(2);
    }
}
