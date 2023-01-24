using CSScripting;
using CSScriptLib;
using CsSrcipt.unload.issue;
using System.Runtime.Loader;
using System.Text;


LogAssemblyCount();

var runner = new ScriptRunner();

LogAssemblyCount();

runner.Runner.Start();

while (runner.Runner.ThreadState != ThreadState.Stopped)
{
	LogAssemblyCount();
	Thread.Sleep(1000);
}

runner = null;

LogAssemblyCount();
GC.Collect();
LogAssemblyCount();


Console.WriteLine("Hello, World!");


static void LogAssemblyCount()
{
	Console.WriteLine($"{DateTime.Now}  {AppDomain.CurrentDomain.GetAssemblies().Length}");
	Console.WriteLine($"  script assembly > {AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName.Contains("#1-0"))}");
}




