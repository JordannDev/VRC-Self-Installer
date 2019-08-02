using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace VRC_Auto_Installer {
    public partial class Main_Form : Form {

        // ARTCC/vACC Facility Code
        private string facilityCode = "ZME";
        // VRC File URL.
        private string vrcLink = "LINK-TO-FILE";
        // Name of the file.
        private string vrcFileName = "zme_vrc.zip";
        // File destination used when extracting.
        private string fileDestination;

        public Main_Form() {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e) {
            // Set the title of the window with the facility code.
            this.Text = facilityCode + " " + this.Text;
            // Replace text in body, and title.
            this.textTitle.Text = this.textTitle.Text.Replace("%fac%", facilityCode);
            this.textBody.Text = this.textBody.Text.Replace("%fac%", facilityCode);
            // Set file destination.
            fileDestination = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "VRC\\Files\\" + facilityCode);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            // Open VRC Folder.
            Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "VRC"));
        }

        private void btnDownload_Click(object sender, EventArgs e) {
            // Confirm the users is aware that the downloader will delete old files in the destination folder.
            DialogResult res = MessageBox.Show("By clicking \"Yes\" you understand that any files or folders in " +
                                               fileDestination + " WILL be deleted, would you like to continue?", "Are you sure?", MessageBoxButtons.YesNo);
            // Check result.
            if(res == DialogResult.Yes)
                downloadFiles();
            else if(res == DialogResult.No)
                Environment.Exit(1);
        }

        private void downloadFiles() {
            try {
                // Create folder...
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "VRC\\Files\\" + facilityCode));


                // Remove old files before extracting..
                DirectoryInfo di = new DirectoryInfo(fileDestination);
                foreach (FileInfo file in di.GetFiles())
                    file.Delete();
                foreach (DirectoryInfo dir in di.GetDirectories())
                    dir.Delete();

                // Download file using Web Client..
                WebClient webClient = new WebClient();
                webClient.DownloadFile(vrcLink, @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "VRC\\Files\\" + facilityCode + "\\" + vrcFileName));

                // Extract Files..
                ZipFile.ExtractToDirectory(fileDestination + "\\" + vrcFileName, fileDestination);

                MessageBox.Show("Downloaded latest files successfully.", "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show("Unable to download facility files. Reason: " + ex.Message + "!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }

        }


    }
}
