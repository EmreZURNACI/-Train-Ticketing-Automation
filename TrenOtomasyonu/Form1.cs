using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrenOtomasyonu
{
    public partial class Form1 : Form
    {
        public string whereFrom = null;
        public string whereTo = null;
        public string whenFrom = null;
        public byte seferTürü = 0;
        public string whenTo = null;
        public byte yolcuSayisi = 0;
        public Random rnd = new Random();
        public Random random = new Random();
        public string[] sehirlerListesi = new string[81] {"Adana",
"Adıyaman",
"Afyonkarahisar",
"Ağrı",
"Aksaray",
"Amasya",
"Ankara",
"Antalya",
"Ardahan",
"Artvin",
"Aydın",
"Balıkesir",
"Bartın",
"Batman",
"Bayburt",
"Bilecik",
"Bingöl",
"Bitlis",
"Bolu",
"Burdur",
"Bursa",
"Çanakkale",
"Çankırı",
"Çorum",
"Denizli",
"Diyarbakır",
"Düzce",
"Edirne",
"Elazığ",
"Erzincan",
"Erzurum",
"Eskişehir",
"Gaziantep",
"Giresun",
"Gümüşhane",
"Hakkâri",
"Hatay",
"Iğdır",
"Isparta",
"İstanbul",
"İzmir",
"Kahramanmaraş",
"Karabük",
"Karaman",
"Kars",
"Kastamonu",
"Kayseri",
"Kilis",
"Kırıkkale",
"Kırklareli",
"Kırşehir",
"Kocaeli",
"Konya",
"Kütahya",
"Malatya",
"Manisa",
"Mardin",
"Mersin",
"Muğla",
"Muş",
"Nevşehir",
"Niğde",
"Ordu",
"Osmaniye",
"Rize",
"Sakarya",
"Samsun",
"Şanlıurfa",
"Siirt",
"Sinop",
"Sivas",
"Şırnak",
"Tekirdağ",
"Tokat",
"Trabzon",
"Tunceli",
"Uşak",
"Van",
"Yalova",
"Yozgat",
"Zonguldak"};
        public string[] gidisSeferSaatleri = new string[12];
        public string[] gelisSeferSaatleri = new string[12];
        public string name = null;
        public string surname = null;
        private string tcno = null;
        public string TCNO
        {
            get
            {
                return tcno;
            }
            set
            {
                tcno=value;
            }
        }
        readonly Form2 frm2 = new Form2();
        public Db_Tren_Seferleri_Entities dbTrenSeferleri = new Db_Tren_Seferleri_Entities();
        public Form1()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.Enabled = false;
            label7.Enabled = false;
            monthCalendar2.Enabled = false;
            comboBox2.Enabled = false;
            comboBox2.SelectedIndex = -1;
            seferTürü = 0;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Enabled = true;
            label7.Enabled = true;
            monthCalendar2.Enabled = true;
            comboBox2.Enabled = true;
            seferTürü = 1;
            comboBox2.Text = gelisSeferSaatleri[0];
            Array.Sort(gelisSeferSaatleri);
            comboBox2.DataSource = gelisSeferSaatleri;
            comboBox2.DisplayMember = gelisSeferSaatleri.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int sehirPlaka = (rnd.Next(81));
            int sehirPlaka2 = (rnd.Next(81));
            goFrom.Text = sehirlerListesi[sehirPlaka].ToString();
            goTo.Text = sehirlerListesi[sehirPlaka2].ToString();
            gidisSeferSaatleri = seferSaatiAyarla(gidisSeferSaatleri);
            gelisSeferSaatleri = seferSaatiAyarla(gelisSeferSaatleri);
            Array.Sort(gidisSeferSaatleri);
            comboBox1.DataSource = gidisSeferSaatleri;
            comboBox1.DisplayMember = gidisSeferSaatleri.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            whereFrom = goFrom.Text.Trim();
            whereTo = goTo.Text.Trim();
            yolcuSayisi = byte.Parse(numericUpDown1.Value.ToString());
            if (radioButton1.Checked == true)
            {
                if (whereFrom != null && whereTo != null && whenFrom != null && yolcuSayisi != 0 && tcno!=null && name != null && surname != null)
                {

                    MessageBox.Show("Aradığınız Kritelere Uygun Sefer Bulundu." +
                                    "\n" + whereFrom + "'dan kalkacak sefer " + whereTo + "'a gidecektir." +
                                    "\nSeferiniz " + whenFrom + " tarihinde" + "saat:  " + comboBox1.SelectedValue + " gerçekleşecektir." +
                                    "\n" + yolcuSayisi + " kişilik biletiniz bulunuyor." +
                                    "\nKoltuk Seçimi İçin Yönlendiriliyorsunuz", "SEFER BULUNDU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmDatas();
                    frm2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Girdiğiniz Bilgiler Eksik veya Hatalıdır.", "HATALI BİLGİLER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (whereFrom != null && whereTo != null && whenFrom != null && whenTo != null && yolcuSayisi != 0 && tcno != null && name != null && surname != null)
                {
                    MessageBox.Show("Aradığınız Kritelere Uygun Sefer Bulundu." +
                                    "\n" + whereFrom + "'dan kalkacak sefer " + whereTo + "'a gidecektir." +
                                    "\nGidiş seferiniz " + whenFrom + " tarihinde saat : " + comboBox1.SelectedValue + "'da"
                                    + "\nGeliş seferiniz ise " + whenTo + " tarihinde saat:  " + comboBox2.SelectedValue + "'da" + " gerçekleşecektir." +
                                    "\n" + yolcuSayisi + " kişilik biletiniz bulunuyor." +
                                     "\nKoltuk Seçimi İçin Yönlendiriliyorsunuz", "SEFER BULUNDU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmDatas();
                    frm2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Girdiğiniz Bilgiler Eksik veya Hatalıdır.", "HATALI BİLGİLER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            whenFrom = FixDate(date);

        }
        private void label5_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.AddDays(1);
            whenFrom = FixDate(date);

        }
        private void label6_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            whenTo = FixDate(date);
        }
        private void label7_Click(object sender, EventArgs e)
        {
            int[] tarihler = FixDateConverter(whenFrom);
            DateTime date = new DateTime(tarihler[2], tarihler[1], tarihler[0]);
            whenTo = FixDate(date);
        }
        public string FixDate(DateTime date)
        {
            string day = null;
            string month = null;
            string year = null;
            if (date.Day.ToString().Length == 2 && date.Month.ToString().Length == 2)
            {
                month = date.ToString().Substring(0, 2);
                day = date.ToString().Substring(3, 2);
                year = date.ToString().Substring(6, 4);
            }
            else if (date.Day.ToString().Length == 1 && date.Month.ToString().Length == 1)
            {
                month = date.ToString().Substring(0, 1);
                day = date.ToString().Substring(2, 1);
                year = date.ToString().Substring(4, 4);
            }
            else if (date.Day.ToString().Length == 1)
            {
                month = date.ToString().Substring(0, 2);
                day = date.ToString().Substring(3, 1);
                year = date.ToString().Substring(5, 4);
            }
            else if (date.Month.ToString().Length == 1)
            {
                month = date.ToString().Substring(0, 1);
                day = date.ToString().Substring(2, 2);
                year = date.ToString().Substring(5, 4);
            }
            return day + "/" + month + "/" + year;
        }
        public int[] FixDateConverter(string date)
        {
            //format :mm/dd/yyyy;
            string[] tarihElemanları = new string[3];
            tarihElemanları = date.Split('/');
            int day = 1;
            day += int.Parse(tarihElemanları[0]);
            int month = int.Parse(tarihElemanları[1]);
            int year = int.Parse(tarihElemanları[2]);
            int[] donecekDizi = new int[3] { day, month, year };
            return donecekDizi;
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (dateCompare())
            {
                MessageBox.Show("Geçmiş Tarihli Yolculuk Seçemezsin", "Tarihi geçmiş sefer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
            whenFrom = FixDate(monthCalendar1.SelectionRange.Start);
            }
        }
        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (dateCompare())
            {
                MessageBox.Show("Geçmiş Tarihli Yolculuk Seçemezsin", "Tarihi geçmiş sefer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                whenTo = FixDate(monthCalendar2.SelectionRange.Start);
            }
           
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (numericUpDown1.Value * 215).ToString() + " TL";
        }
        public string[] seferSaatiAyarla(string[] saatler)
        {
            for (int i = 0; i < saatler.Length; i++)
            {
                string seferSaati = rnd.Next(24).ToString();
                if (seferSaati.Length == 1)
                {
                    saatler[i] = "0" + seferSaati + ":00";
                }
                else if (seferSaati.Length == 2)
                {
                    saatler[i] = seferSaati + ":00";
                }
            }
            for (int i = 0; i < saatler.Length; i++)
            {
                saatler[i] = rnd.Next(24).ToString();
            }
            IEnumerable<string> uniqueItems = saatler.Distinct<string>();
            saatler = uniqueItems.ToArray();
            for (int i = 0; i < saatler.Length; i++)
            {
                if (saatler[i].Length == 1)
                {
                    saatler[i] = "0" + saatler[i] + ":00";
                }
                else
                {
                    saatler[i] = saatler[i] + ":00";
                }
            }
            return saatler;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string temp = null;
            temp = goFrom.Text;
            goFrom.Text = goTo.Text;
            goTo.Text = temp;
        }
        public bool dateCompare()
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = monthCalendar1.SelectionRange.Start.Date;
            d2 += DateTime.Now.TimeOfDay;
            bool dateKontrol = d1 > d2;
            return dateKontrol;
        }
        public void frmDatas()
        {
            frm2.koltukAdedi = yolcuSayisi;
            frm2.whereFrom = whereFrom;
            frm2.whereTo = whereTo;
            frm2.whenFrom = whenFrom;
            frm2.whenTo = whenTo;
            frm2.seferTürü = seferTürü;
            frm2.gidisSaati = comboBox1.SelectedValue.ToString();
            if (seferTürü==1)
            {
                frm2.gelisSaati = comboBox2.SelectedValue.ToString();
            }
            frm2.biletFiyatı = numericUpDown1.Value;
            frm2.name = name;
            frm2.surnname = surname;
            frm2.TCNO = tcno;
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            name = textBox2.Text;
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            surname = textBox3.Text;
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            TCNO = maskedTextBox1.Text;
        }
    }
}
