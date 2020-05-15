using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Leaderboards
{
	internal class Assets
	{
		public static Texture2D[] COLUMN_ICONS;

		public static void LoadContent(ContentManager Content)
		{
			COLUMN_ICONS = new Texture2D[32];
			string str = "UI/Leaderboards/";
			for (int num = 31; num >= 0; num--)
			{
				string str2 = ((Column)num).ToString().ToLower();
				string assetName = str + str2;
				COLUMN_ICONS[num] = Content.Load<Texture2D>(assetName);
			}
		}
	}
}
