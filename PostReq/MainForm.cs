﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PostReq
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			Text += $"{Assembly.}";
		}
	}
}
