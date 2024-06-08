using UnityEngine;

namespace Assets.Code.Trails
{
    public class TrailConfiguration
    {
        public readonly TrailId TrailId;
        public readonly string TrailName;
        public readonly string TrailDescription;
        public readonly TrailRenderer TrailRenderer;

        public readonly int Level;
        public readonly int TrailBaseHp;
        public readonly int TrailBaseAttack;
        public readonly float TrailCriticalMultiplier;
        public readonly float TrailCriticalProbability;
        public readonly float TrailExcelentMultiplier;
        public readonly float TrailExcelentProbability;
        public readonly float TrailHpAbsorbProbability;
        public readonly float TrailHpAbsorbDenominator;
        public readonly float TrailMultipleHitsProbability;
        public readonly int TrailNumberOfHits;


        public TrailConfiguration(int level, int trailBaseHp, int trailBaseAttack, float trailCriticalMultiplier,
                                  float trailCriticalProbability, float trailExcelentMultiplier, float trailExcelentProbability,
                                  float trailHpAbsorbProbability, float trailHpAbsorbDenominator, float trailMultipleHitsProbability,
                                  int trailNumberOfHits, TrailId trailId, TrailRenderer trailRenderer)
        {
            Level = level;
            TrailBaseHp = trailBaseHp;
            TrailBaseAttack = trailBaseAttack;
            TrailCriticalMultiplier = trailCriticalMultiplier;
            TrailCriticalProbability = trailCriticalProbability;
            TrailExcelentMultiplier = trailExcelentMultiplier;
            TrailExcelentProbability = trailExcelentProbability;
            TrailHpAbsorbProbability = trailHpAbsorbProbability;
            TrailHpAbsorbDenominator = trailHpAbsorbDenominator;
            TrailMultipleHitsProbability = trailMultipleHitsProbability;
            TrailNumberOfHits = trailNumberOfHits;
            TrailId = trailId;
            TrailRenderer = trailRenderer;
        }
    }
}