using System;

namespace MvcDemos.Core.GlobalError
{
    public interface ILoggingService
    {
        void Error(Exception exception);
    }
}
