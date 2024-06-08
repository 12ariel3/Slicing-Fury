using Assets.Code.Common.Events;
using Assets.Code.Core.DataStorage;
using Assets.Code.Core;

namespace Assets.Code.Common.Level
{
    public class SwordsLevelSystemImpl : EventObserver, SwordsLevelSystem
    {
        private readonly DataStore _dataStore;
        private const string _basicSwordLevelData = "BasicSwordLevelData";
        private const string _rainbowSwordLevelData = "RainbowSwordLevelData";
        private const string _batPierceSwordLevelData = "BatPierceSwordLevelData";
        private const string _aquariusSwordLevelData = "AquariusSwordLevelData";
        private const string _thundraSwordLevelData = "ThundraSwordLevelData";
        private const string _absoluteZeroSwordLevelData = "AbsoluteZeroSwordLevelData";
        private const string _plasmaBurstSwordLevelData = "PlasmaBurstSwordLevelData";
        private const string _pyraSwordLevelData = "PyraSwordLevelData";
        private const string _soulSeekerSwordLevelData = "SoulSeekerSwordLevelData";
        private const string _terraForceSwordLevelData = "TerraForceSwordLevelData";
        private const string _gaiaSwordLevelData = "GaiaSwordLevelData";

        private const string _basicSwordIsUnlockedData = "BasicSwordIsUnlockedData";
        private const string _rainbowSwordIsUnlockedData = "RainbowSwordIsUnlockedData";
        private const string _batPierceSwordIsUnlockedData = "BatPierceSwordIsUnlockedData";
        private const string _aquariusSwordIsUnlockedData = "AquariusSwordIsUnlockedData";
        private const string _thundraSwordIsUnlockedData = "ThundraSwordIsUnlockedData";
        private const string _absoluteZeroSwordIsUnlockedData = "AbsoluteZeroSwordIsUnlockedData";
        private const string _plasmaBurstSwordIsUnlockedData = "PlasmaBurstSwordIsUnlockedData";
        private const string _pyraSwordIsUnlockedData = "PyraSwordIsUnlockedData";
        private const string _soulSeekerSwordIsUnlockedData = "SoulSeekerSwordIsUnlockedData";
        private const string _terraForceSwordIsUnlockedData = "TerraForceSwordIsUnlockedData";
        private const string _gaiaSwordIsUnlockedData = "GaiaSwordIsUnlockedData";



