using UnityEngine;
using UnityEngine.UI;
using YG;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SetupVolume);

        float volumeSetting = YG2.saves.volumeSetting;
        _slider.value = volumeSetting;
        SetupVolume(volumeSetting);
    }

    public void SetupVolume(float volume)
    {
        AudioListener.volume = volume;
        YG2.saves.volumeSetting = volume;
        YG2.SaveProgress();
    }
}
