public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var frequencyMap = nums.GroupBy(x => x)
                               .ToDictionary(g => g.Key, g => (long) g.Count());
        var minHeap = new PriorityQueue<int, long>();
        int count = 0;
        foreach (var kvp in frequencyMap)
        {
            if(count >= k && minHeap.TryPeek(out _, out var frequency))
            {
                if(kvp.Value > frequency)
                {
                    minHeap.Dequeue();
                    minHeap.Enqueue(kvp.Key, kvp.Value);
                    continue;
                }    
                
            }
            else
            {
              minHeap.Enqueue(kvp.Key, kvp.Value);
              count++;  
            }
            
        }    
        return ToArrayFromHeap(minHeap);
        
    }
    public int[] ToArrayFromHeap(PriorityQueue<int, long> queue)
    {
        var result = new List<int>();

        // Dequeue all elements into a list
        while (queue.Count > 0)
        {
            result.Add(queue.Dequeue());
        }

        return result.ToArray();
    }
}