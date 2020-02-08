using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VClassroom.CourseManagement.Api.Extensions
{
    public static class ClaimsExtension
    {
        public static string GetUserId(this HttpContext context)
        {
            return context.Request.Headers["UserId"];
        }
    }
}
