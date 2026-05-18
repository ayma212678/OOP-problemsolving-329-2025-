namespace Challenge2
{
    class MUserDL
    {
        //--- in-memory user storage ---
        private static List<MUser> users = new List<MUser>();

        //--- add a new user ---
        public static void AddUser(MUser u)
        {
            users.Add(u);
        }

        //--- find user by credentials, returns null if not found ---
        public static MUser FindUser(string username, string password)
        {
            foreach (MUser u in users)
                if (u.Username == username && u.Password == password)
                    return u;
            return null;
        }

        //--- check if username already exists ---
        public static bool UsernameExists(string username)
        {
            foreach (MUser u in users)
                if (u.Username == username) return true;
            return false;
        }
    }
}