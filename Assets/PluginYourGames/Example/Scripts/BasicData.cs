using UnityEngine;
using UnityEngine.UI;

namespace YG.Example
{
    public class BasicData : MonoBehaviour
    {
        public Text dataText;

        private void OnEnable()
        {
            YG2.onGetSDKData += DrawText;
            YG2.onFocusWindowGame += OnFocusWindowGame;
        }

        private void OnDisable()
        {
            YG2.onGetSDKData -= DrawText;
            YG2.onFocusWindowGame -= OnFocusWindowGame;
        }

        private void Start()
        {
            DrawText();
        }

        public void DrawText()
        {
            string platformName = $"platform = <color=#cd5200>{YG2.platform}</color>";
            string focusWindowGame = $"is Focus Window Game = {YG2.isFocusWindowGame.ToString()}";
            string isFirstGameSession = $"is First Game Session = {YG2.isFirstGameSession.ToString()}";
            string gameplaying = $"is Gameplaying = {YG2.isGameplaying.ToString()}";

            dataText.text = $"{platformName}\n{isFirstGameSession}\n{focusWindowGame}\n{gameplaying}";
        }

        private void OnFocusWindowGame(bool hasFocus)
        {
            DrawText();
        }
    }
}