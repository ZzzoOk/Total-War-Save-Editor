using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EsfLibrary;

namespace EditSFCharacters {
    public partial class EditSFCharacters : Form {
        EsfSaveEditorControls.ProgressUpdater updater;
        EsfSaveEditorControls.EsfTabControl esfTabControl1;

        #region Properties
        string filename = null;
        public string FileName {
            get {
                return filename;
            }
            set {
                Text = string.Format("{0} - EditSFCharacters {1}", Path.GetFileName(value), Application.ProductVersion);
                statusLabel.Text = value;
                filename = value;
            }
        }
        EsfFile file;
        EsfFile EditedFile {
            get {
                return file;
            }
            set {
                file = value;
                esfTabControl1.RootNode = (EsfLibrary.ParentNode)value.RootNode;
                esfTabControl1.RootNode.Modified = false;
                saveAsToolStripMenuItem.Enabled = file != null;
                saveToolStripMenuItem.Enabled = file != null;
            }
        }
        #endregion

        public EditSFCharacters() {
            InitializeComponent();
            updater = new EsfSaveEditorControls.ProgressUpdater(progressBar, statusLabel);
            Text = string.Format("EditSFCharacters {0}", Application.ProductVersion);
        }

        private void promptOpenFile() {
            OpenFileDialog dialog = new OpenFileDialog {
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                try {
                    OpenFile(dialog.FileName);
                } catch (Exception e) {
                    MessageBox.Show(string.Format("Could not open {0}: {1}", dialog.FileName, e));
                    updater.LoadingFinished();
                }
            }
        }
        private void OpenFile(string openFilename) {
            string oldStatus = statusLabel.Text;
            try {
                menuStrip1.Enabled = false;
                var stream = File.OpenRead(openFilename);
                //EsfCodec codec = EsfCodecUtil.GetCodec(stream);
                //updater.StartLoading(openFilename, codec);
                statusLabel.Text = string.Format("Loading {0}", openFilename);
                LogFileWriter logger = null;
                if (writeLogFileToolStripMenuItem.Checked) {
                    logger = new LogFileWriter(openFilename + ".xml");
                    //codec.NodeReadFinished += logger.WriteEntry;
                    //codec.Log += logger.WriteLogEntry;
                }
                EditedFile = EsfCodecUtil.LoadEsfFile(openFilename);
                //EditedFile = new EsfFile(codec.Parse(stream), codec);
                //updater.LoadingFinished();
                FileName = openFilename;
                if (logger != null) {
                    logger.Close();
                    //codec.NodeReadFinished -= logger.WriteEntry;
                    //codec.Log -= logger.WriteLogEntry;
                }
                Text = string.Format("{0} - EditSFCharacters {1}", Path.GetFileName(openFilename), Application.ProductVersion);
            } catch (Exception exception) {
                statusLabel.Text = oldStatus;
                Console.WriteLine(exception);
            }
            finally
            {
                menuStrip1.Enabled = true;
            }
        }
        private void promptSaveFile() {
            SaveFileDialog dialog = new SaveFileDialog {
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Save(dialog.FileName);
                FileName = dialog.FileName;
            }
        }
        bool promptGameDir()
        {
            if (!EsfSaveEditorControls.GameDirSetting.verifyGamePath())
            {
                CommonDialogs.DirectoryDialog dlg = new CommonDialogs.DirectoryDialog()
                {
                    Description = string.Format("Please point to Location of {0}\nCancel if not installed.", Properties.Settings.Default.gameid)
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string gamepath = dlg.SelectedPath;
                    if (EsfSaveEditorControls.GameDirSetting.verifyGamePath(gamepath))
                    {
                        EsfSaveEditorControls.GameDirSetting.saveGamePath(gamepath);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect game folder");
                        return promptGameDir();
                    }
                }
                else
                    return false;
            }
            return true;
        }

