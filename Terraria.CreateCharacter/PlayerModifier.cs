using Microsoft.Xna.Framework;

namespace Terraria.CreateCharacter;

internal class PlayerModifier
{
	public static void Hair(Player p, int val)
	{
		p.hair = (byte)val;
	}

	public static void HairColor(Player p, Color val)
	{
		p.hairColor = val;
	}

	public static void Shirt(Player p, Color val)
	{
		p.shirtColor = val;
	}

	public static void Undershirt(Player p, Color val)
	{
		p.underShirtColor = val;
	}

	public static void Pants(Player p, Color val)
	{
		p.pantsColor = val;
	}

	public static void Shoes(Player p, Color val)
	{
		p.shoeColor = val;
	}

	public static void Gender(Player p, bool val)
	{
		p.male = val;
	}

	public static void Difficulty(Player p, byte val)
	{
		p.difficulty = val;
	}

	public static void Eyes(Player p, Color val)
	{
		p.eyeColor = val;
	}

	public static void Skin(Player p, Color val)
	{
		p.skinColor = val;
	}
}
