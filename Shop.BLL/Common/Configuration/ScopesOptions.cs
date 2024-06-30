namespace Shop.BLL.Common.Configuration
{
    public class ScopesOptions
    {
        public const string Scopes = "Scopes";

        public IEnumerable<string> ValidScopes { get; set; } = null!;
    }
}