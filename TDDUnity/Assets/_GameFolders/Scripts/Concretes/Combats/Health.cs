using System;
using TDDUnity.Abstracts.Combats;
using TDDUnity.Abstracts.ScriptableObjects;
using UnityEngine;

namespace TDDUnity.Combats
{
    public class Health: IHealth
    {
        int _currentHealth = 0;
        int _maxHealth = 0;

        bool isDead => _currentHealth <= 0;

        public event Action OnTakeDamage;
        public event Action OnDead;

        public int CurrentHealth => _currentHealth;

        public Health(IStats stats)
        {
            _maxHealth = stats.MaxHealth;

            _currentHealth = _maxHealth;
        }
        public void TakeDamage(IAttacker attacker)
        {
            if (isDead) return;

            _currentHealth -= attacker.Damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);//assign results which one is greater

            OnTakeDamage?.Invoke();
            if (isDead) OnDead?.Invoke();
        }

    }
}
