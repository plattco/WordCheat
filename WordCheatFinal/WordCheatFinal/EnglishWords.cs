using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace WordCheatFinal
{
	public class EnglishWords
	{
		public string[] lines;
		public EnglishWords(string fileName)
		{
			var assembly = IntrospectionExtensions.GetTypeInfo(typeof(EnglishWords)).Assembly;
			string namespaceName = "WordCheatFinal";
			Stream stream = assembly.GetManifestResourceStream(namespaceName + "." + fileName);
			string text = "";
			using(var dictReader = new System.IO.StreamReader(stream))
            {
				text = dictReader.ReadToEnd();
            }
			lines = text.Split('\r','\n');
		}

		public bool isLegal(string word)
		{
			if (Array.Exists(lines, element => element == word))
			{
				return true;
			}
			return false;
		}

		//find all possible permutations of string letters
		//not sure how to find permutations of a certain length
		//put these permutations in an array
		//use for loop to iterate over every word in dictionary
		//use nested loop to iterate over every permuation in the permutation array
		//for each nested iteration compare the permutation to the word in the array
		//if it is equal add the word to the result array

		//or

		//create array to hold results
		//loop through every word in lines array
		//check if the string letters contains every letter in the word
		//if it is true then add it to results array
		public List<string> AvailableWords(string letters, int len, bool allowDup)
		{
			List<string> results = new List<string>();
			for (int i = 0; i < lines.Length; i++)
			{
				string candidate = lines[i];
				if (candidate.Length == len)
				{
					bool accepted = true;
					int found;
					string letterTemp = letters;
					foreach (char c in candidate)
					{
						found = letterTemp.IndexOf(c);
						if (found != -1 && allowDup == false)
						{
							letterTemp = letterTemp.Remove(found, 1);
						}
						else if (found == -1)
						{
							accepted = false;
							break;
						}
					}
					if (accepted)
					{
						results.Add(candidate);
					}
				}
			}
			return results;

			/*
			 * string[] results;
			for (int i = 0; i > lines.Length; i++)
				string candidate = lines[i];
				if(candidate.Length == len)
				{
					foreach(char c in candidate)
					{
						if (!(letters.Contains((string)c)))
						{
							// results = results + lines[i];
						}
						else
						{
						results = results + candidate;
						}
					}
				}*/
			/*
			  for(int i = 0; i > lines.Length; i++)
			{
				if (lines[i].Length == len)
				{
					for (int j = 0; j > len; j++)
					{
						if (lines[j] == letters[i])
						{
							results = results + lines[j];
						}
					}
				}
			}*/
		}


		public List<string> NYTSpellingBee(string outerRingOfLetters, char centerLetter)
		{
			return null;
		}
	}
}
