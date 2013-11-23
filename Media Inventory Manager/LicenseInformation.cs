using System;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using System.Windows.Forms;


namespace Media_Inventory_Manager
{
    class LicenseInformation
    {

        //public string expirationDate;
        //-------------------------    get License Info from d/b    -----------------------]
        public int getLicenseInformation() {

           
            //TimeSpan thirtyDays = TimeSpan.FromDays(30);
            const string commandString = "select tInstallDate, eDate, GUID from tOptions";

            FbDataReader rdr = null;
            if (mainForm.mediaConn.State == ConnectionState.Closed)
                mainForm.mediaConn.Open();

            FbCommand regCmd = new FbCommand(commandString, mainForm.mediaConn);

            rdr = regCmd.ExecuteReader();
            rdr.Read();  //  read the only row...

            try {  //  if there is no install date, error...
                if (rdr[0].Equals(DBNull.Value)) {
                    MessageBox.Show("Installation date is missing; notify support@pragersoftware.com", "Prager Media Inventory Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else
                    mainForm.installedDate = (DateTime)rdr[0];  //  otherwise take date in table
            }
            catch (Exception) {
                //if (ex.Message.Contains("no data to read")) {
                //    MessageBox.Show("Installation date is missing; notify support@pragersoftware.com", "Prager Media Inventory Manager",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
                //}
            }

            mainForm.eDate = rdr[1].ToString();  //  save encrypted date
            //string debugGUID = rdr[2].ToString();  //  verified that we are getting correct GUID 11-25
            if (mainForm.storedGUID == null)
                mainForm.storedGUID = rdr[2].ToString();

            encryptionRoutines er = new encryptionRoutines();
            //string tempDate = er.decryptString(rdr[1].ToString(), rdr[2].ToString());  //  decrypt the expiration date
            string tempDate = er.decryptString(rdr[1].ToString(), mainForm.storedGUID);  //  decrypt the expiration date
            if (tempDate.Contains("Bad Data")) { //  test for 'Bad Data'
           //     return -2;
           // else {  // using MAC?
                tempDate = er.decryptString(rdr[1].ToString(), mainForm.MACAddress);
                if (tempDate.Contains("Bad Data"))  //  test for 'Bad Data'
                    return -2;
            }
            //MessageBox.Show("tempDate: " + tempDate + "  installDate: " + rdr[0].ToString(), "Debugging", MessageBoxButtons.OK, MessageBoxIcon.Information);

            mainForm.expireDate = DateTime.Parse(tempDate);  //  save expiration date for display in the About screen
            string installDate = rdr[0].ToString();  //  save install date

            mainForm.fTrace("I - installDate: " + rdr[0].ToString());
            mainForm.fTrace("I - expirationDate: " + tempDate);  //  let's us know if this is a new user

            if (DateTime.Parse(rdr[0].ToString()) == DateTime.Today) {  //  if installed today, give them 30-days
                mainForm.expireDate = DateTime.Parse(installDate).AddDays(30);
                string maintenanceString = "UPDATE tOptions SET eDate = '" + er.encryptString(mainForm.expireDate.ToShortDateString(),
                 mainForm.storedGUID) + "' ROWS 1";

                FbCommand selCmd = new FbCommand(maintenanceString, mainForm.mediaConn);
                if (mainForm.mediaConn.State == ConnectionState.Closed)
                    mainForm.mediaConn.Open();

                selCmd.ExecuteNonQuery();  //  give them 30-days from installation date
                return -3;
            }

            if (mainForm.expireDate > DateTime.Today)   //  check validity of license...
                return 0; //  license has not expired

            //  if license was purchased within the last year, add 1 year to install date
            DateTime iDate = DateTime.Parse(rdr[0].ToString());  //  when was this installed?
            DateTime graceDateEnd = DateTime.Parse("11/1/2011");  //  last date for grace period

            if (iDate > graceDateEnd.AddYears(-1) && iDate < graceDateEnd) {
                mainForm.expireDate = iDate.AddYears(1);  //  give them 1-year free

                //  update table
                string maintenanceString = "UPDATE tOptions SET eDate = '" +
                    er.encryptString(mainForm.expireDate.ToShortDateString(),
                    mainForm.storedGUID) + "' ROWS 1";

                FbCommand selCmd = new FbCommand(maintenanceString, mainForm.mediaConn);
                if (mainForm.mediaConn.State == ConnectionState.Closed)
                    mainForm.mediaConn.Open();

                selCmd.ExecuteNonQuery();  //  give them one year from installation date
                //                return -4;
            }

            //  if expiration date is less than today...
            if (iDate < DateTime.Today && mainForm.expireDate < DateTime.Today) {  //  expire date has come and gone...
                MessageBox.Show("Your license expired on " + mainForm.expireDate.ToString(), "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -5;
            }


            #region
            //if (unlockCode == "" || unlockCode == "WJ8B-TFE4-H25R-CGIB")  //  unlock code is missing or has been extended
            //{
            //    rdr.Close();  //  close the reader

            //    //  check the install date to see if the free trial period has expired
            //    DateTime expireDate = mainForm.installedDate.Add(thirtyDays);
            //    //DateTime expireDate = installedDate.Subtract(thirtyDays); // for testing ONLY  <-------------------

            //AtomicTime at = new AtomicTime();
            //    DateTime currentDate = DateTime.Parse(at.getAtomicTime(), mainForm.localCulture);  //  en_AU returns -> 8/09/2006 4:44:32 PM

            //    if (DateTime.Compare(currentDate, expireDate) > 0)  // is today greater than installDate + 30? (return > 0)  <----- TODO (local culture test)
            //    {
            //        mainForm.freeTrialExpired = true;
            //        return -3;  //  over 30 days, disable "paid" options and show license window
            //    }
            //}
            //else  //  unlock code is not missing or extended
            //{
            //    //  check to see if they are on the restricted users list
            //    //  unlockCode = "AGBO-CRIA-DQPD-889";  //  <----------------- TESTING ONLY! (testing restricted user list)
            //    for (int i = 0; i < restrictedUsersList.Length; i++)
            //        if (unlockCode.Contains(restrictedUsersList[i])) {
            //            mainForm.freeTrialExpired = true;
            //            rdr.Close();
            //            return -2;  //  restricted (money refunded), disable "paid" options and show license window
            //        }

            //    if (unlockCode.Trim().Length == 0)  //  for some reason, if the registration code is tampered with and is spaces
            //    {
            //        clearUnlockCode();
            //        return -1;  //  either missing or has been tampered with
            //    }

            //    if (unlockCode.Contains("WJ8B-TFE4-H25R-CGIB"))  //  extension unlock code  <-------  ?????????????????
            //    {
            //        //  extend 30-day period by altering the installation date... (mark it so it only happens once!)
            //        return 1;
            //    }

            //    //  parse it...
            //    for (int j = 0; j < 14; j++)  //  number of characters to work with = 14
            //    {
            //        if (j == 4 || j == 9 || j == 14)  //  bypass the dashes
            //            continue;
            //        ch = Convert.ToChar(unlockCode.Substring(j, 1));
            //        chInt += Convert.ToInt32(ch);  //  chInt must match last set of characters
            //    }

            //    chInt += 24;  //  add 24 for Inventory purchase code
            //    string[] msg = unlockCode.Split('-');  //  now, split it into pieces

            //    if (msg[3] != Convert.ToString(chInt))  //  if codes don't match, current code is no good
            //    {
            //        clearUnlockCode();  //  remove it...
            //        return -4;  //  indicate it is no good
            //    }


            //    //else  {  //  codes match, so check to see if it's time to renew
            //    //  check to see if license was purchased within one year... if so, there is no renewal for 2011  <---------- TODO

            //    //    if (DateTime.Compare(mainForm.renewalDate, DateTime.Today) < 0) {  //  compare it... if less than today...
            //    //        return -5;  //  signal time to renew and shut off paid options
            //    //    }
            //    //    else {
            //    //        //mainForm.renewalDate = DateTime.Today.AddDays(-10);  //  <---------------- TEST ONLY
            //    //        DateTime testDate = mainForm.renewalDate.AddDays(15);  //  compare it... if within 15 days, display a message
            //    //        if (DateTime.Compare(mainForm.renewalDate, DateTime.Today) < 0) {
            //    //            MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
            //    //            DialogResult dlgResult =
            //    //            dlg.Show(@"Software\Prager\Inventory Program\RenewalMessage",  //  registry entry
            //    //            "DontShowAgain",  //  registry value name
            //    //            DialogResult.OK,  //  default return value returned immediately if box is not shown
            //    //            "Don't show this again",  //  message for checkbox
            //    //            "Your license expires in less than 15 days; do you want to renew it now?", "Prager Media Inventory Manager",
            //    //            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //    //            if (dlgResult == DialogResult.Yes) {
            //    //                return -5;
            //    //            }
            //    //        }
            //    //    }

            //    //mainForm.programUnlockCode = unlockCode;  //  set fields in mainForm
            //    //    return 0;
            //    //}
            //}
            #endregion

            return 0;
        }

    }
}
