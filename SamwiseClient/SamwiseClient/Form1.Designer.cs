namespace SamwiseClient
{
    partial class MainForm
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
            this.debugLog = new System.Windows.Forms.RichTextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // debugLog
            // 
            this.debugLog.Location = new System.Drawing.Point(12, 12);
            this.debugLog.Name = "debugLog";
            this.debugLog.Size = new System.Drawing.Size(776, 397);
            this.debugLog.TabIndex = 0;
            this.debugLog.Text = "";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(618, 415);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(170, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Start";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.run_button_click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.debugLog);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox debugLog;
        private System.Windows.Forms.Button runButton;
    }
}

