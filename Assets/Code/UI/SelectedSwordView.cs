using Assets.Code.Common.Events;
using Assets.Code.Common.Score;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class SelectedSwordView : MonoBehaviour
    {

        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private TextMeshProUGUI _upgradeButtonValue;
        [SerializeField] private Button _equipButton;

        [SerializeField] private Image _swordImage;
        [SerializeField] private TextMeshProUGUI _swordName;
        [SerializeField] private TextMeshProUGUI _swordLevel;
        [SerializeField] private TextMeshProUGUI _swordAttack;
        [SerializeField] private TextMeshProUGUI _swordHp;
        [SerializeField] private TextMeshProUGUI _swordCriticalProbability;
        [SerializeField] private TextMeshProUGUI _swordExcelentProbability;
        [SerializeField] private TextMeshProUGUI _swordCriticalDmg;
        [SerializeField] private TextMeshProUGUI _swordExcelentDmg;
        [SerializeField] private TextMeshProUGUI _swordHitProbability;
        [SerializeField] private TextMeshProUGUI _swordNumberOfHits;
        [SerializeField] private TextMeshProUGUI _swordHpAbsorbDenominator;
        [SerializeField] private TextMeshProUGUI _swordHpAbsorbProbability;
        [SerializeField] private Image _swordDeepBackground;
        [SerializeField] private Image _swordBackground;
        [SerializeField] private Image _swordIconBackground;



        private TrailRenderer _trailRenderer;
        private Sprite _swordSprite;
        private int _upgradeValue;
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


        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
            _upgradeButton.onClick.AddListener(OnUpgradeButtonPressed);
            _equipButton.onClick.AddListener(OnEquipButtonPressed);
        }

        private void OnEquipButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Equip");
            ServiceLocator.Instance.GetService<SwordEquippedSystem>().SaveSwordEquipped(_id);
            SetSelectedSword();
            ActiveEquippedPopUp();
            OnCloseButtonPressed();
        }

        private void ActiveEquippedPopUp()
        {
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.ActiveSwordEquippedPopUp));
        }

        private void SetSelectedSword()
        {
            var swordEquipedEventData = new SwordEquipedEventData(_swordSprite, _upgradeValue, _id, _level, _attack, _hp, _criticalProbability,
                                                                  _excelentProbability, _criticalMultiplier, _excelentMultiplier,
                                                                  _multipleHitsProbability, _numberOfHits, _hpAbsorbDenominator,
                                                                  _hpAbsorbProbability, _deepBackground, _background, _iconBackground,
                                                                  _nameColor, _levelColor, _trailRenderer, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(swordEquipedEventData);
        }

        private void OnUpgradeButtonPressed()
        {
            if(_level < 100)
            {
                int _totalScore = ServiceLocator.Instance.GetService<ScoreSystem>().GetTotalScore();
                if (_totalScore >= _upgradeValue)
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Upgrade");
                    int newScore = _totalScore - _upgradeValue;
                    ServiceLocator.Instance.GetService<ScoreSystem>().SaveTotalScore(newScore);
                    ServiceLocator.Instance.GetService<ScoreView>().UpdateScore(newScore);
                    _level++;
                    var swordLevelUpEventData = new SwordLevelUpEventData(_id, _level, GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(swordLevelUpEventData);

                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.UpgradesLevelUpPopUpSpawn));
                    if(_level >= 100)
                    {
                        _upgradeButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
                    var NotEnoughEventData = new NotEnoughEventData("Score", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
                }
            }
        }

        private void OnCloseButtonPressed()
        {
            Hide();
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void HideFirst()
        {
            gameObject.SetActive(false);
        }

        public void SetStadistics(Sprite swordSprite, int swordUpgradeValue, string swordName, int swordLevel, int swordAttack, int swordHp, float swordCriticalProbability,
                                  float swordExcelentProbability, float swordCriticalDmg, float swordExcelentDmg, float swordHitProbability,
                                  int swordNumberOfHits, float swordHpAbsorbDenominator, float swordHpAbsorbProbability, Color deepBackground,
                                  Color background, Color iconBackground, Color nameColor, Color levelColor, TrailRenderer trailRenderer)
        {

            if (ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped() == swordName)
            {
                _equipButton.gameObject.SetActive(false);
            }
            else
            {
                _equipButton.gameObject.SetActive(true);
            }

            _swordSprite = swordSprite;
            _upgradeValue = swordUpgradeValue;
            _id = swordName;
            _level = swordLevel;
            _attack = swordAttack;
            _hp = swordHp;
            _criticalProbability = swordCriticalProbability;
            _excelentProbability = swordExcelentProbability;
            _criticalMultiplier = swordCriticalDmg;
            _excelentMultiplier = swordExcelentDmg;
            _multipleHitsProbability = swordHitProbability;
            _numberOfHits = swordNumberOfHits;
            _hpAbsorbDenominator = swordHpAbsorbDenominator;
            _hpAbsorbProbability = swordHpAbsorbProbability;
            _deepBackground = deepBackground;
            _background = background;
            _iconBackground = iconBackground;
            _nameColor = nameColor;
            _levelColor = levelColor;
            _trailRenderer = trailRenderer;


            _swordImage.sprite = _swordSprite;
            _upgradeButtonValue.SetText(_upgradeValue.ToString());
            _swordName.SetText(_id);
            _nameColor.a = 1;
            _swordName.color = _nameColor;
            _swordLevel.SetText(_level.ToString());
            _levelColor.a = 1;
            _swordLevel.color = _levelColor;
            _swordAttack.SetText(_attack.ToString());
            _swordHp.SetText(_hp.ToString());
            _swordCriticalProbability.SetText(_criticalProbability.ToString("f1") + " %");
            _swordExcelentProbability.SetText(_excelentProbability.ToString("f1") + " %");
            _swordCriticalDmg.SetText(_criticalMultiplier.ToString("f1"));
            _swordExcelentDmg.SetText(_excelentMultiplier.ToString("f1"));
            _swordHitProbability.SetText(_multipleHitsProbability.ToString("f1") + " %");
            _swordNumberOfHits.SetText(_numberOfHits.ToString());
            _swordHpAbsorbDenominator.SetText(_hpAbsorbDenominator.ToString("f1"));
            _swordHpAbsorbProbability.SetText(_hpAbsorbProbability.ToString("f1") + " %");
            _deepBackground.a = 1;
            _swordDeepBackground.color = _deepBackground;
            _background.a = 1;
            _swordBackground.color = _background;
            _iconBackground.a = 1;
            _swordIconBackground.color = _iconBackground;

            if(_level >= 100)
            {
                _upgradeButton.gameObject.SetActive(false);
            }
            else
            {
                _upgradeButton.gameObject.SetActive(true);
            }
        }
    }
}