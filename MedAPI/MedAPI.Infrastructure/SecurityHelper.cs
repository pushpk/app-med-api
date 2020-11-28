using MedAPI.Domain;
using System;
using System.Net.Http;

namespace MedAPI.Infrastructure
{
    public class SecurityHelper
    {
        public static string GetEmailConfirmatioLink(User mUser, HttpRequestMessage Request)
        {
            var tokenHash = Infrastructure.HashPasswordHelper.HashToken(mUser.token);
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            return $"{baseUrl}/account-confirm/id={mUser.id}&code={tokenHash}";
        }


    }
}
