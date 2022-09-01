using System;

namespace TDDUnity.Abstracts.Combats
{
    public interface IHealth
    {
        int CurrentHealt { get;}

        void TakeDamage(TDDUnity.Abstracts.Combats.IAttacker attacker);
        event Action OnTakeDamage;
        event Action OnDead;

    }
}
