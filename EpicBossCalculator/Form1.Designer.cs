namespace EpicBossCalculator
{
    partial class Form1
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
            this.armor2auto = new System.Windows.Forms.RadioButton();
            this.armor2panel = new System.Windows.Forms.Panel();
            this.armor2manual = new System.Windows.Forms.RadioButton();
            this.armor1panel = new System.Windows.Forms.Panel();
            this.armor1manual = new System.Windows.Forms.RadioButton();
            this.armor1auto = new System.Windows.Forms.RadioButton();
            this.armor2combo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.armor1combo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.outcomes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.calculate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.armor2element2 = new System.Windows.Forms.ComboBox();
            this.armor2element1 = new System.Windows.Forms.ComboBox();
            this.armor1element2 = new System.Windows.Forms.ComboBox();
            this.armor1element1 = new System.Windows.Forms.ComboBox();
            this.bossDefense = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.bossElement2 = new System.Windows.Forms.ComboBox();
            this.bossElement1 = new System.Windows.Forms.ComboBox();
            this.bossAttack = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.guildRank = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.airBonus = new System.Windows.Forms.ComboBox();
            this.earthBonus = new System.Windows.Forms.ComboBox();
            this.fireBonus = new System.Windows.Forms.ComboBox();
            this.spiritBonus = new System.Windows.Forms.ComboBox();
            this.waterBonus = new System.Windows.Forms.ComboBox();
            this.armor3panel = new System.Windows.Forms.Panel();
            this.armor3manual = new System.Windows.Forms.RadioButton();
            this.armor3auto = new System.Windows.Forms.RadioButton();
            this.armor3combo = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.armor3element2 = new System.Windows.Forms.ComboBox();
            this.armor3element1 = new System.Windows.Forms.ComboBox();
            this.armor1attack = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.armor1defense = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.armor2attack = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.armor2defense = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.armor3attack = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.armor3defense = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.bossHealth = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.bossLevel = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.armor2panel.SuspendLayout();
            this.armor1panel.SuspendLayout();
            this.armor3panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // armor2auto
            // 
            this.armor2auto.AutoSize = true;
            this.armor2auto.Location = new System.Drawing.Point(3, 51);
            this.armor2auto.Name = "armor2auto";
            this.armor2auto.Size = new System.Drawing.Size(72, 17);
            this.armor2auto.TabIndex = 11;
            this.armor2auto.TabStop = true;
            this.armor2auto.Text = "Automatic";
            this.armor2auto.UseVisualStyleBackColor = true;
            this.armor2auto.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // armor2panel
            // 
            this.armor2panel.Controls.Add(this.armor2manual);
            this.armor2panel.Controls.Add(this.armor2auto);
            this.armor2panel.Location = new System.Drawing.Point(15, 281);
            this.armor2panel.Name = "armor2panel";
            this.armor2panel.Size = new System.Drawing.Size(78, 76);
            this.armor2panel.TabIndex = 35;
            // 
            // armor2manual
            // 
            this.armor2manual.AutoSize = true;
            this.armor2manual.Location = new System.Drawing.Point(3, 4);
            this.armor2manual.Name = "armor2manual";
            this.armor2manual.Size = new System.Drawing.Size(60, 17);
            this.armor2manual.TabIndex = 10;
            this.armor2manual.TabStop = true;
            this.armor2manual.Text = "Manual";
            this.armor2manual.UseVisualStyleBackColor = true;
            this.armor2manual.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // armor1panel
            // 
            this.armor1panel.Controls.Add(this.armor1manual);
            this.armor1panel.Controls.Add(this.armor1auto);
            this.armor1panel.Location = new System.Drawing.Point(15, 186);
            this.armor1panel.Name = "armor1panel";
            this.armor1panel.Size = new System.Drawing.Size(78, 78);
            this.armor1panel.TabIndex = 25;
            // 
            // armor1manual
            // 
            this.armor1manual.AutoSize = true;
            this.armor1manual.Location = new System.Drawing.Point(3, 4);
            this.armor1manual.Name = "armor1manual";
            this.armor1manual.Size = new System.Drawing.Size(60, 17);
            this.armor1manual.TabIndex = 2;
            this.armor1manual.TabStop = true;
            this.armor1manual.Text = "Manual";
            this.armor1manual.UseVisualStyleBackColor = true;
            this.armor1manual.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // armor1auto
            // 
            this.armor1auto.AutoSize = true;
            this.armor1auto.Location = new System.Drawing.Point(3, 51);
            this.armor1auto.Name = "armor1auto";
            this.armor1auto.Size = new System.Drawing.Size(72, 17);
            this.armor1auto.TabIndex = 3;
            this.armor1auto.TabStop = true;
            this.armor1auto.Text = "Automatic";
            this.armor1auto.UseVisualStyleBackColor = true;
            this.armor1auto.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // armor2combo
            // 
            this.armor2combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.armor2combo.FormattingEnabled = true;
            this.armor2combo.Location = new System.Drawing.Point(99, 328);
            this.armor2combo.Name = "armor2combo";
            this.armor2combo.Size = new System.Drawing.Size(189, 21);
            this.armor2combo.TabIndex = 44;
            this.armor2combo.SelectedIndexChanged += new System.EventHandler(this.armor2combo_SelectedIndexChanged);
            this.armor2combo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(99, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Armor 2";
            // 
            // armor1combo
            // 
            this.armor1combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.armor1combo.FormattingEnabled = true;
            this.armor1combo.Location = new System.Drawing.Point(99, 233);
            this.armor1combo.Name = "armor1combo";
            this.armor1combo.Size = new System.Drawing.Size(189, 21);
            this.armor1combo.TabIndex = 32;
            this.armor1combo.SelectedIndexChanged += new System.EventHandler(this.armor1combo_SelectedIndexChanged);
            this.armor1combo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(99, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Armor 1";
            // 
            // outcomes
            // 
            this.outcomes.Location = new System.Drawing.Point(15, 533);
            this.outcomes.Multiline = true;
            this.outcomes.Name = "outcomes";
            this.outcomes.ReadOnly = true;
            this.outcomes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outcomes.Size = new System.Drawing.Size(438, 174);
            this.outcomes.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 517);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Possible Outcomes:";
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(149, 488);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(75, 23);
            this.calculate.TabIndex = 46;
            this.calculate.Text = "Calculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Armor 2 Element 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Armor 2 Element 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Armor 1 Element 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Armor 1 Element 1";
            // 
            // armor2element2
            // 
            this.armor2element2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.armor2element2.FormattingEnabled = true;
            this.armor2element2.Items.AddRange(new object[] {
            "Fire",
            "Spirit",
            "Earth",
            "Air",
            "Water",
            "None"});
            this.armor2element2.Location = new System.Drawing.Point(198, 282);
            this.armor2element2.Name = "armor2element2";
            this.armor2element2.Size = new System.Drawing.Size(90, 21);
            this.armor2element2.TabIndex = 40;
            // 
            // armor2element1
            // 
            this.armor2element1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.armor2element1.FormattingEnabled = true;
            this.armor2element1.Items.AddRange(new object[] {
            "Fire",
            "Spirit",
            "Earth",
            "Air",
            "Water",
            "None"});
            this.armor2element1.Location = new System.Drawing.Point(99, 282);
            this.armor2element1.Name = "armor2element1";
            this.armor2element1.Size = new System.Drawing.Size(93, 21);
            this.armor2element1.TabIndex = 38;
            // 
            // armor1element2
            // 
            this.armor1element2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.armor1element2.FormattingEnabled = true;
            this.armor1element2.Items.AddRange(new object[] {
            "Fire",
            "Spirit",
            "Earth",
            "Air",
            "Water",
            "None"});
            this.armor1element2.Location = new System.Drawing.Point(198, 186);
            this.armor1element2.Name = "armor1element2";
            this.armor1element2.Size = new System.Drawing.Size(90, 21);
            this.armor1element2.TabIndex = 27;
            // 
            // armor1element1
            // 
            this.armor1element1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.armor1element1.FormattingEnabled = true;
            this.armor1element1.Items.AddRange(new object[] {
            "Fire",
            "Spirit",
            "Earth",
            "Air",
            "Water",
            "None"});
            this.armor1element1.Location = new System.Drawing.Point(99, 186);
            this.armor1element1.Name = "armor1element1";
            this.armor1element1.Size = new System.Drawing.Size(93, 21);
            this.armor1element1.TabIndex = 26;
            // 
            // bossDefense
            // 
            this.bossDefense.Location = new System.Drawing.Point(313, 25);
            this.bossDefense.Name = "bossDefense";
            this.bossDefense.Size = new System.Drawing.Size(100, 20);
            this.bossDefense.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(310, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "Boss Defense";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(108, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "Boss Element 2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 53;
            this.label15.Text = "Boss Element 1";
            // 
            // bossElement2
            // 
            this.bossElement2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.bossElement2.FormattingEnabled = true;
            this.bossElement2.Items.AddRange(new object[] {
            "Fire",
            "Spirit",
            "Earth",
            "Air",
            "Water",
            "None"});
            this.bossElement2.Location = new System.Drawing.Point(111, 25);
            this.bossElement2.Name = "bossElement2";
            this.bossElement2.Size = new System.Drawing.Size(90, 21);
            this.bossElement2.TabIndex = 51;
            this.bossElement2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // bossElement1
            // 
            this.bossElement1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.bossElement1.FormattingEnabled = true;
            this.bossElement1.Items.AddRange(new object[] {
            "Fire",
            "Spirit",
            "Earth",
            "Air",
            "Water",
            "None"});
            this.bossElement1.Location = new System.Drawing.Point(12, 25);
            this.bossElement1.Name = "bossElement1";
            this.bossElement1.Size = new System.Drawing.Size(93, 21);
            this.bossElement1.TabIndex = 50;
            this.bossElement1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // bossAttack
            // 
            this.bossAttack.Location = new System.Drawing.Point(207, 25);
            this.bossAttack.Name = "bossAttack";
            this.bossAttack.Size = new System.Drawing.Size(100, 20);
            this.bossAttack.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(204, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Boss Attack";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 61;
            this.label16.Text = "Guild Rank";
            // 
            // guildRank
            // 
            this.guildRank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.guildRank.FormattingEnabled = true;
            this.guildRank.Items.AddRange(new object[] {
            "Commander",
            "High Commander",
            "Champion",
            "Sentinel",
            "Master",
            "None"});
            this.guildRank.Location = new System.Drawing.Point(12, 86);
            this.guildRank.Name = "guildRank";
            this.guildRank.Size = new System.Drawing.Size(93, 21);
            this.guildRank.TabIndex = 60;
            this.guildRank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(108, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 63;
            this.label17.Text = "Air Bonus %";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(188, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 65;
            this.label18.Text = "Earth Bonus %";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 13);
            this.label19.TabIndex = 67;
            this.label19.Text = "Fire Bonus %";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(108, 110);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 13);
            this.label20.TabIndex = 69;
            this.label20.Text = "Spirit Bonus %";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(188, 110);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 13);
            this.label21.TabIndex = 71;
            this.label21.Text = "Water Bonus %";
            // 
            // airBonus
            // 
            this.airBonus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.airBonus.FormattingEnabled = true;
            this.airBonus.Items.AddRange(new object[] {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10});
            this.airBonus.Location = new System.Drawing.Point(111, 86);
            this.airBonus.Name = "airBonus";
            this.airBonus.Size = new System.Drawing.Size(67, 21);
            this.airBonus.TabIndex = 72;
            this.airBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // earthBonus
            // 
            this.earthBonus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.earthBonus.FormattingEnabled = true;
            this.earthBonus.Items.AddRange(new object[] {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10});
            this.earthBonus.Location = new System.Drawing.Point(191, 86);
            this.earthBonus.Name = "earthBonus";
            this.earthBonus.Size = new System.Drawing.Size(67, 21);
            this.earthBonus.TabIndex = 73;
            this.earthBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // fireBonus
            // 
            this.fireBonus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.fireBonus.FormattingEnabled = true;
            this.fireBonus.Items.AddRange(new object[] {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10});
            this.fireBonus.Location = new System.Drawing.Point(15, 126);
            this.fireBonus.Name = "fireBonus";
            this.fireBonus.Size = new System.Drawing.Size(67, 21);
            this.fireBonus.TabIndex = 74;
            this.fireBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // spiritBonus
            // 
            this.spiritBonus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.spiritBonus.FormattingEnabled = true;
            this.spiritBonus.Items.AddRange(new object[] {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10});
            this.spiritBonus.Location = new System.Drawing.Point(111, 126);
            this.spiritBonus.Name = "spiritBonus";
            this.spiritBonus.Size = new System.Drawing.Size(67, 21);
            this.spiritBonus.TabIndex = 75;
            this.spiritBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // waterBonus
            // 
            this.waterBonus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.waterBonus.FormattingEnabled = true;
            this.waterBonus.Items.AddRange(new object[] {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10});
            this.waterBonus.Location = new System.Drawing.Point(191, 126);
            this.waterBonus.Name = "waterBonus";
            this.waterBonus.Size = new System.Drawing.Size(67, 21);
            this.waterBonus.TabIndex = 76;
            this.waterBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // armor3panel
            // 
            this.armor3panel.Controls.Add(this.armor3manual);
            this.armor3panel.Controls.Add(this.armor3auto);
            this.armor3panel.Location = new System.Drawing.Point(15, 376);
            this.armor3panel.Name = "armor3panel";
            this.armor3panel.Size = new System.Drawing.Size(78, 76);
            this.armor3panel.TabIndex = 78;
            // 
            // armor3manual
            // 
            this.armor3manual.AutoSize = true;
            this.armor3manual.Location = new System.Drawing.Point(3, 4);
            this.armor3manual.Name = "armor3manual";
            this.armor3manual.Size = new System.Drawing.Size(60, 17);
            this.armor3manual.TabIndex = 10;
            this.armor3manual.TabStop = true;
            this.armor3manual.Text = "Manual";
            this.armor3manual.UseVisualStyleBackColor = true;
            this.armor3manual.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // armor3auto
            // 
            this.armor3auto.AutoSize = true;
            this.armor3auto.Location = new System.Drawing.Point(3, 51);
            this.armor3auto.Name = "armor3auto";
            this.armor3auto.Size = new System.Drawing.Size(72, 17);
            this.armor3auto.TabIndex = 11;
            this.armor3auto.TabStop = true;
            this.armor3auto.Text = "Automatic";
            this.armor3auto.UseVisualStyleBackColor = true;
            this.armor3auto.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // armor3combo
            // 
            this.armor3combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.armor3combo.FormattingEnabled = true;
            this.armor3combo.Location = new System.Drawing.Point(99, 423);
            this.armor3combo.Name = "armor3combo";
            this.armor3combo.Size = new System.Drawing.Size(189, 21);
            this.armor3combo.TabIndex = 85;
            this.armor3combo.SelectedIndexChanged += new System.EventHandler(this.armor3combo_SelectedIndexChanged);
            this.armor3combo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.armor_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(99, 407);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 13);
            this.label22.TabIndex = 87;
            this.label22.Text = "Armor 3";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(198, 361);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(93, 13);
            this.label25.TabIndex = 79;
            this.label25.Text = "Armor 3 Element 2";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(99, 361);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(93, 13);
            this.label26.TabIndex = 77;
            this.label26.Text = "Armor 3 Element 1";
            // 
            // armor3element2
            // 
            this.armor3element2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.armor3element2.FormattingEnabled = true;
            this.armor3element2.Items.AddRange(new object[] {
            "Fire",
            "Spirit",
            "Earth",
            "Air",
            "Water",
            "None"});
            this.armor3element2.Location = new System.Drawing.Point(198, 377);
            this.armor3element2.Name = "armor3element2";
            this.armor3element2.Size = new System.Drawing.Size(90, 21);
            this.armor3element2.TabIndex = 82;
            // 
            // armor3element1
            // 
            this.armor3element1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.armor3element1.FormattingEnabled = true;
            this.armor3element1.Items.AddRange(new object[] {
            "Fire",
            "Spirit",
            "Earth",
            "Air",
            "Water",
            "None"});
            this.armor3element1.Location = new System.Drawing.Point(99, 377);
            this.armor3element1.Name = "armor3element1";
            this.armor3element1.Size = new System.Drawing.Size(93, 21);
            this.armor3element1.TabIndex = 81;
            // 
            // armor1attack
            // 
            this.armor1attack.Location = new System.Drawing.Point(294, 186);
            this.armor1attack.Name = "armor1attack";
            this.armor1attack.Size = new System.Drawing.Size(100, 20);
            this.armor1attack.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 91;
            this.label3.Text = "Armor 1 Attack";
            // 
            // armor1defense
            // 
            this.armor1defense.Location = new System.Drawing.Point(400, 186);
            this.armor1defense.Name = "armor1defense";
            this.armor1defense.Size = new System.Drawing.Size(100, 20);
            this.armor1defense.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "Armor 1 Defense";
            // 
            // armor2attack
            // 
            this.armor2attack.Location = new System.Drawing.Point(294, 282);
            this.armor2attack.Name = "armor2attack";
            this.armor2attack.Size = new System.Drawing.Size(100, 20);
            this.armor2attack.TabIndex = 94;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 95;
            this.label8.Text = "Armor 2 Attack";
            // 
            // armor2defense
            // 
            this.armor2defense.Location = new System.Drawing.Point(400, 282);
            this.armor2defense.Name = "armor2defense";
            this.armor2defense.Size = new System.Drawing.Size(100, 20);
            this.armor2defense.TabIndex = 92;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(397, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 93;
            this.label9.Text = "Armor 2 Defense";
            // 
            // armor3attack
            // 
            this.armor3attack.Location = new System.Drawing.Point(294, 377);
            this.armor3attack.Name = "armor3attack";
            this.armor3attack.Size = new System.Drawing.Size(100, 20);
            this.armor3attack.TabIndex = 98;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(291, 360);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 13);
            this.label23.TabIndex = 99;
            this.label23.Text = "Armor 3 Attack";
            // 
            // armor3defense
            // 
            this.armor3defense.Location = new System.Drawing.Point(400, 377);
            this.armor3defense.Name = "armor3defense";
            this.armor3defense.Size = new System.Drawing.Size(100, 20);
            this.armor3defense.TabIndex = 96;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(397, 360);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(86, 13);
            this.label24.TabIndex = 97;
            this.label24.Text = "Armor 3 Defense";
            // 
            // bossHealth
            // 
            this.bossHealth.Location = new System.Drawing.Point(419, 25);
            this.bossHealth.Name = "bossHealth";
            this.bossHealth.Size = new System.Drawing.Size(100, 20);
            this.bossHealth.TabIndex = 100;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(416, 8);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 13);
            this.label27.TabIndex = 101;
            this.label27.Text = "Boss Health";
            // 
            // bossLevel
            // 
            this.bossLevel.Location = new System.Drawing.Point(419, 65);
            this.bossLevel.Name = "bossLevel";
            this.bossLevel.Size = new System.Drawing.Size(100, 20);
            this.bossLevel.TabIndex = 102;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(416, 48);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 13);
            this.label28.TabIndex = 103;
            this.label28.Text = "Boss Level";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 718);
            this.Controls.Add(this.bossLevel);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.bossHealth);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.armor3attack);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.armor3defense);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.armor2attack);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.armor2defense);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.armor1attack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.armor1defense);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.armor3panel);
            this.Controls.Add(this.armor3combo);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.armor3element2);
            this.Controls.Add(this.armor3element1);
            this.Controls.Add(this.waterBonus);
            this.Controls.Add(this.spiritBonus);
            this.Controls.Add(this.fireBonus);
            this.Controls.Add(this.earthBonus);
            this.Controls.Add(this.airBonus);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.guildRank);
            this.Controls.Add(this.bossAttack);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.bossDefense);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.bossElement2);
            this.Controls.Add(this.bossElement1);
            this.Controls.Add(this.armor2panel);
            this.Controls.Add(this.armor1panel);
            this.Controls.Add(this.armor2combo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.armor1combo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.outcomes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.armor2element2);
            this.Controls.Add(this.armor2element1);
            this.Controls.Add(this.armor1element2);
            this.Controls.Add(this.armor1element1);
            this.Name = "Form1";
            this.Text = " Epic Boss Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.armor2panel.ResumeLayout(false);
            this.armor2panel.PerformLayout();
            this.armor1panel.ResumeLayout(false);
            this.armor1panel.PerformLayout();
            this.armor3panel.ResumeLayout(false);
            this.armor3panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton armor2auto;
        private System.Windows.Forms.Panel armor2panel;
        private System.Windows.Forms.RadioButton armor2manual;
        private System.Windows.Forms.Panel armor1panel;
        private System.Windows.Forms.RadioButton armor1manual;
        private System.Windows.Forms.RadioButton armor1auto;
        private System.Windows.Forms.ComboBox armor2combo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox armor1combo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox outcomes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox armor2element2;
        private System.Windows.Forms.ComboBox armor2element1;
        private System.Windows.Forms.ComboBox armor1element2;
        private System.Windows.Forms.ComboBox armor1element1;
        private System.Windows.Forms.TextBox bossDefense;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox bossElement2;
        private System.Windows.Forms.ComboBox bossElement1;
        private System.Windows.Forms.TextBox bossAttack;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox guildRank;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox airBonus;
        private System.Windows.Forms.ComboBox earthBonus;
        private System.Windows.Forms.ComboBox fireBonus;
        private System.Windows.Forms.ComboBox spiritBonus;
        private System.Windows.Forms.ComboBox waterBonus;
        private System.Windows.Forms.Panel armor3panel;
        private System.Windows.Forms.RadioButton armor3manual;
        private System.Windows.Forms.RadioButton armor3auto;
        private System.Windows.Forms.ComboBox armor3combo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox armor3element2;
        private System.Windows.Forms.ComboBox armor3element1;
        private System.Windows.Forms.TextBox armor1attack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox armor1defense;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox armor2attack;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox armor2defense;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox armor3attack;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox armor3defense;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox bossHealth;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox bossLevel;
        private System.Windows.Forms.Label label28;

    }
}

