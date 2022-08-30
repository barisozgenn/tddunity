using TDDUnity.Abstracts.Inputs;

namespace TDDUnity.Abstracts.Controllers
{
    public interface IPlayerController: IEntityController
    {
        IInputReader InputReader { get; set; }
    }
}
