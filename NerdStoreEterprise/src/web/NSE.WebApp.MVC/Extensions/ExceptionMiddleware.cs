using Refit;
using System.Net;

namespace NSE.WebApp.MVC.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomHttpRequestException ex)
            {
                HandleRequestExceptionAsync(context, ex.StatusCode);
            }
            catch (ValidationApiException ex) // ValidationApiException é do Refit, não é obrigatório usar o Refit, ainda prefiro o HttpClient
            {
                HandleRequestExceptionAsync(context, ex.StatusCode);
            }
            catch (ApiException ex)
            {
                HandleRequestExceptionAsync(context, ex.StatusCode);
            }
        }

        public void HandleRequestExceptionAsync(HttpContext context, HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                // O ReturnUrl, quando a pessoa fizer o Login, ele será automaticamente redirecionado para o PATH informado. Precisa alterar em outro local também.
                // foi alterado também na controller de Login (IdentidadeController.cs) e também alterado na View de Login
                context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
                return;
            }

            context.Response.StatusCode = (int)statusCode;
        }
    }
}
