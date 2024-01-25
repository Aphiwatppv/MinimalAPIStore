namespace MinimalAPIStore;

public static class API
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my mapping 
        app.MapGet(pattern: "/GetAllProduct", GetAllProducts);
        app.MapPost(pattern: "/AddProduct", AddProduct);
        app.MapPost(pattern: "/IncreaseStock", IncreaseStock);
        app.MapGet(pattern: "/GetProductDetails/{productId}", GetProductDetails);
        app.MapPost(pattern: "/ReduceStock", ReduceStock);
        app.MapDelete("/RemoveProduct/{productId}", RemoveProduct);
        app.MapPut("/UpdateAlertLimit", UpdateAlertLimit);
        app.MapPut("/UpdateProductName", UpdateProductName);
        app.MapPut("/UpdateProductPrice", UpdateProductPrice);
        app.MapGet("/GetProductsByName/{namePattern}", GetProductsByName);
    }


    private static  async Task<IResult> GetAllProducts(IProductData product)
    {
        try
        {
            return Results.Ok(await product.GetAllproducts());
        }
        catch(Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> AddProduct(IProductData productData, ProductModel product)
    {
        try
        {
            await productData.AddnewProduct(product);
            return Results.Ok("Product added successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> IncreaseStock(IProductData productData, int productId, int incrementAmount)
    {
        try
        {
            await productData.IncreaseProductStock(productId, incrementAmount);
            return Results.Ok("Stock increased successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetProductDetails(IProductData productData, int productId)
    {
        try
        {
            var product = await productData.GetProductDetails(productId);
            return product != null ? Results.Ok(product) : Results.NotFound("Product not found.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ReduceStock(IProductData productData, int productId, int decrementAmount)
    {
        try
        {
            await productData.ReduceProductStock(productId, decrementAmount);
            return Results.Ok("Stock reduced successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> RemoveProduct(IProductData productData, int productId)
    {
        try
        {
            await productData.RemoveProductById(productId);
            return Results.Ok("Product removed successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateAlertLimit(IProductData productData, int productId, int newAlertLimit)
    {
        try
        {
            await productData.UpdateProductAlertLimit(productId, newAlertLimit);
            return Results.Ok("Product alert limit updated successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateProductName(IProductData productData, int productId, string newProductName)
    {
        try
        {
            await productData.UpdateProductName(productId, newProductName);
            return Results.Ok("Product name updated successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateProductPrice(IProductData productData, int productId, decimal newProductPrice)
    {
        try
        {
            await productData.UpdateProductPrice(productId, newProductPrice);
            return Results.Ok("Product price updated successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetProductsByName(IProductData productData, string namePattern)
    {
        try
        {
            var products = await productData.GetProductsByName(namePattern);
            return Results.Ok(products);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

}
