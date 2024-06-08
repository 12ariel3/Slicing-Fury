using System;

namespace Assets.Code.Core.DataStorage
{
    [Serializable]
    public class UserData
    {
        public int TotalScore = 0;
        public int TotalGems = 0;
        public float ActualEnergy = 20;
        public float TotalEnergy = 20;
        public int PlayerLevel = 1;
        public int PlayerExp;
        public int PlayerCurrentMaxExp;
        public string SwordEquippedName = "Basic Sword";

        public int BasicSword = 1;
        public int RainBowSword = 1;
        public int BatPierceSword = 1;
        public int AquariusSword = 1;
        public int ThundraSword = 1;
        public int AbsoluteZeroSword = 1;
        public int PlasmaBurstSword = 1;
        public int PyraSword = 1;
        public int SoulSeekerSword = 1;
        public int TerraForceSword = 1;
        public int GaiaSword = 1;


        public bool BasicSwordIsUnlocked = true;
        public bool RainBowSwordIsUnlocked = false;
        public bool BatPierceSwordIsUnlocked = false;
        public bool AquariusSwordIsUnlocked = false;
        public bool ThundraSwordIsUnlocked = false;
        public bool AbsoluteZeroSwordIsUnlocked = false;
        public bool PlasmaBurstSwordIsUnlocked = false;
        public bool PyraSwordIsUnlocked = false;
        public bool SoulSeekerSwordIsUnlocked = false;
        public bool TerraForceSwordIsUnlocked = false;
        public bool GaiaSwordIsUnlocked = false;


        public float UpgradesAttack = 0;
        public float UpgradesHp = 0;
        public float UpgradesCriticalMultiplier = 0;
        public float UpgradesCriticalProbability = 0;
        public float UpgradesExcelentMultiplier = 0;
        public float UpgradesExcelentProbability = 0;
        public float UpgradesHpAbsorbDenominator = 0;
        public float UpgradesHpAbsorbProbability = 0;
        public float UpgradesMultipleHitsProbability = 0;
        public float UpgradesNumberOfHits = 0;
        public float UpgradesEnergy = 0;


        public bool AttackNode0 = false;
        public bool AttackNode1 = false;
        public bool AttackNode2 = false;
        public bool AttackNode3 = false;
        public bool AttackNode4 = false;
        public bool AttackNode5 = false;
        public bool AttackNode6 = false;
        public bool AttackNode7 = false;
        public bool AttackNode8 = false;
        public bool HpNode0 = false;
        public bool HpNode1 = false;
        public bool HpNode2 = false;
        public bool HpNode3 = false;
        public bool HpNode4 = false;
        public bool HpNode5 = false;
        public bool HpNode6 = false;
        public bool HpNode7 = false;
        public bool HpNode8 = false;
        public bool CriticalProbabilityNode0 = false;
        public bool CriticalProbabilityNode1 = false;
        public bool CriticalProbabilityNode2 = false;
        public bool CriticalProbabilityNode3 = false;
        public bool CriticalMultiplierNode0 = false;
        public bool CriticalMultiplierNode1 = false;
        public bool CriticalMultiplierNode2 = false;
        public bool CriticalMultiplierNode3 = false;
        public bool ExcelentProbabilityNode0 = false;
        public bool ExcelentProbabilityNode1 = false;
        public bool ExcelentProbabilityNode2 = false;
        public bool ExcelentProbabilityNode3 = false;
        public bool ExcelentMultiplierNode0 = false;
        public bool ExcelentMultiplierNode1 = false;
        public bool ExcelentMultiplierNode2 = false;
        public bool ExcelentMultiplierNode3 = false;
        public bool HpAbsorbProbabilityNode0 = false;
        public bool HpAbsorbProbabilityNode1 = false;
        public bool HpAbsorbProbabilityNode2 = false;
        public bool HpAbsorbProbabilityNode3 = false;
        public bool HpAbsorbDenominatorNode0 = false;
        public bool HpAbsorbDenominatorNode1 = false;
        public bool HpAbsorbDenominatorNode2 = false;
        public bool HpAbsorbDenominatorNode3 = false;
        public bool MultipleHitsProbabilityNode0 = false;
        public bool MultipleHitsProbabilityNode1 = false;
        public bool MultipleHitsProbabilityNode2 = false;
        public bool MultipleHitsProbabilityNode3 = false;
        public bool MultipleHitsProbabilityNode4 = false;
        public bool MultipleHitsProbabilityNode5 = false;
        public bool NumberOfHitsNode0 = false;
        public bool NumberOfHitsNode1 = false;
        public bool EnergyNode0 = false;
        public bool EnergyNode1 = false;
        public bool EnergyNode2 = false;
        public bool EnergyNode3 = false;
        public bool EnergyNode4 = false;
        public bool EnergyNode5 = false;



