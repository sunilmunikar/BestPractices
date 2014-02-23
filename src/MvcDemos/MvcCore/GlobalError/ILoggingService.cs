using System;

namespace MvcDemos.MvcCore.GlobalError
{
    public interface ILoggingService
    {
        void Error(Exception exception);
    }
}
