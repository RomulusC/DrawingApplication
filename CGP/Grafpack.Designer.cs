namespace DrawingApplication
{
    partial class Grafpack
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bASICCIRCLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eLLIPSEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightAngleTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eqilateralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOTATEALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rECTANGLEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rECTANGLEToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.triangleToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.controlsToolStripMenuItem,
            this.rOTATEALLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.selectToolStripMenuItem.Text = "SELECT";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rECTANGLEToolStripMenuItem1,
            this.rECTANGLEToolStripMenuItem2});
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.rectangleToolStripMenuItem.Text = "QUADRILATERAL";            
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bASICCIRCLEToolStripMenuItem,
            this.eLLIPSEToolStripMenuItem1});
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.ellipseToolStripMenuItem.Text = "CIRCULAR";
            // 
            // bASICCIRCLEToolStripMenuItem
            // 
            this.bASICCIRCLEToolStripMenuItem.Name = "bASICCIRCLEToolStripMenuItem";
            this.bASICCIRCLEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bASICCIRCLEToolStripMenuItem.Text = "CIRCLE";
            this.bASICCIRCLEToolStripMenuItem.Click += new System.EventHandler(this.bASICCIRCLEToolStripMenuItem_Click);
            // 
            // eLLIPSEToolStripMenuItem1
            // 
            this.eLLIPSEToolStripMenuItem1.Name = "eLLIPSEToolStripMenuItem1";
            this.eLLIPSEToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.eLLIPSEToolStripMenuItem1.Text = "ELLIPSE";
            this.eLLIPSEToolStripMenuItem1.Click += new System.EventHandler(this.eLLIPSEToolStripMenuItem1_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightAngleTriangleToolStripMenuItem,
            this.eqilateralToolStripMenuItem});
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.triangleToolStripMenuItem.Text = "TRIANGLE";
            // 
            // rightAngleTriangleToolStripMenuItem
            // 
            this.rightAngleTriangleToolStripMenuItem.Name = "rightAngleTriangleToolStripMenuItem";
            this.rightAngleTriangleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rightAngleTriangleToolStripMenuItem.Text = "RIGHT ANGLE";
            this.rightAngleTriangleToolStripMenuItem.Click += new System.EventHandler(this.rightAngleTriangleToolStripMenuItem_Click);
            // 
            // eqilateralToolStripMenuItem
            // 
            this.eqilateralToolStripMenuItem.Name = "eqilateralToolStripMenuItem";
            this.eqilateralToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eqilateralToolStripMenuItem.Text = "ISOSCELES";
            this.eqilateralToolStripMenuItem.Click += new System.EventHandler(this.eqilateralToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.clearToolStripMenuItem.Text = "CLEAR ALL";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.controlsToolStripMenuItem.Text = "HELP";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // rOTATEALLToolStripMenuItem
            // 
            this.rOTATEALLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oNToolStripMenuItem,
            this.oFFToolStripMenuItem});
            this.rOTATEALLToolStripMenuItem.Name = "rOTATEALLToolStripMenuItem";
            this.rOTATEALLToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.rOTATEALLToolStripMenuItem.Text = "ROTATE ALL ";
            // 
            // oNToolStripMenuItem
            // 
            this.oNToolStripMenuItem.Name = "oNToolStripMenuItem";
            this.oNToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.oNToolStripMenuItem.Text = "ON";
            this.oNToolStripMenuItem.Click += new System.EventHandler(this.oNToolStripMenuItem_Click);
            // 
            // oFFToolStripMenuItem
            // 
            this.oFFToolStripMenuItem.Name = "oFFToolStripMenuItem";
            this.oFFToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.oFFToolStripMenuItem.Text = "OFF";
            this.oFFToolStripMenuItem.Click += new System.EventHandler(this.oFFToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // rECTANGLEToolStripMenuItem1
            // 
            this.rECTANGLEToolStripMenuItem1.Name = "rECTANGLEToolStripMenuItem1";
            this.rECTANGLEToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.rECTANGLEToolStripMenuItem1.Text = "SQUARE";
            this.rECTANGLEToolStripMenuItem1.Click += new System.EventHandler(this.rECTANGLEToolStripMenuItem1_Click);
            // 
            // rECTANGLEToolStripMenuItem2
            // 
            this.rECTANGLEToolStripMenuItem2.Name = "rECTANGLEToolStripMenuItem2";
            this.rECTANGLEToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.rECTANGLEToolStripMenuItem2.Text = "RECTANGLE";
            this.rECTANGLEToolStripMenuItem2.Click += new System.EventHandler(this.rECTANGLEToolStripMenuItem2_Click);
            // 
            // Grafpack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Grafpack";
            this.Text = "Grafpack";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rightAngleTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eqilateralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOTATEALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bASICCIRCLEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eLLIPSEToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rECTANGLEToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rECTANGLEToolStripMenuItem2;
    }
}

