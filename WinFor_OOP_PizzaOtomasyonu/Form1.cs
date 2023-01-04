﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFor_OOP_PizzaOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Ebat kucuk = new Ebat { Adi = "Küçük", Carpan= 1};
            Ebat orta = new Ebat { Adi = "Orta", Carpan = 1.25 };
            Ebat buyuk = new Ebat { Adi = "Büyük", Carpan = 1.75 };
            Ebat maxi = new Ebat { Adi = "Maxi", Carpan = 2 };
            cmbEbat.Items.Add(kucuk);
            cmbEbat.Items.Add(orta);
            cmbEbat.Items.Add(buyuk);
            cmbEbat.Items.Add(maxi);

            Pizza klasik = new Pizza { Adi = "Klasik", Fiyat = 14 };
            Pizza karisik = new Pizza { Adi = "Karışık", Fiyat = 17 };
            Pizza turkish = new Pizza { Adi = "Turkish", Fiyat = 20 };
            Pizza tuna = new Pizza { Adi = "Tuna", Fiyat = 21 };
            Pizza akdeniz = new Pizza { Adi = "Akdeniz", Fiyat = 19 };
            Pizza karadeniz = new Pizza { Adi = "Karadeniz", Fiyat = 22 };

            listPizzalar.Items.Add(klasik);
            listPizzalar.Items.Add(karisik);
            listPizzalar.Items.Add(turkish);
            listPizzalar.Items.Add(tuna);
            listPizzalar.Items.Add(akdeniz);
            listPizzalar.Items.Add(karadeniz);

            KenarTip ince = new KenarTip { Adi = "İnce Kenar", EkFiyat = 0 };
            rdbİnceKenar.Tag = ince;
            KenarTip kalin = new KenarTip { Adi = "Kalın Kenar", EkFiyat = 2 };
            rdbKalinKenar.Tag = kalin;


        }
        Siparis s;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Pizza p = (Pizza)listPizzalar.SelectedItem;
            p.Ebati =(Ebat)cmbEbat.SelectedItem;
            p.KenarTipi = rdbİnceKenar.Checked ? (KenarTip)rdbİnceKenar.Tag : (KenarTip)rdbKalinKenar.Tag;
            p.Malzemeler = new List<string>(); 
            foreach (CheckBox ctrl in groupBox1.Controls)
            { 
                {
                    p.Malzemeler.Add(ctrl.Text);
                }
            }
            decimal tutar = nudAdet.Value * p.Tutar;
            txtTutar.Text=tutar.ToString();
            s = new Siparis();
            s.Pizza=p;
            s.Adet = (int)nudAdet.Value;
        }
        
        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (s != null)
            {
                listSepet.Items.Add(s); 
            }
        }

        private void cmbEbat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSiparisOnay_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = 0;
            int adet = 0;
            foreach (Siparis spr in listSepet.Items)
            {
                toplamTutar += spr.Adet * spr.Pizza.Tutar;
                adet++;
            }
            lblToplamTutar.Text = toplamTutar.ToString();
            MessageBox.Show(string.Format("Toplam Sipariş Adediniz:{0}\nToplam Sipariş Tutarınız:{1}",adet,toplamTutar));
        }
    }
}
