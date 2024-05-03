using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// ProductModel class
    /// </summary>
    public class ProductModel
    {
        //Getter and Setter of Id
        public string Id { get; set; }

        //Getter and Setter of Maker who made the product
        public string Maker { get; set; }

        //Getter and Setter of Image
        [JsonPropertyName("img")]
        public string Image { get; set; }

        //Getter and Setter of URL . This in URL that has more description
        public string Url { get; set; }

        //Getter and Setter of Title
        public string Title { get; set; }

        //Getter and Setter of Description
        public string Description { get; set; }

        //Getter and Setter of Ratings
        public int[] Ratings { get; set; }

        //Getter and Setter of ProductType (enum)
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Undefined;

        //Getter and Setter of Quantity
        public int Quantity { get; set; }

        //Getter and Setter of Price
        public decimal Price { get; set; }

        // Store the Comments entered by the users on this product
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        //Serializes it to a String
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

        public ProductModel DeepCopy()
        {
            // New ProductModel to copy everything to
            ProductModel deepCopyModel = new ProductModel();
            deepCopyModel.Id = this.Id;
            deepCopyModel.Maker = this.Maker;
            deepCopyModel.Image = this.Image;
            deepCopyModel.Url = this.Url;
            deepCopyModel.Title = this.Title;
            deepCopyModel.Description = this.Description;
            deepCopyModel.ProductType = this.ProductType;
            deepCopyModel.Quantity = this.Quantity;
            deepCopyModel.Price = this.Price;
            deepCopyModel.CommentList = this.CommentList;

            if (this.Ratings == null)
            {
                return deepCopyModel;
            }

            deepCopyModel.Ratings = new int[this.Ratings.Length];
            this.Ratings.CopyTo(deepCopyModel.Ratings, 0);
            return deepCopyModel;
        }

    }
}