using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.Security
{
    public interface IUserService
    {
        bool VerifyUserUnicity(string userName, string email);
        bool VerifyUserUnicity(int id, string userName, string email);

        void SendChallengeEmail(IUser user, Func<string, string> createUrl);
        IUser ValidateChallenge(string challengeToken);

        bool SendLostPasswordEmail(string usernameOrEmail, Func<string, string> createUrl);
        IUser ValidateLostPassword(string nonce);

        string CreateNonce(IUser user, TimeSpan delay);
        bool DecryptNonce(string challengeToken, out string username, out DateTime validateByUtc);
    }
}
