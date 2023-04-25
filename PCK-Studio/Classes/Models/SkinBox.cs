﻿using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PckStudio.Classes.Models
{
	public class SkinBox
	{
		public string Parent;
		public Vector3 Pos;
		public Vector3 Size;
		public float U, V;
		public bool HideWithArmor;
		public bool Mirror;
		public float Inflation;
		public SkinBox(string input)
		{
			try
			{
				string[] arguments = Regex.Split(input, @"\s+"); // split by whitespace

				int old_length = arguments.Length - 1;

				Console.WriteLine($"Old length - {old_length}");

				Array.Resize<string>(ref arguments, 12);

				for (int x = 11; x > old_length; x--)
				{
					arguments[x] = "0"; // set any missing arguments to '0'
				}

				Parent = arguments[0].ToUpper(); // just in case a box has all lower, the editor still parses correctly

				Pos = new Vector3(float.Parse(arguments[1]), float.Parse(arguments[2]), float.Parse(arguments[3]));
				Size = new Vector3(float.Parse(arguments[4]), float.Parse(arguments[5]), float.Parse(arguments[6]));
				U = float.Parse(arguments[7]);
				V = float.Parse(arguments[8]);
				HideWithArmor = Convert.ToBoolean(int.Parse(arguments[9]));
				Mirror = Convert.ToBoolean(int.Parse(arguments[10]));
				Inflation = float.Parse(arguments[11]);
			}
			catch (FormatException fex)
			{
				MessageBox.Show($"A Format Exception was thrown\nFailed to parse BOX value\n{fex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch (IndexOutOfRangeException iex) // this should be MUCH more rare now
			{
				MessageBox.Show($"A box paramater was out of range\nFailed to parse BOX value\n{iex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch (Exception ex)
			{
				Parent = string.Empty;
			}
		}

	}
}
