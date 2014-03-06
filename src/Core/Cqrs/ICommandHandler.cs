namespace Core.Command
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
