using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarpDev_Derick.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,16}$", ErrorMessage = @"Password field must contain between 8 and 16 characters, 1 upper case character, 1 lowercase character, 1 numeric character and 1 special character (!,#,@,*,/,\,%,_).")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Password fields must be the same.")]
        public string Conf_Password { get; set; }
        public string Country { get; set; }
        [DisplayName("Favourite Colour")]
        public string Colour { get; set; }
        [DataType(DataType.Date)]
        public string Birthday { get; set; }
        [DisplayName("Cell Phone Number")]
        [RegularExpression("(^0[0-9]{9}$)", ErrorMessage = "Please enter a valid cell phone number e.g 0123456789")]
        public string Cell { get; set; }
        public string Comments { get; set; }

        public PersonModel()
        {
            ID = -1;
            Name = "";
            Surname = "";
            Email = "";
            Password = "";
            Conf_Password = "";
            Country = "South Africa";
            Colour = "";
            Birthday = "";
            Cell = "";
            Comments = "";
        }

        public PersonModel(int iD, string name, string surname, string email, string password, string conf_Password, string country, string colour, string birthday, string cell, string comments)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Conf_Password = conf_Password;
            Country = country;
            Colour = colour;
            Birthday = birthday;
            Cell = cell;
            Comments = comments;
        }

    }
}