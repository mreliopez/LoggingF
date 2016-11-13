/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 15/10/2016
 * Time: 21:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LoggingF.Const
{
	/// <summary>
	/// Description of LogTemplate.
	/// </summary>
	public struct LogTemplate
	{
		/// <summary>
		/// {0} Date, {1} Type, {2} Owner, {3} message
		/// </summary>
		public const string LOG_TYPE_1 = "[ {0} ] [ {1} ] {2} >> {3}";
		public const string LOG_DATE = "[ {0} ] ";
		public const string LOG_LOG_TYPE = "[ {0} ] ";
		public const string LOG_OWNER_MESSAGE = " {0} >> {1}";
	}
}
