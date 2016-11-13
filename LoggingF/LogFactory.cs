/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 15/10/2016
 * Time: 21:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LoggingF
{
	/// <summary>
	/// Description of LogFactory.
	/// </summary>
	public static class LogFactory
	{
		public static LogF GetLogger(string owner)
		{
			return new LogF(owner);
		}
	}
}
