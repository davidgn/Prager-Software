//-----------------------------------------------------------------------    signed request helper    -------------------------------------
public class SignedRequestHelper
{
	private String endPoint;
	private String akid;
	private byte[] secret;
	private HMAC signer;

	private static final String REQUEST_URI = "/onca/xml";
	private static final String REQUEST_METHOD = "GET";

//    
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
//     
	public SignedRequestHelper(String awsAccessKeyId, String awsSecretKey, String destination)
	{
		this.endPoint = destination.toLowerCase();
		this.akid = awsAccessKeyId;
		this.secret = Encoding.UTF8.GetBytes(awsSecretKey);
		this.signer = new HMACSHA256(this.secret);
	}

//    
//     * Sign a request in the form of a Dictionary of name-value pairs.
//     * 
//     * This method returns a complete URL to use. Modifying the returned URL
//     * in any way invalidates the signature and Amazon will reject the requests.
//     
	public final String Sign(java.util.Map<String, String> request)
	{
		// Use a SortedDictionary to get the parameters in naturual byte order, as
		// required by AWS.
		ParamComparer pc = new ParamComparer();
		java.util.TreeMap<String, String> sortedMap = new java.util.TreeMap<String, String>(request, pc);

		// Add the AWSAccessKeyId and Timestamp to the requests.
		sortedMap.put("AWSAccessKeyId", this.akid);
		sortedMap.put("Timestamp", this.GetTimestamp());

		// Get the canonical query string
		String canonicalQS = this.ConstructCanonicalQueryString(sortedMap);

		// Derive the bytes needs to be signed.
		StringBuilder builder = new StringBuilder();
		builder.append(REQUEST_METHOD).Append("\n").Append(this.endPoint).Append("\n").Append(REQUEST_URI).Append("\n").Append(canonicalQS);

		String stringToSign = builder.toString();
		byte[] toSign = Encoding.UTF8.GetBytes(stringToSign);

		// Compute the signature and convert to Base64.
		byte[] sigBytes = signer.ComputeHash(toSign);
		String signature = Convert.ToBase64String(sigBytes);

		// now construct the complete URL and return to caller.
		StringBuilder qsBuilder = new StringBuilder();
		qsBuilder.append("http://").Append(this.endPoint).Append(REQUEST_URI).Append("?").Append(canonicalQS).Append("&Signature=").Append(this.PercentEncodeRfc3986(signature));

		return qsBuilder.toString();
	}

//    
//     * Sign a request in the form of a query string.
//     * 
//     * This method returns a complete URL to use. Modifying the returned URL
//     * in any way invalidates the signature and Amazon will reject the requests.
//     
	public final String Sign(String queryString)
	{
		java.util.Map<String, String> request = this.CreateDictionary(queryString);
		return this.Sign(request);
	}

//    
//     * Current time in IS0 8601 format as required by Amazon
//     
	private String GetTimestamp()
	{
		java.util.Date currentTime = java.util.Date.UtcNow;
		String timestamp = currentTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
		return timestamp;
	}

//    
//     * Percent-encode (URL Encode) according to RFC 3986 as required by Amazon.
//     * 
//     * This is necessary because .NET's HttpUtility.UrlEncode does not encode
//     * according to the above standard. Also, .NET returns lower-case encoding
//     * by default and Amazon requires upper-case encoding.
//     
	private String PercentEncodeRfc3986(String str)
	{
		str = HttpUtility.UrlEncode(str, System.Text.Encoding.UTF8);
		str = str.replace("'", "%27").Replace("(", "%28").Replace(")", "%29").Replace("*", "%2A").Replace("!", "%21").Replace("%7e", "~").Replace("+", "%20");

		StringBuilder sbuilder = new StringBuilder(str);
		for (int i = 0; i < sbuilder.length(); i++)
		{
			if (sbuilder.charAt(i) == '%')
			{
				if (Character.isDigit(sbuilder.charAt(i + 1)) && Character.isLetter(sbuilder.charAt(i + 2)))
				{
					sbuilder.setCharAt(i + 2, Character.toUpperCase(sbuilder.charAt(i + 2)));
				}
			}
		}
		return sbuilder.toString();
	}

//    
//     * Convert a query string to corresponding dictionary of name-value pairs.
//     
	private java.util.Map<String, String> CreateDictionary(String queryString)
	{
		java.util.HashMap<String, String> map = new java.util.HashMap<String, String>();

		String[] requestParams = queryString.split("[&]", -1);

		for (int i = 0; i < requestParams.length; i++)
		{
			if (requestParams[i].length() < 1)
			{
				continue;
			}

			char[] sep = { '=' };
			String[] param = requestParams[i].split(sep, 2);
			for (int j = 0; j < param.length; j++)
			{
				param[j] = HttpUtility.UrlDecode(param[j], System.Text.Encoding.UTF8);
			}
			switch (param.length)
			{
				case 1:
					{
						if (requestParams[i].length() >= 1)
						{
							if (requestParams[i].toCharArray()[0] == '=')
							{
								map.put("", param[0]);
							}
							else
							{
								map.put(param[0], "");
							}
						}
						break;
//C# TO JAVA CONVERTER TODO TASK: An unrecognized statement block ends here
					}
				case 2:
					{
						if (!DotNetToJavaStringHelper.isNullOrEmpty(param[0]))
						{
							map.put(param[0], param[1]);
						}
//C# TO JAVA CONVERTER TODO TASK: An unrecognized statement block ends here
					}
					break;
			}
		}

		return map;
	}

//    
//     * Consttuct the canonical query string from the sorted parameter map.
//     
	private String ConstructCanonicalQueryString(java.util.TreeMap<String, String> sortedParamMap)
	{
		StringBuilder builder = new StringBuilder();

		if (sortedParamMap.isEmpty())
		{
			builder.append("");
			return builder.toString();
		}

		for (java.util.Map.Entry<String, String> kvp : sortedParamMap)
		{

			builder.append(this.PercentEncodeRfc3986(kvp.getKey()));
			builder.append("=");
			builder.append(this.PercentEncodeRfc3986(kvp.getValue()));
			builder.append("&");
		}
		String canonicalString = builder.toString();
		canonicalString = canonicalString.substring(0, canonicalString.length() - 1);
		return canonicalString;
	}
} // end signedRequestHelper