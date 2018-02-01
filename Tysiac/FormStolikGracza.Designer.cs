namespace Tysiac
{
    partial class FormStolikGracza
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStolikGracza));
            this.buttonRozdajKarty = new System.Windows.Forms.Button();
            this.buttonPasuj = new System.Windows.Forms.Button();
            this.buttonLicytuj = new System.Windows.Forms.Button();
            this.numericUpDownLicytuj = new System.Windows.Forms.NumericUpDown();
            this.buttonPobierzTalon = new System.Windows.Forms.Button();
            this.buttonRozpocznijGre = new System.Windows.Forms.Button();
            this.buttonRezygnujZGry = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonWyniki = new System.Windows.Forms.Button();
            this.pictureBoxKolorAtu = new System.Windows.Forms.PictureBox();
            this.zbiorKartControlLewa = new TysiacClassLibrary.ZbiorKartControl();
            this.graczControl = new TysiacClassLibrary.GraczControl();
            this.graczControl3 = new TysiacClassLibrary.GraczControl();
            this.graczControl2 = new TysiacClassLibrary.GraczControl();
            this.zbiorKartControlKartyWygrane = new TysiacClassLibrary.ZbiorKartControl();
            this.zbiorKartControlKartyRozdane = new TysiacClassLibrary.ZbiorKartControl();
            this.kartaBoxKier9 = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKierWalet = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKierDama = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKierKrol = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKier10 = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKierAs = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKaro9 = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKaroWalet = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKaroDama = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKaroKrol = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKaro10 = new TysiacClassLibrary.KartaBox();
            this.kartaBoxKaroAs = new TysiacClassLibrary.KartaBox();
            this.kartaBoxTrefl9 = new TysiacClassLibrary.KartaBox();
            this.kartaBoxTreflWalet = new TysiacClassLibrary.KartaBox();
            this.kartaBoxTreflDama = new TysiacClassLibrary.KartaBox();
            this.kartaBoxTreflKrol = new TysiacClassLibrary.KartaBox();
            this.kartaBoxTrefl10 = new TysiacClassLibrary.KartaBox();
            this.kartaBoxTreflAs = new TysiacClassLibrary.KartaBox();
            this.kartaBoxPik9 = new TysiacClassLibrary.KartaBox();
            this.kartaBoxPikWalet = new TysiacClassLibrary.KartaBox();
            this.kartaBoxPikDama = new TysiacClassLibrary.KartaBox();
            this.kartaBoxPikKrol = new TysiacClassLibrary.KartaBox();
            this.kartaBoxPik10 = new TysiacClassLibrary.KartaBox();
            this.kartaBoxPikAs = new TysiacClassLibrary.KartaBox();
            this.zbiorKartControlKartaGracza2 = new TysiacClassLibrary.ZbiorKartControl();
            this.zbiorKartControlKartaGracza3 = new TysiacClassLibrary.ZbiorKartControl();
            this.zbiorKartControlTalon = new TysiacClassLibrary.ZbiorKartControl();
            this.labelChat = new System.Windows.Forms.Label();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLicytuj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKolorAtu)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRozdajKarty
            // 
            this.buttonRozdajKarty.ForeColor = System.Drawing.Color.White;
            this.buttonRozdajKarty.Image = global::Tysiac.Properties.Resources.backGreen;
            resources.ApplyResources(this.buttonRozdajKarty, "buttonRozdajKarty");
            this.buttonRozdajKarty.Name = "buttonRozdajKarty";
            this.buttonRozdajKarty.UseVisualStyleBackColor = true;
            this.buttonRozdajKarty.Click += new System.EventHandler(this.buttonRozdajKarty_Click);
            // 
            // buttonPasuj
            // 
            resources.ApplyResources(this.buttonPasuj, "buttonPasuj");
            this.buttonPasuj.ForeColor = System.Drawing.Color.White;
            this.buttonPasuj.Name = "buttonPasuj";
            this.buttonPasuj.UseVisualStyleBackColor = true;
            this.buttonPasuj.Click += new System.EventHandler(this.buttonPasuj_Click);
            // 
            // buttonLicytuj
            // 
            this.buttonLicytuj.BackgroundImage = global::Tysiac.Properties.Resources.backGreen;
            this.buttonLicytuj.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonLicytuj, "buttonLicytuj");
            this.buttonLicytuj.Name = "buttonLicytuj";
            this.buttonLicytuj.UseVisualStyleBackColor = true;
            this.buttonLicytuj.Click += new System.EventHandler(this.buttonLicytuj_Click);
            // 
            // numericUpDownLicytuj
            // 
            this.numericUpDownLicytuj.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this.numericUpDownLicytuj, "numericUpDownLicytuj");
            this.numericUpDownLicytuj.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownLicytuj.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownLicytuj.Name = "numericUpDownLicytuj";
            this.numericUpDownLicytuj.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownLicytuj.ValueChanged += new System.EventHandler(this.numericUpDownLicytuj_ValueChanged);
            // 
            // buttonPobierzTalon
            // 
            this.buttonPobierzTalon.BackgroundImage = global::Tysiac.Properties.Resources.backGreen;
            this.buttonPobierzTalon.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonPobierzTalon, "buttonPobierzTalon");
            this.buttonPobierzTalon.Name = "buttonPobierzTalon";
            this.toolTip.SetToolTip(this.buttonPobierzTalon, resources.GetString("buttonPobierzTalon.ToolTip"));
            this.buttonPobierzTalon.UseVisualStyleBackColor = false;
            this.buttonPobierzTalon.Click += new System.EventHandler(this.buttonPobierzTalon_Click);
            // 
            // buttonRozpocznijGre
            // 
            resources.ApplyResources(this.buttonRozpocznijGre, "buttonRozpocznijGre");
            this.buttonRozpocznijGre.ForeColor = System.Drawing.Color.White;
            this.buttonRozpocznijGre.Name = "buttonRozpocznijGre";
            this.buttonRozpocznijGre.UseVisualStyleBackColor = true;
            this.buttonRozpocznijGre.Click += new System.EventHandler(this.buttonRozpocznijGre_Click);
            // 
            // buttonRezygnujZGry
            // 
            resources.ApplyResources(this.buttonRezygnujZGry, "buttonRezygnujZGry");
            this.buttonRezygnujZGry.ForeColor = System.Drawing.Color.White;
            this.buttonRezygnujZGry.Name = "buttonRezygnujZGry";
            this.buttonRezygnujZGry.UseVisualStyleBackColor = true;
            this.buttonRezygnujZGry.Click += new System.EventHandler(this.buttonRezygnujZGry_Click);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            this.toolTip.ShowAlways = true;
            // 
            // buttonWyniki
            // 
            resources.ApplyResources(this.buttonWyniki, "buttonWyniki");
            this.buttonWyniki.ForeColor = System.Drawing.Color.White;
            this.buttonWyniki.Name = "buttonWyniki";
            this.toolTip.SetToolTip(this.buttonWyniki, resources.GetString("buttonWyniki.ToolTip"));
            this.buttonWyniki.UseVisualStyleBackColor = false;
            this.buttonWyniki.Click += new System.EventHandler(this.buttonWyniki_Click);
            // 
            // pictureBoxKolorAtu
            // 
            this.pictureBoxKolorAtu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxKolorAtu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBoxKolorAtu.Image = global::Tysiac.Properties.Resources.he;
            resources.ApplyResources(this.pictureBoxKolorAtu, "pictureBoxKolorAtu");
            this.pictureBoxKolorAtu.Name = "pictureBoxKolorAtu";
            this.pictureBoxKolorAtu.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBoxKolorAtu, resources.GetString("pictureBoxKolorAtu.ToolTip"));
            // 
            // zbiorKartControlLewa
            // 
            this.zbiorKartControlLewa.BackColor = System.Drawing.Color.Transparent;
            this.zbiorKartControlLewa.Licznik_Visible = false;
            resources.ApplyResources(this.zbiorKartControlLewa, "zbiorKartControlLewa");
            this.zbiorKartControlLewa.Name = "zbiorKartControlLewa";
            this.zbiorKartControlLewa.Nazwa_Text = "lewa";
            this.zbiorKartControlLewa.Nazwa_Visible = true;
            this.zbiorKartControlLewa.Picture_Visible = true;
            this.zbiorKartControlLewa.Sort_Visible = false;
            this.zbiorKartControlLewa.ZbiorKart = null;
            // 
            // graczControl
            // 
            this.graczControl.BackColor = System.Drawing.Color.Transparent;
            this.graczControl.Gracz = null;
            this.graczControl.Gracz_Image = global::Tysiac.Properties.Resources.rubberduck;
            this.graczControl.Gracz_Text = "Ola";
            resources.ApplyResources(this.graczControl, "graczControl");
            this.graczControl.Name = "graczControl";
            // 
            // graczControl3
            // 
            this.graczControl3.BackColor = System.Drawing.Color.Transparent;
            this.graczControl3.Gracz = null;
            this.graczControl3.Gracz_Image = global::Tysiac.Properties.Resources.soccerball;
            this.graczControl3.Gracz_Text = "Szymek";
            resources.ApplyResources(this.graczControl3, "graczControl3");
            this.graczControl3.Name = "graczControl3";
            // 
            // graczControl2
            // 
            this.graczControl2.BackColor = System.Drawing.Color.Transparent;
            this.graczControl2.Gracz = null;
            this.graczControl2.Gracz_Image = global::Tysiac.Properties.Resources.cat;
            this.graczControl2.Gracz_Text = "Mati";
            resources.ApplyResources(this.graczControl2, "graczControl2");
            this.graczControl2.Name = "graczControl2";
            // 
            // zbiorKartControlKartyWygrane
            // 
            this.zbiorKartControlKartyWygrane.BackColor = System.Drawing.Color.Transparent;
            this.zbiorKartControlKartyWygrane.Licznik_Visible = true;
            resources.ApplyResources(this.zbiorKartControlKartyWygrane, "zbiorKartControlKartyWygrane");
            this.zbiorKartControlKartyWygrane.Name = "zbiorKartControlKartyWygrane";
            this.zbiorKartControlKartyWygrane.Nazwa_Text = "karty wygrane";
            this.zbiorKartControlKartyWygrane.Nazwa_Visible = true;
            this.zbiorKartControlKartyWygrane.Picture_Visible = true;
            this.zbiorKartControlKartyWygrane.Sort_Visible = true;
            this.zbiorKartControlKartyWygrane.ZbiorKart = null;
            // 
            // zbiorKartControlKartyRozdane
            // 
            this.zbiorKartControlKartyRozdane.BackColor = System.Drawing.Color.Transparent;
            this.zbiorKartControlKartyRozdane.Licznik_Visible = false;
            resources.ApplyResources(this.zbiorKartControlKartyRozdane, "zbiorKartControlKartyRozdane");
            this.zbiorKartControlKartyRozdane.Name = "zbiorKartControlKartyRozdane";
            this.zbiorKartControlKartyRozdane.Nazwa_Text = "karty rozdane";
            this.zbiorKartControlKartyRozdane.Nazwa_Visible = false;
            this.zbiorKartControlKartyRozdane.Picture_Visible = true;
            this.zbiorKartControlKartyRozdane.Sort_Visible = true;
            this.zbiorKartControlKartyRozdane.ZbiorKart = null;
            // 
            // kartaBoxKier9
            // 
            this.kartaBoxKier9.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKier9.BackgroundImage = global::Tysiac.Properties.Resources.he9;
            resources.ApplyResources(this.kartaBoxKier9, "kartaBoxKier9");
            this.kartaBoxKier9.Karta = null;
            this.kartaBoxKier9.Name = "kartaBoxKier9";
            // 
            // kartaBoxKierWalet
            // 
            this.kartaBoxKierWalet.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKierWalet.BackgroundImage = global::Tysiac.Properties.Resources.hej;
            resources.ApplyResources(this.kartaBoxKierWalet, "kartaBoxKierWalet");
            this.kartaBoxKierWalet.Karta = null;
            this.kartaBoxKierWalet.Name = "kartaBoxKierWalet";
            // 
            // kartaBoxKierDama
            // 
            this.kartaBoxKierDama.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKierDama.BackgroundImage = global::Tysiac.Properties.Resources.heq;
            resources.ApplyResources(this.kartaBoxKierDama, "kartaBoxKierDama");
            this.kartaBoxKierDama.Karta = null;
            this.kartaBoxKierDama.Name = "kartaBoxKierDama";
            // 
            // kartaBoxKierKrol
            // 
            this.kartaBoxKierKrol.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKierKrol.BackgroundImage = global::Tysiac.Properties.Resources.hek;
            resources.ApplyResources(this.kartaBoxKierKrol, "kartaBoxKierKrol");
            this.kartaBoxKierKrol.Karta = null;
            this.kartaBoxKierKrol.Name = "kartaBoxKierKrol";
            // 
            // kartaBoxKier10
            // 
            this.kartaBoxKier10.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKier10.BackgroundImage = global::Tysiac.Properties.Resources.he10;
            resources.ApplyResources(this.kartaBoxKier10, "kartaBoxKier10");
            this.kartaBoxKier10.Karta = null;
            this.kartaBoxKier10.Name = "kartaBoxKier10";
            // 
            // kartaBoxKierAs
            // 
            this.kartaBoxKierAs.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKierAs.BackgroundImage = global::Tysiac.Properties.Resources.he1;
            resources.ApplyResources(this.kartaBoxKierAs, "kartaBoxKierAs");
            this.kartaBoxKierAs.Karta = null;
            this.kartaBoxKierAs.Name = "kartaBoxKierAs";
            // 
            // kartaBoxKaro9
            // 
            this.kartaBoxKaro9.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKaro9.BackgroundImage = global::Tysiac.Properties.Resources.di9;
            resources.ApplyResources(this.kartaBoxKaro9, "kartaBoxKaro9");
            this.kartaBoxKaro9.Karta = null;
            this.kartaBoxKaro9.Name = "kartaBoxKaro9";
            // 
            // kartaBoxKaroWalet
            // 
            this.kartaBoxKaroWalet.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKaroWalet.BackgroundImage = global::Tysiac.Properties.Resources.dij;
            resources.ApplyResources(this.kartaBoxKaroWalet, "kartaBoxKaroWalet");
            this.kartaBoxKaroWalet.Karta = null;
            this.kartaBoxKaroWalet.Name = "kartaBoxKaroWalet";
            // 
            // kartaBoxKaroDama
            // 
            this.kartaBoxKaroDama.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKaroDama.BackgroundImage = global::Tysiac.Properties.Resources.diq;
            resources.ApplyResources(this.kartaBoxKaroDama, "kartaBoxKaroDama");
            this.kartaBoxKaroDama.Karta = null;
            this.kartaBoxKaroDama.Name = "kartaBoxKaroDama";
            // 
            // kartaBoxKaroKrol
            // 
            this.kartaBoxKaroKrol.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKaroKrol.BackgroundImage = global::Tysiac.Properties.Resources.dik;
            resources.ApplyResources(this.kartaBoxKaroKrol, "kartaBoxKaroKrol");
            this.kartaBoxKaroKrol.Karta = null;
            this.kartaBoxKaroKrol.Name = "kartaBoxKaroKrol";
            // 
            // kartaBoxKaro10
            // 
            this.kartaBoxKaro10.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKaro10.BackgroundImage = global::Tysiac.Properties.Resources.di10;
            resources.ApplyResources(this.kartaBoxKaro10, "kartaBoxKaro10");
            this.kartaBoxKaro10.Karta = null;
            this.kartaBoxKaro10.Name = "kartaBoxKaro10";
            // 
            // kartaBoxKaroAs
            // 
            this.kartaBoxKaroAs.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxKaroAs.BackgroundImage = global::Tysiac.Properties.Resources.di1;
            resources.ApplyResources(this.kartaBoxKaroAs, "kartaBoxKaroAs");
            this.kartaBoxKaroAs.Karta = null;
            this.kartaBoxKaroAs.Name = "kartaBoxKaroAs";
            // 
            // kartaBoxTrefl9
            // 
            this.kartaBoxTrefl9.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxTrefl9.BackgroundImage = global::Tysiac.Properties.Resources.cl9;
            resources.ApplyResources(this.kartaBoxTrefl9, "kartaBoxTrefl9");
            this.kartaBoxTrefl9.Karta = null;
            this.kartaBoxTrefl9.Name = "kartaBoxTrefl9";
            // 
            // kartaBoxTreflWalet
            // 
            this.kartaBoxTreflWalet.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxTreflWalet.BackgroundImage = global::Tysiac.Properties.Resources.clj;
            resources.ApplyResources(this.kartaBoxTreflWalet, "kartaBoxTreflWalet");
            this.kartaBoxTreflWalet.Karta = null;
            this.kartaBoxTreflWalet.Name = "kartaBoxTreflWalet";
            // 
            // kartaBoxTreflDama
            // 
            this.kartaBoxTreflDama.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxTreflDama.BackgroundImage = global::Tysiac.Properties.Resources.clq;
            resources.ApplyResources(this.kartaBoxTreflDama, "kartaBoxTreflDama");
            this.kartaBoxTreflDama.Karta = null;
            this.kartaBoxTreflDama.Name = "kartaBoxTreflDama";
            // 
            // kartaBoxTreflKrol
            // 
            this.kartaBoxTreflKrol.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxTreflKrol.BackgroundImage = global::Tysiac.Properties.Resources.clk;
            resources.ApplyResources(this.kartaBoxTreflKrol, "kartaBoxTreflKrol");
            this.kartaBoxTreflKrol.Karta = null;
            this.kartaBoxTreflKrol.Name = "kartaBoxTreflKrol";
            // 
            // kartaBoxTrefl10
            // 
            this.kartaBoxTrefl10.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxTrefl10.BackgroundImage = global::Tysiac.Properties.Resources.cl10;
            resources.ApplyResources(this.kartaBoxTrefl10, "kartaBoxTrefl10");
            this.kartaBoxTrefl10.Karta = null;
            this.kartaBoxTrefl10.Name = "kartaBoxTrefl10";
            // 
            // kartaBoxTreflAs
            // 
            this.kartaBoxTreflAs.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxTreflAs.BackgroundImage = global::Tysiac.Properties.Resources.cl1;
            resources.ApplyResources(this.kartaBoxTreflAs, "kartaBoxTreflAs");
            this.kartaBoxTreflAs.Karta = null;
            this.kartaBoxTreflAs.Name = "kartaBoxTreflAs";
            // 
            // kartaBoxPik9
            // 
            this.kartaBoxPik9.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxPik9.BackgroundImage = global::Tysiac.Properties.Resources.sp9;
            resources.ApplyResources(this.kartaBoxPik9, "kartaBoxPik9");
            this.kartaBoxPik9.Karta = null;
            this.kartaBoxPik9.Name = "kartaBoxPik9";
            // 
            // kartaBoxPikWalet
            // 
            this.kartaBoxPikWalet.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxPikWalet.BackgroundImage = global::Tysiac.Properties.Resources.spj;
            resources.ApplyResources(this.kartaBoxPikWalet, "kartaBoxPikWalet");
            this.kartaBoxPikWalet.Karta = null;
            this.kartaBoxPikWalet.Name = "kartaBoxPikWalet";
            // 
            // kartaBoxPikDama
            // 
            this.kartaBoxPikDama.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxPikDama.BackgroundImage = global::Tysiac.Properties.Resources.spq;
            resources.ApplyResources(this.kartaBoxPikDama, "kartaBoxPikDama");
            this.kartaBoxPikDama.Karta = null;
            this.kartaBoxPikDama.Name = "kartaBoxPikDama";
            // 
            // kartaBoxPikKrol
            // 
            this.kartaBoxPikKrol.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxPikKrol.BackgroundImage = global::Tysiac.Properties.Resources.spk;
            resources.ApplyResources(this.kartaBoxPikKrol, "kartaBoxPikKrol");
            this.kartaBoxPikKrol.Karta = null;
            this.kartaBoxPikKrol.Name = "kartaBoxPikKrol";
            // 
            // kartaBoxPik10
            // 
            this.kartaBoxPik10.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxPik10.BackgroundImage = global::Tysiac.Properties.Resources.sp10;
            resources.ApplyResources(this.kartaBoxPik10, "kartaBoxPik10");
            this.kartaBoxPik10.Karta = null;
            this.kartaBoxPik10.Name = "kartaBoxPik10";
            // 
            // kartaBoxPikAs
            // 
            this.kartaBoxPikAs.BackColor = System.Drawing.Color.Transparent;
            this.kartaBoxPikAs.BackgroundImage = global::Tysiac.Properties.Resources.sp1;
            resources.ApplyResources(this.kartaBoxPikAs, "kartaBoxPikAs");
            this.kartaBoxPikAs.Karta = null;
            this.kartaBoxPikAs.Name = "kartaBoxPikAs";
            // 
            // zbiorKartControlKartaGracza2
            // 
            this.zbiorKartControlKartaGracza2.BackColor = System.Drawing.Color.Transparent;
            this.zbiorKartControlKartaGracza2.Licznik_Visible = false;
            resources.ApplyResources(this.zbiorKartControlKartaGracza2, "zbiorKartControlKartaGracza2");
            this.zbiorKartControlKartaGracza2.Name = "zbiorKartControlKartaGracza2";
            this.zbiorKartControlKartaGracza2.Nazwa_Text = "karta gracza 1";
            this.zbiorKartControlKartaGracza2.Nazwa_Visible = false;
            this.zbiorKartControlKartaGracza2.Picture_Visible = true;
            this.zbiorKartControlKartaGracza2.Sort_Visible = false;
            this.zbiorKartControlKartaGracza2.ZbiorKart = null;
            // 
            // zbiorKartControlKartaGracza3
            // 
            this.zbiorKartControlKartaGracza3.BackColor = System.Drawing.Color.Transparent;
            this.zbiorKartControlKartaGracza3.Licznik_Visible = false;
            resources.ApplyResources(this.zbiorKartControlKartaGracza3, "zbiorKartControlKartaGracza3");
            this.zbiorKartControlKartaGracza3.Name = "zbiorKartControlKartaGracza3";
            this.zbiorKartControlKartaGracza3.Nazwa_Text = "karta gracza 2";
            this.zbiorKartControlKartaGracza3.Nazwa_Visible = false;
            this.zbiorKartControlKartaGracza3.Picture_Visible = true;
            this.zbiorKartControlKartaGracza3.Sort_Visible = false;
            this.zbiorKartControlKartaGracza3.ZbiorKart = null;
            // 
            // zbiorKartControlTalon
            // 
            this.zbiorKartControlTalon.BackColor = System.Drawing.Color.Transparent;
            this.zbiorKartControlTalon.Licznik_Visible = false;
            resources.ApplyResources(this.zbiorKartControlTalon, "zbiorKartControlTalon");
            this.zbiorKartControlTalon.Name = "zbiorKartControlTalon";
            this.zbiorKartControlTalon.Nazwa_Text = "talon";
            this.zbiorKartControlTalon.Nazwa_Visible = true;
            this.zbiorKartControlTalon.Picture_Visible = true;
            this.zbiorKartControlTalon.Sort_Visible = false;
            this.zbiorKartControlTalon.ZbiorKart = null;
            // 
            // labelChat
            // 
            resources.ApplyResources(this.labelChat, "labelChat");
            this.labelChat.BackColor = System.Drawing.Color.Transparent;
            this.labelChat.ForeColor = System.Drawing.Color.White;
            this.labelChat.Name = "labelChat";
            // 
            // richTextBoxChat
            // 
            resources.ApplyResources(this.richTextBoxChat, "richTextBoxChat");
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            // 
            // richTextBoxMessage
            // 
            resources.ApplyResources(this.richTextBoxMessage, "richTextBoxMessage");
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.BackgroundImage = global::Tysiac.Properties.Resources.backGreen;
            this.buttonSendMessage.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonSendMessage, "buttonSendMessage");
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // FormStolikGracza
            // 
            this.AcceptButton = this.buttonSendMessage;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tysiac.Properties.Resources.backGreen;
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.labelChat);
            this.Controls.Add(this.richTextBoxChat);
            this.Controls.Add(this.buttonPobierzTalon);
            this.Controls.Add(this.zbiorKartControlLewa);
            this.Controls.Add(this.graczControl);
            this.Controls.Add(this.graczControl3);
            this.Controls.Add(this.graczControl2);
            this.Controls.Add(this.pictureBoxKolorAtu);
            this.Controls.Add(this.buttonWyniki);
            this.Controls.Add(this.zbiorKartControlKartyWygrane);
            this.Controls.Add(this.zbiorKartControlKartyRozdane);
            this.Controls.Add(this.kartaBoxKier9);
            this.Controls.Add(this.kartaBoxKierWalet);
            this.Controls.Add(this.kartaBoxKierDama);
            this.Controls.Add(this.kartaBoxKierKrol);
            this.Controls.Add(this.kartaBoxKier10);
            this.Controls.Add(this.kartaBoxKierAs);
            this.Controls.Add(this.kartaBoxKaro9);
            this.Controls.Add(this.kartaBoxKaroWalet);
            this.Controls.Add(this.kartaBoxKaroDama);
            this.Controls.Add(this.kartaBoxKaroKrol);
            this.Controls.Add(this.kartaBoxKaro10);
            this.Controls.Add(this.kartaBoxKaroAs);
            this.Controls.Add(this.kartaBoxTrefl9);
            this.Controls.Add(this.kartaBoxTreflWalet);
            this.Controls.Add(this.kartaBoxTreflDama);
            this.Controls.Add(this.kartaBoxTreflKrol);
            this.Controls.Add(this.kartaBoxTrefl10);
            this.Controls.Add(this.kartaBoxTreflAs);
            this.Controls.Add(this.kartaBoxPik9);
            this.Controls.Add(this.kartaBoxPikWalet);
            this.Controls.Add(this.kartaBoxPikDama);
            this.Controls.Add(this.kartaBoxPikKrol);
            this.Controls.Add(this.kartaBoxPik10);
            this.Controls.Add(this.kartaBoxPikAs);
            this.Controls.Add(this.buttonRozdajKarty);
            this.Controls.Add(this.buttonRezygnujZGry);
            this.Controls.Add(this.buttonRozpocznijGre);
            this.Controls.Add(this.numericUpDownLicytuj);
            this.Controls.Add(this.buttonLicytuj);
            this.Controls.Add(this.buttonPasuj);
            this.Controls.Add(this.zbiorKartControlKartaGracza2);
            this.Controls.Add(this.zbiorKartControlKartaGracza3);
            this.Controls.Add(this.zbiorKartControlTalon);
            this.Name = "FormStolikGracza";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLicytuj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKolorAtu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRozdajKarty;
        private System.Windows.Forms.Button buttonPasuj;
        private System.Windows.Forms.Button buttonLicytuj;
        private System.Windows.Forms.NumericUpDown numericUpDownLicytuj;
        private System.Windows.Forms.Button buttonPobierzTalon;
        private System.Windows.Forms.Button buttonRozpocznijGre;
        private System.Windows.Forms.Button buttonRezygnujZGry;
        private TysiacClassLibrary.KartaBox kartaBoxPik9;
        private TysiacClassLibrary.KartaBox kartaBoxPikWalet;
        private TysiacClassLibrary.KartaBox kartaBoxPikDama;
        private TysiacClassLibrary.KartaBox kartaBoxPikKrol;
        private TysiacClassLibrary.KartaBox kartaBoxPik10;
        private TysiacClassLibrary.KartaBox kartaBoxPikAs;
        private TysiacClassLibrary.KartaBox kartaBoxTrefl9;
        private TysiacClassLibrary.KartaBox kartaBoxTreflWalet;
        private TysiacClassLibrary.KartaBox kartaBoxTreflDama;
        private TysiacClassLibrary.KartaBox kartaBoxTreflKrol;
        private TysiacClassLibrary.KartaBox kartaBoxTrefl10;
        private TysiacClassLibrary.KartaBox kartaBoxTreflAs;
        private TysiacClassLibrary.KartaBox kartaBoxKier9;
        private TysiacClassLibrary.KartaBox kartaBoxKierWalet;
        private TysiacClassLibrary.KartaBox kartaBoxKierDama;
        private TysiacClassLibrary.KartaBox kartaBoxKierKrol;
        private TysiacClassLibrary.KartaBox kartaBoxKier10;
        private TysiacClassLibrary.KartaBox kartaBoxKierAs;
        private TysiacClassLibrary.KartaBox kartaBoxKaro9;
        private TysiacClassLibrary.KartaBox kartaBoxKaroWalet;
        private TysiacClassLibrary.KartaBox kartaBoxKaroDama;
        private TysiacClassLibrary.KartaBox kartaBoxKaroKrol;
        private TysiacClassLibrary.KartaBox kartaBoxKaro10;
        private TysiacClassLibrary.KartaBox kartaBoxKaroAs;
        private TysiacClassLibrary.ZbiorKartControl zbiorKartControlKartyRozdane;
        private TysiacClassLibrary.ZbiorKartControl zbiorKartControlTalon;
        private TysiacClassLibrary.ZbiorKartControl zbiorKartControlKartaGracza2;
        private TysiacClassLibrary.ZbiorKartControl zbiorKartControlKartaGracza3;
        private TysiacClassLibrary.ZbiorKartControl zbiorKartControlLewa;
        private TysiacClassLibrary.ZbiorKartControl zbiorKartControlKartyWygrane;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonWyniki;
        private System.Windows.Forms.PictureBox pictureBoxKolorAtu;
        private TysiacClassLibrary.GraczControl graczControl2;
        private TysiacClassLibrary.GraczControl graczControl3;
        private TysiacClassLibrary.GraczControl graczControl;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.Button buttonSendMessage;
    }
}