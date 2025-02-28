using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace TodoApi1.Helpers
{
    public class GmailServiceHelper
    {
        private static readonly string[] Scopes = { GmailService.Scope.GmailSend };
        private static readonly string ApplicationName = "project-1020759427956";

        public static async Task<GmailService> GetGmailServiceAsync()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // Specify the path to save token.json in your project directory
                string credPath = Path.Combine(Directory.GetCurrentDirectory(), "token.json");

                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));

            }

            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }
    }
}
