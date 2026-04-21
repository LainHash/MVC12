namespace MVC12.Helpers.Constants
{
    public static class SortTypes
    {
        public static Dictionary<int, string> SortDict = new Dictionary<int, string>
        {
            { 0, "Newest" },
            { 1, "Oldest" },
            { 2, "Price: Low to High" },
            { 3, "Price: High to Low" }
        };
    }
}
