namespace org.mars3142.wherugo.luatester.Windows
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
         this.btnLoad = new System.Windows.Forms.Button();
         this.txtLua = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // btnLoad
         // 
         this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnLoad.Location = new System.Drawing.Point(310, 343);
         this.btnLoad.Name = "btnLoad";
         this.btnLoad.Size = new System.Drawing.Size(75, 23);
         this.btnLoad.TabIndex = 0;
         this.btnLoad.Text = "Execute";
         this.btnLoad.UseVisualStyleBackColor = true;
         this.btnLoad.Click += new System.EventHandler(this.btnExecute_Click);
         // 
         // txtLua
         // 
         this.txtLua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtLua.Location = new System.Drawing.Point(12, 12);
         this.txtLua.MaxLength = 2000000000;
         this.txtLua.Multiline = true;
         this.txtLua.Name = "txtLua";
         this.txtLua.Size = new System.Drawing.Size(373, 325);
         this.txtLua.TabIndex = 1;
         // 
         // Main
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(397, 378);
         this.Controls.Add(this.txtLua);
         this.Controls.Add(this.btnLoad);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "Main";
         this.Text = "WherUGo Lua-Tester";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnLoad;
      private System.Windows.Forms.TextBox txtLua;
   }
}

