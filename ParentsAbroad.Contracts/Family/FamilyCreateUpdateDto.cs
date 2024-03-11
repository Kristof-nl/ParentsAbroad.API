using ParentsAbroad.Contracts.Address;

namespace ParentsAbroad.Contracts.Family
{
    public class FamilyCreateUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}
