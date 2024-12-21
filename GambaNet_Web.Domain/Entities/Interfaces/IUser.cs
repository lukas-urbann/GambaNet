namespace GambaNet_Web.Domain.Entities.Interfaces
{
    //Tady pak bude list transakcí (historii výher/proher/dobití kreditu)
    public interface IUser<TKey> : IEntity<TKey>
    {
        string? UserName { get; set; }
        string? Email { get; set; }
        DateTime? StartDate { get; set; }
        Decimal? Balance { get; set; }
        
        string? PhoneNumber { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
    }
}
