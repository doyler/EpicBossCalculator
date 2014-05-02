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

        //TODO
          //Boss level 1-60, is it required?
          //Elements/etc. from fusion calc
          //player level 1-100, is it required?

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
            // TODO work out player stats level equation
            return maxStats;
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                System.Diagnostics.Debug.WriteLine("Dec: " + (decimal)5.5m);
                System.Diagnostics.Debug.WriteLine("Calc: " + ((decimal)5.5m * (90)));
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
            else if (Convert.ToInt32(bossHealth.Text) < 0 || Convert.ToInt32(bossHealth.Text) > 50000)
            {
                showError("You must enter an appropriate value for the boss's health (accepted values are 0-50000)");
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

        private void armor1combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string armorName = armor1combo.Text.Replace("\'", "\'\'");

                DataRow[] theArmor;
                theArmor = allArmors.Select("Name=\'" + armorName + "\'");

                armor1element1.Text = theArmor[0]["Element1"].ToString();
                if (theArmor[0]["Element2"].ToString() == "0")
                    armor1element2.Text = "None";
                else
                    armor1element2.Text = theArmor[0]["Element2"].ToString();
                armor1attack.Text = ((int)theArmor[0]["Attack"]).ToString();
                armor1defense.Text = ((int)theArmor[0]["Defense"]).ToString();
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        private void armor2combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string armorName = armor2combo.Text.Replace("\'", "\'\'");

                DataRow[] theArmor;
                theArmor = allArmors.Select("Name=\'" + armorName + "\'");

                armor2element1.Text = theArmor[0]["Element1"].ToString();
                if (theArmor[0]["Element2"].ToString() == "0")
                    armor2element2.Text = "None";
                else
                    armor2element2.Text = theArmor[0]["Element2"].ToString();
                armor2attack.Text = ((int)theArmor[0]["Attack"]).ToString();
                armor2defense.Text = ((int)theArmor[0]["Defense"]).ToString();
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }
        private void armor3combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string armorName = armor3combo.Text.Replace("\'", "\'\'");

                DataRow[] theArmor;
                theArmor = allArmors.Select("Name=\'" + armorName + "\'");

                armor3element1.Text = theArmor[0]["Element1"].ToString();
                if (theArmor[0]["Element2"].ToString() == "0")
                    armor3element2.Text = "None";
                else
                    armor3element2.Text = theArmor[0]["Element2"].ToString();
                armor3attack.Text = ((int)theArmor[0]["Attack"]).ToString();
                armor3defense.Text = ((int)theArmor[0]["Defense"]).ToString();
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }
    }
}

