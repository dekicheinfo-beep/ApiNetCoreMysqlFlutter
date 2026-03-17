namespace RestApiMysqlSdk9.Models
{
    public class ProductDto
    {

        public string Name { get; set; } = null!;

        public double Price { get; set; }
        public IFormFile? PhotoUrl { get; set; }
    }
}
