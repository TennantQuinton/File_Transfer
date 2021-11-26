namespace File_Transfer
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
            this.select_files = new System.Windows.Forms.OpenFileDialog();
            this.output_button = new System.Windows.Forms.Button();
            this.output_rtextbox = new System.Windows.Forms.RichTextBox();
            this.select_output = new System.Windows.Forms.FolderBrowserDialog();
            this.transfer_label = new System.Windows.Forms.Label();
            this.run_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.show_check_list = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.movie_check_list = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // select_files
            // 
            this.select_files.FileName = "select_files";
            // 
            // output_button
            // 
            this.output_button.Location = new System.Drawing.Point(12, 427);
            this.output_button.Name = "output_button";
            this.output_button.Size = new System.Drawing.Size(142, 42);
            this.output_button.TabIndex = 7;
            this.output_button.Text = "Select Output";
            this.output_button.UseVisualStyleBackColor = true;
            this.output_button.Click += new System.EventHandler(this.output_button_Click);
            // 
            // output_rtextbox
            // 
            this.output_rtextbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.output_rtextbox.Location = new System.Drawing.Point(12, 475);
            this.output_rtextbox.Name = "output_rtextbox";
            this.output_rtextbox.ReadOnly = true;
            this.output_rtextbox.Size = new System.Drawing.Size(396, 59);
            this.output_rtextbox.TabIndex = 8;
            this.output_rtextbox.Text = "";
            // 
            // select_output
            // 
            this.select_output.HelpRequest += new System.EventHandler(this.select_output_HelpRequest);
            // 
            // transfer_label
            // 
            this.transfer_label.AutoSize = true;
            this.transfer_label.Location = new System.Drawing.Point(160, 545);
            this.transfer_label.Name = "transfer_label";
            this.transfer_label.Size = new System.Drawing.Size(94, 20);
            this.transfer_label.TabIndex = 9;
            this.transfer_label.Text = "Transferring";
            this.transfer_label.Visible = false;
            // 
            // run_button
            // 
            this.run_button.Location = new System.Drawing.Point(12, 540);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(142, 30);
            this.run_button.TabIndex = 11;
            this.run_button.Text = "Transfer Files";
            this.run_button.UseVisualStyleBackColor = true;
            this.run_button.Click += new System.EventHandler(this.run_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "TV Shows";
            // 
            // show_check_list
            // 
            this.show_check_list.CheckOnClick = true;
            this.show_check_list.FormattingEnabled = true;
            this.show_check_list.Location = new System.Drawing.Point(323, 34);
            this.show_check_list.Name = "show_check_list";
            this.show_check_list.Size = new System.Drawing.Size(287, 382);
            this.show_check_list.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Movies";
            // 
            // movie_check_list
            // 
            this.movie_check_list.CheckOnClick = true;
            this.movie_check_list.FormattingEnabled = true;
            this.movie_check_list.Location = new System.Drawing.Point(12, 34);
            this.movie_check_list.Name = "movie_check_list";
            this.movie_check_list.Size = new System.Drawing.Size(287, 382);
            this.movie_check_list.TabIndex = 12;
            this.movie_check_list.SelectedIndexChanged += new System.EventHandler(this.movie_check_list_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 613);
            this.Controls.Add(this.run_button);
            this.Controls.Add(this.transfer_label);
            this.Controls.Add(this.output_rtextbox);
            this.Controls.Add(this.output_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.show_check_list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.movie_check_list);
            this.Name = "Form1";
            this.Text = "File Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog select_files;
        private System.Windows.Forms.Button output_button;
        private System.Windows.Forms.RichTextBox output_rtextbox;
        private System.Windows.Forms.FolderBrowserDialog select_output;
        private System.Windows.Forms.Label transfer_label;
        private System.Windows.Forms.Button run_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox show_check_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox movie_check_list;
    }
}

