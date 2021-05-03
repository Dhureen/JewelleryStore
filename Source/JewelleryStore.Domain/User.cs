using System;

namespace JewelleryStore.Domain
{
    public class User
    {
        public User(int id, string name, int discountPercentage, UserType userType)
        {
            if (id < 1 || string.IsNullOrEmpty(name))
                throw new Exception();
            Id = id;
            Name = name;
            Type = userType;
            DiscountPercentage = Type == UserType.Privileged ? discountPercentage : 0;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountPercentage { get; set; }
        public UserType Type { get; set; }
    }
}
