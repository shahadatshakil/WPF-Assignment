using Newtonsoft.Json.Linq;
using NewYorkTimesBestSellers.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;

namespace NewYorkTimesBestSellers.Services
{
    public class APIHelper
    {
        public string GetJSONString(string apiURL)
        {
            string str = "";
            try
            {
                WebClient client = new WebClient();
                str = client.DownloadString(apiURL);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not retrieve the list!","Error!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            return str;
        }

        public ObservableCollection<Book> GetBooks()
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();
            try
            {
                string str = GetJSONString(Constants.BookRetrieveAPI);
                JObject jObject = JObject.Parse(str);
                JToken jToken = jObject["results"];
                Results result = jToken.ToObject<Results>();
                List <Book> allBook = result.books;
                books = new ObservableCollection<Book>(allBook);
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not retrieve the list!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return books;
        }
    }
}
