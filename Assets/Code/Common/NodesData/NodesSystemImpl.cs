using Assets.Code.Core.DataStorage;

namespace Assets.Code.Common.NodesData
{
    public class NodesSystemImpl : NodesSystem
    {
        private readonly DataStore _dataStore;



        public NodesSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
        }
       
        
        public bool GetNodeActivation(string nodeName)
        {
            var userData = _dataStore.GetData<UserData>(nodeName)
                        ?? new UserData();
            switch (nodeName)
            {
                case "Attack0":
                    return userData.AttackNode0;

                case "Attack1":
                    return userData.AttackNode1;

                case "Attack2":
                    return userData.AttackNode2;

                case "Attack3":
                    return userData.AttackNode3;

                case "Attack4":
                    return userData.AttackNode4;

                case "Attack5":
                    return userData.AttackNode5;

                case "Attack6":
                    return userData.AttackNode6;

                case "Attack7":
                    return userData.AttackNode7;

                case "Attack8":
                    return userData.AttackNode8;

                case "Hp0":
                    return userData.HpNode0;

                case "Hp1":
                    return userData.HpNode1;

                case "Hp2":
                    return userData.HpNode2;

                case "Hp3":
                    return userData.HpNode3;

                case "Hp4":
                    return userData.HpNode4;

                case "Hp5":
                    return userData.HpNode5;

                case "Hp6":
                    return userData.HpNode6;

                case "Hp7":
                    return userData.HpNode7;

                case "Hp8":
                    return userData.HpNode8;

                case "CriticalProbability0":
                    return userData.CriticalProbabilityNode0;

                case "CriticalProbability1":
                    return userData.CriticalProbabilityNode1;

                case "CriticalProbability2":
                    return userData.CriticalProbabilityNode2;

                case "CriticalProbability3":
                    return userData.CriticalProbabilityNode3;

                case "CriticalMultiplier0":
                    return userData.CriticalMultiplierNode0;

                case "CriticalMultiplier1":
                    return userData.CriticalMultiplierNode1;

                case "CriticalMultiplier2":
                    return userData.CriticalMultiplierNode2;

                case "CriticalMultiplier3":
                    return userData.CriticalMultiplierNode3;

                case "ExcelentProbability0":
                    return userData.ExcelentProbabilityNode0;

                case "ExcelentProbability1":
                    return userData.ExcelentProbabilityNode1;

                case "ExcelentProbability2":
                    return userData.ExcelentProbabilityNode2;

                case "ExcelentProbability3":
                    return userData.ExcelentProbabilityNode3;

                case "ExcelentMultiplier0":
                    return userData.ExcelentMultiplierNode0;

                case "ExcelentMultiplier1":
                    return userData.ExcelentMultiplierNode1;

                case "ExcelentMultiplier2":
                    return userData.ExcelentMultiplierNode2;

                case "ExcelentMultiplier3":
                    return userData.ExcelentMultiplierNode3;

                case "HpAbsorbProbability0":
                    return userData.HpAbsorbProbabilityNode0;

                case "HpAbsorbProbability1":
                    return userData.HpAbsorbProbabilityNode1;

                case "HpAbsorbProbability2":
                    return userData.HpAbsorbProbabilityNode2;

                case "HpAbsorbProbability3":
                    return userData.HpAbsorbProbabilityNode3;

                case "HpAbsorbDenominator0":
                    return userData.HpAbsorbDenominatorNode0;

                case "HpAbsorbDenominator1":
                    return userData.HpAbsorbDenominatorNode1;

                case "HpAbsorbDenominator2":
                    return userData.HpAbsorbDenominatorNode2;

                case "HpAbsorbDenominator3":
                    return userData.HpAbsorbDenominatorNode3;

                case "MultipleHitsProbability0":
                    return userData.MultipleHitsProbabilityNode0;

                case "MultipleHitsProbability1":
                    return userData.MultipleHitsProbabilityNode1;

                case "MultipleHitsProbability2":
                    return userData.MultipleHitsProbabilityNode2;

                case "MultipleHitsProbability3":
                    return userData.MultipleHitsProbabilityNode3;

                case "MultipleHitsProbability4":
                    return userData.MultipleHitsProbabilityNode4;

                case "MultipleHitsProbability5":
                    return userData.MultipleHitsProbabilityNode5;

                case "NumberOfHits0":
                    return userData.NumberOfHitsNode0;

                case "NumberOfHits1":
                    return userData.NumberOfHitsNode1;

                case "Energy0":
                    return userData.EnergyNode0;

                case "Energy1":
                    return userData.EnergyNode1;

                case "Energy2":
                    return userData.EnergyNode2;

                case "Energy3":
                    return userData.EnergyNode3;

                case "Energy4":
                    return userData.EnergyNode4;

                case "Energy5":
                    return userData.EnergyNode5;
                default: return false;
            }
        }

