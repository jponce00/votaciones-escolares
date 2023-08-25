namespace SV.Utilities.Components
{
    public static class ConvertionComponent
    {
        public static byte[] ConvertImageToBytes(string filePath)
        {
            using FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, (int)bytes.Length);

            return bytes;
        }
    }
}
