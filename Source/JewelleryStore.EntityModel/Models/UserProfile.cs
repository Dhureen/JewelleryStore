namespace JewelleryStore.EntityModel
{
    public partial class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public double? DiscountPercentage { get; set; }
        public string Password { get; set; }
    }
}
