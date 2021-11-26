using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace File_Transfer
{
    // TODO: If cancel file transfer early then save what was leftover to start later
    // TODO: Make it easier to read the file lists (Search bar?)
    public partial class Form1 : Form
    {
        List<string> file_list = new List<string>();
        List<string> path_list = new List<string>();

        Dictionary<string, string> show_file_dict = new Dictionary<string, string>();
        string show_filepath = (@"E:\Media\TV Shows\");

        Dictionary<string, string> movie_file_dict = new Dictionary<string, string>();
        string all_filepath = (@"E:\Media\Movies\All");
        string unc_filepath = (@"E:\Media\Movies\Uncategorized");

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Please make sure the hard drive is connected under the E-drive. Then click 'OK' to proceed.", "Hard Drive Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (string movie_folder_path in System.IO.Directory.GetDirectories(all_filepath))
            {
                string movie_folder_name = System.IO.Path.GetFileName(movie_folder_path);
                movie_file_dict.Add(movie_folder_name, movie_folder_path);
            }

            foreach (string movie_folder_path in System.IO.Directory.GetDirectories(unc_filepath))
            {
                string movie_folder_name = System.IO.Path.GetFileName(movie_folder_path);
                movie_file_dict.Add(movie_folder_name, movie_folder_path);
            }

            foreach (string movie_path in System.IO.Directory.GetFiles(all_filepath))
            {
                string movie_name = System.IO.Path.GetFileName(movie_path);
                movie_file_dict.Add(movie_name, movie_path);
            }

            foreach (string movie_path in System.IO.Directory.GetFiles(unc_filepath))
            {
                string movie_name = System.IO.Path.GetFileName(movie_path);
                movie_file_dict.Add(movie_name, movie_path);
            }

            movie_file_dict.Distinct();
            List<string> movie_file_list = movie_file_dict.Keys.ToList();
            movie_file_list.Sort();

            foreach (string file in movie_file_list)
            {
                movie_check_list.Items.Add(file);
            }

            foreach (string show_folder_path in System.IO.Directory.GetDirectories(show_filepath))
            {
                string show_folder_name = System.IO.Path.GetFileName(show_folder_path);
                show_file_dict.Add(show_folder_name, show_folder_path);
            }

            show_file_dict.Distinct();
            List<string> show_file_list = show_file_dict.Keys.ToList();
            show_file_list.Sort();

            foreach (string file in show_file_list)
            {
                show_check_list.Items.Add(file);
            }
        }

        private void select_files_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void output_button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.select_output.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                output_rtextbox.Text = select_output.SelectedPath;
            }
        }

        private void select_output_HelpRequest(object sender, EventArgs e)
        {

        }

        private void add_button_Click(object sender, EventArgs e)
        {
            
        }

        private void run_button_Click(object sender, EventArgs e)
        {
            string item = "";
            string path = "";
            string output_path = output_rtextbox.Text;

            transfer_label.Visible = true;
            transfer_label.Text = "";

            foreach (string item_checked in movie_check_list.CheckedItems)
            {
                path = (movie_file_dict[item_checked]);
                string out_path = $@"{output_path}\{item}";

                item = (item_checked);
                transfer_label.Text = ($"Transferring {item}");

                System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);

                if (!System.IO.File.Exists($@"{output_path}\{item}"))
                {
                    if (attr.HasFlag(System.IO.FileAttributes.Directory))
                        FileSystem.CopyDirectory(path, $@"{output_path}\{item}", UIOption.AllDialogs);
                    else
                        FileSystem.CopyFile(path, $@"{output_path}\{item}", UIOption.AllDialogs);
                    //System.IO.File.Copy(path, out_path);
                    //MessageBox.Show("Transferred " + item);
                }
            }
            foreach (string item_checked in show_check_list.CheckedItems)
            {
                path = (show_file_dict[item_checked]);
                string out_path = output_path + @"\" + item;

                item = (item_checked);
                transfer_label.Text = ($"Transferring {item}");

                System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);

                if (!System.IO.File.Exists($@"{output_path}\{item}"))
                {
                    if (attr.HasFlag(System.IO.FileAttributes.Directory))
                        FileSystem.CopyDirectory(path, $@"{output_path}\{item}", UIOption.AllDialogs);
                    else
                        FileSystem.CopyFile(path, $@"{output_path}\{item}", UIOption.AllDialogs);
                    //System.IO.File.Copy(path, out_path);
                    //MessageBox.Show("Transferred " + item);
                }
            }
            transfer_label.Text = "Transferred All Files!";
        }

        private void movie_check_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sorting_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = @"E:\Media\Programs\Movie_Sorting\Movie Sorting\bin\Debug\Movie Sorting.exe";
            System.Diagnostics.Process.Start(path);
        }

        private void wtw_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = @"E:\Media\Programs\What_to_Watch\What to Watch\bin\Debug\What to Watch.exe";
            System.Diagnostics.Process.Start(path);
        }
    }
}
