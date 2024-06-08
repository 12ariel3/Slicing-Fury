using Assets.Code.Common.Events;
using Assets.Code.Common.GemsData;
using Assets.Code.Common.Score;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _gemsText;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _backgroundBackToMenuButton;
        [SerializeField] private Button _adsButton;
        private InGameMenuMediator _mediator;

        private void Awake()
        {
            _backToMenuButton.onClick.AddListener(OnBackToMenuPressed);
            _backgroundBackToMenuButton.onClick.AddListener(OnBackToMenuPressed);
            _adsButton.onClick.AddListener(OnAdsPressed);
        }


        public void Configure(InGameMenuMediator mediator)
        {
            _mediator = mediator;
        }
        public void Show()
        {
            var currentScore = ServiceLocator.Instance.GetService<ScoreSystem>().BattleCurrentScore.ToString();
            var currentGems = ServiceLocator.Instance.GetService<GemsSystem>().BattleCurrentGems.ToString();
            _scoreText.SetText(currentScore);
            _gemsText.SetText(currentGems);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnBackToMenuPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
            ServiceLocator.Instance.GetService<AudioManager>().StopGameMusic();
            _mediator.OnBackToMenuPressed();
        }

        private void OnAdsPressed()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
                var NotEnoughEventData = new NotEnoughEventData("NotConnection", GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
                return;
            }
            else
            {
                _mediator.OnAdsPressed();
            }
        }
    }
}