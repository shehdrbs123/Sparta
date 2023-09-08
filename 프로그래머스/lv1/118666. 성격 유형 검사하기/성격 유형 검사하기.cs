using System;
using System.Collections.Generic;
public class Solution {
    public string solution(string[] survey, int[] choices) {
        string answer = "";
        Dictionary<string,int> surveySum = new Dictionary<string,int>();
        
        MakeResult(surveySum,survey,choices);
        MakeYourStyle(surveySum,out answer);
        
        return answer;
    }
    private void MakeResult( Dictionary<string,int> surveySum,string[] survey, int[] choices)
    {
        for(int i=0;i<survey.Length;i++)
        {
            string style = survey[i];
            int score = choices[i]-4;
            
            int sum = 0;
            if(surveySum.TryGetValue(style,out sum))
            {
                surveySum[style] += score;
            }
            else
            {
                surveySum.Add(style,score);
            }
        }
    }
    
    private void MakeYourStyle(Dictionary<string,int> surveySum,out string answer)
    {
        string[] arStyles = {"RT","CF","JM","AN"};
        int[] sumResult = new int[arStyles.Length];
        char[] result= {'R','C','J','A'};
        
        for(int i=0;i<arStyles.Length;i++)
        {
            int score1=0,score2=0;
            string baseArStyle = arStyles[i];
            
            char[] reverseTemp = baseArStyle.ToCharArray();
            Array.Reverse(reverseTemp);
            string reverseArStyle = new String(reverseTemp);
            
            surveySum.TryGetValue(baseArStyle, out score1);
            
            surveySum.TryGetValue(reverseArStyle,out score2);
            
            //Console.WriteLine("{0} : {1} {2} : {3}",baseArStyle,score1, reverseArStyle,score2);
            sumResult[i] = score1 - score2;
        }
        
        for(int i=0;i<sumResult.Length; i++)
        {
            if(sumResult[i] > 0)
            {
                result[i] = arStyles[i][1];
            }
        }
        //foreach(KeyValuePair<string,int> a in surveySum)
        //    Console.WriteLine("key {0}, value {1}",a.Key, a.Value);
        
        answer = new String(result);
    }
    
}