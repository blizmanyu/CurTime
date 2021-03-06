﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace CurTime
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());
			var now = DateTime.Now;
			Clipboard.SetText(now.ToString("yyyy MMdd HHmm ssff"));
			ShowBalloonTip(body: String.Format("Current time copied to clipboard!\n{0}", now.ToString("M/d/yyyy HH:mmtt").ToLower()));
			Application.Exit();
		}

		private static void ShowBalloonTip(string title = null, string body = null, int timeout = 2200)
		{
			using (var notifyIcon = new NotifyIcon()) {
				if (title != null)
					notifyIcon.BalloonTipTitle = title;

				if (body != null)
					notifyIcon.BalloonTipText = body;

				notifyIcon.Visible = true;
				notifyIcon.Icon = SystemIcons.Application;
				notifyIcon.ShowBalloonTip(timeout);
			}
		}
	}
}