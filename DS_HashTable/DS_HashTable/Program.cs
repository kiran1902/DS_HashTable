using DS_HashTable;

Console.WriteLine("Welcome To HashTable Program");

MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
hash.Add("0", "To");
hash.Add("1", "Be");
hash.Add("2", "Or");
hash.Add("3", "Not");
hash.Add("4", "To");
hash.Add("5", "Be");

string hash5 = hash.Get("5");
Console.WriteLine("5th Index Value : " + hash5);

//hash removal("2")
string hash2 = hash.Get("2");
Console.WriteLine("2nd Index Value : " + hash2);

