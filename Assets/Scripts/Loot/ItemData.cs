namespace Sleepy.Loot
{
    using System;
    using UnityEngine;

    [Serializable]
    public struct ItemData
    {
        public string SpritePath;
        public string Description;

        public Sprite LoadSprite()
        {
            Sprite sprite = Resources.Load<Sprite>(SpritePath);

            if (sprite == null)
            {
                throw new Exception("Sprite not found (" + SpritePath + ")");
            }

            return sprite;
        }
    }
}
