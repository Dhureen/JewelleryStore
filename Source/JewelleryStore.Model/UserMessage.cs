using System;

namespace JewelleryStore.Model
{
    public class UserMessage
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountPercentage { get; set; }
        public UserTypeMessage Type { get; set; }
    }
}
