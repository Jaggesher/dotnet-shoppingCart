# **dotnet-ShoppingCart**
This project implements simple single shop shopping cart idea. This project only contains API part and there is a separate <a href="https://github.com/Jaggesher/ng-shoppingCart">project</a> which implement user interface. This project is based on ASP.NET core 2.0 and authentication implemented using JWT. 

* ## *Requirements*
  * **.NET Core 2.0 SDK** From <a href="https://www.microsoft.com/net/download/dotnet-core/">here</a> 
 

* ## *Installation* 
  * `git clone  https://github.com/Jaggesher/dotnet-shoppingCart.git`
  * `Open CMD & navigate to 'dotnet-shoppingCart' folder`
  * `First command 'dotnet restore'`
  * `Second command 'dotnet ef database update'`
  * `Third command 'dotnet run'`
 
 If everything goes fine then your server is running. In my case it is **http://localhost:5000**. 
 
<hr>

## **Common API Doc**
   * **New Account**: http://localhost:5000/api/auth/register
     * Method: **POST**
     * JSON Body With example: 
        ```
        {
	          "UserName" : "jaggesher",
	          "Email" : "jaggesher14@gmail.com",
	          "Password" : "123456=Jk",
	          "ConfirmPassword" : "123456=Jk"
        }
        
        ```
      * Return: Success Or Fail Messages.
      
   * **LogIn**: http://localhost:5000/api/auth/login
     * Method: **POST**
     * JSON Body With example:
       ```
       {
         "UserName" : "jaggesher",
         "Password" : "123456=Jk"
       }
       
       ```
     * Return: ID with Token(JWT) or fail messages.
     
   * **AddCategory**: http://localhost:5000/api/admin/AddCategory
     * Method: **POST**
     * JSON Body With example:
       ```
       {
         "ProductCategory" : "T-Shirt"
       }
       
       ```
     * Return: Success Or Fail Messages.
     
   * **AllCategory**: http://localhost:5000/api/admin/AllCategory
     * Method: **GET**
     * Return: Return All Category.
     
   * **AddProduct**: http://localhost:5000/api/admin/AddProduct
     * Method: **POST**
     * Require Form Data items:
       ```
       "Img" : `image file`,
       "CategoryId" : `Related Category ID`,
       "Description" : `Product Description`,
       "InStock" : `Stock Quentity`,
       "Price" : `Product Price`
       ```
     * Return: Success Or Fail Messages.
   
   * **AllProduct**: http://localhost:5000/api/General/AllProducts
     * Method: **GET**
     * Return: Return All Product info Which have non zero quantity.
     
   * **SingleProduct**: http://localhost:5000/api/General/{id}
     * Method: **GET**
     * Return: Return Related Product Info.
     
   * **Get Product By IDs**: http://localhost:5000/api/General/GetByIDs
     * Method: **POST**
     * JSON Body With example:
       ```
       {
         	"Ids": [
                "40338331-1dcf-4d2a-3884-08d59cb72e94",
                "26090972-abcd-456b-2c3d-08d59cbb9c23"
               ]
       }
       
       ```
     * Return: Related Products info.
   
   * **StoreShipment**: http://localhost:5000/api/General/StoreShipment
     * Method: **POST**
     * JSON Body With example:
       ```
       {
         "Name": "Mr.Boss",
         "Phone": "01915770274",
         "Address": "Fake Address",
         "TotalCost": "122",
         "OrderProduct": [
           {
            "ProductID": "8cd8d49d-12b8-4da3-b23b-08d59cbbcf32",
            "Quantity" : "3"
           }
         ]
       }
       
       ```
     * Return: Success Or Fail Messages.
     
   * **AllShipments**: http://localhost:5000/api/admin/AllShipments
     * Method: **GET**
     * Return: Return All Shipment Info.
      
   * **ConfirmShipment**: http://localhost:5000/api/General/StoreShipment
    * Method: **POST**
    * Require Form Data item:
      ```
      {
        "id": `Shiment ID`
      }

      ```
    * Return: Success Or Fail Messages.
     
   
   **These are most important APIs for this project, there are many more additional APIs for this visit projects controller files.**
   
   
   <hr>
   
   ## **Feel free to share your query.**
   * Mail: jaggesher14@gmail.com
   * LinkedIn: jaggesher-mondal-348239102
   
   
   
