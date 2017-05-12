﻿using System.Threading.Tasks;

namespace Rwby.Global.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
