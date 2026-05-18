namespace Challenge1
{
    class MyLine
    {
        //--- private fields ---
        private MyPoint begin;
        private MyPoint end;

        //--- constructor ---
        public MyLine(int x1, int y1, int x2, int y2)
        {
            begin = new MyPoint(x1, y1);
            end = new MyPoint(x2, y2);
        }

        //--- getters and setters ---
        public MyPoint GetBegin() { return begin; }
        public MyPoint GetEnd() { return end; }

        public void SetBegin(int x, int y) { begin.SetXY(x, y); }
        public void SetEnd(int x, int y) { end.SetXY(x, y); }

        //--- length using distance formula ---
        public double GetLength()
        {
            return begin.DistanceWithObject(end);
        }

        //--- gradient  m = (y2 - y1) / (x2 - x1) ---
        public double GetGradient()
        {
            int dx = end.GetX() - begin.GetX();
            if (dx == 0)
            {
                Console.WriteLine("Gradient is undefined (vertical line).");
                return double.NaN;
            }
            return (double)(end.GetY() - begin.GetY()) / dx;
        }

        //--- distance of begin point from origin ---
        public double BeginDistanceFromZero()
        {
            return begin.DistanceFromZero();
        }

        //--- distance of end point from origin ---
        public double EndDistanceFromZero()
        {
            return end.DistanceFromZero();
        }
    }
}