using System;

//TODO: Comments

namespace SaggezzaApp
{
    public class UserDataViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }

        //public UserDataViewModel(UserData data)
        //{
        //    Id = data.Id;
        //    Name = data.Name;
        //    GivenName = data.GivenName;
        //    FamilyName = data.FamilyName;
        //    Email = data.Email;
        //}

        public UserDataViewModel()
        {
        }

        public void Update(string id, string name, string givenName, string familyName, string email)
        {
            Id = id;
            Name = name;
            GivenName = givenName;
            FamilyName = familyName;
            Email = email;
        }
    }
}
