using Assets.Code.Common;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.Enemies;
using Assets.Code.Enemies.CheckDestroyLimits;
using Assets.Code.Enemies.Projectiles;
using Assets.Code.Enemies.Projectiles.Common;
using Assets.Code.MusicAndSound;
using Assets.Code.Projectiles.Common;
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ProjectileMediator : RecyclableObject, Projectile, EventObserver
{
    [SerializeField] private MovementController _movementController;
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private HealthController _healthController;

    [SerializeField] private ProjectileId _projectileId;

    public string Id => _projectileId.Value;

    private string _explosionName;
    private int _playerAttack;
    private int _score;
    private int _gems;
    private int _gemsProbability;
    private int _experience;
    private int _attack;
    private CheckDestroyLimits _checkDestroyLimits;
    private bool _moved;
    private float _timer;
    private float _multipleHitsProbability;
    private int _numberOfHits;
    private bool _isSpecial;
    private bool _gameOver;
    private bool _pause;

    internal override void Init()
    {
        var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
        eventQueue.Subscribe(EventIds.GameOver, this);
        eventQueue.Subscribe(EventIds.Victory, this);
        eventQueue.Subscribe(EventIds.PausePressed, this);
        eventQueue.Subscribe(EventIds.ProjectileSpawned, this);
        eventQueue.Subscribe(EventIds.PlayerDestroyed, this);
        eventQueue.Subscribe(EventIds.ContinueBattleAfterAds, this);
        eventQueue.Subscribe(EventIds.PlayerSendFinalStatsValue, this);
        eventQueue.Subscribe(EventIds.IceExplosionWasActivated, this);
    }

    internal override void Release()
    {
        var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
        eventQueue.Unsubscribe(EventIds.GameOver, this);
        eventQueue.Unsubscribe(EventIds.Victory, this);
        eventQueue.Unsubscribe(EventIds.PausePressed, this);
        eventQueue.Unsubscribe(EventIds.ProjectileSpawned, this);
        eventQueue.Unsubscribe(EventIds.PlayerDestroyed, this);
        eventQueue.Unsubscribe(EventIds.ContinueBattleAfterAds, this);
        eventQueue.Unsubscribe(EventIds.PlayerSendFinalStatsValue, this);
        eventQueue.Unsubscribe(EventIds.IceExplosionWasActivated, this);
        _moved = false;
    }


    public void Configure(ProjectileConfiguration configuration)
    {
        _checkDestroyLimits = configuration.CheckDestroyLimits;
        _movementController.Configure(configuration.DirectionPositions, configuration.IsTop, configuration.IsLeft,
                                      configuration.IsRight);
        _healthController.Configure(this, configuration.Level, configuration.MaxHp);
        _score = Mathf.FloorToInt((configuration.Score * configuration.Level) / 7);
        _gems = Mathf.FloorToInt(((configuration.Gems * configuration.Level) / 7)+1);
        _gemsProbability = configuration.GemsProbability;
        _experience = Mathf.FloorToInt((configuration.Experience * configuration.Level)/7);
        _attack = Mathf.FloorToInt(configuration.Attack * configuration.Level); ;
        _explosionName = configuration.ExplosionName;
        _isSpecial = configuration.IsSpecial;
        if(_isSpecial )
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.IceExplosionWasActivated, this);
        }
    }

    private void OnMouseOver()
    {
        if (!_gameOver)
        {
            if (!_pause)
            {
                if (Input.touchCount >= 1)
                {
                    if (_timer >= .3f)
                    {
                        if (Random.Range(0, 100f) <= _multipleHitsProbability)
                        {
                            StartCoroutine(Attack(_numberOfHits));
                        }
                        else
                        {
                            StartCoroutine(Attack(1));
                        }
                        string randomString = Random.Range(1, 2).ToString();
                        ServiceLocator.Instance.GetService<AudioManager>().PlayProjectile("Hit" + randomString);
                        _timer = 0;
                    }
                }
            }
        }
    }
    
    IEnumerator Attack(int numberOfAttacks)
    {
        while(numberOfAttacks > 0)
        {
            DoOneAttack();
            yield return new WaitForSeconds(0.08f);
            numberOfAttacks--;
        }
    }

    private void DoOneAttack()
    {
        var transformPositionPlusOneOnZ = transform.position;
        transformPositionPlusOneOnZ.z = transformPositionPlusOneOnZ.z - 3;
        var projectileHittedEventData = new ProjectileHittedEventData(transformPositionPlusOneOnZ, transform.rotation,
                                                                      GetInstanceID());
        ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(projectileHittedEventData);
        _healthController.SetSpawnPopUpPosition(transform.position);
        _healthController.AddDamage(_playerAttack);
    }


    private void Update()
    {
        CheckDestroyLimits();
        _timer += Time.deltaTime;
    }

    private void CheckDestroyLimits()
    {

        if (_checkDestroyLimits.IsInsideTheLimits(transform.position))
        {
            return;
        }

        AttackPlayer();
    }

    private void AttackPlayer()
    {
        ProjectileDestroyedEventData projectileDestroyedEventData;

        if (_isSpecial)
        {
            projectileDestroyedEventData = new ProjectileDestroyedEventData(0, 0, 0, 0, 0, Id, transform.position,
                                                                                transform.rotation, GetInstanceID());
        }
        else
        {
            var attack = (int)(_attack * Random.Range(0.8f, 1.2f));
            projectileDestroyedEventData = new ProjectileDestroyedEventData(0, 0, 0, 0, attack, Id, transform.position,
                                                                                transform.rotation, GetInstanceID());
            string randomString = Random.Range(1, 2).ToString();
            ServiceLocator.Instance.GetService<AudioManager>().PlayProjectile("Damage" + randomString);
            DOTween.Sequence().Insert(0, Camera.main.DOShakePosition(0.4f, 0.2f, 2000));
        }
        
        ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(projectileDestroyedEventData);
        Recycle();
    }

    public void OnDamageReceived(bool isDeath)
    {
        if (isDeath)
        {
           
            var projectileDestroyedEventData = new ProjectileDestroyedEventData(_score, _gems, _gemsProbability, _experience, 0, Id,
                                                                                transform.position, transform.rotation, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(projectileDestroyedEventData);
            ServiceLocator.Instance.GetService<AudioManager>().PlayProjectile(_explosionName);

            if (_isSpecial)
            {
                VerifyWhichSpecialIsAndDoTheSpecialAbility();
            }

            Recycle();
        }
    }

    public void OnIceDamaged()
    {
        var projectileDestroyedEventData = new ProjectileDestroyedEventData(_score, _gems, _gemsProbability, _experience, 0, Id,
                                                                                transform.position, transform.rotation, GetInstanceID());
        ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(projectileDestroyedEventData);
        ServiceLocator.Instance.GetService<AudioManager>().PlayProjectile(_explosionName);

        Recycle();
    }


    public void VerifyWhichSpecialIsAndDoTheSpecialAbility()
    {
        switch (Id)
        {
            case "Good":
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.GoodSpecialProjectileDestroyed));
                return;
            case "IceExplosion":
                DOTween.Sequence().Insert(0, Camera.main.DOShakePosition(1f, 1f, 2000));
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.IceExplosionWasActivated));
                return;
            case "Bad":
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.BadSpecialProjectileDestroyed));
                return;
            case "Time":
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.TimeSpecialProjectileWasActivated));
                return;
        }
    }



    public void Process(EventData eventData)
    {
        if (eventData.EventId == EventIds.ProjectileSpawned)
        {
            if(!_moved)
            {
                _movementController.Move();
                _moved = true;
            }
        }
        
        if (eventData.EventId == EventIds.PausePressed)
        {
            if(_pause == true)
            {
                _pause = false;
            }
            else
            {
                _pause = true;
            }
        }
        
        if (eventData.EventId == EventIds.PlayerDestroyed)
        {
            _gameOver = true;
            _movementController.IsKinematicAndAssignVariables();
        }
        
        if (eventData.EventId == EventIds.ContinueBattleAfterAds)
        {
            _gameOver = false;
            _movementController.IsNotKinematicAndReassignVariables();
        }

        if (eventData.EventId == EventIds.PlayerSendFinalStatsValue)
        {
            var playerSendFinalStatsEventData = (PlayerSendFinalStatsEventData)eventData;
            _healthController.SetMultipliers(playerSendFinalStatsEventData.CriticalMultiplier, playerSendFinalStatsEventData.CriticalProbability,
                                             playerSendFinalStatsEventData.ExcelentMultiplier, playerSendFinalStatsEventData.ExcelentProbability);

            _playerAttack = playerSendFinalStatsEventData.AttackValue;
            _multipleHitsProbability = playerSendFinalStatsEventData.MultipleHitsProbability;
            _numberOfHits = playerSendFinalStatsEventData.NumberOfHits;
            _healthController.SetAbsorbVariables(playerSendFinalStatsEventData.HpAbsorbProbability,
                                                 playerSendFinalStatsEventData.HpAbsorbDenominator);
        }   

        if (eventData.EventId == EventIds.IceExplosionWasActivated)
        {
            OnIceDamaged();
        }

        if (eventData.EventId == EventIds.Victory)
        {
            Recycle();
        }

        if (eventData.EventId == EventIds.GameOver)
        {
            _gameOver = true;
        }

    }
}
