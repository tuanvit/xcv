using Shopping.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
	public class ProductModel
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập tên sản phẩm ")]
		public string Name { get; set; }
		public string Slug { get; set; }

		[Required, MinLength(4, ErrorMessage = "Vui lòng mô tả sản phẩm")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập giá sản phẩm ")]
		[Range(0.01,double.MaxValue)]
		[Column(TypeName="decimal(8,2)")]
		public decimal Price { get; set; }

        [Required, Range (1, int.MaxValue, ErrorMessage = "Chọn một thương hiệu")]

		public int BrandId { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Chọn một danh mục")]
        public int CategoryId { get; set; }

		public BrandModel Brand { get; set; }
        public CategoryModel Category { get; set; }
		public string Image { get; set; }

		[NotMapped]
		[FileExtention]
        public IFormFile? ImageUpload { get; set; }


    }
}
