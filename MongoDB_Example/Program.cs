using System;
using MongoDB.Driver;
using MongoDB.Bson;


namespace MongoDB_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //NOTES:
            //Cluster name = myFirstDatabase
            //Database name(s) = sample_airbnb | sample_analytics | sample_geospatial | sample_mflix | sample_restaurants | sample_supplies | sample_training | sample_weatherdata
            //Collections (aka tables) = listed under each database ^

            //MongoDB connection
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Wadders_88:O2z4HTSyLDrecSeo@mysampledb.xcrwt.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("sample_training");

            //List collection names
            Console.WriteLine("Collection Names = ");
            var dbTableList = database.ListCollectionNames().ToList();
            foreach (var db in dbTableList)
            {
                Console.WriteLine(db);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //BsonDoc for dbstats
            var command = new BsonDocument { { "dbstats", 1 } };
            var res = database.RunCommand<BsonDocument>(command);
            Console.WriteLine("dbstats = {0}", res.ToJson());
            Console.WriteLine("");
            Console.WriteLine("");

            //BsonDoc with filter for companies called Facebook
            /*
            var companies = database.GetCollection<BsonDocument>("companies");
            var filter = Builders<BsonDocument>.Filter.Eq("name", "Facebook");
            var doc = companies.Find(filter).FirstOrDefault();
            Console.WriteLine(doc.ToString());
            */

        }
    }
}
