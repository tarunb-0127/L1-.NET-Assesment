using MySql.Data.MySqlClient;


namespace LostFoundManagement
{
    public class LostFound
    {
        static string connectionString = "server=localhost;user=root;password=root;database=sample1;port=3306;";

        public void AddLostItem()
        {
            Console.WriteLine("Enter item name:");
            string itemName = Console.ReadLine();
            Console.Write("Enter item type : ");
            string itemType = Console.ReadLine();
            Console.Write("Enter lost date : ");
            string itemDate = Console.ReadLine();
            Console.Write("Enter recovery status : ");
            string itemStatus = Console.ReadLine();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO lost_items(item_name, item_type, lost_date, recovery_status) VALUES(@itemName, @itemType, @itemDate, @itemStatus)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@itemName", itemName);
            cmd.Parameters.AddWithValue("@itemType", itemType);
            cmd.Parameters.AddWithValue("@itemDate", itemDate);
            cmd.Parameters.AddWithValue("@itemStatus", itemStatus);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Item added successfully!");
        }

        public void UpdateLostItem()
        {
            Console.Write("Enter item id to update : ");
            int itemId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter item name : ");
            string itemName = Console.ReadLine();
            Console.Write("Enter item type : ");
            string itemType = Console.ReadLine();
            Console.Write("Enter lost date : ");
            string itemDate = Console.ReadLine();
            Console.Write("Enter recovery status : ");
            string itemStatus = Console.ReadLine();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "UPDATE lost_items SET item_name = @itemName, item_type = @itemType, lost_date = @itemDate, recovery_status = @itemStatus WHERE item_id = @itemId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@itemName", itemName);
            cmd.Parameters.AddWithValue("@itemType", itemType);
            cmd.Parameters.AddWithValue("@itemDate", itemDate);
            cmd.Parameters.AddWithValue("@itemStatus", itemStatus);
            cmd.Parameters.AddWithValue("@itemId", itemId);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Item updated successfully!");

        }

        public void ViewLostItems()
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM lost_items";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Item ID: {reader["item_id"]}");
                Console.WriteLine($"Item Name: {reader["item_name"]}");
                Console.WriteLine($"Item Type: {reader["item_type"]}");
                Console.WriteLine($"Lost Date: {reader["lost_date"]}");
                Console.WriteLine($"Recovery Status: {reader["recovery_status"]}");
                Console.WriteLine();
            }
        }
        
        public void DeleteLostItem()
        {
            Console.Write("Enter item id to delete : ");
            int itemId = Convert.ToInt32(Console.ReadLine());
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "DELETE FROM lost_items WHERE item_id = @itemId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@itemId", itemId);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Item deleted successfully!");
        }

        public void SearchItem()
        {
            Console.Write("Enter item id to search : ");
            int itemId = Convert.ToInt32(Console.ReadLine());
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM lost_items WHERE item_id = @itemId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@itemId", itemId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Item ID: {reader["item_id"]}");
                Console.WriteLine($"Item Name: {reader["item_name"]}");
                Console.WriteLine($"Item Type: {reader["item_type"]}");
                Console.WriteLine($"Lost Date: {reader["lost_date"]}");
                Console.WriteLine($"Recovery Status: {reader["recovery_status"]}");
            }
            else
            {
                Console.WriteLine("Item not found!");
            }

        }
    }
}