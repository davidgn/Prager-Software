
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using FirebirdSql.Data.FirebirdClient;
using MarketplaceWebServiceProducts;
using MarketplaceWebServiceProducts.Model;


//------------    static keys for uploads and upload Verification   -----------------
//  Developer: MWS Access Key ID:  AKIAIZEE34BK5NOX5SDA
//             Secret Key: 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
//             Account Nbr: 1145-8140-6600
//             Merchant ID: A20V78MULJSCYR  (aka "Seller ID")
//             Marketplace ID: ATVPDKIKX0DER

//----------    my AWS keys for getting prices    ------------------  ??????????????????
//  Seller:  Access key:  AKIAJCD64XK7AANOIA3A
//           Secret Key:  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
//           Associates Tag: wwwpragerbook-20   

namespace BulkAddBooks
{
 

    public class AmazonMWS  {

         public int ndx1 = 0;  //  indicates how many prices there were
         public string imageURL = "";
        
    
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    look for book info and parse results
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public bool InvokeItemSearch(string ISBN, string AWSKey, string MerchantID, string MarketplaceID, string AWSSecretKey) {

            Cursor.Current = Cursors.WaitCursor;

            const string applicationName = "PragerBookInventory";
            const string applicationVersion = "12.7.0";

            MarketplaceWebServiceProductsConfig config = new MarketplaceWebServiceProductsConfig();
            config.ServiceURL = "https://mws.amazonservices.com/Products/2011-10-01";

            MarketplaceWebServiceProductsClient service = new MarketplaceWebServiceProductsClient(
                applicationName, applicationVersion, AWSKey, AWSSecretKey, config);

            GetMatchingProductRequest request = new GetMatchingProductRequest();

            ASINListType wsList = new ASINListType();
            wsList.ASIN.Add(ISBN);
            request.ASINList = wsList;
            request.MarketplaceId = MarketplaceID;
            request.SellerId = MerchantID;

            GetMatchingProductResponse response = service.GetMatchingProduct(request);
            List<GetMatchingProductResult> getMatchingProductResultList = response.GetMatchingProductResult;

            // take the response and convert it to a XML string
            string xml = null;
            foreach (GetMatchingProductResult getMatchingProductResult in getMatchingProductResultList) {
                if (getMatchingProductResult.IsSetProduct()) {
                    Product product = getMatchingProductResult.Product;

                    if (product.IsSetAttributeSets()) {  //  is attributes set?
                        foreach (var attribute in product.AttributeSets.Any) {  //  send each XML element
                            xml = ProductsUtil.FormatXml((System.Xml.XmlElement)attribute);
                        }
                    }
                    //System.Diagnostics.Debug.WriteLine(xml);  //  DEBUGGING
                }
            }

            //  check for error...
            if (xml == null) {
                //lNotFound.Visible = true;
                return false;
            }

            byte[] byteArray = Encoding.ASCII.GetBytes(xml);
            MemoryStream stream = new MemoryStream(byteArray);

            XmlTextReader reader = new XmlTextReader(stream);
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:  //  the node is an element
                        if (reader.Name == "ns2:ItemAttributes")
                            break;
                        if (reader.Name == "ns2:Author") {
                            reader.Read();  //  get value
                            mainForm.Author = reader.Value;
                        }
                        if (reader.Name == "ns2:Binding") {
                            reader.Read();  //  get value
                            mainForm.Binding = reader.Value;
                        }
                        if (reader.Name == "ns2:NumberOfPages") {
                            reader.Read();  //  get value
                            mainForm.Pages = reader.Value;
                        }
                        if (reader.Name == "ns2:PublicationDate") {
                            reader.Read();  //  get value
                            mainForm.PubDate = reader.Value.Length > 0 ? reader.Value.Substring(0, 4) : "";
                        }
                        if (reader.Name == "ns2:Publisher") {
                            reader.Read();  //  get value
                            mainForm.Pub = reader.Value;
                        }
                        if (reader.Name == "ns2:Title") {
                            reader.Read();  //  get value
                            mainForm.Title = reader.Value;
                        }
                        break;
                    default:
                        break;
                }
            }

            Cursor.Current = Cursors.Default;

