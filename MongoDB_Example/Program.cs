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
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //My DB details
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Wadders_88 | d7BlSqKCqqfCHY4Z | mysampledb-shard-00-02.xcrwt.mongodb.net:27017 | Cluster name = mySampleDB
            //Database name(s) = sample_airbnb | sample_analytics | sample_geospatial | sample_mflix | sample_restaurants | sample_supplies | sample_training | sample_weatherdata
            //Collections (aka tables) = listed under each database ^
            //Connection string = mongodb+srv://Wadders_88:O2z4HTSyLDrecSeo@mysampledb.xcrwt.mongodb.net/mysampledb?retryWrites=true&w=majority
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Tom's DB details
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Wadders_88 | d7BlSqKCqqfCHY4Z | sampledb-shard-00-02.egd8v.mongodb.net:27017 | Cluster name = sampledb
            //Database name(s) = sample_airbnb | sample_analytics | sample_geospatial | sample_mflix | sample_restaurants | sample_supplies | sample_training | sample_weatherdata
            //Collections (aka tables) = listed under each database ^
            //Connection string = mongodb+srv://Wadders_88:d7BlSqKCqqfCHY4Z@sampledb.egd8v.mongodb.net/sampledb?retryWrites=true&w=majority
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //MongoDB connection
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Wadders_88:d7BlSqKCqqfCHY4Z@sampledb.egd8v.mongodb.net/sampledb?retryWrites=true&w=majority");
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

            //BsonDoc for dbstats
            /*
            var command = new BsonDocument { { "dbstats", 1 } };
            var res = database.RunCommand<BsonDocument>(command);
            Console.WriteLine("dbstats = {0}", res.ToJson());
            Console.WriteLine("");
            */

            //BsonDoc with filter for companies called Facebook
            /*
            var companies = database.GetCollection<BsonDocument>("companies");
            var filter = Builders<BsonDocument>.Filter.Eq("name", "Facebook");
            var doc = companies.Find(filter).FirstOrDefault();
            Console.WriteLine(doc.ToString());
            Console.WriteLine("");
            */

            //BsonDoc with filter count for companies called Facebook
            var companies = database.GetCollection<BsonDocument>("companies");
            var filter1 = companies.Find(Builders<BsonDocument>.Filter.Eq("name", "Facebook"));
            var filter2 = companies.Find(Builders<BsonDocument>.Filter.Eq("name", "Wetpaint"));
            Console.WriteLine("Companies count = {0}", filter1.CountDocuments() + filter2.CountDocuments());
            Console.WriteLine("");

        }
    }
}
