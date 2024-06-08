using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using UnityEngine;

namespace Assets.Code.Common.TimeMediator
{
    public class TimeForSpecialProjectileMediator : MonoBehaviour, EventObserver
    {
        private float _counter;
        private bool _isActive;

        void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.TimeSpecialProjectileWasActivated, this);
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.GameOver, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.TimeSpecialProjectileWasActivated, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
            eventQueue.Unsubscribe(EventIds.GameOver, this);
        }

        void Update()
        {
            if(_isActive)
            {
                _counter -= Time.deltaTime;
                if(_counter <= 0)
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayProjectile("TimeFast");
                    Time.timeScale = 1f;
                    _isActive = false;
                }
            }
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.TimeSpecialProjectileWasActivated)
            {
                Time.timeScale = 0.8f;
                _isActive = true;
                _counter = 10;
            }

            if (eventData.EventId == EventIds.GameOver || eventData.EventId == EventIds.Victory)
            {
                _counter = 0;
                Time.timeScale = 1f;
                _isActive = false;
            }
        }

    }
}