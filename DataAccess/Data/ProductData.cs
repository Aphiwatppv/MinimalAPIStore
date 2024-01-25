using DataAccess.DbAccess;
using DataAccess.Models;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Data
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess _dataAccess;

        // connect to database 

        public ProductData(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        /// <summary>
        /// Asynchronously retrieves all products from the database.
        /// </summary>
        /// <returns>A collection of ProductModel objects, representing all products.</returns>
        public Task<IEnumerable<ProductModel>> GetAllproducts() =>
            _dataAccess.LoadData<ProductModel, dynamic>(storedProcedure: "dbo.sp_GetAllProducts", new { });

        /// <summary>
        /// Asynchronously adds a new product to the database.
        /// </summary>
        /// <param name="product">The ProductModel object containing the product details to be added.</param>
        /// <returns>A task representing the asynchronous operation of adding the product.</returns>
        public Task AddnewProduct(ProductModel product) =>
            _dataAccess.SaveData(
                storedProcedure: "dbo.sp_AddNewProduct",
                new
                {
                    product.Product_Id,
                    product.Product_Name,
                    product.Remaining_Stock,
                    product.Product_unit,
                    product.Alert_limit,
                    product.Add_by,
                    product.Product_Price,
                    product.Price_Unit,
                    product.Update_By
                }
            );


        /// <summary>
        /// Asynchronously increases the stock of a product.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="incrementAmount">The amount to increase the product's stock.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task IncreaseProductStock(int productId, int incrementAmount)
        {
            return _dataAccess.SaveData(
                storedProcedure: "dbo.sp_IncreaseProductStock",
                new { Product_Id = productId, IncrementAmount = incrementAmount }
            );
        }

        /// <summary>
        /// Asynchronously retrieves the details of a specific product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product whose details are to be retrieved.</param>
        /// <returns>A task representing the asynchronous operation, resulting in the ProductModel object.</returns>
        public async Task<ProductModel?> GetProductDetails(int productId)
        {
            var result = await _dataAccess.LoadData<ProductModel, dynamic>(
                storedProcedure: "dbo.sp_GetProductDetails",
                new { Product_Id = productId }
            );

            return result.FirstOrDefault();
        }
        /// <summary>
        /// Asynchronously decreases the stock of a product.
        /// </summary>
        /// <param name="productId">The ID of the product whose stock is to be decreased.</param>
        /// <param name="decrementAmount">The amount by which the product's stock is to be decreased.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stock is insufficient to reduce.</exception>
        public Task ReduceProductStock(int productId, int decrementAmount)
        {
            return _dataAccess.SaveData(
                storedProcedure: "dbo.sp_ReduceProductStock",
                new { Product_Id = productId, DecrementAmount = decrementAmount }
            );
        }

        /// <summary>
        /// Asynchronously removes a product from the database based on its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to be removed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task RemoveProductById(int productId)
        {
            return _dataAccess.SaveData(
                storedProcedure: "dbo.sp_RemoveProductId",
                new { Product_Id = productId }
            );
        }

        /// <summary>
        /// Asynchronously updates the alert limit of a product.
        /// </summary>
        /// <param name="productId">The ID of the product whose alert limit is to be updated.</param>
        /// <param name="newAlertLimit">The new alert limit value for the product.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateProductAlertLimit(int productId, int newAlertLimit)
        {
            return _dataAccess.SaveData(
                storedProcedure: "dbo.sp_UpdateProductAlertLimit",
                new { Product_Id = productId, New_Alert_Limit = newAlertLimit }
            );
        }

        /// <summary>
        /// Asynchronously updates the name of a product.
        /// </summary>
        /// <param name="productId">The ID of the product whose name is to be updated.</param>
        /// <param name="newProductName">The new name for the product.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateProductName(int productId, string newProductName)
        {
            return _dataAccess.SaveData(
                storedProcedure: "dbo.sp_UpdateProductName",
                new { Product_Id = productId, New_Product_Name = newProductName }
            );
        }

        /// <summary>
        /// Asynchronously updates the price of a product.
        /// </summary>
        /// <param name="productId">The ID of the product whose price is to be updated.</param>
        /// <param name="newProductPrice">The new price for the product.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateProductPrice(int productId, decimal newProductPrice)
        {
            return _dataAccess.SaveData(
                storedProcedure: "dbo.sp_UpdateProductPrice",
                new { Product_Id = productId, New_Product_Price = newProductPrice }
            );
        }

        /// <summary>
        /// Asynchronously retrieves products whose names contain a specified pattern.
        /// </summary>
        /// <param name="namePattern">The pattern to search for in product names.</param>
        /// <returns>A task representing the asynchronous operation, resulting in a collection of ProductModel objects.</returns>
        public Task<IEnumerable<ProductModel>> GetProductsByName(string namePattern)
        {
            return _dataAccess.LoadData<ProductModel, dynamic>(
                storedProcedure: "dbo.sp_GetProductsByName",
                new { NamePattern = namePattern }
            );
        }
    }
}
