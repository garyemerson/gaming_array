using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        int g = Convert.ToInt32(Console.ReadLine());
        for(int i = 0; i < g; i++){
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> nums = Console.ReadLine().Split(' ').Select<string, int>(s => int.Parse(s)).ToList();
            // Console.WriteLine("nums is {{ {0} }}", string.Join(", ", nums));
            Console.WriteLine(getWinner(nums));
        }
    }

    private static string getWinner(List<int> nums) {
        List<int> maxIndices = getMaxIndices(nums);
        // Console.WriteLine("maxIndices is {{ {0} }}", string.Join(", ", maxIndices));
        int numTurns = 0;
        int curr = nums.Count - 1;
        while (curr >= 0) {
            numTurns++;
            curr = maxIndices[curr] - 1;
        }
        if (numTurns % 2 == 0) {
            return "ANDY";
        } else {
            return "BOB";
        }
    }

    private static List<int> getMaxIndices(List<int> nums) {
        List<int> maxIndices = new List<int>(nums.Count);
        int currMaxIndex = 0;
        for (int i = 0; i < nums.Count; i++) {
            if (nums[i] > nums[currMaxIndex]) {
                maxIndices.Add(i);
                currMaxIndex = i;
            } else {
                maxIndices.Add(currMaxIndex);
            }
        }
        return maxIndices;
    }
}
