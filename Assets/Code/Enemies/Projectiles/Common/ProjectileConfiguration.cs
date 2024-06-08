
using UnityEngine;

namespace Assets.Code.Enemies.Projectiles.Common
{
    public class ProjectileConfiguration
    {
        public readonly CheckDestroyLimits.CheckDestroyLimits CheckDestroyLimits;

        public readonly ProjectileId ProjectileId;
        public readonly Transform[] DirectionPositions;
        public readonly string Name;
        public readonly string ExplosionName;
        public readonly int Score;
        public readonly int Gems;
        public readonly int GemsProbability;
        public readonly int Experience;
        public readonly bool IsSpecial;
        public readonly bool IsTop;
        public readonly bool IsLeft;
        public readonly bool IsRight;

        public readonly int Level;
        public readonly int MaxHp;
        public readonly int Attack;


        public ProjectileConfiguration(string name, string explosionName, int score, int gems, int gemsProbability, int experience, int level,
                                       int maxHp, int attack, ProjectileId projectileId, Transform[] directionPositions,
                                       CheckDestroyLimits.CheckDestroyLimits checkDestroyLimits,
                                       bool isSpecial, bool isTop, bool isLeft, bool isRight)
        {
            Name = name;
            ExplosionName = explosionName;
            Score = score;
            Gems = gems;
            GemsProbability = gemsProbability;
            Experience = experience;
            Level = level;
            MaxHp = maxHp;
            Attack = attack;
            ProjectileId = projectileId;
            DirectionPositions = directionPositions;
            CheckDestroyLimits = checkDestroyLimits;
            IsSpecial = isSpecial;
            IsTop = isTop;
            IsLeft = isLeft;
            IsRight = isRight;
        }
    }
}