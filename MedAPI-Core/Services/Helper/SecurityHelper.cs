using Repository.DTOs;
using System;
using System.Net.Http;
using System.Web;

namespace Services.Helpers
{
    public class SecurityHelper
    {
        public static string GetEmailConfirmatioLink(User mUser, HttpRequestMessage Request)
        {
            var tokenHash = HttpUtility.UrlEncode(HashPasswordHelper.HashToken(mUser.token).ToString());
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            return $"{baseUrl}/account-confirm?id={mUser.id}&code={tokenHash}";
        }

        public static string GetPasswordResetLink(User mUser, HttpRequestMessage Request)
        {
            var tokenHash = HttpUtility.UrlEncode(HashPasswordHelper.HashToken(mUser.reset_token));
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            return $"{baseUrl}/reset-password?id={mUser.id}&code={tokenHash}";
        }

        public static string GetLabNotificationLink(User user, HttpRequestMessage Request)
        {
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            return $"{baseUrl}/records/{user.documentNumber}";

        }

        
        public static string GetAccountSettingLink(HttpRequestMessage Request)
        {
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            return $"{baseUrl}/account-setting";

        }

    }
}
