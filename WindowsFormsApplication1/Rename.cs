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
using mainWin;
using System.Resources;
using System.Net;
using System.Threading;
using System.Web;
using System.Text.RegularExpressions;
using mshtml;
using System.Collections;



namespace ReName
{
    
    public partial class Rename : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        List<string> subNameList = new List<string>();
        List<bdy> bdylist = new List<bdy>();

        //novel
        List<novel_list> NL = new List<novel_list>();
        string NLnowUrl = "",NLrootUrl="";
        string saveFilepath = "";
        wbdL wbdl;


        public delegate void display(int type, string strHtml);
        public display Dis;
        string wbState = "";//"lyric or novel or null"
        public Rename()
        {
            this.wbdl = wbdl;
            Dis = new display(displaySongList);
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void Rename_Load(object sender, EventArgs e)
        {
            ColumnHeader ch = new ColumnHeader();
            ColumnHeader ch1 = new ColumnHeader();
            compate.Hide();
            //wb.Hide();

            LyricRB.Checked = true;
            change.Hide();
            instring.Hide();
            songlist.FullRowSelect = true;


            ch.Width = 80;
            ch.Text = "檔案格式";

            ch1.Text = "原始檔案名稱";
            ch1.Width = 300;

            columnHeader1.Text = "檔案名稱";
            columnHeader1.Width = 300;
            listView1.Columns.AddRange(new ColumnHeader[] { ch1, ch });
            countRise.Value = 1;
            listView1.FullRowSelect = true;

            outstring.Multiline = true;
            SubnameFileRead();
            if (subteamName.Items.Count > 0)
                subteamName.SelectedIndex = 0;

            novel_link.Text = "https://novel18.syosetu.com/n0280z/";
            SavePath.Text = @"A:\novel\";
            /*
             *countRise.ThousandsSeparator = true;
             *
             *listView1.Items.Add(new ListViewItem(new string[] { "132", "456" }) );   viewitem2格以上塞入方式
             *listView1.Items[0].SubItems[0] //取地2格以上的直
             */


            ColumnHeader columnheader;// Used for creating column headers.
            ListViewItem listviewitem;// Used for creating listview items.

            // Ensure that the view is set to show details.
            listView1.View = View.Details;

            //// Loop through and size each column header to fit the column header text.
            //foreach (ColumnHeader cha in this.listView1.Columns)
            //{
            //    cha.Width = -2;
            //}
        }

        private void path_TextChanged(object sender, EventArgs e)
        {

            PathFilesRead();
        }
        private void PathFilesRead()
        {
            try
            {
                listView1.Items.Clear();
                string[] filed = Directory.GetFiles(path.Text);
                foreach (var file in filed)
                {
                    FileInfo f = new FileInfo(file);
                    listView1.Items.Add(new ListViewItem(new string[] { f.Name, f.Name, f.Extension }));
                }
            }
            catch (Exception ex) { }
        }
        private void Selectdir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            path.Text = fbd.SelectedPath;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            RenameDusplay();
        }

