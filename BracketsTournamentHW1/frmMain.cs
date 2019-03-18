using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BracketsTournamentHW1 {
    public partial class frmMain : Form {
        // Create variables
        string FILE_CONTENTS = string.Empty;

        public frmMain() {
            InitializeComponent();
        }

        /// <summary>
        /// Allows the user to select a file from their computer and reads
        /// selected file information into a string for further use; file name
        /// and extension is also displayed in tbFileName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e) {
            using(OpenFileDialog openFile = new OpenFileDialog()) {
                openFile.InitialDirectory = "c:\\"; // Automatically directs user to c:\\ path when dialog opens
                openFile.Filter = "txt files|*.txt"; // Only .txt files can be uploaded
                openFile.RestoreDirectory = true; // Returns directory to original path before opening

                if(openFile.ShowDialog() == DialogResult.OK) {
                    // Display file path in tbFileName
                    tbFileName.Text = openFile.SafeFileName;

                    // Retrieve contents of file
                    var fileStream = openFile.OpenFile();

                    // Store file contents into FILE_CONTENTS variable
                    using(StreamReader fileReader = new StreamReader(fileStream)) {
                        FILE_CONTENTS = fileReader.ReadToEnd(); // Makes one giant string
                    }
                }
            }
        }

        /// <summary>
        /// Opens DisplayBrackets form to view bracket information from the
        /// uploaded file in btnBrowse_Click method
        /// </summary>
        private void btnGetBrackets_Click(object sender, EventArgs e) {
            if(tbFileName.Text != string.Empty) {
                // To test FILE_CONTENTS variable
                //MessageBox.Show(FILE_CONTENTS);

                // Open DisplayBrackets and pass in FILE_CONTENTS
                using (frmDisplayBrackets displayBrackets = new frmDisplayBrackets(FILE_CONTENTS)) {
                    displayBrackets.ShowDialog();
                }
            }
            else {
                MessageBox.Show("You must choose a file");
            }
        }

        /// <summary>
        /// Exits the program 
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
