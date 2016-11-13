/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 16/10/2016
 * Time: 11:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LoggingF.Model
{
	/// <summary>
	/// Description of Critical.
	/// </summary>
	public class Critical : Log
	{
		public Critical(string msg, string owner) : base(msg, owner)
		{
			LogType = Const.LogType.Critical;
			Color = ConsoleColor.DarkRed;
		}
	}
}
