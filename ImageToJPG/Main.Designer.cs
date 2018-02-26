namespace ImageToJPG
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnConvert = new System.Windows.Forms.Button();
            this.tips = new System.Windows.Forms.Label();
            this.checkAllFolder = new System.Windows.Forms.CheckBox();
            this.checkDel = new System.Windows.Forms.CheckBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnFolder = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(443, 229);
            this.listBox.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 286);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(443, 22);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 1;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(348, 235);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(83, 43);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "批量转换";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // tips
            // 
            this.tips.BackColor = System.Drawing.Color.White;
            this.tips.Location = new System.Drawing.Point(12, 9);
            this.tips.Name = "tips";
            this.tips.Size = new System.Drawing.Size(419, 207);
            this.tips.TabIndex = 3;
            this.tips.Text = "将文件夹或图像文件拖动于此...";
            this.tips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkAllFolder
            // 
            this.checkAllFolder.AutoSize = true;
            this.checkAllFolder.Checked = true;
            this.checkAllFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAllFolder.Location = new System.Drawing.Point(207, 235);
            this.checkAllFolder.Name = "checkAllFolder";
            this.checkAllFolder.Size = new System.Drawing.Size(104, 19);
            this.checkAllFolder.TabIndex = 4;
            this.checkAllFolder.Text = "包括子目录";
            this.checkAllFolder.UseVisualStyleBackColor = true;
            // 
            // checkDel
            // 
            this.checkDel.AutoSize = true;
            this.checkDel.Location = new System.Drawing.Point(207, 260);
            this.checkDel.Name = "checkDel";
            this.checkDel.Size = new System.Drawing.Size(134, 19);
            this.checkDel.TabIndex = 4;
            this.checkDel.Text = "转换后删除原图";
            this.checkDel.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 237);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(83, 43);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "添加图像";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.DefaultExt = "图片文件|*.bmp;*.jpeg;*.gif;*.png";
            this.fileDialog.FileName = "openFileDialog1";
            this.fileDialog.Filter = "图片文件|*.bmp;*.jpeg;*.gif;*.png";
            this.fileDialog.Multiselect = true;
            this.fileDialog.RestoreDirectory = true;
            this.fileDialog.Title = "添加图像...";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(101, 237);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(83, 43);
            this.btnFolder.TabIndex = 6;
            this.btnFolder.Text = "添加目录";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "添加目录...";
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 308);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.checkDel);
            this.Controls.Add(this.checkAllFolder);
            this.Controls.Add(this.tips);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "ImageToJPG";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label tips;
        private System.Windows.Forms.CheckBox checkAllFolder;
        private System.Windows.Forms.CheckBox checkDel;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
    }
}

