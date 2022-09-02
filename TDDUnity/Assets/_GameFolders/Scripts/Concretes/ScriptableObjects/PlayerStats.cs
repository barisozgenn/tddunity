using System.Collections;
using TDDUnity.Abstracts.ScriptableObjects;
using UnityEngine;

namespace TDDUnity.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats", menuName = "Baris Gaming/Stats/Player Stats")]
    public class PlayerStats : Stats, IPlayerStats
    {
        public float JumpForce => 0;
    }
}


