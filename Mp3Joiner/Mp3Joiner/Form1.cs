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
using NAudio;
using NAudio.Wave;
using System.Diagnostics;

namespace Mp3Joiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearchOne_Click(object sender, EventArgs e)
        {
            string fileOneDir = string.Empty;
            
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                fileOneDir = openFile.InitialDirectory.ToString() + openFile.FileName.ToString();
            }

            if (fileOneDir != "" && fileOneDir != null && fileOneDir.Length > 0)
            {
                txtFileOne.Text = fileOneDir;
            }
        }

        private void btnSearchTwo_Click(object sender, EventArgs e)
        {
            string fileTwoDir = string.Empty;

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                fileTwoDir = openFile.InitialDirectory.ToString() + openFile.FileName.ToString();
            }

            if (fileTwoDir != "" && fileTwoDir != null && fileTwoDir.Length > 0)
            {
                txtFileTwo.Text = fileTwoDir;
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (txtFileOne.Text != "" && txtFileOne.Text != null && txtFileOne.Text.Length > 0 && txtFileTwo.Text != "" && txtFileTwo.Text != null && txtFileTwo.Text.Length > 0)
            {
                string rootFolderPath = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                string folderPath = Path.Combine(rootFolderPath, "MergedMp3s");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileLocation = Path.Combine(folderPath, "MergedMp3_" + DateTime.Now.ToShortDateString().Replace('/','_') + ".mp3");

                Mp3FileReader readers = new Mp3FileReader(txtFileOne.Text);
                WaveFormat targetFormat = new WaveFormat();
                WaveStream convertedStreamOne = new WaveFormatConversionStream(targetFormat, readers);
                WaveFileWriter.CreateWaveFile(Path.Combine(folderPath,"firstwav.wav"), convertedStreamOne);

                readers = new Mp3FileReader(txtFileTwo.Text);
                targetFormat = new WaveFormat();
                WaveStream convertedStreamTwo = new WaveFormatConversionStream(targetFormat, readers);
                WaveFileWriter.CreateWaveFile(Path.Combine(folderPath,"secondwav.wav"), convertedStreamTwo);

                string[] inputFiles = new string[2];
                Stream output = new MemoryStream();
                inputFiles[0] = Path.Combine(folderPath, "firstwav.wav");
                inputFiles[1] = Path.Combine(folderPath,"secondwav.wav");
                mixWAVFiles(inputFiles, fileLocation);

                MessageBox.Show("Merged!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Please select two audio files!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void mixWAVFiles(string[] inputFiles, string fileLocation)
        {
            int count = inputFiles.GetLength(0);
            WaveMixerStream32 mixer = new WaveMixerStream32();
            WaveFileReader[] reader = new WaveFileReader[count];
            WaveChannel32[] channelSteam = new WaveChannel32[count];
            mixer.AutoStop = true;

            for (int i = 0; i < count; i++)
            {
                reader[i] = new WaveFileReader(inputFiles[i]);
                channelSteam[i] = new WaveChannel32(reader[i]);
                mixer.AddInputStream(channelSteam[i]);
            }
            mixer.Position = 0;
            WaveFileWriter.CreateWaveFile(fileLocation, mixer);
            convertWAVtoMP3(fileLocation);
        }

        public void convertWAVtoMP3(string wavfile)
        {
            //string lameEXE = @"C:\Users\Jibran\Desktop\MP3 Merger\bin\Debug\lame.exe";
            string lameEXE = Path.GetDirectoryName(Application.ExecutablePath) + "/lame.exe";
            string lameArgs = "-V2";

            string wavFile = wavfile;
            string mp3File = "mixed.mp3";

            Process process = new Process();
            process.StartInfo = new ProcessStartInfo();
            process.StartInfo.FileName = lameEXE;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = string.Format(
                "{0} {1} {2}",
                lameArgs,
                wavFile,
                mp3File);

            process.Start();
            process.WaitForExit();

            int exitCode = process.ExitCode;
        }
    }
}
