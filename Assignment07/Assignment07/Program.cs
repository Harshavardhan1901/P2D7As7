using System;
using System.Data;
using System.Data.SqlClient;

namespace Assignment07
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter adapter;
        static DataSet ds;
        static string constring = "server=LAPTOP-P20IR6K6;database=LibraryDB;trusted_connection=true;";
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(constring);
                cmd = new SqlCommand("select * from Books", con);

                //Retrive data from dataset
                RetriveBookData();

                //Display book inventory
                DisplayAllBook();

                //Add new Book
                AddNewBook();

                //Update Book
                UpdateBook();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.ReadKey(); }
        }
        public static void RetriveBookData()
        {
            adapter = new SqlDataAdapter(cmd);
            con.Open();
            ds = new DataSet();
            adapter.Fill(ds);
        }
        public static void DisplayAllBook()
        {
            Console.WriteLine("Books List");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine("BookId: " + ds.Tables[0].Rows[i]["BookId"]);
                Console.WriteLine("Title: " + ds.Tables[0].Rows[i]["Title"]);
                Console.WriteLine("Author: " + ds.Tables[0].Rows[i]["Author"]);
                Console.WriteLine("Genre: " + ds.Tables[0].Rows[i]["Genre"]);
                Console.WriteLine("Quantity: " + ds.Tables[0].Rows[i]["Quantity"]);
                Console.WriteLine("\n");
            }
        }
        public static void AddNewBook()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Adding new Book to List");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            con.Close();
            Console.WriteLine("Enter Book Id: ");
            dr["BookId"] = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Book Title: ");
            dr["Title"] = Console.ReadLine();
            Console.WriteLine("Enter Book Author: ");
            dr["Author"] = Console.ReadLine();
            Console.WriteLine("Enter Book Genre: ");
            dr["Genre"] = Console.ReadLine();
            Console.WriteLine("Enter Book Quantity: ");
            dr["Quantity"] = int.Parse(Console.ReadLine());
            dt.Rows.Add(dr);
            ApplyChanges();
            Console.WriteLine("Book Added!!");

        }
        public static void UpdateBook()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Updating a Book from List");
            DataTable dt = ds.Tables[0];
            con.Close();
            Console.WriteLine("Enter Id to Update Book: ");
            int id = int.Parse(Console.ReadLine());
            DataRow dr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)dt.Rows[i]["BookId"] == id)
                {
                    dr = dt.Rows[i];
                    break;
                }
            }
            if (dr != null)
            {
                Console.WriteLine("Enter Title: ");
                dr["Title"] = Console.ReadLine();
                Console.WriteLine("Enter Book Author: ");
                dr["Author"] = Console.ReadLine();
                Console.WriteLine("Enter Book Genre: ");
                dr["Genre"] = Console.ReadLine();
                Console.WriteLine("Enter Book Quantity: ");
                dr["Quantity"] = int.Parse(Console.ReadLine());
                ApplyChanges();
                Console.WriteLine("Record Updated!! ");
            }
            else
            {
                Console.WriteLine("No such record exist");
            }

        }
        public static void ApplyChanges()
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
        }
    }
}