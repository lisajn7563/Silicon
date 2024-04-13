using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string? FirstName { get; set; }

    [ProtectedPersonalData]
    public string? LastName { get; set; } 
    public string? ProfileImage { get; set; } = "profile.svg";
    public bool IsExternal { get; set; }
    public string? Bio { get; set; }
    
    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }

}

public class AddressEntity
{
    public int Id { get; set; }
    public string AddressLine_1 { get; set; } = null!;
    public string? AddressLine_2 { get; set; } 
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    
}