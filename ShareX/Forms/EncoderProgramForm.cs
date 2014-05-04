﻿#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (C) 2008-2014 ShareX Developers

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using HelpersLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShareX
{
    public partial class EncoderProgramForm : Form
    {
        public VideoEncoder encoder { get; private set; }

        public EncoderProgramForm()
            : this(new VideoEncoder())
        {
        }

        public EncoderProgramForm(VideoEncoder encoder)
        {
            Icon = ShareXResources.Icon;
            this.encoder = encoder;
            InitializeComponent();
            txtName.Text = encoder.Name ?? "";
            txtPath.Text = encoder.Path ?? "";
            txtArguments.Text = encoder.Args ?? "";
            txtExtension.Text = encoder.OutputExtension ?? "";
        }

        private void btnPathBrowse_Click(object sender, EventArgs e)
        {
            Helpers.BrowseFile("ShareX - Choose encoder path", txtPath);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("Path can't be empty.", "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtExtension.Text))
            {
                MessageBox.Show("Extension can't be empty.", "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            encoder.Name = txtName.Text;
            encoder.Path = txtPath.Text;
            encoder.Args = txtArguments.Text;
            encoder.OutputExtension = txtExtension.Text;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}