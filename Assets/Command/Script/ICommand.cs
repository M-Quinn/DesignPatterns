
namespace dev.MikeQ.Command {
    public interface ICommand 
    {
        void Execute();
        void Undo();
    }
}

