using System;

namespace TestApp
{
    public class Rent
    {
        public User Rentee { get; set; }

        public bool CanReturn(User user) => user == null ? throw new ArgumentNullException() : Rentee == user || user.IsAdmin;

    }


    public class User
    {
        public bool IsAdmin { get; set; }
    }

}
