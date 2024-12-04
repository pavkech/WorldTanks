using UnityEngine;
using YG;

public class LoadSettings : MonoBehaviour
{

    [SerializeField] private AudioListener _listener;

    private void Awake()
    { 

        float volumeSetting = YG2.saves.volumeSetting;
        AudioListener.volume = volumeSetting;
    }
}
