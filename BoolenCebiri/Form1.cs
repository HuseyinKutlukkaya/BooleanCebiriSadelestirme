using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace odev1_son
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string denklem,yeniDenklem,tersi,parantezliKisim,carpanlar,yeniParantezliKisim;
        List<string> parcalanmisDenklem = new List<string>();
        ArrayList isaretliler = new ArrayList();
        ArrayList temp = new ArrayList();
        int durumNumarasi = 1;
        bool sadelestirmeYapildimi = false,parantezTespitEdildimi= false,ParantezAcikmi=false,parantezyokoldumu=false,ozelDurumOldumu;
        private void btn_coz_Click(object sender, EventArgs e)
        {
            durumNumarasi = 1;
            denklem = tb_denklem.Text;
            lb1.Text += "\nOrjinal hal";
            lb2.Text += "\n" + tb_denklem.Text;
            lb1.Text = "KURAL";
            lb2.Text = "İŞLEM";
            parantezyokoldumu = false;
            ozelDurumOldumu = false;
            do
            {
                do
                {
                   
                    parantezliKisim = "";
                    yeniParantezliKisim = "";
                    carpanlar = "";
                    parantezTespitEdildimi = false;
                    ParanteziTespitEt();
                    if (parantezTespitEdildimi)
                    {
                       ParantezliKisimiGeciciyeDoldur(parantezliKisim);
                        ParantezinYanCarpanlariniTespitEtVeSil();
                        ParantezDisindakileriDagit();
                        YeniParantezliDenklemiAktar();
                        ParantezleriCarp();
                        parantezyokoldumu = true;
                    }

                  
                } while (parantezTespitEdildimi);
                if(parantezyokoldumu)
                {
                    parantezyokoldumu = false;
                    lb1.Text += "\nParantezsiz Hal";
                    lb2.Text += "\n" + denklem;
                }
               
                parcalanmisDenklem.Clear();
                sadelestirmeYapildimi = false;
                parcalanmisDenklem.AddRange(denklem.Split('+'));
                TekTekSadeleştirme(); 
                OzelDurumKontrol();
                if(ozelDurumOldumu)
                {
                    lb1.Text += "\nDurum" + durumNumarasi.ToString();durumNumarasi++;
                    ekranaYaz();
                }
                denklemiGuncelle();
                for (int i = 0; i < parcalanmisDenklem.Count; i++)
                    for (int v = i + 1; v < parcalanmisDenklem.Count; v++)
                    {
                        Sadelestir(parcalanmisDenklem[i], parcalanmisDenklem[v]);
                    }

                
                if(sadelestirmeYapildimi)
                {
                    yeniDenklemiAktar();
                    lb1.Text += "\n Durum" + durumNumarasi.ToString();
                    durumNumarasi++;
                    lb2.Text += "\n " + denklem;
                }
            } while (sadelestirmeYapildimi);
              
        }
        void yeniDenklemiAktar()
        {
            for (int i = 0; i < parcalanmisDenklem.Count; i++)
            {
                if (!isaretliler.Contains(parcalanmisDenklem[i]))
                    yeniDenklem += parcalanmisDenklem[i].ToString() + "+";
            }
            isaretliler.Clear();
           yeniDenklem= yeniDenklem.Remove(yeniDenklem.Length-1);
            denklem = yeniDenklem;
            yeniDenklem = "";
        }
        void ParanteziTespitEt()
        {
            string karakter;
            ParantezAcikmi = false;
            bool parantezBittimi=false;
            parantezliKisim = "";
            parcalanmisDenklem.Clear();
            parcalanmisDenklem.AddRange(denklem.Split('+'));
            for (int i = 0; i < parcalanmisDenklem.Count; i++)
            { 
                for (int b = 0; b < parcalanmisDenklem[i].Length; b++)
                {
                    karakter = parcalanmisDenklem[i].Substring(b, 1);
                    parantezliKisim += karakter;
                    if (karakter == "(")
                       ParantezAcikmi = true;
                    else if (karakter == ")")
                    {
                        parantezTespitEdildimi = true;
                        parantezBittimi = true;
                        ParantezAcikmi = false;
                    }
                     
                }
                if (parantezBittimi&&!ParantezAcikmi)
                    break;
                if (!ParantezAcikmi)
                    parantezliKisim = "";
                else
                    parantezliKisim += "+";
            }
        }
        void ParantezinYanCarpanlariniTespitEtVeSil()
        {
            carpanlar = "";
           ParantezAcikmi = false;
            for (int i = 0; i < temp.Count; i++)
            {
                
                if (temp[i].ToString() == "(")
                    ParantezAcikmi = true;
                 if (!ParantezAcikmi)
                    carpanlar += parantezliKisim[i].ToString();
                 if (temp[i].ToString() == ")")
                    ParantezAcikmi = false;
               
            }
            ParantezAcikmi = false;
            for (int i = 0; i < temp.Count; i++)
            {

                if (temp[i].ToString() == "(")
                    ParantezAcikmi = true;
                if (!ParantezAcikmi)
                {
                    temp.RemoveAt(i);
                    i = -1;
                   
                }       
               else if (temp[i].ToString() == ")")
                    ParantezAcikmi = false;

            }
        }
       void ParantezDisindakileriDagit()
        {
            bool eklemeYapilsinmi = true;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].ToString() == ")")
                    break;
                if (temp[i].ToString() != "+"&& temp[i].ToString() != "("&&eklemeYapilsinmi)
                {
                    temp[i] = carpanlar + temp[i].ToString();
                    eklemeYapilsinmi = false;
                }
                if (temp[i].ToString() == "+")
                    eklemeYapilsinmi = true;
            }
        }
      void YeniParantezliDenklemiAktar()
        {
            for (int i = 0; i < temp.Count; i++)
                yeniParantezliKisim += temp[i].ToString();

           
        }
        void ParantezleriCarp()
        {
            ArrayList temp2 = new ArrayList();
            parcalanmisDenklem.Clear();
            parcalanmisDenklem.AddRange(yeniParantezliKisim.Split(')'));
            parcalanmisDenklem.Remove("");

            for (int i = 0; i < parcalanmisDenklem.Count; i++)
                parcalanmisDenklem[i]=parcalanmisDenklem[i].Remove(0, 1);

            if (parcalanmisDenklem.Count > 1)
            {

                temp.Clear();
                temp.AddRange(parcalanmisDenklem[0].Split('+'));

                yeniParantezliKisim = "";
                for (int i = 1; i < parcalanmisDenklem.Count; i++)
                {
                    temp2.Clear();
                    temp2.AddRange(parcalanmisDenklem[i].Split('+'));
                    for (int v = 0; v < temp.Count; v++)
                    {
                        for (int b = 0; b < temp2.Count; b++)
                        {
                            yeniParantezliKisim += temp[v].ToString() + temp2[b].ToString() + "+";
                        }
                    }
                }
                yeniParantezliKisim = yeniParantezliKisim.Remove(yeniParantezliKisim.Length - 1);

            }
            else yeniParantezliKisim = parcalanmisDenklem[0];

            if(denklem.Contains("+"+parantezliKisim+"+"))
                denklem = denklem.Replace("+" + parantezliKisim + "+", "+" + yeniParantezliKisim + "+");
            else if (denklem.Contains( parantezliKisim + "+"))
                denklem = denklem.Replace(parantezliKisim + "+",  yeniParantezliKisim + "+");
            else if (denklem.Contains("+" + parantezliKisim))
                denklem = denklem.Replace("+" + parantezliKisim , "+" + yeniParantezliKisim);
            else 
               denklem= denklem.Replace( parantezliKisim , yeniParantezliKisim );
        }
        void Sadelestir(string a,string b)
        {
       
            string ortak_kisim = "";
            ArrayList t1 = new ArrayList();
            ArrayList t2 = new ArrayList();
            geciciyeDoldur(a);
            t1.AddRange(temp);
           
            geciciyeDoldur(b);
            t2.AddRange(temp);
        
            for (int i = 0; i < t1.Count; i++)
            {
                if(t2.Contains(t1[i].ToString()))
                {
                   
                    ortak_kisim += t1[i].ToString();
                    t2.Remove(t1[i].ToString());
                    t1.RemoveAt(i);
                    i--;
                }
            }
            if (t1.Count==0||t2.Count==0)
            {//kural ab+a=a
              
                sadelestirmeYapildimi = true;
                isaretliler.Add(a);
                isaretliler.Add(b);
                yeniDenklem += ortak_kisim + "+";
                lb1.Text += "\n abVa=a";
                lb2.Text += "\n " + a + "+" + b + "=" + ortak_kisim;
            }
            else if(t1.Count ==1 && t2.Count == 1)
            {
                TersiniBul(t1[0].ToString());
                if(tersi==t2[0].ToString())
                {
                    lb1.Text += "\n abVab'=a";
                    lb2.Text += "\n "+a+"+"+b+"="+ortak_kisim;
                    isaretliler.Add(a);
                    isaretliler.Add(b);
                    sadelestirmeYapildimi = true;
                    yeniDenklem += ortak_kisim + "+";
                }
            }
        }
        void denklemiGuncelle()
        { denklem = "";
            for (int i = 0; i < parcalanmisDenklem.Count; i++)
                if(i!=parcalanmisDenklem.Count-1)
                denklem += parcalanmisDenklem[i].ToString()+"+";
            else
                    denklem += parcalanmisDenklem[i].ToString();


        }
        void OzelDurumKontrol()
        {
            int a;
            if (parcalanmisDenklem.Contains("1"))
            {
                parcalanmisDenklem.Clear();
                sadelestirmeYapildimi = false;
                lb1.Text += "\naV1=1,Durum" + durumNumarasi.ToString() ;
                lb2.Text += "\n1";
                ozelDurumOldumu = true;
            }
            a = parcalanmisDenklem.Count;
            while (parcalanmisDenklem.Contains("0"))
            {
                parcalanmisDenklem.Remove("0");
                ozelDurumOldumu = true;
              
            }
            if(parcalanmisDenklem.Count!=a)
            {
                ozelDurumOldumu = true;
                lb1.Text += "\naV0=a";
                ekranaYaz();
            }
            for (int i = 0; i < parcalanmisDenklem.Count; i++)
            {
                for (int v = i+1; v < parcalanmisDenklem.Count; v++)
                {
                    if (parcalanmisDenklem[i].ToString() ==parcalanmisDenklem[v].ToString())
                    {
                        ozelDurumOldumu = true;
                        parcalanmisDenklem.RemoveAt(v);
                        v--;
                        i = 0;
                        lb1.Text += "\naVa=a";
                        ekranaYaz();
                    }
                }
            }
        }
        void TekTekSadeleştirme()
        {
            string gecici = "";
            for (int i = 0; i < parcalanmisDenklem.Count; i++)
            {
                if (parcalanmisDenklem[i].Contains("0")&&parcalanmisDenklem[i].Length>1)
                {
               
                    parcalanmisDenklem[i] = "0";
                    lb1.Text += "\na.0=0";
                    ekranaYaz();

                }
                   
                if (parcalanmisDenklem[i].Contains("1")&& parcalanmisDenklem[i].Length > 1)
                {
                    parcalanmisDenklem[i] = parcalanmisDenklem[i].Replace("1", string.Empty);
                    lb1.Text += "\na.1=a";
                    ekranaYaz();
                }

                gecici = parcalanmisDenklem[i];
                geciciyeDoldur(gecici);
                for (int b = 0; b < parcalanmisDenklem[i].Length; b++)
                {
                    if (b + 1 < gecici.Length)
                    {
                        if (gecici.Substring(b + 1, 1) == "'")
                        {
                            TersiniBul(gecici.Substring(b, 2));
                            b++;
                        }
                        else
                            TersiniBul(gecici.Substring(b, 1));

                        if (temp.Contains(tersi))
                        {
                            parcalanmisDenklem[i] = "0";
                            lb1.Text += "\na.a'=0";
                            ekranaYaz();
                        }
                    }                  
                }
                temp.Clear();
                gecici = parcalanmisDenklem[i];
                geciciyeDoldur(gecici);
                parcalanmisDenklem[i] = "";
                bool islemYapildimi = false;
                for (int n = 0; n < temp.Count; n++)
                {
                    for (int v =n+1; v < temp.Count; v++)
                    {
                        if (temp[v].ToString() == temp[n].ToString())
                        {
                            islemYapildimi = true;
                            temp.RemoveAt(v);
                            v--;
                        }    
                    }
                }
            
                for (int w = 0; w < temp.Count; w++)
                    parcalanmisDenklem[i] += temp[w].ToString();

                if(islemYapildimi)
                {
                    lb1.Text += "\na.a=a"; ekranaYaz();
                }
                   


            }

        }
       
	   void ekranaYaz()
        {
            denklem = "";
            for (int i = 0; i < parcalanmisDenklem.Count; i++)
            {if (i != parcalanmisDenklem.Count - 1)
                    denklem += parcalanmisDenklem[i].ToString() + "+";
                else
                    denklem += parcalanmisDenklem[i].ToString();
            }
            lb2.Text += "\n" + denklem;
        }
        void geciciyeDoldur(string a)
        {
          string  gecici = a;
            temp.Clear();
            for (int v = 0; v < a.Length; v++)
            {

                if (gecici.Substring(v, 1) == "'")
                    temp[temp.Count - 1] = temp[temp.Count - 1].ToString() + "'";
                else
                    temp.Add(gecici.Substring(v, 1).ToString());
            }   
        }
        void ParantezliKisimiGeciciyeDoldur(string a)
        {
            temp.Clear();
            for (int v = 0; v < a.Length; v++)                     
              temp.Add(a.Substring(v, 1).ToString());
           
        }
        void TersiniBul(string karakter)
        {
            if (karakter.Length == 1)
                tersi = karakter + "'";
            else if (karakter.Length == 2)
                tersi = karakter.Remove(karakter.Length - 1);
        }
    }
}
