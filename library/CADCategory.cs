using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace library {
    public class CADCategory {
        private string constring;

        public CADCategory() {
            constring = ConfigurationManager.ConnectionStrings["hada-p3"].ConnectionString;
        }

        public bool Read(ENCategory en) {
            try {
                using (SqlConnection con = new SqlConnection(constring)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT id, name FROM Categories WHERE id=@id", con);
                    cmd.Parameters.AddWithValue("@id", en.Id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        en.Id = (int)reader["id"];
                        en.Name = reader["name"].ToString();
                        return true;
                    }
                    return false;
                }
            } catch (SqlException ex) {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public List<ENCategory> ReadAll() {
            List<ENCategory> list = new List<ENCategory>();
            try {
                using (SqlConnection con = new SqlConnection(constring)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT id, name FROM Categories ORDER BY id ASC", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        ENCategory cat = new ENCategory();
                        cat.Id = (int)reader["id"];
                        cat.Name = reader["name"].ToString();
                        list.Add(cat);
                    }
                }
            } catch (SqlException ex) {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return list;
        }
    }
}