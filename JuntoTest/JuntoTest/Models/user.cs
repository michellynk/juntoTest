namespace JuntoTest.Models
{
    public class user
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public user(int uId, string uName, string uPassword, string uToken)
        {
            this.Id = uId;
            this.Name = uName;
            this.Password = uPassword;
            this.Token = uToken;
        }
    }
}