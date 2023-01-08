namespace DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImgUrl { get; set; }
        public int? GuarantyMonth { get; set; }
        public string? CountryOfProduction { get; set; }

}
}