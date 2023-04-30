namespace ResolutionSelector
{
    partial class ResolutionsModal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbFullScreen = new CheckBox();
            lbResolutions = new ListBox();
            butOk = new Button();
            SuspendLayout();
            // 
            // cbFullScreen
            // 
            cbFullScreen.AutoSize = true;
            cbFullScreen.Location = new Point(12, 13);
            cbFullScreen.Name = "cbFullScreen";
            cbFullScreen.Size = new Size(83, 19);
            cbFullScreen.TabIndex = 0;
            cbFullScreen.Text = "Full Screen";
            cbFullScreen.UseVisualStyleBackColor = true;
            // 
            // lbResolutions
            // 
            lbResolutions.FormattingEnabled = true;
            lbResolutions.ItemHeight = 15;
            lbResolutions.Location = new Point(12, 43);
            lbResolutions.Name = "lbResolutions";
            lbResolutions.Size = new Size(318, 184);
            lbResolutions.TabIndex = 1;
            // 
            // butOk
            // 
            butOk.BackColor = Color.FromArgb(192, 255, 192);
            butOk.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 192);
            butOk.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            butOk.ForeColor = Color.FromArgb(0, 192, 0);
            butOk.Location = new Point(12, 245);
            butOk.Name = "butOk";
            butOk.Size = new Size(318, 36);
            butOk.TabIndex = 2;
            butOk.Text = "OK";
            butOk.UseVisualStyleBackColor = false;
            // 
            // ResolutionsModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 296);
            Controls.Add(butOk);
            Controls.Add(lbResolutions);
            Controls.Add(cbFullScreen);
            Name = "ResolutionsModal";
            Text = "Selecto Resolution";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbFullScreen;
        private ListBox lbResolutions;
        private Button butOk;
    }
}