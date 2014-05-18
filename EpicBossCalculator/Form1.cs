using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpicBossCalculator
{
    public partial class Form1 : Form
    {
        private DataTable allArmors = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private int GetStat(int level, int statMax, decimal statJump)
        {
            if (level >= 30)
            {
                return (int)(statMax - (statJump * (100 - level)));
            }
            else
            {
                return statMax;
            }
        }

        private int GetPlayerHealth(int level)
        {
            return GetStat(level, 607, 5.5m);
        }

        private int GetFollowerHealth(int level)
        {
            return GetStat(level, 455, 4);
        }

        private int GetPlayerStats(int level)
        {
            return GetStat(level, 316, 21);
        }

        private int GetFollowerStats(int level)
        {
            return GetStat(level, 237, 16);
        }

        private decimal GetBaseAttack(int level)
        {
            return (1.6m * level) + 4;
        }

        private decimal GetGuildElementBonus(string element1, string element2)
        {
            decimal elementBonus = 1;

            if (element1 == "Air" || element2 == "Air")
            {
                elementBonus += (Convert.ToInt32(airBonus.Text) / 100m);
            }
            if (element1 == "Earth" || element2 == "Earth")
            {
                elementBonus += (Convert.ToInt32(earthBonus.Text) / 100m);
            }
            if (element1 == "Fire" || element2 == "Fire")
            {
                elementBonus += (Convert.ToInt32(fireBonus.Text) / 100m);
            }
            if (element1 == "Spirit" || element2 == "Spirit")
            {
                elementBonus += (Convert.ToInt32(spiritBonus.Text) / 100m);
            }
            if (element1 == "Water" || element2 == "Water")
            {
                elementBonus += (Convert.ToInt32(waterBonus.Text) / 100m);
            }
            return elementBonus;
        }

        private decimal GetElementalBonus(string element1off, string element2off, string element1def, string element2def, bool isNemesis)
        {
            decimal elementalBonus = 1m;

            if (isNemesis)
            {
                elementalBonus = 4.5m;
            }
            else if (element1off == "Starmetal")
            {
                elementalBonus = 1.5m;
            }
            else
            {
                if (ArmorIsStrongAgainst(element1off, element2off, element1def))
                {
                    elementalBonus += 0.5m;
                }
                if (element2def != "None")
                {
                    if (ArmorIsStrongAgainst(element1off, element2off, element2def))
                    {
                        elementalBonus += 0.5m;
                    }
                }
            }
            return elementalBonus;
        }

        private bool ArmorIsStrongAgainst(string element1off, string element2off, string elementDef)
        {
            switch (elementDef)
            {
                case "Air":
                    return (element1off == "Earth") || (element2off == "Earth") || (element1off == "Starmetal") || (element2off == "Starmetal");
                case "Earth":
                    return (element1off == "Spirit") || (element2off == "Spirit") || (element1off == "Starmetal") || (element2off == "Starmetal");
                case "Fire":
                    return (element1off == "Water") || (element2off == "Water") || (element1off == "Starmetal") || (element2off == "Starmetal");
                case "Spirit":
                    return (element1off == "Fire") || (element2off == "Fire") || (element1off == "Starmetal") || (element2off == "Starmetal");
                case "Water":
                    return (element1off == "Air") || (element2off == "Air") || (element1off == "Starmetal") || (element2off == "Starmetal");
                default:
                    return false;
            }
        }

        private decimal GetBossLevelBonus(int level)
        {
            decimal bossLevel = 0m;
            switch (level)
            {
                case 10:
                    bossLevel = 11.5m;
                    break;
                case 15:
                    bossLevel = 18m;
                    break;
                case 21:
                    bossLevel = 24m;
                    break;
                case 28:
                    bossLevel = 31m;
                    break;
                case 35:
                    bossLevel = 39m;
                    break;
                case 43:
                    bossLevel = 47m;
                    break;
                case 51:
                    bossLevel = 55m;
                    break;
                case 60:
                    bossLevel = 67m;
                    break;
                default:
                    bossLevel = (decimal)level;
                    break;
            }
            return (level < 20) ? 3 * (bossLevel + 4) : (1.6m * bossLevel) + 44;
        }

        //TODO: update and clean this method
        private int GetDamageDone(decimal baseAttack, int playerAttack, int bossDefense, decimal guildRankBonus, decimal guildElementBonus, decimal playerBonus, decimal knightBonus)
        {
            int knightStat = GetKnightStat(playerAttack, guildRankBonus, guildElementBonus);
            return (int)Math.Floor(Math.Floor(baseAttack * (knightStat / (decimal)bossDefense) * playerBonus) * knightBonus);
        }

        private int GetDamageTaken(int playerDefense, int bossAttack, decimal guildRankBonus, decimal guildElementBonus, decimal bossLevelBonus, decimal bossElementBonus)
        {
            int knightStat = GetKnightStat(playerDefense, guildRankBonus, guildElementBonus);
            int damageTaken = (int)Math.Floor(Math.Floor((bossAttack / (decimal)knightStat) * bossLevelBonus) * bossElementBonus);
            return (damageTaken > 0) ? damageTaken : 1;
        }

        public int GetKnightStat(int stat, decimal guildRankBonus, decimal guildElementBonus)
        {
            return (int)Math.Ceiling(Math.Ceiling(stat * guildElementBonus) * guildRankBonus);
        }

        private void setValues()
        {
            bossLevel.Text = "35";
            bossElement1.Text = "Spirit";
            bossElement2.Text = "Air";
            bossAttack.Text = "2116";
            bossDefense.Text = "797";
            bossHealth.Text = "41385";

            guildRank.Text = "Commander";
            airBonus.Text = "10";
            earthBonus.Text = "9";
            fireBonus.Text = "10";
            spiritBonus.Text = "10";
            waterBonus.Text = "10";

            armor1manual.Checked = true;
            //Pestilence
            armor1element1.Text = "Air";
            armor1element2.Text = "Fire";
            armor1attack.Text = "1564";
            armor1defense.Text = "1430";

            armor2manual.Checked = true;
            //Voidborne
            armor2element1.Text = "Fire";
            armor2element2.Text = "Spirit";
            armor2attack.Text = "1610";
            armor2defense.Text = "1263";

            armor3manual.Checked = true;
            //Apocalypse
            armor3element1.Text = "Spirit";
            armor3element2.Text = "Earth";
            armor3attack.Text = "1862";
            armor3defense.Text = "1832";

            results.Text = "";
        }


        private void calculate_Click(object sender, EventArgs e)
        {
            setValues();

            if (ValidateForm())
            {
                int playerHealth = GetPlayerHealth(100);
                int playerStats = GetPlayerStats(100);
                int followerHealth = GetFollowerHealth(100);
                int followerStats = GetFollowerStats(100);
                decimal baseAttack = GetBaseAttack(100);
                decimal knightBonus = 1 + (((Convert.ToInt32(numKnights.Text) + Convert.ToInt32(numFriends.Text)) - 1) * 0.25m);

                decimal guildRankBonus = 1.0m;
                if (guildRank.SelectedIndex == 1)
                {
                    guildRankBonus = 1.05m;
                }
                else if (guildRank.SelectedIndex == 2 || guildRank.SelectedIndex == 3)
                {
                    guildRankBonus = 1.07m;
                }
                else if (guildRank.SelectedIndex == 4)
                {
                    guildRankBonus = 1.10m;
                }

                decimal guildElementBonus = GetGuildElementBonus(armor1element1.Text, armor1element2.Text);
                decimal playerElementBonus = GetElementalBonus(armor1element1.Text, armor1element2.Text, bossElement1.Text, bossElement2.Text, armor1isNemesis.Checked);
                    
                decimal bossLevelBonus = GetBossLevelBonus(Convert.ToInt32(bossLevel.Text));
                decimal bossElementBonus = GetElementalBonus(bossElement1.Text, bossElement2.Text, armor1element1.Text, armor1element2.Text, false);

                int playerDamageDone = GetDamageDone(baseAttack, Convert.ToInt32(armor1attack.Text) + playerStats, Convert.ToInt32(bossDefense.Text), guildRankBonus, guildElementBonus, playerElementBonus, knightBonus);
                int followerDamageDone = GetDamageDone(baseAttack, Convert.ToInt32(armor1attack.Text) + followerStats, Convert.ToInt32(bossDefense.Text), guildRankBonus, guildElementBonus, playerElementBonus, knightBonus);

                int playerDamageTaken = GetDamageTaken(Convert.ToInt32(armor1defense.Text) + playerStats, Convert.ToInt32(bossAttack.Text), guildRankBonus, guildElementBonus, bossLevelBonus, bossElementBonus);
                int followerDamageTaken = GetDamageTaken(Convert.ToInt32(armor1defense.Text) + followerStats, Convert.ToInt32(bossAttack.Text), guildRankBonus, guildElementBonus, bossLevelBonus, bossElementBonus);

                int playerHitsTaken = (playerHealth / playerDamageTaken) + 1;
                int followerHitsTaken = (followerHealth / followerDamageTaken) + 1;

                results.Text += String.Format("Boss level {0}, {1}/{2}, {3}/{4}", bossLevel.Text, bossElement1.Text, bossElement2.Text, bossAttack.Text, bossDefense.Text);
                results.Text += "\r\n";
                results.Text += String.Format("Level {0} {1}", 100, guildRank.Text);
                results.Text += "\r\n";
                results.Text += String.Format("Level {0} {1}", 99, armor1combo.Text);
                results.Text += "\r\n";
                results.Text += String.Format("Player: {0} damage done, {1} damage taken, {2} hits taken, {3} total damage done", playerDamageDone, playerDamageTaken, playerHitsTaken, (playerHitsTaken - 1) * playerDamageDone);
                results.Text += "\r\n";
                results.Text += String.Format("Follower: {0} damage done, {1} damage taken, {2} hits taken, {3} total damage done", followerDamageDone, followerDamageTaken, followerHitsTaken, (followerHitsTaken - 1) * followerDamageDone);
            }
        }

        private DataTable CsvToDataTable(string strFileName)
        {
            DataTable dataTable = new DataTable("DataTable Name");
            string fullPath = Path.GetDirectoryName("..\\..\\" + strFileName);

            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + fullPath + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\""))
            {
                conn.Open();
                string strQuery = "SELECT * FROM [" + strFileName + "]";
                OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        private bool ValidateForm()
        {
            if (bossElement1.Text == "")
            {
                ShowError("You must select an element 1 for the boss");
                return false;
            }
            else if (bossElement2.Text == "")
            {
                ShowError("You must select an element 2 for the boss (select none for mono-element)");
                return false;
            }
            else if (!Regex.IsMatch(bossAttack.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for the boss's attack");
                return false;
            }
            else if (Convert.ToInt32(bossAttack.Text) < 0 || Convert.ToInt32(bossAttack.Text) > 5000)
            {
                ShowError("You must enter an appropriate value for the boss's attack (accepted values are 0-5000)");
                return false;
            }
            else if (!Regex.IsMatch(bossDefense.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for the boss's defense");
                return false;
            }
            else if (Convert.ToInt32(bossDefense.Text) < 0 || Convert.ToInt32(bossDefense.Text) > 5000)
            {
                ShowError("You must enter an appropriate value for the boss's defense (accepted values are 0-5000)");
                return false;
            }
            else if (!Regex.IsMatch(bossHealth.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for the boss's health");
                return false;
            }
            else if (Convert.ToInt32(bossHealth.Text) < 1 || Convert.ToInt32(bossHealth.Text) > 50000)
            {
                ShowError("You must enter an appropriate value for the boss's health (accepted values are 1-50000)");
                return false;
            }
            else if (!Regex.IsMatch(bossLevel.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for the boss's level");
                return false;
            }
            else if (Convert.ToInt32(bossLevel.Text) < 1 || Convert.ToInt32(bossLevel.Text) > 60)
            {
                ShowError("You must enter an appropriate value for the boss's level (accepted values are 1-60)");
                return false;
            }
            else if (guildRank.Text == "")
            {
                ShowError("You must select a guild rank (select none if not in a guild)");
                return false;
            }
            else if (airBonus.Text == "")
            {
                ShowError("You must select an air bonus % (select none if not in a guild)");
                return false;
            }
            else if (earthBonus.Text == "")
            {
                ShowError("You must select an earth bonus % (select none if not in a guild)");
                return false;
            }
            else if (fireBonus.Text == "")
            {
                ShowError("You must select an fire bonus % (select none if not in a guild)");
                return false;
            }
            else if (spiritBonus.Text == "")
            {
                ShowError("You must select an spirit bonus % (select none if not in a guild)");
                return false;
            }
            else if (waterBonus.Text == "")
            {
                ShowError("You must select an water bonus % (select none if not in a guild)");
                return false;
            }
            if (armor1element1.Text == "")
            {
                ShowError("You must select an element 1 for armor 1");
                return false;
            }
            else if (armor1element2.Text == "")
            {
                ShowError("You must select an element 2 for armor 1 (select none for mono-element)");
                return false;
            }
            else if (armor2element1.Text == "")
            {
                ShowError("You must select an element 1 for armor 2");
                return false;
            }
            else if (armor2element2.Text == "")
            {
                ShowError("You must select an element 2 for armor 2 (select none for mono-element)");
                return false;
            }
            else if (armor3element1.Text == "")
            {
                ShowError("You must select an element 1 for armor 3");
                return false;
            }
            else if (armor3element2.Text == "")
            {
                ShowError("You must select an element 2 for armor 3 (select none for mono-element)");
                return false;
            }
            else if (armor1element1.Text == armor1element2.Text)
            {
                ShowError("Armor 1 cannot have 2 of the same element.");
                return false;
            }
            else if (armor2element1.Text == armor2element2.Text)
            {
                ShowError("Armor 2 cannot have 2 of the same element.");
                return false;
            }
            else if (armor3element1.Text == armor3element2.Text)
            {
                ShowError("Armor 3 cannot have 2 of the same element.");
                return false;
            }
            else if (!Regex.IsMatch(armor1attack.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for armor 1's attack");
                return false;
            }
            else if (Convert.ToInt32(armor1attack.Text) < 0 || Convert.ToInt32(armor1attack.Text) > 2500)
            {
                ShowError("You must enter an appropriate value for armor 1's attack (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor1defense.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for armor 1's defense");
                return false;
            }
            else if (Convert.ToInt32(armor1defense.Text) < 0 || Convert.ToInt32(armor1defense.Text) > 2500)
            {
                ShowError("You must enter an appropriate value for armor 1's defense (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor2attack.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for armor 2's attack");
                return false;
            }
            else if (Convert.ToInt32(armor2attack.Text) < 0 || Convert.ToInt32(armor2attack.Text) > 2500)
            {
                ShowError("You must enter an appropriate value for armor 2's attack (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor2defense.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for armor 2's defense");
                return false;
            }
            else if (Convert.ToInt32(armor2defense.Text) < 0 || Convert.ToInt32(armor2defense.Text) > 2500)
            {
                ShowError("You must enter an appropriate value for armor 2's defense (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor3attack.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for armor 3's attack");
                return false;
            }
            else if (Convert.ToInt32(armor3attack.Text) < 0 || Convert.ToInt32(armor3attack.Text) > 2500)
            {
                ShowError("You must enter an appropriate value for armor 3's attack (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor3defense.Text, @"^\d+$"))
            {
                ShowError("You must enter in an integer value for armor 3's defense");
                return false;
            }
            else if (Convert.ToInt32(armor3defense.Text) < 0 || Convert.ToInt32(armor3defense.Text) > 2500)
            {
                ShowError("You must enter an appropriate value for armor 3's defense (accepted values are 0-2500)");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            if (armor1manual.Checked)
            {
                armor1combo.Enabled = false;

                armor1element1.Enabled = true;
                armor1element2.Enabled = true;
                armor1attack.Enabled = true;
                armor1defense.Enabled = true;
            }
            else if (armor1auto.Checked)
            {
                armor1combo.Enabled = true;

                armor1element1.Enabled = false;
                armor1element2.Enabled = false;
                armor1attack.Enabled = false;
                armor1defense.Enabled = false;
            }
            if (armor2manual.Checked)
            {
                armor2combo.Enabled = false;

                armor2element1.Enabled = true;
                armor2element2.Enabled = true;
                armor2attack.Enabled = true;
                armor2defense.Enabled = true;
            }
            else if (armor2auto.Checked)
            {
                armor2combo.Enabled = true;

                armor2element1.Enabled = false;
                armor2element2.Enabled = false;
                armor2attack.Enabled = false;
                armor2defense.Enabled = false;
            }
            if (armor3manual.Checked)
            {
                armor3combo.Enabled = false;

                armor3element1.Enabled = true;
                armor3element2.Enabled = true;
                armor3attack.Enabled = true;
                armor3defense.Enabled = true;
            }
            else if (armor3auto.Checked)
            {
                armor3combo.Enabled = true;

                armor3element1.Enabled = false;
                armor3element2.Enabled = false;
                armor3attack.Enabled = false;
                armor3defense.Enabled = false;
            }
        }

        private void ShowError(string theError)
        {
            MessageBox.Show(theError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public static IEnumerable<Control> GetAllControls(Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);

            while (stack.Any())
            {
                var next = stack.Pop();
                foreach (Control child in next.Controls)
                    stack.Push(child);
                yield return next;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            armor1combo.SelectedIndexChanged += ArmorSelectedIndexChanged;
            armor2combo.SelectedIndexChanged += ArmorSelectedIndexChanged;
            armor3combo.SelectedIndexChanged += ArmorSelectedIndexChanged;

            var comboBoxes = GetAllControls(this).OfType<ComboBox>();
            foreach (ComboBox cb in comboBoxes)
            {
                cb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboKeyPress);
            }

            armor1manual.Checked = true;
            armor2manual.Checked = true;
            armor3manual.Checked = true;

            allArmors = CsvToDataTable("armors.csv");

            foreach (DataRow row in allArmors.Rows)
            {
                string name = row["Name"].ToString();

                armor1combo.Items.Add(name);
                armor2combo.Items.Add(name);
                armor3combo.Items.Add(name);
            }
        }

        public virtual void ComboKeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.DroppedDown = true;
            string strFindStr = "";
            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }
            int intIdx = -1;
            // Search the string in the ComboBox list.
            intIdx = cb.FindString(strFindStr);
            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void ArmorSelectedIndexChanged(object sender, EventArgs e)
        {
            string armorNum = ((ComboBox)sender).Tag.ToString();
            try
            {
                string armorName = ((ComboBox)sender).Text.Replace("\'", "\'\'");

                DataRow[] theArmor;
                theArmor = allArmors.Select("Name=\'" + armorName + "\'");

                ((ComboBox)tabControl1.Controls[2].Controls.Find("armor" + armorNum + "element1", false)[0]).Text = theArmor[0]["Element1"].ToString();
                if (theArmor[0]["Element2"].ToString() == "0")
                    ((ComboBox)tabControl1.Controls[2].Controls.Find("armor" + armorNum + "element2", false)[0]).Text = "None";
                else
                    ((ComboBox)tabControl1.Controls[2].Controls.Find("armor" + armorNum + "element2", false)[0]).Text = theArmor[0]["Element2"].ToString();
                ((TextBox)tabControl1.Controls[2].Controls.Find("armor" + armorNum + "attack", false)[0]).Text = ((int)theArmor[0]["Attack"]).ToString();
                ((TextBox)tabControl1.Controls[2].Controls.Find("armor" + armorNum + "defense", false)[0]).Text = ((int)theArmor[0]["Defense"]).ToString();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}

/*
health jumps
-------------
1 -> 10 = 72
10 -> 20 = 60
20 -> 30 = 60
30 -> 40 = 55
...
90 -> 100 = 55


stat jumps
----------
1 -> 10 = 62
10 -> 20 = 39
20 -> 30 = 38
30 -> 40 = 21
...
90 -> 100 = 21


follow health jumps
--------------------
1 -> 10 = 77
10 -> 20 = 45
20 -> 30 = 45
30 -> 40 = 41
...
90 -> 100 = 41


follow stat jumps
------------------
1 -> 10 = 69
10 -> 20 = 29
20 -> 30 = 29
30 -> 40 = 16
...
90 -> 100 = 16
*/