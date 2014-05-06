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

        private int getPlayerHealth(int level)
        {
            return getHealth(level, 607, 5.5m);
        }

        private int getFollowerHealth(int level)
        {
            return getHealth(level, 455, 4);
        }

        private int getHealth(int level, int maxHealth, decimal jump)
        {
            //TODO: this formula isn't right
            //TODO: combine the health and stats formulas?
            return (int)(maxHealth - (jump * (100 - level)));
        }

        private int getPlayerStats(int level)
        {
            return getStats(level, 316);
        }

        private int getFollowerStats(int level)
        {
            return getStats(level, 237);
        }

        private int getStats(int level, int maxStats)
        {
            //TODO: work out player stats level equation
            return maxStats;
        }

        private decimal getBaseAttack(int level)
        {
            //TODO: what is this about?
            return (1.6m * level) + 4;
        }

        private decimal getGuildElementBonus(string element1, string element2)
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

        public bool armorIsStrongAgainst(string element1off, string element2off, string elementDef)
        {
            switch (elementDef)
            {
                case "Air":
                    return (element1off == "Earth") || (element2off == "Earth");
                case "Earth":
                    return (element1off == "Spirit") || (element2off == "Spirit");
                case "Fire":
                    return (element1off == "Water") || (element2off == "Water");
                case "Spirit":
                    return (element1off == "Fire") || (element2off == "Fire");
                case "Water":
                    return (element1off == "Air") || (element2off == "Air");
                default:
                    return false;
            }
        }

        private decimal getBossLevelBonus(int level)
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
            //TODO: clean this up any? for now it is fine though
            return (level < 20) ? 3 * (bossLevel + 4) : (1.6m * bossLevel) + 44;
        }

        //TODO: update and clean this method
        private int getDamageDone(decimal baseAttack, int playerAttack, int bossDefense, decimal guildRankBonus, decimal guildElementBonus, decimal playerBonus, decimal knightBonus)
        {
            int knightStat = getKnightStat(playerAttack, guildRankBonus, guildElementBonus);
            return (int)Math.Floor(Math.Floor(baseAttack * (knightStat / (decimal)bossDefense) * playerBonus) * knightBonus);
        }

        private int getDamageTaken(int playerDefense, int bossAttack, decimal guildRankBonus, decimal guildElementBonus, decimal bossLevelBonus, decimal bossElementBonus)
        {
            int knightStat = getKnightStat(playerDefense, guildRankBonus, guildElementBonus);
            int damageTaken = (int)Math.Floor(Math.Floor((bossAttack / (decimal)knightStat) * bossLevelBonus) * bossElementBonus);
            return (damageTaken > 0) ? damageTaken : 1;
        }

        public int getKnightStat(int stat, decimal guildRankBonus, decimal guildElementBonus)
        {
            return (int)Math.Ceiling(Math.Ceiling(stat * guildElementBonus) * guildRankBonus);
        }


        private void calculate_Click(object sender, EventArgs e)
        {
            bossLevel.Text = "46";
            bossElement1.Text = "Fire";
            bossElement2.Text = "Earth";
            bossAttack.Text = "2203";
            bossDefense.Text = "789";
            bossHealth.Text = "41633";
            
            guildRank.Text = "Commander";
            airBonus.Text = "10";
            earthBonus.Text = "9";
            fireBonus.Text = "10";
            spiritBonus.Text = "9";
            waterBonus.Text = "10";

            armor1manual.Checked = true;
            //Nathair+
            armor1element1.Text = "Earth";
            armor1element2.Text = "Water";
            armor1attack.Text = "1432";
            armor1defense.Text = "1437";

            armor2auto.Checked = true;
            armor2combo.Text = "Northerner's Battlegear";

            armor3manual.Checked = true;
            //Revelation
            armor3element1.Text = "Water";
            armor3element2.Text = "Spirit";
            armor3attack.Text = "1802";
            armor3defense.Text = "1892";


            if (validateForm())
            {
                int playerHealth = getPlayerHealth(100);
                int playerStats = getPlayerStats(100);
                int followerHealth = getFollowerHealth(100);
                int followerStats = getFollowerStats(100);
                decimal baseAttack = getBaseAttack(100);
                decimal knightBonus = 1 + ((5 - 1) * 0.25m); //5 is the knight count from UI

                decimal guildRankBonus = 1.0m;
                if (guildRank.SelectedIndex == 1)
                {
                    guildRankBonus = 1.05m;
                }
                else if (guildRank.SelectedIndex == 2)
                {
                    guildRankBonus = 1.07m;
                }
                else if (guildRank.SelectedIndex == 3)
                {
                    guildRankBonus = 1.07m;
                }
                else if (guildRank.SelectedIndex == 4)
                {
                    guildRankBonus = 1.10m;
                }

                //TODO: loop through the armors here when it's a variable amount
                decimal guildElementBonus = getGuildElementBonus(armor1element1.Text, armor1element2.Text);

                //TODO: this needs to be separate for multiple armors, and cleaner
                decimal playerElementBonus = 1m;
                if (armorIsStrongAgainst(armor1element1.Text, armor1element2.Text, bossElement1.Text))
                {
                    playerElementBonus += 0.5m;
                }
                if (bossElement2.Text != "None")
                {
                    if (armorIsStrongAgainst(armor1element1.Text, armor1element2.Text, bossElement2.Text))
                    {
                        playerElementBonus += 0.5m;
                    }
                }

                decimal bossLevelBonus = getBossLevelBonus(Convert.ToInt32(bossLevel.Text));

                //TODO: same as player bonus, clean and separate
                decimal bossElementBonus = 1m;
                if (armorIsStrongAgainst(bossElement1.Text, bossElement2.Text, armor1element1.Text))
                {
                    bossElementBonus += 0.5m;
                }
                if (armor1element2.Text != "None")
                {
                    if (armorIsStrongAgainst(bossElement1.Text, bossElement2.Text, armor1element2.Text))
                    {
                        bossElementBonus += 0.5m;
                    }
                }

                int playerDamageDone = getDamageDone(baseAttack, Convert.ToInt32(armor1attack.Text) + playerStats, Convert.ToInt32(bossDefense.Text), guildRankBonus, guildElementBonus, playerElementBonus, knightBonus);
                int followerDamageDone = getDamageDone(baseAttack, Convert.ToInt32(armor1attack.Text) + followerStats, Convert.ToInt32(bossDefense.Text), guildRankBonus, guildElementBonus, playerElementBonus, knightBonus);

                int playerDamageTaken = getDamageTaken(Convert.ToInt32(armor1defense.Text) + playerStats, Convert.ToInt32(bossAttack.Text), guildRankBonus, guildElementBonus, bossLevelBonus, bossElementBonus);
                int followerDamageTaken = getDamageTaken(Convert.ToInt32(armor1defense.Text) + followerStats, Convert.ToInt32(bossAttack.Text), guildRankBonus, guildElementBonus, bossLevelBonus, bossElementBonus);

                int playerHitsTaken = (playerHealth / playerDamageTaken) + 1;
                int followerHitsTaken = (followerHealth / followerDamageTaken) + 1;

                System.Diagnostics.Debug.WriteLine(String.Format("Boss level {0}, {1}/{2}, {3}/{4}", bossLevel.Text, bossElement1.Text, bossElement2.Text, bossAttack.Text, bossDefense.Text));
                System.Diagnostics.Debug.WriteLine(String.Format("Level {0} {1} with {2}% in all bonuses", 100, guildRank.Text, airBonus.Text));
                System.Diagnostics.Debug.WriteLine(String.Format("Level {0} {1}", 99, armor1combo.Text));
                System.Diagnostics.Debug.WriteLine(String.Format("Player: {0} damage done, {1} damage taken, {2} hits taken, {3} total damage done", playerDamageDone, playerDamageTaken, playerHitsTaken, (playerHitsTaken - 1) * playerDamageDone));
                System.Diagnostics.Debug.WriteLine(String.Format("Follower: {0} damage done, {1} damage taken, {2} hits taken, {3} total damage done", followerDamageDone, followerDamageTaken, followerHitsTaken, (followerHitsTaken - 1) * followerDamageDone));

                /*
                 * KADC OUTPUT
                 * ------------
                 * Boss level 20, Fire/Earth, 1500/1500, (23697 hp???)
                 * Level 100 Commander with 10% in all bonuses
                 * Level 99 Northerner's
                 * Player: 400 damage done, 61 damage taken, 10 hits taken, 3600 total damage done
                 * Follower: 386 damage done, 64 damage taken, 8 hits taken, 2702 total damage done
                 */

                /*
                 * PROGRAM OUTPUT
                 * ---------------
                 * Level 100 Commander with 10% in all bonuses
                 * Level 99 Northerner's Battlegear
                 * Player: 400 damage done, 61 damage taken, 10 hits taken, 3600 total damage done
                 * Follower: 386 damage done, 64 damage taken, 8 hits taken, 2702 total damage done
                 */

                /*
                 * Program
                 * --------
                 * Vs lvl 46
                 * 
                 * Nathair - 735 diff (1238/129) - actual = 1238/129
                 * --------
                 * Player: 648 damage done, 124 damage taken, 5 hits taken, 2592 total damage done
                 * Follower: 619 damage done, 129 damage taken, 4 hits taken, 1857 total damage done
                 * 
                 * Northerner's - 842 diff (1468/147) - actual = 1468/147
                 * -------------
                 * Player: 761 damage done, 140 damage taken, 5 hits taken, 3044 total damage done
                 * Follower: 734 damage done, 147 damage taken, 4 hits taken, 2202 total damage done
                 * 
                 * Revelation - 2176 diff (2096/147) - actual = 2096/147
                 * -----------
                 * Player: 1048 damage done, 147 damage taken, 5 hits taken, 4192 total damage done
                 * Follower: 1008 damage done, 153 damage taken, 3 hits taken, 2016 total damage done
                 */
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

        private bool validateForm()
        {
            if (bossElement1.Text == "")
            {
                showError("You must select an element 1 for the boss");
                return false;
            }
            else if (bossElement2.Text == "")
            {
                showError("You must select an element 2 for the boss (select none for mono-element)");
                return false;
            }
            else if (!Regex.IsMatch(bossAttack.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for the boss's attack");
                return false;
            }
            else if (Convert.ToInt32(bossAttack.Text) < 0 || Convert.ToInt32(bossAttack.Text) > 5000)
            {
                showError("You must enter an appropriate value for the boss's attack (accepted values are 0-5000)");
                return false;
            }
            else if (!Regex.IsMatch(bossDefense.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for the boss's defense");
                return false;
            }
            else if (Convert.ToInt32(bossDefense.Text) < 0 || Convert.ToInt32(bossDefense.Text) > 5000)
            {
                showError("You must enter an appropriate value for the boss's defense (accepted values are 0-5000)");
                return false;
            }
            else if (!Regex.IsMatch(bossHealth.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for the boss's health");
                return false;
            }
            else if (Convert.ToInt32(bossHealth.Text) < 1 || Convert.ToInt32(bossHealth.Text) > 50000)
            {
                showError("You must enter an appropriate value for the boss's health (accepted values are 1-50000)");
                return false;
            }
            else if (!Regex.IsMatch(bossLevel.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for the boss's level");
                return false;
            }
            else if (Convert.ToInt32(bossLevel.Text) < 1 || Convert.ToInt32(bossLevel.Text) > 60)
            {
                showError("You must enter an appropriate value for the boss's level (accepted values are 1-60)");
                return false;
            }
            else if (guildRank.Text == "")
            {
                showError("You must select a guild rank (select none if not in a guild)");
                return false;
            }
            else if (airBonus.Text == "")
            {
                showError("You must select an air bonus % (select none if not in a guild)");
                return false;
            }
            else if (earthBonus.Text == "")
            {
                showError("You must select an earth bonus % (select none if not in a guild)");
                return false;
            }
            else if (fireBonus.Text == "")
            {
                showError("You must select an fire bonus % (select none if not in a guild)");
                return false;
            }
            else if (spiritBonus.Text == "")
            {
                showError("You must select an spirit bonus % (select none if not in a guild)");
                return false;
            }
            else if (waterBonus.Text == "")
            {
                showError("You must select an water bonus % (select none if not in a guild)");
                return false;
            }
            if (armor1element1.Text == "")
            {
                showError("You must select an element 1 for armor 1");
                return false;
            }
            else if (armor1element2.Text == "")
            {
                showError("You must select an element 2 for armor 1 (select none for mono-element)");
                return false;
            }
            else if (armor2element1.Text == "")
            {
                showError("You must select an element 1 for armor 2");
                return false;
            }
            else if (armor2element2.Text == "")
            {
                showError("You must select an element 2 for armor 2 (select none for mono-element)");
                return false;
            }
            else if (armor3element1.Text == "")
            {
                showError("You must select an element 1 for armor 3");
                return false;
            }
            else if (armor3element2.Text == "")
            {
                showError("You must select an element 2 for armor 3 (select none for mono-element)");
                return false;
            }
            else if (armor1element1.Text == armor1element2.Text)
            {
                showError("Armor 1 cannot have 2 of the same element.");
                return false;
            }
            else if (armor2element1.Text == armor2element2.Text)
            {
                showError("Armor 2 cannot have 2 of the same element.");
                return false;
            }
            else if (armor3element1.Text == armor3element2.Text)
            {
                showError("Armor 3 cannot have 2 of the same element.");
                return false;
            }
            else if (!Regex.IsMatch(armor1attack.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for armor 1's attack");
                return false;
            }
            else if (Convert.ToInt32(armor1attack.Text) < 0 || Convert.ToInt32(armor1attack.Text) > 2500)
            {
                showError("You must enter an appropriate value for armor 1's attack (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor1defense.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for armor 1's defense");
                return false;
            }
            else if (Convert.ToInt32(armor1defense.Text) < 0 || Convert.ToInt32(armor1defense.Text) > 2500)
            {
                showError("You must enter an appropriate value for armor 1's defense (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor2attack.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for armor 2's attack");
                return false;
            }
            else if (Convert.ToInt32(armor2attack.Text) < 0 || Convert.ToInt32(armor2attack.Text) > 2500)
            {
                showError("You must enter an appropriate value for armor 2's attack (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor2defense.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for armor 2's defense");
                return false;
            }
            else if (Convert.ToInt32(armor2defense.Text) < 0 || Convert.ToInt32(armor2defense.Text) > 2500)
            {
                showError("You must enter an appropriate value for armor 2's defense (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor3attack.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for armor 3's attack");
                return false;
            }
            else if (Convert.ToInt32(armor3attack.Text) < 0 || Convert.ToInt32(armor3attack.Text) > 2500)
            {
                showError("You must enter an appropriate value for armor 3's attack (accepted values are 0-2500)");
                return false;
            }
            else if (!Regex.IsMatch(armor3defense.Text, @"^\d+$"))
            {
                showError("You must enter in an integer value for armor 3's defense");
                return false;
            }
            else if (Convert.ToInt32(armor3defense.Text) < 0 || Convert.ToInt32(armor3defense.Text) > 2500)
            {
                showError("You must enter an appropriate value for armor 3's defense (accepted values are 0-2500)");
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

        private void showError(string theError)
        {
            MessageBox.Show(theError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        public virtual void armor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void armorSelectedIndexChanged(object sender, EventArgs e, int armorNum)
        {
            try
            {
                string armorName = ((ComboBox)sender).Text.Replace("\'", "\'\'");

                DataRow[] theArmor;
                theArmor = allArmors.Select("Name=\'" + armorName + "\'");

                ((ComboBox)this.Controls.Find("armor" + armorNum + "element1", false)[0]).Text = theArmor[0]["Element1"].ToString();
                if (theArmor[0]["Element2"].ToString() == "0")
                    ((ComboBox)this.Controls.Find("armor" + armorNum + "element2", false)[0]).Text = "None";
                else
                    ((ComboBox)this.Controls.Find("armor" + armorNum + "element2", false)[0]).Text = theArmor[0]["Element2"].ToString();
                ((TextBox)this.Controls.Find("armor" + armorNum + "attack", false)[0]).Text = ((int)theArmor[0]["Attack"]).ToString();
                ((TextBox)this.Controls.Find("armor" + armorNum + "defense", false)[0]).Text = ((int)theArmor[0]["Defense"]).ToString();
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }
    }
}

/*
(knight health ignoring level 1 - (r) = .99989)
y=51.333333333333+5.5757575757576x


10,92
20,131
30,169
40,190
50,211
60,232
70,253
80,274
90,295
100,316





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