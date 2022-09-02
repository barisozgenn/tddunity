using System.Collections;
using System.Collections.Generic;
using TDDUnity.Abstracts.Combats;
using TDDUnity.Abstracts.ScriptableObjects;
using UnityEngine;

namespace TDDUnity.Combats
{
    public class Attacker : IAttacker
    {
        readonly IStats _stats;

        public Attacker(IStats stats)
        {
            _stats = stats;
        }
        public int Damage => _stats.CalculateDamage;
    }
}

