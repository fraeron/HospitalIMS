using System.Configuration;
using System.Collections.Specialized;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Text.RegularExpressions;

namespace HospitalIMSServices
{
    public class MailkitServices
    {
        private string currentError = "";
        private string USERNAME = "ENTER-USERNAME"; // TODO: Use App.config.
        private string PASSWORD = "ENTER-PASSWORD";

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
                    //Console.WriteLine(ConfigurationManager.AppSettings.Get("Username"));
                    //Console.WriteLine(ConfigurationManager.AppSettings.Get("Password"));
                    client.Authenticate(
                        USERNAME, 
                        PASSWORD
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

        public string SendAppointmentAndReturnContent(string emailMessage, string emailSubject)
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
                    //Console.WriteLine(ConfigurationManager.AppSettings.Get("Username"));
                    //Console.WriteLine(ConfigurationManager.AppSettings.Get("Password"));
                    client.Authenticate(
                        USERNAME,
                        PASSWORD
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
            // Remove HTML tags before returning for better viewing.
            return Regex.Replace("\t" + emailSubject + "\n\n" + emailMessage.TrimStart(), "<.*?>|p{margin:0}", String.Empty);
        }
    }
}
