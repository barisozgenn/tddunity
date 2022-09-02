using TDDUnity.Abstracts.Combats;
using TDDUnity.Abstracts.Inputs;
using TDDUnity.Abstracts.ScriptableObjects;

namespace TDDUnity.Abstracts.Controllers
{
    public interface IPlayerController: IEntityController
    {
        IInputReader InputReader { get; set; }
        IPlayerStats Stats { get; }
        IHealth Health { get; }
    }
}
