using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Text;
using MobilePhoneRetailer.DataLayer;

namespace MobilePhoneRetailer.BusinessLayer
{
    public class Catalogue
    {
        public Catalogue()
        {
            
        }

        public static string Search(string searchString){
            List<string> searchList = new List<string>();
            string selectSQL = "SELECT * FROM [Products]";

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    searchList.Add("" + reader["Type"]);
                }
                reader.Close();
                con.Close();
                return ClosestWord(searchString, searchList);
            }
            catch (Exception sqlEx)
            {
                return sqlEx.Message;
            }
        }

        public static string ClosestWord(string word, List<string> list)
        {
            string term = word.ToLower();
            if (list.Contains(term))
                return list.Find(t => t.ToLower() == term);
            else
            {
                int[] counter = new int[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    for (int x = 0; x < Math.Min(term.Length, list[i].Length); x++)
                    {
                        int difference = Math.Abs(term[x] - list[i][x]);
                        counter[i] += difference;
                    }
                }

                int min = counter.Min();
                int index = counter.ToList().FindIndex(t => t == min);
                return list[index];
            }
        }
    }
}