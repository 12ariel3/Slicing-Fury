namespace Assets.Code.Common.Events
{
    public class BadProjectileDamageAmountEventData : EventData
    {
        public readonly int HpToRest;
        public readonly int InstanceId;

        public BadProjectileDamageAmountEventData(int hpToRest, int instanceId) : base(EventIds.BadProjectileDamageAmount)
        {
            HpToRest = hpToRest;
            InstanceId = instanceId;
        }
    }
}