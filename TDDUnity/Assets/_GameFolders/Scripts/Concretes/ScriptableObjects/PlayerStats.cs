using System.Collections;
using TDDUnity.Abstracts.ScriptableObjects;
using UnityEngine;

namespace TDDUnity.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats", menuName = "Baris Gaming/Stats/Player Stats")]
    public class PlayerStats : ScriptableObject, IPlayerStats
    {
        [Header("Move Information")]  [SerializeField] float _moveSpeed = 5f;

        [Header("Combat Information")] [SerializeField] int _maxHealth = 10;

        public float MoveSpeed => _moveSpeed;

        public int MaxHealth => _maxHealth;
    }
}


