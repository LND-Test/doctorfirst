using Google.Apis.Gmail.v1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using MimeKit;
using TodoApi1.Helpers;
using TodoApi1.Models;

namespace TodoApi1.Controllers
{
   
    [Route("api/[controller]/[action]")]
     [ApiController]
    public class EmailController : ControllerBase
    {
        // Store OTPs with Expiry Time
        private static readonly ConcurrentDictionary<string, (string OTP, DateTime Expiry)> _otpStorage = new ConcurrentDictionary<string, (string, DateTime)>();
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {

            if (request == null || string.IsNullOrEmpty(request.Email))
            {
                return BadRequest("Email address is required.");
            }

                // Generate a 4-digit OTP
            var otp = new Random().Next(1000, 9999).ToString();
            var expiryTime = DateTime.UtcNow.AddMinutes(5); // OTP expires in 5 minutes

            // Store OTP with expiry
            _otpStorage[request.Email] = (otp, expiryTime);

            var gmailService = await GmailServiceHelper.GetGmailServiceAsync();

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("DoctorFirst", "innocent.crazyboy@gmail.com"));//Sender details
            email.To.Add(new MailboxAddress("Tester", request.Email));//Receiver details
            email.Subject = "Your OTP Code";
            email.Body = new TextPart("plain")
            {
                Text =  $"Your OTP is: {otp}. It will expire in 5 minutes."
            };

            var rawMessage = Base64UrlEncode(email.ToString());

            var message = new Message
            {
                Raw = rawMessage
            };

            await gmailService.Users.Messages.Send(message, "me").ExecuteAsync();

            return Ok(new { Message = "OTP sent successfully.", Expiry = expiryTime });
        }
        public IActionResult VerifyOtp([FromBody] VerifyOtpRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.OTP))
            {
                return BadRequest("Email and OTP are required.");
            }

            if (_otpStorage.TryGetValue(request.Email, out var storedOtp))
            {
                if (storedOtp.Expiry < DateTime.UtcNow)
                {
                    _otpStorage.TryRemove(request.Email, out _);
                    return BadRequest("OTP has expired.");
                }

                if (storedOtp.OTP == request.OTP)
                {
                    _otpStorage.TryRemove(request.Email, out _);
                    return Ok("OTP verified successfully.");
                }

                return BadRequest("Invalid OTP.");
            }

            return BadRequest("No OTP found for this email.");
        }
        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }
        
    }
    public class EmailRequest
    {
        public string Email { get; set; }
    }

    public class VerifyOtpRequest
    {
        public string Email { get; set; }
        public string OTP { get; set; }
    }
}

