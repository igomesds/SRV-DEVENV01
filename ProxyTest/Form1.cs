using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ProxyTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGoSync;
		private System.Windows.Forms.Button btnGoAsync;
		private System.Windows.Forms.TextBox txtSync;
		private System.Windows.Forms.TextBox txtAsync1;
		private System.Windows.Forms.TextBox txtAsync2;
		private System.Windows.Forms.Label lblAsync1;
		private System.Windows.Forms.Label lblAsync2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnGoSync = new System.Windows.Forms.Button();
			this.btnGoAsync = new System.Windows.Forms.Button();
			this.txtSync = new System.Windows.Forms.TextBox();
			this.txtAsync1 = new System.Windows.Forms.TextBox();
			this.txtAsync2 = new System.Windows.Forms.TextBox();
			this.lblAsync1 = new System.Windows.Forms.Label();
			this.lblAsync2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnGoSync
			// 
			this.btnGoSync.Location = new System.Drawing.Point(16, 8);
			this.btnGoSync.Name = "btnGoSync";
			this.btnGoSync.Size = new System.Drawing.Size(88, 23);
			this.btnGoSync.TabIndex = 0;
			this.btnGoSync.Text = "GO Sync";
			this.btnGoSync.Click += new System.EventHandler(this.btnGoSync_Click);
			// 
			// btnGoAsync
			// 
			this.btnGoAsync.Location = new System.Drawing.Point(16, 48);
			this.btnGoAsync.Name = "btnGoAsync";
			this.btnGoAsync.Size = new System.Drawing.Size(88, 56);
			this.btnGoAsync.TabIndex = 1;
			this.btnGoAsync.Text = "GO Async";
			this.btnGoAsync.Click += new System.EventHandler(this.btnGoAsync_Click);
			// 
			// txtSync
			// 
			this.txtSync.Location = new System.Drawing.Point(120, 8);
			this.txtSync.Name = "txtSync";
			this.txtSync.TabIndex = 2;
			this.txtSync.Text = "";
			// 
			// txtAsync1
			// 
			this.txtAsync1.Location = new System.Drawing.Point(120, 48);
			this.txtAsync1.Name = "txtAsync1";
			this.txtAsync1.TabIndex = 3;
			this.txtAsync1.Text = "";
			// 
			// txtAsync2
			// 
			this.txtAsync2.Location = new System.Drawing.Point(120, 80);
			this.txtAsync2.Name = "txtAsync2";
			this.txtAsync2.TabIndex = 4;
			this.txtAsync2.Text = "";
			// 
			// lblAsync1
			// 
			this.lblAsync1.Location = new System.Drawing.Point(232, 48);
			this.lblAsync1.Name = "lblAsync1";
			this.lblAsync1.TabIndex = 5;
			this.lblAsync1.Text = "label1";
			// 
			// lblAsync2
			// 
			this.lblAsync2.Location = new System.Drawing.Point(232, 80);
			this.lblAsync2.Name = "lblAsync2";
			this.lblAsync2.TabIndex = 6;
			this.lblAsync2.Text = "label2";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 118);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblAsync2,
																		  this.lblAsync1,
																		  this.txtAsync2,
																		  this.txtAsync1,
																		  this.txtSync,
																		  this.btnGoAsync,
																		  this.btnGoSync});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnGoAsync_Click(object sender, System.EventArgs e)
		{
			localhost.AppService objService = new localhost.AppService();

			// First Async call
			AsyncCallback adrCallBack1 = new AsyncCallback(AppServiceCallback1);
			txtAsync1.Text = "";
			lblAsync1.Text = "";
			objService.BeginGetAppSettings("connectionString", 2500, adrCallBack1, objService);

			// Second Async call
			AsyncCallback adrCallBack2 = new AsyncCallback(AppServiceCallback2);
			txtAsync2.Text = "";
			lblAsync2.Text = "";
			objService.BeginGetAppSettings("connectionString", 5000, adrCallBack2, objService);		
		}

		private void AppServiceCallback1(IAsyncResult resAr)
		{
			localhost.AppService objService = (localhost.AppService)resAr.AsyncState;
			txtAsync1.Text = objService.EndGetAppSettings(resAr);
			lblAsync1.Text = DateTime.Now.ToLongTimeString();
		}

		private void AppServiceCallback2(IAsyncResult resAr)
		{
			localhost.AppService objService = (localhost.AppService)resAr.AsyncState;
			txtAsync2.Text = objService.EndGetAppSettings(resAr);
			lblAsync2.Text = DateTime.Now.ToLongTimeString();
		}

		private void btnGoSync_Click(object sender, System.EventArgs e)
		{

		}
	}
}
