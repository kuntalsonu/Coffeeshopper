using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Client.Services
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> identityServerSettings;
        public readonly DiscoveryDocumentResponse discoveryDocumentResponse;
        public readonly HttpClient httpClient;

        public TokenService(IOptions<IdentityServerSettings> identityServerSettings)
        {
            this.identityServerSettings = identityServerSettings;
            httpClient = new HttpClient();
            discoveryDocumentResponse = httpClient.GetDiscoveryDocumentAsync(this.identityServerSettings.Value.DiscoveryUrl).Result;
            if(discoveryDocumentResponse.IsError)
            {
                throw new Exception("Unable to get discovery document",discoveryDocumentResponse.Exception);
            }
            
        }

        public async Task<TokenResponse> GetToken(string scope)
        {
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocumentResponse.TokenEndpoint,
                ClientId = identityServerSettings.Value.ClientName,
                ClientSecret=identityServerSettings.Value.ClientPassword,
                Scope = scope
            });
            if (tokenResponse.IsError)
            {
                throw new Exception("Unable to get Token",tokenResponse.Exception);
            }
            return tokenResponse;
        }
    }
}
