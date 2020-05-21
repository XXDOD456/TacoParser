using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();
            Console.WriteLine(locations.Length);
            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file

            // Now, here's the new code

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            // Create a `double` variable to store the distance
            ITrackable locA = null;
            ITrackable locB = null;
            double distance;
            double longestDistance = 0;
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            foreach(var loc1 in locations)
            {
                var coorA = new GeoCoordinate();
                coorA.Latitude = loc1.Location.Latitude;
                coorA.Longitude = loc1.Location.Longitude;

                foreach(var loc2 in locations)
                {
                    var coorB = new GeoCoordinate();
                    coorB.Latitude = loc2.Location.Latitude;
                    coorB.Longitude = loc2.Location.Longitude;

                    distance = coorA.GetDistanceTo(coorB);
                    if (distance > longestDistance)
                    {
                        longestDistance = distance;
                        locA = loc1;
                        locB = loc2;
                        
                    }
                }

            }
            Console.WriteLine($"Longest Distance {longestDistance}");
            Console.WriteLine($"LocA {locA.Name}");
            Console.WriteLine($"LocB {locB.Name}");
            var miles = TacoParser.ConvertToMiles(longestDistance);
            Console.WriteLine($"Miles: {miles}");
            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.



        }
    }
}