        public bool GetNodeAvailability(string nodeAvailableName)
        {
            var userData = _dataStore.GetData<UserData>(nodeAvailableName)
                        ?? new UserData();
            switch (nodeAvailableName)
            {
                case "AttackAvailable0":
                    return userData.AttackNodeAvailable0;

                case "AttackAvailable1":
                    return userData.AttackNodeAvailable1;

                case "AttackAvailable2":
                    return userData.AttackNodeAvailable2;

                case "AttackAvailable3":
                    return userData.AttackNodeAvailable3;

                case "AttackAvailable4":
                    return userData.AttackNodeAvailable4;

                case "AttackAvailable5":
                    return userData.AttackNodeAvailable5;

                case "AttackAvailable6":
                    return userData.AttackNodeAvailable6;

                case "AttackAvailable7":
                    return userData.AttackNodeAvailable7;

                case "AttackAvailable8":
                    return userData.AttackNodeAvailable8;

                case "HpAvailable0":
                    return userData.HpNodeAvailable0;

                case "HpAvailable1":
                    return userData.HpNodeAvailable1;

                case "HpAvailable2":
                    return userData.HpNodeAvailable2;

                case "HpAvailable3":
                    return userData.HpNodeAvailable3;

                case "HpAvailable4":
                    return userData.HpNodeAvailable4;

                case "HpAvailable5":
                    return userData.HpNodeAvailable5;

                case "HpAvailable6":
                    return userData.HpNodeAvailable6;

                case "HpAvailable7":
                    return userData.HpNodeAvailable7;

                case "HpAvailable8":
                    return userData.HpNodeAvailable8;

                case "CriticalProbabilityAvailable0":
                    return userData.CriticalProbabilityNodeAvailable0;

                case "CriticalProbabilityAvailable1":
                    return userData.CriticalProbabilityNodeAvailable1;

                case "CriticalProbabilityAvailable2":
                    return userData.CriticalProbabilityNodeAvailable2;

                case "CriticalProbabilityAvailable3":
                    return userData.CriticalProbabilityNodeAvailable3;

                case "CriticalMultiplierAvailable0":
                    return userData.CriticalMultiplierNodeAvailable0;

                case "CriticalMultiplierAvailable1":
                    return userData.CriticalMultiplierNodeAvailable1;

                case "CriticalMultiplierAvailable2":
                    return userData.CriticalMultiplierNodeAvailable2;

                case "CriticalMultiplierAvailable3":
                    return userData.CriticalMultiplierNodeAvailable3;

                case "ExcelentProbabilityAvailable0":
                    return userData.ExcelentProbabilityNodeAvailable0;

                case "ExcelentProbabilityAvailable1":
                    return userData.ExcelentProbabilityNodeAvailable1;

                case "ExcelentProbabilityAvailable2":
                    return userData.ExcelentProbabilityNodeAvailable2;

                case "ExcelentProbabilityAvailable3":
                    return userData.ExcelentProbabilityNodeAvailable3;

                case "ExcelentMultiplierAvailable0":
                    return userData.ExcelentMultiplierNodeAvailable0;

                case "ExcelentMultiplierAvailable1":
                    return userData.ExcelentMultiplierNodeAvailable1;

                case "ExcelentMultiplierAvailable2":
                    return userData.ExcelentMultiplierNodeAvailable2;

                case "ExcelentMultiplierAvailable3":
                    return userData.ExcelentMultiplierNodeAvailable3;

                case "HpAbsorbProbabilityAvailable0":
                    return userData.HpAbsorbProbabilityNodeAvailable0;

                case "HpAbsorbProbabilityAvailable1":
                    return userData.HpAbsorbProbabilityNodeAvailable1;

                case "HpAbsorbProbabilityAvailable2":
                    return userData.HpAbsorbProbabilityNodeAvailable2;

                case "HpAbsorbProbabilityAvailable3":
                    return userData.HpAbsorbProbabilityNodeAvailable3;

                case "HpAbsorbDenominatorAvailable0":
                    return userData.HpAbsorbDenominatorNodeAvailable0;

                case "HpAbsorbDenominatorAvailable1":
                    return userData.HpAbsorbDenominatorNodeAvailable1;

                case "HpAbsorbDenominatorAvailable2":
                    return userData.HpAbsorbDenominatorNodeAvailable2;

                case "HpAbsorbDenominatorAvailable3":
                    return userData.HpAbsorbDenominatorNodeAvailable3;

                case "MultipleHitsProbabilityAvailable0":
                    return userData.MultipleHitsProbabilityNodeAvailable0;

                case "MultipleHitsProbabilityAvailable1":
                    return userData.MultipleHitsProbabilityNodeAvailable1;

                case "MultipleHitsProbabilityAvailable2":
                    return userData.MultipleHitsProbabilityNodeAvailable2;

                case "MultipleHitsProbabilityAvailable3":
                    return userData.MultipleHitsProbabilityNodeAvailable3;

                case "MultipleHitsProbabilityAvailable4":
                    return userData.MultipleHitsProbabilityNodeAvailable4;

                case "MultipleHitsProbabilityAvailable5":
                    return userData.MultipleHitsProbabilityNodeAvailable5;

                case "NumberOfHitsAvailable0":
                    return userData.NumberOfHitsNodeAvailable0;

                case "NumberOfHitsAvailable1":
                    return userData.NumberOfHitsNodeAvailable1;

                case "EnergyAvailable0":
                    return userData.EnergyNodeAvailable0;

                case "EnergyAvailable1":
                    return userData.EnergyNodeAvailable1;

                case "EnergyAvailable2":
                    return userData.EnergyNodeAvailable2;

                case "EnergyAvailable3":
                    return userData.EnergyNodeAvailable3;

                case "EnergyAvailable4":
                    return userData.EnergyNodeAvailable4;

                case "EnergyAvailable5":
                    return userData.EnergyNodeAvailable5;
                default: return false;
            }
        }


