using System;

namespace Playground.DI.Impl
{
    public class DefaultOperation :
        ITransientOperation,
        IScopedOperation,
        ISingletonOperation
    {
        public string OperationId { get; } = Guid.NewGuid().ToString()[^4..];
    }
}