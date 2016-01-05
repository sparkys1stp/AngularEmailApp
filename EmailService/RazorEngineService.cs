using System;
using System.IO;
using System.Reflection;
using EmailService.Models;
using RazorEngine;
using RazorEngine.Templating;

namespace EmailService
{
    public class RazorEngineService
    {
        private const string ViewPathTemplate = "EmailService.EmailTemplates";
        private const string SendEmailView = "SendEmail.cshtml";
        private const string EmailLayoutView = "_EmailLayout.cshtml";

        public string ParseEmailTemplate(EmailMessageVM emailMessageVM)
        {
            Engine.Razor.Compile(ConvertViewToString(EmailLayoutView), "EmailMailerLayout");

            var myParsedTemplate = Engine.Razor.RunCompile(ConvertViewToString(SendEmailView), "SendEmailView", null, emailMessageVM);
            return myParsedTemplate;
        }

        public string ConvertViewToString(string viewName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("{0}.{1}", ViewPathTemplate, viewName));

            if (stream == null)
                throw new Exception("Unable to process Razor Template");
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}