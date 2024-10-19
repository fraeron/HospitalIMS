﻿using System.Configuration;
using System.Collections.Specialized;
using MailKit.Net.Smtp;
using MimeKit;

namespace HospitalIMSServices
{
    public class MailkitServices
    {
        private string currentError = "";


        public string GetCurrentError()
        {
            return currentError;
        }

        public bool SendAppointment(string emailMessage, string emailSubject)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Pedro Grace Hospital", "do-not-reply@pedrohospital.com"));
            message.To.Add(new MailboxAddress("Patient", "samplepatient@email.com"));
            message.Subject = emailSubject;

            message.Body = new TextPart("html")
            {
                 Text = emailMessage
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    
                    client.Authenticate(
                        ConfigurationManager.AppSettings.Get("Username"),
                        ConfigurationManager.AppSettings.Get("Password")
                        );
                    client.Send(message);
                    currentError = "";
                }
                catch (System.Exception ex)
                {
                    currentError = ex.Message;
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
            return currentError.Length != 0 ? false : true;
        }
    }
}