using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogError("Error, length is less than 3");
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            double lat1;
            if (double.TryParse(cells[0], out lat1) == false)
            {
                logger.LogError("Bad data. Wasn't able to parse as double");
            }
            // grab the longitude from your array at index 1
            double lon1;
            if (double.TryParse(cells[1], out lon1) == false)
            {
                logger.LogError("Bad data. Wasn't able to parse as double");
            }
            // grab the name from your array at index 2
            string name = cells[2];

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            var newPoint = new Point();
            newPoint.Longitude = lon1;
            newPoint.Latitude = lat1;
            ITrackable tacoBell = new TacoBell(name, newPoint);
            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable
            
            return tacoBell;
        }
        public static double ConvertToMiles(double meters)
        {
            return Math.Round(meters * .000621, 2);
        }
    }
}