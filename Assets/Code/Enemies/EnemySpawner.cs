using Assets.Code.Common.Events;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Core;
using Assets.Code.Enemies;
using Assets.Code.MusicAndSound;
using Assets.Code.Projectiles.Common;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _verticalDirectionPositions;
    [SerializeField] private Transform[] _horizontalDirectionPositions;
    [SerializeField] private Transform[] _topSpawnPositions;
    [SerializeField] private Transform[] _rightSpawnPositions;
    [SerializeField] private Transform[] _leftSpawnPositions;
    [SerializeField] private Transform[] _bottomSpawnPositions;

    [SerializeField] private  MapsConfiguration _mapsConfiguration;
    private ProjectileFactory _projectileFactory;

    private LevelConfiguration _levelConfiguration;
    private float _currentTimeInSeconds;
    private int _currentConfigurationIndex;
    private bool _canSpawn;
    private string _lastMapPlayed;


    private void Start()
    {
        _projectileFactory = ServiceLocator.Instance.GetService<ProjectileFactory>();
        GetCurrentLevelCofiguration();
        ServiceLocator.Instance.GetService<AudioManager>().PlayGameMusic(_lastMapPlayed);
    }

    private void GetCurrentLevelCofiguration()
    {
        var serviceLocator = ServiceLocator.Instance;
        int currentLevel = serviceLocator.GetService<MapsAndLevelsSystem>().GetLastLevelPlayed();
        _lastMapPlayed = serviceLocator.GetService<MapsAndLevelsSystem>().GetLastMapPlayed();
        MapConfiguration mapConfiguration = _mapsConfiguration.GetMapById(_lastMapPlayed);
        _levelConfiguration = mapConfiguration.GetCurrentLevelConfiguration(currentLevel);
    }

    public void StartSpawn()
    {
        _canSpawn = true;
    }

    public void RestartSpawn()
    {
        _canSpawn = true;
        if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
        {
            ServiceLocator.Instance.GetService<EventQueue>()
                          .EnqueueEvent(new EventData(EventIds.AllProjectilesSpawned));
        }
    }


    public void Stop() 
    {
        _canSpawn = false;
    }


    private void Update()
    {
        if (!_canSpawn)
        {
            return;
        }

        if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
        {
            return;
        }

        _currentTimeInSeconds += Time.deltaTime;

        var spawnConfiguration = _levelConfiguration.SpawnConfigurations[_currentConfigurationIndex];
        if (spawnConfiguration.TimeToSpawn > _currentTimeInSeconds)
        {
            return;
        }

        SpawnShips(spawnConfiguration);
        _currentConfigurationIndex += 1;

        if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
        {
            ServiceLocator.Instance.GetService<EventQueue>()
                          .EnqueueEvent(new EventData(EventIds.AllProjectilesSpawned));
        }
    }


    private Transform FilterSpawnPosition(SpawnConfiguration spawnConfiguration)
    {
        if (spawnConfiguration.IsTop)
        {
            var spawnPosition = _topSpawnPositions[Random.Range(0, _topSpawnPositions.Length)];
            return spawnPosition;
        }
        if (spawnConfiguration.IsRightAside)
        {
            var spawnPosition = _rightSpawnPositions[Random.Range(0, _rightSpawnPositions.Length)];
            return spawnPosition;
        }
        if (spawnConfiguration.IsLeftAside)
        {
            var spawnPosition = _leftSpawnPositions[Random.Range(0, _leftSpawnPositions.Length)];
            return spawnPosition;
        }
        else
        {
            var spawnPosition = _bottomSpawnPositions[Random.Range(0, _bottomSpawnPositions.Length)];
            return spawnPosition;
        }
    }

    private Transform[] FilterDirectionPositions(SpawnConfiguration spawnConfiguration)
    {
        if (spawnConfiguration.IsRightAside || spawnConfiguration.IsLeftAside)
        {
            return _verticalDirectionPositions;
        }
        
        return _horizontalDirectionPositions;
    }
    private void SpawnShips(SpawnConfiguration spawnConfiguration)
    {
        ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Spawn");
        for (var i = 0; i < spawnConfiguration.ProjectileNumberToSpawnConfigurations; i++)
        {
            float randomNumber = Random.Range(0f, 100f);
            ProjectileToSpawnConfiguration shipConfiguration;

            if (randomNumber < _levelConfiguration.SpecialProjectileCastPercentaje)
            {
                shipConfiguration = _levelConfiguration.GetRandomSpecialProgectileToSpawnConfiguration();
            }
            else
            {
                shipConfiguration = _levelConfiguration.GetRandomProgectileToSpawnConfiguration();
            }

            var shipBuilder = _projectileFactory.Create(shipConfiguration.ProjectileId.Value);
            var spawnPosition = FilterSpawnPosition(spawnConfiguration);
            shipBuilder
                      .WithPosition(spawnPosition.position)
                      .WithRotation(spawnPosition.rotation)
                      .WithSpawnPosition(spawnConfiguration.IsTop, spawnConfiguration.IsLeftAside, spawnConfiguration.IsRightAside)
                      .WithDirectionPositions(FilterDirectionPositions(spawnConfiguration))
                      .WithProjectileLevel(_levelConfiguration.ProjectileLevel)
                      .WithConfiguration(shipConfiguration)
                      .WithCheckBottomDestroyLimits()
                      .Build();
            ServiceLocator.Instance.GetService<EventQueue>()
                          .EnqueueEvent(new EventData(EventIds.ProjectileSpawned));
        }
    }

}
