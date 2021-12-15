using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.IO;

namespace dnc_300_movie_finder_data.Controllers
{
    public class MovieFinderController : Controller
    {
        private const string API_KEY = "8d062334";
        private Hashtable movies;


        public MovieFinderController()
        {
            movies = new Hashtable();
        }

        public string FindMovie(string param, string value)
        {
            string url = "";
            string json = "";

            // Check if user query will be an IMBD ID or a movie title
            switch(param)
            {
                case "i":
                    url = $"http://omdbapi.com/?i={value}&apikey={API_KEY}";
                    break;
                case "t":
                    url = $"http://omdbapi.com/?t={value}&apikey={API_KEY}";
                    break;
            }

            // Check if requested movie is in our cache, if so return the data
            if (movies.ContainsKey(url))
            {
                return (string) movies[url];
            }

            try
            {
                using (WebClient client = new WebClient())
                {
                    json = client.DownloadString(url);
                }

            } catch(Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
            return json;
        }

    }
}
