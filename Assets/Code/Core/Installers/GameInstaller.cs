using Assets.Code.Battle;
using Assets.Code.Projectiles.Common;
using Assets.Code.UI;
using UnityEngine;
using Assets.Code.ReciclableObjects;
using Assets.Code.ReciclableObjects.HitParticles;
using Assets.Code.ReciclableObjects.ExplosionParticles;
using Assets.Code.ReciclableObjects.PopUps;
using Assets.Code.ReciclableObjects.PopUps.DamagePopUp;
using Assets.Code.ReciclableObjects.DamagePopUp;
using Assets.Code.ReciclableObjects.PopUps.HpPopUp;
using Assets.Code.ReciclableObjects.BloodyOverlay;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Enemies.Projectiles;
using Assets.Code.ReciclableObjects.PopUps.LvlUpPopUp;

namespace Assets.Code.Core.Installers
{
    public class GameInstaller : GeneralInstaller
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private GemsView _gemsView;
        [SerializeField] private LevelExperienceView _levelExperienceView;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private ParticleSpawner _particleSpawner;
        [SerializeField] private PopUpSpawner _popUpSpawner;
        [SerializeField] private BloodyOverlaySpawner _bloodyOverlaySpawner;
        [SerializeField] private GameStateController _gameStateController;
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private LvlUpPopUpSpawner _lvlUpPopUpSpawner;

        [SerializeField] private AllProjectilesConfiguration _allProjectilesConfiguration;
        [SerializeField] private ExplosionParticlesSystemConfiguration _explosionParticlesSystemConfiguration;
        [SerializeField] private HitParticlesSystemConfiguration _hitParticlesSystemConfiguration;
        [SerializeField] private DamagePopUpConfiguration _damagePopUpConfiguration;
        [SerializeField] private HpPopUpConfiguration _hpPopUpConfiguration;
        [SerializeField] private BloodyOverlayConfiguration _bloodyOverlayConfiguration;
        [SerializeField] private LvlUpPopUpConfiguration _lvlUpPopUpConfiguration;


        protected override void DoStart()
        {
        }

        protected override void DoInstallDependencies()
        {
            ServiceLocator.Instance.RegisterService(_scoreView);
            ServiceLocator.Instance.RegisterService(_gemsView);
            ServiceLocator.Instance.RegisterService(_levelExperienceView);
            ServiceLocator.Instance.RegisterService(_enemySpawner);
            ServiceLocator.Instance.RegisterService(_particleSpawner);
            ServiceLocator.Instance.RegisterService(_popUpSpawner);
            ServiceLocator.Instance.RegisterService(_bloodyOverlaySpawner);
            ServiceLocator.Instance.RegisterService(_gameStateController);
            ServiceLocator.Instance.RegisterService(_screenFade);
            ServiceLocator.Instance.RegisterService(_lvlUpPopUpSpawner);
            InstallProjectileFactory();
            InstallExplosionParticleSystemFactory();
            InstallHitParticleSystemFactory();
            InstallDamagePopUpFactory();
            InstallHpPopUpFactory();
            InstallBloodyOverlayFactory();
            InstallLvlUpPopUpConfiguration();
        }


        private void InstallProjectileFactory()
        {
            var lastMapPlayed = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().GetLastMapPlayed();
            var projectileFactory = new ProjectileFactory(Instantiate(_allProjectilesConfiguration.GetProjectileConfigurationById(lastMapPlayed)));
            ServiceLocator.Instance.RegisterService(projectileFactory);
        }

        private void InstallExplosionParticleSystemFactory()
        {
            var explosionParticleSystemFactory = new ExplosionParticleSystemFactory(Instantiate(_explosionParticlesSystemConfiguration),
                                                ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().GetLastMapPlayed());
            ServiceLocator.Instance.RegisterService(explosionParticleSystemFactory);
        }
        private void InstallHitParticleSystemFactory()
        {
            var hitParticleSystemFactory = new HitParticleSystemFactory(Instantiate(_hitParticlesSystemConfiguration));
            ServiceLocator.Instance.RegisterService(hitParticleSystemFactory);
        }

        private void InstallDamagePopUpFactory()
        {
            var damagePopUpFactory = new DamagePopUpFactory(Instantiate(_damagePopUpConfiguration));
            ServiceLocator.Instance.RegisterService(damagePopUpFactory);
        }

        private void InstallHpPopUpFactory()
        {
            var hpPopUpFactory = new HpPopUpFactory(Instantiate(_hpPopUpConfiguration));
            ServiceLocator.Instance.RegisterService(hpPopUpFactory);
        }
        
        private void InstallBloodyOverlayFactory()
        {
            var bloodyOverlayFactory = new BloodyOverlayFactory(Instantiate(_bloodyOverlayConfiguration));
            ServiceLocator.Instance.RegisterService(bloodyOverlayFactory);
        }

        private void InstallLvlUpPopUpConfiguration()
        {
            var LvlUpPopUpFactory = new LvlUpPopUpFactory(Instantiate(_lvlUpPopUpConfiguration));
            ServiceLocator.Instance.RegisterService(LvlUpPopUpFactory);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.UnregisterService<ScoreView>();
            ServiceLocator.Instance.UnregisterService<GemsView>();
            ServiceLocator.Instance.UnregisterService<LevelExperienceView>();
            ServiceLocator.Instance.UnregisterService<EnemySpawner>();
            ServiceLocator.Instance.UnregisterService<ParticleSpawner>();
            ServiceLocator.Instance.UnregisterService<PopUpSpawner>();
            ServiceLocator.Instance.UnregisterService<BloodyOverlaySpawner>();
            ServiceLocator.Instance.UnregisterService<GameStateController>();
            ServiceLocator.Instance.UnregisterService<ScreenFade>();
            ServiceLocator.Instance.UnregisterService<ProjectileFactory>();
            ServiceLocator.Instance.UnregisterService<ExplosionParticleSystemFactory>();
            ServiceLocator.Instance.UnregisterService<HitParticleSystemFactory>();
            ServiceLocator.Instance.UnregisterService<DamagePopUpFactory>();
            ServiceLocator.Instance.UnregisterService<HpPopUpFactory>();
            ServiceLocator.Instance.UnregisterService<BloodyOverlayFactory>();
            ServiceLocator.Instance.UnregisterService<LvlUpPopUpSpawner>();
            ServiceLocator.Instance.UnregisterService<LvlUpPopUpFactory>();
        }
    }
}