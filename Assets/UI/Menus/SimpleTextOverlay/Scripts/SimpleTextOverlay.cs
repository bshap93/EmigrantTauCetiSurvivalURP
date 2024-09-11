using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus.SimpleTextOverlay.Scripts
{
    public enum OverlayState
    {
        Paused,
        Dead,
        Normal
    }

    public class SimpleTextOverlay : MonoBehaviour
    {
        Button _button;
        TMP_Text _buttonText;
        OverlayState _currentOverlayState;
        Image _overlayPanel;
        TMP_Text _overlayText;


        void Start()
        {
            _overlayPanel = GetComponent<Image>();
            _overlayText = GetComponentInChildren<TMP_Text>();
            _currentOverlayState = OverlayState.Normal;
            _button = GetComponentInChildren<Button>();
            _buttonText = _button.GetComponentInChildren<TMP_Text>();
            _button.onClick.AddListener(OnButtonClick);
        }
        public event Action OnRestartCurrentLevel;

        public void SetState(OverlayState overlayState)
        {
            switch (overlayState)
            {
                case OverlayState.Normal:
                    gameObject.SetActive(false);
                    break;
                case OverlayState.Paused:
                    SetOverlayPause();
                    break;
                case OverlayState.Dead:
                    SetOverlayDead();

                    break;
            }
        }

        void SetOverlayPause()
        {
            _overlayPanel.color = new Color(0, 0, 0, 0.5f);
            _overlayText.text = "Paused";
            _buttonText.text = "Resume";
            gameObject.SetActive(true);
        }

        void SetOverlayDead()
        {
            _overlayPanel.color = new Color(0, 0, 0, 0.5f);
            _overlayText.text = "You Died";
            _buttonText.text = "Restart";
            gameObject.SetActive(true);
        }

        void OnButtonClick()
        {
            if (_currentOverlayState == OverlayState.Paused)
            {
                SetState(OverlayState.Normal);
            }
            else if (_currentOverlayState == OverlayState.Dead)
            {
                SetState(OverlayState.Normal);
                OnRestartCurrentLevel?.Invoke();
            }
        }
    }
}
