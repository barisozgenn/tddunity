using System;
using TDDUnity.Abstracts.Combats;
using UnityEngine;

namespace TDDUnity.Combats
{
    public class Health: IHealth
    {
        int _currentHealth = 0;

        bool isDead => _currentHealth <= 0;

        public event Action OnTakeDamage;
        public event Action OnDead;

        public int CurrentHealt => _currentHealth;

        public Health(int maxHealth)
        {
            _currentHealth = maxHealth;
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
