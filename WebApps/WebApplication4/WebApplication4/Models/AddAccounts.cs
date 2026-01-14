using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models.accounts;

public class AddAccounts
{


    [Required(ErrorMessage = "Id is required.")]
    public int Id { get; set; }

    //[StringLength(MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters long.")]
    public string Name { get; set; }
    public Gender Gender { get; set; }
}
