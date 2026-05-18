namespace Challenge1
{
    class MyPoint
    {
        //--- private fields ---
        private int x;
        private int y;

        //--- default constructor ---
        public MyPoint()
        {
            x = 0;
            y = 0;
        }

        //--- parameterized constructor ---
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //--- getters and setters ---
        public int GetX() { return x; }
        public void SetX(int x) { this.x = x; }

        public int GetY() { return y; }
        public void SetY(int y) { this.y = y; }

        //--- set both x and y ---
        public void SetXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //--- distance to another point using coordinates ---
        public double DistanceWithCords(int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - this.x, 2) + Math.Pow(y2 - this.y, 2));
        }

        //--- distance to another MyPoint object ---
        public double DistanceWithObject(MyPoint another)
        {
            return DistanceWithCords(another.x, another.y);
        }

        //--- distance from origin (0, 0) ---
        public double DistanceFromZero()
        {
            return DistanceWithCords(0, 0);
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}