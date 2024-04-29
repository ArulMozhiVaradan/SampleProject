﻿using SampleProject.Application.BaseFeatures;
using System.Text.Json;

namespace SampleProject.API.BaseMiddlewares;

public class ForbiddenMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        await next(context);

        if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
        {
            var result = new BaseResult();
            result.Forbidden();

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
