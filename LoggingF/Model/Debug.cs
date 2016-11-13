/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 16/10/2016
 * Time: 11:31
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace LoggingF.Model
{
	public class Debug : Log
	{
		public Debug(string msg, string owner) : base(msg, owner)
		{
			LogType = Const.LogType.Debug;
			Color = ConsoleColor.Green;
		}
	}
}