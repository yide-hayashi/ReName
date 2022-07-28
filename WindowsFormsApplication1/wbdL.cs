using mainWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ReName
{
    public partial class wbdL : Form
    {
         string  saveFilepath, NLnowUrl="",html;
        public string url;
        public List<novel_list> NL;
        public int count = 0;
        public string WriterAcc = "",title="";
        Rename Renamex;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rename">本身的class</param>
        /// <param name="url">link</param>
        /// <param name="saveFilepath">path</param>
        public wbdL(Rename rename,string saveFilepath)
        {
            this.Renamex = rename;
            this.saveFilepath = saveFilepath;
            InitializeComponent();
            this.Hide();
            wb.ScriptErrorsSuppressed = false;
        }

        private void wbdL_Load(object sender, EventArgs e)
        {
                
                wb.Navigate(NL[0].url);
            
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wb.Document.InvokeScript("x", new object[] { @"function x(){if(document.getElementById(""yes18"")!=null) document.getElementById(""yes18"").click();} " });
            // wb.Document.InvokeScript(@"x(function名稱),new object[]{" Javascript"}");
            //wb.Document.InvokeScript(@"x(function名稱 直接呼叫));
            if (NLnowUrl != wb.Document.Url.ToString() && wb.DocumentText.Contains("</html>") == true)
            {
                NLnowUrl = wb.Document.Url.ToString();
                //網路太慢 只有抓一半 要驗證</html>沒有的畫run到有為止

                //url link更改
                html = wb.DocumentText;
                html = changehref(html);
                //存檔
                fileio savef = new fileio();
                savef.fileDataCreatUTF8(html, saveFilepath,(count+1).ToString()+ ".html");

                if (count < NL.Count)
                {
                    count++;
                    Renamex.RenameDLstate(count+1, NL.Count);
                    if (count < NL.Count)
                        wb.Navigate(NL[count].url);
                    else
                    {
                        Renamex.RenameDLstate();
                        this.Close();
                    }
                    Thread.Sleep(Convert.ToInt32(new Random().NextDouble() * 500));
                }
                else
                {
                    Renamex.RenameDLstate();
                    this.Close();
                }
            }
        }
        private string changehref(string html)
        {
            
            regset reg = new regset();
            //WriterAcc = reg.RegReplace(wb.Document.Url.ToString(),@"$1", @"http?s:\/\/novel18.syosetu.com\/(\w*)\/\w*\/");
            html = reg.RegReplace(html, @"$1.html", @"\/"+ WriterAcc +@"(\d*)\/");
            return reg.RegReplace(html,@"$1../"+title+@".html $2", @"(<a\s*href\s*=\s*"")\s*https:\/\/*.*.*\/"+WriterAcc+@"\s*("">目次<\s*\/a\s*>)");
        }
       
    }
}
