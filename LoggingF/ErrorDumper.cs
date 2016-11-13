/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 15/10/2016
 * Time: 21:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;

namespace LoggingF
{
	/// <summary>
	/// Description of ErrorDumper.
	/// </summary>
	public class ErrorDumper
	{
		static ErrorDumper instance;
		
		ErrorDumper(){}
		
		public static ErrorDumper Instance
		{
			get
			{
				if(instance == null)
					instance = new ErrorDumper();
				return instance;
			}
		}
		
		public void Dump(string errormsg)
		{
			try
			{
				FileStream fs = CreateStream();
				StreamWriter sw = new StreamWriter(fs);
				StringBuilder sb = new StringBuilder();
				string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				sb.AppendLine(string.Format(Const.LogTemplate.LOG_TYPE_1, date, Const.LogType.Critical.ToString(), "LoggingFErrorDumper", errormsg ));
				sw.WriteLine(sb.ToString());
				sw.Flush();
				sw.Close();				
			}
			catch(Exception e)
			{
				Console.WriteLine("!!!!! FATAL !!!!! There was an error trying to dump another error. e:{0}", e.ToString());
			}
		}
		
		FileStream CreateStream()
		{
			const string filename = "loggingf-dump-error.log";
			return File.Open(filename, FileMode.OpenOrCreate, FileAccess.Write);
		}
	}
}
