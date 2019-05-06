using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
	public abstract class Skin

	{
		public abstract void Clear();
		public abstract void Render(string str);
	}
	public class ClassicSkin : Skin
	{
		public override void Clear()
		{
			Console.Clear();
		}

		public override void Render(string str)
		{
			Console.WriteLine(str);
		}
	}
	public class ColorSkin : Skin
	{
		public override void Clear()
		{
			Console.Clear();
		}

		public override void Render(string str)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine($"{str}");
		}
	}
	public class RandomColorSkin : Skin
	{
		Random rand = new Random();
		ConsoleColor Color { get; set; }
		
		public override void Clear()
		{
			Console.Clear();
			char ch = Encoding.GetEncoding(437).GetChars(Encoding.ASCII.GetBytes("U+058D"))[0];
			string result = new String(ch, 30);
			Console.WriteLine($"C{result}");
		}

		public override void Render(string str)
		{
			var consoleColors = Enum.GetValues(typeof(ConsoleColor));
			Console.ForegroundColor = (ConsoleColor)consoleColors.GetValue(rand.Next(15));
			Console.WriteLine($"{str}");
		}
	}
}
