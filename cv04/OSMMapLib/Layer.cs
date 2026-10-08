using System;
using System.Collections.Generic;
using System.Text;

namespace OSMMapLib
{
    public class Layer
    {
        public string UrlTemplate { get; private set; }

        public int MaxZoom { get; private set; }

        public Layer(
            string urlTemplate= "http://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png",
            int maxZoom = 10)
        {
            UrlTemplate = urlTemplate;
            MaxZoom = maxZoom;
        }

        public string FormatUrl(int x, int y, int zoom)
        { 
            Random random = new Random();
            int n = random.Next('a', 'd');

            string tmp = UrlTemplate.Replace("{x}", x.ToString())
                .Replace("{y}", y.ToString())
                .Replace("{z}", zoom.ToString())
                .Replace("{c}", ((char)n).ToString());

            return tmp;
        }

        public Tile this[int x, int y, int zoom]
        {
            get { return new Tile(x,y,zoom,this.FormatUrl(x, y, zoom)); }
            //set {  }
        }

    }
}
