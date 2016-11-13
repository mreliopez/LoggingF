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
	/// Description of Info.
	/// </summary>
	public class Info : Log
	{
		public Info(string msg, string owner) : base(msg, owner)
		{
			LogType = Const.LogType.Info;
			Color = ConsoleColor.White;
		}
	}
}
