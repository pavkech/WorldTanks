using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private GameObject _menuUI;
    [SerializeField] private GameObject _settingsUI;

    private void Awake()
    {
        _playButton.onClick.AddListener(PlayGame);
        _settingsButton.onClick.AddListener(ToggleSettings);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Map_01");
    }

    private void ToggleSettings()
    {
        _menuUI.SetActive(_menuUI.activeSelf == false);
        _settingsUI.SetActive(_settingsUI.activeSelf == false);
    }
}
