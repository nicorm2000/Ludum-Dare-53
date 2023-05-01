using System;
using UnityEngine;


public class VolumeManager : MonoBehaviourSingleton<VolumeManager>
{
    private FMOD.Studio.Bus _master;
    
    [SerializeField]
    private float masterVolume = 0.5f;

    public void SetVolume(float newVolumeValue)
    {
        this.masterVolume = newVolumeValue;
        _master.setVolume(masterVolume);
    }

    private new void Awake()
    {
        base.Awake();
        _master = FMODUnity.RuntimeManager.GetBus("bus:/");
        _master.setVolume(0.25f);
    }
}
