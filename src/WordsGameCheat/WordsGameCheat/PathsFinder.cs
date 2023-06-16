namespace WordsGameCheat
{
    internal class PathsFinder
    {
        const int fieldSize = 4;
        bool[,] _playfield = new bool[fieldSize, fieldSize];

        public List<Point[]> Paths = new List<Point[]>();

        public void Find(Point p, Point[] path, int currentDepth)
        {
            _playfield[p.x, p.y] = true;
            path[currentDepth] = p;

            if (currentDepth + 1 < path.Length)
            {
                Point newP;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (i == 0 && j == 0) continue;

                        newP.x = p.x + i;
                        newP.y = p.y + j;
                        if (newP.x >= 0 && newP.x < fieldSize
                            && newP.y >= 0 && newP.y < fieldSize 
                            && !_playfield[newP.x, newP.y])
                        {
                            Find(newP, path, currentDepth + 1);
                        }
                    }
                }
            }
            else
            {
                Paths.Add((Point[])path.Clone());
            }

            _playfield[p.x, p.y] = false;
        }
    }
}
