namespace ResourceServer.DTO
{
    public interface IVisitorDTO
    {
        string FullName { get; set; }
        string SSN { get; set; }
        string CountryName { get; set; }
        string PassportNo { get; set; }
        string Company { get; set; }
        string City { get; set; }
    }
}
