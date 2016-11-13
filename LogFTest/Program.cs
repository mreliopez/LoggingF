/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 15/10/2016
 * Time: 21:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using LoggingF;

namespace LogFTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			LogF log = LogFactory.GetLogger("Program");
			log.Trace("Mensaje 1");
			log.Info("Mensaje 2");
			log.Debug("Mensaje 3");
			log.Notice("Mensaje 4");
			log.Warning("Mensaje 5");
			log.Error("Mensaje 6");
			log.Critical("Mensaje 7");
			Console.ReadKey(true);
		}
	}
}