        #region Menu handlers
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            promptOpenFile();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            promptSaveFile();
        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (filename != null) {
                Save(filename);
            }
        }
        private void runTestsToolStripMenuItem_Click(object sender, EventArgs eventArgs) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                dialog.Dispose();
                string logFileName = Path.Combine(dialog.SelectedPath, "EditSF_test.txt");
                FileTester tester = new FileTester();
                using (TextWriter logWriter = File.CreateText(logFileName)) {
                    foreach (string file in Directory.EnumerateFiles(dialog.SelectedPath)) {
                        if (file.EndsWith("EditSF_test.txt")) {
                            continue;
                        }
                        string testResult = tester.RunTest(file, progressBar, statusLabel);
                        logWriter.WriteLine(testResult);
                        logWriter.Flush();
                    }
                }
                MessageBox.Show(string.Format("Test successes {0}/{1}", tester.TestSuccesses, tester.TestsRun),
                                "Tests finished");
            }
        }
        private void runSingleTestToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openDialog = new OpenFileDialog {
                RestoreDirectory = true
            };
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string output = new FileTester().RunTest(openDialog.FileName, progressBar, statusLabel);
                MessageBox.Show(output, "Test Finished");
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(String.Format("EditSFCharacters {0}\nCreated by lampuiho", Application.ProductVersion), "About EditSFCharacters");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void chooseDatapackToLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPackFilePicker("Data", EsfSaveEditorControls.GameInfo.dataPacks);
        }
        private void chooseLocDatabaseToLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPackFilePicker("Locale Database", EsfSaveEditorControls.GameInfo.locDataPacks);
        }
        #endregion

        private void Save(string filename) {
            try {
                EsfCodecUtil.WriteEsfFile(filename, EditedFile);
                esfTabControl1.RootNode.Modified = false;
            } catch (Exception e) {
                MessageBox.Show(string.Format("Could not save {0}: {1}", filename, e));
            }
        }
        private void EditSFCharacters_Shown(object sender, EventArgs e)
        {
            var gameid = Properties.Settings.Default.gameid;
            if (gameid != null && gameid != "")
                switchGame(gameid);
        }
        bool InitEditor()
        {
            if (EsfSaveEditorControls.GameData.GetInstance() != null)
            {
                this.SuspendLayout();
                this.Controls.Remove(this.esfTabControl1);
                this.esfTabControl1 = new EsfSaveEditorControls.EsfTabControl();
                // 
                // esfTabControl1
                // 
                this.esfTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.esfTabControl1.Location = new System.Drawing.Point(0, 31);
                this.esfTabControl1.Name = "esfTabControl1";
                this.esfTabControl1.RootNode = null;
                this.esfTabControl1.TabIndex = 3;
                this.Controls.Add(this.esfTabControl1);
                this.esfTabControl1.BringToFront();
                this.esfTabControl1.InitControl();
                this.menuStrip1.Enabled = true;
                this.ResumeLayout(false);
                this.PerformLayout();
                return true;
            }

            MessageBox.Show("Error occurred when attempting to read database");
            return false;
        }
        void showPackFilePicker(string type, List<string> fileList)
        {
            string dataPath;
            if (EsfSaveEditorControls.GameDirSetting.getDataPath(out dataPath))
            {

                Form pick = new Form();
                pick.Text = "Choose files to load for " + type;
                pick.StartPosition = FormStartPosition.CenterParent;
                pick.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                EsfSaveEditorControls.PackFilePicker packFilePicker
                    = new EsfSaveEditorControls.PackFilePicker(dataPath, fileList);
                packFilePicker.Location = new System.Drawing.Point(3, 3);
                pick.Controls.Add(packFilePicker);
                var result = pick.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    EsfSaveEditorControls.GameInfo.SaveDataPackSettings(packFilePicker.newFileList, fileList);

                    EsfSaveEditorControls.GameData.Invalidate();

                    this.menuStrip1.Enabled = false;

                    var refreshDB = 
                        System.Threading.Tasks.Task.Run(() => EsfSaveEditorControls.GameData.Initialise(updater));

                    refreshDB.ContinueWith(x=>InitEditor(), System.Threading.Tasks.TaskScheduler.
                        FromCurrentSynchronizationContext());
                }
            }
            else
                MessageBox.Show("unable to obtain data path");
        }
        private void rome2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchGame((sender as ToolStripMenuItem).Tag.ToString());
        }
        async void switchGame(string gameid)
        {
            fileToolStripMenuItem.Enabled = false;
            chooseDatapackToLoadToolStripMenuItem.Enabled = false;
            chooseLocDatabaseToLoadToolStripMenuItem.Enabled = false;
            EsfSaveEditorControls.GameInfo.SetGame(gameid);
            EsfSaveEditorControls.GameInfo.LoadDataPacks();
            if (promptGameDir())
            {
                menuStrip1.Enabled = false;
                await System.Threading.Tasks.Task.Run(() => EsfSaveEditorControls.GameData.Initialise(updater));

                if (InitEditor())
                {
                    fileToolStripMenuItem.Enabled = true;
                    chooseDatapackToLoadToolStripMenuItem.Enabled = true;
                    chooseLocDatabaseToLoadToolStripMenuItem.Enabled = true;
                    Properties.Settings.Default.gameid = gameid;
                    Properties.Settings.Default.Save();
                    foreach (ToolStripMenuItem menuitem in gameToolStripMenuItem.DropDownItems)
                        menuitem.Checked = gameid.Equals(menuitem.Tag.ToString());
                    return;
                }
            }
        }
    }

    public class LogFileWriter {
        private TextWriter writer;
        public LogFileWriter(string logFileName) {
            writer = File.CreateText(logFileName);
        }
        public void WriteEntry(EsfNode node, long position) {
            //ParentNode
            if (node is RecordNode) {
            }
            //writer.WriteLine("Entry {0} / {1:x} read at {2:x}", node, node.TypeCode, position);
        }
        public void WriteLogEntry(string entry) {
            writer.WriteLine(entry);
        }
        public void Close() {
            writer.Close();
        }
    }
}