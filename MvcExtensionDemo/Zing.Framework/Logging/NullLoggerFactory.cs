using System;

namespace Zing.Framework.Logging {
    class NullLoggerFactory : ILoggerFactory {
        public ILogger CreateLogger(Type type) {
            return NullLogger.Instance;
        }
    }
}