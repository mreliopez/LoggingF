/*
 * Created by SharpDevelop.
 * User: eselv
 * Date: 11/10/2016
 * Time: 09:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LoggingF.Model;

namespace LoggingF.Persistence
{
	/// <summary>
	/// Description of LogFPersistor.
	/// </summary>
	public class LogFPersistor
	{
		string folder = "logs";
		string filepath = "";
		static LogFPersistor instance;
		List<Log> logBuffer;
		List<Log> log;
		
		LogFPersistor()
		{
			logBuffer = new List<Log>();
			log = new List<Log>();
			filepath = folder + "/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-full-log.log";
			CreateFile();
			BeginThread();
		}
		
		void BeginThread()
		{
			Task.Factory.StartNew(Start);
		}
		
		void CreateFile()
		{
			
			CreateFolder();
			try
			{
				if(!File.Exists(filepath))
					File.Create(filepath);
			}
			catch(Exception e)
			{
				ErrorDumper.Instance.Dump(string.Format("Create File Error. e:{0}", e.ToString()));
			}
		}
		
		void CreateFolder()
		{
			try
			{
				if(!Directory.Exists(folder))
					Directory.CreateDirectory(folder);			
			}
			catch(Exception e)
			{
				ErrorDumper.Instance.Dump(string.Format("Error on Creating Folder. e: {0}", e.ToString()));
				folder = string.Empty;
			}
		}
		
		public static LogFPersistor Instance
		{
			get{
				if(instance == null)
					instance = new LogFPersistor();
				return instance;
			}
		}
		
		public void Add(Log l)
		{
			lock(this)
				logBuffer.Add(l);
		}
		
		public void Start()
		{
			try
			{
				int count = 0;
				while(true)
				{
					try
					{
						System.Threading.Thread.Sleep(100);
						if( count == 5)
						{
							DoPersist();
							count = 0;
						}
						CopyBuffers();
						count++;
					}
					catch(Exception e)
					{
						ErrorDumper.Instance.Dump(string.Format("There was an error in persistor thread. We will try to carry on. e:{0}", e.ToString()));
					}
				}
			}
			catch(Exception e)
			{
				ErrorDumper.Instance.Dump(string.Format("Error in persistor thread. e:{0}", e.ToString()));
			}
			
		}
		
		void CopyBuffers()
		{
			lock(this)
			{
				log.AddRange(logBuffer.GetRange(0, logBuffer.Count));
				logBuffer.Clear();
			}
		}
		
		void DoPersist()
		{
			lock(this)
			{
				FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Write);
				StreamWriter sw = new StreamWriter(fs);
				StringBuilder sb = new StringBuilder();
				foreach(Log l in log)
				{
					string line = string.Format(Const.LogTemplate.LOG_TYPE_1, l.Date, l.LogType.ToString(), l.Owner, l.Message);					
					sb.AppendLine(line);
				}
				sw.WriteLine(sb.ToString());
				sw.Flush();
				sw.Close();
			}
		}
	}
}
