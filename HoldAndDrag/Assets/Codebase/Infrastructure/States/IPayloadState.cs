namespace Codebase.Infrastructure.States
{
    public interface IPayloadState<TPayload> : IState
    {
        void Enter(TPayload payload);
    }
}