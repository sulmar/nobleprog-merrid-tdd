using System;
using System.IO;
using System.Text.Json;
using static TestApp.Mocking.TrackingService;

namespace TestApp.Mocking
{
    public interface IFileReader
    {
        string Get(string path);
    }

    public class FileReader : IFileReader
    {
        public string Get(string path)
        {
            return File.ReadAllText(path);
        }
    }



    public class TrackingService
    {
        private IFileReader fileReader;

        public TrackingService()
        {
            this.fileReader = new FileReader();
        }

        public TrackingService(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public Location Get()
        {
            string json = fileReader.Get("tracking.txt");

            try
            {
                Location location = JsonSerializer.Deserialize<Location>(json);

                if (location == null)
                    throw new ApplicationException("Error parsing the location");

                return location;
            }
            catch (JsonException e)
            {
                throw new ApplicationException();
            }



        }


        public class Location
        {
            public Location(double latitude, double longitude)
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public override string ToString()
            {
                return $"{Latitude} {Longitude}";
            }
        }
    }
}
