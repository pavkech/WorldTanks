using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SetupVolume);
    }

    public void SetupVolume(float volume)
    {
        AudioListener.volume = volume;
        Debug.Log($"Текущая громкость: {AudioListener.volume}");
    }
}
