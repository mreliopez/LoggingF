/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 11/10/2016
 * Time: 09:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LoggingF.Model
{
	/// <summary>
	/// Description of Log.
	/// </summary>
	public class Log
	{
		public Const.LogType LogType {get;set;}
		public ConsoleColor Color {get;set;}
		public string Message {get;set;}
		public string Owner {get;set;}
		public string Date {get;set;}
		
		public Log(string msg, string owner)
		{
			Message = msg;
			Owner = owner;
			Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}
