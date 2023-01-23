using CSScripting;
using CSScriptLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace CsSrcipt.unload.issue;
internal class ScriptRunner
{

	public Thread Runner { get; }

	public ScriptRunner()
	{
		Runner = new Thread(Run);
	}


	void Run()
	{
		var script = """
			public int Add(int x, int y)
			{
				return x + y;
			}
			""";

		var runnable = CSScript.Evaluator.With(eval =>
		{
			eval.IsAssemblyUnloadingEnabled = true;
			eval.IsCachingEnabled = false;
		})
		.LoadMethod<IRunnable>(script);

		var result = runnable.Add(1, 2);
		Console.WriteLine($"Result: {result}");

		Thread.Sleep(1000);

		//TODO: unload via context
		//var asm = runnable.GetType().Assembly;
		//var ctx = AssemblyLoadContext.GetLoadContext(asm);
		//ctx!.Unload();

		//TODO: unload via assembly
		var asm2 = runnable.GetType().Assembly;
		asm2.Unload();

		Thread.Sleep(10000);

	}

}

public interface IRunnable
{
	int Add(int x, int y);
}
