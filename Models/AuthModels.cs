namespace TodoApi1.Models
{
    public class AuthModels
    {
        public class RegisterDto
        {
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string RePassword { get; set; }
        }

        public class LoginDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class VerifyOtpDto
        {
            public string Email { get; set; }
            public string OTPCode { get; set; }
        }

    }

}
