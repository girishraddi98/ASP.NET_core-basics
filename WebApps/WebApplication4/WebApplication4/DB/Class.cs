using WebApplication4.Models;

namespace WebApplication4.DB
{
    public class ClassRoom
    {
        public Dictionary<int, string> Dict { get; set; }

        public static ClassRoom Current = new ClassRoom()
        {
            Dict = new Dictionary<int, string>
        {
            {1,"A"},
            {2,"B"},
            {3,"C"},
            {4,"D"},
            {5,"E"},
            {6,"F"},
            {7,"G"},
            {8,"H"},
            {9,"I"},
            {10,"J"}
        }
        };
        
    }
}
