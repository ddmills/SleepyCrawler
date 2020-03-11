namespace Sleepy.Loot
{
    using System;
    using Bolt;

    [Serializable]
    public struct ItemUseData
    {
        public int SlotId;

        public ItemUseData(int slotId)
        {
            SlotId = slotId;
        }

        public ItemUseEvent ToBoltItemUseEventEvent(BoltEntity reciever)
        {
            ItemUseEvent evnt = ItemUseEvent.Create(reciever);

            evnt.Slot = SlotId;

            return evnt;
        }

        public static ItemUseData FromBoltEvent(ItemUseEvent evnt)
        {
            return new ItemUseData(evnt.Slot);
        }
    }
}
