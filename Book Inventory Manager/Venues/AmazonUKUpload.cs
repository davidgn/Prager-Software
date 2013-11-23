using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using MsgBoxCheck;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Prager_Book_Inventory
{
    class AmazonUKUpload
    {
        Regex r;
        Match m;
        Regex r1;
        Match m1;

        //--------------------    actual upload to Amazon.uk    -------------------------------|
        public int uploadAmazonUKFiles(string[] args, ListBox lbUploadStatus) {

            string UKaddModifyDeleteURL = @"https://secure.amazon.co.uk/exec/panama/seller-admin/catalog-upload/add-modify-delete";
            string UKpurgeAndReplace = @"https://secure.amazon.co.uk/exec/panama/seller-admin/catalog-upload/purge-replace";


            string uploadFilename1 = "";
            //string uploadFilename2 = "";

            //Prepare the cookies
            CookieCollection cookies = new CookieCollection();
            CookieContainer cookieContainer = new CookieContainer();

            cookies.Add(new Cookie("x-main", "YvjPkwfntqDKun0QEmVRPcTTZDMe?Tn?"));
            cookies.Add(new Cookie("ubid-main", "002-8989859-9917520"));
            cookies.Add(new Cookie("ubid-tacbus", "019-5423258-4241018"));
            cookies.Add(new Cookie("x-tacbus", "vtm4d53DvX@Sc9LxTnAnxsFL3DorwxJa"));
            cookies.Add(new Cookie("ubid-tcmacb", "087-8055947-0795529"));
            cookies.Add(new Cookie("ubid-ty2kacbus", "161-5477122-2773524"));
            cookies.Add(new Cookie("session-id", "087-178254-5924832"));
            cookies.Add(new Cookie("session-id-time", "950660664"));

            cookieContainer.Add(new Uri(@"https://secure.amazon.co.uk"), cookies);

            int x = 0;
            string[] fileNameParts = args[2].Split('\\');
            for (x = 0; x < fileNameParts.Length; x++)
                uploadFilename1 += fileNameParts[x] + @"\";
            uploadFilename1 = uploadFilename1.Substring(0, uploadFilename1.Length - 1);

            //        uploadFilename = uploadFilename.Replace("HB", "AZ");
            uploadFilename1 = fileNameParts[0] + @"\" + fileNameParts[1] + @"\" + fileNameParts[2] + @"\" + fileNameParts[3].Replace("HB", "AZisbn");
            //uploadFilename2 = fileNameParts[0] + @"\" + fileNameParts[1] + @"\" + fileNameParts[2] + @"\" + fileNameParts[3].Replace("HB", "AZnoisbn");

            //HttpWebRequest myRequest = null;
            //if (args[2].Contains("purge"))  //  are we doing a purge (as noted in the filename)?
            //    myRequest = (HttpWebRequest)WebRequest.Create(purgeAndReplace);
            //else
            //    myRequest = (HttpWebRequest)WebRequest.Create(addModifyDeleteURL);

            //myRequest.Method = "POST";
            //myRequest.Headers.Add("Authorization: Basic " + EncodeBase64(args[0] + ":" + args[1]));
            //myRequest.ContentType = "text/xml";
            //myRequest.Timeout = 600000;
            //myRequest.KeepAlive = false;
            //myRequest.CookieContainer = cookieContainer;

            ////  additional parameters 
            //myRequest.Headers.Add("UploadFor", "Marketplace");
            //myRequest.Headers.Add("FileFormat", "TabDelimited");
            //myRequest.Headers.Add("email", "Y");  //  send email confirmation of upload

            //  get length of input file with ISBNs
            FileInfo fi = new FileInfo(uploadFilename1);
            if (!fi.Exists) { //  does file exist?
                System.Windows.Forms.MessageBox.Show("File " + uploadFilename1[0] + " is missing; did you change the export path?", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            HttpWebRequest myRequest = null;
            if (args[2].Contains("purge"))  //  are we doing a purge (as noted in the filename)?
                myRequest = (HttpWebRequest)WebRequest.Create(UKpurgeAndReplace);
            else
                myRequest = (HttpWebRequest)WebRequest.Create(UKaddModifyDeleteURL);

            myRequest.Method = "POST";
            myRequest.Headers.Add("Authorization: Basic " + EncodeBase64(args[0] + ":" + args[1]));
            myRequest.ContentType = "text/xml";
            myRequest.Timeout = 600000;
            myRequest.KeepAlive = false;
            myRequest.CookieContainer = cookieContainer;

            //  additional parameters 
            myRequest.Headers.Add("UploadFor", "Marketplace");
            myRequest.Headers.Add("FileFormat", "TabDelimited");
            myRequest.Headers.Add("email", "Y");  //  send email confirmation of upload


            int fileLength = (int)fi.Length;
            if (fileLength > 0) {
                myRequest.ContentLength = fileLength + 2;  //  set length of data
                FileStream rdr = new FileStream(uploadFilename1, FileMode.Open, FileAccess.Read);

                //  read the data and put it into the request buffer
                byte[] inData = new byte[fileLength];
                byte[] crLF = { 13, 10 };
                int bytesRead = rdr.Read(inData, 0, fileLength);

                try {
                    Stream reqStream = myRequest.GetRequestStream();  //  get a request stream
                    reqStream.Write(inData, 0, bytesRead);
                    reqStream.Write(crLF, 0, 2);
                    rdr.Close();
                    reqStream.Close();
                }
                catch (Exception e) {
                    System.Windows.Forms.MessageBox.Show("exception: " + e.Message);
                }

                lbUploadStatus.Items.Insert(0, "upload of file: " + uploadFilename1 + " to Amazonco..uk started");
                lbUploadStatus.Refresh();

                uploadToAmazon(myRequest, lbUploadStatus);
            }

            ////  get length of input file with non-ISBNs
            //fi = new FileInfo(uploadFilename2);
            //if (!fi.Exists) {  //  does file exist?
            //    System.Windows.Forms.MessageBox.Show("File " + uploadFilename2 + " is missing; did you change the export path?", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return -1;
            //}

            //HttpWebRequest myRequest2 = null;
            ////if (args[2].Contains("purge"))  //  are we doing a purge (as noted in the filename)?  (removed - we've already done the purge, so don't do it again)
            ////    myRequest2 = (HttpWebRequest)WebRequest.Create(purgeAndReplace);
            ////else
            //myRequest2 = (HttpWebRequest)WebRequest.Create(UKaddModifyDeleteURL);

            //myRequest2.Method = "POST";
            //myRequest2.Headers.Add("Authorization: Basic " + EncodeBase64(args[0] + ":" + args[1]));
            //myRequest2.ContentType = "text/xml";
            //myRequest2.Timeout = 600000;
            //myRequest2.KeepAlive = false;
            //myRequest2.CookieContainer = cookieContainer;

            ////  additional parameters 
            //myRequest2.Headers.Add("UploadFor", "Marketplace");
            //myRequest2.Headers.Add("FileFormat", "TabDelimited");
            //myRequest2.Headers.Add("email", "Y");  //  send email confirmation of upload

            //fileLength = (int)fi.Length;
            //if (fileLength > 0) {
            //    myRequest2.ContentLength = fileLength + 2;  //  set length of data

            //    Stream reqStream = myRequest2.GetRequestStream();  //  get a request stream
            //    FileStream rdr = new FileStream(uploadFilename2, FileMode.Open, FileAccess.Read);

            //    //  read the data and put it into the request buffer
            //    byte[] inData = new byte[fileLength];
            //    byte[] crLF = { 13, 10 };

            //    int bytesRead = rdr.Read(inData, 0, fileLength);
            //    reqStream.Write(inData, 0, bytesRead);
            //    reqStream.Write(crLF, 0, 2);
            //    rdr.Close();
            //    reqStream.Close();

            //    lbUploadStatus.Items.Insert(0, "upload of file: " + uploadFilename2 + " to Amazon.com started");
            //    lbUploadStatus.Refresh();

            //    uploadToAmazon(myRequest2, lbUploadStatus);
            //}

            return 0;
        }


        //------------------------    call the Amazon.uk upload routine    ---------------------------|
        private int uploadToAmazon(HttpWebRequest myRequest, ListBox lbUploadStatus) {

            string line;
            HttpWebResponse myHttpWebResponse = null;

            try {
                myHttpWebResponse = (HttpWebResponse)myRequest.GetResponse();

                Stream streamResponse = myHttpWebResponse.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);

                while ((line = streamRead.ReadLine()) != null) {
                    Regex r = new Regex(@"<Success>SUCCESS");  //  was it clean?

                    if (r.IsMatch(line))
                        lbUploadStatus.Items.Insert(0, "upload to Amazon.uk was successful");
                    else {
                        r = new Regex(@"<FileError>");  // file error?
                        if (r.IsMatch(line))
                            lbUploadStatus.Items.Insert(0, "upload to Amazon.uk failed - FileError ");
                        else {
                            r = new Regex(@"<BusinessLogicError>");  //  what kind of error?
                            m = r.Match(line);
                            if (m.Success) {
                                r1 = new Regex(@"</BusinessLogicError>");  //  find the end...
                                m1 = r1.Match(line);
                                if (m1.Success) {
                                    int len = m1.Index - m.Index - 20;
                                    lbUploadStatus.Items.Insert(0, "upload to Amazon.uk failed: " + line.Substring(20, len));
                                }
                            }
                        }
                    }

                    lbUploadStatus.Refresh();
                }
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show("Error during upload to Amazon.uk: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return 0;
        }

        //---------------------------------------------------------------------------------------------------------|
        static string EncodeBase64(string data) {
            return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(data));
        }


    }
}
