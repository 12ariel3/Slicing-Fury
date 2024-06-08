using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.Trails
{
    [CreateAssetMenu(menuName = "Trail/TrailsConfiguration", fileName = "TrailsConfiguration")]
    public class TrailsConfiguration : ScriptableObject
    {
        [SerializeField] private TrailToSpawnConfiguration[] _trailsConfigurations;
        private Dictionary<string, TrailToSpawnConfiguration> _idToTrailConfiguration;


        private void Awake()
        {
            _idToTrailConfiguration = new Dictionary<string, TrailToSpawnConfiguration>();
            foreach (var trail in _trailsConfigurations)
            {
                _idToTrailConfiguration.Add(trail.TrailId.Value, trail);
            }
        }


        public TrailToSpawnConfiguration GetTrailToSpawnConfigurationById(string id)
        {
            if (!_idToTrailConfiguration.TryGetValue(id, out var trail))
            {
                throw new Exception($"TrailToSpawnConfiguration {id} not found");
            }

            return trail;
        }
    }
}