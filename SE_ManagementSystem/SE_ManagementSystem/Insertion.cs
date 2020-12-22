﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ManagementSystem
{
    class Insertion
    {
        public static void InsertCustomers(string customerID,string customerName,string cusPass,string customerAddress,string customerNum)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spInsertCustomers", CentralControl.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerID", customerID);
                cmd.Parameters.AddWithValue("@customerName", customerName);
                cmd.Parameters.AddWithValue("@cusPass", cusPass);
                cmd.Parameters.AddWithValue("@customerAddress", customerAddress);
                cmd.Parameters.AddWithValue("@customerNum", customerNum);
                CentralControl.con.Open();
                int res = cmd.ExecuteNonQuery();
                CentralControl.con.Close();
                if(res>0)
                {
                    CentralControl.ShowMSG(customerID + " added sucessfully into the system", "Sucess");
                }
            }
            catch(Exception ex)
            {
                CentralControl.con.Close();
                CentralControl.ShowMSG(ex.Message, "Error");
            }
        }
    }
}
