﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace slackbot.Middleware
{
    public class EnforceHttps
    {
        private readonly RequestDelegate _next;

        public EnforceHttps(RequestDelegate next)
        {
            if (next == null)
                throw new ArgumentNullException(nameof(next));
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.IsHttps)
            {
                context.Response.Redirect($"https://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}", true);
                return;
            }

            await _next(context);
        }
    }
}
