using UnityEngine;


[CreateAssetMenu(fileName = "Projectile Base", menuName = "Projectile/Projectile Base")]
public class ProjectileBase : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private int _score;
    [SerializeField] private ParticleSystem _explosionParticleSystem;

    [SerializeField] private int maxHp;
    [SerializeField] private int attack;
    [SerializeField] private int defense;


    public string Id => _id;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public ParticleSystem ExplosionParticleSystem => _explosionParticleSystem;
}
