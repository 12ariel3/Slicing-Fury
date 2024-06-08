using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerConfiguration
    {

        public readonly PlayerId PlayerId;
        public readonly TrailRenderer TrailRenderer;

        //Player base stats
        public readonly int Level;
        public readonly int BaseHp;
        public readonly int BaseAttack;
        public readonly float BaseCriticalMultiplier;
        public readonly float BaseCriticalProbability;
        public readonly float BaseExcelentMultiplier;
        public readonly float BaseExcelentProbability;
        public readonly float BaseHpAbsorbProbability;
        public readonly float BaseHpAbsorbDenominator;
        public readonly float BaseMultipleHitsProbability;
        public readonly int BaseNumberOfHits;

        //Trail stats
        public readonly string TrailId;
        public readonly int TrailAttack;
        public readonly int TrailHp;
        public readonly float TrailCriticalMultiplier;
        public readonly float TrailCriticalProbability;
        public readonly float TrailExcelentMultiplier;
        public readonly float TrailExcelentProbability;
        public readonly float TrailHpAbsorbDenominator;
        public readonly float TrailHpAbsorbProbability;
        public readonly float TrailMultipleHitsProbability;
        public readonly int TrailNumberOfHits;
        public readonly TrailRenderer TrailTrailRenderer;

        //Upgrades stats
        public readonly float UpgradesAttack;
        public readonly float UpgradesHp;
        public readonly float UpgradesCriticalMultiplier;
        public readonly float UpgradesCriticalProbability;
        public readonly float UpgradesExcelentMultiplier;
        public readonly float UpgradesExcelentProbability;
        public readonly float UpgradesHpAbsorbDenominator;
        public readonly float UpgradesHpAbsorbProbability;
        public readonly float UpgradesMultipleHitsProbability;
        public readonly float UpgradesNumberOfHits;



        public PlayerConfiguration(int level, int baseHp, int baseAttack,
                                   float baseCriticalMultiplier, float baseCriticalProbability, float baseExcelentMultiplier,
                                   float baseExcelentProbability, float basehpAbsorbProbability, float baseHpAbsorbDenominator,
                                   float baseMultipleHitsProbability, int baseNumberOfHits, PlayerId playerId, TrailRenderer trailRenderer,


                                   string trailId, int trailHp, int trailAttack,
                                   float trailCriticalMultiplier, float trailCriticalProbability, float trailExcelentMultiplier,
                                   float trailExcelentProbability, float trailHpAbsorbProbability, float trailHpAbsorbDenominator,
                                   float trailMultipleHitsProbability, int trailNumberOfHits, TrailRenderer trailTrailRenderer,


                                   float upgradesHp, float upgradesAttack,
                                   float upgradesCriticalMultiplier, float upgradesCriticalProbability, float upgradesExcelentMultiplier,
                                   float upgradesExcelentProbability, float upgradesHpAbsorbProbability, float upgradesHpAbsorbDenominator,
                                   float upgradesMultipleHitsProbability, float upgradesNumberOfHits)
        {
            Level = level;
            BaseHp = baseHp;
            BaseAttack = baseAttack;
            BaseCriticalMultiplier = baseCriticalMultiplier;
            BaseCriticalProbability = baseCriticalProbability;
            BaseExcelentMultiplier = baseExcelentMultiplier;
            BaseExcelentProbability = baseExcelentProbability;
            BaseHpAbsorbProbability = basehpAbsorbProbability;
            BaseHpAbsorbDenominator = baseHpAbsorbDenominator;
            BaseMultipleHitsProbability = baseMultipleHitsProbability;
            BaseNumberOfHits = baseNumberOfHits;
            PlayerId = playerId;
            TrailRenderer = trailRenderer;


            TrailId = trailId;
            TrailHp = trailHp;
            TrailAttack = trailAttack;
            TrailCriticalMultiplier = trailCriticalMultiplier;
            TrailCriticalProbability = trailCriticalProbability;
            TrailExcelentMultiplier = trailExcelentMultiplier;
            TrailExcelentProbability = trailExcelentProbability;
            TrailHpAbsorbProbability = trailHpAbsorbProbability;
            TrailHpAbsorbDenominator = trailHpAbsorbDenominator;
            TrailMultipleHitsProbability = trailMultipleHitsProbability;
            TrailNumberOfHits = trailNumberOfHits;
            TrailTrailRenderer = trailTrailRenderer;
            
            
            UpgradesHp = upgradesHp;
            UpgradesAttack = upgradesAttack;
            UpgradesCriticalMultiplier = upgradesCriticalMultiplier;
            UpgradesCriticalProbability = upgradesCriticalProbability;
            UpgradesExcelentMultiplier = upgradesExcelentMultiplier;
            UpgradesExcelentProbability = upgradesExcelentProbability;
            UpgradesHpAbsorbProbability = upgradesHpAbsorbProbability;
            UpgradesHpAbsorbDenominator = upgradesHpAbsorbDenominator;
            UpgradesMultipleHitsProbability = upgradesMultipleHitsProbability;
            UpgradesNumberOfHits = upgradesNumberOfHits;
        }
    }
}