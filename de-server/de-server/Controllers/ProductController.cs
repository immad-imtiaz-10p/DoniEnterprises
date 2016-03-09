using de_server.Entity_Framework;
using de_server.Models;
using de_server.Security;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using de_server.Reporting;
using NReco.PdfGenerator;
using de_server.Filters;
using de_server.App_Config;

namespace de_server.Controllers
{
    [DoniApiExceptionFilter]    
    [Authorize]
    public class ProductController : ApiController
    {
        [Route("getAllProducts")]
        [HttpGet]
        public List<ProductListItem> GetProducts()
        {
            List<ProductListItem> allProducts = new List<ProductListItem>();
            using (var context = new DhoniEnterprisesEntities())
            {
                var products = context.uspGetProductList();
                foreach(var p in products){                 
                    allProducts.Add(new ProductListItem(p.ProductId, p.ProductName, p.quality, p.origin, (int?)p.tr_transactionID, (System.DateTime?)p.TransactionDate)); 
                }
                

            }
            return allProducts;
        }

        [Route("getProductListTagInputs/{input}")]
        [HttpGet]
        public List<ProductTagInput> GetProductListTagInputs(String input)
        {
            List<ProductTagInput> allProducts = new List<ProductTagInput>();
            using (var context = new DhoniEnterprisesEntities())
            {
                var products = context.uspGetProductTagInput(Convert.ToString(input));
                foreach (var p in products)
                {
                    allProducts.Add(new ProductTagInput(p.ProductId,p.ProductName,p.origin,p.quality));
                }


            }
            return allProducts;
        }



        [Route("getAllProductPDF")]
        public HttpResponseMessage GetAllProductPdf()
        {
            HttpResponseMessage result = null;
           
                using (var context = new DhoniEnterprisesEntities())
                {
                    var data = context.uspGetProductListPDF();
                    String body = string.Empty;
                    using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(PdfService.allProduct)))
                    {
                        body = reader.ReadToEnd();
                    }
                    string content = "<div><h1>All Products</h1><div>";
                    foreach (var p in data)
                    {
                        var temp = body;
                        temp = temp.Replace("{Name}", p.ProductName);
                        temp = temp.Replace("{Origin}", p.origin);
                        temp = temp.Replace("{Purity}", p.purity.ToString());
                        temp = temp.Replace("{Quality}", p.quality);
                        temp = temp.Replace("{Moisture}", p.moisture.ToString());
                        temp = temp.Replace("{Weeviled}", p.weaveled.ToString());
                        temp = temp.Replace("{Splits}", p.splits.ToString());
                        temp = temp.Replace("{Damaged}", p.damaged.ToString());
                        temp = temp.Replace("{foreignMatter}", p.foreignMatter.ToString());
                        temp = temp.Replace("{greenDamaged}", p.greenDamaged.ToString());
                        temp = temp.Replace("{otherColor}", p.otherColor.ToString());
                        temp = temp.Replace("{wrinkled}", p.wrinkled.ToString());
                        content += temp;
                    }



                    MemoryStream pdf = new MemoryStream((new PdfService()).getPDF(content));
                    result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Content = new ByteArrayContent(pdf.ToArray());
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    result.Content.Headers.ContentDisposition.FileName = "AllProductsDetails-DhoniGroup.pdf";
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    result.StatusCode = HttpStatusCode.OK;
                    return result;
                }

                
          
            
        }

        [Route("editProduct")]
        [HttpPost]
        public IHttpActionResult PostaddProduct([FromBody]JObject Product)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
               
                    int userID = BasicAuthHttpModule.getCurrentUserId();
                    de_server.Models.Product product = Product["product"].ToObject<de_server.Models.Product>();
                    if (userID != -1)
                    {
                        var result = context.uspUpdateProduct(product.id,product.name,product.specs.moisture, product.specs.weeviled, product.origin, product.specs.purity, product.specs.splits, product.quality, Convert.ToInt32(userID), product.specs.damaged, product.specs.foreignMatter, product.specs.greenDamaged, product.specs.otherColor, product.specs.wrinkled);
                        return Ok(new { success = true, message = "Product Changes Saved!" });
                    }
                    else
                    {
                        return NotFound();
                    }
             

            }

        }

        [Route("addProduct")]
        [HttpPost]
        public IHttpActionResult PostEditProduct([FromBody]JObject newProduct)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                
                    int userID = BasicAuthHttpModule.getCurrentUserId();
                    de_server.Models.Product product = newProduct["product"].ToObject<de_server.Models.Product>();
                    if(userID != -1){
                        var result = context.uspAddProduct(product.name, Convert.ToInt32(userID),product.specs.moisture, product.specs.weeviled, product.origin, product.specs.purity, product.specs.splits, product.quality, product.specs.damaged, product.specs.foreignMatter, product.specs.greenDamaged, product.specs.otherColor, product.specs.wrinkled);
                        return Ok(new { success = true, message = "New Product Added!" });
                    }
                    else{
                        return NotFound();
                    }
              
                
            }
            
        }
        [Route("getProduct/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                
                    
                    var result = (context.uspGetSingleProduct(id).AsEnumerable()).FirstOrDefault();
                    de_server.Models.Product prod = new de_server.Models.Product(result.ProductId, result.ProductName, result.origin, result.quality, result.purity, result.moisture, result.splits, result.weaveled, result.damaged, result.foreignMatter, result.greenDamaged, result.otherColor, result.wrinkled);
                    return Ok(new { success = true, message = "found", product = prod });
               
            }
        }

        [Route("deleteProduct/{id:int}")]
        [HttpGet]
        public IHttpActionResult DeleteProduct(int id)
        {
            using (var context = new DhoniEnterprisesEntities())
            {                
                    context.uspDeleteProduct(id);
                    return Ok(new { success = true, message = "Product Successfully deleted!" });
              
            }
        }

        [Route("getProductsPricesByDate")]
        [HttpPost]
        public IHttpActionResult GetProductsPricesByDate([FromBody]JObject date)
        {
            using(var context = new DhoniEnterprisesEntities())
            {
                var productPrices = context.uspGetProductPriceByDate(Convert.ToDateTime(date["date"]));
                return Ok(new { success = true, productPrices = DataTableSerializer.LINQToDataTable(productPrices) });
            }
        }

        [Route("productPriceByDateCrud")]
        [HttpPost]
        public IHttpActionResult ProductPriceByDateCRUD([FromBody]JObject productPrice)
        {
            var priceInfo = productPrice["data"];
            var operation = Convert.ToString(priceInfo["operation"]);
            var prodId = (int?)priceInfo["productId"];
            var price = (int)priceInfo["price"];
            var date = (DateTime?)priceInfo["date"];
            var userID = BasicAuthHttpModule.getCurrentUserId();
            using (var context = new DhoniEnterprisesEntities()){

                context.uspProductPriceByDateCRUD(operation, prodId, date, price, userID, userID);
                return Ok(new {
                    success = true,
                    message= "Product price successfully updated!"
                });
            }
        }

        [Route("productPriceByDateRange")]
        [HttpGet]
        public IHttpActionResult ProductPriceByDateRange(DateTime startDate, DateTime endDate)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                DataTable transactions = new DataTable();
                var productsPrices = DataTableSerializer.LINQToDataTable(context.uspProductListByDateRange(startDate, endDate));
                return Ok(new
                {
                    success = true,
                    productsPrices = productsPrices
                });

            }
        }

    }
}
