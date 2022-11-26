using HashidsNet;
using System;

namespace IntegerToHashId
{
    //For more information: https://github.com/ullmark/hashids.net
    //https://www.youtube.com/watch?v=tSuwe7FowzE
    class Program
    {
        static void Main(string[] args)
        {
            ExampleObject exampleObject1 = new ExampleObject() { Id = 1 };
            ExampleObject exampleObject2 = new ExampleObject() { Id = 2 };

            Hashids hashIds = new Hashids("With this string, encoded values will be unique to me", 11);
            string id1 = hashIds.Encode(exampleObject1.Id);
            string id2 = hashIds.Encode(exampleObject2.Id);
            if (hashIds.Decode(id1).Length > 0)
                Console.WriteLine($"{hashIds.Decode(id1)[0]}: {id1}");
            if (hashIds.Decode(id2).Length > 0)
                Console.WriteLine($"{hashIds.Decode(id2)[0]}: {id2}");

            //Ecode multiple ids
            var ids = hashIds.Encode(exampleObject1.Id, exampleObject2.Id);
            string decodedStr = String.Empty;
            int[] decodedIds = hashIds.Decode(ids);
            for (int i = 0; i < decodedIds.Length; i++)
                decodedStr += i != 0 ? $",{decodedIds[i]}" : decodedIds[i];

            Console.WriteLine($"{decodedStr}: {ids}");

            Console.ReadLine();
        }
    }
    class ExampleObject
    {
        public int Id { get; set; }
    }
}
