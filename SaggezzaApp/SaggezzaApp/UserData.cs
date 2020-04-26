using System;
namespace SaggezzaApp
{
    /*
        Description: This page holds the C# code for back end processing and retrival of the user data.
        Authors:Cameron Chrisholm
        Release Date: 03/03/2020
        Last editied: 10/04/2020
    */
    // User's info is store as UserData object
    public class UserData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }

    }
}
