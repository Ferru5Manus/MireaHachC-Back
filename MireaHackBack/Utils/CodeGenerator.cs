using System.Security.Cryptography;
using System.Text;

namespace MireaHackBack.Utils;

public static class CodeGenerator
{
    public static string CodeGen(int length)
    {
        const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder sb = new StringBuilder();
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[length];
            rng.GetBytes(randomBytes);
            foreach (byte b in randomBytes)
            {
                sb.Append(validChars[b % validChars.Length]);
            }
        }
        return sb.ToString();
    }
}