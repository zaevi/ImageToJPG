using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ImageToJPG
{
    public partial class Main : Form
    {
        List<string> Images = new List<string>();
        SynchronizationContext SyncContext;
        int Succeed = 0, Fail = 0;

        public Main()
        {
            InitializeComponent();
            ThreadPool.SetMaxThreads(5, 5);
            SyncContext = SynchronizationContext.Current;
        }

        private void AddImages(string[] files)
        {
            Images.AddRange(files);
            listBox.Items.AddRange(files);
            if (tips.Visible && Images.Count > 0)
            {
                tips.Visible = false;
                btnConvert.Enabled = true;
            }
        }

        private void AddFolder(string folder)
        {
            AddImages(Directory.GetFiles(folder, "*.*",
                checkAllFolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                .Where(file => IsImageExtension(file)).ToArray());
        }

        private bool IsImageExtension(string file)
        {
            string[] ext = {".bmp", ".jpeg", ".png"};
            return ext.Any(e => file.EndsWith(e, StringComparison.OrdinalIgnoreCase));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(fileDialog.ShowDialog() == DialogResult.OK)
                AddImages(fileDialog.FileNames);
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if(folderDialog.ShowDialog() == DialogResult.OK)
                AddFolder(folderDialog.SelectedPath);
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop);
            AddImages(data.Where(f => File.Exists(f) && IsImageExtension(f)).ToArray());
            foreach (var folder in data.Where(f => Directory.Exists(f)))
                AddFolder(folder);
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            btnConvert.Enabled = false;
            Succeed = Fail = 0;
            progressBar.Maximum = Images.Count;
            foreach (var file in Images)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Convert), file);
            }
        }

        private void Convert(object fileObj)
        {
            var file = fileObj.ToString();
            bool result = false;
            try
            {
                using (Image img = Image.FromFile(file))
                    img.Save(Path.ChangeExtension(file, ".jpg"), ImageFormat.Jpeg);
                result = true;
            }
            catch { }

            SyncContext.Post(OnProgress, new Tuple<string, bool>(file, result));
        }

        private void OnProgress(object fileObj)
        {
            var result = (Tuple<string, bool>)fileObj;
            if (!result.Item2)
                Fail++;
            else
            {
                Succeed++;
                Images.Remove(result.Item1);
                listBox.Items.Remove(result.Item1);
                if (checkDel.Checked)
                {
                    try
                    {
                        File.Delete(result.Item1);
                    }
                    catch { }
                }
            }
            progressBar.PerformStep();
            if(progressBar.Value == progressBar.Maximum)
            {
                var msg = string.Format("图像转换成功: {0}, 失败: {1}", Succeed, Fail);
                MessageBox.Show(msg);
                progressBar.Value = 0;
                if(Images.Count == 0)
                {
                    tips.Visible = true;
                    btnConvert.Enabled = false;
                }
            }
        }
    }
}
