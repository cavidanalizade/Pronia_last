﻿using System.ComponentModel.DataAnnotations;

namespace ProniaAdmin.ViewModels.Account
{
    public class RegisterVm
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(25)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
