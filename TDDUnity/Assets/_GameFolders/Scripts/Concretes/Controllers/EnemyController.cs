using TDDUnity.Abstracts.Combats;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.ScriptableObjects;
using TDDUnity.Combats;
using TDDUnity.ScriptableObjects;
using UnityEngine;

namespace TDDUnity.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] EnemyStats _stats;

        public IAttacker Attacker { get; private set; }
        public IEnemyStats Stats => _stats;

        void Awake()
        {
            Attacker = new Attacker(stats: Stats);
        }

        void OnCollisionEnter2D(Collision2D collisionOther)
        {
            if (collisionOther.collider.TryGetComponent(out IPlayerController playerController))
            {
                Debug.Log(this.gameObject.name +" => OnCollisionEnter2D => " + collisionOther.gameObject.name);

                playerController.Health.TakeDamage(attacker: Attacker);

            }
        }
    }
}

