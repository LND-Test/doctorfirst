namespace TodoApi1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string UserName { get; set; }
        public bool IsVerified { get; set; }
        public string OTP { get; set; }
        public DateTime OTPExpiry { get; set; }
    }

}
