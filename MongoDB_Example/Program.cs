using System;
using MongoDB.Driver;


namespace MongoDB_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cluster name = myFirstDatabase
            //Database name(s) = sample_airbnb | sample_analytics | sample_geospatial | sample_mflix | sample_restaurants | sample_supplies | sample_training | sample_weatherdata
            //Collections (aka tables) = listed under each database ^

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Wadders_88:O2z4HTSyLDrecSeo@mysampledb.xcrwt.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("sample_training");

            var dbList = database.ListCollections().ToList();
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }

        }
    }
}
