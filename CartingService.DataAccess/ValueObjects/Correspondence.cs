namespace CartingService.DataAccess.ValueObjects;

public class Correspondence
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public List<Contact> Contacts { get; set; }
}