namespace Sleepy.Combat
{
    using System;
    using UnityEngine;

    [Serializable]
    [CreateAssetMenu(menuName="Combat/DamageType")]
    public class DamageType : ScriptableObject
    {
        public string Name;
        public string Description;
    }
}
