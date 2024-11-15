using Microsoft.Xna.Framework;

namespace Terraria;

public static class Credits
{
	private const int SCROLL_SPEED = 2;

	private const string THE_CREDITS = "<c>\r\n<h><t>Published by 505 Games</t></h>\r\n<i>505 Games</i> and the <i>505 Games logo</i> are registered trademarks of <i>505 Games</i>.\r\nAll rights reserved.\r\n\r\n\r\n<h><t>Re-Logic</t></h>\r\n\r\n<i>Creator/Lead Developer</i>\r\n<t>Andrew \"Redigit\" Spinks</t>\r\n\r\n<i>Graphic Design</i>\r\n<t>Andrew \"Redigit\" Spinks\r\nFinn \"Tiy\" Brice\r\nGabriel \"Red Yoshi\" Kiesshau\r\nJamison \"Lazure\" Hayes</t>\r\n\r\n<i>Creative Consultation/Production Support</i>\r\n<t>Jeremy \"Blue\" Guerrette\r\nDavid \"D-Town\" Phelps\r\nDustin \"Splugen\" Gunter</t>\r\n\r\n<i>Business Director</i>\r\n<t>David \"D-Town\" Phelps</t>\r\n\r\n<i>Beta/QA Testers</i>\r\nGabriel \"Red Yoshi\" Kiesshau\r\nKyle \"Kley\" Hodge\r\nSteven \"Twitchy\" French\r\nBrian \"TGS\" Gilliford\r\nCheah Jun Siang\r\nZach \"Olink\" Piispanen\r\nTyler \"BurnZeZ\" Whiteman\r\nLisa \"Lils\" Chiu\r\nAtri \"m4sterbr0s\" Maharaj\r\nKaleb \"JesusLlama\" Regalado\r\nJamison \"Lazure\" Hayes\r\nIgor \"Conker\" Magi Marinho\r\nElias \"Elbow\" Naddaf\r\nValtteri Nieminen\r\nJonathan \"FallingSnow\" Poholarz\r\nBrandon Thomas\r\nWilliam \"Ignoritus\" Coffey\r\nMike \"Trinity Flash\" Dunn\r\nRyan \"Namyrr\" Le\r\nDaniel \"DMF\" Faria\r\nRobert \"qig\" Buchanan\r\nAlexaunder \"as303298\" Savoy\r\nAlexander \"Vandarx\" Reaves\r\nBalázs \"Mamaluigi\" Makai\r\nDaniel \"Garro\" Berner \r\nTyler \"Quill\" Warr\r\nAndrew \"Andydark\" Windmiller\r\n\r\n<h>Special Thanks to</h>\r\n<i>Kane Hart</i>, all the guys and gals at <i>Curse</i> and <i>TerrariaOnline.com</i>,\r\nthe IRC operators, the LPers, and all the fans for your passion and continued support!\r\n\r\n\r\n\r\n<h><t>Engine Software</t></h>\r\n\r\n\r\n<i>Executive Producer</i>\r\n<t>Ivo Wubbels</t>\r\n\r\n\r\n<i>Producer</i>\r\n<t>Jeroen Schmitz</t>\r\n\r\n\r\n<i>Lead Programmer</i>\r\n<t>Jan-Lieuwe Koopmans</t>\r\n\r\n\r\n<i>Programmer</i>\r\n<t>Bart Veldstra</t>\r\n\r\n\r\n<i>Art Director</i>\r\n<t>Sandra Meijer</t>\r\n\r\n\r\n<i>Artists</i>\r\n<t>Aaron Willemsen\r\nMarco Willemsen</t>\r\n\r\n\r\n<i>Game Design and testing</i>\r\n<t>Hiroshi Wijmer</t>\r\n\r\n\r\n\r\n\r\n\r\n<h><t>505 Games s.r.l</t></h>\r\n\r\n\r\n<h>Production:</h>\r\n\r\n<i>Producer</i>\r\n<t>David Welch</t>\r\n\r\n\r\n<i>Production Coordinator</i>\r\n<t>Michael Greening</t>\r\n\r\n\r\n<i>Development Director</i>\r\n<t>Michael Meischeid</t>\r\n\r\n\r\n<i>Submissions Managers</i>\n<t>Chiara Pasquini\r\nMarcello Monti\r\nDavide Racah\nJohn Sweeney</t>\r\n\r\n\r\n<i>QA Manager</i>\r\n<t>Esther Partschefeld</t>\r\n\r\n\r\n<i>Production Manager</i>\r\n<t>Stefano Stalla</t>\r\n\r\n\r\n<i>Business Development Associate</i>\r\n<t>Kimberley Rizzo</t>\r\n\r\n\r\n\r\n<h>Brand:</h>\r\n\r\n<i>Head Of Global Brand</i>\r\n<t>Tim Woodley</t>\r\n\r\n<i>Global Brand Manager</i>\r\n<t>John Merchant</t>\r\n\r\n<i>Assistant Brand Manager</i>\r\n<t>Rodrigo De La Pedraja</t>\r\n\r\n<i>Global Brand Director</i>\r\n<t>Melissa Menton</t>\r\n\r\n\r\n\r\n<h>Creative Services:</h>\r\n\r\n<i>Creative Services Designers</i>\r\n<t>Rebecca Meyer\r\nAndrea Quinteri</t>\r\n\r\n<i>Studio Manager</i>\r\n<t>James Howes</t>\r\n\r\n<i>Creative Director</i>\r\n<t>Mark Stevens</t>\r\n\r\n\r\n\r\n<h>Commercial, Marketing & PR:</h>\r\n\r\n<i>PR Director, North America</i>\r\n<t>Lisa Fields</t>\r\n\r\n<i>European PR Manager</i>\r\n<t>Greg Jones</t>\r\n\r\n<i>Senior Marketing Services Manager</i>\r\n<t>Howard Liebeskind</t>\r\n\r\n\r\n\r\n<h>Operations:</h>\r\n\r\n<i>Publishing Manager</i>\r\n<t>Silvana Greenfield</t>\r\n\r\n<i>Sales Operations Analyst</i>\r\n<t>Dawn-Marie Sable</t>\r\n\r\n\r\n\r\n<h>Management</h>\r\n\r\n<i>President, 505 Games Inc</i>\r\n<t>Ian Howe</t>\r\n\r\n<i>VP of Operations</i>\r\n<t>Nic Ashford</t>\r\n\r\n<i>VP of Sales</i>\r\n<t>Gary Kinnsch</t>\n\n\n\n<h>Functional QA</h>\n\n<t>EC-i\nGlobalStep LLC</t>\n\n<h>Localisation QA</h>\n\n<t>GTL Media</t>\n\n<h>Translation</h>\n\r\n<t>Translate Plus Limited\r\n\r\n\r\n\r\n\r\n\r\n\r\n<i>Thanks for playing!\r\n";

