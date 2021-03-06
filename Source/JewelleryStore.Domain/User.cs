using System;

namespace JewelleryStore.Domain
{
    public class User
    {
        public User(int id, string name, int discountPercentage, UserType userType)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception($"{nameof(Name)} is empty");
            Id = id;
            Name = name;
            Type = userType;
            DiscountPercentage = Type == UserType.Privileged ? discountPercentage : 0;
        }

        public int Id { get; }
        public string Name { get;}
        public int DiscountPercentage { get;}
        public UserType Type { get;}
    }
}
