using System.Text;

namespace OSMMapLib
{
    public class Tile
    {
        private string url;
        private int x;
        private int y;
        private int _zoom;

        public int X   
        {
            get { return x; }
            private set { x = value; }
        }

        public int Y
        {
            get { return y; }
            private set { y = value; }
        }

        public int Zoom
        {
            get { return _zoom; }
            private set
            {
                if (value < 1)
                    _zoom = 1;
                else
                    _zoom = value;
            }
        }

        public string Url
        {
            get { return url; }
            private set { url = value; }
        }

        public Tile(int x, int y, int zoom, string url)
        {
            X = x;
            Y = y;
            Zoom = zoom;
            Url = url;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[").Append(X).Append(", ").Append(Y).Append(", ").Append(Zoom).Append("]: ").Append(Url);

            return sb.ToString();
        }
    }
    
}
