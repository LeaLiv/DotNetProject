

namespace BO;
public class Customer
{
    public int Id;
    public string? Name;
    public string? Address;
    public string? PhoneNumber;
    public override string ToString() => this.ToStringProperty();
    public Customer(int id,string? name,string? address ,string? phoneNumber )
    {
        Id = id;
        Name = name; 
        Address = address;
        PhoneNumber = phoneNumber;
    }
}

