using System;

namespace Zing.Framework.Logging {
    public interface ILoggerFactory {
        ILogger CreateLogger(Type type);
    }
}