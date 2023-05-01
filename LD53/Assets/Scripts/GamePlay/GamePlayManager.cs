using UnityEngine;
using Menu;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviourSingleton<GamePlayManager>
{
    [SerializeField] private GameOverManager GOM;
    [SerializeField] public int lvl;
    [SerializeField] private int hp = 0;
    [SerializeField] private LevelProgress levelProgress = null;
    [SerializeField] private int[] levelDuration = new int[8];
    [SerializeField] private int[] levelEnemies = new int[8];
    [SerializeField] private int[] levelSouls = new int[8];
    [SerializeField] private int[] levelSpeed = new int[8];
    [SerializeField] private int[] levelrandomization = new int[8];
    [SerializeField] private Movement.PlayerMovement player;
    [SerializeField] private Animator animPlayer;
    [SerializeField] private SoulSpawner spawner;
    
    [SerializeField] private GameObject[] souls;
    [SerializeField] private Animator puerto1;
    [SerializeField] private Animator puerto2;
    [SerializeField] private Transform endpos;
    [SerializeField] private ParticleSystem PS;
    
    [SerializeField] private GameObject[] onboardSouls;
    private ParticleSystem.MainModule MainPS;
    [SerializeField] private GameObject Background1;
    [SerializeField] private GameObject Background2;
    [SerializeField] private GameObject BackgroundLine1;
    [SerializeField] private GameObject BackgroundLine2;

    void Start()
    {
        Background1.GetComponent<BgTP>().speed = 0;
        Background2.GetComponent<BgTP>().speed = 0;
        BackgroundLine1.GetComponent<BgTP>().speed = 0;
        BackgroundLine2.GetComponent<BgTP>().speed = 0;
        MainPS = PS.main;
        PS.Stop();
        MainPS.startSpeed = 1;
        PS.Play();
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
        spawner.SetupSpawner(levelEnemies[lvl], levelSouls[lvl], levelDuration[lvl], levelSpeed[lvl], levelrandomization[lvl]);
        Debug.Log(levelEnemies[lvl]+"; "+ levelSouls[lvl] + "; " + levelDuration[lvl] + "; " + levelrandomization[lvl]);
        puerto1.Play("Start");
        PS.Stop();
        MainPS.startSpeed = levelSpeed[lvl];
        PS.Play();
        Background1.GetComponent<BgTP>().speed = levelSpeed[lvl] * 0.6f;
        Background2.GetComponent<BgTP>().speed = levelSpeed[lvl] * 0.6f;
        BackgroundLine1.GetComponent<BgTP>().speed = levelSpeed[lvl];
        BackgroundLine2.GetComponent<BgTP>().speed = levelSpeed[lvl];
        levelProgress = new LevelProgress(() => { Win(); }, levelDuration[0]);
    }

    public void ModifyHp(int hpModifier)
    {
        hp += hpModifier;
        if (hp <= 0)
        {
            GOM.GameOver();
        }

        onboardSouls[hp].gameObject.SetActive(false);
        onboardSouls[hp-1].gameObject.SetActive(true);

    }
    private void Win()
    {
        
        spawner.enabled = false;
        if (puerto2!=null)
        puerto2.Play("Start");
        Invoke("InvokeCorrutine", 6);
    }
    private void InvokeCorrutine()
    {
        if (MainPS.startSpeed.constant !=1 )
        {
            PS.Stop();
            MainPS.startSpeed = 1;
            PS.Play();
        }
        Background1.GetComponent<BgTP>().speed = 0;
        Background2.GetComponent<BgTP>().speed = 0;
        BackgroundLine1.GetComponent<BgTP>().speed = 0;
        BackgroundLine2.GetComponent<BgTP>().speed = 0;
        
        StartCoroutine(playerLerp());
    }

    IEnumerator playerLerp()
    {
        
        Vector3 pos = player.transform.position;
        Vector3 endpos = this.endpos.position;
        float cTime=0;
        do
        {
            
            if (cTime >= 2)
            {
                cTime = 2;
            }
            player.transform.position = Vector3.Lerp(pos, endpos, cTime);
            
            if (cTime != 2)
            {
                cTime += Time.deltaTime;
                yield return null;
            }
        } while (cTime != 2);
        GameManager.Get().score = hp;
        yield return new WaitForSeconds(1);
        Debug.Log("Game over");
        SceneManager.LoadScene(2);
    }
}
