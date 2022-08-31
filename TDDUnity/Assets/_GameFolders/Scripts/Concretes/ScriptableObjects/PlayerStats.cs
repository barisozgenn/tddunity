using System.Collections;
using TDDUnity.Abstracts.ScriptableObjects;
using UnityEngine;

namespace TDDUnity.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats", menuName = "Baris Gaming/Stats/Player Stats")]
    public class PlayerStats : ScriptableObject, IPlayerStats
    {
        [Header("Move Information")]
        [SerializeField] float _moveSpeed = 5f;

        public float MoveSpeed => _moveSpeed;
    }
}


