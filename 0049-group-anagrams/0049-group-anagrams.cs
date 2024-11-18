public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        if (strs.Length == 0)
        {
            return new List<IList<string>>(); // Return an empty list for an empty input.
        }
        
        // Dictionary to group anagrams
        Dictionary<string, List<string>> result = new();

        foreach (var item in strs)
        {
            int[] charMask = new int[26]; // Array to count characters
            foreach (var chara in item)
            {
                charMask[chara - 'a']++;
            }
            
            // Convert the character count array to a unique string key
            string key = string.Join(",", charMask);
            if (result.ContainsKey(key))
            {
                result[key].Add(item); // Add the string to the existing group
            }
            else
            {
                result.Add(key, new List<string> { item }); // Create a new group
            }
        }

        // Convert the dictionary values to IList<IList<string>> format
        return new List<IList<string>>(result.Values);
    }
}
