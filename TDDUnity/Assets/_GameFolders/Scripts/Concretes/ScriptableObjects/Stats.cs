using UnityEngine;

namespace TDDUnity.ScriptableObjects
{
    public abstract class Stats : ScriptableObject
    {
        [Header("Move Information")][SerializeField]protected float _moveSpeed = 5f;

        [Header("Combat Information")][SerializeField] protected int _maxHealth = 10;

        [Header("Damage Information")][SerializeField] protected int _damage = 1;

        public float MoveSpeed => _moveSpeed;

        public int MaxHealth => _maxHealth;

        public virtual int CalculateDamage => _damage;
    }
}


