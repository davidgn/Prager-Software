#region Using directives

using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


#endregion

namespace Prager_Book_Inventory
{

        /// <summary>
    /// An extended <see cref="SmtpClient"/> which sends the
    /// FQDN of the local machine in the EHLO/HELO command.
    /// </summary>
    public class SmtpClientEx : SmtpClient
    {
        #region Private Data

        private static readonly FieldInfo localHostName = GetLocalHostNameField();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpClientEx"/> class
        /// that sends e-mail by using the specified SMTP server and port.
        /// </summary>
        /// <param name="host">
        /// A <see cref="String"/> that contains the name or
        /// IP address of the host used for SMTP transactions.
        /// </param>
        /// <param name="port">
        /// An <see cref="Int32"/> greater than zero that
        /// contains the port to be used on host.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="port"/> cannot be less than zero.
        /// </exception>
        public SmtpClientEx(string host, int port)
            : base(host, port) {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpClientEx"/> class
        /// that sends e-mail by using the specified SMTP server.
        /// </summary>
        /// <param name="host">
        /// A <see cref="String"/> that contains the name or
        /// IP address of the host used for SMTP transactions.
        /// </param>
        public SmtpClientEx(string host)
            : base(host) {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpClientEx"/> class
        /// by using configuration file settings.
        /// </summary>
        public SmtpClientEx() {
            Initialize();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the local host name used in SMTP transactions.
        /// </summary>
        /// <value>
        /// The local host name used in SMTP transactions.
        /// This should be the FQDN of the local machine.
        /// </value>
        /// <exception cref="ArgumentNullException">
        /// The property is set to a value which is
        /// <see langword="null"/> or <see cref="String.Empty"/>.
        /// </exception>
        public string LocalHostName {
            get {
                if (null == localHostName) return null;
                return (string)localHostName.GetValue(this);
            }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("value");
                }
                if (null != localHostName) {
                    localHostName.SetValue(this, value);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the price "localHostName" field.
        /// </summary>
        /// <returns>
        /// The <see cref="FieldInfo"/> for the private
        /// "localHostName" field.
        /// </returns>
        private static FieldInfo GetLocalHostNameField() {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            return typeof(SmtpClient).GetField("localHostName", flags);
        }

        /// <summary>
        /// Initializes the local host name to
        /// the FQDN of the local machine.
        /// </summary>
        private void Initialize() {
            IPGlobalProperties ip = IPGlobalProperties.GetIPGlobalProperties();
            if (!string.IsNullOrEmpty(ip.HostName) && !string.IsNullOrEmpty(ip.DomainName)) {
                this.LocalHostName = ip.HostName + "." + ip.DomainName;
            }
        }

        #endregion
    }

    //-----------------------------------------------------------------------------
    //--    converts 10-digit ISBN to 13-digit ISBN
    class ConvertISBN
    {
        public ConvertISBN() {
        }

        public string convertToISBN13(string ISBN10) {
            string workingISBN = "978" + ISBN10.Substring(0, 9);
            char[] ISBNdigit = workingISBN.ToCharArray();
            int weightedValues = int.Parse(ISBNdigit[0].ToString()) + int.Parse(ISBNdigit[1].ToString()) * 3 +
                int.Parse(ISBNdigit[2].ToString()) + int.Parse(ISBNdigit[3].ToString()) * 3 +
                int.Parse(ISBNdigit[4].ToString()) + int.Parse(ISBNdigit[5].ToString()) * 3 +
                int.Parse(ISBNdigit[6].ToString()) + int.Parse(ISBNdigit[7].ToString()) * 3 +
                int.Parse(ISBNdigit[8].ToString()) + int.Parse(ISBNdigit[9].ToString()) * 3 +
                int.Parse(ISBNdigit[10].ToString()) + int.Parse(ISBNdigit[11].ToString()) * 3;
            int remainder, checkDigit;
            Math.DivRem(weightedValues, 10, out remainder);
            if (remainder != 0)
                checkDigit = 10 - remainder;
            else
                checkDigit = 0;

            return workingISBN + checkDigit.ToString();
        }

        //  9780735606043  (converted check digit s/b 8
        public string convertToISBN10(string ISBN13) {
            string workingISBN = ISBN13.Substring(3, 9);  //  receives a 13-digit ISBN
            char[] ISBNdigit = workingISBN.ToCharArray();

            int weightedValues = int.Parse(ISBNdigit[0].ToString()) * 10 + int.Parse(ISBNdigit[1].ToString()) * 9 +
                int.Parse(ISBNdigit[2].ToString()) * 8 + int.Parse(ISBNdigit[3].ToString()) * 7 +
                int.Parse(ISBNdigit[4].ToString()) * 6 + int.Parse(ISBNdigit[5].ToString()) * 5 +
                int.Parse(ISBNdigit[6].ToString()) * 4 + int.Parse(ISBNdigit[7].ToString()) * 3 +
                int.Parse(ISBNdigit[8].ToString()) * 2;

            int quotient = weightedValues / 11;
            int checkDigit = ((quotient + 1)) * 11 - weightedValues;

            if (checkDigit > 10)
                return workingISBN + "X";
            else
                return workingISBN + checkDigit.ToString();
        }
    }


    //---------------------------------------------------------------------------------
    //--    gets current date and time from the internet
    class AtomicTime
    {
        public AtomicTime() {
        }

        public string getAtomicTime() {

            return DateTime.Now.ToString("dd MMM yyyy");  //  returns -> 06/10/2006 1:53:37 PM

            //TcpClient tcpc = new TcpClient();
            //Byte[] read = new Byte[32];
            //Stream s;
            //string Time;

            //try
            //{
            //    //    tcpc.Connect("129.6.15.28", 13);  //  NIST, Gaithersburg, Maryland (http://tf.nist.gov/service/time-servers.html)
            //    tcpc.Connect("132.163.4.101", 13);
            //    s = tcpc.GetStream();
            //    int bytes = s.Read(read, 0, read.Length);
            //    Time = Encoding.ASCII.GetString(read); //  returns ->  53896 06-06-10 20:52:52 50 0 0
            //}
            //catch (Exception)
            //{
            //    //if(ex.Message.Contains("A connection attempt failed because the connected party"))
            //    //lbStatus.Items.Insert(0, "unable to connect to the Atomic Time server");
            //    //else

            //    //lbStatus.Refresh();
            //    return DateTime.Now;
            //}

            //string[] workingTime = Time.Split(' ');  //  split into component parts
            //if (workingTime.Length > 3)
            //{
            //    string[] workingDate = workingTime[1].Split('-');  //  replace 'em
            //    string formattedDate;
            //    if (mainForm.currentCulture.Name.ToString() == "en-US")  //<----------------------------------- bombs here!!
            //        formattedDate = workingDate[1] + "/" + workingDate[2] + "/" + workingDate[0];
            //    else
            //        formattedDate = workingDate[2] + "/" + workingDate[1] + "/" + workingDate[0];

            //    string[] formattedTime = workingTime[2].Split(':');

            //    bool pm = false;
            //    int hour = 0;
            //    if (Int16.Parse(formattedTime[0]) > 12)  //  afternoon?
            //    {
            //        hour = Int16.Parse(formattedTime[0]) - 12;
            //        pm = true;
            //    }
            //    else
            //        hour = Int16.Parse(formattedTime[0]);

            //    string formattedDateTime = formattedDate + " " + hour.ToString() + ":" + formattedTime[1] + ":" + formattedTime[2];

            //    if (pm == true)
            //        formattedDateTime = formattedDateTime + " PM";
            //    else
            //        formattedDateTime = formattedDateTime + " AM";

            //    DateTime atdt = DateTime.Parse(formattedDateTime);

            //    string localTime = atdt.ToLocalTime().ToString();  //  for testing only

            //    return atdt.ToLocalTime();
            //}
            //else

            //return DateTime.Now.ToString("dd MMM yyyy");  //  returns -> 06/10/2006 1:53:37 PM


            //string xx =DateTime.Now.ToString("yyyy mm dd");  //  returns -> 06/10/2006 1:53:37 PM
            //string xy =DateTime.Now.ToString("yyyy-mm-dd");  //  returns -> 06/10/2006 1:53:37 PM
            //return xy;
        }
    }



    //-------------------------------------------------------------------------------
    //--    will return system information
    public class SystemInformation
    {
        #region "Enum Types"
        public enum DriveTypes
        {
            Unknown = 0,
            No_Root_Directory = 1,
            Removable_Disk = 2,
            Local_Disk = 3,
            Network_Drive = 4,
            Compact_Disc = 5,
            RAM_Disk = 6
        }

        public enum Status
        {
            Success = 0,
            AuthenticateFailure = 1,
            UnauthorizedAccess = 2,
            RPCServicesUnavailable = 3
        }
        #endregion

        #region "Structures"
        public struct TimezoneInfo
        {
            public String standardname;
            public int minoffset;
        }

        public struct LogicalDrive
        {
            public String name;
            public DriveTypes drivetype;
            public ulong size;
            public ulong freespace;
            public String filesystem;
        }

        public struct IPAddresses
        {
            public IPAddress address;
            public IPAddress subnet;
        }

        public struct NetworkAdapter
        {
            public IPAddresses[] networkaddress;
            public Boolean DHCPEnabled;
            public String name;
            public String databasePath;
        }

        public struct Processor
        {
            public String name;
            public uint speed;
            public String architecture;
        }

        public struct OperatingSystemVersion
        {
            public uint servicepackmajor;
            public uint servicepackminor;
            public uint major;
            public uint minor;
            public uint type;
            public uint build;
            public String description;
        }
        #endregion

        #region "Variable declarations"
        private int p_extendederror;

        private System.IO.Stream p_stderr;

        private NetworkAdapter[] p_adapters;

        private String p_bios;

        private String p_osname;
        private String p_osmanufacturer;
        private OperatingSystemVersion p_osversion;
        public string p_locale;
        private String p_windowsdirectory;
        private ulong p_freephysicalmemory;
        private ulong p_totalphysicalmemory;
        private ulong p_freevirtualmemory;
        private ulong p_totalvirtualmemory;
        private ulong p_pagefilesize;
        private TimezoneInfo p_timezone;
        private String p_computername;

        private String p_domain;
        private String p_systemmanufacturer;
        private String p_systemmodel;
        private String p_systemtype;
        private uint p_numberofprocessors;
        private Processor[] p_processors;

        private LogicalDrive[] p_drives;
        #endregion

        #region "Properties"
        public int ExtendedError {
            get { return p_extendederror; }
        }

        public System.IO.Stream stderr {
            get { return p_stderr; }
            set {
                if (value != null && value.CanWrite)
                    p_stderr = value;
                //				else
                //					throw new System.IO.IOException("Stream is not open or cannot be written to.");
            }
        }

        public LogicalDrive[] LogicalDrives {
            get { return p_drives; }
        }

        public String Bios {
            get { return p_bios; }
        }

        public NetworkAdapter[] Adapters {
            get { return p_adapters; }
        }

        public String OSName {
            get { return p_osname; }
        }

        public String OSManufacturer {
            get { return p_osmanufacturer; }
        }

        public OperatingSystemVersion OSVersion {
            get { return p_osversion; }
        }

        public String Locale {
            get { return p_locale; }
        }

        public String WindowsDirectory {
            get { return p_windowsdirectory; }
        }

        public ulong FreePhysicalMemory {
            get { return p_freephysicalmemory; }
        }

        public ulong TotalPhysicalMemory {
            get { return p_totalphysicalmemory; }
        }

        public ulong FreeVirtualMemory {
            get { return p_freevirtualmemory; }
        }

        public ulong TotalVirtualMemory {
            get { return p_totalvirtualmemory; }
        }

        public ulong PageFileSize {
            get { return p_pagefilesize; }
        }

        public TimezoneInfo Timezone {
            get { return p_timezone; }
        }

        public String ComputerName {
            get { return p_computername; }
        }

        public String Domain {
            get { return p_domain; }
        }

        public String SystemManufacturer {
            get { return p_systemmanufacturer; }
        }

        public String SystemModel {
            get { return p_systemmodel; }
        }

        public String SystemType {
            get { return p_systemtype; }
        }

        public uint NumberOfProcessors {
            get { return p_numberofprocessors; }
        }

        public Processor[] Processors {
            get { return p_processors; }
        }
        #endregion

        public SystemInformation() {
            p_stderr = null;
        }

        public SystemInformation(System.IO.Stream errstrm) {
            // Note that we use the property to set this as it
            // does checks on it to make sure it's valid.
            stderr = errstrm;
        }

        public Status Get(String host) {
            return Get(host, null, null);
        }

        public Status Get(String host, String username, String password) {
            // No blank username's allowed.
            if (username == "") {
                username = null;
                password = null;
            }
            // Configure the connection settings.
            ConnectionOptions options = new ConnectionOptions();
            options.Username = username; //could be in domain\user format
            options.Password = password;
            ManagementPath path = new ManagementPath(String.Format("\\\\{0}\\root\\cimv2", host));
            ManagementScope scope = new ManagementScope(path, options);

            // Try and connect to the remote (or local) machine.
            try {
                scope.Connect();
            }
            catch (ManagementException ex) {
                // Failed to authenticate properly.
                LogError("Failed to authenticate: " + ex.Message);
                p_extendederror = (int)ex.ErrorCode;
                return Status.AuthenticateFailure;
            }
            catch (System.Runtime.InteropServices.COMException ex) {
                // Unable to connect to the RPC service on the remote machine.
                LogError("Unable to connect to RPC service: " + ex.Message);
                p_extendederror = ex.ErrorCode;
                return Status.RPCServicesUnavailable;
            }
            catch (System.UnauthorizedAccessException ex) {
                // User not authorized.
                LogError("Unauthorized access: " + ex.Message);
                p_extendederror = 0;
                return Status.UnauthorizedAccess;
            }

            // Populate the class.
            GetSystemInformation(scope);
            //GetNetworkAddresses(scope);
            //GetLogicalDrives(scope);

            p_extendederror = 0;
            return Status.Success;
        }


        //----------------------------------------------------------------------------------
        private void LogError(String message) {
            if (p_stderr != null && p_stderr.CanWrite) {
                byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(message);
                p_stderr.Write(bytes, 0, bytes.Length);
            }
        }


        //----------------------------------------------------------------------------
        //--    get system information
        private void GetSystemInformation(ManagementScope scope) {
            // Only get the first BIOS in the list. Usually this is all there is.
            foreach (ManagementObject mo in new ManagementClass(scope, new ManagementPath("Win32_BIOS"), null).GetInstances()) {
                p_bios = mo["Version"].ToString();
                break;
            }

            foreach (ManagementObject mo in new ManagementClass(scope, new ManagementPath("Win32_OperatingSystem"), null).GetInstances()) {
                p_osversion.build = uint.Parse(mo["BuildNumber"].ToString());
                p_osversion.description = String.Format("{0} {1} Build {2}", mo["Version"], mo["CSDVersion"], mo["BuildNumber"]);
                p_osversion.servicepackmajor = uint.Parse(mo["ServicePackMajorVersion"].ToString());
                p_osversion.servicepackminor = uint.Parse(mo["ServicePackMinorVersion"].ToString());
                p_osversion.type = uint.Parse(mo["OSType"].ToString());
                // Get the major and minor version numbers.
                String[] numbers = mo["Version"].ToString().Split(".".ToCharArray());
                p_osversion.major = uint.Parse(numbers[0]);
                p_osversion.minor = uint.Parse(numbers[1]);
                // Get the rest of the fields.
                p_osname = mo["Name"].ToString().Split("|".ToCharArray())[0];
                p_osmanufacturer = mo["Manufacturer"].ToString();
                p_locale = mo["Locale"].ToString();
                p_windowsdirectory = mo["WindowsDirectory"].ToString();
                p_freevirtualmemory = ulong.Parse(mo["FreeVirtualMemory"].ToString());
                p_totalvirtualmemory = ulong.Parse(mo["TotalVirtualMemorySize"].ToString());
                p_freephysicalmemory = ulong.Parse(mo["FreePhysicalMemory"].ToString());
                p_totalphysicalmemory = ulong.Parse(mo["TotalVisibleMemorySize"].ToString());
                p_pagefilesize = ulong.Parse(mo["SizeStoredInPagingFiles"].ToString());
                p_computername = mo["CSName"].ToString();
                // Get the information related to the timezone.
                //p_timezone.minoffset = int.Parse(mo["CurrentTimeZone"].ToString());
                //p_timezone.standardname = GetTimezone(p_timezone.minoffset);
                break;
            }

            foreach (ManagementObject mo in new ManagementClass(scope, new ManagementPath("Win32_ComputerSystem"), null).GetInstances()) {
                p_systemmanufacturer = mo["Manufacturer"].ToString();
                p_systemmodel = mo["Model"].ToString();
                p_systemtype = mo["SystemType"].ToString();
                p_domain = mo["Domain"].ToString();
                p_numberofprocessors = uint.Parse(mo["NumberOfProcessors"].ToString());
                break;
            }

            ManagementObjectSearcher moSearch = new ManagementObjectSearcher(scope, new ObjectQuery("Select Name, CurrentClockSpeed, Architecture from Win32_Processor"));
            ManagementObjectCollection moReturn = moSearch.Get();

            p_processors = new Processor[moReturn.Count];
            int i = 0;
            foreach (ManagementObject mo in moReturn) {
                p_processors[i].name = mo["Name"].ToString().Trim();
                p_processors[i].architecture = mo["Architecture"].ToString();
                p_processors[i].speed = uint.Parse(mo["CurrentClockSpeed"].ToString());
                i++;
            }
        }
    }


    //-----------------------------------------------------------------------------
    //--    Implements the manual sorting of items by columns
    class ListViewItemComparer : IComparer
    {
        private int col;
        private System.Windows.Forms.SortOrder order;

        public ListViewItemComparer() {
            col = 0;
            order = System.Windows.Forms.SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order) {
            col = column;
            this.order = order;
        }


        public int Compare(object x, object y) {
            int returnVal;

            try  // Determine whether the type being compared is a decimal type
            {
                Decimal firstAmount = Decimal.Parse(((ListViewItem)x).SubItems[col].Text);
                Decimal secondAmount = Decimal.Parse(((ListViewItem)y).SubItems[col].Text);
                returnVal = Decimal.Compare(firstAmount, secondAmount);
            }
            catch  // If neither has a valid date format, compare as a string
            {
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }

            // Determine whether the sort order is descending.
            if (order == System.Windows.Forms.SortOrder.Descending)
                returnVal *= -1;  // Invert the value returned by String.Compare.

            return returnVal;

        }

    }


    //-----------------------    converts a long to hex    ----------------------------
    public static class ExpandableHexConverter
    {
        //public enum ExpandLevel
        //{
        //    A = 11,
        //    B,
        //    C,
        //    D,
        //    E,
        //    F,
        //    G,
        //    H,
        //    I,
        //    J,
        //    K,
        //    L,
        //    M,
        //    N,
        //    O,
        //    P,
        //    Q,
        //    R,
        //    S,
        //    T,
        //    U,
        //    V,
        //    W,
        //    X,
        //    Y,
        //    Z,
        //    UseCaseSensitive = 62
        //}

        //public static string ToHex(long value, ExpandLevel ExpandBy)
        //{
        //    return loopRemainder(value, (long)ExpandBy);
        //}

        //public static long ToInt64(string value, ExpandLevel ExpandBy)
        //{
        //    value = validate(value, ExpandBy);
        //    long returnvalue = 0;
        //    for (int i = 0; i < value.Length; i++)
        //        returnvalue += (long)Math.Pow((long)ExpandBy, (value.Length - (i + 1))) * CharToVal(value[i]);
        //    return returnvalue;
        //}

        private static string loopRemainder(long value, long PowerOf) {
            long x = 0;
            long y = Math.DivRem(value, PowerOf, out x);
            if (y > 0)
                return loopRemainder(y, PowerOf) + ValToChar(x).ToString();
            else
                return ValToChar(x).ToString();
        }
        private static char ValToChar(long value) {
            if (value > 9) {
                int ascii = (65 + ((int)value - 10));
                if (ascii > 90)
                    ascii += 6;
                return (char)ascii;
            }
            else
                return value.ToString()[0];
        }
    }


    ////--------------------------------------------------------------------------
    ////--    class to encrypt/decrypt various fields
    //public class encryptionRoutines
    //{

    //    //--    encrypt string
    //    public string encryptString(string plainData, string guidKey) {
    //        byte[] Results;
    //        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

    //        // Step 1. We hash the passphrase using MD5
    //        // We use the MD5 hash generator as the result is a 128 bit byte array
    //        // which is a valid length for the TripleDES encoder we use below

    //        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
    //        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(guidKey));

    //        // Step 2. Create a new TripleDESCryptoServiceProvider object
    //        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

    //        // Step 3. Setup the encoder
    //        TDESAlgorithm.Key = TDESKey;
    //        TDESAlgorithm.Mode = CipherMode.ECB;
    //        TDESAlgorithm.Padding = PaddingMode.PKCS7;

    //        // Step 4. Convert the input string to a byte[]
    //        byte[] DataToEncrypt = UTF8.GetBytes(plainData);

    //        // Step 5. Attempt to encrypt the string
    //        try {
    //            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
    //            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
    //        }
    //        finally {
    //            // Clear the TripleDes and Hashprovider services of any sensitive information
    //            TDESAlgorithm.Clear();
    //            HashProvider.Clear();
    //        }

    //        // Step 6. Return the encrypted string as a base64 encoded string
    //        return Convert.ToBase64String(Results);
    //    }


    //    //-----------------------------------------------------------------------
    //    //--    decrypt string
    //    public string decryptString(string plainData, string guidKey) {
    //        byte[] Results = Encoding.ASCII.GetBytes("");
    //        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

    //        // Step 1. We hash the passphrase using MD5
    //        // We use the MD5 hash generator as the result is a 128 bit byte array
    //        // which is a valid length for the TripleDES encoder we use below

    //        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
    //        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(guidKey));

    //        // Step 2. Create a new TripleDESCryptoServiceProvider object
    //        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

    //        // Step 3. Setup the decoder
    //        TDESAlgorithm.Key = TDESKey;
    //        TDESAlgorithm.Mode = CipherMode.ECB;
    //        TDESAlgorithm.Padding = PaddingMode.PKCS7;

    //        // Step 4. Convert the input string to a byte[]
    //        //plainData = "5txxpyhtBDKOwkYe64x95Q==";  //  TESTING ONLY (Bad Data) !!
    //        byte[] DataToDecrypt;
    //        try {
    //            DataToDecrypt = Convert.FromBase64String(plainData);
    //        }
    //        catch (Exception ex) {
    //            MessageBox.Show("The License information you have entered is invalid; please verify it and try again",
    //                "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            Results = Encoding.ASCII.GetBytes("Bad Data");
    //            return UTF8.GetString(Results);
    //        }

    //        // Step 5. Attempt to decrypt the string
    //        try {
    //            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
    //            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
    //        }
    //        catch (Exception ex) {
    //            //if (ex.Message.Contains("bad data"))
    //            Results = Encoding.ASCII.GetBytes("Bad Data");
    //        }
    //        finally {
    //            // Clear the TripleDes and Hashprovider services of any sensitive information
    //            TDESAlgorithm.Clear();
    //            HashProvider.Clear();
    //        }

    //        // Step 6. Return the decrypted string in UTF8 format
    //        return UTF8.GetString(Results);
    //    }
    //}

}
