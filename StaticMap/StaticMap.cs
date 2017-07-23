/*!
 * \author Victor D. Montero
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StaticMap
{
    /*!
     * \brief Helper class to download an static map image
     * 
     * This class provides some methods to downloads static map image from google.
     * You need a Google Api Key, in order to use the service
     * please specify such key before using the any method of this library.
     */
    public static class StaticMap
    {

        public static string GoogleKey { get; set; }/*! https://developers.google.com/maps/documentation/javascript/get-api-key */
        public static string ApiUrl = "https://maps.googleapis.com/maps/api/staticmap";

        /*!
         * \brief Downloads a png image with a resolution up to 640 x 480
         * 
         * This function returns an image serialized as a byte array.
         * \param[in] latitude.
         * \param[in] longitude.
         * \param[in] key: this is a free developer google key. Its mandatory to have it, in order to use
         * the google static maps service.
         * \param[in] options: a key value pair collection, containing all optional parameters.
         * 
         * For more information about static maps, see: https://developers.google.com/maps/documentation/static-maps/intro
         * 
         */
        public static byte[] DownloadMap(double latitude, double longitude, Dictionary<string, string> options = null)
        {
            WebClient client = new WebClient();

            return client.DownloadData(GenerateUrl(latitude, longitude, options));
        }

        private static string GenerateUrl(double latitude, double longitude, Dictionary<string, string> options)
        {
            string url = string.Empty;

            if (options == null)
                options = new Dictionary<string, string>();

            if (!options.ContainsKey("center"))
                options.Add("center", string.Format("{0},{1}", latitude, longitude));

            if (!options.ContainsKey("size"))
                options.Add("size", string.Format("{0}x{1}", 1024, 768));

            if (!options.ContainsKey("zoom"))
                options.Add("zoom", string.Format("{0}", 19));

            if (!options.ContainsKey("markers"))
                options.Add("markers", string.Format("color:red|{0},{1}", latitude, longitude));

            url = ApiUrl;
            url += "?";

            foreach (KeyValuePair<string, string> pair in options)
            {
                url += string.Format("{0}={1}", pair.Key, pair.Value);
                url += "&";
            }

            url += string.Format("key={0}", GoogleKey);

            return url;
        }
    }
}
