using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            constring = ConfigurationManager.ConnectionStrings["hada-p3"].ConnectionString;
        }

        public bool Create(ENProduct en) {
            try {
                using (SqlConnection con = new SqlConnection(constring)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Products (name, code, amount, price, category, creationDate) " +
                        "VALUES (@name, @code, @amount, @price, @category, @creationDate)", con);
                    cmd.Parameters.AddWithValue("@name", en.Name);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.Parameters.AddWithValue("@amount", en.Amount);
                    cmd.Parameters.AddWithValue("@price", en.Price);
                    cmd.Parameters.AddWithValue("@category", en.Category);
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);
                    cmd.ExecuteNonQuery();
                }
                return true;
            } catch (SqlException ex) {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Update(ENProduct en) {
            try {
                using (SqlConnection con = new SqlConnection(constring)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Products SET name=@name, amount=@amount, price=@price, " +
                        "category=@category, creationDate=@creationDate WHERE code=@code", con);
                    cmd.Parameters.AddWithValue("@name", en.Name);
                    cmd.Parameters.AddWithValue("@amount", en.Amount);
                    cmd.Parameters.AddWithValue("@price", en.Price);
                    cmd.Parameters.AddWithValue("@category", en.Category);
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.ExecuteNonQuery();
                }
                return true;
            } catch (SqlException ex) {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Delete(ENProduct en) {
            try {
                using (SqlConnection con = new SqlConnection(constring)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Products WHERE code=@code", con);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.ExecuteNonQuery();
                }
                return true;
            } catch (SqlException ex) {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Read(ENProduct en) {
            try {
                using (SqlConnection con = new SqlConnection(constring)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT name, code, amount, price, category, creationDate " +
                        "FROM Products WHERE code=@code", con);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        en.Name = reader["name"].ToString();
                        en.Code = reader["code"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = (float)(double)reader["price"];
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                    return false;
                }
            } catch (SqlException ex) {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadFirst(ENProduct en) {
            try {
                using (SqlConnection con = new SqlConnection(constring)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT TOP 1 name, code, amount, price, category, creationDate " +
                        "FROM Products ORDER BY code ASC", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        en.Name = reader["name"].ToString();
                        en.Code = reader["code"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = (float)(double)reader["price"];
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                    return false;
                }
            } catch (SqlException ex) {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadNext(ENProduct en) {
            try {
                using (SqlConnection con = new SqlConnection(constring)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT TOP 1 name, code, amount, price, category, creationDate " +
                        "FROM Products WHERE code > @code ORDER BY code ASC", con);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        en.Name = reader["name"].ToString();
                        en.Code = reader["code"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = (float)(double)reader["price"];
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                    return false;
                }
            } catch (SqlException ex) {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadPrev(ENProduct en) {
            try {
                using (SqlConnection con = new SqlConnection(constring)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT TOP 1 name, code, amount, price, category, creationDate " +
                        "FROM Products WHERE code < @code ORDER BY code DESC", con);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        en.Name = reader["name"].ToString();
                        en.Code = reader["code"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = (float)(double)reader["price"];
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                    return false;
                }
            } catch (SqlException ex) {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
    }
}
