using Microsoft.AspNetCore.Mvc.Filters;

namespace VClassroom.Authentication.Api
{
    internal class CorsAuthorizationFilterFactory : IFilterMetadata
    {
        private string v;

        public CorsAuthorizationFilterFactory(string v)
        {
            this.v = v;
        }
    }
}