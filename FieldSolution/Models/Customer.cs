using System.ComponentModel.DataAnnotations;

namespace FieldSolution.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string? Salutation { get; set; }

        public string? Initials { get; set; }

        public string? FirstName { get; set; }

        public string? firstname_ascii { get; set; }

        public string? Gender { get; set; }

        public string? firstname_country_rank { get; set; }

        public string? firstname_country_frequency { get; set; }

        public string? LastName { get; set; }

        public string? lastname_ascii { get; set; }

        public string? lastname_country_rank { get; set; }

        public string? lastname_country_frequency { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Country_Code { get; set; }

        public string? country_code_alpha { get; set; }

        public string? country_name { get; set; }

        public string? primary_language_code { get; set; }

        public string? primary_language { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Phone]
        public string? Phone_Number { get; set; }

        public string? Currency { get; set; }
    }
}
