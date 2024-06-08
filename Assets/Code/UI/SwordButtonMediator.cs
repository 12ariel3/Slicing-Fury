using Assets.Code.Common.Events;
using Assets.Code.Common.Level;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using Assets.Code.Trails;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class SwordButtonMediator : MonoBehaviour, EventObserver
    {
        [SerializeField] private Button _swordButton;
        [SerializeField] private SelectedSwordView _selectedSwordView;
        [SerializeField] private Button _lockButton;
        [SerializeField] private UnlockSwordView _unlockSwordView;
        [SerializeField] private TextMeshProUGUI _unlockScoreTextValue;
        [SerializeField] private TextMeshProUGUI _unlockGemsTextValue;
        [SerializeField] private Trail _trail;

        [SerializeField] private Image _swordImage;
        [SerializeField] private TextMeshProUGUI _swordName;
        [SerializeField] private TextMeshProUGUI _swordLevel;
        [SerializeField] private Image _deepBackground;
        [SerializeField] private Image _background;
        [SerializeField] private Image _iconBackground;

        private Color _deepBackgroundColor;
        private Color _backgroundColor;
        private Color _iconBackgroundColor;
        private Color _nameColor;
        private Color _levelColor;

        private void Awake()
        {
            _swordButton.onClick.AddListener(ShowSelectedSwordView);
            _lockButton.onClick.AddListener(ShowUnlockSwordView);
        }



        private void Start()
        {
            SetButtonColors();
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.SwordLevelUp, this);
            eventQueue.Subscribe(EventIds.SwordUnlocked, this);
            SetInitialSwordParameters();
        }


        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.SwordLevelUp, this);
            eventQueue.Unsubscribe(EventIds.SwordUnlocked, this);
        }


        private void SetInitialSwordParameters()
        {
            var swordEquippedName = ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped();
            if (swordEquippedName == _trail.Id)
            {
                var swordEquipedEventData = new SwordEquipedEventData(_trail.SwordSprite, _trail.TrailUpgradeValue, _trail.Id, _trail.Level,
                                                                  _trail.Attack, _trail.HP, _trail.CriticalProbability,
                                                                  _trail.ExcelentProbability, _trail.CriticalMultiplier, _trail.ExcelentMultiplier,
                                                                  _trail.MultipleHitsProbability, _trail.NumberOfHits, _trail.HpAbsorbDenominator,
                                                                  _trail.HpAbsorbProbability, _trail.DeepBackground, _trail.Background,
                                                                  _trail.IconBackground, _trail.NameColor, _trail.LevelColor, _trail.TrailRenderer,
                                                                  GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(swordEquipedEventData);
            }

            _unlockScoreTextValue.SetText(_trail.TrailUnlockScoreCost.ToString());
            _unlockGemsTextValue.SetText(_trail.TrailUnlockGemsCost.ToString());

            if (ServiceLocator.Instance.GetService<SwordsLevelSystem>().GetIfIsSwordUnlocked(_trail.Id))
            {
                _lockButton.gameObject.SetActive(false);
            }
            else
            {
                _lockButton.gameObject.SetActive(true);
            }
        }

        private void SetButtonColors()
        {
            _deepBackgroundColor = _trail.DeepBackground;
            _deepBackgroundColor.a = 1f;
            _backgroundColor = _trail.Background;
            _backgroundColor.a = 1f;
            _iconBackgroundColor = _trail.IconBackground;
            _iconBackgroundColor.a = 1f;
            _nameColor = _trail.NameColor;
            _nameColor.a = 1f;
            _levelColor = _trail.LevelColor;
            _levelColor.a = 1f;

            _swordImage.sprite = _trail.SwordSprite;
            _swordName.SetText(_trail.Id);
            _swordName.color = _nameColor;
            _swordLevel.SetText(_trail.Level.ToString());
            _swordLevel.color = _levelColor;
            _deepBackground.color = _deepBackgroundColor;
            _background.color = _backgroundColor;
            _iconBackground.color = _iconBackgroundColor;
        }

        private void ShowSelectedSwordView()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");

            _selectedSwordView.SetStadistics(_trail.SwordSprite, _trail.TrailUpgradeValue, _trail.Id, _trail.Level, _trail.Attack, _trail.HP,
                                             _trail.CriticalProbability, _trail.ExcelentProbability, _trail.CriticalMultiplier,
                                             _trail.ExcelentMultiplier, _trail.MultipleHitsProbability, _trail.NumberOfHits, 
                                             _trail.HpAbsorbDenominator, _trail.HpAbsorbProbability, _trail.DeepBackground, _trail.Background,
                                             _trail.IconBackground, _trail.NameColor, _trail.LevelColor, _trail.TrailRenderer);
            _selectedSwordView.Show();
        }

        private void ShowUnlockSwordView()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");

            _unlockSwordView.SetStadistics(_trail.SwordSprite, _trail.TrailUnlockScoreCost, _trail.TrailUnlockGemsCost, _trail.Id, _trail.Level,
                                            _trail.DeepBackground, _trail.Background, _trail.IconBackground, _trail.NameColor, _trail.LevelColor);

            _unlockSwordView.Show();
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.SwordLevelUp)
            {
                var swordLevelUpEventData = (SwordLevelUpEventData)eventData;
                if(swordLevelUpEventData.SwordId == _trail.Id)
                {
                    _trail.LevelUp(swordLevelUpEventData.SwordLevel);

                    var swordEquippedLevelUpEventData = new SwordEquippedLevelUpEventData(_trail.Id, _trail.TrailUpgradeValue, _trail.Level,
                                             _trail.Attack, _trail.HP, _trail.CriticalProbability, _trail.ExcelentProbability,
                                             _trail.CriticalMultiplier, _trail.ExcelentMultiplier, _trail.MultipleHitsProbability,
                                             _trail.NumberOfHits, _trail.HpAbsorbDenominator, _trail.HpAbsorbProbability, GetInstanceID());

                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(swordEquippedLevelUpEventData);

                    _selectedSwordView.SetStadistics(_trail.SwordSprite, _trail.TrailUpgradeValue, _trail.Id, _trail.Level, _trail.Attack, _trail.HP,
                                             _trail.CriticalProbability, _trail.ExcelentProbability, _trail.CriticalMultiplier,
                                             _trail.ExcelentMultiplier, _trail.MultipleHitsProbability, _trail.NumberOfHits,
                                             _trail.HpAbsorbDenominator, _trail.HpAbsorbProbability, _trail.DeepBackground, _trail.Background,
                                             _trail.IconBackground, _trail.NameColor, _trail.LevelColor, _trail.TrailRenderer);
                    SetButtonColors();
                }

                return;
            }

            if (eventData.EventId == EventIds.SwordUnlocked)
            {
                if (ServiceLocator.Instance.GetService<SwordsLevelSystem>().GetIfIsSwordUnlocked(_trail.Id))
                {
                    _lockButton.gameObject.SetActive(false);
                }
                else
                {
                    _lockButton.gameObject.SetActive(true);
                }
            }
        }
    }
}