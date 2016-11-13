/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 11/10/2016
 * Time: 09:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LoggingF.Model
{
	/// <summary>
	/// Description of Trace.
	/// </summary>
	public class Trace : Log
	{
		public Trace(string msg, string owner) : base(msg, owner)
		{
			Color = ConsoleColor.Magenta;
			LogType = Const.LogType.Trace;
		}
		
		
	}
}
