using System.Globalization;

namespace GeneralExtensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            var words = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLower());

            var result = words
                .Select((word, index) =>
                    index == 0
                        ? word
                        : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word))
                .ToArray();

            return string.Concat(result);
        }
    }
}
