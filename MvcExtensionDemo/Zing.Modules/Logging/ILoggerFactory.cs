using System;

namespace Zing.Modules.Logging {
    public interface ILoggerFactory {
        ILogger CreateLogger(Type type);
    }
}