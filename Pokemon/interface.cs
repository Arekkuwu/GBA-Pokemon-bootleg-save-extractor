using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon
{
    public partial class Software : Form
    {
        public Software()
        {
            InitializeComponent();
        }

        private void CheckedListBox_Games_ItemCheck(object sender, ItemCheckEventArgs e) // Make sure only one game can be selected at a time
        {
            for (int i = 0; i < checkedListBox_Games.Items.Count; ++i)
                if (i != e.Index) { checkedListBox_Games.SetItemChecked(i, false); }
            label_adress.Text = "";
        }

        private string Determine_selected_game() // Read the name of selected game
        {
            string s = "Default";

            for (int i = 0; i <= (checkedListBox_Games.Items.Count - 1); i++)
                if (checkedListBox_Games.GetItemChecked(i)) { s = checkedListBox_Games.Items[i].ToString(); }

            return s;
        }

        private bool Game_selected_null() // Tell if a game is selected
        {
            bool selected = false;

            if(Determine_selected_game() == "Default")
            {
                selected = true;
                label_path.Text = "ERROR 02: NO GAME SELECTED";
            }

            return selected;
        }

        private byte[] Create_stuffing(int size) // Create stuffing byte
        {
            byte[] stuffing = new byte[size];

            for (int i = 0; i < size; i++) { stuffing[i] = 255; }
            return stuffing;
        }

        OpenFileDialog FD_select_rom = new OpenFileDialog(); 

        private void Button_Load_Rom_Click(object sender, EventArgs e) // When Load Rom button is clicked
        {
            label_path.Text   = "";
            label_adress.Text = "";
            if (Game_selected_null()) { return; }                           // Verify if a game is selected in CheckedBoxList_Games
            FD_select_rom.Filter = "gba rom (*.gba)|*.gba";                 // Restrict file choice to .gba

            // Open a Dialog Window to obtain the ROM
            if (FD_select_rom.ShowDialog() != DialogResult.OK) { return; } // If the file is a gba file

            string Save_Path = FD_select_rom.FileName;          // Obtain the ROM's path
            Save_Path = Save_Path.Remove(Save_Path.Length - 3); // Remove the extension from tha path (gba)
            
            BinaryReader Reader = new BinaryReader(File.OpenRead(FD_select_rom.FileName)); // Start a read of the file
            int rom_size = unchecked((int)Reader.BaseStream.Length);                       // Determine the ROM size 

            // Determine if it is a 16Mo or 32Mo ROM
            if (rom_size == 33554432) { rom_size = 0x01FFFFE0 + 0x18; }     // 32Mo
            else
            {
                if (rom_size == 16777216) { rom_size = 0x00FFFFE0 + 0x18; } // 16Mo
                else
                {
                    label_path.Text = "ERROR 01: BAD DUMP !";               // Else verify your dump
                    return;
                }
            }

            int rom_save_adress_end = Get_rom_save_adress_end(Reader, rom_size); // Determines the ROM's address of the last save's byte
            string game = Determine_selected_game();

            switch (game) // Depending on the game
            {
                case "Emerald":
                    byte[] save_start_FF = Create_stuffing(57344);

                    byte[] save_end_00 = Create_stuffing(16384);

                    Reader.BaseStream.Position = (rom_save_adress_end - 57343);
                    byte[] rom_emerald_save = Reader.ReadBytes(57344);
                    Reader.Close();

                    byte[] emerald_save = new byte[save_start_FF.Length + rom_emerald_save.Length + save_end_00.Length];
                    System.Buffer.BlockCopy(save_start_FF, 0, emerald_save, 0, save_start_FF.Length);
                    System.Buffer.BlockCopy(rom_emerald_save, 0, emerald_save, save_start_FF.Length, rom_emerald_save.Length);
                    System.Buffer.BlockCopy(save_end_00, 0, emerald_save, save_start_FF.Length + rom_emerald_save.Length, save_end_00.Length);

                    SaveData(Save_Path, emerald_save);
                    break;

                case "FireRed":
                    Reader.BaseStream.Position = (rom_save_adress_end - 114687); // 24379392

                    byte[] rom_frrd_save = Reader.ReadBytes(114688);

                    Reader.Close();

                    byte[] save_end_FF = Create_stuffing(16384);

                    byte[] frrd_save = new byte[rom_frrd_save.Length + save_end_FF.Length];
                    System.Buffer.BlockCopy(rom_frrd_save, 0, frrd_save, 0, rom_frrd_save.Length);
                    System.Buffer.BlockCopy(save_end_FF, 0, frrd_save, rom_frrd_save.Length, save_end_FF.Length);

                    SaveData(Save_Path, frrd_save);
                    break;

                default:
                    label_path.Text = "ERROR 03: GAME SELECTED NOT KNOWN";
                    break;
            } // END OF switch (game)
        }         // END OF Button_Load_Rom_Click

        private int Get_rom_save_adress_end(BinaryReader m_br, int m_rom_size)
        {
            int end_adress = 0;
            bool not_found = true;

            for (int address_tested = m_rom_size; address_tested >= 0x0000020; address_tested -= 0x20)
            {
                m_br.BaseStream.Position = address_tested;
                byte[] codon_byte = m_br.ReadBytes(4);
                string codon = codon_byte[0].ToString() + codon_byte[1].ToString() + codon_byte[2].ToString() + codon_byte[3].ToString();

                if (codon == "373218")
                {
                    end_adress = address_tested + 0x07;
                    address_tested = 0x0000000;
                    label_adress.Text = "Save found ! end at @0" + end_adress.ToString("x").ToUpper(); ;   
                    not_found = false;
                }
            }

            if(not_found) { label_path.Text = "NO SAVE FOUND !"; }

            return end_adress;
        } // END OF Get_rom_save_adress_end

        protected bool SaveData(string m_Save_Path, byte[] Data)
        {
            BinaryWriter Writer; // = null;
            m_Save_Path += "sav"; // Add the extension for the save file

            try
            {
                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(m_Save_Path));

                // Writer raw data                
                Writer.Write(Data);
                label_selected_game.Text = "Save file located at :";
                label_path.Text = m_Save_Path;
                Writer.Flush();
                Writer.Close();
            }
            catch { return false; }
            
            return true;
        } // END OF SAVEDATA

    }
}