/*
namespace KnightsAndDragonsCalculatorApplication.Calculator
{
    public class KnightsAndDragonsCalculator
    {
        public CalculatorResults Calculate(EpicBossRequest request)
        {
            // validation
            string epicBossValidationMessage = GetEpicBossDataValidationMessage(request.EpicBoss);
            if (!string.IsNullOrEmpty(epicBossValidationMessage)) return new CalculatorResults(epicBossValidationMessage);
            string guildValidationMessage = GetGuildDataValidationMessage(request.Guild);
            if (!string.IsNullOrEmpty(guildValidationMessage)) return new CalculatorResults(guildValidationMessage);
            string playerValidationMessage = GetPlayerDataValidationMessage(request.Player);
            if (!string.IsNullOrEmpty(playerValidationMessage)) return new CalculatorResults(playerValidationMessage);

            EpicBossResults epicBoss = GetEpicBossResults(request.EpicBoss, request.Guild, request.Player);

            return new CalculatorResults(epicBoss);
        }

        #region Epic Boss

        private EpicBossResults GetEpicBossResults(EpicBoss epicBoss, Guild guild, Player player)
        {
            EpicBossResults results = new EpicBossResults();
            results.Items = new List<EpicBossResultItem>();

            int playerHealth = GetPlayerHealth(player.Level);
            int playerStats = GetPlayerStats(player.Level);
            int followerHealth = GetFollowerHealth(player.Level);
            int followerStats = GetFollowerStats(player.Level);
            decimal baseAttack = GetBaseAttack(player.Level);
            decimal knightBonus = GetKnightBonus(player.KnightCount);

            foreach (PlayerArmor playerArmor in player.Armors)
            {
                Armor armor = ArmorTable.Instance.GetArmor(playerArmor.ArmorName);

                KeyValuePair<int, int> armorStats = GetArmorStats(armor, playerArmor.Level, playerArmor.IsPlus);
                decimal guildRankBonus = GetGuildRankBonus(guild.RankBonus);
                decimal guildElementBonus = GetGuildElementBonus(armor, guild);
                decimal playerBonus = GetPlayerBonus(epicBoss.Element1, epicBoss.Element2, armor, playerArmor.IsNemesis);
                decimal bossLevelBonus = GetBossLevelBonus(epicBoss.Level);
                decimal bossElementBonus = GetBossElementBonus(epicBoss, armor);

                int playerDamageDone = GetDamageDone(baseAttack, armorStats.Key + playerStats, epicBoss.Defense, guildRankBonus, guildElementBonus, playerBonus, knightBonus);
                int followerDamageDone = GetDamageDone(baseAttack, armorStats.Key + followerStats, epicBoss.Defense, guildRankBonus, guildElementBonus, playerBonus, knightBonus);

                int playerDamageTaken = GetDamageTaken(armorStats.Value + playerStats, epicBoss.Attack, guildRankBonus, guildElementBonus, bossLevelBonus, bossElementBonus);
                int followerDamageTaken = GetDamageTaken(armorStats.Value + followerStats, epicBoss.Attack, guildRankBonus, guildElementBonus, bossLevelBonus, bossElementBonus);

                int playerHitsTaken = (playerHealth / playerDamageTaken) + 1;
                int followerHitsTaken = (followerHealth / followerDamageTaken) + 1;

                results.Items.Add(new EpicBossResultItem(armor.Name, armor.SafeName, playerDamageDone, playerDamageTaken, playerHitsTaken, followerDamageDone, followerDamageTaken, followerHitsTaken));
            }
            results.Items.Sort((x, y) => -1 * x.PlayerTotalDamageDone.CompareTo(y.PlayerTotalDamageDone));

            return results;
        }

        private string GetPlayerDataValidationMessage(Player player)
        {
            if (player == null) return Strings.ErrorPlayerDataNotProvided;
            if (player.Level < 1 || player.Level > 100) return Strings.ErrorInvalidPlayerLevel;
            if (player.KnightCount < 1 || player.KnightCount > 5) return Strings.ErrorInvalidPlayerKnightCount;
            if (player.Armors == null || player.Armors.Count <= 0) return Strings.ErrorPlayerArmorsDataNotProvided;

            foreach (PlayerArmor playerArmor in player.Armors)
            {
                Armor armor = ArmorTable.Instance.GetArmor(playerArmor.ArmorName);
                if (armor == null) return string.Format(Strings.ErrorPlayerArmorNotFound, playerArmor.ArmorName);
                if (playerArmor.Level < 1 || playerArmor.Level > armor.MaxLevel) return string.Format(Strings.ErrorInvalidPlayerArmorLevel, playerArmor.ArmorName, armor.MaxLevel);
                if (playerArmor.IsNemesis && armor.Rarity != Rarity.Nemesis) return string.Format(Strings.ErrorInvalidIsNemesis, playerArmor.ArmorName);
                if ((playerArmor.IsPlus && armor.PlusStats == null) || (!playerArmor.IsPlus && armor.NormalStats == null)) return string.Format(Strings.ErrorArmorStatsNotAvailable, playerArmor.ArmorName);
            }

            return string.Empty;
        }

        private KeyValuePair<int, int> GetArmorStats(Armor armor, int level, bool isPlus)
        {
            int armorAttack = (isPlus) ? armor.GetPlusAttackAt(level) : armor.GetNormalAttackAt(level);
            int armorDefense = (isPlus) ? armor.GetPlusDefenseAt(level) : armor.GetNormalDefenseAt(level);

            return new KeyValuePair<int, int>(armorAttack, armorDefense);
        }

        private decimal GetGuildRankBonus(int rankBonus)
        {
            return 1 + (rankBonus / 100m);
        }

        private decimal GetGuildElementBonus(Armor armor, Guild guild)
        {
            decimal elementBonus = 1;
            if (armor.Element1 != Element.All)
            {
                if (armor.HasElement(Element.Air)) elementBonus += (guild.AirBonus / 100m);
                if (armor.HasElement(Element.Earth)) elementBonus += (guild.EarthBonus / 100m);
                if (armor.HasElement(Element.Fire)) elementBonus += (guild.FireBonus / 100m);
                if (armor.HasElement(Element.Spirit)) elementBonus += (guild.SpiritBonus / 100m);
                if (armor.HasElement(Element.Water)) elementBonus += (guild.WaterBonus / 100m);
            }

            return elementBonus;
        }

        private decimal GetPlayerBonus(Element bossElement1, Element? bossElement2, Armor armor, bool isNemesis)
        {
            if (isNemesis) return 4.5m;
            if (armor.Element1 == Element.All) return 1.5m;
            bool isStrongAgainstElement1 = armor.IsStrongAgainst(bossElement1);
            bool isStrongAgainstElement2 = bossElement2 != null && armor.IsStrongAgainst(bossElement2.Value);
            return 1m + (isStrongAgainstElement1 ? 0.5m : 0m) + (isStrongAgainstElement2 ? 0.5m : 0m);
        }

        private decimal GetKnightBonus(int count)
        {
            return 1 + ((count - 1) * 0.25m);
        }

        private decimal GetBossLevelBonus(int level)
        {
            decimal bossLevel = GetBossLevel(level);
            return (level < 20) ? 3 * (bossLevel + 4) : (1.6m * bossLevel) + 44;
        }

        private decimal GetBossElementBonus(EpicBoss epicBoss, Armor armor)
        {
            decimal elementBonus = 1;
            if (armor.IsWeakAgainst(epicBoss.Element1)) elementBonus += 0.5m;
            if (epicBoss.Element2 != null && armor.IsWeakAgainst(epicBoss.Element2.Value)) elementBonus += 0.5m;

            return elementBonus;
        }

        private decimal GetBossLevel(int level)
        {
            switch (level)
            {
                case 10:
                    return 11.5m;
                case 15:
                    return 18m;
                case 21:
                    return 24m;
                case 28:
                    return 31m;
                case 35:
                    return 39m;
                case 43:
                    return 47m;
                case 51:
                    return 55m;
                case 60:
                    return 67m;
                default:
                    return level;
            }
        }

        private int GetDamageDone(decimal baseAttack, int playerAttack, int bossDefense, decimal guildRankBonus, decimal guildElementBonus, decimal playerBonus, decimal knightBonus)
        {
            int knightStat = GetKnightStat(playerAttack, guildRankBonus, guildElementBonus);
            return (int)Math.Floor(Math.Floor(baseAttack * (knightStat / (decimal)bossDefense) * playerBonus) * knightBonus);
        }

        private decimal GetBaseAttack(int level)
        {
            return (1.6m * level) + 4;
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

        #endregion
    }
}
*/