namespace AncientTool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CmdFiles = new System.Windows.Forms.Button();
            this.LblInput = new System.Windows.Forms.Label();
            this.TxtInput = new System.Windows.Forms.RichTextBox();
            this.LblResult = new System.Windows.Forms.RichTextBox();
            this.LblOutput = new System.Windows.Forms.Label();
            this.CmdVerse = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmdFiles
            // 
            resources.ApplyResources(this.CmdFiles, "CmdFiles");
            this.CmdFiles.Name = "CmdFiles";
            this.CmdFiles.UseVisualStyleBackColor = true;
            this.CmdFiles.Click += new System.EventHandler(this.CmdFiles_Click);
            // 
            // LblInput
            // 
            this.LblInput.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.LblInput, "LblInput");
            this.LblInput.Name = "LblInput";
            this.LblInput.Click += new System.EventHandler(this.LblInput_Click);
            // 
            // TxtInput
            // 
            resources.ApplyResources(this.TxtInput, "TxtInput");
            this.TxtInput.Name = "TxtInput";
            this.TxtInput.Tag = "";
            this.TxtInput.TextChanged += new System.EventHandler(this.TxtInput_TextChanged);
            // 
            // LblResult
            // 
            this.LblResult.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.LblResult, "LblResult");
            this.LblResult.Name = "LblResult";
            this.LblResult.ReadOnly = true;
            this.LblResult.TextChanged += new System.EventHandler(this.LblResult_TextChanged);
            // 
            // LblOutput
            // 
            resources.ApplyResources(this.LblOutput, "LblOutput");
            this.LblOutput.Name = "LblOutput";
            this.LblOutput.Click += new System.EventHandler(this.LblOutput_Click);
            // 
            // CmdVerse
            // 
            resources.ApplyResources(this.CmdVerse, "CmdVerse");
            this.CmdVerse.Name = "CmdVerse";
            this.CmdVerse.UseVisualStyleBackColor = true;
            this.CmdVerse.Click += new System.EventHandler(this.CmdVerse_Click);
            // 
            // CmdClear
            // 
            resources.ApplyResources(this.CmdClear, "CmdClear");
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.UseVisualStyleBackColor = true;
            this.CmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            // 
            // CmdExit
            // 
            resources.ApplyResources(this.CmdExit, "CmdExit");
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdVerse);
            this.Controls.Add(this.LblResult);
            this.Controls.Add(this.LblOutput);
            this.Controls.Add(this.TxtInput);
            this.Controls.Add(this.LblInput);
            this.Controls.Add(this.CmdFiles);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdFiles;
        private System.Windows.Forms.Label LblInput;
        private System.Windows.Forms.RichTextBox TxtInput;
        private System.Windows.Forms.RichTextBox LblResult;
        private System.Windows.Forms.Label LblOutput;
        private System.Windows.Forms.Button CmdVerse;
        private System.Windows.Forms.Button CmdClear;
        private System.Windows.Forms.Button CmdExit;
    }
}