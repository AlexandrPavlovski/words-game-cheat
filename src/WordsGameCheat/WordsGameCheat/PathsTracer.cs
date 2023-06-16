using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WordsGameCheat;

namespace WordsGameCheat
{
    internal class PathsTracer
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, int dwExtraInfo);

        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;


        int playfieldTopOffset = 350;
        int playfieldLeftOffset = 410;
        int tileSize = 82;

        Point wLoc;

        public PathsTracer(Point windowLocation)
        {
            wLoc = windowLocation;
        }

        public void Trace(List<Point[]> paths)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                var path = paths[i];
                MoveCursorToTile(path[0]);
                Thread.Sleep(10);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 50, 50, 0, 0);
                for (int j = 1; j < path.Length; j++)
                {
                    Thread.Sleep(15);
                    MoveCursorToTile(path[j]);
                }
                Thread.Sleep(20);
                mouse_event(MOUSEEVENTF_LEFTUP, 50, 50, 0, 0);
                Thread.Sleep(20);
            }
        }

        private void MoveCursorToTile(Point p)
        {
            SetCursorPos(playfieldLeftOffset + wLoc.x + tileSize * p.x, playfieldTopOffset + wLoc.y + tileSize * p.y);
        }
    }
}