        public bool AttackNodeAvailable0 = true;
        public bool AttackNodeAvailable1 = false;
        public bool AttackNodeAvailable2 = false;
        public bool AttackNodeAvailable3 = false;
        public bool AttackNodeAvailable4 = false;
        public bool AttackNodeAvailable5 = false;
        public bool AttackNodeAvailable6 = false;
        public bool AttackNodeAvailable7 = false;
        public bool AttackNodeAvailable8 = false;
        public bool HpNodeAvailable0 = false;
        public bool HpNodeAvailable1 = false;
        public bool HpNodeAvailable2 = false;
        public bool HpNodeAvailable3 = false;
        public bool HpNodeAvailable4 = false;
        public bool HpNodeAvailable5 = false;
        public bool HpNodeAvailable6 = false;
        public bool HpNodeAvailable7 = false;
        public bool HpNodeAvailable8 = false;
        public bool CriticalProbabilityNodeAvailable0 = false;
        public bool CriticalProbabilityNodeAvailable1 = false;
        public bool CriticalProbabilityNodeAvailable2 = false;
        public bool CriticalProbabilityNodeAvailable3 = false;
        public bool CriticalMultiplierNodeAvailable0 = false;
        public bool CriticalMultiplierNodeAvailable1 = false;
        public bool CriticalMultiplierNodeAvailable2 = false;
        public bool CriticalMultiplierNodeAvailable3 = false;
        public bool ExcelentProbabilityNodeAvailable0 = false;
        public bool ExcelentProbabilityNodeAvailable1 = false;
        public bool ExcelentProbabilityNodeAvailable2 = false;
        public bool ExcelentProbabilityNodeAvailable3 = false;
        public bool ExcelentMultiplierNodeAvailable0 = false;
        public bool ExcelentMultiplierNodeAvailable1 = false;
        public bool ExcelentMultiplierNodeAvailable2 = false;
        public bool ExcelentMultiplierNodeAvailable3 = false;
        public bool HpAbsorbProbabilityNodeAvailable0 = false;
        public bool HpAbsorbProbabilityNodeAvailable1 = false;
        public bool HpAbsorbProbabilityNodeAvailable2 = false;
        public bool HpAbsorbProbabilityNodeAvailable3 = false;
        public bool HpAbsorbDenominatorNodeAvailable0 = false;
        public bool HpAbsorbDenominatorNodeAvailable1 = false;
        public bool HpAbsorbDenominatorNodeAvailable2 = false;
        public bool HpAbsorbDenominatorNodeAvailable3 = false;
        public bool MultipleHitsProbabilityNodeAvailable0 = false;
        public bool MultipleHitsProbabilityNodeAvailable1 = false;
        public bool MultipleHitsProbabilityNodeAvailable2 = false;
        public bool MultipleHitsProbabilityNodeAvailable3 = false;
        public bool MultipleHitsProbabilityNodeAvailable4 = false;
        public bool MultipleHitsProbabilityNodeAvailable5 = false;
        public bool NumberOfHitsNodeAvailable0 = false;
        public bool NumberOfHitsNodeAvailable1 = false;
        public bool EnergyNodeAvailable0 = false;
        public bool EnergyNodeAvailable1 = false;
        public bool EnergyNodeAvailable2 = false;
        public bool EnergyNodeAvailable3 = false;
        public bool EnergyNodeAvailable4 = false;
        public bool EnergyNodeAvailable5 = false;



        public string MaxMapReached = "Moon Walker";
        public string LastMapPlayed = "Moon Walker";
        public int MaxLevelReached = 1;
        public int LastLevelPlayed = 1;
        public bool IsNewLevelPlayed = false;
        public bool IsLastMapLevelPlayed = false;
        public bool IsFirstUpdate = false;

        public bool IsMoonWalkerPassed = false;
        public bool IsAtlansAbyssPassed = false;
        public bool IsVillaSoldatiPassed = false;
        public bool IsRaklionPassed = false;
        public bool IsAcheronPassed = false;

        public bool IsGameReviewed = false;
        public bool IsCongratulationsViewed = false;


        public float MainMenuMusicIntensity = .6f;
        public float GameMusicIntensity = .2f;
        public float SwordIntensity = .3f;
        public float ProjectileIntensity = .55f;
        public float SoundIntensity = .6f;
        public bool IsVibrationActived = true;

        public int LastDateEnergyRecovered = 1709678256;

        public bool AdsWereRemoved = false;
    }
}