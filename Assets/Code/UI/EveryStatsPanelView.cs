using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class EveryStatsPanelView : MonoBehaviour, EventObserver
    {
        [SerializeField] RectTransform _panelTransform;
        [SerializeField] private Button _switchButton;
        [SerializeField] private Image _switchIconOpen;
        [SerializeField] private Image _switchIconClose;

        [SerializeField] private TextMeshProUGUI _characterAttack;
        [SerializeField] private TextMeshProUGUI _characterHp;
        [SerializeField] private TextMeshProUGUI _characterCriticalProbability;
        [SerializeField] private TextMeshProUGUI _characterExcelentProbability;
        [SerializeField] private TextMeshProUGUI _characterCriticalDmg;
        [SerializeField] private TextMeshProUGUI _characterExcelentDmg;
        [SerializeField] private TextMeshProUGUI _characterHitProbability;
        [SerializeField] private TextMeshProUGUI _characterNumberOfHits;
        [SerializeField] private TextMeshProUGUI _characterHpAbsorbDenominator;
        [SerializeField] private TextMeshProUGUI _characterHpAbsorbProbability;


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


        [SerializeField] private TextMeshProUGUI _upgradesAttack;
        [SerializeField] private TextMeshProUGUI _upgradesHp;
        [SerializeField] private TextMeshProUGUI _upgradesCriticalProbability;
        [SerializeField] private TextMeshProUGUI _upgradesExcelentProbability;
        [SerializeField] private TextMeshProUGUI _upgradesCriticalDmg;
        [SerializeField] private TextMeshProUGUI _upgradesExcelentDmg;
        [SerializeField] private TextMeshProUGUI _upgradesHitProbability;
        [SerializeField] private TextMeshProUGUI _upgradesNumberOfHits;
        [SerializeField] private TextMeshProUGUI _upgradesHpAbsorbDenominator;
        [SerializeField] private TextMeshProUGUI _upgradesHpAbsorbProbability;

        private bool _isOpened;

        private void Awake()
        {
            _switchButton.onClick.AddListener(SwitchPanel);
            _switchIconClose.gameObject.SetActive(false);
        }


        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.PlayerSendEveryStatsValue, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.PlayerSendEveryStatsValue, this);
        }


        private void SwitchPanel()
        {
            if (_isOpened)
            {
                StartCoroutine(Move(_panelTransform, new Vector2(-700, 0)));
                _switchIconClose.gameObject.SetActive(false);
                _switchIconOpen.gameObject.SetActive(true);
                _isOpened = false;
            }
            else
            {
                StartCoroutine(Move(_panelTransform, new Vector2(0, 0)));
                _switchIconClose.gameObject.SetActive(true);
                _switchIconOpen.gameObject.SetActive(false);
                _isOpened = true;
            }
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
        }


        private void SetEveryStat(int characterAttackValue, int characterHpValue, float characterCriticalMultiplier,
                                  float characterCriticalProbability, float characterExcelentMultiplier,
                                  float characterExcelentProbability, float characterHpAbsorbProbability,
                                  float characterHpAbsorbDenominator, float characterMultipleHitsProbability, int characterNumberOfHits,

                                  int swordAttackValue, int swordHpValue, float swordCriticalMultiplier, float swordCriticalProbability,
                                  float swordExcelentMultiplier, float swordExcelentProbability, float swordHpAbsorbProbability,
                                  float swordHpAbsorbDenominator, float swordMultipleHitsProbability, int swordNumberOfHits,

                                  float upgradesAttackValue, float upgradesHpValue, float upgradesCriticalMultiplier,
                                  float upgradesCriticalProbability, float upgradesExcelentMultiplier,
                                  float upgradesExcelentProbability, float upgradesHpAbsorbProbability,
                                  float upgradesHpAbsorbDenominator, float upgradesMultipleHitsProbability, float upgradesNumberOfHits)
        {
            _characterAttack.SetText(characterAttackValue.ToString());
            _characterHp.SetText(characterHpValue.ToString());
            _characterCriticalDmg.SetText(characterCriticalMultiplier.ToString("f1"));
            _characterCriticalProbability.SetText(characterCriticalProbability.ToString("f1") + " %");
            _characterExcelentDmg.SetText(characterExcelentMultiplier.ToString("f1"));
            _characterExcelentProbability.SetText(characterExcelentProbability.ToString("f1") + " %");
            _characterHpAbsorbProbability.SetText(characterHpAbsorbProbability.ToString("f1") + " %");
            _characterHpAbsorbDenominator.SetText(characterHpAbsorbDenominator.ToString("f1"));
            _characterHitProbability.SetText(characterMultipleHitsProbability.ToString("f1") + " %");
            _characterNumberOfHits.SetText(characterNumberOfHits.ToString());

            _swordAttack.SetText(swordAttackValue.ToString());
            _swordHp.SetText(swordHpValue.ToString());
            _swordCriticalDmg.SetText(swordCriticalMultiplier.ToString("f1"));
            _swordCriticalProbability.SetText(swordCriticalProbability.ToString("f1") + " %");
            _swordExcelentDmg.SetText(swordExcelentMultiplier.ToString("f1"));
            _swordExcelentProbability.SetText(swordExcelentProbability.ToString("f1") + " %");
            _swordHpAbsorbProbability.SetText(swordHpAbsorbProbability.ToString("f1") + " %");
            _swordHpAbsorbDenominator.SetText(swordHpAbsorbDenominator.ToString("f1"));
            _swordHitProbability.SetText(swordMultipleHitsProbability.ToString("f1") + "  %");
            _swordNumberOfHits.SetText(swordNumberOfHits.ToString());

            _upgradesAttack.SetText(upgradesAttackValue.ToString());
            _upgradesHp.SetText(upgradesHpValue.ToString());
            _upgradesCriticalDmg.SetText(upgradesCriticalMultiplier.ToString("f1"));
            _upgradesCriticalProbability.SetText(upgradesCriticalProbability.ToString("f1") + " %");
            _upgradesExcelentDmg.SetText(upgradesExcelentMultiplier.ToString("f1"));
            _upgradesExcelentProbability.SetText(upgradesExcelentProbability.ToString("f1") + " %");
            _upgradesHpAbsorbProbability.SetText(upgradesHpAbsorbProbability.ToString("f1") + "  %");
            _upgradesHpAbsorbDenominator.SetText(upgradesHpAbsorbDenominator.ToString("f1"));
            _upgradesHitProbability.SetText(upgradesMultipleHitsProbability.ToString("f1") + " %");
            _upgradesNumberOfHits.SetText(upgradesNumberOfHits.ToString());
        }



        IEnumerator Move(RectTransform rt, Vector2 targetPos)
        {
            float step = 0;
            while (step < 1)
            {
                rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime);
                rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PlayerSendEveryStatsValue)
            {
                var playerStat = (playerSendEveryStatsEventData)eventData;

                SetEveryStat(playerStat.CharacterAttackValue, playerStat.CharacterHpValue, playerStat.CharacterCriticalMultiplier,
                         playerStat.CharacterCriticalProbability, playerStat.CharacterExcelentMultiplier, playerStat.CharacterExcelentProbability,
                         playerStat.CharacterHpAbsorbProbability, playerStat.CharacterHpAbsorbDenominator, playerStat.CharacterMultipleHitsProbability,
                         playerStat.CharacterNumberOfHits,

                         playerStat.SwordAttackValue, playerStat.SwordHpValue, playerStat.SwordCriticalMultiplier, playerStat.SwordCriticalProbability,
                         playerStat.SwordExcelentMultiplier, playerStat.SwordExcelentProbability, playerStat.SwordHpAbsorbProbability,
                         playerStat.SwordHpAbsorbDenominator, playerStat.SwordMultipleHitsProbability, playerStat.SwordNumberOfHits,

                         playerStat.UpgradesAttackValue, playerStat.UpgradesHpValue, playerStat.UpgradesCriticalMultiplier,
                         playerStat.UpgradesCriticalProbability, playerStat.UpgradesExcelentMultiplier, playerStat.UpgradesExcelentProbability,
                         playerStat.UpgradesHpAbsorbProbability, playerStat.UpgradesHpAbsorbDenominator, playerStat.UpgradesMultipleHitsProbability,
                         playerStat.UpgradesNumberOfHits);
            }
        }
    }
}