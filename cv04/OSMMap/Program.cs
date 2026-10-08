using OSMMapLib;

namespace OSMMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            map.Layer = new Layer(maxZoom:17);
            map.Lat = 49.058744;
            map.Lon = 15.814833;
            map.Zoom = 14;
            map.Render("map.png");

        }
    }
}
