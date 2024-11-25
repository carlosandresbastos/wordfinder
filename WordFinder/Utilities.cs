using System.Text;

namespace BusinessRules
{
    public class Utilities
    {
        public static List<string> GenerateColumns(IEnumerable<string> strings)
        {
            int maxLength = strings.Max(s => s.Length);
            List<string> columns = new List<string>();

            for (int i = 0; i < maxLength; i++)
            {
                StringBuilder column = new StringBuilder();
                foreach (string str in strings)
                {
                    column.Append(str[i]);
                }
                columns.Add(column.ToString());
            }
            return columns;
        }
    }
}
