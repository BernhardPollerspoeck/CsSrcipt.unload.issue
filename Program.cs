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


Thread.Sleep(10000);
LogAssemblyCount();


Console.WriteLine("Hello, World!");


static void LogAssemblyCount()
{
	Console.WriteLine($"{DateTime.Now}  {AppDomain.CurrentDomain.GetAssemblies().Length}");
}




