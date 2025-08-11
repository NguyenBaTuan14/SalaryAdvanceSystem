﻿using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.DTOs
{
    public class ChangePassDto
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
