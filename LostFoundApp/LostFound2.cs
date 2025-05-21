using MySql.Data.MySqlClient;
using MobilePhoneData;


namespace LostFoundManagement
{


    public class LostFound2
    {
        static string connectionString = "server=localhost;user=root;password=root;database=sample1;port=3306;";
        public void AddLostItem()
        {
            Console.Write("Enter item type : ");
            string itemType = Console.ReadLine();
            if (itemType == "Mobile")
            {
                MobilePhone mobilePhone = new MobilePhone();
                mobilePhone.AddMobileDetails();

            }
            Console.Write("Enter lost date : ");
            string itemDate = Console.ReadLine();
            Console.Write("Enter recovery status : ");
            string itemStatus = Console.ReadLine();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO lost_items3(item_type, lost_date, recovery_status) VALUES(@itemType, @itemDate, @itemStatus)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@itemType", itemType);
            cmd.Parameters.AddWithValue("@itemDate", itemDate);
            cmd.Parameters.AddWithValue("@itemStatus", itemStatus);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Item added successfully!");
        }

        public void GetLostItem()
        {
            Console.Write("Enter item type : ");
            string itemType = Console.ReadLine();
            string mobileNumber;
            if (itemType == "Mobile")
            {
                Console.Write("Enter mobile number to search : ");
                mobileNumber = Console.ReadLine();
                MobilePhone mobilePhone = new MobilePhone();
                mobilePhone.SearchMobile(mobileNumber);

                using var conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT * FROM lost_items3 inner join mobile_phones on lost_items3.item_id=mobile_phones.item_id WHERE mobile_phones.phone_number = @mobileNumber";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Item Type: {reader["item_type"]}");
                    Console.WriteLine($"Lost Date: {reader["lost_date"]}");
                    Console.WriteLine($"Recovery Status: {reader["recovery_status"]}");
                    Console.WriteLine();
                }


            }

        }

        public void DisplayAll()
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM lost_items3";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID : {reader["item_id"]}");
                Console.WriteLine($"Item Type: {reader["item_type"]}");
                Console.WriteLine($"Lost Date: {reader["lost_date"]}");
                Console.WriteLine($"Recovery Status: {reader["recovery_status"]}");
                Console.WriteLine();
            }
        }

        public void DeleteItem()
        {
            Console.Write("Enter item id to delete : ");
            int itemId = Convert.ToInt32(Console.ReadLine());
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "DELETE FROM lost_items3 WHERE item_id = @itemId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@itemId", itemId);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Item deleted successfully!");
        }

        public void updateItem()
        {
            Console.Write("Enter type of item to update : ");
            string itemType = Console.ReadLine();
            if (itemType == "Mobile")
            {
                MobilePhone mobilePhone = new MobilePhone();
                mobilePhone.UpdateMobileDetails();
                Console.Write("Updated Lost Date : ");
                string itemDate = Console.ReadLine();
                Console.Write("Updated Recovery Status : ");
                string itemStatus = Console.ReadLine();

                using var conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "UPDATE lost_items3 SET lost_date = @itemDate, recovery_status = @itemStatus WHERE item_type = @itemType";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemDate", itemDate);
                cmd.Parameters.AddWithValue("@itemStatus", itemStatus);
                cmd.Parameters.AddWithValue("@itemType", itemType);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Item updated successfully!");
            }
        }
    }
}