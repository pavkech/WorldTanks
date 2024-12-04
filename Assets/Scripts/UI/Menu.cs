using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private GameObject _menuUI;
    [SerializeField] private GameObject _settingsUI;
    [SerializeField] private Button _closeSettingsButton;
    [SerializeField] private Animator _fadeInOut;

    private void Awake()
    {
        _playButton.onClick.AddListener(PlayGame);
        _settingsButton.onClick.AddListener(ToggleSettings);
        _closeSettingsButton.onClick.AddListener(ToggleSettings);
    }

    private void PlayGame()
    {
        _fadeInOut.SetTrigger("fade");

        StartCoroutine(LoadPlayableScene());
    }

    private void ToggleSettings()
    {
        _menuUI.SetActive(_menuUI.activeSelf == false);
        _settingsUI.SetActive(_settingsUI.activeSelf == false);
    }

    private IEnumerator LoadPlayableScene()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Map_01");
    }
}
