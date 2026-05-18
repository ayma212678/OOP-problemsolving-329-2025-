namespace Challenge2
{
    class MUser
    {
        //--- properties ---
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }  //--- "admin" or "customer" ---

        //--- constructor ---
        public MUser(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}