using System.Linq;

namespace XMLPortGenerator
{
    public static class MyExtensions
    {
        public static string PrepareForXMLField(this string str)
        {
            char[] arr;
            arr = str.Where(c => char.IsLetterOrDigit(c)).ToArray();
            str = new string(arr);
            return str.TrimEnd().PadRight(20, ' ');
        }
    }
}
