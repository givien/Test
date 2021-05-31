using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using DirectScale.Disco.Extension.Hooks.Orders;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Associates;
using DirectScale.Disco.Extension.Hooks.Autoships;
using DirectScale.Disco.Extension.Hooks.Commissions;
using DirectScale.Disco.Extension.Services;
namespace bombshells.Hooks
{
    public class SendGridHook2 : IHook<LogRealtimeRankAdvanceHookRequest, LogRealtimeRankAdvanceHookResponse> // This hook is triggered when an ambassador gets a new sale
    {
        //private readonly IAssociateService _associateService;
        public LogRealtimeRankAdvanceHookResponse Invoke(LogRealtimeRankAdvanceHookRequest request, Func<LogRealtimeRankAdvanceHookRequest, LogRealtimeRankAdvanceHookResponse> func)
        {
            int associateId = request.AssociateId;
            int newRank = request.NewRank;
            #region Get associate's email and the highest rank ever
            string email = "";
            int highestRankEver = 0;
            #endregion
            if (newRank > highestRankEver)
            {
                Email1(email).Wait(); // in case the new rank is now her highest one
            }
            else
            {
                Email2(email).Wait(); // in case she's ever had higher or equal rank than the new one
            }
            return func(request);
        }
        static async Task Email1(string email)
        {
            var client = new SendGridClient("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"); // API key
            var from = new EmailAddress("givien@glowb.team", "Givi"); // From
            var subject = "Sending with SendGrid is Fun"; // Email Subject
            var to = new EmailAddress("givien@glowb.team"); // To
            var plainTextContent = ""; // Don't touch it
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>"; // Email Body
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent); // Don't touch it
            var response = await client.SendEmailAsync(msg); // Don't touch it
        }
        static async Task Email2(string email)
        {
            var client = new SendGridClient("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"); // API key
            var from = new EmailAddress("givien@glowb.team", "Givi"); // From
            var subject = "Sending with SendGrid is Fun"; // Email Subject
            var to = new EmailAddress("givien@glowb.team"); // To
            var plainTextContent = ""; // Don't touch it
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>"; // Email Body
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent); // Don't touch it
            var response = await client.SendEmailAsync(msg); // Don't touch it
        }
    }
}
