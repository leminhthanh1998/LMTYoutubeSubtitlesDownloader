using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using MetroFramework.Forms;

namespace LMT_Youtube_Subtitles_Downloader
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            btnDownload.Enabled = false;
            labelProcess.Visible = false;
            cmbTrans.SelectedIndex = 0;
        }

        #region private member

        private string videoId;
        private List<Subtitle> sub = new List<Subtitle>();
        private List<string> listToSrt;
        private string pathSaveFile;
        private List<string> langToTrans = new List<string>() { "", "vi", "en", "ja", "fr", "de", "ko", "ru", "es" };
        #endregion


        /// <summary>
        /// Kiem tra xem link youtube co phu de hay khong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCheck_Click(object sender, EventArgs e)
        {
            sub.Clear();
            cmbSub.Items.Clear();
            if (!txbLink.Text.Contains("youtube.com/watch?v="))
            {
                MessageBox.Show("Link bạn nhập không đúng!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                videoId = Regex.Match(txbLink.Text, $"(?:watch\\?v=)([^\\s]+)").Groups[1].Value;
                string availablesub = await GetDoc("http://video.google.com/timedtext?type=list&v=" + videoId);
                var availablesubXDocument = XDocument.Parse(availablesub);
                if (!(availablesubXDocument.Root != null && availablesubXDocument.Root.HasElements))
                {
                    MessageBox.Show("Video này không có sẵn phụ đề!", "Lỗi!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                foreach (var item in availablesubXDocument.Root.Elements())
                {
                    sub.Add(new Subtitle()
                    {
                        Id = item.Attribute("id")?.Value,
                        LangCode = item.Attribute("lang_code")?.Value,
                        LangOriginal = item.Attribute("lang_original")?.Value,
                        LangTranslated = item.Attribute("lang_translated")?.Value
                    });
                }
                foreach (var subtitle in sub)
                {
                    cmbSub.Items.Add(subtitle);
                }
                cmbSub.SelectedIndex = 0;
                btnDownload.Enabled = true;
            }
            catch
            {
                // ignored
            }
        }


        /// <summary>
        /// Lay thong tin ve sub
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        private async Task<string> GetDoc(string link)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(new Uri(link));
            }
        }

        /// <summary>
        /// Tien hanh tai sub ve 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDownload_Click(object sender, EventArgs e)
        {
            btnDownload.Text = "Chờ tí!!";
            btnDownload.Enabled = btnCheck.Enabled = false;
            labelProcess.Visible = true;

            listToSrt = new List<string>();
            var xmlDoc = new XmlDocument();
            var mSub = sub[cmbSub.SelectedIndex];
            var subDocument =
                await GetDoc(
                    $"http://video.google.com/timedtext?type=track&v={videoId}&id={mSub.Id}&lang={mSub.LangCode}");
            xmlDoc.LoadXml(subDocument);
            if (xmlDoc.DocumentElement != null)
            {
                var temp = 1;//danh dau so dong
                var nodeList = xmlDoc.DocumentElement.SelectNodes("//text");
                if (nodeList != null)
                {
                    for (int i = 0; i < nodeList.Count; i++)
                    {
                        var node = nodeList[i];
                        var startString = node.Attributes["start"].Value;
                        float start = float.Parse(startString, CultureInfo.InvariantCulture);
                        var durString = node.Attributes["dur"].Value;
                        float duration = float.Parse(durString, CultureInfo.InvariantCulture);
                        var text = node.InnerText.Replace("&#39;", "'").Replace("&quot;", @"""");
                        var startTs = new TimeSpan(0, 0, 0, 0, (int)(start * 1000));
                        var endTs = new TimeSpan(0, 0, 0, 0, (int)((start + duration) * 1000));
                        if (cmbTrans.SelectedIndex != 0) //Kiem tra xem co dich phu de sang ngon ngu khac hay khong
                            text = await Translate(text);

                        //dinh dang lai thoi gian
                        string startTsString = startTs.ToString().Replace(".", ",");
                        string endTsString = endTs.ToString().Replace(".", ",");

                        //dinh dang lai thoi gian cho phu hop voi file srt
                        if (startTsString.Substring(startTsString.Length - 4, 4) == "0000")
                            startTsString = startTsString.Substring(0, startTsString.Length - 4);
                        if (endTsString.Substring(endTsString.Length - 4, 4) == "0000")
                            endTsString = endTsString.Substring(0, endTsString.Length - 4);

                        if (!startTsString.Contains(","))
                            startTsString += ",000";
                        if (!endTsString.Contains(","))
                            endTsString += ",000";

                        var lineSrtFormat = $"{startTsString} --> {endTsString}";

                        var temp2 = temp++;
                        //Them du lieu vao danh sach
                        listToSrt.Add(temp2.ToString());
                        listToSrt.Add(lineSrtFormat);
                        listToSrt.Add(text);
                        listToSrt.Add("");

                        labelProcess.Invoke(new MethodInvoker(delegate
                            {
                                if (cmbTrans.SelectedIndex != 0)
                                    labelProcess.Text = $"Đã dịch được: {temp2}/{nodeList.Count} dòng";
                            }));
                    }
                    SaveFile();
                    if (string.IsNullOrEmpty(pathSaveFile))
                    {
                        MessageBox.Show("Bạn chưa chọn nơi lưu file", "Lỗi!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    File.WriteAllLines(pathSaveFile, listToSrt);
                    MessageBox.Show("Đã tải về thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDownload.Enabled = labelProcess.Visible = false;
                    btnDownload.Text = "Tải về";
                    btnCheck.Enabled = true;
                }
            }

        }

        private void SaveFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Srt File (*.srt)|*.srt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pathSaveFile = dlg.FileName;
            }
        }

        /// <summary>
        /// Dich ngon ngu
        /// </summary>
        /// <param name="textToTrans"></param>
        /// <returns></returns>
        private async Task<string> Translate(string textToTrans)
        {
            var result = "";
            
            var arrayTextToTrans = textToTrans.Split('.', '?', '!');
            foreach (var item in arrayTextToTrans)
            {
                using (HttpClient client = new HttpClient())
                {
                    var mSub = sub[cmbSub.SelectedIndex];
                    var linkGoogleTranslate =
                        $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={mSub.LangCode}&tl={langToTrans[cmbTrans.SelectedIndex]}&dt=t&q=" +
                        item.Replace(" ", "%20");
                    var text = await client.GetStringAsync(new Uri(linkGoogleTranslate));
                    var text2 = text.Replace("[[[\"", "");
                    var index = text2.IndexOf('\"');
                    var transLated = text2.Substring(0, index);
                    result += $"{transLated} ";
                   
                }
            }
            return result;
        }


    }
}
