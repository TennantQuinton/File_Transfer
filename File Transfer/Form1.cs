using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace File_Transfer
{
    // TODO: If cancel file transfer early then save what was leftover to start later
    // TODO: Make it easier to read the file lists (Search bar?)
    public partial class Form1 : Form
    {
        // Initialize the file and path list
        List<string> file_list = new List<string>();
        List<string> path_list = new List<string>();

        // Initialize the dictionary of tv shows
        Dictionary<string, string> show_file_dict = new Dictionary<string, string>();
        string show_filepath = (@"E:\Media\TV Shows\");

        // Initialize the dictionary of movies
        Dictionary<string, string> movie_file_dict = new Dictionary<string, string>();
        string all_filepath = (@"E:\Media\Movies\All");
        string unc_filepath = (@"E:\Media\Movies\Uncategorized");

        // Windows Form
        public Form1()
        {
            InitializeComponent();
            // Check that the harddrive is connected properly
            MessageBox.Show("Please make sure the hard drive is connected under the E-drive. Then click 'OK' to proceed.", "Hard Drive Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Loop through the folders of movies in the /All/ folder
            foreach (string movie_folder_path in System.IO.Directory.GetDirectories(all_filepath))
            {
                // Get the folders in this directory and append to the dictionary the name and complete filepath
                string movie_folder_name = System.IO.Path.GetFileName(movie_folder_path);
                movie_file_dict.Add(movie_folder_name, movie_folder_path);
            }

            // Loop through the folders of movies in the /Uncategorized/ folder
            foreach (string movie_folder_path in System.IO.Directory.GetDirectories(unc_filepath))
            {
                // Get the folders in this directory and append to the dictionary the name and complete filepath
                string movie_folder_name = System.IO.Path.GetFileName(movie_folder_path);
                movie_file_dict.Add(movie_folder_name, movie_folder_path);
            }

            // Loop through the files of movies in the /All/ folder
            foreach (string movie_path in System.IO.Directory.GetFiles(all_filepath))
            {
                // Get the files in this directory and append to the dictionary the name and complete filepath
                string movie_name = System.IO.Path.GetFileName(movie_path);
                movie_file_dict.Add(movie_name, movie_path);
            }

            // Loop through the files of movies in the /Uncategorized/ folder
            foreach (string movie_path in System.IO.Directory.GetFiles(unc_filepath))
            {
                // Get the files in this directory and append to the dictionary the name and complete filepath
                string movie_name = System.IO.Path.GetFileName(movie_path);
                movie_file_dict.Add(movie_name, movie_path);
            }

            // Remove duplicates from the dictionary
            movie_file_dict.Distinct();

            // Get list of movies for checked list box
            List<string> movie_file_list = movie_file_dict.Keys.ToList();

            // Sort alphabetically
            movie_file_list.Sort();

            // Loop through the files in the list
            foreach (string file in movie_file_list)
            {
                // Add each movie to the checked list box
                movie_check_list.Items.Add(file);
            }

            // Loop through the show folders in the TV Shows directory
            foreach (string show_folder_path in System.IO.Directory.GetDirectories(show_filepath))
            {
                // Get each name and add to the dictionary with filename
                string show_folder_name = System.IO.Path.GetFileName(show_folder_path);
                show_file_dict.Add(show_folder_name, show_folder_path);
            }

            // Remove duplicates from the dictionary
            show_file_dict.Distinct();

            // Get list of tv shows for checked list box
            List<string> show_file_list = show_file_dict.Keys.ToList();

            // Sort alphabetically
            show_file_list.Sort();

            // Loop through the list
            foreach (string file in show_file_list)
            {
                // Add each tv show to the checked list box
                show_check_list.Items.Add(file);
            }
        }

        private void select_files_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void output_button_Click(object sender, EventArgs e)
        {
            // Getting the output path from selection
            DialogResult dialogResult = this.select_output.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                // Insert path to output text file
                output_rtextbox.Text = select_output.SelectedPath;

                // We use these constants to convert bytes to gigabytes
                const double BytesInGB = 1073741824;

                // Get the drive of the output file
                string pathRoot = Path.GetPathRoot(select_output.SelectedPath);
                DriveInfo output_drive = new DriveInfo(pathRoot);

                // Find the free space on that drive in GB
                double freeSpace = Math.Round(output_drive.TotalFreeSpace / BytesInGB, 2);

                // Change label to the free space of the output drive
                freeSpaceLabel.Visible = true;
                freeSpaceLabel.Text = "Free Space: " + freeSpace.ToString() + " GB";
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
            // Initialize the items and paths outside of loops
            string item = "";
            string path = "";
            string output_path = output_rtextbox.Text;

            // Make the transfer label visible and empty
            transfer_label.Visible = true;
            transfer_label.Text = "";

            // Loop through the checked movies
            foreach (string item_checked in movie_check_list.CheckedItems)
            {
                // Get the path of the checked item from the dictionary
                path = (movie_file_dict[item_checked]);

                // Get the checked item name
                item = (item_checked);

                // Update the transfer label
                transfer_label.Text = ($"Transferring {item}");

                // Get the attributes of the path
                System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);

                // Output item path
                string out_path = $@"{output_path}\{item}";

                // Check that the output path doesn't exist
                if (!System.IO.File.Exists(out_path))
                {
                    // Check if the path is a directory or file and use correct copy function
                    if (attr.HasFlag(System.IO.FileAttributes.Directory))
                        FileSystem.CopyDirectory(path, $@"{output_path}\{item}", UIOption.AllDialogs);
                    else
                        FileSystem.CopyFile(path, $@"{output_path}\{item}", UIOption.AllDialogs);
                }
            }

            // Loop through the checked tv shows
            foreach (string item_checked in show_check_list.CheckedItems)
            {
                // Get the path of the checked item from the dictionary
                path = (show_file_dict[item_checked]);
                string out_path = output_path + @"\" + item;

                // Get the checked item name
                item = (item_checked);
                transfer_label.Text = ($"Transferring {item}");

                // Get the attributes of the path
                System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);

                // Check that the out file doesn't exist
                if (!System.IO.File.Exists($@"{output_path}\{item}"))
                {
                    // Check if the path is a directory or file and use correct copy function
                    if (attr.HasFlag(System.IO.FileAttributes.Directory))
                        FileSystem.CopyDirectory(path, $@"{output_path}\{item}", UIOption.AllDialogs);
                    else
                        FileSystem.CopyFile(path, $@"{output_path}\{item}", UIOption.AllDialogs);
                }
            }
            transfer_label.Text = "Transferred All Files!";
        }

        private void movie_check_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            double totalSize = 0.0;

            // We use these constants to convert bytes to gigabytes
            const double BytesInGB = 1073741824;

            List<string> itemList = new List<string>();

            foreach (var item in movie_check_list.CheckedItems)
            {
                string list = string.Join(",", movie_check_list.CheckedItems.OfType<string>().ToList());
                // MessageBox.Show(item.ToString());
                // Get the path of the checked item from the dictionary
                string path = (movie_file_dict[item.ToString()]);

                // Get the attributes of the path
                System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);

                FileInfo file_path_info = new FileInfo(path);
                DirectoryInfo dir_path_info = new DirectoryInfo(path);

                double fileSize = 0.0;

                // Check if the path is a directory or file and use correct copy function
                if (attr.HasFlag(System.IO.FileAttributes.Directory))
                {
                    dir_path_info = new DirectoryInfo(path);

                    string[] files_in_dir = Directory.GetFiles(path, "*.*");
                    string[] dirs_in_dir = Directory.GetDirectories(path);

                    string subfile_path = string.Join(",", dirs_in_dir);
                    string[] files_in_subdir = Directory.GetFiles(subfile_path, "*.*");

                    double subfolder_files_size = 0;
                    foreach (string name in files_in_subdir)
                    {
                        FileInfo info = new FileInfo(name);
                        subfolder_files_size += info.Length;
                    }

                    double folder_files_size = 0;
                    foreach (string name in files_in_dir)
                    {
                        FileInfo info = new FileInfo(name);
                        folder_files_size += info.Length;
                    }

                    fileSize = Math.Round((folder_files_size + subfolder_files_size) / BytesInGB, 2);
                }
                else
                {
                    file_path_info = new FileInfo(path);
                    fileSize = Math.Round(file_path_info.Length / BytesInGB, 2);
                }
                
                totalSize = totalSize + fileSize;
            }

            fileSizeLabel.Visible = true;
            fileSizeLabel.Text = "Files Size: " + totalSize.ToString() + " GB";
        }

        private void sorting_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Running the movie sorting program if clicked
            string path = @"E:\Media\Programs\Movie_Sorting\Movie Sorting\bin\Debug\Movie Sorting.exe";
            System.Diagnostics.Process.Start(path);
        }

        private void wtw_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Running the what to watch program if clicked
            string path = @"E:\Media\Programs\What_to_Watch\What to Watch\bin\Debug\What to Watch.exe";
            System.Diagnostics.Process.Start(path);
        }

        private void freeSpaceLabel_Click(object sender, EventArgs e)
        {

        }

        private void show_check_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            double totalSize = 0.0;

            // We use these constants to convert bytes to gigabytes
            const double BytesInGB = 1073741824;

            List<string> itemList = new List<string>();

            foreach (var item in show_check_list.CheckedItems)
            {
                string list = string.Join(",", show_check_list.CheckedItems.OfType<string>().ToList());

                // Get the path of the checked item from the dictionary
                string path = (show_file_dict[item.ToString()]);

                // Get the attributes of the path
                System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);

                FileInfo file_path_info = new FileInfo(path);
                DirectoryInfo dir_path_info = new DirectoryInfo(path);

                double fileSize = 0.0;

                // Don't need to check if file or directory. Just treat all as directories
                dir_path_info = new DirectoryInfo(path);

                string[] files_in_dir = Directory.GetFiles(path, "*.*");
                string[] dirs_in_dir = Directory.GetDirectories(path);

                double subfolder_files_size = 0;

                if (dirs_in_dir.Length > 0)
                {
                    string subfile_path = string.Join(",", dirs_in_dir);
                    if (subfile_path.Length > 200)
                    {
                        MessageBox.Show($"{subfile_path.Length}");
                    }
                    string[] files_in_subdir = Directory.GetFiles(subfile_path, "*.*");

                    foreach (string name in files_in_subdir)
                    {
                        FileInfo info = new FileInfo(name);
                        subfolder_files_size += info.Length;
                    }
                }

                double folder_files_size = 0;
                foreach (string name in files_in_dir)
                {
                    FileInfo info = new FileInfo(name);
                    folder_files_size += info.Length;
                }

                fileSize = Math.Round((folder_files_size + subfolder_files_size) / BytesInGB, 2);

                totalSize = totalSize + fileSize;
            }

            fileSizeLabel.Visible = true;
            fileSizeLabel.Text = "Files Size: " + totalSize.ToString() + " GB";
        }
    }
}