        private void remane_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                bool replace = false;
                for (i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected && File.Exists(path.Text + "\\" + listView1.Items[i].SubItems[1].Text))
                    {
                        File.Move(path.Text + "\\" + listView1.Items[i].SubItems[1].Text,
                            path.Text + "\\" + listView1.Items[i].SubItems[0].Text);
                    }
                }
                PathFilesRead();
                foreach (var x in subNameList.ToArray())
                {
                    if (x == subteamName.Text)
                    {
                        replace = true;

                        break;

                    }
                }
                if (!replace)
                {
                    subNameList.Add(subteamName.Text);
                    SubnameFileSave();
                    SubnameFileRead();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\r\n檔案名稱有重複或其他問題"); }
        }

        private void animeName_TextChanged(object sender, EventArgs e)
        {
            RenameDusplay();
        }

        private void subteamName_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 顯示rename後的名稱
        /// </summary>
        private void RenameDusplay()
        {
            if (subteamName.Text != "" && animeName.Text != "")
            {
                int count = Convert.ToInt32(countRise.Value);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        if(!SpaceCheckbox.Checked)
                        {
                            listView1.Items[i].Text = animeName.Text + " " + count.ToString("D2") + " [" + subteamName.Text + "]" +
                            listView1.Items[i].SubItems[2].Text;
                        }
                        else
                        {
                            listView1.Items[i].Text = animeName.Text + "_" + count.ToString("D2") + "_" + subteamName.Text+
                            listView1.Items[i].SubItems[2].Text;
                        }
                        listView1.Items[i].SubItems[0].BackColor = Color.LightBlue;
                        listView1.Items[i].SubItems[1].BackColor = Color.LightBlue;
                        listView1.Items[i].SubItems[2].BackColor = Color.LightBlue;
                        count++;
                    }
                    else if (listView1.Items[i].SubItems[0].Text != listView1.Items[i].SubItems[1].Text)
                    {
                        listView1.Items[i].SubItems[0].Text = listView1.Items[i].SubItems[1].Text;
                        listView1.Items[i].BackColor = Color.Transparent;
                    }

                }
            }
        }

        private void subteamName_TextChanged_1(object sender, EventArgs e)
        {
            RenameDusplay();
        }
        private void SubnameFileRead()
        {
            subteamName.Items.Clear();
            subNameList.Clear();
            if (File.Exists(Application.StartupPath + "\\SubName.sn"))
            {
                fileio fio = new fileio();
                foreach (var x in fio.fileDataReadCharUTF8(Application.StartupPath + "\\SubName.sn"))
                {
                    subNameList.Add(x);
                    subteamName.Items.Add(x);
                }
            }
        }
        private void SubnameFileSave()
        {
            if (!File.Exists(Application.StartupPath + "\\SubName.sn"))
            {
                File.Delete(Application.StartupPath + "\\SubName.sn");
            }
            fileio fio = new fileio();
            fio.fileDataCreatUTF8(subNameList.ToArray(), Application.StartupPath, "SubName.sn");
        }

        private void countRise_ValueChanged(object sender, EventArgs e)
        {
            RenameDusplay();
        }


        private void countRise_KeyUp(object sender, KeyEventArgs e)
        {
            RenameDusplay();
        }


        private void down_MouseLeave(object sender, EventArgs e)
        {
            down.FlatAppearance.BorderSize = 0;
        }


        private void up_MouseLeave(object sender, EventArgs e)
        {
            up.FlatAppearance.BorderSize = 0;
        }

        private void up_MouseEnter(object sender, EventArgs e)
        {
            up.FlatAppearance.BorderSize = 1;
            //up.FlatAppearance.BorderColor = Color.FromArgb(176, 173, 242);
        }

        private void down_MouseEnter(object sender, EventArgs e)
        {
            down.FlatAppearance.BorderSize = 1;
        }

        private void up_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem lvi;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected && i != 0)
                    {
                        lvi = listView1.Items[i];
                        listView1.Items.RemoveAt(i);
                        listView1.Items.Insert(i - 1, lvi);
                        if (i - 1 == 0)
                            listView1.Items[0].Selected = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void down_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> SelectIndex = new List<int>();
                int i = 0;
                ListViewItem lvi;
                for (i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    if (listView1.Items[i].Selected && i + 1 < listView1.Items.Count)
                    {
                        listView1.Items[i].Selected = false;
                        lvi = listView1.Items[i];
                        listView1.Items.RemoveAt(i);
                        listView1.Items.Insert(i + 1, lvi);
                        if (i + 1 != listView1.Items.Count - 1)
                            SelectIndex.Add(i + 1);
                    }
                }
                for (i = 0; i < SelectIndex.Count; i++)
                {
                    listView1.Items[SelectIndex[i]].Selected = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }


        private void down_MouseDown(object sender, MouseEventArgs e)
        {
            down.FlatAppearance.BorderSize = 0;
        }

        private void change_Click(object sender, EventArgs e)
        {
            wbState = "lyric";
            string[] htmltag = new string[] { "div", "br", "/div", "/br" };

            outstring.Text = HtmlToString(instring.Text);

        }
        private string HtmlToString(string input)
        {
            int i = 0;
            bool flag = false;
            string str = "";
            input = input.Replace("<br>", "\r\n").Replace("<\\br>", "\r\n");
            for (i = 0; i < input.Length; i++)
            {
                if (input[i] == '<')
                    flag = true;
                if (!flag)
                {
                    str += input[0];
                    input = input.Substring(1, input.Length - 1);
                    i = 0;
                }

                if (input[i] == '>')
                {
                    flag = false;
                    input = input.Substring(i + 1, input.Length - (i + 1));
                    i = 0;
                }

            }
            return str;
        }

        private void instring_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                instring.SelectAll();
        }

        private void outstring_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                outstring.SelectAll();
        }


        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string html = "",WriterAcc="";
            if (wbState == "novel")
            {
                if(NLrootUrl=="")
                    NLrootUrl = wb.Document.Url.ToString();
                /*
                 * 插進去之前要先讓系統註冊表全部變成IE11 不然JS不會動作
                 */
                /* HtmlElement head = wb.Document.GetElementsByTagName("head")[0];
                 HtmlElement scriptEl = wb.Document.CreateElement("script");
                 //using mshtml  c:\windows\system32\mshtml.tlb
                 IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
                 element.text = @"function x(){if(document.getElementById(""yes18"")!=null) document.getElementById(""yes18"").click();} ";
                 head.AppendChild(scriptEl);
                 *
                 *javascript 觸發event方式
                 * wb.DocumentText + @"<script>function x(){document.getElementById(""yes18"").click();}</script> ";
                 */
                /*注入最快方式 以及目前可行 */
                wb.Document.InvokeScript("x", new object[] { @"function x(){if(document.getElementById(""yes18"")!=null) document.getElementById(""yes18"").click();} " });
                // wb.Document.InvokeScript(@"x(function名稱),new object[]{" Javascript"}");
                //wb.Document.InvokeScript(@"x(function名稱 直接呼叫));
                if (NLnowUrl != wb.Document.Url.ToString()　&& wb.DocumentText.Contains("</html>")==true)
                {
                    NLnowUrl = wb.Document.Url.ToString();


                    html = wb.DocumentText;
                    WriterAcc = wb.Document.Url.ToString().Replace("https://novel18.syosetu.com/", "");
                    //html link更改
                    html = changehref(html,WriterAcc);

                    //存檔
                    fileio savef = new fileio();
                    saveFilepath = SavePath.Text;
                    
                    if(Directory.Exists(saveFilepath)==false)
                        Directory.CreateDirectory(saveFilepath);

                    savef.fileDataCreatUTF8(html, saveFilepath, wb.DocumentTitle + ".html");

                    //建立作者帳號資料夾
                    saveFilepath += "/"+WriterAcc;
                    Directory.CreateDirectory(saveFilepath);
                    


                    
                    
                    if(NLrootUrl==wb.Document.Url.ToString())
                        //抓sublist2出來 thread處理
                        catchClassSubList2(wb.DocumentText, wb.DocumentTitle, WriterAcc);
                    
                }
            }
            else
            {
                
                songlist.Items.Clear();
                html = wb.DocumentText;
                bdylist = cuthtml(html);
                this.Invoke(this.Dis, new object[] { 1, "" });
            }
        }
        #region novelDL

        /// <summary>
        /// 抓取class 編列
        /// </summary>
        /// <param name="html">URLhtml sourc</param>
        /// <param name="tittle">書名</param>
        /// <param name="WriterAcc">作者帳號</param>
        private void catchClassSubList2(string html,string title,string WriterAcc)
        {
            //正規式過濾class完後再count
            regset reg = new regset();
            List<string> result = new List<string>();
            
            result=reg.RegSet(html, @"class=""novel_sublist2""");
            for(int i = 1;i<=result.Count; i++)
            {
                NL.Add(new novel_list() { url = wb.Document.Url.ToString()+i});
            }

            openwbdl(title,WriterAcc);
        }
        /// <summary>
        /// 抓每一章的內容
        /// </summary>
        /// <param name="title">書名</param>
        /// <param name="WriterAcc">作者帳號</param>
        public void openwbdl(string title, string WriterAcc)
        {
            string[] files=new string [1];
            //確認上次抓取的資料 有檔案就跳過，從上次的最後一個檔案重抓
            files=Directory.GetFiles(saveFilepath);
            wbdL wbdl1 = new wbdL(this, saveFilepath);
            wbdl1.NL = NL;
            wbdl1.WriterAcc = WriterAcc;
            wbdl1.title = title;
            wbdl1.count = files.Count()-1;
            wbdl1.Show();
            wbdl1.Hide();
        }
        /// <summary>
        /// 下載量表示
        /// </summary>
        /// <param name="now">現在下載完成數字</param>
        /// <param name="total">總數</param>
        public void RenameDLstate(int now,int total)
        {
            DLstate.Text = "目前状態：　　" + now.ToString() + "/" + total.ToString();
        }
        /// <summary>
        /// 下載量表示-完成
        /// </summary>
        public void RenameDLstate()
        {
            DLstate.Text = "目前状態：　　完成"; 
        }
        private void novel_dl_Click(object sender, EventArgs e)
        {

            try
            {
                NLrootUrl = "";
                //確認網址格式是否正確


                //if
                //確認資料夾內的最新集數 如果有相同就不抓
                //else 抓

                gainHtmlSourve_throughWB(novel_link.Text);

            }
            catch (Exception ex)
            { }

        }
        /// <summary>
        /// 先驗證R18在抓目錄，在抓底下的集數
        /// </summary>
        private void gainHtmlSourve_throughWB(string url)
        {
            wbState = "novel";
            wb.Show();

            wb.Navigate(url);

            //之後再wbcomplieted處理
        }

        private void novel_link_TextChanged(object sender, EventArgs e)
        {

        }

        private void pathbtu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog sfd = new FolderBrowserDialog();
            //確認儲存資料夾
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                saveFilepath = sfd.SelectedPath;
                SavePath.Text = sfd.SelectedPath;
            }

        }
        /// <summary>
        /// 處理目錄內的href
        /// </summary>
        /// <param name="html">原始html</param>
        /// <param name="WriterAcc">作者帳號</param>
        /// <returns></returns>
        public string changehref(string html,string WriterAcc)
        {
            regset reg = new regset();
            return reg.RegReplace(html, @"$1.html", @"\/("+WriterAcc+@"\d*)/");
        }

        #endregion

        #region lyrics deal
        private void catchtest_Click(object sender, EventArgs e)
        {
            wbState = "lyric";
            string bourn = "https://search2.j-lyric.net/index.php?ex=on&ct=2&ca=2&cl=2&kt=" + HttpUtility.UrlEncode(songNameText.Text)+ "&search=検索";
            //備用歌詞往
            string lyrics = "http://utaten.com/search/=/sort=popular_sort%3Aasc/artist_name=/title=" + HttpUtility.UrlEncode(songNameText.Text) + "/beginning=/body=/lyricist=/composer=/sub_title=/form_open=1/show_artists=1/";
            /*KKBOX https://www.kkbox.com/tw/tc/search.php?word=Candy-Go-Round */
            compate.Show();
            compate.Text = "搜尋中...";
            Thread th = new Thread(new ThreadStart(select));

            th.Start();
            songlist.Items.Clear();
            bdylist.Clear();

        }

        private void select()
        {
            string lyrics = "http://utaten.com/search/=/sort=popular_sort%3Aasc/artist_name=/title=" + HttpUtility.UrlEncode(songNameText.Text) + "/beginning=/body=/lyricist=/composer=/sub_title=/form_open=1/show_artists=1/";
            //要找地2頁以上 page=n
            chattest(lyrics);
        }
        private void chattest(string url)
        {
            /*WebRequest的版本已在 .NET framework 5.X 以後的版本不用了
             *
             *.NET framework 5.X 以後可用的新版本如下
             *using System.Net.Http;
             *
             *string url = @"https://www.qqxiuzi.cn/zh/hanzi-unicode-bianma.php?zfj=jbhz";

            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage= client.GetAsync(url).Result;
            responseMessage.EnsureSuccessStatusCode();
            string response=await responseMessage.Content.ReadAsStringAsync();
             */

            string strHtml = "https://search2.j-lyric.net/index.php?ex=on&ct=2&ca=2&cl=2&kt=" + HttpUtility.UrlEncode(songNameText.Text) + "&search=検索";
            WebRequest myWebRequest = WebRequest.Create(url);

            myWebRequest.Timeout = 10000;

            //-------------------
            //取得網頁方式
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Timeout = 10000;
            myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Windows NT 5.2; Windows NT 6.0; Windows NT 6.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; MS-RTC LM 8; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET CLR 4.0C; .NET CLR 4.0E)";
            myHttpWebRequest.Method = "GET";

            //---------------------
            //取得回傳
            WebResponse myWebResponse = myHttpWebRequest.GetResponse();

            Stream myStream = myWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);

            cuthtml(myStreamReader.ReadToEnd());
            this.Invoke(Dis, new object[] { 2, strHtml });

        }
        private void catchlyircs(string url, int bdyindex)
        {
            string strHtml = "";
            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Timeout = 10000;
            //登陸帳號密碼的寫法
            //myWebRequest.Credentials = new NetworkCredential("Name", "PWD", "Domain Name");

            //-------------------
            //取得網頁方式
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Timeout = 10000;
            myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Windows NT 5.2; Windows NT 6.0; Windows NT 6.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; MS-RTC LM 8; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET CLR 4.0C; .NET CLR 4.0E)";
            myHttpWebRequest.Method = "GET";

            //---------------------
            //取得回傳
            WebResponse myWebResponse = myHttpWebRequest.GetResponse();

            Stream myStream = myWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            strHtml = myStreamReader.ReadToEnd();

            CutLyric(strHtml, bdyindex);

        }
        private void CutLyric(string html, int bdyindex)
        {

            string lyrics = "";
            List<string> tag = new List<string>();
            int webtype = 2; //1=search.j-lyric.net(網站已不存在) 2=http://utaten.com
            int i = 0;
            bool flag = false, nolyrics = false;
            var x = new Regex(@"(\s|\S)+<div\s+class=""hopeVote""\s+>(\s|\S)+").Matches(html);

            if (html.IndexOf(@"class=""hopeVote""") != -1)
            {
                outstring.Text = "目前無歌詞";
            }
            else
            {
                if (html.IndexOf("<p id=\"Lyric\">") != -1)
                {
                    webtype = 1;
                    html = html.Substring(html.IndexOf("<p id=\"Lyric\">") + 13, html.Length - (html.IndexOf("<p id=\"Lyric\">") + 13)).Replace("<br>", "\r\n");
                    for (i = 0; i < html.Length; i++)
                    {

                        if (html[i] == '>')
                        {
                            i++;
                            flag = true;

                        }
                        if (html[i] == '<')
                        {
                            flag = false;
                            break;
                        }
                        if (flag)
                        {
                            lyrics += html[i];
                        }
                    }
                }
                else if (html.IndexOf("<div class=\"medium\">") != -1) //webtype2
                {
                    webtype = 2;
                    regset reg = new regset();
                    html = reg.reg(html, @"(<div[ ]*class=""medium""[ ]*>[\S\s]*?<\/div>)");
                    /*[ ]*div[ ]*class=""hiragana""[ ]*>\s*|<\/[ ]*span[ ]*> */
                    tag = reg.RegSet(html, @"<[ ]*div[ ]*class=""medium""[ ]*>\s*|<[ ]*div[ ]*class=""hiragana""[ ]*>\s*|<\/[ ]*div[ ]*>|<[ ]*span+[ ]*class=\""ruby\"">|<[ ]*span+[ ]*class=""rt""[ ]*>\w*<\/[ ]*span[ ]*>|<[ ]*span[ ]*class=""rb""[ ]*>");
                    foreach (string str in tag)
                    {
                        string temp;
                        if (html.IndexOf(str) != -1)
                        {
                            if (str.IndexOf("<span class=\"rt\">") !=-1)
                            {
                                temp = str.Replace("<span class=\"rt\">", "(");
                                temp = temp.Replace("</span>", ")");
                                html = html.Replace(str, temp);
                            }
                            else
                            {
                                html = html.Replace(str, "");
                            }
                        }
                    }
                    html = html.Replace("</span>","");
                        lyrics = html.Replace("<br />", "\r\n");
                }
                else
                {
                    nolyrics = true;
                }
                if (!nolyrics)
                    outstring.Text = "「" + bdylist[bdyindex].songName + "」\r\n 歌:" + bdylist[bdyindex].songer + "\r\n \r\n" + lyrics;
                else
                    outstring.Text = "無歌詞";
            }


        }

        private void displaySongList(int type, string strHtml)
        {
            outstring.Text = "";
            for (int i = 0; i < bdylist.Count; i++)
            {
                songlist.Items.Add(new ListViewItem(new string[] { bdylist[i].songName, bdylist[i].songer }));
            }
            if (bdylist.Count == 0 && type == 1)
            {
                songlist.Items.Add("見つかりません");
                compate.Text = "搜尋完成";
            }
            else if (bdylist.Count != 0 && (type == 2 || type == 1))
            {
                compate.Text = "搜尋完成";
            }
            else if (bdylist.Count == 0 && type == 2)
            {
                wb.Navigate(strHtml);
            }
        }
        /// <summary>
        /// data丟入List<bdy>
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private List<bdy> cuthtml(string html)
        {
            int i = 0;
            string word = "", link="", songer="", songName="";
            bool flag = false;

            hrefcatch catchlink = new hrefcatch();
            regset reg = new regset();

            for (i = 0; i < html.Count(); i++)
            {

                if (html[i] == '<')
                {
                    flag = true;
                }
                if (html[i] == '>')
                {
                    word += html[i];
                    flag = false;
                    if (word == "<p class=\"mid\">")
                    {
                        link = cutlinkword(html, i, 1);
                        html = html.Substring(html.IndexOf(link) + link.Length + 1, html.Length - (html.IndexOf(link) + link.Length + 1));
                        i = 1;
                        songer = cutsongerword(html, i, 1);
                        songName = cutsongName(html, i + songer.Length);

                        bdylist.Add(new bdy { songer = HttpUtility.HtmlDecode(songer), songName = HttpUtility.HtmlDecode(songName), link = link });
                    }
                    else if (word == "<p class=\"searchResult__title\">")
                    {
                        
                        if(html.IndexOf("New!!")>=0) 
                        {
                            string temp = "";
                            html=html.Substring(html.IndexOf("New!!"), html.Length - html.IndexOf("New!!"));
                            link = "";
                            temp = catchlink.Hrefcath(html);
                            link +=temp.Substring(6, temp.Length-(6+2));
                            html = html.Substring(html.IndexOf(link), html.Length - html.IndexOf(link));


                            songName = catchlink.SongNamecaths(html).Replace("\n", "");
                            songName = songName.Substring(1, songName.Length - 4);
                            songName = reg.reg(songName, @"\S[\W\S]*\S"); //正規式刪除前後空白()
                            html = html.Substring(html.IndexOf(songName), html.Length - html.IndexOf(songName));

                            i = html.IndexOf(songName); //用index 直接抓一段出來
                            songer = cutsongerword(html, i, 2);//抓歌名

                        }
                        else
                        {
                            link = cutlinkword(html, i, 2);
                            html = html.Substring(html.IndexOf(link) + link.Length + 1, html.Length - (html.IndexOf(link) + link.Length + 1));
                            i = 1;

                            songName = cutsongName(html, i - 1).Replace("\n", "");
                            songer = cutsongerword(html, i, 2);//抓歌名
                        }
                        link = link.Insert(0, "http://utaten.com");
                        bdylist.Add(new bdy { songer = reg.reg(HttpUtility.HtmlDecode(songer), @"\S[\W\S]*\S") , songName = reg.reg(HttpUtility.HtmlDecode(songName), @"\S[\W\S]*\S"), link = link });
                    }
                    word = "";
                }

                if (flag)
                    word += html[i];
            }
            return bdylist;
        }


        private string cutlinkword(string html, int count, int webtype) //webtype 1= 2=utaten
        {
            string link = "";
            bool flag = false;
            for (; count < html.Count(); count++)
            {
                if (html[count] == '\"' && html[count + 1] == 'h' && !flag && webtype == 1)
                {
                    flag = true;
                    count++;
                }
                if (html[count] == '\"' && !flag && webtype == 2)
                {
                    flag = true;
                    count++;
                }
                else if (html[count] == '\"' && flag)
                {
                    flag = false;
                    break;
                }
                if (flag)
                    link += html[count];
            }
            return link;
        }

        private string cutsongerword(string html, int count, int webtype)// webtype =1(search.j-lyric.net ) =2(utaten.com)
        {
            string songer = "";
            bool flag = false, type2cutword = false;
            bool wordspace = false;//前面文字空白偵測
            for (; count < html.Count(); count++)
            {

                if (html[count] == '\"' && !flag && webtype == 1)
                {
                    flag = true;
                    count++;
                }
                else if (html[count] == '\"' && flag && webtype == 1)
                {
                    flag = false;
                    break;
                }

                //------------------------------------------------------------
                if (webtype == 2 && html[count] == '<' && !type2cutword)
                    flag = true;

                if (webtype == 2 && html[count] == '>' && !type2cutword)
                {
                    flag = false;
                    songer += ">";
                    if (songer == "<p class=\"searchResult__name\">")
                    {
                        count += songer.Length;
                        type2cutword = true;
                        songer = "";
                    }
                    else
                        songer = "";
                }

                if (type2cutword && webtype == 2 && html[count] == '>')
                {
                    count++;
                    flag = true;
                    songer = "";
                }

                if (type2cutword && webtype == 2 && html[count] == '<' && html[count + 1] == '/' && html[count + 2] == 'a' && flag)
                {
                    flag = false;
                    break;
                }

                if (flag)
                {
                    songer += html[count];
                }



            }
            return songer.Replace("歌詞", "").Replace("\n", "");
        }
        private string cutsongName(string html, int count)
        {
            string songName = "";
            bool flag = false;
            for (; count < html.Count(); count++)
            {
                if (html[count] == '>' && !flag)
                {
                    flag = true;
                    count++;
                }
                else if (html[count] == '<' && flag)
                {
                    flag = false;
                    if (songName != "New!!" && Regex.IsMatch(songName, @"\s+\W+\s+"))
                    {
                        break;
                    }
                    else
                    {
                        songName = "";
                    }
                }
                if (flag)
                    songName += html[count];
            }
            return songName;
        }



        private void HtmlCannelRB_Click(object sender, EventArgs e)
        {

            HtmlCannelRB.Checked = true;
            change.Show();
            instring.Show();

            LyricRB.Checked = false;
            catchtest.Hide();
            songNameText.Hide();
            songlist.Hide();
        }

        private void LyricRB_Click(object sender, EventArgs e)
        {
            HtmlCannelRB.Checked = false;
            change.Hide();
            instring.Hide();

            LyricRB.Checked = true;
            catchtest.Show();
            songNameText.Show();
            songlist.Show();
        }

        #endregion

        #region songlist
        private void songlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            listcolor();
        }
        private void listcolor()
        {
            try
            {
                for (int i = 0; i < songlist.Items.Count; i++)
                {
                    if (songlist.Items[i].Selected)
                    {

                        songlist.Items[i].SubItems[0].BackColor = Color.LightBlue;
                        songlist.Items[i].SubItems[1].BackColor = Color.LightBlue;

                    }
                    else
                    {
                        songlist.Items[i].SubItems[0].BackColor = Color.Transparent;
                        songlist.Items[i].SubItems[1].BackColor = Color.Transparent;
                    }

                }
            }
            catch (Exception ex) { }
        }
        private void songlist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            listcolor();
        }

        private void songlist_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < songlist.Items.Count; i++)
                {
                    if (songlist.Items[i].Selected)
                    {
                        catchlyircs(bdylist[i].link, i);
                        //去比對bdy 然後抓網址 丟出去
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void songNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                catchtest_Click(sender, e);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        #endregion



        private void Rename_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(wbdl!=null)
                if(wbdl.Visible==true)
                    wbdl.Close();
        }

        private void SpaceCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private void outstring_TextChanged(object sender, EventArgs e)
        {

        }
    }
    class bdy
    {
        public string songer = ""; //class=sml (first)
        public string songName = ""; //class=mid
        public string link = ""; //class=mid href
    }


    public class hrefcatch
    {
        /// <summary>
        /// 抓html string內的第一個網址
        /// 
        /// </summary>
        /// <param name="href">含有href的字串</param>
        /// <returns>回傳單一網址</returns>
        public string Hrefcath(string href)
        {
            Regex testreg = new Regex(@"href=\S*""");
            MatchCollection regsee = testreg.Matches(href);
            foreach (Match x in regsee)
            {
                href = x.Groups[0].Value;
                break;
            }
            return href;

        }
        /// <summary>
        /// 抓html string內所有網址
        /// </summary>
        /// <param name="href">含有href的字串</param>
        /// <returns>回傳多個網址</returns>
        public string[] Hrefcaths(string href)
        {
            string[] returnString = new string [1];
            int count = 0;
            Regex testreg = new Regex(@"href=\S*""");
            MatchCollection regsee = testreg.Matches(href);
            foreach (Match x in regsee)
            {
                href = x.Groups[count].Value;
                System.Array.Resize(ref returnString, returnString.Length + 1);
                count++;
            }
            return returnString;
        }

        /// <summary>
        /// 抓html string內所有網址
        /// </summary>
        /// <param name="href">含有href的字串</param>
        /// <returns></returns>
        public string SongNamecaths(string href)
        {
            string returnString="";
            int count = 0;
            Regex testreg = new Regex(@">\D*<[^\w]a");
            MatchCollection regsee = testreg.Matches(href);
            foreach (Match x in regsee)
            {
                returnString = x.Groups[count].Value;
                
                count++;
                break;
            }
            return returnString;
        }

        /*
         * https://regexr.com/ 正規式測試網頁
         */
    }

    public class gainHtmlSource
    {
        
        public string gainHtmlSourve_Get(string url)
        {
            string htmlsource = "";
            

            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Timeout = 10000;
            //登陸帳號密碼的寫法
            //myWebRequest.Credentials = new NetworkCredential("Name", "PWD", "Domain Name");

            //-------------------
            //取得網頁方式
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Timeout = 10000;
            myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Windows NT 5.2; Windows NT 6.0; Windows NT 6.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; MS-RTC LM 8; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET CLR 4.0C; .NET CLR 4.0E)";
            myHttpWebRequest.Method = "GET";

            //---------------------
            //取得回傳
            WebResponse myWebResponse = myHttpWebRequest.GetResponse();

            Stream myStream = myWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            htmlsource = myStreamReader.ReadToEnd();

           

            return htmlsource;
        }

    }
    /*
     * C#->web HttpWebRequest(沒有拉到JS的部分就可以用 單純抓資料 ajax login)
     * C#->web WebBrowser(體積大 只能單向給JS 抓資料 ajax login)
     * C#<->web Sefsharp Brower (JS互相溝通 全部都要自己建構)
     */

    public class novel_list
    {
        public string url = "";
        public string subName = "";
    }


    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;

        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;

        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor. Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface. It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}
