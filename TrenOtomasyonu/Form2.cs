using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace TrenOtomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public byte koltukAdedi = 0;
        public byte koltukSayacı = 0;
        public List<string> koltukNo;
        public string koltuklar = null;
        public string whereFrom = null;
        public string whereTo = null;
        public string whenFrom = null;
        public byte seferTürü = 0;
        public string whenTo = null;
        public string gidisSaati;
        public string gelisSaati;
        public decimal biletFiyatı = 0;
        public string name = null;
        public string surnname = null;
        private string tcno = null;
        public string TCNO
        {
            get
            {
                return tcno;
            }
            set
            {
                tcno = value;
            }
        }
        public Db_Tren_Seferleri_Entities dbTrenSeferleri = new Db_Tren_Seferleri_Entities();
        private void Form2_Load(object sender, EventArgs e)
        {
            koltukNo = new List<string>();
            //MessageBox.Show(koltukAdedi + "Adet Koltuk Seçimi Yapacaksınız", "KOLTUK SEÇİMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pictureBox1.Location = new Point(0,-75);
            button1.Location = new Point(184, 117);
            button2.Location = new Point(184, 247);
            button3.Location = new Point(184, 313);
            button4.Location = new Point(227, 117);
            button5.Location = new Point(227, 247);
            button6.Location = new Point(227, 313);
            button7.Location = new Point(271, 117);
            button8.Location = new Point(271, 247);
            button9.Location = new Point(271, 313);
            button10.Location = new Point(314, 117);
            button11.Location = new Point(314, 247);
            button12.Location = new Point(314, 313);
            button13.Location = new Point(358, 117);
            button14.Location = new Point(358, 247);
            button15.Location = new Point(358, 313);
            button16.Location = new Point(402, 117);
            button17.Location = new Point(402, 247);
            button18.Location = new Point(402, 313);
            button19.Location = new Point(445, 117);
            button20.Location = new Point(445, 247);
            button21.Location = new Point(445, 313);
            button22.Location = new Point(490, 117);
            button23.Location = new Point(490, 247);
            button24.Location = new Point(490, 313);
            button25.Location = new Point(534, 117);
            button26.Location = new Point(534, 247);
            button27.Location = new Point(534, 313);
            button28.Location = new Point(578, 117);
            button29.Location = new Point(578, 247);
            button30.Location = new Point(578, 313);
            button31.Location = new Point(623, 117);
            button32.Location = new Point(623, 247);
            button33.Location = new Point(623, 313);
            button34.Location = new Point(668, 117);
            button35.Location = new Point(668, 247);
            button36.Location = new Point(668, 313);
            button37.Location = new Point(710, 117);
            button38.Location = new Point(710, 247);
            button39.Location = new Point(710, 313);
            button40.Location = new Point(755, 117);
            button41.Location = new Point(755, 247);
            button42.Location = new Point(755, 313);
            button43.Location = new Point(798, 117);
            button44.Location = new Point(798, 247);
            button45.Location = new Point(798, 313);
            button46.Location = new Point(842, 117);
            button47.Location = new Point(842, 247);
            button48.Location = new Point(842, 313);
            button49.Location = new Point(887, 117);
            button50.Location = new Point(887, 247);
            button51.Location = new Point(887, 313);
            button52.Location = new Point(930, 117);
            button53.Location = new Point(930, 247);
            button54.Location = new Point(930, 313);
            button55.Location = new Point(974, 117);
            button56.Location = new Point(974, 247);
            button57.Location = new Point(974, 313);
            button58.Location = new Point(1018, 117);
            button59.Location = new Point(1018, 247);
            button60.Location = new Point(1018, 313);
            BlockSeats();

        }
        public void cursorHand(Button[]dizi)
        {
            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i].Cursor = System.Windows.Forms.Cursors.Hand;
                dizi[i].Name = "Koltuk " + i;
            }
        }
        public void BlockSeats()
        {
            Random rnd = new Random();
            Button[] buttons = new Button[60]
            {
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9,
                button10,
                button11,
                button12,
                button13,
                button14,
                button15,
                button16,
                button17,
                button18,
                button19,
                button20,
                button21,
                button22,
                button23,
                button24,
                button25,
                button26,
                button27,
                button28,
                button29,
                button30,
                button31,
                button32,
                button33,
                button34,
                button35,
                button36,
                button37,
                button38,
                button39,
                button40,
                button41,
                button42,
                button43,
                button44,
                button45,
                button46,
                button47,
                button48,
                button49,
                button50,
                button51,
                button52,
                button53,
                button54,
                button55,
                button56,
                button57,
                button58,
                button59,
                button60
            };
            cursorHand(buttons);
            for (int i = 0; i < rnd.Next(58); i++)
            {
                int selectedButtonIndex=rnd.Next(60);
                buttons[selectedButtonIndex].BackColor = Color.Red;
                buttons[selectedButtonIndex].Cursor = System.Windows.Forms.Cursors.No;
            }
        }
        private void click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if (koltukSayacı < koltukAdedi)
            {
                if (btn.BackColor == Color.Red)
                {
                    MessageBox.Show("Bu koltuk zaten seçildi.\nLütfen boş koltukları seçiniz.", "DOLU KOLTUK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    btn.BackColor = Color.Blue;
                    koltukNo.Add(btn.Name);
                    koltukSayacı++;
                    if (koltukSayacı == koltukAdedi)
                    {
                       
                        koltukNo.Sort();
                        foreach (var item in koltukNo)
                        {
                            koltuklar += item + "\n";
                        }
                        
                        MessageBox.Show("Koltuklarınız Başarıyla Seçildi.\n" +
                                         "Koltuklarınız : \n" + koltuklar, "Koltuklar Seçildi.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        veriTabanıIslemleri();
                        MessageBox.Show("Sayın "+name+" "+surnname+"\nBizi Tercih Ettiğiniz İçin Teşekkür Eder,İyi Yolculuklar Dileriz...","İYİ YOLCULUKLAR");
                        Form2 frm2 = new Form2();
                        frm2.Close();
                        System.Environment.Exit(0);
                    }
                }
            }
            else
            {
                MessageBox.Show("Yeteri kadar koltuk seçildi.", "Koltuklarınız Seçildi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void veriTabanıIslemleri()
        {
            musteriTBL musteriTbl = new musteriTBL();
            musteriTbl.seferTürü = seferTürü;
            musteriTbl.nereden = whereFrom;
            musteriTbl.nereye = whereTo;
            musteriTbl.gidisSeferSaati = gidisSaati;
            musteriTbl.koltukAdet = koltukAdedi;
            musteriTbl.biletFiyatı = decimal.Parse((biletFiyatı* 215).ToString());
            musteriTbl.musteriAd = name;
            musteriTbl.musteriSoyad = surnname;
            musteriTbl.TCNO = tcno;
            musteriTbl.Koltukları= koltuklar.Replace("Koltuk ", " ");
            if (seferTürü == 1)
            {
                musteriTbl.gelisSeferSaati = gelisSaati;
            }
            else
            {
                musteriTbl.gelisSeferSaati = "--";
            }
            dbTrenSeferleri.musteriTBLs.Add(musteriTbl);
            dbTrenSeferleri.SaveChanges();

        }
    }
}
