using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageToJPG
{
    public partial class Main : Form
    {
        BindingList<string> Images = new BindingList<string>();

        public Main()
        {
            InitializeComponent();
            listBox.DataSource = Images;
            Images.ListChanged += (s, e) => tips.Visible = Images.Count == 0;
        }

        string[] ImageExt = { ".bmp", ".jpeg", ".png" };

        private bool IsImage(string file)
            => ImageExt.Any(e => file.EndsWith(e, StringComparison.OrdinalIgnoreCase)) && File.Exists(file);

        private void AddImages(string[] files)
        {
            foreach (var file in files)
            {
                if (IsImage(file)) Images.Add(file);
                else if (Directory.Exists(file)) AddImages(Directory.GetFiles(file, "*.*",
                    checkAllFolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(fileDialog.ShowDialog() == DialogResult.OK)
                AddImages(fileDialog.FileNames);
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if(folderDialog.ShowDialog() == DialogResult.OK)
                AddImages(new[] { folderDialog.SelectedPath });
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
            => AddImages(e.Data.GetData(DataFormats.FileDrop) as string[]);

        private void Main_DragEnter(object sender, DragEventArgs e)
            => e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;

        private void btnConvert_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Maximum = Images.Count;
            foreach (var file in Images.ToArray())
            {
                try
                {
                    using (Image img = Image.FromFile(file))
                        img.Save(Path.ChangeExtension(file, ".jpg"), ImageFormat.Jpeg);
                    File.Delete(file);
                    Images.Remove(file);
                }
                catch {}
                progressBar.PerformStep();
            }
            MessageBox.Show("转换完毕" + (Images.Count > 0 ? ", 有部分图像未能转换" : ""));
        }
    }
}
