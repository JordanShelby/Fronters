namespace Volt.Models;

public class Tab
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<User> Users { get; set; }
    public DateTime CreatedDate { get; set; }   
    public string CreatedId { get; set; }
    public string Total { get; set; }
    public string DeliveryDate { get; set; }
}