            return true;  //  good return code
        }


    //        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //        //--    actual code to update the database with the ASINs
    //        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //        private bool updateDBwithASINs() {
    //            string sFileName = "";
    //            string updateString = "";

    //            //  get filename
    //            if (openFileDialog1.ShowDialog() == DialogResult.OK)
    //                sFileName = openFileDialog1.FileName;
    //            else
    //                return false;  //  user canceled...

    //            string inputRecord;

    //            System.IO.StreamReader sr = new StreamReader(sFileName);  //  create stream reader object 
    //            sr.ReadLine();  //  get past the first record which contains the header information

    //            while ((inputRecord = sr.ReadLine()) != null)  //  read a tab-delimited records
    //            {
    //                string[] delimitedData = inputRecord.Split('\t');  //  now split each record into elements
    //                if (delimitedData[22].StartsWith("B"))  //  we have an ASIN
    //                {
    //                    //  update the record in the table
    //                    updateString = "UPDATE tBooks SET ISBN = '" + delimitedData[22] + "' WHERE BookNbr = '" + delimitedData[3] + "'";
    //                    FbCommand cmd = new FbCommand(updateString);
    //                    cmd.Connection = mainForm.bookConn;
    //                    if (cmd.Connection.State == System.Data.ConnectionState.Closed)
    //                        cmd.Connection.Open();

    //                    cmd.ExecuteNonQuery();
    //                }
    //            }

    //            sr.Close();  //  close the stream reader
    //            return true;
    //        }
    }  


    ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    ////--    signed request helper
    ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //class SignedRequestHelper
    //{
    //    private string endPoint;
    //    private string akid;
    //    private byte[] secret;
    //    private HMAC signer;

    //    private const string REQUEST_URI = "/onca/xml";
    //    private const string REQUEST_METHOD = "GET";

    //    /*
    //     * Use this constructor to create the object. The AWS credentials are available on
    //     * http://aws.amazon.com
    //     * 
    //     * The destination is the service end-point for your application:
    //     *  US: ecs.amazonaws.com
    //     *  JP: ecs.amazonaws.jp
    //     *  UK: ecs.amazonaws.co.uk
    //     *  DE: ecs.amazonaws.de
    //     *  FR: ecs.amazonaws.fr
    //     *  CA: ecs.amazonaws.ca
    //     */
    //    public SignedRequestHelper(string awsAccessKeyId, string awsSecretKey, string destination) {
    //        endPoint = destination.ToLower();
    //        akid = awsAccessKeyId;
    //        secret = Encoding.UTF8.GetBytes(awsSecretKey);
    //        signer = new HMACSHA256(secret);
    //    }

    //    /*
    //     * Sign a request in the form of a Dictionary of name-value pairs.
    //     * 
    //     * This method returns a complete URL to use. Modifying the returned URL
    //     * in any way invalidates the signature and Amazon will reject the requests.
    //     */
    //    public string Sign(IDictionary<string, string> request) {
    //        // Use a SortedDictionary to get the parameters in naturual byte order, as
    //        // required by AWS.
    //        ParamComparer pc = new ParamComparer();
    //        SortedDictionary<string, string> sortedMap = new SortedDictionary<string, string>(request, pc);

    //        // Add the AWSAccessKeyId and Timestamp to the requests.
    //        sortedMap["AWSAccessKeyId"] = akid;
    //        sortedMap["Timestamp"] = GetTimestamp();

    //        // Get the canonical query string
    //        string canonicalQS = ConstructCanonicalQueryString(sortedMap);

    //        // Derive the bytes needs to be signed.
    //        StringBuilder builder = new StringBuilder();
    //        builder.Append(REQUEST_METHOD)
    //            .Append("\n")
    //            .Append(endPoint)
    //            .Append("\n")
    //            .Append(REQUEST_URI)
    //            .Append("\n")
    //            .Append(canonicalQS);

    //        string stringToSign = builder.ToString();
    //        byte[] toSign = Encoding.UTF8.GetBytes(stringToSign);

    //        // Compute the signature and convert to Base64.
    //        byte[] sigBytes = signer.ComputeHash(toSign);
    //        string signature = Convert.ToBase64String(sigBytes);

    //        // now construct the complete URL and return to caller.
    //        StringBuilder qsBuilder = new StringBuilder();
    //        qsBuilder.Append("http://")
    //            .Append(endPoint)
    //            .Append(REQUEST_URI)
    //            .Append("?")
    //            .Append(canonicalQS)
    //            .Append("&Signature=")
    //            .Append(PercentEncodeRfc3986(signature));

    //        return qsBuilder.ToString();
    //    }

    //    /*
    //     * Sign a request in the form of a query string.
    //     * 
    //     * This method returns a complete URL to use. Modifying the returned URL
    //     * in any way invalidates the signature and Amazon will reject the requests.
    //     */
    //    public string Sign(string queryString) {
    //        IDictionary<string, string> request = CreateDictionary(queryString);
    //        return Sign(request);
    //    }

    //    /*
    //     * Current time in IS0 8601 format as required by Amazon
    //     */
    //    private string GetTimestamp() {
    //        DateTime currentTime = DateTime.UtcNow;
    //        string timestamp = currentTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
    //        return timestamp;
    //    }

    //    /*
    //     * Percent-encode (URL Encode) according to RFC 3986 as required by Amazon.
    //     * 
    //     * This is necessary because .NET's HttpUtility.UrlEncode does not encode
    //     * according to the above standard. Also, .NET returns lower-case encoding
    //     * by default and Amazon requires upper-case encoding.
    //     */
    //    private string PercentEncodeRfc3986(string str) {
    //        str = HttpUtility.UrlEncode(str, Encoding.UTF8);
    //        str = str.Replace("'", "%27").Replace("(", "%28").Replace(")", "%29").Replace("*", "%2A").Replace("!", "%21").Replace("%7e", "~").Replace("+", "%20");

    //        StringBuilder sbuilder = new StringBuilder(str);
    //        for (int i = 0; i < sbuilder.Length; i++) {
    //            if (sbuilder[i] == '%') {
    //                if (Char.IsLetter(sbuilder[i + 1]) || Char.IsLetter(sbuilder[i + 2])) {
    //                    sbuilder[i + 1] = Char.ToUpper(sbuilder[i + 1]);
    //                    sbuilder[i + 2] = Char.ToUpper(sbuilder[i + 2]);
    //                }
    //            }
    //        }
    //        return sbuilder.ToString();
    //    }

    //    /*
    //     * Convert a query string to corresponding dictionary of name-value pairs.
    //     */
    //    private IDictionary<string, string> CreateDictionary(string queryString) {
    //        Dictionary<string, string> map = new Dictionary<string, string>();

    //        string[] requestParams = queryString.Split('&');

    //        for (int i = 0; i < requestParams.Length; i++) {
    //            if (requestParams[i].Length < 1) {
    //                continue;
    //            }

    //            char[] sep = { '=' };
    //            string[] param = requestParams[i].Split(sep, 2);
    //            for (int j = 0; j < param.Length; j++) {
    //                param[j] = HttpUtility.UrlDecode(param[j], Encoding.UTF8);
    //            }
    //            switch (param.Length) {
    //                case 1: {
    //                        if (requestParams[i].Length >= 1) {
    //                            if (requestParams[i].ToCharArray()[0] == '=') {
    //                                map[""] = param[0];
    //                            }
    //                            else {
    //                                map[param[0]] = "";
    //                            }
    //                        }
    //                        break;
    //                    }
    //                case 2: {
    //                        if (!string.IsNullOrEmpty(param[0])) {
    //                            map[param[0]] = param[1];
    //                        }
    //                    }
    //                    break;
    //            }
    //        }

    //        return map;
    //    }

    //    /*
    //     * Consttuct the canonical query string from the sorted parameter map.
    //     */
    //    private string ConstructCanonicalQueryString(SortedDictionary<string, string> sortedParamMap) {
    //        StringBuilder builder = new StringBuilder();

    //        if (sortedParamMap.Count == 0) {
    //            builder.Append("");
    //            return builder.ToString();
    //        }

    //        foreach (KeyValuePair<string, string> kvp in sortedParamMap) {
    //            builder.Append(PercentEncodeRfc3986(kvp.Key));
    //            builder.Append("=");
    //            builder.Append(PercentEncodeRfc3986(kvp.Value));
    //            builder.Append("&");
    //        }
    //        string canonicalString = builder.ToString();
    //        canonicalString = canonicalString.Substring(0, canonicalString.Length - 1);
    //        return canonicalString;
    //    }
    //}  

    /*
     * To help the SortedDictionary order the name-value pairs in the correct way.
     */
    class ParamComparer : IComparer<string>
    {
        public int Compare(string p1, string p2) {
            return string.CompareOrdinal(p1, p2);
        }
    }
}
