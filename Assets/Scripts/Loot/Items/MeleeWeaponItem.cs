namespace Sleepy.Loot
{
    using Combat;
    using Characters;
    using System;
    using UnityEngine;
    using Combat;

    [Serializable]
    [CreateAssetMenu(menuName="Items/Equipable/Melee")]
    public class MeleeWeaponItem : EquipableItem
    {
        [Header("Weapon Stats")]
        [Tooltip("Damage before any modifiers are applied")]
        public float Damage;
        public MeleeWeaponClassification Classification;
        public AttackType AttackType;
        public DamageType DamageType;
        [Tooltip("Base cooldown duration between attacks (ms), before any modifiers are applied")]
        public float CooldownDuration;

        public override void Use(Character character)
        {
            Collider2D[] collisions = AttackType.GetColliders(character);

            foreach (Collider2D collision in collisions)
            {
                if (collision == character.Body.Collider)
                {
                    continue;
                }

                Strikeable strikeable = collision.gameObject.GetComponent<Strikeable>();

                if (strikeable)
                {
                    StrikeData strike = new StrikeData(
                        DamageType.Name,
                        Damage,
                        character.Entity,
                        Time.time
                    );

                    strikeable.Strike(strike);
                }
            }
        }

        public void SpawnUseEffects(Character character)
        {
            GameObject effect = Instantiate(AttackType.EffectPrefab, character.Transform);
            effect.transform.localEulerAngles = new Vector3(0, 0, character.Body.Angle - 90);
        }
    }
}
