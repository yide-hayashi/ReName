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

namespace WindowsFormsApplication1
{
    public partial class Rename : Form
    {
        List<string> subNameList = new List<string>();
        List<bdy> bdylist = new List<bdy>();
        public delegate void display(int type, string strHtml);
        public display Dis;
        public Rename()
        {
            Dis = new display(displaySongList);
            InitializeComponent();
        }

        private void Rename_Load(object sender, EventArgs e)
        {
            ColumnHeader ch = new ColumnHeader();
            ColumnHeader ch1 = new ColumnHeader();
            compate.Hide();
            wb.Hide();

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


            /*
             *countRise.ThousandsSeparator = true;
             *
             *listView1.Items.Add(new ListViewItem(new string[] { "132", "456" }) );   viewitem2格以上塞入方式
             *listView1.Items[0].SubItems[0] //取地2格以上的直
             */

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
        private void RenameDusplay()
        {
            if (subteamName.Text != "" && animeName.Text != "")
            {
                int count = Convert.ToInt32(countRise.Value);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        listView1.Items[i].Text = animeName.Text + " " + count.ToString("D2") + " [" + subteamName.Text + "]" +
                            listView1.Items[i].SubItems[2].Text;
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

        private void catchtest_Click(object sender, EventArgs e)
        {
            string bourn = "http://search.j-lyric.net/index.php?ex=on&ct=2&ca=2&cl=2&kt=" + HttpUtility.UrlEncode(songNameText.Text);
            //備用歌詞往
            string lyrics = "http://utaten.com/search/=/sort=popular_sort%3Aasc/artist_name=/title=" + HttpUtility.UrlEncode(songNameText.Text) + "/beginning=/body=/lyricist=/composer=/sub_title=/form_open=1/show_artists=1/";
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
            string strHtml = "http://search.j-lyric.net/index.php?ex=on&ct=2&ca=2&cl=2&kt=" + HttpUtility.UrlEncode(songNameText.Text);
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
            bool flag = false,nolyrics=false;
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
                    
                    tag=reg.RegSet(html, @"<[ ]*div[ ]*class=""medium""[ ]*>\s*|<\/[ ]*div[ ]*>|<[ ]*span+[ ]*class=\""ruby\"">|<\/[ ]*span[ ]*>|<[ ]*span+[ ]*class=""rt""[ ]*>|<[ ]*span[ ]*class=""rb""[ ]*>");
                    foreach(string str in tag)
                    {
                        if (html.IndexOf(str) != -1)
                        {
                            html=html.Replace(str,"");
                        }
                    }
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
        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            string html = "";
            songlist.Items.Clear();
            html = wb.DocumentText;
            bdylist = cuthtml(html);
            this.Invoke(this.Dis, new object[] { 1, "" });

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
    }
    class bdy
    {
        public string songer = ""; //class=sml (first)
        public string songName = ""; //class=mid
        public string link = ""; //class=mid href
    }
    public class regset
    {
        /// <summary>
        /// 正規式引入(回傳單一一個)
        /// </summary>
        /// <param name="href">字串</param>
        /// <param name="pax">正規式符號</param>
        /// <returns></returns>
        public string reg(string href,string pax)
        {
            Regex testreg = new Regex(pax);
            MatchCollection regsee = testreg.Matches(href);
            foreach (Match x in regsee)
            {
                href = x.Groups[0].Value;
                break;
            }
            return href;
        }

        public List<string> RegSet(string href, string pax)
        {
            List<string> Setlist = new List<string>();
            Regex testreg = new Regex(pax);
            MatchCollection regsee = testreg.Matches(href);
            foreach (Match x in regsee)
            {
                Setlist.Add(x.Groups[0].Value);
            }
            return Setlist;
        }
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
}
