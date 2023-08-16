using EKLEXIA.Data;
using EKLEXIA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EKLEXIA.Services
{
    public class EmailSMSService : BackgroundService
    {
      public readonly XContext ctx;
        public EmailSMSService( XContext context)
        {
            ctx = context;
        }

        protected async override  Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
            
                Member member = new();

            //we creating the necessary URL string:
            string GeneratedID = (from m in ctx.Members where m.MemberId == member.MemberId select m.IDNumber).FirstOrDefault().ToString()
                       ;
                string URL = "https://frog.wigal.com.gh/ismsweb/sendmsg?";
                string from = "JHC";
                string username = "KofiPoku";
                string password = "Az36400@osp";
                string to = member.Telephone;
                string messageText = "Thank you for joining Joy House Chapel. Your church ID is" + GeneratedID + "You are Welcome";

                // Creating URL to send sms
                string message = URL
                    + "username="
                    + username
                    + "&password="
                    + password
                    + "&from="
                    + from
                    + "&to="
                    + to
                    + "&service="
                    + "SMS"
                    + "&message="
                    + messageText;



                HttpClient httpclient = new();

            var response2 = await httpclient.SendAsync(new HttpRequestMessage(HttpMethod.Post, message), stoppingToken);
                if (response2.StatusCode == HttpStatusCode.OK)
                {
                    // Do something with response. Example get content:
                    // var responseContent = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
                }

            await Task.CompletedTask;

            }
        }
    }

