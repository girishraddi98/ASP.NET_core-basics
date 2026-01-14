using System.Linq;
class program
{



    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5 };

        arr = arr.Where(x =>
        x != 3).ToArray();
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
        int[] arr2 = { 1, 2, 3, 4, 5, 3, 6, 3 };
        arr2 = arr2.Append(7).ToArray();
        foreach (var item2 in arr2) {
            Console.WriteLine(item2);

        }
        Dictionary< int, string> dict = new Dictionary<int, string>()
        {{1, "one" },
            {2, "two" },
            {3, "three" }
         };
        dict.Remove(2);
        foreach (var kvp in dict) {
            Console.WriteLine($"{kvp.Key} : {kvp.Value}");
        }
        dict[2] = "two";
        dict[4]= "four";
        foreach (var kvp in dict)
            Console.WriteLine($"{kvp.Key} : {kvp.Value}");
        //dict = dict.Append(new KeyValuePair<string, int>("four", 4)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    
}