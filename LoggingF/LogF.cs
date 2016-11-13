/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 11/10/2016
 * Time: 09:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using LoggingF.Model;
using LoggingF.Persistence;

namespace LoggingF
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class LogF
	{
		public string Owner {get;set;}
		
		public LogF(string owner)
		{
			Owner = owner;
		}
		
		public Trace Trace(string msg)
		{
			Trace t = new Trace(msg, Owner);
			Dump(t);
			return t;
		}
		
		public Info Info(string msg)
		{
			Info i = new Info(msg, Owner);
			Dump(i);
			return i;
		}
		
		public Debug Debug(string msg)
		{
			Debug d = new LoggingF.Model.Debug(msg, Owner);
			Dump(d);
			return d;
		}
		
		public Notice Notice(string msg)
		{
			Notice n = new LoggingF.Model.Notice(msg, Owner);
			Dump(n);
			return n;
		}
		
		public Warning Warning(string msg)
		{
			Warning w = new LoggingF.Model.Warning(msg, Owner);
			Dump(w);
			return w;
		}
		
		public Error Error(string msg)
		{
			Error e = new LoggingF.Model.Error(msg, Owner);
			Dump(e);
			return e;
		}
		
		public Critical Critical(string msg)
		{
			Critical c = new LoggingF.Model.Critical(msg, Owner);
			Dump(c);
			return c;
		}
		
		void Dump(Log l)
		{
			DumpToConsole(l);
			LogFPersistor.Instance.Add(l);
		}
		
		void DumpToConsole(Log l)
		{
			string line = string.Empty;
			ConsoleColor cc = Console.ForegroundColor;
			if(Options.Instance.LogConsoleType == Const.LogConsoleType.FullColor)
			{
				line = string.Format(Const.LogTemplate.LOG_TYPE_1, l.Date, l.LogType.ToString(), l.Owner, l.Message);
				Console.ForegroundColor = l.Color;
				Console.WriteLine(line);
			}
			else
			{
				line = string.Format(Const.LogTemplate.LOG_DATE, l.Date);
				Console.Write(line);
				Console.ForegroundColor = l.Color;
				line = string.Format(Const.LogTemplate.LOG_LOG_TYPE, l.LogType.ToString());
				Console.Write(line);
				Console.ForegroundColor = cc;
				line = string.Format(Const.LogTemplate.LOG_OWNER_MESSAGE, l.Owner, l.Message);
				Console.WriteLine(line);
			}
			Console.ForegroundColor = cc;
		}
	}
}