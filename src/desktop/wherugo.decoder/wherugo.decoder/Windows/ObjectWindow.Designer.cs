namespace org.mars3142.wherugo.decoder.Windows
{
   partial class ObjectWindow
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectWindow));
         this.lbObject = new System.Windows.Forms.ListBox();
         this.pmnItems = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.mnExportItem = new System.Windows.Forms.ToolStripMenuItem();
         this.pbImage = new System.Windows.Forms.PictureBox();
         this.mnExportItems = new System.Windows.Forms.ToolStripMenuItem();
         this.pmnItems.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
         this.SuspendLayout();
         // 
         // lbObject
         // 
         this.lbObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.lbObject.ContextMenuStrip = this.pmnItems;
         this.lbObject.FormattingEnabled = true;
         this.lbObject.Location = new System.Drawing.Point(12, 12);
         this.lbObject.Name = "lbObject";
         this.lbObject.Size = new System.Drawing.Size(190, 355);
         this.lbObject.TabIndex = 0;
         this.lbObject.SelectedIndexChanged += new System.EventHandler(this.lbObject_SelectedIndexChanged);
         // 
         // pmnItems
         // 
         this.pmnItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnExportItem,
            this.mnExportItems});
         this.pmnItems.Name = "contextMenuStrip1";
         this.pmnItems.Size = new System.Drawing.Size(166, 70);
         // 
         // mnExportItem
         // 
         this.mnExportItem.Name = "mnExportItem";
         this.mnExportItem.Size = new System.Drawing.Size(165, 22);
         this.mnExportItem.Text = "Export this object";
         this.mnExportItem.Click += new System.EventHandler(this.mnExportItem_Click);
         // 
         // pbImage
         // 
         this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.pbImage.Location = new System.Drawing.Point(208, 12);
         this.pbImage.Name = "pbImage";
         this.pbImage.Size = new System.Drawing.Size(314, 354);
         this.pbImage.TabIndex = 1;
         this.pbImage.TabStop = false;
         // 
         // mnExportItems
         // 
         this.mnExportItems.Name = "mnExportItems";
         this.mnExportItems.Size = new System.Drawing.Size(165, 22);
         this.mnExportItems.Text = "Export all objects";
         this.mnExportItems.Click += new System.EventHandler(this.mnExportItems_Click);
         // 
         // ObjectWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(534, 378);
         this.Controls.Add(this.pbImage);
         this.Controls.Add(this.lbObject);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ObjectWindow";
         this.Text = "ObjectWindow";
         this.pmnItems.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox lbObject;
      private System.Windows.Forms.PictureBox pbImage;
      private System.Windows.Forms.ContextMenuStrip pmnItems;
      private System.Windows.Forms.ToolStripMenuItem mnExportItem;
      private System.Windows.Forms.ToolStripMenuItem mnExportItems;
   }
}