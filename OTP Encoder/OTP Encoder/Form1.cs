using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace OTP_Encoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Encrypt_File_Click(object sender, EventArgs e)
        {
            string full_file_path = String.Empty;
            string filename = String.Empty;
            string path = String.Empty;
            string keyfile_name = String.Empty;
            string keyfile_full_path = String.Empty;
            string encrypted_file_name = String.Empty;
            long filelength = 0;
            byte[] key;
            byte[] file;
            byte[] encrypted_file;

            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            OpenFileDialog file_encode = new OpenFileDialog();

            file_encode.InitialDirectory = "c:\\";
            file_encode.Filter = "All files (*.*)|*.*";
            file_encode.FilterIndex = 1;
            file_encode.RestoreDirectory = true;

            if (file_encode.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    full_file_path = file_encode.FileName;
                    filename = Path.GetFileName(full_file_path);
                    path = Path.GetDirectoryName(full_file_path);
                    encrypted_file_name = filename + ".otp";
                    keyfile_name = filename + ".otpkey";
                    keyfile_full_path = path + "\\" + keyfile_name;

                    FileInfo File_Info = new FileInfo(full_file_path);
                    filelength = File_Info.Length;

                    Text_Box.Clear();
                    Text_Box.AppendText("Opening File: " + filename + " \n");
                    Text_Box.AppendText("Size " + filelength + " Bytes \n");
                    Text_Box.AppendText("Keyfile path is " + keyfile_full_path + "\n");
                    Text_Box.AppendText("Encrypted filename is " + encrypted_file_name + "\n");
                }
                catch (Exception ex)
                {
                    Text_Box.AppendText("Error: Could not read file from disk. \n" + ex.Message);
                    return;
                }
            }
            else
            {
                return;
            }

            key = new byte[filelength];
            file = new byte[filelength];
            encrypted_file = new byte[filelength];
            rngCsp.GetBytes(key);

            try
            {
                Text_Box.AppendText("Reading file \n");
                file = File.ReadAllBytes(full_file_path);
            }
            catch (Exception ex)
            {
                Text_Box.AppendText("Error: Could not read file from disk. \n" + ex.Message);
                return;
            }

            for (int i = 0; i < filelength; i++)
            {
                encrypted_file[i] = (byte)(file[i] ^ key[i]);
            }

            try
            {
                Text_Box.AppendText("Writing keyfile \n");
                File.WriteAllBytes(keyfile_full_path, key);
            }
            catch (Exception ex)
            {
                Text_Box.AppendText("Error: Could not write to disk. \n" + ex.Message);
                return;
            }

            try
            {
                Text_Box.AppendText("Writing encrypted file \n");
                File.WriteAllBytes(path + "\\" + encrypted_file_name, encrypted_file);
            }
            catch (Exception ex)
            {
                Text_Box.AppendText("Error: Could not write to disk. \n" + ex.Message);
                return;
            }
            Text_Box.AppendText("Finished! \n");
        }

        private void Decrypt_File_Click(object sender, EventArgs e)
        {
            string full_file_path = String.Empty;
            string filename = String.Empty;
            string filename_without_extension = String.Empty;
            string path = String.Empty;
            string keyfile_full_path = String.Empty;
            long filelength = 0;
            byte[] key;
            byte[] file;
            byte[] decrypted_file;


            OpenFileDialog file_decrypt = new OpenFileDialog();
            file_decrypt.InitialDirectory = "c:\\";
            file_decrypt.Filter = "OTP Files (*.otp)|*.otp";
            file_decrypt.FilterIndex = 1;
            file_decrypt.RestoreDirectory = true;

            if (file_decrypt.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    full_file_path = file_decrypt.FileName;
                    filename = Path.GetFileName(full_file_path);
                    filename_without_extension = Path.GetFileNameWithoutExtension(full_file_path);
                    path = Path.GetDirectoryName(full_file_path);
                    keyfile_full_path = path + "\\" + filename_without_extension + ".otpkey";

                    if (Path.GetExtension(full_file_path) != ".otp")
                    {
                        Text_Box.AppendText("Please choose an .otp file");
                        return;
                    }

                    FileInfo File_Info = new FileInfo(full_file_path);
                    filelength = File_Info.Length;

                    Text_Box.Clear();
                    Text_Box.AppendText("Opening File: " + filename + " \n");
                    Text_Box.AppendText("Size " + filelength + " Bytes \n");
                    Text_Box.AppendText("Keyfile path is " + keyfile_full_path + "\n");
                }
                catch (Exception ex)
                {
                    Text_Box.AppendText("Error: Could not read file from disk. \n" + ex.Message);
                    return;
                }
            }
            else
            {
                return;
            }

            key = new byte[filelength];
            file = new byte[filelength];
            decrypted_file = new byte[filelength];

            try
            {
                Text_Box.AppendText("Reading file \n");
                file = File.ReadAllBytes(full_file_path);
            }
            catch (Exception ex)
            {
                Text_Box.AppendText("Error: Could not read file from disk. \n" + ex.Message);
                return;
            }

            try
            {
                Text_Box.AppendText("Reading keyfile \n");
                key = File.ReadAllBytes(keyfile_full_path);
            }
            catch (Exception ex)
            {
                Text_Box.AppendText("Error: Could not read file from disk. \n" + ex.Message);
                return;
            }

            for (int i = 0; i < filelength; i++)
            {
                decrypted_file[i] = (byte)(file[i] ^ key[i]);
            }

            try
            {
                Text_Box.AppendText("Writing decrypted file \n");
                File.WriteAllBytes(path + "\\" + filename_without_extension, decrypted_file);
            }
            catch (Exception ex)
            {
                Text_Box.AppendText("Error: Could not write to disk. \n" + ex.Message);
                return;
            }
            Text_Box.AppendText("Finished! \n");
        }
    }
}
