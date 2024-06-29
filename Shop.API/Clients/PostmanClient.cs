
using Microsoft.OpenApi.Writers;
using OpenIddict.Abstractions;
using Shop.DAL.Contexts;

namespace Shop.API.Clients
{
    public class PostmanClient : IHostedService
    {
        private readonly string _clientId = "postman";
        private readonly IServiceProvider _serviceProvider;

        public PostmanClient(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ShopContext>();

            var manager =
                scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

            if (await manager.FindByClientIdAsync("postman", cancellationToken) == null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor()
                {
                    ClientId = _clientId,
                    ClientSecret = "postman-secret",
                    DisplayName = "Postman",
                    RedirectUris = { new Uri("https://oauth.pstmn.io/v1/callback") },

                    Permissions =
                    {
                        OpenIddictConstants.Permissions.Endpoints.Token,

                        OpenIddictConstants.GrantTypes.Password,
                        OpenIddictConstants.GrantTypes.RefreshToken,

                        OpenIddictConstants.Permissions.Prefixes.Scope + "api.shop.games"
                    }
                }, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}