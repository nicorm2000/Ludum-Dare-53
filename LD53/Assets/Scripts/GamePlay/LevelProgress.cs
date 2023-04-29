using Menu;
using UnityEngine;

[System.Serializable]
public class LevelProgress
{
    [SerializeField] private float finalTime = 100;
    [SerializeField] private float DeltaTime = 0;

    public System.Action OnEndLvl = null;

    public LevelProgress(System.Action OnEndLvl,float endTime)
    {
        finalTime = endTime;
        Init(OnEndLvl);
    }

    public void Init(System.Action OnEndLvl)
    {
        this.OnEndLvl = OnEndLvl;
    }
    public void Update()
    {
        if (DeltaTime >= finalTime)
            OnEndLvl?.Invoke();
        else
            if (!PauseManager.Get().IsPause)
                DeltaTime += Time.deltaTime;
    }

}
