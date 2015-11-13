using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace demo.xamarin.forms.Model
{
    public class UserResult
    {
        public List<UserEntry> Results { get; set; }
    }

    public class UserEntry
    {
        public User User { get; set; }
    }

    public class User
    {
        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }
        public int Registered { get; set; }
        public int Dob { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string NINO { get; set; }
        public Picture Picture { get; set; }

        public ImageSource Image
        {
            get
            {
                var imagen = new UriImageSource()
                {
                    CachingEnabled = true,
                    Uri = new Uri(Picture.medium),
                };
                return imagen;

            }
        }

        public ImageSource LargeImage
        {
            get
            {
                var imagen = new UriImageSource()
                {
                    CachingEnabled = true,
                    Uri = new Uri(Picture.large),
                };
                return imagen;

            }
        }
    }
}