using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MyBox;

namespace MuseumCorvus.UI
{
    public enum NavigateDirection
    {
        Default,
        Up,
        Down,
        Left,
        Right,
    }

    public class PanelNavigator : MonoBehaviour
    {
        public bool DisableOnPause = false;
        public bool EnableCrossAsButtonClick = false;
        public bool AcceptLeftAnalogInput = false;
        [Space(10)]
        public Image Navigator;
        public float NavigatorSpeed = 0.3f;
        public float InputDelay = 0.2f;
        public Ease NavigationEase = Ease.Linear;

        public PanelNavigatable StartPanel;
        public PanelNavigatable CurrentPanel { get { return _currentPanel; } private set { SetCurrentPanel(value); } }

        [Space(10)]
        [Header("For Menu Switching")]
        [Space(10)]
        public bool MenuSwitchingEnabled = true;
        [ConditionalField("MenuSwitchingEnabled")] public Button ControlPanelButton;
        [ConditionalField("MenuSwitchingEnabled")] public Button DisplayPanelButton;
        [ConditionalField("MenuSwitchingEnabled")] public PanelNavigatable ControlPanelLowerButton;
        [ConditionalField("MenuSwitchingEnabled")] public PanelNavigatable DisplayPanelLowerButton;

        private PanelNavigatable _currentPanel;
        private NavigateDirection _lastDirection;

        private float _dpadVertical;
        private float _dpadHorizontal;

        private float _delay = 0f;

        // Use this for initialization
        void Start()
        {
            if (MenuSwitchingEnabled)
            {
                ControlPanelButton.onClick.AddListener(() =>
                {
                    if (!DisableOnPause /*GameState.IsPaused*/)
                        ControlPanelButton.GetComponent<PanelNavigatable>().LowerElement = ControlPanelLowerButton;
                });

                DisplayPanelButton.onClick.AddListener(() =>
                {
                    if (!DisableOnPause  /*GameState.IsPaused)*/)
                        DisplayPanelButton.GetComponent<PanelNavigatable>().LowerElement = DisplayPanelLowerButton;
                });
            }

            Invoke("GoToStartPanel", 0.1f);
        }

        private void GoToStartPanel()
        {
            CurrentPanel = StartPanel;
        }

        // Update is called once per frame
        void Update()
        {
            _dpadHorizontal = 0f;
            _dpadVertical = 0f;

           // if (DisableOnPause && GameState.IsPaused)
               // return;

            if (Input.GetButtonDown("L3"))
            {
                CurrentPanel.ClickButton();
            }
            else if(EnableCrossAsButtonClick && Input.GetButtonDown("Controller Cross"))
            {
                CurrentPanel.ClickButton();
            }

            if (_delay > 0f)
            {
                _delay -= Time.deltaTime;
            }
            else
            {
                _dpadHorizontal = Input.GetAxis("D-Pad Horizontal");
                _dpadVertical = Input.GetAxis("D-Pad Vertical");

                if(_dpadHorizontal == 0f && _dpadVertical == 0f && AcceptLeftAnalogInput)
                {
                    _dpadHorizontal = Input.GetAxis("Controller X");
                    _dpadVertical = Input.GetAxis("Controller Y");
                }

                if (_dpadVertical >= 0.5f)
                {
                    Navigate(NavigateDirection.Up);
                    _delay = InputDelay;
                }
                else if (_dpadVertical <= -0.5f)
                {
                    Navigate(NavigateDirection.Down);
                    _delay = InputDelay;
                }
                else if (_dpadHorizontal >= 0.5f)
                {
                    Navigate(NavigateDirection.Right);
                    _delay = InputDelay;
                }
                else if (_dpadHorizontal <= -0.5f)
                {
                    Navigate(NavigateDirection.Left);
                    _delay = InputDelay;
                }              
            }
        }

        private void Navigate(NavigateDirection direction)
        {
            switch (direction)
            {
                case NavigateDirection.Up:
                    _lastDirection = NavigateDirection.Up;
                    CurrentPanel = _currentPanel.UpperElement;
                    break;
                case NavigateDirection.Down:
                    _lastDirection = NavigateDirection.Down;
                    CurrentPanel = _currentPanel.LowerElement;
                    break;
                case NavigateDirection.Left:
                    _lastDirection = NavigateDirection.Left;
                    CurrentPanel = _currentPanel.LeftElement;
                    break;
                case NavigateDirection.Right:
                    _lastDirection = NavigateDirection.Right;
                    CurrentPanel = _currentPanel.RightElement;
                    break;
                case NavigateDirection.Default:
                    break;
            }
        }

        private void SetCurrentPanel(PanelNavigatable panel)
        {
            if (panel == null)
                return;
            else if (panel.GetComponent<Button>().interactable == false)
            {
                if (_lastDirection == NavigateDirection.Up && panel.UpperElement != null)
                {
                    SetCurrentPanel(panel.UpperElement);
                }
                else if (_lastDirection == NavigateDirection.Down && panel.LowerElement != null)
                {
                    SetCurrentPanel(panel.LowerElement);
                }
                else if (_lastDirection == NavigateDirection.Left && panel.LeftElement != null)
                {
                    SetCurrentPanel(panel.LeftElement);
                }
                else if (_lastDirection == NavigateDirection.Right && panel.RightElement != null)
                {
                    SetCurrentPanel(panel.RightElement);
                }

                return;
            }

            _currentPanel = panel;

            Navigator.rectTransform.DOSizeDelta(panel.GetComponent<RectTransform>().sizeDelta, NavigatorSpeed).SetEase(NavigationEase);
            Navigator.rectTransform.DOMove(panel.GetComponent<RectTransform>().position, NavigatorSpeed);
        }
    }
}
