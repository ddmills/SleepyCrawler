namespace Sleepy.Combat
{
    using System;
    using UnityEngine;

    [Serializable]
    [CreateAssetMenu(menuName="Combat/MeleeWeaponClassification")]
    public class MeleeWeaponClassification : ScriptableObject
    {
        public string Name;
        public string Description;
    }
}
