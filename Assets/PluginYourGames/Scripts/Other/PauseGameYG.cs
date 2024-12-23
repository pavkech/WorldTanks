using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace YG
{
    public class PauseGameYG : MonoBehaviour
    {
        public static PauseGameYG inst;

        public float timeScale_save;
        public bool audioPause_save;
        public bool cursorVisible_save;
        public CursorLockMode cursorLockState_save;
        public bool eventSystem_save;

        private EventSystem eventSystem;

        public void Setup()
        {
            if (inst == null)
            {
                inst = this;
                DontDestroyOnLoad(inst);

                timeScale_save = Time.timeScale;
                audioPause_save = AudioListener.pause;
                cursorVisible_save = Cursor.visible;
                cursorLockState_save = Cursor.lockState;

                Time.timeScale = 0;
                AudioListener.pause = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                EventSystemDisable();
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            EventSystemDisable();
        }

        private void EventSystemDisable()
        {
            if (eventSystem == null)
            {
                eventSystem = GameObject.FindAnyObjectByType<EventSystem>();
                eventSystem_save = eventSystem.enabled;
                eventSystem.enabled = false;
            }
        }

        private void LateUpdate()
        {
            if (Time.timeScale != 0)
            {
                timeScale_save = Time.timeScale;
                Time.timeScale = 0;
            }

            if (AudioListener.pause != true)
            {
                audioPause_save = AudioListener.pause;
                AudioListener.pause = true;
            }

            if (Cursor.visible != true)
            {
                cursorVisible_save = Cursor.visible;
                Cursor.visible = true;
            }

            if (Cursor.lockState != CursorLockMode.None)
            {
                cursorLockState_save = Cursor.lockState;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        public void PauseDisabled()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;

            Time.timeScale = timeScale_save;
            AudioListener.pause = audioPause_save;
            Cursor.visible = cursorVisible_save;
            Cursor.lockState = cursorLockState_save;

            if (eventSystem != null)
                eventSystem.enabled = eventSystem_save;

            inst = null;
            DestroyImmediate(gameObject);
        }
    }
}
