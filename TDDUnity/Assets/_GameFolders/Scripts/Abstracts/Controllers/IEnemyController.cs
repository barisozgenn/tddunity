using TDDUnity.Abstracts.Combats;
using TDDUnity.Abstracts.ScriptableObjects;

namespace TDDUnity.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IAttacker Attacker { get; }
        public IEnemyStats Stats { get; }
    }
}