        public void SaveNodeActivation(string nodeName, bool isActived)
        {
            switch (nodeName)
            {
                case "Attack0":
                    var userData = new UserData { AttackNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Attack1":
                    userData = new UserData { AttackNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Attack2":
                    userData = new UserData { AttackNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Attack3":
                    userData = new UserData { AttackNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Attack4":
                    userData = new UserData { AttackNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Attack5":
                    userData = new UserData { AttackNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Attack6":
                    userData = new UserData { AttackNode6 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Attack7":
                    userData = new UserData { AttackNode7 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Attack8":
                    userData = new UserData { AttackNode8 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp0":
                    userData = new UserData { HpNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp1":
                    userData = new UserData { HpNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp2":
                    userData = new UserData { HpNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp3":
                    userData = new UserData { HpNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp4":
                    userData = new UserData { HpNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp5":
                    userData = new UserData { HpNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp6":
                    userData = new UserData { HpNode6 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp7":
                    userData = new UserData { HpNode7 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp8":
                    userData = new UserData { HpNode8 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "CriticalProbability0":
                    userData = new UserData { CriticalProbabilityNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "CriticalProbability1":
                    userData = new UserData { CriticalProbabilityNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "CriticalProbability2":
                    userData = new UserData { CriticalProbabilityNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "CriticalProbability3":
                    userData = new UserData { CriticalProbabilityNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "CriticalMultiplier0":
                    userData = new UserData { CriticalMultiplierNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "CriticalMultiplier1":
                    userData = new UserData { CriticalMultiplierNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "CriticalMultiplier2":
                    userData = new UserData { CriticalMultiplierNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "CriticalMultiplier3":
                    userData = new UserData { CriticalMultiplierNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "ExcelentProbability0":
                    userData = new UserData { ExcelentProbabilityNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "ExcelentProbability1":
                    userData = new UserData { ExcelentProbabilityNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "ExcelentProbability2":
                    userData = new UserData { ExcelentProbabilityNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "ExcelentProbability3":
                    userData = new UserData { ExcelentProbabilityNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "ExcelentMultiplier0":
                    userData = new UserData { ExcelentMultiplierNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "ExcelentMultiplier1":
                    userData = new UserData { ExcelentMultiplierNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "ExcelentMultiplier2":
                    userData = new UserData { ExcelentMultiplierNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "ExcelentMultiplier3":
                    userData = new UserData { ExcelentMultiplierNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "HpAbsorbProbability0":
                    userData = new UserData { HpAbsorbProbabilityNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "HpAbsorbProbability1":
                    userData = new UserData { HpAbsorbProbabilityNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "HpAbsorbProbability2":
                    userData = new UserData { HpAbsorbProbabilityNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "HpAbsorbProbability3":
                    userData = new UserData { HpAbsorbProbabilityNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "HpAbsorbDenominator0":
                    userData = new UserData { HpAbsorbDenominatorNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "HpAbsorbDenominator1":
                    userData = new UserData { HpAbsorbDenominatorNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "HpAbsorbDenominator2":
                    userData = new UserData { HpAbsorbDenominatorNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "HpAbsorbDenominator3":
                    userData = new UserData { HpAbsorbDenominatorNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "MultipleHitsProbability0":
                    userData = new UserData { MultipleHitsProbabilityNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;
                case "MultipleHitsProbability1":
                    userData = new UserData { MultipleHitsProbabilityNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "MultipleHitsProbability2":
                    userData = new UserData { MultipleHitsProbabilityNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "MultipleHitsProbability3":
                    userData = new UserData { MultipleHitsProbabilityNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "MultipleHitsProbability4":
                    userData = new UserData { MultipleHitsProbabilityNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "MultipleHitsProbability5":
                    userData = new UserData { MultipleHitsProbabilityNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "NumberOfHits0":
                    userData = new UserData { NumberOfHitsNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "NumberOfHits1":
                    userData = new UserData { NumberOfHitsNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy0":
                    userData = new UserData { EnergyNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy1":
                    userData = new UserData { EnergyNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy2":
                    userData = new UserData { EnergyNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;
                case "Energy3":
                    userData = new UserData { EnergyNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy4":
                    userData = new UserData { EnergyNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy5":
                    userData = new UserData { EnergyNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;
                default: return;
            }
        }



        public void SaveNodeAvailability(string nodeAvailableName, bool isAvailable)
        {
            switch (nodeAvailableName)
            {
                case "AttackAvailable0":
                    var userData = new UserData { AttackNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "AttackAvailable1":
                    userData = new UserData { AttackNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "AttackAvailable2":
                    userData = new UserData { AttackNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "AttackAvailable3":
                    userData = new UserData { AttackNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "AttackAvailable4":
                    userData = new UserData { AttackNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "AttackAvailable5":
                    userData = new UserData { AttackNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "AttackAvailable6":
                    userData = new UserData { AttackNodeAvailable6 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "AttackAvailable7":
                    userData = new UserData { AttackNodeAvailable7 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "AttackAvailable8":
                    userData = new UserData { AttackNodeAvailable8 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable0":
                    userData = new UserData { HpNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable1":
                    userData = new UserData { HpNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable2":
                    userData = new UserData { HpNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable3":
                    userData = new UserData { HpNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable4":
                    userData = new UserData { HpNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable5":
                    userData = new UserData { HpNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable6":
                    userData = new UserData { HpNodeAvailable6 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable7":
                    userData = new UserData { HpNodeAvailable7 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable8":
                    userData = new UserData { HpNodeAvailable8 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "CriticalProbabilityAvailable0":
                    userData = new UserData { CriticalProbabilityNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "CriticalProbabilityAvailable1":
                    userData = new UserData { CriticalProbabilityNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "CriticalProbabilityAvailable2":
                    userData = new UserData { CriticalProbabilityNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "CriticalProbabilityAvailable3":
                    userData = new UserData { CriticalProbabilityNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "CriticalMultiplierAvailable0":
                    userData = new UserData { CriticalMultiplierNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "CriticalMultiplierAvailable1":
                    userData = new UserData { CriticalMultiplierNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "CriticalMultiplierAvailable2":
                    userData = new UserData { CriticalMultiplierNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "CriticalMultiplierAvailable3":
                    userData = new UserData { CriticalMultiplierNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ExcelentProbabilityAvailable0":
                    userData = new UserData { ExcelentProbabilityNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ExcelentProbabilityAvailable1":
                    userData = new UserData { ExcelentProbabilityNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ExcelentProbabilityAvailable2":
                    userData = new UserData { ExcelentProbabilityNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ExcelentProbabilityAvailable3":
                    userData = new UserData { ExcelentProbabilityNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ExcelentMultiplierAvailable0":
                    userData = new UserData { ExcelentMultiplierNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ExcelentMultiplierAvailable1":
                    userData = new UserData { ExcelentMultiplierNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ExcelentMultiplierAvailable2":
                    userData = new UserData { ExcelentMultiplierNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ExcelentMultiplierAvailable3":
                    userData = new UserData { ExcelentMultiplierNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAbsorbProbabilityAvailable0":
                    userData = new UserData { HpAbsorbProbabilityNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAbsorbProbabilityAvailable1":
                    userData = new UserData { HpAbsorbProbabilityNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAbsorbProbabilityAvailable2":
                    userData = new UserData { HpAbsorbProbabilityNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAbsorbProbabilityAvailable3":
                    userData = new UserData { HpAbsorbProbabilityNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAbsorbDenominatorAvailable0":
                    userData = new UserData { HpAbsorbDenominatorNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAbsorbDenominatorAvailable1":
                    userData = new UserData { HpAbsorbDenominatorNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAbsorbDenominatorAvailable2":
                    userData = new UserData { HpAbsorbDenominatorNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAbsorbDenominatorAvailable3":
                    userData = new UserData { HpAbsorbDenominatorNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "MultipleHitsProbabilityAvailable0":
                    userData = new UserData { MultipleHitsProbabilityNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;
                case "MultipleHitsProbabilityAvailable1":
                    userData = new UserData { MultipleHitsProbabilityNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "MultipleHitsProbabilityAvailable2":
                    userData = new UserData { MultipleHitsProbabilityNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "MultipleHitsProbabilityAvailable3":
                    userData = new UserData { MultipleHitsProbabilityNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "MultipleHitsProbabilityAvailable4":
                    userData = new UserData { MultipleHitsProbabilityNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "MultipleHitsProbabilityAvailable5":
                    userData = new UserData { MultipleHitsProbabilityNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "NumberOfHitsAvailable0":
                    userData = new UserData { NumberOfHitsNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "NumberOfHitsAvailable1":
                    userData = new UserData { NumberOfHitsNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable0":
                    userData = new UserData { EnergyNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable1":
                    userData = new UserData { EnergyNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable2":
                    userData = new UserData { EnergyNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;
                case "EnergyAvailable3":
                    userData = new UserData { EnergyNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable4":
                    userData = new UserData { EnergyNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable5":
                    userData = new UserData { EnergyNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;
                default: return;
            }
        }
    }
}