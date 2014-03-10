using Core.Services.Validation;

namespace Core.Command
{
    public class ValidationCommandHandlerDecorator<TCommand>
        : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private ICommandHandler<TCommand> decoratee;
        private IValidator<TCommand> validator;

        public ValidationCommandHandlerDecorator(
            ICommandHandler<TCommand> decoratee,
            IValidator<TCommand> validator)
        {
            this.decoratee = decoratee;
            this.validator = validator;
        }

        public void Handle(TCommand command)
        {
            validator.Validate(command);
            decoratee.Handle(command);
        }
    }
}