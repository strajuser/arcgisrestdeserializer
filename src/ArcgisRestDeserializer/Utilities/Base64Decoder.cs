using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace ArcgisRestDeserializer.Utilities
{
    /// <summary> 
    /// Decoder for creating BitmapImage from base64-string
    /// </summary>
    public static class Base64Decoder
    {
        /// <summary> 
        /// Creates BitmapImage from base64-string 
        /// </summary>
        public static BitmapImage Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String.Replace("\0", ""));
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                var im = new BitmapImage();
                im.SetSource(ms);
                return im;
            }
        }
    }
}