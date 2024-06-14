using System.Data.SqlClient;
using System.IO;

namespace FillingImageTable
{
    internal class Program
    {

        private static string _connectionString = "Server=localHost;Database=MemoryGame;Trusted_Connection=True;TrustServerCertificate=True";
        private static string _imageDirectory = "C:\\Users\\vanho\\Desktop\\UnityProjects\\PD4MemoryGame\\PD4 MemoryGame\\ImagesData\\Images";
        static void Main(string[] args)
        {
            LoadImagesFrom(_imageDirectory);


        }

        private static void LoadImagesFrom(string imgDir)
        {
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();

                using (SqlCommand sqlDelete = new SqlCommand("DELETE FROM dbo.Images", sqlCon))
                {
                    sqlDelete.ExecuteNonQuery();
                }

                using (SqlCommand sqlInsert = new SqlCommand("INSERT INTO dbo.Images (id, name, image, isBack) VALUES (@id, @name, @image, @isBack)", sqlCon))
                {
                    SqlParameter prmID = sqlInsert.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int));
                    SqlParameter prmName = sqlInsert.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 60));
                    SqlParameter prmImage = sqlInsert.Parameters.Add(new SqlParameter("@image", System.Data.SqlDbType.VarBinary, int.MaxValue));
                    SqlParameter prmIsBack = sqlInsert.Parameters.Add(new SqlParameter("@isBack", System.Data.SqlDbType.Bit));

                    int idx = 0;

                    foreach (string completedFileName in Directory.GetFiles(imgDir, "*.png"))
                    {
                        byte[] fileBytes = File.ReadAllBytes(completedFileName);
                        prmID.Value = idx++;
                        string fileName = Path.GetFileName(completedFileName);
                        prmName.Value = fileName;
                        prmImage.Value = fileBytes;
                        prmIsBack.Value = fileName == "CardBack.png";
                        sqlInsert.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}