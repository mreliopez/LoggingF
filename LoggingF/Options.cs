/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 15/10/2016
 * Time: 22:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LoggingF
{
	/// <summary>
	/// Description of Options.
	/// </summary>
	public class Options
	{
		static Options instance;
		#region Public Properties
		public Const.LogConsoleType LogConsoleType {get;set;}
		#endregion
		Options()
		{
			DefaultValues();
		}
		
		public static Options Instance
		{
			get
			{
				if(instance == null)
					instance = new Options();
				return instance;
			}
		}
		
		void DefaultValues()
		{
			LogConsoleType = Const.LogConsoleType.PartialColor;
		}
	}
}
