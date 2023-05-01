using UnityEngine;

public class VolumeSet : MonoBehaviour
{
    public void SetVolume(float newVolume)
    {
        VolumeManager.Get()?.SetVolume(newVolume);
    }
}