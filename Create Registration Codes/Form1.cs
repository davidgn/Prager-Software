#region Using directives

using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

#endregion

//  network license:  UfRQIxuv6dVwB+qgXR6ICg==

namespace WindowsApplication1
{
    partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();

        }

        private void bGenerate_Click(object sender, EventArgs e) {

            if (!rbInventory.Checked && !rbMedia.Checked && !rbPricing.Checked && !rbSynchronizer.Checked) {
                MessageBox.Show("Which license?", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            Int32 int32 = 0;
            int chInt = 0;
            int size = 12;

            for (int i = 0; i < size; i++) {
                int32 = Convert.ToInt32(26 * random.NextDouble() + 65);  //  get random number
                if (int32 < 64 || int32 > 90)  //  only want upper case letters
                {
                    i--;  //  decrement control
                    continue;
                }
                chInt += int32;  //  add to verification number
                ch = Convert.ToChar(int32);  //  convert to a character
                builder.Append(ch);  //  append it to the string
            }

            //  find out which program this is for...
            if (rbInventory.Checked || rbMedia.Checked)  //  inventory or media program?
                if (tbGUID.Text.Length > 0) {  //  is this for the new license?
                    tbGeneratedKey.Text = encryptDate();  //  yep...
                    return;  //  no hyphens used
                }
                else
                    chInt += 24;  //  no...
            else if (rbPricing.Checked == true)  //  pricing program?
                chInt += 33;
            else if (rbSynchronizer.Checked == true)  //  synchronizer program?
                chInt += 67;

            builder.Append(chInt);  //  now append the verification number
            builder.Insert(4, '-');  //  insert hyphens
            builder.Insert(9, '-');
            builder.Insert(14, '-');
            tbGeneratedKey.Text = builder.ToString();  //  move it to the text field

            chInt = 0;

            for (int j = 0; j < size + 2; j++)  //  now, verify it...
            {
                if (j == 4 || j == 9 || j == 14)
                    continue;
                ch = Convert.ToChar(tbGeneratedKey.Text.Substring(j, 1));
                chInt += Convert.ToInt32(ch);
            }

            //tbVerified.Text = Convert.ToString(chInt);

        }


        //------------------    encrypt date using GUID    ---------------------|
        public string encryptDate() {

            if (rbLocaleUK.Checked) {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            }

            string dateTime = dateTimePicker1.Value.ToString("MM.dd.yyyy");  //  Debugging  <---
            string encryptedDate = "";

            encryptionRoutines er = new encryptionRoutines();
            //string encryptedDate = er.encryptString(dateTimePicker1.Value.ToShortDateString(), tbGUID.Text);
            if (rbInventory.Checked)
                encryptedDate = er.encryptString(dateTime, tbGUID.Text);
            else if (rbMedia.Checked)
                encryptedDate = er.encryptString(dateTime, "media" + tbGUID.Text);

            if (rbInventory.Checked)
                tbDecryptedKey.Text = er.decryptString(encryptedDate, tbGUID.Text);
            else if (rbMedia.Checked)
                tbDecryptedKey.Text = er.decryptString(encryptedDate, "media" + tbGUID.Text);

            return encryptedDate;
        }


        //---------------    paste GUID from clipboard    --------------------|
        private void bPasteGUID_Click(object sender, EventArgs e) {

            tbGUID.Text = Clipboard.GetText();
        }


        //-------------    Copy key to clipboard    ----------------------|
        private void bCopyKey_Click(object sender, EventArgs e) {

            Clipboard.SetText(tbGeneratedKey.Text);
        }


        //-------------------    decrypt the key    ----------------------|
        private void bDecrypt_Click(object sender, EventArgs e) {

            encryptionRoutines er = new encryptionRoutines();
            if (rbMedia.Checked == true)
                tbDecryptedKey.Text = er.decryptString(tbGeneratedKey.Text, "media" + tbGUID.Text);
            else
                tbDecryptedKey.Text = er.decryptString(tbGeneratedKey.Text, tbGUID.Text);

        }


        //----------------    add one (1) year to displayed date    ---------------|
        private void bAddOneYear_Click(object sender, EventArgs e) {

            dateTimePicker1.Value = dateTimePicker1.Value.AddYears(1);
            dateTimePicker1.Refresh();
        }


        //----------------    change locale of datetimepicker1    ---------------------|
        private void rbLocaleUK_CheckedChanged(object sender, EventArgs e) {
            if (rbLocaleUK.Checked) {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            }
        }

        //------------------  copy network license key    ----------------------------|
        private void bCopyNetworkLic_Click(object sender, EventArgs e) {
            Clipboard.SetText("UfRQIxuv6dVwB+qgXR6ICg==");
        }
    }

    //------------------------    class to encrypt/decrypt various fields    -------------|
    public class encryptionRoutines
    {

        //---------------    encrypt string    -----------------------|
        public string encryptString(string plainData, string guidKey) {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(guidKey));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(plainData);

            // Step 5. Attempt to encrypt the string
            try {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }



        //---------------    decrypt string    -----------------------|
        public string decryptString(string plainData, string guidKey) {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(guidKey));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(plainData);

            // Step 5. Attempt to decrypt the string
            try {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }
    }

}
