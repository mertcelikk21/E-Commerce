﻿using System.ComponentModel.DataAnnotations;

namespace eTicaret.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression
            (
            "(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$"
            ,ErrorMessage ="Şifreniz bir büyük karakter, bir küçük karakter ve bir rakam içermelidir"
            )]
        public string Password { get; set; }

    }
}
