//
//  * To help the SortedDictionary order the name-value pairs in the correct way.
//  
//C# TO JAVA CONVERTER TODO TASK: The interface type was changed to the closest equivalent Java type, but the methods implemented will need adjustment:
public class ParamComparer implements java.util.Comparator<String>
{
	public final int Compare(String p1, String p2)
	{
		return String.CompareOrdinal(p1, p2);
	}
}