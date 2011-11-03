//  wherugo - WherUGo for Magellan eXplorist x10
//  Copyright (C) 2011 Peter Siegmund <developer@mars3142.org>
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace org.mars3142.wherugo.decoder.Windows
{
   partial class Main
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.fdGWC = new System.Windows.Forms.OpenFileDialog();
         this.pbOpen = new System.Windows.Forms.Button();
         this.txContent = new System.Windows.Forms.TextBox();
         this.imSplashScreen = new System.Windows.Forms.PictureBox();
         this.imSmallIcon = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.imSplashScreen)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.imSmallIcon)).BeginInit();
         this.SuspendLayout();
         // 
         // fdGWC
         // 
         this.fdGWC.Filter = "Cartridges|*.gwc|All files|*.*";
         this.fdGWC.Title = "Open Cartridge";
         // 
         // pbOpen
         // 
         this.pbOpen.Location = new System.Drawing.Point(12, 12);
         this.pbOpen.Name = "pbOpen";
         this.pbOpen.Size = new System.Drawing.Size(75, 23);
         this.pbOpen.TabIndex = 0;
         this.pbOpen.Text = "Open GWC";
         this.pbOpen.UseVisualStyleBackColor = true;
         this.pbOpen.Click += new System.EventHandler(this.pbOpen_Click);
         // 
         // txContent
         // 
         this.txContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txContent.Location = new System.Drawing.Point(12, 41);
         this.txContent.Multiline = true;
         this.txContent.Name = "txContent";
         this.txContent.Size = new System.Drawing.Size(459, 209);
         this.txContent.TabIndex = 1;
         // 
         // imSplashScreen
         // 
         this.imSplashScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.imSplashScreen.Location = new System.Drawing.Point(12, 256);
         this.imSplashScreen.Name = "imSplashScreen";
         this.imSplashScreen.Size = new System.Drawing.Size(225, 194);
         this.imSplashScreen.TabIndex = 2;
         this.imSplashScreen.TabStop = false;
         // 
         // imSmallIcon
         // 
         this.imSmallIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.imSmallIcon.Location = new System.Drawing.Point(243, 256);
         this.imSmallIcon.Name = "imSmallIcon";
         this.imSmallIcon.Size = new System.Drawing.Size(228, 194);
         this.imSmallIcon.TabIndex = 3;
         this.imSmallIcon.TabStop = false;
         // 
         // Main
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(483, 462);
         this.Controls.Add(this.imSmallIcon);
         this.Controls.Add(this.imSplashScreen);
         this.Controls.Add(this.txContent);
         this.Controls.Add(this.pbOpen);
         this.Name = "Main";
         this.Text = "Open GWC";
         ((System.ComponentModel.ISupportInitialize)(this.imSplashScreen)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.imSmallIcon)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

       private System.Windows.Forms.OpenFileDialog fdGWC;
       private System.Windows.Forms.Button pbOpen;
       private System.Windows.Forms.TextBox txContent;
      private System.Windows.Forms.PictureBox imSplashScreen;
      private System.Windows.Forms.PictureBox imSmallIcon;
   }
}

