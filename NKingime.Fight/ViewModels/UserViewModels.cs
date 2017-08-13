﻿using System.ComponentModel.DataAnnotations;

namespace NKingime.Fight.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "用户名")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "请记住我")]
        public bool RememberMe { get; set; }
    }
}
