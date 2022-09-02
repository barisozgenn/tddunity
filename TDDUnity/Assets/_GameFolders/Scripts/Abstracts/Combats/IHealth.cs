using System;

namespace TDDUnity.Abstracts.Combats
{
    public interface IHealth
    {
        int CurrentHealth { get;}

        void TakeDamage(TDDUnity.Abstracts.Combats.IAttacker attacker);
        event Action OnTakeDamage;
        event Action OnDead;

    }
}
