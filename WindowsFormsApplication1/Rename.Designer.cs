namespace ReName
{
    partial class Rename
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
            this.Selectdir = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remane = new System.Windows.Forms.Button();
            this.animeName = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.countRise = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.subteamName = new System.Windows.Forms.ComboBox();
            this.up = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.tb3 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.songlist = new System.Windows.Forms.ListView();
            this.song = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.songer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.outstring = new System.Windows.Forms.RichTextBox();
            this.compate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LyricRB = new System.Windows.Forms.RadioButton();
            this.HtmlCannelRB = new System.Windows.Forms.RadioButton();
            this.songNameText = new System.Windows.Forms.TextBox();
            this.catchtest = new System.Windows.Forms.Button();
            this.change = new System.Windows.Forms.Button();
            this.instring = new System.Windows.Forms.TextBox();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DLstate = new System.Windows.Forms.Label();
            this.pathbtu = new System.Windows.Forms.Button();
            this.SavePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.novel_dl = new System.Windows.Forms.Button();
            this.novel_link = new System.Windows.Forms.TextBox();
            this.SpaceCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.countRise)).BeginInit();
            this.tb3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Selectdir
            // 
            this.Selectdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Selectdir.Location = new System.Drawing.Point(520, 7);
            this.Selectdir.Name = "Selectdir";
            this.Selectdir.Size = new System.Drawing.Size(75, 23);
            this.Selectdir.TabIndex = 0;
            this.Selectdir.Text = "選擇資料夾";
            this.Selectdir.UseVisualStyleBackColor = true;
            this.Selectdir.Click += new System.EventHandler(this.Selectdir_Click);
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(520, 36);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(561, 22);
            this.path.TabIndex = 1;
            this.path.TextChanged += new System.EventHandler(this.path_TextChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(520, 131);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(569, 445);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 126;
            // 
            // remane
            // 
            this.remane.Location = new System.Drawing.Point(994, 99);
            this.remane.Name = "remane";
            this.remane.Size = new System.Drawing.Size(75, 23);
            this.remane.TabIndex = 7;
            this.remane.Text = "重新命名";
            this.remane.UseVisualStyleBackColor = true;
            this.remane.Click += new System.EventHandler(this.remane_Click);
            // 
            // animeName
            // 
            this.animeName.Location = new System.Drawing.Point(553, 72);
            this.animeName.Name = "animeName";
            this.animeName.Size = new System.Drawing.Size(228, 22);
            this.animeName.TabIndex = 3;
            this.animeName.TextChanged += new System.EventHandler(this.animeName_TextChanged);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Location = new System.Drawing.Point(518, 75);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(29, 12);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "片名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(520, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "集數開始";
            // 
            // countRise
            // 
            this.countRise.Location = new System.Drawing.Point(579, 100);
            this.countRise.Name = "countRise";
            this.countRise.Size = new System.Drawing.Size(39, 22);
            this.countRise.TabIndex = 5;
            this.countRise.ValueChanged += new System.EventHandler(this.countRise_ValueChanged);
            this.countRise.KeyUp += new System.Windows.Forms.KeyEventHandler(this.countRise_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(794, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "字幕組";
            // 
            // subteamName
            // 
            this.subteamName.FormattingEnabled = true;
            this.subteamName.Location = new System.Drawing.Point(841, 72);
            this.subteamName.Name = "subteamName";
            this.subteamName.Size = new System.Drawing.Size(241, 20);
            this.subteamName.TabIndex = 4;
            this.subteamName.TextChanged += new System.EventHandler(this.subteamName_TextChanged_1);
            // 
            // up
            // 
            this.up.AutoSize = true;
            this.up.BackColor = System.Drawing.Color.Transparent;
            this.up.BackgroundImage = global::ReName.Properties.Resources.up;
            this.up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.up.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.up.FlatAppearance.BorderSize = 0;
            this.up.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.up.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.up.Location = new System.Drawing.Point(759, 102);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(22, 23);
            this.up.TabIndex = 14;
            this.up.UseVisualStyleBackColor = false;
            this.up.Click += new System.EventHandler(this.up_Click);
            this.up.MouseEnter += new System.EventHandler(this.up_MouseEnter);
            this.up.MouseLeave += new System.EventHandler(this.up_MouseLeave);
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.Transparent;
            this.down.BackgroundImage = global::ReName.Properties.Resources.down;
            this.down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.down.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.down.FlatAppearance.BorderSize = 0;
            this.down.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.down.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.down.Location = new System.Drawing.Point(787, 102);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(22, 23);
            this.down.TabIndex = 15;
            this.down.UseVisualStyleBackColor = false;
            this.down.Click += new System.EventHandler(this.down_Click);
            this.down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down_MouseDown);
            this.down.MouseEnter += new System.EventHandler(this.down_MouseEnter);
            this.down.MouseLeave += new System.EventHandler(this.down_MouseLeave);
            // 
            // tb3
            // 
            this.tb3.Controls.Add(this.tabPage1);
            this.tb3.Controls.Add(this.tabPage2);
            this.tb3.Controls.Add(this.tabPage3);
            this.tb3.Location = new System.Drawing.Point(-2, -2);
            this.tb3.Name = "tb3";
            this.tb3.Padding = new System.Drawing.Point(0, 0);
            this.tb3.SelectedIndex = 0;
            this.tb3.Size = new System.Drawing.Size(1114, 622);
            this.tb3.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BackgroundImage = global::ReName.Properties.Resources._003;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.SpaceCheckbox);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.down);
            this.tabPage1.Controls.Add(this.Selectdir);
            this.tabPage1.Controls.Add(this.up);
            this.tabPage1.Controls.Add(this.path);
            this.tabPage1.Controls.Add(this.subteamName);
            this.tabPage1.Controls.Add(this.remane);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.animeName);
            this.tabPage1.Controls.Add(this.countRise);
            this.tabPage1.Controls.Add(this.lbl);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1106, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ReName";
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::ReName.Properties.Resources.tw_head_01;
            this.tabPage2.Controls.Add(this.songlist);
            this.tabPage2.Controls.Add(this.outstring);
            this.tabPage2.Controls.Add(this.compate);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.LyricRB);
            this.tabPage2.Controls.Add(this.HtmlCannelRB);
            this.tabPage2.Controls.Add(this.songNameText);
            this.tabPage2.Controls.Add(this.catchtest);
            this.tabPage2.Controls.Add(this.change);
            this.tabPage2.Controls.Add(this.instring);
            this.tabPage2.Controls.Add(this.wb);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1106, 596);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HTMLtag消去";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // songlist
            // 
            this.songlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.song,
            this.songer});
            this.songlist.HideSelection = false;
            this.songlist.Location = new System.Drawing.Point(699, 3);
            this.songlist.Name = "songlist";
            this.songlist.Size = new System.Drawing.Size(392, 229);
            this.songlist.TabIndex = 11;
            this.songlist.UseCompatibleStateImageBehavior = false;
            this.songlist.View = System.Windows.Forms.View.Details;
            this.songlist.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.songlist_ItemCheck);
            this.songlist.SelectedIndexChanged += new System.EventHandler(this.songlist_SelectedIndexChanged);
            this.songlist.DoubleClick += new System.EventHandler(this.songlist_DoubleClick);
            // 
            // song
            // 
            this.song.Text = "歌曲";
            this.song.Width = 188;
            // 
            // songer
            // 
            this.songer.Text = "演唱者";
            this.songer.Width = 197;
            // 
            // outstring
            // 
            this.outstring.BackColor = System.Drawing.SystemColors.Window;
            this.outstring.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outstring.Location = new System.Drawing.Point(711, 367);
            this.outstring.Name = "outstring";
            this.outstring.Size = new System.Drawing.Size(392, 226);
            this.outstring.TabIndex = 3;
            this.outstring.Text = "";
            this.outstring.TextChanged += new System.EventHandler(this.outstring_TextChanged);
            // 
            // compate
            // 
            this.compate.AutoSize = true;
            this.compate.Location = new System.Drawing.Point(732, 279);
            this.compate.Name = "compate";
            this.compate.Size = new System.Drawing.Size(33, 12);
            this.compate.TabIndex = 12;
            this.compate.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(697, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "歌曲名稱";
            // 
            // LyricRB
            // 
            this.LyricRB.AutoSize = true;
            this.LyricRB.Location = new System.Drawing.Point(960, 238);
            this.LyricRB.Name = "LyricRB";
            this.LyricRB.Size = new System.Drawing.Size(59, 16);
            this.LyricRB.TabIndex = 8;
            this.LyricRB.TabStop = true;
            this.LyricRB.Text = "找歌詞";
            this.LyricRB.UseVisualStyleBackColor = true;
            this.LyricRB.Click += new System.EventHandler(this.LyricRB_Click);
            // 
            // HtmlCannelRB
            // 
            this.HtmlCannelRB.AutoSize = true;
            this.HtmlCannelRB.Location = new System.Drawing.Point(960, 260);
            this.HtmlCannelRB.Name = "HtmlCannelRB";
            this.HtmlCannelRB.Size = new System.Drawing.Size(82, 16);
            this.HtmlCannelRB.TabIndex = 7;
            this.HtmlCannelRB.TabStop = true;
            this.HtmlCannelRB.Text = "刪除htmltag";
            this.HtmlCannelRB.UseVisualStyleBackColor = true;
            this.HtmlCannelRB.Click += new System.EventHandler(this.HtmlCannelRB_Click);
            // 
            // songNameText
            // 
            this.songNameText.Location = new System.Drawing.Point(760, 238);
            this.songNameText.Name = "songNameText";
            this.songNameText.Size = new System.Drawing.Size(183, 22);
            this.songNameText.TabIndex = 6;
            this.songNameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songNameText_KeyDown);
            // 
            // catchtest
            // 
            this.catchtest.Location = new System.Drawing.Point(812, 268);
            this.catchtest.Name = "catchtest";
            this.catchtest.Size = new System.Drawing.Size(75, 23);
            this.catchtest.TabIndex = 4;
            this.catchtest.Text = "尋找";
            this.catchtest.UseVisualStyleBackColor = true;
            this.catchtest.Click += new System.EventHandler(this.catchtest_Click);
            // 
            // change
            // 
            this.change.Location = new System.Drawing.Point(868, 268);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(75, 23);
            this.change.TabIndex = 2;
            this.change.Text = "轉換";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // instring
            // 
            this.instring.Location = new System.Drawing.Point(699, 3);
            this.instring.Multiline = true;
            this.instring.Name = "instring";
            this.instring.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.instring.Size = new System.Drawing.Size(392, 229);
            this.instring.TabIndex = 0;
            this.instring.KeyDown += new System.Windows.Forms.KeyEventHandler(this.instring_KeyDown);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(780, 47);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(163, 132);
            this.wb.TabIndex = 5;
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::ReName.Properties.Resources.天音かなたtest;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage3.Controls.Add(this.DLstate);
            this.tabPage3.Controls.Add(this.pathbtu);
            this.tabPage3.Controls.Add(this.SavePath);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.novel_dl);
            this.tabPage3.Controls.Add(this.novel_link);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1106, 596);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "小說下載";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DLstate
            // 
            this.DLstate.AutoSize = true;
            this.DLstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DLstate.Location = new System.Drawing.Point(863, 138);
            this.DLstate.Name = "DLstate";
            this.DLstate.Size = new System.Drawing.Size(160, 24);
            this.DLstate.TabIndex = 6;
            this.DLstate.Text = "現在状態：　　預備";
            // 
            // pathbtu
            // 
            this.pathbtu.Location = new System.Drawing.Point(1058, 96);
            this.pathbtu.Name = "pathbtu";
            this.pathbtu.Size = new System.Drawing.Size(22, 22);
            this.pathbtu.TabIndex = 5;
            this.pathbtu.Text = "...";
            this.pathbtu.UseVisualStyleBackColor = true;
            this.pathbtu.Click += new System.EventHandler(this.pathbtu_Click);
            // 
            // SavePath
            // 
            this.SavePath.Location = new System.Drawing.Point(655, 96);
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(397, 22);
            this.SavePath.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(653, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "儲存路徑";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(653, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "網址:";
            // 
            // novel_dl
            // 
            this.novel_dl.Location = new System.Drawing.Point(818, 160);
            this.novel_dl.Name = "novel_dl";
            this.novel_dl.Size = new System.Drawing.Size(69, 25);
            this.novel_dl.TabIndex = 1;
            this.novel_dl.Text = "下載";
            this.novel_dl.UseVisualStyleBackColor = true;
            this.novel_dl.Click += new System.EventHandler(this.novel_dl_Click);
            // 
            // novel_link
            // 
            this.novel_link.Location = new System.Drawing.Point(655, 34);
            this.novel_link.Name = "novel_link";
            this.novel_link.Size = new System.Drawing.Size(425, 22);
            this.novel_link.TabIndex = 0;
            this.novel_link.TextChanged += new System.EventHandler(this.novel_link_TextChanged);
            // 
            // SpaceCheckbox
            // 
            this.SpaceCheckbox.AutoSize = true;
            this.SpaceCheckbox.Location = new System.Drawing.Point(634, 103);
            this.SpaceCheckbox.Name = "SpaceCheckbox";
            this.SpaceCheckbox.Size = new System.Drawing.Size(107, 16);
            this.SpaceCheckbox.TabIndex = 16;
            this.SpaceCheckbox.Text = "取消空白鍵和[ ]";
            this.SpaceCheckbox.UseVisualStyleBackColor = true;
            // 
            // Rename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ReName.Properties.Resources._14_1920x1080;
            this.ClientSize = new System.Drawing.Size(1094, 608);
            this.Controls.Add(this.tb3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Rename";
            this.ShowIcon = false;
            this.Text = "Rename";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rename_FormClosing);
            this.Load += new System.EventHandler(this.Rename_Load);
            ((System.ComponentModel.ISupportInitialize)(this.countRise)).EndInit();
            this.tb3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Selectdir;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button remane;
        private System.Windows.Forms.TextBox animeName;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown countRise;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox subteamName;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tb3;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.TextBox instring;
        private System.Windows.Forms.RichTextBox outstring;
        private System.Windows.Forms.Button catchtest;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.TextBox songNameText;
        private System.Windows.Forms.RadioButton LyricRB;
        private System.Windows.Forms.RadioButton HtmlCannelRB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView songlist;
        private System.Windows.Forms.ColumnHeader song;
        private System.Windows.Forms.ColumnHeader songer;
        private System.Windows.Forms.Label compate;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button novel_dl;
        private System.Windows.Forms.TextBox novel_link;
        private System.Windows.Forms.Button pathbtu;
        private System.Windows.Forms.TextBox SavePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label DLstate;
        private System.Windows.Forms.CheckBox SpaceCheckbox;
    }
}