using Assets.Code.Common.Events;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class EquipedSwordView : MonoBehaviour, EventObserver
    {
        [SerializeField] private Image _swordImage;
        [SerializeField] private TextMeshProUGUI _swordName;
        [SerializeField] private TextMeshProUGUI _swordLevel;
        [SerializeField] private Image _swordDeepBackground;
        [SerializeField] private Image _swordBackground;
        [SerializeField] private Image _swordIconBackground;

        [SerializeField] private Button _swordButton;
        [SerializeField] private SelectedSwordView _selectedSwordView;


        private Sprite _swordSprite;
        private int _swordUpgradeValue;
        private string _id;
        private int _level;
        private int _attack;
        private int _hp;
        private float _criticalProbability;
        private float _excelentProbability;
        private float _criticalMultiplier;
        private float _excelentMultiplier;
        private float _multipleHitsProbability;
        private int _numberOfHits;
        private float _hpAbsorbDenominator;
        private float _hpAbsorbProbability;
        private Color _deepBackground;
        private Color _background;
        private Color _iconBackground;
        private Color _nameColor;
        private Color _levelColor;
        private TrailRenderer _trailRenderer;


        private void Awake()
        {
            _swordButton.onClick.AddListener(ShowSelectedSwordView);
        }

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.SwordEquiped, this);
            eventQueue.Subscribe(EventIds.SwordEquippedLevelUp, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.SwordEquiped, this);
            eventQueue.Unsubscribe(EventIds.SwordEquippedLevelUp, this);
        }


        private void SetEquipedSwordStats()
        {
            _swordImage.sprite = _swordSprite;
            _swordName.SetText(_id);
            _swordName.color = _nameColor;
            _swordLevel.SetText(_level.ToString());
            _swordLevel.color = _levelColor;
            _swordDeepBackground.color = _deepBackground;
            _swordBackground.color = _background;
            _swordIconBackground.color = _iconBackground;
        }


        private void ShowSelectedSwordView()
        {
            _selectedSwordView.SetStadistics(_swordSprite, _swordUpgradeValue, _id, _level, _attack, _hp, _criticalProbability, _excelentProbability,
                                             _criticalMultiplier, _excelentMultiplier, _multipleHitsProbability, _numberOfHits,
                                             _hpAbsorbDenominator, _hpAbsorbProbability, _deepBackground, _background,
                                             _iconBackground, _nameColor, _levelColor, _trailRenderer);
            _selectedSwordView.Show();
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.SwordEquiped)
            {
                var swordEquipedEventData = (SwordEquipedEventData)eventData;

                _swordSprite = swordEquipedEventData._swordSprite;
                _swordUpgradeValue = swordEquipedEventData._swordUpgradeValue;
                _id = swordEquipedEventData._id;
                _level = swordEquipedEventData._level;
                _attack = swordEquipedEventData._attack;
                _hp = swordEquipedEventData._hp;
                _criticalProbability = swordEquipedEventData._criticalProbability;
                _excelentProbability = swordEquipedEventData._excelentProbability;
                _criticalMultiplier = swordEquipedEventData._criticalMultiplier;
                _excelentMultiplier = swordEquipedEventData._excelentMultiplier;
                _multipleHitsProbability = swordEquipedEventData._multipleHitsProbability;
                _numberOfHits = swordEquipedEventData._numberOfHits;
                _hpAbsorbDenominator = swordEquipedEventData._hpAbsorbDenominator;
                _hpAbsorbProbability = swordEquipedEventData._hpAbsorbProbability;
                _deepBackground = swordEquipedEventData._deepBackground;
                _deepBackground.a = 1;
                _background = swordEquipedEventData._background;
                _background.a = 1;
                _iconBackground = swordEquipedEventData._iconBackground;
                _iconBackground.a = 1;
                _nameColor = swordEquipedEventData._nameColor;
                _nameColor.a = 1;
                _levelColor = swordEquipedEventData._levelColor;
                _levelColor.a = 1;
                _trailRenderer = swordEquipedEventData._trailRenderer;

                SetEquipedSwordStats();

                return;
            }



            if (eventData.EventId == EventIds.SwordEquippedLevelUp)
            {
                var swordEquippedLevelUpEventData = (SwordEquippedLevelUpEventData)eventData;
                if (ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped() == swordEquippedLevelUpEventData.Id)
                {
                    _swordUpgradeValue = swordEquippedLevelUpEventData.TrailUpgradeValue;
                    _id = swordEquippedLevelUpEventData.Id;
                    _level = swordEquippedLevelUpEventData.Level;
                    _attack = swordEquippedLevelUpEventData.Attack;
                    _hp = swordEquippedLevelUpEventData.Hp;
                    _criticalProbability = swordEquippedLevelUpEventData.CriticalProbability;
                    _excelentProbability = swordEquippedLevelUpEventData.ExcelentProbability;
                    _criticalMultiplier = swordEquippedLevelUpEventData.CriticalMultiplier;
                    _excelentMultiplier = swordEquippedLevelUpEventData.ExcelentMultiplier;
                    _multipleHitsProbability = swordEquippedLevelUpEventData.MultipleHitsProbability;
                    _numberOfHits = swordEquippedLevelUpEventData.NumberOfHits;
                    _hpAbsorbDenominator = swordEquippedLevelUpEventData.HpAbsorbDenominator;
                    _hpAbsorbProbability = swordEquippedLevelUpEventData.HpAbsorbProbability;

                    SetEquipedSwordStats();
                }
            }
        }
    }
}