	private static CompiledText text;

	private static int scrollY;

	public static void Init()
	{
		if (text == null)
		{
			text = new CompiledText("<c>\r\n<h><t>Published by 505 Games</t></h>\r\n<i>505 Games</i> and the <i>505 Games logo</i> are registered trademarks of <i>505 Games</i>.\r\nAll rights reserved.\r\n\r\n\r\n<h><t>Re-Logic</t></h>\r\n\r\n<i>Creator/Lead Developer</i>\r\n<t>Andrew \"Redigit\" Spinks</t>\r\n\r\n<i>Graphic Design</i>\r\n<t>Andrew \"Redigit\" Spinks\r\nFinn \"Tiy\" Brice\r\nGabriel \"Red Yoshi\" Kiesshau\r\nJamison \"Lazure\" Hayes</t>\r\n\r\n<i>Creative Consultation/Production Support</i>\r\n<t>Jeremy \"Blue\" Guerrette\r\nDavid \"D-Town\" Phelps\r\nDustin \"Splugen\" Gunter</t>\r\n\r\n<i>Business Director</i>\r\n<t>David \"D-Town\" Phelps</t>\r\n\r\n<i>Beta/QA Testers</i>\r\nGabriel \"Red Yoshi\" Kiesshau\r\nKyle \"Kley\" Hodge\r\nSteven \"Twitchy\" French\r\nBrian \"TGS\" Gilliford\r\nCheah Jun Siang\r\nZach \"Olink\" Piispanen\r\nTyler \"BurnZeZ\" Whiteman\r\nLisa \"Lils\" Chiu\r\nAtri \"m4sterbr0s\" Maharaj\r\nKaleb \"JesusLlama\" Regalado\r\nJamison \"Lazure\" Hayes\r\nIgor \"Conker\" Magi Marinho\r\nElias \"Elbow\" Naddaf\r\nValtteri Nieminen\r\nJonathan \"FallingSnow\" Poholarz\r\nBrandon Thomas\r\nWilliam \"Ignoritus\" Coffey\r\nMike \"Trinity Flash\" Dunn\r\nRyan \"Namyrr\" Le\r\nDaniel \"DMF\" Faria\r\nRobert \"qig\" Buchanan\r\nAlexaunder \"as303298\" Savoy\r\nAlexander \"Vandarx\" Reaves\r\nBalázs \"Mamaluigi\" Makai\r\nDaniel \"Garro\" Berner \r\nTyler \"Quill\" Warr\r\nAndrew \"Andydark\" Windmiller\r\n\r\n<h>Special Thanks to</h>\r\n<i>Kane Hart</i>, all the guys and gals at <i>Curse</i> and <i>TerrariaOnline.com</i>,\r\nthe IRC operators, the LPers, and all the fans for your passion and continued support!\r\n\r\n\r\n\r\n<h><t>Engine Software</t></h>\r\n\r\n\r\n<i>Executive Producer</i>\r\n<t>Ivo Wubbels</t>\r\n\r\n\r\n<i>Producer</i>\r\n<t>Jeroen Schmitz</t>\r\n\r\n\r\n<i>Lead Programmer</i>\r\n<t>Jan-Lieuwe Koopmans</t>\r\n\r\n\r\n<i>Programmer</i>\r\n<t>Bart Veldstra</t>\r\n\r\n\r\n<i>Art Director</i>\r\n<t>Sandra Meijer</t>\r\n\r\n\r\n<i>Artists</i>\r\n<t>Aaron Willemsen\r\nMarco Willemsen</t>\r\n\r\n\r\n<i>Game Design and testing</i>\r\n<t>Hiroshi Wijmer</t>\r\n\r\n\r\n\r\n\r\n\r\n<h><t>505 Games s.r.l</t></h>\r\n\r\n\r\n<h>Production:</h>\r\n\r\n<i>Producer</i>\r\n<t>David Welch</t>\r\n\r\n\r\n<i>Production Coordinator</i>\r\n<t>Michael Greening</t>\r\n\r\n\r\n<i>Development Director</i>\r\n<t>Michael Meischeid</t>\r\n\r\n\r\n<i>Submissions Managers</i>\n<t>Chiara Pasquini\r\nMarcello Monti\r\nDavide Racah\nJohn Sweeney</t>\r\n\r\n\r\n<i>QA Manager</i>\r\n<t>Esther Partschefeld</t>\r\n\r\n\r\n<i>Production Manager</i>\r\n<t>Stefano Stalla</t>\r\n\r\n\r\n<i>Business Development Associate</i>\r\n<t>Kimberley Rizzo</t>\r\n\r\n\r\n\r\n<h>Brand:</h>\r\n\r\n<i>Head Of Global Brand</i>\r\n<t>Tim Woodley</t>\r\n\r\n<i>Global Brand Manager</i>\r\n<t>John Merchant</t>\r\n\r\n<i>Assistant Brand Manager</i>\r\n<t>Rodrigo De La Pedraja</t>\r\n\r\n<i>Global Brand Director</i>\r\n<t>Melissa Menton</t>\r\n\r\n\r\n\r\n<h>Creative Services:</h>\r\n\r\n<i>Creative Services Designers</i>\r\n<t>Rebecca Meyer\r\nAndrea Quinteri</t>\r\n\r\n<i>Studio Manager</i>\r\n<t>James Howes</t>\r\n\r\n<i>Creative Director</i>\r\n<t>Mark Stevens</t>\r\n\r\n\r\n\r\n<h>Commercial, Marketing & PR:</h>\r\n\r\n<i>PR Director, North America</i>\r\n<t>Lisa Fields</t>\r\n\r\n<i>European PR Manager</i>\r\n<t>Greg Jones</t>\r\n\r\n<i>Senior Marketing Services Manager</i>\r\n<t>Howard Liebeskind</t>\r\n\r\n\r\n\r\n<h>Operations:</h>\r\n\r\n<i>Publishing Manager</i>\r\n<t>Silvana Greenfield</t>\r\n\r\n<i>Sales Operations Analyst</i>\r\n<t>Dawn-Marie Sable</t>\r\n\r\n\r\n\r\n<h>Management</h>\r\n\r\n<i>President, 505 Games Inc</i>\r\n<t>Ian Howe</t>\r\n\r\n<i>VP of Operations</i>\r\n<t>Nic Ashford</t>\r\n\r\n<i>VP of Sales</i>\r\n<t>Gary Kinnsch</t>\n\n\n\n<h>Functional QA</h>\n\n<t>EC-i\nGlobalStep LLC</t>\n\n<h>Localisation QA</h>\n\n<t>GTL Media</t>\n\n<h>Translation</h>\n\r\n<t>Translate Plus Limited\r\n\r\n\r\n\r\n\r\n\r\n\r\n<i>Thanks for playing!\r\n", 864, UI.styleFontSmallOutline);
		}
		scrollY = 540;
	}

	public static void Update()
	{
		if (UI.main.IsBackButtonTriggered())
		{
			text = null;
			UI.main.PrevMenu();
		}
		else if (-scrollY < text.Height - 270 && !UI.main.IsUpButtonDown())
		{
			scrollY -= 2;
			if (UI.main.IsDownButtonDown())
			{
				scrollY -= 2;
			}
		}
	}

	public static void Draw()
	{
		text.Draw(Main.spriteBatch, new Rectangle(48, scrollY, 864, text.Height), new Color(255, 255, 255, 255), new Color(255, 212, 0, 255));
	}
}
