using System.Collections;
using System.Collections.Generic;
using TDDUnity.Abstracts.ScriptableObjects;
using UnityEngine;

namespace TDDUnity.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Baris Gaming/Stats/Enemy Stats")]
    public class EnemyStats : Stats, IEnemyStats
    {

        /*[SerializeField] int _randomMaxDamage = 10;

        public override int CalculateDamage => Random.Range(_damage,_randomMaxDamage);*/
    }
}