        public SwordsLevelSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.SwordLevelUp, this);
        }


        public int GetLevel(string swordId)
        {
            switch (swordId)
            {
                case "Basic Sword":
                   return GetBasicCurrentLevel(); 

                case "Rainbow":
                   return GetRainbowCurrentLevel();
                
                case "Bat Pierce":
                   return GetBatPierceCurrentLevel(); 
                
                case "Aquarius":
                   return GetAquariusCurrentLevel(); 
                
                case "Thundra":
                   return GetThundraCurrentLevel(); 
                
                case "Absolute Zero":
                   return GetAbsoluteZeroCurrentLevel(); 
                
                case "Plasma Burst":
                   return GetPlasmaBurstCurrentLevel(); 
                
                case "Pyra":
                   return GetPyraCurrentLevel(); 
                
                case "Soul Seeker":
                   return GetSoulSeekerCurrentLevel(); 
                
                case "Terra Force":
                   return GetTerraForceCurrentLevel(); 
                
                case "Gaia":
                   return GetGaiaCurrentLevel(); 
                
                default: return 1;
            }
        }
        public int GetBasicCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_basicSwordLevelData)
                        ?? new UserData();
            return userData.BasicSword;
        }
        public int GetRainbowCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_rainbowSwordLevelData)
                        ?? new UserData();
            return userData.RainBowSword;
        }
        public int GetBatPierceCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_batPierceSwordLevelData)
                        ?? new UserData();
            return userData.BatPierceSword;
        }
        public int GetAquariusCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_aquariusSwordLevelData)
                        ?? new UserData();
            return userData.AquariusSword;
        }
        public int GetThundraCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_thundraSwordLevelData)
                        ?? new UserData();
            return userData.ThundraSword;
        }
        public int GetAbsoluteZeroCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_absoluteZeroSwordLevelData)
                        ?? new UserData();
            return userData.AbsoluteZeroSword;
        }
        public int GetPlasmaBurstCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_plasmaBurstSwordLevelData)
                        ?? new UserData();
            return userData.PlasmaBurstSword;
        }
        public int GetPyraCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_pyraSwordLevelData)
                        ?? new UserData();
            return userData.PyraSword;
        }
        public int GetSoulSeekerCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_soulSeekerSwordLevelData)
                        ?? new UserData();
            return userData.SoulSeekerSword;
        }
        public int GetTerraForceCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_terraForceSwordLevelData)
                        ?? new UserData();
            return userData.TerraForceSword;
        }
        public int GetGaiaCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_gaiaSwordLevelData)
                        ?? new UserData();
            return userData.GaiaSword;
        }


        public void SaveLevel(string swordId, int swordLevel)
        {
            switch (swordId)
            {
                case "Basic Sword":
                    SaveBasicCurrentLevel(swordLevel); break;

                case "Rainbow":
                    SaveRainbowCurrentLevel(swordLevel); break;

                case "Bat Pierce":
                    SaveBatPierceCurrentLevel(swordLevel); break;
                
                case "Aquarius":
                    SaveAquariusCurrentLevel(swordLevel); break;
                
                case "Thundra":
                    SaveThundraCurrentLevel(swordLevel); break;
                
                case "Absolute Zero":
                    SaveAbsoluteZeroCurrentLevel(swordLevel); break;
                
                case "Plasma Burst":
                    SavePlasmaBurstCurrentLevel(swordLevel); break;
                
                case "Pyra":
                    SavePyraCurrentLevel(swordLevel); break;
                
                case "Soul Seeker":
                    SaveSoulSeekerCurrentLevel(swordLevel); break;
                
                case "Terra Force":
                    SaveTerraForceCurrentLevel(swordLevel); break;
                
                case "Gaia":
                    SaveGaiaCurrentLevel(swordLevel); break;
                
                default:
                    break;
            }
        }


        public void SaveBasicCurrentLevel(int level)
        {
            var userData = new UserData { BasicSword = level };
            _dataStore.SetData(userData, _basicSwordLevelData);
        }
        
        public void SaveRainbowCurrentLevel(int level)
        {
            var userData = new UserData { RainBowSword = level };
            _dataStore.SetData(userData, _rainbowSwordLevelData);
        }
        
        public void SaveBatPierceCurrentLevel(int level)
        {
            var userData = new UserData { BatPierceSword = level };
            _dataStore.SetData(userData, _batPierceSwordLevelData);
        }
        
        public void SaveAquariusCurrentLevel(int level)
        {
            var userData = new UserData { AquariusSword = level };
            _dataStore.SetData(userData, _aquariusSwordLevelData);
        }
        
        public void SaveThundraCurrentLevel(int level)
        {
            var userData = new UserData { ThundraSword = level };
            _dataStore.SetData(userData, _thundraSwordLevelData);
        }
        
        public void SaveAbsoluteZeroCurrentLevel(int level)
        {
            var userData = new UserData { AbsoluteZeroSword = level };
            _dataStore.SetData(userData, _absoluteZeroSwordLevelData);
        }
        
        public void SavePlasmaBurstCurrentLevel(int level)
        {
            var userData = new UserData { PlasmaBurstSword = level };
            _dataStore.SetData(userData, _plasmaBurstSwordLevelData);
        }
        
        public void SavePyraCurrentLevel(int level)
        {
            var userData = new UserData { PyraSword = level };
            _dataStore.SetData(userData, _pyraSwordLevelData);
        }
        
        public void SaveSoulSeekerCurrentLevel(int level)
        {
            var userData = new UserData { SoulSeekerSword = level };
            _dataStore.SetData(userData, _soulSeekerSwordLevelData);
        }
        
        public void SaveTerraForceCurrentLevel(int level)
        {
            var userData = new UserData { TerraForceSword = level };
            _dataStore.SetData(userData, _terraForceSwordLevelData);
        }
        
        public void SaveGaiaCurrentLevel(int level)
        {
            var userData = new UserData { GaiaSword = level };
            _dataStore.SetData(userData, _gaiaSwordLevelData);
        }



        public bool GetIfIsSwordUnlocked(string swordId)
        {
            switch (swordId)
            {
                case "Basic Sword":
                    return GetBasicIfIsUnlocked();

                case "Rainbow":
                    return GetRainbowIfIsUnlocked();

                case "Bat Pierce":
                    return GetBatPierceIfIsUnlocked();

                case "Aquarius":
                    return GetAquariusIfIsUnlocked();

                case "Thundra":
                    return GetThundraIfIsUnlocked();

                case "Absolute Zero":
                    return GetAbsoluteZeroIfIsUnlocked();

                case "Plasma Burst":
                    return GetPlasmaBurstIfIsUnlocked();

                case "Pyra":
                    return GetPyraIfIsUnlocked();

                case "Soul Seeker":
                    return GetSoulSeekerIfIsUnlocked();

                case "Terra Force":
                    return GetTerraForceIfIsUnlocked();

                case "Gaia":
                    return GetGaiaIfIsUnlocked();

                default: return false;
            }
        }


        public bool GetBasicIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_basicSwordIsUnlockedData)
                        ?? new UserData();
            return userData.BasicSwordIsUnlocked;
        }
        public bool GetRainbowIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_rainbowSwordIsUnlockedData)
                        ?? new UserData();
            return userData.RainBowSwordIsUnlocked;
        }
        public bool GetBatPierceIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_batPierceSwordIsUnlockedData)
                        ?? new UserData();
            return userData.BatPierceSwordIsUnlocked;
        }
        public bool GetAquariusIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_aquariusSwordIsUnlockedData)
                        ?? new UserData();
            return userData.AquariusSwordIsUnlocked;
        }
        public bool GetThundraIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_thundraSwordIsUnlockedData)
                        ?? new UserData();
            return userData.ThundraSwordIsUnlocked;
        }
        public bool GetAbsoluteZeroIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_absoluteZeroSwordIsUnlockedData)
                        ?? new UserData();
            return userData.AbsoluteZeroSwordIsUnlocked;
        }
        public bool GetPlasmaBurstIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_plasmaBurstSwordIsUnlockedData)
                        ?? new UserData();
            return userData.PlasmaBurstSwordIsUnlocked;
        }
        public bool GetPyraIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_pyraSwordIsUnlockedData)
                        ?? new UserData();
            return userData.PyraSwordIsUnlocked;
        }
        public bool GetSoulSeekerIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_soulSeekerSwordIsUnlockedData)
                        ?? new UserData();
            return userData.SoulSeekerSwordIsUnlocked;
        }
        public bool GetTerraForceIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_terraForceSwordIsUnlockedData)
                        ?? new UserData();
            return userData.TerraForceSwordIsUnlocked;
        }
        public bool GetGaiaIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_gaiaSwordIsUnlockedData)
                        ?? new UserData();
            return userData.GaiaSwordIsUnlocked;
        }



        public void SaveIfIsSwordUnlocked(string swordId, bool isSwordUnlocked)
        {
            switch (swordId)
            {
                case "Basic Sword":
                    SaveBasicIfIsUnlocked(isSwordUnlocked); break;

                case "Rainbow":
                    SaveRainbowIfIsUnlocked(isSwordUnlocked); break;

                case "Bat Pierce":
                    SaveBatPierceIfIsUnlocked(isSwordUnlocked); break;

                case "Aquarius":
                    SaveAquariusIfIsUnlocked(isSwordUnlocked); break;

                case "Thundra":
                    SaveThundraIfIsUnlocked(isSwordUnlocked); break;

                case "Absolute Zero":
                    SaveAbsoluteZeroIfIsUnlocked(isSwordUnlocked); break;

                case "Plasma Burst":
                    SavePlasmaBurstIfIsUnlocked(isSwordUnlocked); break;

                case "Pyra":
                    SavePyraIfIsUnlocked(isSwordUnlocked); break;

                case "Soul Seeker":
                    SaveSoulSeekerIfIsUnlocked(isSwordUnlocked); break;

                case "Terra Force":
                    SaveTerraForceIfIsUnlocked(isSwordUnlocked); break;

                case "Gaia":
                    SaveGaiaIfIsUnlocked(isSwordUnlocked); break;

                default:
                    break;
            }
        }


        public void SaveBasicIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { BasicSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _basicSwordIsUnlockedData);
        }

        public void SaveRainbowIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { RainBowSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _rainbowSwordIsUnlockedData);
        }

        public void SaveBatPierceIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { BatPierceSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _batPierceSwordIsUnlockedData);
        }

        public void SaveAquariusIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { AquariusSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _aquariusSwordIsUnlockedData);
        }

        public void SaveThundraIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { ThundraSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _thundraSwordIsUnlockedData);
        }

        public void SaveAbsoluteZeroIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { AbsoluteZeroSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _absoluteZeroSwordIsUnlockedData);
        }

        public void SavePlasmaBurstIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { PlasmaBurstSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _plasmaBurstSwordIsUnlockedData);
        }

        public void SavePyraIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { PyraSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _pyraSwordIsUnlockedData);
        }

        public void SaveSoulSeekerIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { SoulSeekerSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _soulSeekerSwordIsUnlockedData);
        }

        public void SaveTerraForceIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { TerraForceSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _terraForceSwordIsUnlockedData);
        }

        public void SaveGaiaIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { GaiaSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _gaiaSwordIsUnlockedData);
        }




        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.SwordLevelUp)
            {
                var swordLevelUpEventData = (SwordLevelUpEventData)eventData;
                SaveLevel(swordLevelUpEventData.SwordId, swordLevelUpEventData.SwordLevel);

                return;
            }
        }
    }
}