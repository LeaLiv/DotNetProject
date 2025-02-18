

namespace DO
{
    public record Customer
        (int Id,
        string? Name = null,
        string? Address = null,
        string? PhoneNumber = null)
    {
        public Customer() : this (0)
        { }
    }
}
