using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace slackbot.Middleware
{
    public class TokenValidator
    {
        private readonly RequestDelegate _next;
        private readonly string _validToken;

        public TokenValidator(RequestDelegate next, string validToken)
        {
            if (next == null)
                throw new ArgumentNullException(nameof(next));
            if(validToken == null)
                throw new ArgumentNullException(nameof(validToken));
            _next = next;
            _validToken = validToken;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.ContentType != "application/x-www-form-urlencoded" ||
            context.Request.Form["token"].ToString() != _validToken)
            {
                context.Response.StatusCode = 403;
                return;
            }

            await _next(context);
        }
    }
}