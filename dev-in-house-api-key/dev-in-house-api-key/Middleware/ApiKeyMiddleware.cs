namespace dev_in_house_api_key.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HEADER_API_KEY = "ApiKey";
        private const string SECRETS_API_KEY = "33BA0426-15DF-4C58-8383-563001028C98";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var apiKeyRequest = context!.Request!.QueryString!.Value!.Split('=')[1];

            //if (!context!.Request.Headers.TryGetValue(HEADER_API_KEY, out var apiKeyRequest))
            //{
            //    context.Response.StatusCode = 404;
            //    await context.Response.WriteAsync("Heder sem a chave API KEY");
            //    return;
            //}

            if (!apiKeyRequest.Equals(SECRETS_API_KEY))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Autorização Negada");
                return;
            }

            await _next(context);
        }
    }
}
