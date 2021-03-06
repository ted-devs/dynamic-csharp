using System.Collections.Generic;
using System.Linq;
using System;

namespace StringConstructor 
{
    class AllConstruct
    {
        public static List<List<string>> allConstruct(string target, List<string> wordBank) 
        {
            if (target == "") return new List<List<string>>() {new List<string>()};

            List<List<string>> result = new List<List<string>>();

            foreach (string word in wordBank)
            {
                if (target.IndexOf(word) == 0) 
                {
                    string suffix = target.Substring(word.Length);
                    List<List<string>> waysToTarget = allConstruct(suffix, wordBank);
                    waysToTarget.ForEach(s => 
                    {
                        s.Insert(0, word);
                        result.Add(s);
                    });
                }
            }
            
            return result;
        } 

        public static List<List<string>> allConstruct_memo(string target, List<string> wordBank, Dictionary<string, List<List<string>>> memo) 
        {
            if (memo.ContainsKey(target)) return memo[target];

            List<List<string>> result = new List<List<string>>();

            foreach (string word in wordBank)
            {
                if (target.IndexOf(word) == 0) 
                {
                    string suffix = target.Substring(word.Length);
                    List<List<string>> waysToTarget = allConstruct_memo(suffix, wordBank, memo);
                    waysToTarget.ForEach(s => 
                    {
                        s.Insert(0, word);
                        result.Add(s);
                    });
                }
            }
            
            memo.Add(target, result);
            return result;
        }

        public static string printer(List<List<string>> arr) {
            string result = "";
            arr.ForEach(item => {
                result += "{";
                item.ForEach(x => {
                    result += $"{x},";
                });
                result += "}, ";
            });

            return result;
        }
    }
}