using System.Collections.Immutable;
using Microsoft.Extensions.Options;
using OpenIddict.Abstractions;
using Shop.API.Configuration;
using Shop.DAL.Contexts;

namespace Shop.API.Clients
{
    public class PostmanClient : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ClientsOptions _clients;

        public PostmanClient(IServiceProvider serviceProvider, IOptions<ClientsOptions> clients)
        {
            _serviceProvider = serviceProvider;
            _clients = clients.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ShopContext>();

            var manager =
                scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

            foreach (var client in _clients.ClientsArr)
            {
                if (await manager.FindByClientIdAsync(client.ClientId, cancellationToken) == null)
                {
                    OpenIddictApplicationDescriptor appDescriptor = new()
                    {
                        ClientId = client.ClientId,
                        ClientSecret = client.ClientSecret,
                        DisplayName = client.DisplayName,
                    };

                    appDescriptor.RedirectUris.UnionWith(client.RedirectUris);
                    appDescriptor.Permissions.UnionWith(client.Permissions);

                    await manager.CreateAsync(appDescriptor, cancellationToken);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}