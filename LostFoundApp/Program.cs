using MySql.Data.MySqlClient;

namespace MobilePhoneData
{
    public class MobilePhone

    {
        static string connectionString = "server=localhost;user=root;database=sample1;password=root;port=3306";
        public void AddMobileDetails()
        {
            Console.Write("Enter mobile number : ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter mobile brand : ");
            string brand = Console.ReadLine();
            Console.Write("Enter mobile model : ");
            string mobilePrice = Console.ReadLine();
            Console.Write("Enter IMEI number : ");
            string IMEI = Console.ReadLine();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO mobile_phones(phone_number, phone_brand, phone_model, imei_number) VALUES(@mobileNumber, @brand, @mobilePrice, @IMEI)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@mobilePrice", mobilePrice);
            cmd.Parameters.AddWithValue("@IMEI", IMEI);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Mobile details added successfully!");
        }

        public void GetMobileDetails()
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM mobile_phones";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Mobile Number: {reader["phone_number"]}");
                Console.WriteLine($"Mobile Brand: {reader["phone_brand"]}");
                Console.WriteLine($"Mobile Model: {reader["phone_model"]}");
                Console.WriteLine($"IMEI Number: {reader["imei_number"]}");
                Console.WriteLine();
            }

        }

        public void SearchMobile(string mobileNumber)
        {

            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM mobile_phones WHERE phone_number = @mobileNumber";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Mobile Number: {reader["phone_number"]}");
                Console.WriteLine($"Mobile Brand: {reader["phone_brand"]}");
                Console.WriteLine($"Mobile Model: {reader["phone_model"]}");
                Console.WriteLine($"IMEI Number: {reader["imei_number"]}");
            }
            else
            {
                Console.WriteLine("Mobile not found!");
            }
        }

        public void UpdateMobileDetails()
        {
            Console.Write("Enter id of mobile to update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter mobile number : ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter mobile brand : ");
            string brand = Console.ReadLine();
            Console.Write("Enter mobile model : ");
            string mobilePrice = Console.ReadLine();
            Console.Write("Enter IMEI number : ");
            string IMEI = Console.ReadLine();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "UPDATE mobile_phones SET phone_number = @mobileNumber, phone_brand = @brand, phone_model = @mobilePrice, imei_number = @IMEI WHERE item_id = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@mobilePrice", mobilePrice);
            cmd.Parameters.AddWithValue("@IMEI", IMEI);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Mobile details updated successfully!");
        }
    }
}