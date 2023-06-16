using System.Diagnostics;
using System.Runtime.InteropServices;
using WordsGameCheat;

[DllImport("user32.dll")]
static extern bool GetWindowRect(IntPtr hwnd, ref Point p);


string[] windowTitles =
{
    "test",
    "friday stand up",
    "last day of sprint meeting"
};

Console.WriteLine("Start?");
Console.ReadLine();

//var t = pf.Paths.Select(x => x.Select(x => x.ToString()).Aggregate((c, n) => $"{c} - {n}")).ToList();
//var t2 = t.Distinct().ToList();

Process[] processList = Process.GetProcesses();
var gameProcess = processList.FirstOrDefault(x => windowTitles.Any(x.MainWindowTitle.ToLower().Contains));
if (gameProcess != null)
{
    IntPtr hWnd = gameProcess.MainWindowHandle;
    Point windowLocation = new Point();
    GetWindowRect(hWnd, ref windowLocation);

    var pt = new PathsTracer(windowLocation);

    Point p;
    int depth = 4;
    for (int x = 0; x < 4; x++)
    {
        for (int y = 0; y < 4; y++)
        {
            p.x = x;
            p.y = y;

            var pf = new PathsFinder();
            pf.Find(p, new Point[depth], 0);
            pt.Trace(pf.Paths);
        }
        Console.WriteLine("Continue?");
        Console.ReadLine();
    }
}
else
{
    Console.WriteLine("No window");
}

Console.WriteLine("Finished");
Console.ReadLine();
