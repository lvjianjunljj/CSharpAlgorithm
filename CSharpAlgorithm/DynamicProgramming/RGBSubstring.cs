/*
 * Problem link: https://codeforces.com/problemset/problem/1196/D1
 * Problem description:
 * D1. RGB Substring (easy version)
time limit per test2 seconds
memory limit per test256 megabytes
inputstandard input
outputstandard output
The only difference between easy and hard versions is the size of the input.

You are given a string s consisting of n characters, each character is 'R', 'G' or 'B'.

You are also given an integer k. Your task is to change the minimum number of characters in the initial string s so that after the changes there will be a string of length k that is a substring of s, and is also a substring of the infinite string "RGBRGBRGB ...".

A string a is a substring of string b if there exists a positive integer i such that a1=bi, a2=bi+1, a3=bi+2, ..., a|a|=bi+|a|−1. For example, strings "GBRG", "B", "BR" are substrings of the infinite string "RGBRGBRGB ..." while "GR", "RGR" and "GGG" are not.

You have to answer q independent queries.

Input
The first line of the input contains one integer q (1≤q≤2000) — the number of queries. Then q queries follow.

The first line of the query contains two integers n and k (1≤k≤n≤2000) — the length of the string s and the length of the substring.

The second line of the query contains a string s consisting of n characters 'R', 'G' and 'B'.

It is guaranteed that the sum of n over all queries does not exceed 2000 (∑n≤2000).

Output
For each query print one integer — the minimum number of characters you need to change in the initial string s so that after changing there will be a substring of length k in s that is also a substring of the infinite string "RGBRGBRGB ...".

Example
inputCopy
3
5 2
BGGGG
5 3
RBRGR
5 5
BBBRR
outputCopy
1
0
3
Note
In the first example, you can change the first character to 'R' and obtain the substring "RG", or change the second character to 'R' and obtain "BR", or change the third, fourth or fifth character to 'B' and obtain "GB".
 */
namespace CSharpAlgorithm.DynamicProgramming
{
    using System;

    class RGBSubstring
    {
        static void MainMethod()
        {
            int q = int.Parse(Console.ReadLine());
            for (int i = 0; i < q; i++)
            {
                string lineStr = Console.ReadLine();
                string[] strList = lineStr.Split(new char[] { ' ' });
                int n = int.Parse(strList[0]);
                int k = int.Parse(strList[1]);
                string s = Console.ReadLine();
                char[] charArray = s.ToCharArray();
                Console.WriteLine(GetChangeCount(charArray, n, k));
            }



            Console.ReadKey();
        }
        static char[] CHARS = { 'R', 'G', 'B' };
        private static int GetChangeCount(char[] charArray, int n, int k)
        {
            int res = int.MaxValue;
            int[,] precomp = new int[3, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (CHARS[(i + j) % 3] != charArray[i])
                    {
                        precomp[j, i]++;
                    }
                    if (i != 0)
                    {
                        precomp[j, i] += precomp[j, i - 1];
                    }
                }
            }
            for (int i = 0; i < n - k + 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int start = i == 0 ? 0 : precomp[j, i - 1];
                    int end = precomp[j, i + k - 1];
                    res = Math.Min(res, end - start);
                }
            }
            return res;
        }


    }
}
