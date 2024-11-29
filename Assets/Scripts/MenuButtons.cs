
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{

    [SerializeField] Button _playButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(PlayGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveAllListeners();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}