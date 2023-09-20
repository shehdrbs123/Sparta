using System;
public class Solution {
    long[] dp  = new long[2001];
    public long solution(int n) {
        long answer = 0;

        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 3;
        dp[4] = 5;
        
        for(int i=5;i<=2000;++i)
        {
            dp[i] = (dp[i-1] + dp[i-2]) % 1234567;
            
        }
        Console.WriteLine(dp[6]);
        answer = dp[n];
        
        return answer;
    }
}