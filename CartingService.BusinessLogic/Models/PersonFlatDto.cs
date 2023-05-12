namespace CartingService.BusinessLogic.Models;

public class PersonFlatDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; }
    public string Occupation { get; set; }
    public string Employer { get; set; }
    public string EducationLevel { get; set; }
    public decimal Income { get; set; }
    public string MaritalStatus { get; set; }
    public Person Spouse { get; set; }
    public List<Person> Children { get; set; }
    public string CorrespondenceStreet { get; set; }
    public string CorrespondenceCity { get; set; }
    public string CorrespondenceState { get; set; }
    public string CorrespondenceZipCode { get; set; }
    public List<ContactDto> CorrespondenceContacts { get; set; }
}