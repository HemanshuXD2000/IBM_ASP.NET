// CartController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;  // Add this using statement for JSON serialization
using OrganicStore.Models;
using System;
using System.Collections.Generic;

public class CartController : Controller
{
    [HttpPost]
    public IActionResult SubmitCart([FromBody] List<CartItem> cart)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionMod.getConnString()))
            {
                connection.Open();

                foreach (var cartItem in cart)
                {
                    // Check if the item exists in the database
                    string selectQuery = "SELECT * FROM CartItems WHERE ProductId = @ProductId";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@ProductId", cartItem.ProductId);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // If the item exists, update quantity and total
                                string updateQuery = @"
                                    UPDATE CartItems 
                                    SET Quantity = Quantity + @Quantity, 
                                        Total = (Quantity + @Quantity) * Price 
                                    WHERE ProductId = @ProductId";

                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@ProductId", cartItem.ProductId);
                                    updateCommand.Parameters.AddWithValue("@Quantity", cartItem.Quantity);

                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // If the item doesn't exist, insert a new record
                                string insertQuery = @"
                                    INSERT INTO CartItems (ProductId, ProductName, Price, Quantity, Total) 
                                    VALUES (@ProductId, @ProductName, @Price, @Quantity, @Total)";

                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@ProductId", cartItem.ProductId);
                                    insertCommand.Parameters.AddWithValue("@ProductName", cartItem.ProductName);
                                    insertCommand.Parameters.AddWithValue("@Price", cartItem.Price);
                                    insertCommand.Parameters.AddWithValue("@Quantity", cartItem.Quantity);
                                    insertCommand.Parameters.AddWithValue("@Total", cartItem.Total);

                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }

            return Json(new { success = true, message = "Cart submitted successfully" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Error submitting cart", error = ex.Message });
        }
    }
}
