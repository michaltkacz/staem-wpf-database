﻿using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.DBLayer
{
    public static class OrderDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public static List<Order> RetrieveAllOrders()
        {
            string query = "SELECT * FROM staem.orders;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Order> allOrders = new List<Order>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string quantity = dr["Order_quantity"].ToString();
                    string gameID = dr["Game_id"].ToString();
                    string supplierID = dr["Supplier_id"].ToString();
                    allOrders.Add(new Order(id, quantity, gameID, supplierID));
                }
            }
            return allOrders;
        }
    }
}
