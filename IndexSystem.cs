using System.Security.Cryptography;
using System.Text;


namespace BookSorter
{
    public interface ISerialNumberGenerator
    {
        string GenerateSerialNumber(BookModel book);
    }

    public class SerialNumberGenerator : ISerialNumberGenerator
    {
        public string GenerateSerialNumber(BookModel book)
        {
            String toconvert = $"{book.Name}{book.Title}{book.Place}{book.Publisher}{book.Date}";
            using (var hashAlgorithm = SHA256.Create())
            {
                byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(toconvert));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                var serialNumber = sBuilder.ToString();
                return serialNumber;

                //based on microsoft documentation https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=netcore-3.1#System_Security_Cryptography_HashAlgorithm_ComputeHash_System_Byte___
            }
        }
    }
}
