namespace Assets.Code.Projectiles.Common
{
    public interface Projectile
    {
        string Id { get; }

        void OnDamageReceived(bool isDeath);
    }
}