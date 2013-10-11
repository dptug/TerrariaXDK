// Type: Terraria.Lang
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Globalization;

namespace Terraria
{
  internal sealed class Lang
  {
    public static int lang = 0;
    public static string languageId = "en";
    public static string[] misc = new string[37];
    public static string[] menu = new string[113];
    public static string[] gen = new string[59];
    public static string[] inter = new string[80];
    public static string[] tip = new string[52];
    public static string[] dt = new string[4];
    public static readonly string[] CONTROLS_EN = new string[87]
    {
      (string) (object) '\x008C' + (object) "Select",
      (string) (object) '\x008D' + (object) "Back",
      (string) (object) '\x008D' + (object) "Close",
      (string) (object) '\x008A' + (object) "Change Storage Device",
      (string) (object) '\x008B' + (object) "Xbox LIVE Party",
      (string) (object) '\x008C' + (object) "Toggle Grappling Mode",
      (string) (object) '\x0083' + (object) "Ban World",
      (string) (object) '\x0085' + (object) "Map",
      "\x0080\x0081Zoom",
      (string) (object) '\x008C' + (object) "Toggle PvP",
      (string) (object) '\x008C' + (object) "Select Team",
      (string) (object) '\x008A' + (object) "Invite",
      (string) (object) '\x008B' + (object) "Invite Xbox LIVE Party",
      (string) (object) '\x008C' + (object) "Gamer card",
      (string) (object) '\x008C' + (object) "Create World",
      (string) (object) '\x008C' + (object) "Join",
      (string) (object) '\x008A' + (object) "Show gamer card",
      "\x0082\x0083Switch Item",
      "\x0082\x0083Switch Menu",
      (string) (object) '\x0080' + (object) "Grapple",
      (string) (object) '\x008E' + (object) "Grapple",
      (string) (object) '\x008D' + (object) "Use",
      (string) (object) '\x008D' + (object) "Talk",
      (string) (object) '\x008C' + (object) "Jump",
      (string) (object) '\x008B' + (object) "Inventory",
      (string) (object) '\x008A' + (object) "Drop",
      (string) (object) '\x008A' + (object) "Trash",
      (string) (object) '\x008A' + (object) "Sell",
      (string) (object) '\x0081' + (object) "Action",
      (string) (object) '\x0081' + (object) "Dig",
      (string) (object) '\x0081' + (object) "Chop",
      (string) (object) '\x0081' + (object) "Attack",
      (string) (object) '\x0081' + (object) "Hit",
      (string) (object) '\x0081' + (object) "Build",
      (string) (object) '\x0081' + (object) "Take One",
      (string) (object) '\x008C' + (object) "Take",
      (string) (object) '\x008C' + (object) "Place",
      (string) (object) '\x008C' + (object) "Equip",
      (string) (object) '\x008C' + (object) "Swap",
      (string) (object) '\x0081' + (object) "Equip",
      (string) (object) '\x0081' + (object) "Open",
      (string) (object) '\x008C' + (object) "Reforge",
      (string) (object) '\x008C' + (object) "Show Recipes",
      (string) (object) '\x008C' + (object) "Craft",
      (string) (object) '\x008A' + (object) "Show All",
      (string) (object) '\x008A' + (object) "Show Available",
      (string) (object) '\x008B' + (object) "Ingredients",
      (string) (object) '\x008B' + (object) "Recipes",
      "\x0080\x0081Switch Category",
      (string) (object) '\x0081' + (object) "Buy One",
      (string) (object) '\x008C' + (object) "Buy",
      (string) (object) '\x008C' + (object) "Sell",
      (string) (object) '\x008C' + (object) "Cancel Buff",
      (string) (object) '\x008C' + (object) "Assign to Room",
      (string) (object) '\x008A' + (object) "Check Housing",
      (string) (object) '\x008B' + (object) "Show Room Flags",
      (string) (object) '\x008B' + (object) "Hide Room Flags",
      "Gender",
      "Difficulty",
      "Hair Type",
      "Hair Color",
      "Vest Color",
      "Shirt Color",
      "Undershirt Color",
      "Pants Color",
      "Shoe Color",
      "Skin Color",
      "Eye Color",
      (string) (object) '\x008B' + (object) "Randomize All",
      (string) (object) '\x0088' + (object) " Create Character",
      "\x0082\x0083Switch Category",
      (string) (object) '\x0084' + (object) "Select Color",
      (string) (object) '\x0084' + (object) "Select Type",
      (string) (object) '\x0084' + (object) "Select Gender",
      (string) (object) '\x0084' + (object) "Select Difficulty",
      (string) (object) '\x0084' + (object) "Change Sound Volume",
      (string) (object) '\x0084' + (object) "Change Music Volume",
      (string) (object) '\x008C' + (object) "Next Page",
      (string) (object) '\x008A' + (object) "Previous Page",
      (string) (object) '\x0084' + (object) "Scroll Text",
      "\x0082\x0083Switch Leaderboard",
      (string) (object) '\x008A' + (object) "Show Top",
      (string) (object) '\x008A' + (object) "Show Myself",
      (string) (object) '\x008A' + (object) "Show Friends Only",
      (string) (object) '\x008C' + (object) "Exit Game",
      (string) (object) '\x008D' + (object) "Back",
      (string) (object) '\x008A' + (object) "Unlock Full Game"
    };
    public static readonly string[] CONTROLS_DE = new string[87]
    {
      (string) (object) '\x008C' + (object) "Auswählen",
      (string) (object) '\x008D' + (object) "Zurück",
      (string) (object) '\x008D' + (object) "Schließen",
      (string) (object) '\x008A' + (object) "Speichermedium wechseln",
      (string) (object) '\x008B' + (object) "Xbox LIVE Party",
      (string) (object) '\x008C' + (object) "Auf Greifhaken-Modus umstellen",
      (string) (object) '\x0083' + (object) "Verbanne Welt",
      (string) (object) '\x0085' + (object) "Karte",
      "\x0080\x0081Zoom",
      (string) (object) '\x008C' + (object) "Auf PvP schalten",
      (string) (object) '\x008C' + (object) "Team wählen",
      (string) (object) '\x008A' + (object) "Einladung",
      (string) (object) '\x008B' + (object) "Einladung - Xbox LIVE Party",
      (string) (object) '\x008C' + (object) "Spielerkarte",
      (string) (object) '\x008C' + (object) "Welt erstellen",
      (string) (object) '\x008C' + (object) "Teilnehmen",
      (string) (object) '\x008A' + (object) "Spielerkarte zeigen",
      "\x0082\x0083Item austauschen",
      "\x0082\x0083Menü wechseln",
      (string) (object) '\x0080' + (object) "Entern",
      (string) (object) '\x008E' + (object) "Entern",
      (string) (object) '\x008D' + (object) "Nutzen",
      (string) (object) '\x008D' + (object) "Sprechen",
      (string) (object) '\x008C' + (object) "Springen",
      (string) (object) '\x008B' + (object) "Inventar",
      (string) (object) '\x008A' + (object) "Fallenlassen",
      (string) (object) '\x008A' + (object) "Müll",
      (string) (object) '\x008A' + (object) "Verkaufen",
      (string) (object) '\x0081' + (object) "Action",
      (string) (object) '\x0081' + (object) "Graben",
      (string) (object) '\x0081' + (object) "Hacken",
      (string) (object) '\x0081' + (object) "Attackieren",
      (string) (object) '\x0081' + (object) "Schlagen",
      (string) (object) '\x0081' + (object) "Bauen",
      (string) (object) '\x0081' + (object) "Nimm eins",
      (string) (object) '\x008C' + (object) "Nehmen",
      (string) (object) '\x008C' + (object) "Platzieren",
      (string) (object) '\x008C' + (object) "Ausstatten",
      (string) (object) '\x008C' + (object) "Tauschen",
      (string) (object) '\x0081' + (object) "Ausstatten",
      (string) (object) '\x0081' + (object) "Öffnen",
      (string) (object) '\x008C' + (object) "Wieder schmieden",
      (string) (object) '\x008C' + (object) "Rezepte anzeigen",
      (string) (object) '\x008C' + (object) "Herstellen",
      (string) (object) '\x008A' + (object) "Alle",
      (string) (object) '\x008A' + (object) "Erhältliche",
      (string) (object) '\x008B' + (object) "Bestandteile",
      (string) (object) '\x008B' + (object) "Rezepte",
      "\x0080\x0081Kategorie",
      (string) (object) '\x0081' + (object) "Kauf eins",
      (string) (object) '\x008C' + (object) "Kaufen",
      (string) (object) '\x008C' + (object) "Verkaufen",
      (string) (object) '\x008C' + (object) "Buff löschen",
      (string) (object) '\x008C' + (object) "Raum zuweisen",
      (string) (object) '\x008A' + (object) "Unterkünfte",
      (string) (object) '\x008B' + (object) "Flaggen anzeigen",
      (string) (object) '\x008B' + (object) "Flaggen verbergen",
      "Geschlecht",
      "Schwierigkeitsstufe",
      "Haartyp",
      "Haarfarbe",
      "Hemdfarbe",
      "Shirt-Farbe",
      "Unterhemdfarbe",
      "Hosenfarbe",
      "Schuhfarbe",
      "Hautfarbe",
      "Augenfarbe",
      (string) (object) '\x008B' + (object) "Alle nach Zufallsprinzip auswählen",
      (string) (object) '\x0088' + (object) " Charakter erstellen",
      "\x0082\x0083Kategorie wechseln",
      (string) (object) '\x0084' + (object) "Farbe auswählen",
      (string) (object) '\x0084' + (object) "Typ auswählen",
      (string) (object) '\x0084' + (object) "Geschlecht auswählen",
      (string) (object) '\x0084' + (object) "Schwierigkeitsstufe auswählen",
      (string) (object) '\x0084' + (object) "Tonlautstärke ändern",
      (string) (object) '\x0084' + (object) "Musiklautstärke ändern",
      (string) (object) '\x008C' + (object) "Nächste Seite",
      (string) (object) '\x008A' + (object) "Vorherige Seite",
      (string) (object) '\x0084' + (object) "Text scrollen",
      "\x0082\x0083Bestenlisten wechseln",
      (string) (object) '\x008A' + (object) "Bestplatzierte",
      (string) (object) '\x008A' + (object) "Mich selbst anzeigen",
      (string) (object) '\x008A' + (object) "Nur Freunde anzeigen",
      (string) (object) '\x008C' + (object) "Spiel verlassen",
      (string) (object) '\x008D' + (object) "Zurück",
      (string) (object) '\x008A' + (object) "Vollständiges Spiel freischalten"
    };
    public static readonly string[] CONTROLS_FR = new string[87]
    {
      (string) (object) '\x008C' + (object) "Sélectionner",
      (string) (object) '\x008D' + (object) "Retour",
      (string) (object) '\x008D' + (object) "Fermer",
      (string) (object) '\x008A' + (object) "Changer périphérique de stockage",
      (string) (object) '\x008B' + (object) "Groupe d'amis Xbox LIVE",
      (string) (object) '\x008C' + (object) "Basculer en mode grappin",
      (string) (object) '\x0083' + (object) "Bannir un monde",
      (string) (object) '\x0085' + (object) "Carte",
      "\x0080\x0081Agrandir",
      (string) (object) '\x008C' + (object) "PvP",
      (string) (object) '\x008C' + (object) "L'équipe",
      (string) (object) '\x008A' + (object) "Invitation",
      (string) (object) '\x008B' + (object) "Inviter groupe d'amis Xbox LIVE",
      (string) (object) '\x008C' + (object) "Carte joueur",
      (string) (object) '\x008C' + (object) "Créer un monde",
      (string) (object) '\x008C' + (object) "Rejoindre",
      (string) (object) '\x008A' + (object) "Afficher la carte du joueur",
      "\x0082\x0083Changer objet",
      "\x0082\x0083Changer menu",
      (string) (object) '\x0080' + (object) "Grappin",
      (string) (object) '\x008E' + (object) "Grappin",
      (string) (object) '\x008D' + (object) "Utiliser",
      (string) (object) '\x008D' + (object) "Parler",
      (string) (object) '\x008C' + (object) "Sauter",
      (string) (object) '\x008B' + (object) "Inventaire",
      (string) (object) '\x008A' + (object) "Lâcher",
      (string) (object) '\x008A' + (object) "Poubelle",
      (string) (object) '\x008A' + (object) "Vendre",
      (string) (object) '\x0081' + (object) "Action",
      (string) (object) '\x0081' + (object) "Creuser",
      (string) (object) '\x0081' + (object) "Couper",
      (string) (object) '\x0081' + (object) "Attaquer",
      (string) (object) '\x0081' + (object) "Frapper",
      (string) (object) '\x0081' + (object) "Construire",
      (string) (object) '\x0081' + (object) "En prendre un(e)",
      (string) (object) '\x008C' + (object) "Prendre",
      (string) (object) '\x008C' + (object) "Placer",
      (string) (object) '\x008C' + (object) "Équiper",
      (string) (object) '\x008C' + (object) "Échanger",
      (string) (object) '\x0081' + (object) "Équiper",
      (string) (object) '\x0081' + (object) "Ouvrir",
      (string) (object) '\x008C' + (object) "Reforger",
      (string) (object) '\x008C' + (object) "Afficher recettes",
      (string) (object) '\x008C' + (object) "Fabriquer",
      (string) (object) '\x008A' + (object) "Tout",
      (string) (object) '\x008A' + (object) "Disponible",
      (string) (object) '\x008B' + (object) "Ingrédients",
      (string) (object) '\x008B' + (object) "Recettes",
      "\x0080\x0081Catégories",
      (string) (object) '\x0081' + (object) "En acheter un(e)",
      (string) (object) '\x008C' + (object) "Acheter",
      (string) (object) '\x008C' + (object) "Vendre",
      (string) (object) '\x008C' + (object) "Annuler buff",
      (string) (object) '\x008C' + (object) "Attribuer chambre",
      (string) (object) '\x008A' + (object) "Logement",
      (string) (object) '\x008B' + (object) "Afficher drapeaux",
      (string) (object) '\x008B' + (object) "Masquer drapeaux",
      "Sexe",
      "Difficulté",
      "Type de cheveux",
      "Couleur de cheveux",
      "Couleur de veste",
      "Couleur de chemise",
      "Couleur de t-shirt",
      "Couleur de pantalon",
      "Couleur des chaussures",
      "Couleur de peau",
      "Couleur des yeux",
      (string) (object) '\x008B' + (object) "Tout au hasard",
      (string) (object) '\x0088' + (object) "Créer un personnage",
      "\x0082\x0083Changer de catégorie",
      (string) (object) '\x0084' + (object) "Choisir une couleur",
      (string) (object) '\x0084' + (object) "Choisir un type",
      (string) (object) '\x0084' + (object) "Choisir le sexe",
      (string) (object) '\x0084' + (object) "Choisir la difficulté",
      (string) (object) '\x0084' + (object) "Changer le volume des sons",
      (string) (object) '\x0084' + (object) "Changer le volume de la musique",
      (string) (object) '\x008C' + (object) "Page suivante",
      (string) (object) '\x008A' + (object) "Page précédente",
      (string) (object) '\x0084' + (object) "Faire défiler le texte",
      "\x0082\x0083Changer le classement",
      (string) (object) '\x008A' + (object) "Afficher les premiers",
      (string) (object) '\x008A' + (object) "Afficher mon rang",
      (string) (object) '\x008A' + (object) "Afficher amis uniquement",
      (string) (object) '\x008C' + (object) "Quitter le jeu",
      (string) (object) '\x008D' + (object) "Retour",
      (string) (object) '\x008A' + (object) "Déverrouiller le jeu complet"
    };
    public static readonly string[] CONTROLS_IT = new string[87]
    {
      (string) (object) '\x008C' + (object) "Seleziona",
      (string) (object) '\x008D' + (object) "Indietro",
      (string) (object) '\x008D' + (object) "Chiudi",
      (string) (object) '\x008A' + (object) "Cambia portaoggetti",
      (string) (object) '\x008B' + (object) "Party Xbox LIVE",
      (string) (object) '\x008C' + (object) "Attiva modalità di lotta",
      (string) (object) '\x0083' + (object) "Blocca Mondo",
      (string) (object) '\x0085' + (object) "Mappa",
      "\x0080\x0081Ingrandisci",
      (string) (object) '\x008C' + (object) "Attiva PvP",
      (string) (object) '\x008C' + (object) "Seleziona squadra",
      (string) (object) '\x008A' + (object) "Invito",
      (string) (object) '\x008B' + (object) "Invita ad un Party Xbox LIVE",
      (string) (object) '\x008C' + (object) "Scheda giocatore",
      (string) (object) '\x008C' + (object) "Crea Mondo",
      (string) (object) '\x008C' + (object) "Entra",
      (string) (object) '\x008A' + (object) "Mostra scheda giocatore",
      "\x0082\x0083Cambia oggetto",
      "\x0082\x0083Cambia menu",
      (string) (object) '\x0080' + (object) "Afferra",
      (string) (object) '\x008E' + (object) "Afferra",
      (string) (object) '\x008D' + (object) "Utilizza",
      (string) (object) '\x008D' + (object) "Parla",
      (string) (object) '\x008C' + (object) "Salta",
      (string) (object) '\x008B' + (object) "Inventario",
      (string) (object) '\x008A' + (object) "Lascia",
      (string) (object) '\x008A' + (object) "Cestino",
      (string) (object) '\x008A' + (object) "Vendi",
      (string) (object) '\x0081' + (object) "Azione",
      (string) (object) '\x0081' + (object) "Scava",
      (string) (object) '\x0081' + (object) "Taglia",
      (string) (object) '\x0081' + (object) "Attacca",
      (string) (object) '\x0081' + (object) "Colpisci",
      (string) (object) '\x0081' + (object) "Costruisci",
      (string) (object) '\x0081' + (object) "Prendi uno",
      (string) (object) '\x008C' + (object) "Prendi",
      (string) (object) '\x008C' + (object) "Posiziona",
      (string) (object) '\x008C' + (object) "Equipaggiati",
      (string) (object) '\x008C' + (object) "Scambia",
      (string) (object) '\x0081' + (object) "Equipaggiamento",
      (string) (object) '\x0081' + (object) "Apri",
      (string) (object) '\x008C' + (object) "Riforgia",
      (string) (object) '\x008C' + (object) "Mostra formule",
      (string) (object) '\x008C' + (object) "Crea",
      (string) (object) '\x008A' + (object) "Tutto",
      (string) (object) '\x008A' + (object) "Disponibile",
      (string) (object) '\x008B' + (object) "Ingredienti",
      (string) (object) '\x008B' + (object) "Formule",
      "\x0080\x0081Categoria",
      (string) (object) '\x0081' + (object) "Compra uno",
      (string) (object) '\x008C' + (object) "Compra",
      (string) (object) '\x008C' + (object) "Vendi",
      (string) (object) '\x008C' + (object) "Cancella bonus",
      (string) (object) '\x008C' + (object) "Assegna stanza",
      (string) (object) '\x008A' + (object) "Alloggio",
      (string) (object) '\x008B' + (object) "Mostra bandiere",
      (string) (object) '\x008B' + (object) "Nascondi bandiere",
      "Sesso",
      "Difficoltà",
      "Tipologia capelli",
      "Colore capelli",
      "Colore giubbotto",
      "Colore maglia",
      "Colore canottiera",
      "Colore pantaloni",
      "Colore scarpe",
      "Colore pelle",
      "Colore occhi",
      (string) (object) '\x008B' + (object) "Randomizza tutto",
      (string) (object) '\x0088' + (object) " Crea personaggio",
      "\x0082\x0083Cambia categoria",
      (string) (object) '\x0084' + (object) "Seleziona colore",
      (string) (object) '\x0084' + (object) "Seleziona tipologia",
      (string) (object) '\x0084' + (object) "Seleziona sesso",
      (string) (object) '\x0084' + (object) "Seleziona difficoltà",
      (string) (object) '\x0084' + (object) "Cambia volume suono",
      (string) (object) '\x0084' + (object) "Cambia volume musica",
      (string) (object) '\x008C' + (object) "Pagina successiva",
      (string) (object) '\x008A' + (object) "Pagina precedente",
      (string) (object) '\x0084' + (object) "Scorri testo",
      "\x0082\x0083Cambia classifica",
      (string) (object) '\x008A' + (object) "Mostra il primo in classifica",
      (string) (object) '\x008A' + (object) "Mostra il mio personaggio",
      (string) (object) '\x008A' + (object) "Mostra solo i miei amici",
      (string) (object) '\x008C' + (object) "Esci dal gioco",
      (string) (object) '\x008D' + (object) "Indietro",
      (string) (object) '\x008A' + (object) "Sblocca gioco completo"
    };
    public static readonly string[] CONTROLS_ES = new string[87]
    {
      (string) (object) '\x008C' + (object) "Seleccionar",
      (string) (object) '\x008D' + (object) "Atrás",
      (string) (object) '\x008D' + (object) "Cerrar",
      (string) (object) '\x008A' + (object) "Cambiar de dispositivo de almacenaje",
      (string) (object) '\x008B' + (object) "Xbox LIVE Party",
      (string) (object) '\x008C' + (object) "Cambiar de modo de agarre",
      (string) (object) '\x0083' + (object) "Prohibir Mundo",
      (string) (object) '\x0085' + (object) "Mapa",
      "\x0080\x0081Aumentar",
      (string) (object) '\x008C' + (object) "Cambiar PvP",
      (string) (object) '\x008C' + (object) "Seleccionar equipo",
      (string) (object) '\x008A' + (object) "Invitación",
      (string) (object) '\x008B' + (object) "Invitar a Xbox LIVE Party",
      (string) (object) '\x008C' + (object) "Mostrar jugador",
      (string) (object) '\x008C' + (object) "Crear mundo",
      (string) (object) '\x008C' + (object) "Unirse",
      (string) (object) '\x008A' + (object) "Mostrar tarjeta de jugador",
      "\x0082\x0083Cambiar objeto",
      "\x0082\x0083Cambiar de menú",
      (string) (object) '\x0080' + (object) "Agarrar",
      (string) (object) '\x008E' + (object) "Agarrar",
      (string) (object) '\x008D' + (object) "Usar",
      (string) (object) '\x008D' + (object) "Hablar",
      (string) (object) '\x008C' + (object) "Saltar",
      (string) (object) '\x008B' + (object) "Inventario",
      (string) (object) '\x008A' + (object) "Soltar",
      (string) (object) '\x008A' + (object) "Basura",
      (string) (object) '\x008A' + (object) "Vender",
      (string) (object) '\x0081' + (object) "Acción",
      (string) (object) '\x0081' + (object) "Excavar",
      (string) (object) '\x0081' + (object) "Cortar",
      (string) (object) '\x0081' + (object) "Atacar",
      (string) (object) '\x0081' + (object) "Golpear",
      (string) (object) '\x0081' + (object) "Construir",
      (string) (object) '\x0081' + (object) "Tomar uno",
      (string) (object) '\x008C' + (object) "Tomar",
      (string) (object) '\x008C' + (object) "Poner",
      (string) (object) '\x008C' + (object) "Equipar",
      (string) (object) '\x008C' + (object) "Cambiar",
      (string) (object) '\x0081' + (object) "Equipar",
      (string) (object) '\x0081' + (object) "Abrir",
      (string) (object) '\x008C' + (object) "Volver a forjar",
      (string) (object) '\x008C' + (object) "Mostrar recetas",
      (string) (object) '\x008C' + (object) "Crear",
      (string) (object) '\x008A' + (object) "Todo",
      (string) (object) '\x008A' + (object) "Disponible",
      (string) (object) '\x008B' + (object) "Ingredientes",
      (string) (object) '\x008B' + (object) "Recetas",
      "\x0080\x0081Categoría",
      (string) (object) '\x0081' + (object) "Comprar uno",
      (string) (object) '\x008C' + (object) "Comprar",
      (string) (object) '\x008C' + (object) "Vender",
      (string) (object) '\x008C' + (object) "Cancelar potenciador",
      (string) (object) '\x008C' + (object) "Asignar habitación",
      (string) (object) '\x008A' + (object) "Cobijo",
      (string) (object) '\x008B' + (object) "Mostrar banderas",
      (string) (object) '\x008B' + (object) "Ocultar banderas",
      "Sexo",
      "Dificultad",
      "Peinado",
      "Color de pelo",
      "Color de la ropa",
      "Color de la camisa",
      "Color de camiseta",
      "Color de los pantalones",
      "Color de los zapatos",
      "Color de la piel",
      "Color de los ojos",
      (string) (object) '\x008B' + (object) "Todo aleatorio",
      (string) (object) '\x0088' + (object) "Crear personaje",
      "\x0082\x0083Cambiar categoría",
      (string) (object) '\x0084' + (object) "Elegir color",
      (string) (object) '\x0084' + (object) "Elegir tipo",
      (string) (object) '\x0084' + (object) "Elegir sexo",
      (string) (object) '\x0084' + (object) "Elegir dificultad",
      (string) (object) '\x0084' + (object) "Cambiar volumen del sonido",
      (string) (object) '\x0084' + (object) "Cambiar volumen de la música",
      (string) (object) '\x008C' + (object) "Página siguiente",
      (string) (object) '\x008A' + (object) "Página anterior",
      (string) (object) '\x0084' + (object) "Avanzar texto",
      "\x0082\x0083Cambiar marcador",
      (string) (object) '\x008A' + (object) "Mostrar inicio",
      (string) (object) '\x008A' + (object) "Mostrar mi posición",
      (string) (object) '\x008A' + (object) "Mostrar solo amigos",
      (string) (object) '\x008C' + (object) "Salir del juego",
      (string) (object) '\x008D' + (object) "Atrás",
      (string) (object) '\x008A' + (object) "Desbloquear juego completo"
    };
    private static readonly ControlDesc[] MENU_CONTROLS_EN = new ControlDesc[13]
    {
      new ControlDesc(0, 361, 144, "Grapple"),
      new ControlDesc(0, 592, 144, "Action"),
      new ControlDesc(3, (int) byte.MaxValue, 198, "Previous Item"),
      new ControlDesc(2, 703, 198, "Next Item"),
      new ControlDesc(1, 174, 310, "Quick Shortcuts"),
      new ControlDesc(3, (int) byte.MaxValue, 265, "Move/"),
      new ControlDesc(3, 550, 420, "Aim/Switch Cursor Mode"),
      new ControlDesc(0, 437, 108, "Player List & World Map"),
      new ControlDesc(0, 520, 172, "Pause"),
      new ControlDesc(2, 703, 290, "Jump"),
      new ControlDesc(2, 703, 260, "Use"),
      new ControlDesc(2, 703, 320, "Drop"),
      new ControlDesc(2, 703, 230, "Inventory")
    };
    private static readonly ControlDesc[] MENU_CONTROLS_DE = new ControlDesc[13]
    {
      new ControlDesc(0, 361, 140, "Entern"),
      new ControlDesc(0, 592, 140, "Action"),
      new ControlDesc(3, (int) byte.MaxValue, 198, "Vorheriges Item"),
      new ControlDesc(2, 703, 198, "Nächstes Item"),
      new ControlDesc(1, 174, 310, "Schnelle Verknüpfungen"),
      new ControlDesc(3, (int) byte.MaxValue, 265, "Bewegen/"),
      new ControlDesc(3, 550, 420, "Mit Cursor zielen/Cursor-Modus ändern"),
      new ControlDesc(0, 437, 106, "Spielerliste/Weltkarte"),
      new ControlDesc(0, 520, 168, "Pause"),
      new ControlDesc(2, 703, 290, "Springen"),
      new ControlDesc(2, 703, 260, "Nutzen"),
      new ControlDesc(2, 703, 320, "Fallenlassen"),
      new ControlDesc(2, 703, 230, "Inventar")
    };
    private static readonly ControlDesc[] MENU_CONTROLS_FR = new ControlDesc[13]
    {
      new ControlDesc(0, 361, 140, "Grappin"),
      new ControlDesc(0, 592, 140, "Action"),
      new ControlDesc(3, (int) byte.MaxValue, 198, "Objet précédent"),
      new ControlDesc(2, 703, 198, "Objet suivant"),
      new ControlDesc(1, 174, 310, "Raccourcis"),
      new ControlDesc(3, (int) byte.MaxValue, 265, "Se déplacer/"),
      new ControlDesc(3, 550, 420, "Viser/Changer le mode curseur"),
      new ControlDesc(0, 437, 106, "Liste du joueur/carte du monde"),
      new ControlDesc(0, 520, 168, "Pause"),
      new ControlDesc(2, 703, 290, "Sauter"),
      new ControlDesc(2, 703, 260, "Utiliser"),
      new ControlDesc(2, 703, 320, "Lâcher"),
      new ControlDesc(2, 703, 230, "Inventaire")
    };
    private static readonly ControlDesc[] MENU_CONTROLS_IT = new ControlDesc[13]
    {
      new ControlDesc(0, 361, 140, "Afferra"),
      new ControlDesc(0, 592, 140, "Azione"),
      new ControlDesc(3, (int) byte.MaxValue, 198, "Oggetto precedente"),
      new ControlDesc(2, 703, 198, "Oggetto nuovo"),
      new ControlDesc(1, 174, 310, "Comandi rapidi"),
      new ControlDesc(3, (int) byte.MaxValue, 265, "Sposta/"),
      new ControlDesc(3, 550, 420, "Modalità cursore Mira/Cambia"),
      new ControlDesc(0, 437, 106, "Lista giocatori/Mappa Mondo"),
      new ControlDesc(0, 520, 168, "Pausa"),
      new ControlDesc(2, 703, 290, "Salta"),
      new ControlDesc(2, 703, 260, "Utilizza"),
      new ControlDesc(2, 703, 320, "Lascia"),
      new ControlDesc(2, 703, 230, "Inventario")
    };
    private static readonly ControlDesc[] MENU_CONTROLS_ES = new ControlDesc[13]
    {
      new ControlDesc(0, 361, 140, "Agarrar"),
      new ControlDesc(0, 592, 140, "Acción"),
      new ControlDesc(3, (int) byte.MaxValue, 198, "Objeto anterior"),
      new ControlDesc(2, 703, 198, "Objeto siguiente"),
      new ControlDesc(1, 174, 310, "Accesos directos"),
      new ControlDesc(3, (int) byte.MaxValue, 265, "Mover/"),
      new ControlDesc(3, 550, 420, "Apuntar/Cambiar modo de cursor"),
      new ControlDesc(0, 437, 106, "Lista de jugadores/Mapa del mundo"),
      new ControlDesc(0, 520, 168, "Pausa"),
      new ControlDesc(2, 703, 290, "Saltar"),
      new ControlDesc(2, 703, 260, "Usar"),
      new ControlDesc(2, 703, 320, "Soltar"),
      new ControlDesc(2, 703, 230, "Inventario")
    };
    public static readonly string[] PROJECTILE_NAMES = new string[120]
    {
      null,
      "Wooden Arrow",
      "Fire Arrow",
      "Shuriken",
      "Unholy Arrow",
      "Jester's Arrow",
      "Enchanted Boomerang",
      "Vilethorn",
      "Vilethorn (end)",
      "Starfury",
      "Purification Powder",
      "Vile Powder",
      "Fallen Star",
      "Grappling Hook",
      "Musket Ball",
      "Ball of Fire",
      "Magic Missile",
      "Dirt Ball",
      "Orb of Light",
      "Flamarang",
      "Green Laser",
      "Bone",
      "Water Stream",
      "Harpoon",
      "Spiky Ball",
      "Ball 'O Hurt",
      "Blue Moon",
      "Water Bolt",
      "Bomb",
      "Dynamite",
      "Grenade",
      "Sand Ball",
      "Ivy Whip",
      "Thorn Chakrum",
      "Flamelash",
      "Sunfury",
      "Meteor Shot",
      "Sticky Bomb",
      "Harpy Feather",
      "Mud Ball",
      "Ash Ball",
      "Hellfire Arrow",
      "Sand Ball",
      "Tombstone",
      "Demon Sickle",
      "Demon Scythe",
      "Dark Lance",
      "Trident",
      "Throwing Knife",
      "Spear",
      "Glowstick",
      "Seed",
      "Wooden Boomerang",
      "Sticky Glowstick",
      "Poisoned Knife",
      "Stinger",
      "Ebonsand Ball",
      "Cobalt Chainsaw",
      "Mythril Chainsaw",
      "Cobalt Drill",
      "Mythril Drill",
      "Adamantite Chainsaw",
      "Adamantite Drill",
      "The Dao of Pow",
      "Mythril Halberd",
      "Ebonsand Ball",
      "Adamantite Glaive",
      "Pearl Sand Ball",
      "Pearl Sand Ball",
      "Holy Water",
      "Unholy Water",
      "Silt Ball",
      "Blue Fairy",
      "Hook",
      "Hook",
      "Happy Bomb",
      "Note",
      "Note",
      "Note",
      "Rainbow",
      "Ice Block",
      "Wooden Arrow",
      "Flaming Arrow",
      "Eye Laser",
      "Pink Laser",
      "Flames",
      "Pink Fairy",
      "Green Fairy",
      "Purple Laser",
      "Crystal Bullet",
      "Crystal Shard",
      "Holy Arrow",
      "Hallow Star",
      "Magic Dagger",
      "Crystal Storm",
      "Cursed Flame",
      "Cursed Flame",
      "Cobalt Naginata",
      "Poison Dart",
      "Boulder",
      "Death laser",
      "Eye Fire",
      "Bomb",
      "Cursed Arrow",
      "Cursed Bullet",
      "Gungnir",
      "Light Disc",
      "Hamdrax",
      "Explosives",
      "Snow Ball",
      "Bullet",
      "Guinea Pig",
      "Tonbogiri",
      "Spectral Arrow",
      "Vulcan Bolt",
      "Slime",
      "Tiphia",
      "Bat",
      "Werewolf",
      "Zombie"
    };
    private static readonly string[] ITEM_PREFIX_EN = new string[84]
    {
      null,
      "Large",
      "Massive",
      "Dangerous",
      "Savage",
      "Sharp",
      "Pointy",
      "Tiny",
      "Terrible",
      "Small",
      "Dull",
      "Unhappy",
      "Bulky",
      "Shameful",
      "Heavy",
      "Light",
      "Sighted",
      "Rapid",
      "Hasty",
      "Intimidating",
      "Deadly",
      "Staunch",
      "Awful",
      "Lethargic",
      "Awkward",
      "Powerful",
      "Mystic",
      "Adept",
      "Masterful",
      "Inept",
      "Ignorant",
      "Deranged",
      "Intense",
      "Taboo",
      "Celestial",
      "Furious",
      "Keen",
      "Superior",
      "Forceful",
      "Broken",
      "Damaged",
      "Shoddy",
      "Quick",
      "Deadly",
      "Agile",
      "Nimble",
      "Murderous",
      "Slow",
      "Sluggish",
      "Lazy",
      "Annoying",
      "Nasty",
      "Manic",
      "Hurtful",
      "Strong",
      "Unpleasant",
      "Weak",
      "Ruthless",
      "Frenzying",
      "Godly",
      "Demonic",
      "Zealous",
      "Hard",
      "Guarding",
      "Armored",
      "Warding",
      "Arcane",
      "Precise",
      "Lucky",
      "Jagged",
      "Spiked",
      "Angry",
      "Menacing",
      "Brisk",
      "Fleeting",
      "Hasty",
      "Quick",
      "Wild",
      "Rash",
      "Intrepid",
      "Violent",
      "Legendary",
      "Unreal",
      "Mythical"
    };
    private static readonly string[] ITEM_PREFIX_DE = new string[84]
    {
      null,
      "Groß",
      "Riesig",
      "Gefährlich",
      "Barbarisch",
      "Scharf",
      "Spitz",
      "Winzig",
      "Schrecklich",
      "Klein",
      "Stumpf",
      "Unglücklich",
      "Sperrig",
      "Beschämend",
      "Schwer",
      "Leicht",
      "Gesichtet",
      "Schnell",
      "Hastig",
      "Einschüchternd",
      "Tödlich",
      "Unerschütterlich",
      "Schrecklich",
      "Lethargisch",
      "Unbeholfen",
      "Mächtig",
      "Mystisch",
      "Geschickt",
      "Meisterhaft",
      "Ungeschickt",
      "Unwissend",
      "Gestört",
      "Intensiv",
      "Tabu",
      "Himmlisch",
      "Wütend",
      "Scharf",
      "Überlegen",
      "Kraftvoll",
      "Gebrochen",
      "Beschädigt",
      "Schäbig",
      "Rasch",
      "Tödlich",
      "Agil",
      "Wendig",
      "Mörderisch",
      "Langsam",
      "Träge",
      "Faul",
      "Lästig",
      "Böse",
      "Manisch",
      "Verletzend",
      "Stark",
      "Unangenehm",
      "Schwach",
      "Rücksichtslos",
      "Rasend",
      "Fromm",
      "Dämonisch",
      "Eifrig",
      "Schwer",
      "Schützend",
      "Gepanzert",
      "Abwehrend",
      "Geheimnisvoll",
      "Präzise",
      "Glücklich",
      "Gezackt",
      "Spike",
      "Wütend",
      "Bedrohlich",
      "Rege",
      "Flüchtig",
      "Hastig",
      "Rasch",
      "Wild",
      "Voreilig",
      "Unerschrocken",
      "Gewalttätig",
      "Legendär",
      "Unwirklich",
      "Mythisch"
    };
    private static readonly string[] ITEM_PREFIX_IT = new string[84]
    {
      null,
      "Grande",
      "Massiccio",
      "Pericoloso",
      "Selvaggio",
      "Appuntito",
      "Tagliente",
      "Minuto",
      "Terribile",
      "Piccolo",
      "Opaco",
      "Infelice",
      "Ingombrante",
      "Vergognoso",
      "Pesante",
      "Luce",
      "Avvistato",
      "Rapido",
      "Frettoloso",
      "Intimidatorio",
      "Mortale",
      "Convinto",
      "Orribile",
      "Letargico",
      "Scomodo",
      "Potente",
      "Mistico",
      "Esperto",
      "Magistrale",
      "Inetto",
      "Ignorante",
      "Squilibrato",
      "Intenso",
      "Tabù",
      "Celeste",
      "Furioso",
      "Appassionato",
      "Superiore",
      "Forte",
      "Rotto",
      "Danneggiato",
      "Scadente",
      "Veloce",
      "Mortale",
      "Agile",
      "Lesto",
      "Omicida",
      "Lento",
      "Lento",
      "Pigro",
      "Fastidioso",
      "Cattivo",
      "Maniaco",
      "Offensivo",
      "Robusto",
      "Sgradevole",
      "Debole",
      "Spietato",
      "Frenetico",
      "Devoto",
      "Diabolico",
      "Zelante",
      "Duro",
      "Protettivo",
      "Corazzato",
      "Difensivo",
      "Arcano",
      "Preciso",
      "Fortunato",
      "Frastagliato",
      "Spillo",
      "Arrabbiato",
      "Minaccioso",
      "Vivace",
      "Fugace",
      "Frettoloso",
      "Veloce",
      "Selvaggio",
      "Temerario",
      "Intrepido",
      "Violento",
      "Leggendario",
      "Irreale",
      "Mitico"
    };
    private static readonly string[] ITEM_PREFIX_FR = new string[84]
    {
      null,
      "Grand",
      "Massif",
      "Dangereuses",
      "Sauvages",
      "Coupante",
      "Pointues",
      "Minuscules",
      "Terrible",
      "Petit",
      "Terne",
      "Malheureux",
      "Volumineux",
      "Honteux",
      "Lourds",
      "Léger",
      "Voyants",
      "Rapide",
      "Hâtif",
      "Intimidant",
      "Mortelle",
      "Dévoué",
      "Affreux",
      "Léthargique",
      "Scomodo",
      "Puissante",
      "Mystique",
      "Expert",
      "Magistrale",
      "Inepte",
      "Ignorants",
      "Dérangé",
      "Intenses",
      "Tabou",
      "Célestes",
      "Furieux",
      "Vif",
      "Supérieure",
      "Énergique",
      "Rompu",
      "Endommagés",
      "Mesquin",
      "Prompt",
      "Mortelle",
      "Agile",
      "Leste",
      "Meurtrier",
      "Lente",
      "Paresseux",
      "Fainéant",
      "Ennuyeux",
      "Méchant",
      "Maniaco",
      "Blessant",
      "Robuste",
      "Désagréables",
      "Faibles",
      "Impitoyable",
      "Frénétique",
      "Pieux",
      "Démoniaque",
      "Zélé",
      "Durs",
      "Protecteur",
      "Blindés",
      "Défensif",
      "Ésotérique",
      "Précise",
      "Chanceux",
      "Déchiqueté",
      "Pointes",
      "Fâché",
      "Menaçant",
      "Brusque",
      "Fugace",
      "Hâtif",
      "Prompt",
      "Sauvages",
      "Téméraire",
      "Intrépide",
      "Violent",
      "Légendaire",
      "Irréel",
      "Mythique"
    };
    private static readonly string[] ITEM_PREFIX_ES = new string[84]
    {
      null,
      "Grande",
      "Enorme",
      "Peligroso",
      "Salvaje",
      "Afilado",
      "Puntiagudo",
      "Diminuto",
      "Mala ",
      "Pequeño",
      "Aburrido",
      "Infeliz",
      "Voluminoso",
      "Vergonzoso",
      "Pesado",
      "Ligero",
      "Perspicaz",
      "Rápido",
      "Precipitado",
      "Intimidante",
      "Mortal",
      "Firme",
      "Atroz",
      "Letárgico",
      "Torpe",
      "Poderoso",
      "Místico",
      "Experto",
      "Maestro",
      "Inepto",
      "Ignorante",
      "Trastornado",
      "Intenso",
      "Prohibido",
      "Celeste",
      "Furioso",
      "Incisivo",
      "Superior",
      "Fuerte",
      "Roto",
      "Estropeado",
      "Chapucero",
      "Veloz",
      "Mortal",
      "Ágil",
      "Listo",
      "Asesino",
      "Lento",
      "Perezoso",
      "Gandul",
      "Molesto",
      "Feo",
      "Maníaco",
      "Hiriente",
      "Vigoroso",
      "Desagradable",
      "Débil",
      "Despiadado",
      "Frenético",
      "Piadoso",
      "Demoníaco",
      "Fanático",
      "Duro",
      "Protector",
      "Blindado",
      "Defensivo",
      "Arcano",
      "Preciso",
      "Afortunado",
      "Dentado",
      "Claveteado",
      "Enojado",
      "Amenazante",
      "Enérgico",
      "Fugaz",
      "Precipitado",
      "Veloz",
      "Salvaje",
      "Temerario",
      "Intrépido",
      "Violento",
      "Legendario",
      "Irreal",
      "Mítico"
    };
    private static readonly string[] TUTORIAL_EN = new string[80]
    {
      "Terraria is a game about adventuring to the ends of the World and defeating villainous bosses along the way. This tutorial will teach you the basics.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "Use " + (object) '\x0084' + " to move around.",
      "Press " + (object) '\x008C' + " to jump.",
      "You can fall through wood platforms by pressing down " + (object) '\x0084' + ". Try falling through the platform.",
      "Now jump out by pressing " + (object) '\x008C' + ".",
      "Press (or hold) " + (object) '\x0081' + " to perform actions with the current item. Aim with " + (string) (object) '\x0085' + ".",
      "At the top of your screen is the Inventory Bar. You can switch between items with " + (object) '\x0082' + " & " + (string) (object) '\x0083' + ". Now switch to your sword.",
      "An evil monster has appeared. Defeat it with your sword by pressing " + (object) '\x0081' + ".",
      "Terraria is full of monsters, especially at night. Luckily there are many weapons you can find to help you.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "If you get hurt, you will heal over time. You can also use food or healing potions.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "Killing that slime gave you a gel. If you had wood to combine it with, you could craft a torch. Let's gather some wood.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "To chop down a tree you must use an axe. Switch to your axe.",
      "Chop down a tree by aiming toward one and holding " + (object) '\x0081' + ".",
      "All the items you pick up go into your Inventory. Press " + (object) '\x008B' + " to open the Inventory Menu.",
      "The Inventory Menu is split into sections. This area is your main Inventory. The top row of item slots is your Inventory Bar. There are also slots for ammo (such as arrows) or coins.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "Use " + (object) '\x0084' + " to move between slots. Use " + (string) (object) '\x008C' + " to pick up and place stacks of items. Use " + (string) (object) '\x0081' + " to move one item at a time.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "To permanently delete an item, move it to the Trash slot or press " + (object) '\x008A' + ".\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "Press " + (object) '\x0083' + " to switch to the Equip section.",
      "The Equip section is where you place armor and accessories. Items in Vanity slots appear on your character, but do not give armor bonuses.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "If you activate a chest or vendor NPC, a separate section will appear for it.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "Press " + (object) '\x0082' + " or " + (string) (object) '\x0083' + " until you switch to the Crafting section.",
      "The gel and wood you collected can be crafted into a torch. Select the torch icon and press " + (object) '\x008C' + " to create it.",
      "If you want to find out more about a recipe's ingredients, you can press " + (object) '\x008B' + " to enter or exit the Ingredients area.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "There are several categories of crafting items. You can switch between them by pressing " + (object) '\x0080' + " and " + (string) (object) '\x0081' + ".",
      "Press " + (object) '\x008D' + " to exit Crafting.",
      "To create better items and explore the vast underground, you will need to dig down and mine ore with a pickaxe. Switch to your pickaxe.",
      "Nearby there is a vein of ore. Mine it all by aiming toward it and holding " + (object) '\x0081' + ".",
      "As you dig deeper underground, you will find better ores. Some may require a better pickaxe to mine.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "If you get stuck in a hole, you can place wood platforms to get out. Craft 5 wood platforms.",
      "Press " + (object) '\x008B' + " to open the Inventory Menu. Switch to Crafting with " + (string) (object) '\x0082' + " and " + (string) (object) '\x0083' + ".",
      "Now select the wood platforms in your Inventory Bar.",
      "Placing items and structures is easier in the Manual Cursor Mode. Press " + (object) '\x008F' + " to switch your Cursor Mode.",
      "In Manual Cursor Mode " + (object) '\x0085' + " acts like a mouse. Aim the cursor and press " + (string) (object) '\x0081' + " to place wood platforms.\n\n",
      "Build enough so you can jump out of the hole.",
      "Remember you can switch between Cursor Modes at any time by pressing " + (object) '\x008F' + ".\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "It's dangerous to be outside at night. Build a shelter before it gets dark.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "To start, build walls and a ceiling. Give yourself plenty of room inside. If you don't have enough wood (or stone), gather more.",
      "\n\nA shelter must be at least 6 blocks high and 10 blocks wide.",
      "You'll need a door to get in and out. Remove 3 blocks from the bottom of a wall to make room.",
      "\n\nUse an axe to remove wood blocks, or a pickaxe to remove stone blocks.",
      "To craft a door, you need a work bench. Craft a work bench and place it inside your house.",
      "\nIf you don't have enough wood, chop down more trees.",
      "When you are standing near a work bench or other crafting station (such as an anvil or furnace), more recipes will be available to build in your Crafting menu.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "Stand near your crafting table and craft a door.",
      "\nIf you don't have enough wood, chop down more trees.",
      "Now place the door in the space in the wall. This can be tricky, and is easiest in the Manual Cursor Mode, " + (object) '\x008F' + ".",
      "You can open or close your door. Aim at it and press " + (object) '\x008D' + ".",
      "You're almost done. To make your house safe, you will need to panel the background of your house with walls (such as wood walls).\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "Craft a bunch of wood walls at your work bench.",
      "\nIf you don't have enough wood, chop down more trees.",
      "Panel the background of your house with wood walls. This is easiest in the Auto Cursor Mode, " + (object) '\x008F' + ".",
      "Make sure to cover the entire background.",
      "Your house is now safe. For a room to be livable for NPCs, it needs: a table (such as your work bench), a chair, and a light source (such as a torch).\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "Craft a chair and place it in your house.",
      "Now place a torch on the walls or floor of your house. This is easiest in Manual Cursor Mode, " + (object) '\x008F' + ".",
      "This room is now livable for NPCs. As you progress, there are many NPCs who can move into your house if you have enough livable rooms for them.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "The Guide is the first NPC who can move into your house. You can talk to him for tips or details about crafting ingredients.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "If you ever want to destroy furniture or background walls, you can craft a hammer to do so.\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      "Congratulations, you have completed the tutorial. There are only a few areas to explore on this floating island. When you are ready, exit the tutorial and create yourself a whole new World!\n ",
      "<c>Press " + (object) '\x008D' + " to continue.",
      null
    };
    private static readonly string[] TUTORIAL_DE = new string[80]
    {
      "Terraria ist ein Spiel, in dem du dich bis ans Ende der Welt wagst und unterwegs bösartige Endgegner besiegst. Dieses Tutorial bringt dir die Grundlagen dafür bei.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Bewege dich mit " + (object) '\x0084' + ".",
      "Springe mit " + (object) '\x008C' + ".",
      "Du kannst durch Holzplattformen fallen, indem du " + (object) '\x0084' + " nach unten drückst. Versuche, durch eine Plattform zu fallen.",
      "Springe heraus, indem du " + (object) '\x008C' + " drückst.",
      "Drücke (oder halte) " + (object) '\x0081' + ", um Aktionen mit einem Gegenstand durchzuführen. Ziele mit " + (string) (object) '\x0085' + ".",
      "Am oberen Ende des Bildschirms befindet sich deine Inventarleiste. Mit" + (object) '\x0082' + " & " + (string) (object) '\x0083' + " kannst du zwischen Gegenständen wechseln. Wechsle zu deinem Schwert.",
      "Ein böses Monster ist erschienen. Besiege es mit deinem Schwert, indem du " + (object) '\x0081' + " drückst.",
      "Terraria ist voller Monster, besonders nachts. Zum Glück kannst du viele Waffen finden, die dir helfen.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Wenn du verletzt wirst, regenerierst du dich mit der Zeit wieder. Du kannst dazu auch Nahrung oder Heiltränke verwenden.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Die Zerstörung des Schleims hat dir ein Gel eingebracht. Wenn du Holz hättest, könntest du damit eine Fackel herstellen. Lass uns Holz sammeln.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Zum Fällen eines Baumes musst du eine Axt benutzen. Wechsle zu deiner Axt.",
      "Fälle einen Baum, indem du auf ihn zielst und " + (object) '\x0081' + " hältst.",
      "Alle von dir gesammelten Gegenstände gehen in dein Inventar. Drücke " + (object) '\x008B' + ", um das Inventarmenü zu öffnen.",
      "Das Inventar-Menü ist in Sektionen unterteilt. Diese Sektion ist dein Hauptinventar. Die obere Reihe Gegenstand-Slots ist deine Inventarleiste. Es gibt auch Slots für Munition (z.B. Pfeile) oder Münzen.\n ",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Wechsle mit " + (object) '\x0084' + " zwischen den Slots. Nimm mit " + (string) (object) '\x008C' + " einen Stapel von Gegenständen auf und platziere ihn. Bewege jeweils einen Gegenstand mit " + (string) (object) '\x0081' + ".\n ",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Um einen Gegenstand für immer zu löschen, lege ihn auf den Müll-Slot oder drücke " + (object) '\x008A' + ". \n ",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Wechsle durch Drücken von " + (object) '\x0083' + " zur Ausrüstungssektion.",
      "In der Ausrüstungssektion legst du deine Rüstung und dein Zubehör ab. Gegenstände in den Verzierungs-Slots erscheinen an deinem Charakter und verleihen keine Rüstungsboni.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Wenn du eine Schatzkiste oder einen Verkäufer-NPC aktivierst, erscheint dafür eine separate Sektion.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Drücke " + (object) '\x0082' + " oder " + (string) (object) '\x0083' + ", bis du zu der Herstellungssektion wechselst.",
      "Die gesammelten Gegenstände Gel und Holz können zu einer Fackel verarbeitet werden. Wähle das Fackelsymbol und drücke " + (object) '\x008C' + ", um sie anzufertigen.",
      "Wenn du mehr über eine Anleitung herausfinden möchtest, kannst du mit " + (object) '\x008B' + " die Sparte für Bestandteile anwählen oder verlassen.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Es gibt verschiedene Kategorien von herstellbaren Gegenständen. Durch Drücken von " + (object) '\x0080' + " und " + (string) (object) '\x0081' + " kannst du zwischen ihnen wechseln.",
      "Verlasse die Herstellungssektion durch Drücken von " + (object) '\x008D' + ".",
      "Du brauchst eine Spitzhacke zur Herstellung besserer Gegenstände und zur Erforschung der Unterwelt. Mit ihr kannst du graben und Erz abbauen. Wechsle zu deiner Spitzhacke.",
      "In der Nähe befindet sich eine Erzader. Baue sie ab, indem du auf sie zielst und " + (object) '\x0081' + " hältst.",
      "Wenn du tiefer in den Untergrund gräbst, findest du bessere Erze. Für manche brauchst du eine bessere Spitzhacke, um sie abzubauen.\n ",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Wenn du in einem Loch steckst, kannst du Holzplattformen errichten, um herauszukommen. Errichte fünf Holzplattformen.",
      "Drücke " + (object) '\x008B' + ", um das Inventarmenü zu öffnen. Wechsle mit " + (string) (object) '\x0082' + " und " + (string) (object) '\x0083' + " zur Herstellungssektion.",
      "Wähle nun die Holzplattformen in deiner Inventarleiste.",
      "Gegenstände und Bauwerke können im manuellen Cursor-Modus leichter platziert werden. Drücke " + (object) '\x008F' + ", um deinen Cursor-Modus zu wechseln.",
      "Im manuellen Cursor-Modus verhält sich " + (object) '\x0085' + " wie eine Maus. Ziele mit dem Cursor und drücke " + (string) (object) '\x0081' + ", um Holzplattformen zu platzieren.\n\n",
      "Baue hoch genug, um aus dem Loch herauszuspringen.",
      "Denk daran, dass du jederzeit mit " + (object) '\x008F' + " zwischen den Cursor-Modi wechseln kannst.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Es ist gefährlich, nachts draußen zu sein. Baue eine Unterkunft, bevor es dunkel wird.\n ",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Errichte zuerst Wände und ein Dach. Gestalte den Innenraum weiträumig. Falls du nicht genug Holz (oder Steine) hast, sammle mehr davon.",
      "\n\nEine Unterkunft muss mindestens sechs Blöcke hoch und zehn Blöcke breit sein.",
      "Du benötigst eine Tür, um hinein-und hinauszukommen. Entferne drei Blöcke an der Unterseite einer Wand, um Platz zu schaffen.",
      "\n\nBenutze eine Axt, um Holzblöcke zu entfernen oder eine Spitzhacke, um Steinblöcke zu entfernen.",
      "Zur Herstellung einer Tür benötigst du eine Werkbank. Errichte eine Werkbank und platziere sie in deinem Haus.",
      "\nFälle mehr Bäume, wenn du nicht genug Holz hast.",
      "Wenn du in der Nähe einer Werkbank oder anderer Arbeitsgeräte (wie z.B. Amboss oder Schmelzofen) stehst, sind mehr Anleitungen in deinem Herstellungsmenü verfügbar.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Stelle dich neben deine Werkbank und stelle eine Tür her.",
      "\nFälle mehr Bäume, wenn du nicht genug Holz hast.",
      "Platziere nun die Tür in der Aussparung der Wand. Dies kann knifflig sein und lässt sich am einfachstem im manuellen Cursor-Modus erledigen, " + (object) '\x008F' + ".",
      "Du kannst die Tür öffnen oder schließen. Ziele darauf und drücke " + (object) '\x008D' + ".",
      "Du bist fast fertig. Um dein Haus sicher zu machen, musst du die Rückseite deines Hauses mit Wänden (wie z.B. Holzwänden) vertäfeln.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Stelle Holzwände auf deiner Werkbank her.",
      "\nFälle mehr Bäume, wenn du nicht genug Holz hast.",
      "Vertäfle die Rückseite deines Hauses mit Holzwänden. Am einfachsten lässt sich das im manuellen Cursor-Modus erledigen " + (object) '\x008F' + ".",
      "Achte darauf, die gesamte Rückseite abzudecken.",
      "Dein Haus ist jetzt sicher. Damit NPCs in einem Raum leben können, brauchst du: Tisch (wie z.B. eine Werkbank), Stuhl und Lichtquelle (wie z.B. eine Fackel).\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Stelle einen Stuhl her und platziere ihn in deinem Haus.",
      "Platziere nun eine Fackel an der Wand oder auf dem Boden des Hauses. Am einfachsten lässt sich das im manuellen Cursor-Modus erledigen " + (object) '\x008F' + ".",
      "Dieser Raum kann jetzt von NPCs bewohnt werden. Je weiter du vorankommst, desto mehr NPCs können in dein Haus einziehen, sofern du genug bewohnbare Räume für sie hast.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Der Ratgeber ist der erste NPC, der in dein Haus einziehen kann. Du kannst mit ihm reden und Tipps oder Details zu Herstellungsbestandteilen erhalten.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Wenn du Möbel oder Rückwände zerstören willst, kannst du dafür einen Hammer herstellen.\n",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      "Herzlichen Glückwunsch, du hast das Tutorial abgeschlossen. Es gibt nur ein paar wenige Areale auf dieser schwimmenden Insel zu erkunden.Beende das Tutorial und erschaffe eine komplett neue Welt, sobald du bereit dazu bist!\n ",
      "<c>Drücke " + (object) '\x008D' + ", um fortzufahren.",
      null
    };
    private static readonly string[] TUTORIAL_FR = new string[80]
    {
      "Terraria est un jeu qui entraîne le joueur au bout du monde et lui fait affronter les boss infâmes se dressant sur son chemin. Ce didacticiel va vous enseigner les bases.\n",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Utilisez " + (object) '\x0084' + " pour vous déplacer.",
      "Appuyez sur " + (object) '\x008C' + " pour sauter.",
      "Vous pouvez passer au travers des plateformes en bois en appuyant sur " + (object) '\x0084' + ".  Essayez de passer au travers de la plateforme.",
      "Maintenant, sautez de la plateforme en appuyant sur " + (object) '\x008C' + ".",
      "Appuyez sur (ou maintenez) " + (object) '\x0081' + " pour réaliser des actions avec l'objet tenu. Visez avec " + (string) (object) '\x0085' + ".",
      "La barre d'inventaire figure en haut de votre écran. Vous pouvez changer d'objet avec " + (object) '\x0082' + " et " + (string) (object) '\x0083' + ". Maintenant, prenez votre épée.",
      "Un monstre diabolique est apparu. Vainquez-le à l'aide de votre épée en appuyant sur " + (object) '\x0081' + ".",
      "Terraria grouille de monstres, surtout la nuit. Heureusement, vous pouvez trouver beaucoup d'armes qui vous seront d'une grande aide.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "En cas de blessure, vous guérirez au fil du temps. Vous pouvez également utiliser de la nourriture ou des potions de soin.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Tuer ce slime vous a rapporté un gel. En le combinant avec du bois, vous pourriez fabriquer une torche. Ramassons du bois.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Pour couper un arbre, il vous faut une hache. Prenez votre hache.",
      "Coupez un arbre en le visant tout en maintenant " + (object) '\x0081' + ".",
      "Tous les objets que vous collectez vont dans votre inventaire. Appuyez sur " + (object) '\x008B' + " pour ouvrir le menu Inventaire.",
      "Le menu Inventaire est divisé en sections. Cette zone représente votre inventaire principal. La ligne supérieure des emplacements pour objets est votre barre d'inventaire. Il y a également des emplacements pour les munitions (comme les flèches) ou pour les pièces.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Utilisez " + (object) '\x0084' + " pour vous déplacer dans les emplacements. Utilisez " + (string) (object) '\x008C' + " pour prendre et placer des piles d'objets. Utilisez " + (string) (object) '\x0081' + " pour déplacer un seul objet à la fois.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Pour supprimer définitivement un objet, placez-le sur l'emplacement Poubelle ou appuyez sur " + (object) '\x008A' + ". \n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Appuyez sur " + (object) '\x0083' + " pour passer à la section Équiper.",
      "La section Équiper est celle dans laquelle vous placez vos armures et vos accessoires. Les objets des emplacements Vanité apparaissent sur votre personnage, mais ne confèrent aucun bonus d'armure.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Une section séparée apparaîtra si vous activez un coffre ou un PNJ vendeur.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Appuyez sur " + (object) '\x0082' + " ou " + (string) (object) '\x0083' + " jusqu'à la section Artisanat.",
      "Vous pouvez combiner le gel et le bois que vous avez collectés pour fabriquer une torche. Sélectionnez l'icône de la torche et appuyez sur " + (object) '\x008C' + " pour la créer.",
      "Si vous voulez en savoir plus sur les ingrédients d'une recette, vous pouvez appuyer sur " + (object) '\x008B' + " pour entrer dans la zone Ingrédients ou en sortir.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Il existe plusieurs catégories d'objets d'artisanat. Vous pouvez les consulter en appuyant sur " + (object) '\x0080' + " et " + (string) (object) '\x0081' + ".",
      "Appuyez sur " + (object) '\x008D' + " pour quitter Artisanat.",
      "Pour créer de meilleurs objets et explorer les immenses souterrains, vous devrez creuser et extraire du minerai à l'aide d'une pioche. Prenez votre pioche.",
      "Il y a une veine de minerai dans les environs. Exploitez-la entièrement en la visant tout en maintenant " + (object) '\x0081' + ".",
      "En creusant plus profondément, vous trouverez de meilleurs minerais. Vous aurez peut-être besoin d'une pioche plus solide pour en extraire certains.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Si vous êtes dans un trou, vous pouvez placer des plateformes en bois pour en sortir. Fabriquez 5 plateformes en bois.",
      "Appuyez sur " + (object) '\x008B' + " pour ouvrir le menu Inventaire. Accédez à Artisanat avec " + (string) (object) '\x0082' + " et " + (string) (object) '\x0083' + ".",
      "Sélectionnez les plateformes en bois dans votre barre d'inventaire.",
      "Le mode Curseur manuel permet de placer des objets et structures plus facilement. Appuyez sur " + (object) '\x008F' + " pour changer le mode Curseur.",
      "En mode Curseur manuel, " + (object) '\x0085' + " a la même fonction qu'une souris. Visez avec le curseur et appuyez sur " + (string) (object) '\x0081' + " pour placer les plateformes en bois.\n\n",
      "Construisez-en assez pour pouvoir sortir du trou.",
      "N'oubliez pas que vous pouvez changer de mode Curseur à tout moment en appuyant sur " + (object) '\x008F' + ".\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "C'est dangereux d'être dehors quand il fait nuit. Construisez un abri avant la tombée de la nuit.\n",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Pour commencer, construisez les murs et le plafond. Accordez-vous beaucoup d'espace intérieur. Si vous n'avez pas assez de bois (ou de pierres), collectez-en plus.",
      "\n\nUn abri doit avoir au moins 6 blocs de hauteur et 10 blocs de largeur.",
      "Vous aurez besoin d'une porte pour entrer et sortir. Supprimez 3 blocs du bas d'un des murs pour réserver cet espace.",
      "\n\nUtilisez une hache pour supprimer les blocs de bois ou une pioche pour supprimer les blocs de pierre.",
      "Vous aurez besoin d'un établi pour fabriquer une porte. Fabriquez un établi et placez-le dans votre maison.",
      "\nSi vous n'avez pas assez de bois, coupez plus d'arbres.",
      "Lorsque vous vous tenez près d'un établi ou d'une autre station d'artisanat (comme une enclume ou une fournaise), de nouvelles recettes apparaîtront dans votre menu Artisanat.\n '",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Placez-vous à côté de votre établi et fabriquez une porte.",
      "\nSi vous n'avez pas assez de bois, coupez plus d'arbres.",
      "Placez maintenant la porte dans l'espace réservé du mur. Ceci peut s'avérer délicat et le mode Curseur manuel vous facilitera la tâche, " + (object) '\x008F' + ".",
      "Vous pouvez ouvrir ou fermer votre porte. Visez-la et appuyez sur " + (object) '\x008D' + ".",
      "C'est presque fini. Pour sécuriser votre maison, vous devrez en recouvrir le fond de murs (par exemple, des murs en bois).\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Fabriquez une réserve de murs en bois à votre établi.",
      "\nSi vous n'avez pas assez de bois, coupez plus d'arbres.",
      "Recouvrez le fond de votre maison de murs en bois. Le mode Curseur auto vous facilitera la tâche, " + (object) '\x008F' + ".",
      "Veillez à bien recouvrir la totalité du mur du fond.",
      "Votre maison est maintenant sûre. Afin qu'un PNJ puisse vivre dans une chambre, il faut : une table (par exemple, votre établi), une chaise et une source de lumière (par exemple, une torche).\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Fabriquez une chaise et placez-la dans votre maison.",
      "Placez maintenant une torche aux murs ou sur le sol de votre maison. Le mode Curseur manuel vous facilitera la tâche, " + (object) '\x008F' + ".",
      "Cette pièce est désormais habitable pour les PNJ. Au fur et à mesure de votre progression, plusieurs PNJ pourront s'installer dans votre maison si vous avez suffisamment de chambres habitables.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Le guide est le premier PNJ à pouvoir s'installer dans votre maison. Vous pouvez lui parler pour obtenir des conseils et des détails sur les ingrédients d'artisanat.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Vous pouvez fabriquer un marteau si jamais vous souhaitez détruire un meuble ou les murs du fond.\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      "Félicitations, vous avez achevé le didacticiel. Il n'y a que quelques zones à explorer sur cette île flottante.Quand vous serez prêt(e), quittez le didacticiel et créez-vous un monde complètement nouveau !\n ",
      "<c>Appuyez sur " + (object) '\x008D' + " pour continuer.",
      null
    };
    private static readonly string[] TUTORIAL_IT = new string[80]
    {
      "Terraria è un gioco d'avventura per spingersi ai confini del Mondo e sconfiggere i perfidi boss sul tuo cammino. Questo tutorial te ne insegnerà le basi.\n",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Utilizza " + (object) '\x0084' + " per spostarti.",
      "Premi " + (object) '\x008C' + " per saltare.",
      "Puoi passare attraverso le piattaforme di legno, premendo in giù " + (object) '\x0084' + ". Prova a passare attraverso una piattaforma di legno.",
      "Quindi salta fuori, premendo " + (object) '\x008C' + ".",
      "Premi (o tieni premuto) " + (object) '\x0081' + " per eseguire un'azione con l'oggetto in uso. Punta con " + (string) (object) '\x0085' + ".",
      "La barra dell'Inventario si trova nella parte superiore dello schermo. È possibile passare da un oggetto all'altro con " + (object) '\x0082' + " & " + (string) (object) '\x0083' + ". Adesso passa alla spada.",
      "È apparso un mostro malvagio. Sconfiggilo con la spada, premendo " + (object) '\x0081' + ".",
      "Terraria è piena di mostri, specialmente di notte. Per fortuna, puoi trovare molte armi che ti saranno di grande aiuto.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Se ti fai male, guarirai col tempo. Puoi anche usare del cibo o pozioni di guarigione.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "L'uccisione dello Slime ti ha fornito della gelatina. Combinandola con la legna, otterrai una torcia. Raccogliamo un po' di legna!\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Per abbattere un albero userai un'ascia. Passa all'ascia.",
      "Per abbattere un albero, puntane uno e tieni premuto " + (object) '\x0081' + ".",
      "Tutti gli oggetti raccolti vanno nell'Inventario. Premi " + (object) '\x008B' + " per aprire il menu dell'Inventario.",
      "Il menu dell'Inventario è diviso in sezioni. Quest'area costituisce l'Inventario principale. La riga superiore degli slot degli oggetti è la tua barra dell'Inventario. Inoltre, sono presenti slot per le munizioni (es. frecce) o per le monete.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Utilizza " + (object) '\x0084' + " per spostarti da uno slot all'altro. Utilizza " + (string) (object) '\x008C' + " per raccogliere e posizionare gli oggetti accumulati. Utilizza " + (string) (object) '\x0081' + " per spostare un oggetto alla volta.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Sposta l'oggetto nella sezione del Cestino o premi " + (object) '\x008A' + ", per eliminarlo definitivamente. \n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Premi " + (object) '\x0083' + " per passare alla sezione Equipaggiamento.",
      "Nella sezione Equipaggiamento si trovano armature e accessori. Gli oggetti negli slot di Estetica sappaiono sul personaggio, ma non forniscono bonus per le armature.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Se attivi una cassa o un venditore PNG, apparirà una sezione apposita.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Premi " + (object) '\x0082' + " o " + (string) (object) '\x0083' + " finché non passi alla sezione Creazione Oggetti.",
      "Con la gelatina e la legna raccolte puoi creare una torcia. Seleziona l'icona della torcia e premi " + (object) '\x008C' + " per crearla.",
      "Per ottenere maggiori informazioni sugli ingredienti delle formule, premi " + (object) '\x008B' + " per entrare o uscire dall'area Ingredienti.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Ci sono diverse categorie di oggetti da creare.Puoi scorrerli premendo " + (object) '\x0080' + " e " + (string) (object) '\x0081' + ".",
      "Premi " + (object) '\x008D' + " per uscire dalla sezione Creazione Oggetti.",
      "È necessario scavare ed estrarre minerali con un piccone per creare oggetti migliori ed esplorare gli immensi sotterranei. Passa al piccone.",
      "C'è un filone di minerali nei paraggi. Estrailo completamente, puntando su di esso e tenendo premuto " + (object) '\x0081' + ".",
      "Quanto più scavi in profondità, tanto migliori saranno i minerali. Alcuni di questi richiedono un piccone migliore per essere estratti.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Se resti bloccato in un buco, è possibile posizionare delle piattaforme di legno per uscire. Crea 5 piattaforme di legno.",
      "Premi " + (object) '\x008B' + " per aprire il menu dell'Inventario. Passa alla sezione Creazione Oggetti premendo " + (string) (object) '\x0082' + " e " + (string) (object) '\x0083' + ".",
      "Ora seleziona le piattaforme di legno dalla barra dell'Inventario",
      "È più facile posizionare oggetti e strutture nella modalità Cursore Manuale. Premi " + (object) '\x008F' + " per cambiare modalità Cursore.",
      "Nella modalità Cursore Manuale, " + (object) '\x0085' + " funge da mouse. Punta il cursore e premi " + (string) (object) '\x0081' + " per posizionare le piattaforme di legno.\n\n",
      "Costruisci abbastanza piattaforme per saltare fuori dal buco.",
      "Ricorda che puoi passare da una modalità Cursore all'altra in qualunque momento, premendo " + (object) '\x008F' + ".\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "È pericoloso trovarsi fuori di notte. Costruisci un rifugio prima che faccia buio!\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Inizia a costruire i muri e il soffitto. Crea un ambiente spazioso e raccogli altra legna (o pietre) se non ne possiedi abbastanza.",
      "\n\nIl rifugio deve essere alto almeno 6 blocchi e largo 10 blocchi.",
      "Ti serve una porta per entrare e uscire. Rimuovi 3 blocchi dalla parte inferiore di un muro per fare spazio.",
      "\n\nUtilizza un'ascia per rimuovere i blocchi di legno o un piccone per rimuovere i blocchi di pietra.",
      "Per fare una porta ti serve un banco da lavoro. Crea un banco da lavoro e posizionalo all'interno dell'abitazione.",
      "\nAbbatti altri alberi se non possiedi abbastanza legna.",
      "Quando sei vicino a un banco da lavoro o a un'altra unità per la creazione (es. un'incudine o una fornace), nel menu Creazione Oggetti saranno disponibili più formule.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Avvicinati al banco da lavoro e fai una porta.",
      "\nAbbatti altri alberi se non possiedi abbastanza legna.",
      "Adesso posiziona la porta nello spazio creato nel muro. È complicato, ma risulta più facile nella modalità Cursore Manuale " + (object) '\x008F' + ".",
      "Puoi aprire e chiudere la porta. Punta su di essa e premi " + (object) '\x008D' + ".",
      "Ci sei quasi! Per rendere sicura l'abitazione, è necessario rivestire lo sfondo di quest'ultima con dei muri (es. muri di legno).\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Crea un set di muri di legno sul banco da lavoro.",
      "\nAbbatti altri alberi se non possiedi abbastanza legna.",
      "Rivesti lo sfondo dell'abitazione con muri di legno. Il compito risulta più facile nella modalità Cursore Automatico, " + (object) '\x008F' + ".",
      "Assicurati di coprire l'intero sfondo.",
      "L'abitazione ora è sicura. Perché un PNG possa abitare una stanza sono necessari: un tavolo (es. banco da lavoro), una sedia e una fonte di illuminazione (es. torcia).\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Crea una sedia e posizionala all'interno dell'abitazione.",
      "Quindi posiziona una torcia sui muri o sul pavimento dell'abitazione. Il compito è più facile nella modalità Cursore Manuale " + (object) '\x008F' + ".",
      "Questa stanza è a misura di PNG! Man mano che avanzi, molti PNG potranno trasferirsi nell'abitazione se vi sono abbastanza stanze abitabili a disposizione.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "La Guida è il primo PNG che può trasferirsi nell'abitazione. Puoi parlargli per chiedere consigli o informazioni sugli ingredienti per la creazione.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "È possibile creare un martello per distruggere mobili o muri sullo sfondo.\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      "Congratulazioni, hai completato il tutorial! Ci sono solo poche aree da esplorare su quest'isola fluttuante. Quando sei pronto, esci dal tutorial e crea un mondo completamente nuovo!\n ",
      "<c>Premi " + (object) '\x008D' + " per continuare.",
      null
    };
    private static readonly string[] TUTORIAL_ES = new string[80]
    {
      "Terraria es un juego que te permite vivir aventuras en los confines de la tierra y derrotar a los malvados jefes que se crucen en tu camino. Con este tutorial te familiarizarás con los principios básicos.\n",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Usa " + (object) '\x0084' + " para moverte.",
      "Pulsa " + (object) '\x008C' + " para saltar.",
      "Puedes dejarte caer por las plataformas de madera pulsando hacia abajo " + (object) '\x0084' + ". Intenta dejarte caer por la plataforma.",
      "Ahora, salta pulsando " + (object) '\x008C' + ".",
      "Pulsa (o mantén presionado) " + (object) '\x0081' + " para realizar acciones con el objeto actual. Apunta con " + (string) (object) '\x0085' + ".",
      "La barra de inventario está en la parte superior de la pantalla. Puedes desplazarte entre los objetos pulsando " + (object) '\x0082' + " & " + (string) (object) '\x0083' + ". Ahora, cambia a la espada.",
      "Ha aparecido un malvado monstruo. Derrótalo con la espada pulsando " + (object) '\x0081' + ".",
      "Terraria está llena de monstruos, sobre todo por la noche. Por suerte, hay muchas armas que puedes encontrar para facilitarte la vida.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Si te hieren, te curarás con el tiempo. También puedes usar comida o pociones sanadoras.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Si eliminas a ese slime conseguirás un gel. Si tuvieses madera con la que combinarlo, podrías fabricar una antorcha. Vamos a por algo de madera.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Para talar un árbol debes usar un hacha. Cambia al hacha.",
      "Tala un árbol apuntando hacia uno y manteniendo presionado " + (object) '\x0081' + ".",
      "Todos los objetos que consigas irán al inventario. Pulsa " + (object) '\x008B' + " para abrir el menú Inventario.",
      "El menú Inventario se divide en secciones. Esta zona es tu inventario principal. La barra de inventario es la fila superior de ranuras de objetos. También hay ranuras para monedas y munición (por ejemplo, flechas).\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Usa " + (object) '\x0084' + " para pasar de una ranura a otra. Usa " + (string) (object) '\x008C' + " para coger un objeto y apilarlo. Usa " + (string) (object) '\x0081' + " para mover los objetos de uno en uno.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Si quieres eliminar un objeto permanentemente, ponlo en la ranura de basura o pulsa " + (object) '\x008A' + ". \n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Pulsa " + (object) '\x0083' + " para cambiar a la sección Equipo.",
      "En la sección Equipo se colocan la armadura y los accesorios. Los objetos de las ranuras de adornos cambian el aspecto de tu personaje, pero no proporcionan bonificaciones de armadura.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Si interactúas con un cofre o un PNJ comerciante, aparecerá una sección para el mismo.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Pulsa " + (object) '\x0082' + " o " + (string) (object) '\x0083' + " para cambiar a la sección Creación.",
      "El gel y la madera que has conseguido pueden usarse para fabricar una antorcha. Selecciona el icono de antorcha y pulsa " + (object) '\x008C' + " para crearla.",
      "Si quieres obtener más información acerca de los ingredientes de una receta, pulsa " + (object) '\x008B' + " para entrar o salir de la zona de ingredientes.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Hay varias categorías de objetos que puedes crear. Puedes cambiar entre ellas pulsando " + (object) '\x0080' + " y " + (string) (object) '\x0081' + ".",
      "Pulsa " + (object) '\x008D' + " para salir del modo Creación.",
      "Para crear objetos mejores y explorar el amplio mundo subterráneo, necesitarás excavar y conseguir minerales con un pico. Cambia al pico.",
      "Hay una veta de minerales cerca. Explótala a fondo apuntando hacia ella y manteniendo presionado " + (object) '\x0081' + ".",
      "Cuanto más profundo excaves, mejores minerales encontrarás. Algunos minerales requerirán un pico de mejor calidad.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Si te quedas bloqueado en un agujero, puedes colocar plataformas de madera para salir. Fabrica 5 plataformas de madera.",
      "Pulsa " + (object) '\x008B' + " para abrir el menú Inventario. Cambia al modo Creación con " + (string) (object) '\x0082' + " y " + (string) (object) '\x0083' + ".",
      "Ahora selecciona las plataformas de madera de la barra de inventario.",
      "Colocar objetos y estructuras es más fácil en el modo cursor manual. Pulsa " + (object) '\x008F' + " para cambiar el modo de cursor.",
      "En el modo cursor manual, " + (object) '\x0085' + " actúa como un ratón. Apunta con el cursor y pulsa " + (string) (object) '\x0081' + " para colocar plataformas de madera.\n\n",
      "Construye suficientes para poder salir del agujero.",
      "Recuerda que puedes cambiar entre los modos de cursor en cualquier momento pulsando " + (object) '\x008F' + ".\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Es peligroso estar fuera por la noche. Construye un cobijo antes de que sea tarde.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Para empezar, construye muros y un techo. Debes dejar bastante espacio dentro. Si no tienes madera o piedras suficientes, consigue más.",
      "\n\nLa casa o cobijo debe tener como mínimo 6 bloques de alto y 10 de ancho.",
      "Necesitarás una puerta para entrar y salir. Quita 3 bloques de la parte inferior del muro para hacer espacio.",
      "\n\nUsa un hacha para eliminar los bloques de madera o un pico para eliminar los bloques de piedra.",
      "Para fabricar una puerta necesitarás un banco de trabajo. Crea un banco de trabajo y ponlo dentro de la casa.",
      "\nSi no tienes madera suficiente, tala más árboles.",
      "Cuando estás cerca de un banco de trabajo o de cualquier objeto de tu taller de creación (como un yunque o una forja), tendrás más recetas disponibles para construir en el menú Creación.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Ponte cerca de la mesa y construye una puerta.",
      "\nSi no tienes madera suficiente, tala más árboles.",
      "Ahora coloca la puerta en el espacio de la pared. Esto puede ser algo complicado. Será más fácil si usas el modo cursor manual, " + (object) '\x008F' + ".",
      "Puedes abrir o cerrar la puerta. Apunta hacia ella y pulsa " + (object) '\x008D' + ".",
      "Ya casi has terminado. Para hacer que la casa sea segura, necesitarás cubrir con muros (por ejemplo, paneles de madera) el fondo de la casa.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Crea unos cuantos muros de madera en el banco de trabajo.",
      "\nSi no tienes madera suficiente, tala más árboles.",
      "Cubre el fondo de la casa con muros de madera. Esto es más fácil en el modo cursor automático, " + (object) '\x008F' + ".",
      "Asegúrate de cubrir todo el fondo.",
      "La casa ya es segura. Para que una habitación sea habitable para los PNJ, necesita: una mesa (como el banco de trabajo), una fuente de luz (como una antorcha) y una silla.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Crea una silla y ponla dentro de casa.",
      "Ahora coloca una antorcha en los muros o en el suelo de la casa. Esto es más fácil en el modo cursor manual, " + (object) '\x008F' + ".",
      "A partir de ahora, esta sala podrá ser habitada por los PNJ. Conforme vayas progresando, otros PNJ se mudarán a tu casa si tienes suficientes habitaciones disponibles para ellos.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "El guía es el primer PNJ que se puede mudar a la casa. Puedes hablar con él para recibir consejos o detalles sobre los ingredientes empleados en el proceso de creación.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "Si alguna vez quieres destruir muebles o muros de fondo, puedes crear un martillo para hacerlo.\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      "¡Enhorabuena, has completado el tutorial! Solo quedan algunas zonas por explorar en esta isla flotante.¡Cuando estés preparado, sal del tutorial y crea todo un mundo nuevo para ti!\n ",
      "<c>Pulsa " + (object) '\x008D' + " para continuar.",
      null
    };
    public const char _LT_ = '\x0080';
    public const char _RT_ = '\x0081';
    public const char _LB_ = '\x0082';
    public const char _RB_ = '\x0083';
    public const char _LS_ = '\x0084';
    public const char _RS_ = '\x0085';
    public const char _DPAD_ = '\x0086';
    public const char _BACK_ = '\x0087';
    public const char _START_ = '\x0088';
    public const char _HOME_ = '\x0089';
    public const char _X_ = '\x008A';
    public const char _Y_ = '\x008B';
    public const char _A_ = '\x008C';
    public const char _B_ = '\x008D';
    public const char _LS_PRESS_ = '\x008E';
    public const char _RS_PRESS_ = '\x008F';
    public const string _LB_RB_ = "\x0082\x0083";
    public const string _RT_A_ = "\x0081\x008C";
    public const string _LT_RT_ = "\x0080\x0081";
    private const char _USE_ = '\x0081';
    private const char _INTERACT_ = '\x008D';
    private const char _INVENTORY_SELECT_ = '\x008C';
    private const char _MOVE_ = '\x0084';
    private const char _CONTROL_MODE_ = '\x0085';
    private const char _JUMP_ = '\x008C';
    private const char _INVENTORY_ = '\x008B';
    private const char _LEAVE_INVENTORY_ = '\x008D';
    private const char _MOVE_CURSOR_ = '\x0085';
    private const char _DROP_ = '\x008A';
    private const string _HB_SCROLL_ = "\x0082\x0083";

    static Lang()
    {
    }

    public static string controls(Lang.CONTROLS i)
    {
      switch (Lang.lang)
      {
        case 2:
          return Lang.CONTROLS_DE[(int) i];
        case 3:
          return Lang.CONTROLS_IT[(int) i];
        case 4:
          return Lang.CONTROLS_FR[(int) i];
        case 5:
          return Lang.CONTROLS_ES[(int) i];
        default:
          return Lang.CONTROLS_EN[(int) i];
      }
    }

    public static ControlDesc[] controls()
    {
      switch (Lang.lang)
      {
        case 2:
          return Lang.MENU_CONTROLS_DE;
        case 3:
          return Lang.MENU_CONTROLS_IT;
        case 4:
          return Lang.MENU_CONTROLS_FR;
        case 5:
          return Lang.MENU_CONTROLS_ES;
        default:
          return Lang.MENU_CONTROLS_EN;
      }
    }

    public static string itemPrefix(int prefix)
    {
      switch (Lang.lang)
      {
        case 2:
          return Lang.ITEM_PREFIX_DE[prefix];
        case 3:
          return Lang.ITEM_PREFIX_IT[prefix];
        case 4:
          return Lang.ITEM_PREFIX_FR[prefix];
        case 5:
          return Lang.ITEM_PREFIX_ES[prefix];
        default:
          return Lang.ITEM_PREFIX_EN[prefix];
      }
    }

    public static string dialog(Player player, int l)
    {
      string str1 = NPC.chrName[17];
      string str2 = NPC.chrName[18];
      string str3 = NPC.chrName[22];
      string str4 = NPC.chrName[19];
      string str5 = NPC.chrName[20];
      string str6 = NPC.chrName[38];
      string str7 = NPC.chrName[54];
      string str8 = NPC.chrName[107];
      string str9 = NPC.chrName[108];
      string str10 = NPC.chrName[124];
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case 1:
            return "I hope a scrawny kid like you isn't all that is standing between us and Cthulu's Eye.";
          case 2:
            return "Look at that shoddy armor you're wearing. Better buy some more healing potions.";
          case 3:
            return "I feel like an evil presence is watching me.";
          case 4:
            return "Sword beats paper! Get one today.";
          case 5:
            return "You want apples? You want carrots? You want pineapples? We got torches.";
          case 6:
            return "Lovely morning, wouldn't you say? Was there something you needed?";
          case 7:
            return "Night will be upon us soon, friend. Make your choices while you can.";
          case 8:
            return "You have no idea how much dirt blocks sell for overseas.";
          case 9:
            return "Ah, they will tell tales of " + player.name + " some day... good ones I'm sure.";
          case 10:
            return "Check out my dirt blocks; they are extra dirty.";
          case 11:
            return "Boy, that sun is hot! I do have some perfectly ventilated armor.";
          case 12:
            return "The sun is high, but my prices are not.";
          case 13:
            return "Oh, great. I can hear " + str10 + " and " + str2 + " arguing from here.";
          case 14:
            return "Have you seen Chith...Shith.. Chat... The big eye?";
          case 15:
            return "Hey, this house is secure, right? Right? " + player.name + "?";
          case 16:
            return "Not even a Blood Moon can stop capitalism. Let's do some business.";
          case 17:
            return "Keep your eye on the prize, buy a lense!";
          case 18:
            return "Kosh, kapleck Mog. Oh sorry, that's klingon for 'Buy something or die.'";
          case 19:
            return player.name + " is it? I've heard good things, friend!";
          case 20:
            return "I hear there's a secret treasure... oh never mind.";
          case 21:
            return "Angel Statue you say? I'm sorry, I'm not a junk dealer.";
          case 22:
            return "The last guy who was here left me some junk... er I mean... treasures!";
          case 23:
            return "I wonder if the moon is made of cheese...huh, what? Oh yes, buy something!";
          case 24:
            return "Did you say gold?  I'll take that off of ya.";
          case 25:
            return "You better not get blood on me.";
          case 26:
            return "Hurry up and stop bleeding.";
          case 27:
            return "If you're going to die, do it outside.";
          case 28:
            return "What is that supposed to mean?!";
          case 29:
            return "I don't think I like your tone.";
          case 30:
            return "Why are you even here? If you aren't bleeding, you don't need to be here. Get out.";
          case 31:
            return "WHAT?!";
          case 32:
            return "Have you seen that old man pacing around the dungeon? He looks troubled.";
          case 33:
            return "I wish " + str6 + " would be more careful.  I'm getting tired of having to sew his limbs back on every day.";
          case 34:
            return "Hey, has " + str4 + " mentioned needing to go to the doctor for any reason? Just wondering.";
          case 35:
            return "I need to have a serious talk with " + str3 + ". How many times a week can you come in with severe lava burns?";
          case 36:
            return "I think you look better this way.";
          case 37:
            return "Eww... What happened to your face?";
          case 38:
            return "MY GOODNESS! I'm good, but I'm not THAT good.";
          case 39:
            return "Dear friends we are gathered here today to bid farewell... Oh, you'll be fine.";
          case 40:
            return "You left your arm over there. Let me get that for you...";
          case 41:
            return "Quit being such a baby! I've seen worse.";
          case 42:
            return "That's gonna need stitches!";
          case 43:
            return "Trouble with those bullies again?";
          case 44:
            return "Hold on, I've got some cartoon bandages around here somewhere.";
          case 45:
            return "Walk it off, " + player.name + ", you'll be fine. Sheesh.";
          case 46:
            return "Does it hurt when you do that? Don't do that.";
          case 47:
            return "You look half digested. Have you been chasing slimes again?";
          case 48:
            return "Turn your head and cough.";
          case 49:
            return "That's not the biggest I've ever seen... Yes, I've seen bigger wounds for sure.";
          case 50:
            return "Would you like a lollipop?";
          case 51:
            return "Show me where it hurts.";
          case 52:
            return "I'm sorry, but you can't afford me.";
          case 53:
            return "I'm gonna need more gold than that.";
          case 54:
            return "I don't work for free you know.";
          case 55:
            return "I don't give happy endings.";
          case 56:
            return "I can't do anymore for you without plastic surgery.";
          case 57:
            return "Quit wasting my time.";
          case 58:
            return "I heard there is a doll that looks very similar to " + str3 + " somewhere in the underworld.  I'd like to put a few rounds in it.";
          case 59:
            return "Make it quick! I've got a date with " + str2 + " in an hour.";
          case 60:
            return "I want what " + str2 + " is sellin'. What do you mean, she doesn't sell anything?";
          case 61:
            return str5 + " is a looker.  Too bad she's such a prude.";
          case 62:
            return "Don't bother with " + str6 + ", I've got all you need right here.";
          case 63:
            return "What's " + str6 + "'s problem? Does he even realize we sell completely different stuff?";
          case 64:
            return "Man, it's a good night not to talk to anybody, don't you think, " + player.name + "?";
          case 65:
            return "I love nights like tonight.  There is never a shortage of things to kill!";
          case 66:
            return "I see you're eyeballin' the Minishark.. You really don't want to know how it was made.";
          case 67:
            return "Hey, this ain't a movie, pal. Ammo is extra.";
          case 68:
            return "Keep your hands off my gun, buddy!";
          case 69:
            return "Have you tried using purification powder on the ebonstone of the corruption?";
          case 70:
            return "I wish " + str4 + " would stop flirting with me. Doesn't he realize I'm 500 years old?";
          case 71:
            return "Why does " + str1 + " keep trying to sell me an angel statues? Everyone knows that they don't do anything.";
          case 72:
            return "Have you seen the old man walking around the dungeon? He doesn't look well at all...";
          case 73:
            return "I sell what I want! If you don't like it, too bad.";
          case 74:
            return "Why do you have to be so confrontational during a time like this?";
          case 75:
            return "I don't want you to buy my stuff. I want you to want to buy my stuff, ok?";
          case 76:
            return "Dude, is it just me or is there like a million zombies out tonight?";
          case 77:
            return "You must cleanse the world of this corruption.";
          case 78:
            return "Be safe; Terraria needs you!";
          case 79:
            return "The sands of time are flowing. And well, you are not aging very gracefully.";
          case 80:
            return "What's this about me having more 'bark' than bite?";
          case 81:
            return "So two goblins walk into a bar, and one says to the other, 'Want to get a Goblet of beer?!";
          case 82:
            return "I cannot let you enter until you free me of my curse.";
          case 83:
            return "Come back at night if you wish to enter.";
          case 84:
            return "My master cannot be summoned under the light of day.";
          case 85:
            return "You are far too weak to defeat my curse.  Come back when you aren't so worthless.";
          case 86:
            return "You pathetic fool.  You cannot hope to face my master as you are now.";
          case 87:
            return "I hope you have like six friends standing around behind you.";
          case 88:
            return "Please, no, stranger. You'll only get yourself killed.";
          case 89:
            return "You just might be strong enough to free me from my curse...";
          case 90:
            return "Stranger, do you possess the strength to defeat my master?";
          case 91:
            return "Please! Battle my captor and free me! I beg you!";
          case 92:
            return "Defeat my master, and I will grant you passage into the Dungeon.";
          case 93:
            return "Trying to get past that ebonrock, eh?  Why not introduce it to one of these explosives!";
          case 94:
            return "Hey, have you seen a clown around?";
          case 95:
            return "There was a bomb sitting right here, and now I can't seem to find it...";
          case 96:
            return "I've got something for them zombies alright!";
          case 97:
            return "Even " + str4 + " wants what I'm selling!";
          case 98:
            return "Would you rather have a bullet hole or a grenade hole? That's what I thought.";
          case 99:
            return "I'm sure " + str2 + " will help if you accidentally lose a limb to these.";
          case 100:
            return "Why purify the world when you can just blow it up?";
          case 101:
            return "If you throw this one in the bathtub and close all the windows, it'll clear your sinuses and pop your ears!";
          case 102:
            return "Wanna play Fuse Chicken?";
          case 103:
            return "Hey, could you sign this Griefing Waiver?";
          case 104:
            return "NO SMOKING IN HERE!!";
          case 105:
            return "Explosives are da' bomb these days.  Buy some now!";
          case 106:
            return "It's a good day to die!";
          case 107:
            return "I wonder what happens if I... (BOOM!)... Oh, sorry, did you need that leg?";
          case 108:
            return "Dynamite, my own special cure-all for what ails ya.";
          case 109:
            return "Check out my goods; they have explosive prices!";
          case 110:
            return "I keep having vague memories of tying up a woman and throwing her in a dungeon.";
          case 111:
            return "... we have a problem! It's a Blood Moon out there!";
          case 112:
            return "T'were I younger, I would ask " + str2 + " out. I used to be quite the lady killer.";
          case 113:
            return "That Red Hat of yours looks familiar...";
          case 114:
            return "Thanks again for freeing me from my curse. Felt like something jumped up and bit me.";
          case 115:
            return "Mama always said I would make a great tailor.";
          case 116:
            return "Life's like a box of clothes; you never know what you are gonna wear!";
          case 117:
            return "Of course embroidery is hard! If it wasn't hard, no one would do it! That's what makes it great.";
          case 118:
            return "I know everything they is to know about the clothierin' business.";
          case 119:
            return "Being cursed was lonely, so I once made a friend out of leather. I named him Wilson.";
          case 120:
            return "Thank you for freeing me, human.  I was tied up and left here by the other goblins.  You could say that we didn't get along very well.";
          case 121:
            return "I can't believe they tied me up and left me here just for pointing out that they weren't going east!";
          case 122:
            return "Now that I'm an outcast, can I throw away the spiked balls? My pockets hurt.";
          case 123:
            return "Looking for a gadgets expert? I'm your goblin!";
          case 124:
            return "Thanks for your help. Now, I have to finish pacing around aimlessly here. I'm sure we'll meet again.";
          case 125:
            return "I thought you'd be taller.";
          case 126:
            return "Hey...what's " + str10 + " up to? Have you...have you talked to her, by chance?";
          case (int) sbyte.MaxValue:
            return "Hey, does your hat need a motor? I think I have a motor that would fit exactly in that hat.";
          case 128:
            return "Yo, I heard you like rockets and running boots, so I put some rockets in your running boots.";
          case 129:
            return "Silence is golden. Duct tape is silver.";
          case 130:
            return "YES, gold is stronger than iron. What are they teaching these humans nowadays?";
          case 131:
            return "You know, that mining helmet-flipper combination was a much better idea on paper.";
          case 132:
            return "Goblins are surprisingly easy to anger. In fact, they could start a war over cloth!";
          case 133:
            return "To be honest, most goblins aren't exactly rocket scientists. Well, some are.";
          case 134:
            return "Do you know why we all carry around these spiked balls? Because I don't.";
          case 135:
            return "I just finished my newest creation! This version doesn't explode violently if you breathe on it too hard.";
          case 136:
            return "Goblin thieves aren't very good at their job. They can't even steal from an unlocked chest!";
          case 137:
            return "Thanks for saving me, friend! This bondage was starting to chafe.";
          case 138:
            return "Ohh, my hero!";
          case 139:
            return "Oh, how heroic! Thank you for saving me, young lady!";
          case 140:
            return "Oh, how heroic! Thank you for saving me, young man!";
          case 141:
            return "Now that we know each other, I can move in with you, right?";
          case 142:
            return "Well, hi there, " + str3 + "! What can I do for you today?";
          case 143:
            return "Well, hi there, " + str6 + "! What can I do for you today?";
          case 144:
            return "Well, hi there, " + str8 + "! What can I do for you today?";
          case 145:
            return "Well, hi there, " + str2 + "! What can I do for you today?";
          case 146:
            return "Well, hi there, " + str10 + "! What can I do for you today?";
          case 147:
            return "Well, hi there, " + str5 + "! What can I do for you today?";
          case 148:
            return "Want me to pull a coin from behind your ear? No? Ok.";
          case 149:
            return "Do you want some magic candy? No? Ok.";
          case 150:
            return "I make a rather enchanting hot chocolate if you'd be inter... No? Ok.";
          case 151:
            return "Are you here for a peek at my crystal ball?";
          case 152:
            return "Ever wanted an enchanted ring that turns rocks into slimes? Well neither did I.";
          case 153:
            return "Someone once told me friendship is magic. That's ridiculous. You can't turn people into frogs with friendship.";
          case 154:
            return "I can see your future now... You will buy a lot of items from me!";
          case 155:
            return "I once tried to bring an Angel Statue to life. It didn't do anything.";
          case 156:
            return "Thanks! It was just a matter of time before I ended up like the rest of the skeletons down here.";
          case 157:
            return "Hey, watch where you're going! I was over there a little while ago!";
          case 158:
            return "Hold on, I've almost got wifi going down here.";
          case 159:
            return "But I was almost done putting blinking lights up here!";
          case 160:
            return "DON'T MOVE. I DROPPED MY CONTACT.";
          case 161:
            return "All I want is for the switch to make the... What?!";
          case 162:
            return "Oh, let me guess. Didn't buy enough wire. Idiot.";
          case 163:
            return "Just-could you just... Please? Ok? Ok. Ugh.";
          case 164:
            return "I don't appreciate the way you're looking at me. I am WORKING right now.";
          case 165:
            return "Hey, " + player.name + ", did you just come from " + str8 + "'s? Did he say anything about me by chance?";
          case 166:
            return str4 + " keeps talking about pressing my pressure plate. I told him it was for stepping on.";
          case 167:
            return "Always buy more wire than you need!";
          case 168:
            return "Did you make sure your device was plugged in?";
          case 169:
            return "Oh, you know what this house needs? More blinking lights.";
          case 170:
            return "You can tell a Blood Moon is out when the sky turns red. There is something about it that causes monsters to swarm.";
          case 171:
            return "Hey, buddy, do you know where any deathweed is? Oh, no reason; just wondering, is all.";
          case 172:
            return "If you were to look up, you'd see that the moon is red right now.";
          case 173:
            return "You should stay indoors at night. It is very dangerous to be wandering around in the dark.";
          case 174:
            return "Greetings, " + player.name + ". Is there something I can help you with?";
          case 175:
            return "I am here to give you advice on what to do next.  It is recommended that you talk with me anytime you get stuck.";
          case 176:
            return "They say there is a person who will tell you how to survive in this land... oh wait. That's me.";
          case 177:
            return "You can use your pickaxe to dig through dirt, and your axe to chop down trees. Just place your cursor over the tile and press " + (object) '\x0081' + "!";
          case 178:
            return "If you want to survive, you will need to create weapons and shelter. Start by chopping down trees and gathering wood.";
          case 179:
            return "Press " + (object) '\x008B' + "to access your crafting menu. When you have enough wood, create a workbench. This will allow you to create more complicated things, as long as you are standing close to it.";
          case 180:
            return "You can build a shelter by placing wood or other blocks in the world. Don't forget to create and place walls.";
          case 181:
            return "Once you have a wooden sword, you might try to gather some gel from the slimes. Combine wood and gel to make a torch!";
          case 182:
            return "To interact with backgrounds and placed objects, use a hammer!";
          case 183:
            return "You should do some mining to find metal ore. You can craft very useful things with it.";
          case 184:
            return "Now that you have some ore, you will need to turn it into a bar in order to make items with it. This requires a furnace!";
          case 185:
            return "You can create a furnace out of torches, wood, and stone. Make sure you are standing near a work bench.";
          case 186:
            return "You will need an anvil to make most things out of metal bars.";
          case 187:
            return "Anvils can be crafted out of iron, or purchased from a merchant.";
          case 188:
            return "Underground are crystal hearts that can be used to increase your max life. You will need a hammer to obtain them.";
          case 189:
            return "If you gather 10 fallen stars, they can be combined to create an item that will increase your magic capacity.";
          case 190:
            return "Stars fall all over the world at night. They can be used for all sorts of usefull things. If you see one, be sure to grab it because they disappear after sunrise.";
          case 191:
            return "There are many different ways you can attract people to move in to our town. They will of course need a home to live in.";
          case 192:
            return "In order for a room to be considered a home, it needs to have a door, chair, table, and a light source.  Make sure the house has walls as well.";
          case 193:
            return "Two people will not live in the same home. Also, if their home is destroyed, they will look for a new place to live.";
          case 194:
            return "You can use the housing interface to assign and view housing.";
          case 195:
            return "If you want a merchant to move in, you will need to gather plenty of money. 50 silver coins should do the trick!";
          case 196:
            return "For a nurse to move in, you might want to increase your maximum life.";
          case 197:
            return "If you had a gun, I bet an arms dealer might show up to sell you some ammo!";
          case 198:
            return "You should prove yourself by defeating a strong monster. That will get the attention of a dryad.";
          case 199:
            return "Make sure to explore the dungeon thoroughly. There may be prisoners held deep within.";
          case 200:
            return "Perhaps the old man by the dungeon would like to join us now that his curse has been lifted.";
          case 201:
            return "Hang on to any bombs you might find. A demolitionist may want to have a look at them.";
          case 202:
            return "Are goblins really so different from us that we couldn't live together peacefully?";
          case 203:
            return "I heard there was a powerfully wizard who lives in these parts.  Make sure to keep an eye out for him next time you go underground.";
          case 204:
            return "If you combine lenses at a demon altar, you might be able to find a way to summon a powerful monster. You will want to wait until night before using it, though.";
          case 205:
            return "You can create worm bait with rotten chunks and vile powder. Make sure you are in a corrupt area before using it.";
          case 206:
            return "Demonic altars can usually be found in the corruption. You will need to be near them to craft some items.";
          case 207:
            return "You can make a grappling hook from a hook and 3 chains. Skeletons found deep underground usually carry hooks, and chains can be made from iron bars.";
          case 208:
            return "If you see a pot, be sure to smash it open. They contain all sorts of useful supplies.";
          case 209:
            return "There is treasure hidden all over the world. Some amazing things can be found deep underground!";
          case 210:
            return "Smashing a shadow orb will sometimes cause a meteor to fall out of the sky. Shadow orbs can usually be found in the chasms around corrupt areas.";
          case 211:
            return "You should focus on gathering more heart crystals to increase your maximum life.";
          case 212:
            return "Your current equipment simply won't do. You need to make better armor.";
          case 213:
            return "I think you are ready for your first major battle. Gather some lenses from the eyeballs at night and take them to a demon altar.";
          case 214:
            return "You will want to increase your life before facing your next challenge. Fifteen hearts should be enough.";
          case 215:
            return "The ebonstone in the corruption can be purified using some powder from a dryad, or it can be destroyed with explosives.";
          case 216:
            return "Your next step should be to explore the corrupt chasms.  Find and destroy any shadow orb you find.";
          case 217:
            return "There is a old dungeon not far from here. Now would be a good time to go check it out.";
          case 218:
            return "You should make an attempt to max out your available life. Try to gather twenty hearts.";
          case 219:
            return "There are many treasures to be discovered in the jungle, if you are willing to dig deep enough.";
          case 220:
            return "The underworld is made of a material called hellstone. It's perfect for making weapons and armor.";
          case 221:
            return "When you are ready to challenge the keeper of the underworld, you will have to make a living sacrifice. Everything you need for it can be found in the underworld.";
          case 222:
            return "Make sure to smash any demon altar you can find. Something good is bound to happen if you do!";
          case 223:
            return "Souls can sometimes be gathered from fallen creatures in places of extreme light or dark.";
          case 224:
            return "Ho ho ho, and a bottle of... Egg Nog!";
          case 225:
            return "Care to bake me some cookies?";
          case 226:
            return "What? You thought I wasn't real?";
          case 227:
            return "I managed to sew your face back on. Be more careful next time.";
          case 228:
            return "That's probably going to leave a scar.";
          case 229:
            return "All better. I don't want to see you jumping off anymore cliffs.";
          case 230:
            return "That didn't hurt too bad, now did it?";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case 1:
            return "Ich hoffe, du dünnes Hemd bist nicht das Einzige, was zwischen Chtulus Auge und uns steht.";
          case 2:
            return "Was für eine schäbige Rüstung du trägst. Kauf lieber ein paar Heiltränke.";
          case 3:
            return "Ich habe das Gefühl, dass mich eine böse Kraft beobachtet.";
          case 4:
            return "Schwert schlägt Papier! Hol dir noch heute eins.";
          case 5:
            return "Du möchtest Äpfel? Du willst Karotten? Ananas? Wir haben Fackeln.";
          case 6:
            return "Ein schöner Morgen, nicht wahr? War da noch was, was du brauchst?";
          case 7:
            return "Die Nacht wird bald hereinbrechen, mein Freund. Entscheide dich, solange du kannst.";
          case 8:
            return "Du hast keine Ahnung, wie gut sich Dreckblöcke nach Übersee verkaufen.";
          case 9:
            return "Ach, eines Tages werden sie Geschichten über" + player.name + " erzählen ... sicher gute.";
          case 10:
            return "Schau dir mal meine Dreckblöcke an; die sind wirklich super-dreckig.";
          case 11:
            return "Junge, Junge, wie die Sonne brennt! Ich hab da eine tolle klimatisierte Rüstung.";
          case 12:
            return "Die Sonne steht zwar hoch, meine Preise sind's aber nicht.";
          case 13:
            return "Toll. Ich kann " + str10 + " und " + str2 + " von hier aus diskutieren hören.";
          case 14:
            return "Hast du Chith ... Shith.. Chat... das große Auge gesehen?";
          case 15:
            return "Heh, dieses Haus ist doch wohl sicher? Oder? " + player.name + "?";
          case 16:
            return "Nicht mal ein Blutmond kann den Kapitalismus stoppen. Lass uns also Geschäfte machen.";
          case 17:
            return "Achte auf den Preis, kaufe eine Linse!";
          case 18:
            return "Kosh, kapleck Mog. Oha, sorry. Das ist klingonisch für: Kauf oder stirb!";
          case 19:
            return player.name + " ist es? Ich habe nur Gutes über dich gehört!";
          case 20:
            return "Ich hörte, es gibt einen geheimen Schatz ... oh, vergiss es!";
          case 21:
            return "Engelsstatue, sagst du? Tut mir Leid, ich bin kein Nippesverkäufer.";
          case 22:
            return "Der letzte Typ, der hier war, hinterließ mir einigen Nippes, äh, ich meine ... Schätze!";
          case 23:
            return "Ich frage mich, ob der Mond aus Käse ist ... huch, was? Oh, ja, kauf etwas!";
          case 24:
            return "Hast du Gold gesagt? Ich nehm' dir das ab.";
          case 25:
            return "Blute mich bloß nicht voll!";
          case 26:
            return "Mach schon und hör mit dem Bluten auf!";
          case 27:
            return "Wenn du stirbst, dann bitte draußen.";
          case 28:
            return "Was soll das heißen?!";
          case 29:
            return "Irgendwie gefällt mir dein Ton nicht.";
          case 30:
            return "Warum bist du überhaupt hier? Wenn du nicht blutest, gehörst du nicht hierher. Raus jetzt!";
          case 31:
            return "WAS?!";
          case 32:
            return "Hast du den Greis um das Verlies schreiten sehen? Der scheint Probleme zu haben.";
          case 33:
            return "Ich wünschte, " + str6 + " wäre vorsichtiger. Es nervt mich, täglich seine Glieder zusammennähen zu müssen.";
          case 34:
            return "Heh, hat " + str4 + " den Grund für einen notwendigen Arztbesuch erwähnt? Ich wundere mich nur.";
          case 35:
            return "Ich muss mal ein ernsthaftes Wort mit  " + str3 + " reden. Wie oft kann man in einer Woche mit schweren Lavaverbrennungen hereinkommen?";
          case 36:
            return "Ich finde, du siehst so besser aus.";
          case 37:
            return "Ähhh ... was ist denn mit deinem Gesicht passiert?";
          case 38:
            return "MEINE GÜTE! Ich bin gut, aber ich bin nicht SO gut.";
          case 39:
            return "Liebe Freunde, wir sind zusammengekommen, um Aufwiedersehen zu sagen ... Ach, es wird schon werden.";
          case 40:
            return "Du hast deinen Arm da drüben gelassen. Lass mich ihn holen ...";
          case 41:
            return "Hör schon auf, wie ein Baby zu plärren! Ich habe Schlimmeres gesehen.";
          case 42:
            return "Das geht nicht ohne ein paar Stiche!";
          case 43:
            return "Schon wieder Ärger mit diesen Rabauken?";
          case 44:
            return "Halt durch. Ich hab hier irgendwo ein paar hübsch bedruckte Pflaster.";
          case 45:
            return "Hör schon auf, " + player.name + ", du überstehst das schon. Mist.";
          case 46:
            return "Tut es weh, wenn du das machst? Tu das nicht.";
          case 47:
            return "Du siehst halb verdaut aus. Hast du schon wieder Schleime gejagt?";
          case 48:
            return "Dreh deinen Kopf und huste!";
          case 49:
            return "Ich habe schon Schlimmeres gesehen ... ja, ganz sicher habe ich schon größere Wunden gesehen.";
          case 50:
            return "Möchtest du einen Lollipop?";
          case 51:
            return "Zeig mir, wo es weh tut.";
          case 52:
            return "Tut mir leid, aber ich bin viel zu teuer für dich.";
          case 53:
            return "Dafür brauche ich mehr Gold.";
          case 54:
            return "Ich arbeite schließlich nicht umsonst, weißt du.";
          case 55:
            return "Ich verschenke keine Happy-Ends.";
          case 56:
            return "Ohne eine Schönheitsoperation kann ich nicht mehr für dich tun .";
          case 57:
            return "Hör auf, meine Zeit zu verschwenden!";
          case 58:
            return "Ich habe gehört, es gibt eine Puppe in der Unterwelt, die " + str3 + " sehr ähnlich sieht. Ich würde sie gerne mit ein paar Kugeln durchlöchern.";
          case 59:
            return "Mach schnell! Ich habe in einer Stunde ein Date mit " + str2 + ".";
          case 60:
            return "Ich möchte das, was " + str2 + "  verkauft. Was heißt, sie verkauft nichts?";
          case 61:
            return str5 + " ist hübsch. Zu dumm, dass sie so prüde ist.";
          case 62:
            return "Halte dich nicht mit " + str6 + " auf, ich habe alles, was du brauchst, hier.";
          case 63:
            return "Was ist eigentlich mit " + str6 + " los? Kriegt der mal mit, dass wir ganz andere Sachen verkaufen?";
          case 64:
            return "Das ist eine gute Nacht, um mit niemandem zu sprechen, denkst du nicht, " + player.name + "?";
          case 65:
            return "Ich liebe Nächte wie diese. Es gibt immer genug zu töten!";
          case 66:
            return "Wie ich sehe, starrst du den Minihai an ... Du solltest lieber nicht fragen, wie der entstand.";
          case 67:
            return "Moment, das ist kein Film, Freundchen. Munition geht extra.";
          case 68:
            return "Hände weg von meinem Gewehr, Kumpel!";
          case 69:
            return "Hast du versucht, das Reinigungspulver auf dem Ebenstein des Verderbens auszuprobieren?";
          case 70:
            return "Ich wünschte, " + str4 + " würde aufhören, mit mir zu flirten. Versteht er nicht, dass ich 500 Jahre alt bin?";
          case 71:
            return "Warum versucht " + str1 + " , mir Engelsstatuen zu verkaufen? Jeder weiß, dass sie nutzlos sind.";
          case 72:
            return "Hast du den Greis um das Verlies herumgehen sehen? Der sieht gar nicht gut aus ...";
          case 73:
            return "Ich verkaufe, was ich will! Dein Pech, wenn du es nicht magst.";
          case 74:
            return "Warum bist du in einer Zeit wie dieser so aggressiv?";
          case 75:
            return "Ich möchte nicht, dass du meine Sachen kaufst, sondern dass du dir wünschst, sie zu kaufen, okay?";
          case 76:
            return "Kommt es mir nur so vor oder sind heute Nacht eine Million Zombies draußen?";
          case 77:
            return "Du musst die Welt von diesem Verderben befreien.";
          case 78:
            return "Pass auf dich auf, Terraria braucht dich!";
          case 79:
            return "Der Zahn der Zeit nagt und du alterst nicht gerade würdevoll.";
          case 80:
            return "Was soll das heißen: Ich belle mehr als ich beiße?";
          case 81:
            return "Zwei Goblins kommen in einen Stoffladen. Sagt der eine zum anderen: Sitzt du gerne auf Gobelin?";
          case 82:
            return "Ich kann dich erst hineinlassen, wenn du mich von meinem Fluch befreit hast.";
          case 83:
            return "Komm in der Nacht wieder, wenn du hineinwillst.";
          case 84:
            return "Mein Meister kann nicht bei Tageslicht herbeigerufen werden.";
          case 85:
            return "Du bist viel zu schwach, um meinen Fluch zu brechen. Komm wieder, wenn du was aus dir gemacht hast.";
          case 86:
            return "Du armseliger Wicht. So kannst du meinem Meister nicht gegenübertreten.";
          case 87:
            return "Ich hoffe, du hast mindestens sechs Freunde, die hinter dir stehen.";
          case 88:
            return "Bitte nicht, Fremdling. Du bringst dich nur selbst um.";
          case 89:
            return "Du könntest tatsächlich stark genug sein, um mich von meinem Fluch zu befreien ...";
          case 90:
            return "Fremdling, hast du die Kraft, meinen Meister zu besiegen?";
          case 91:
            return "Bitte! Bezwinge meinen Kerkermeister und befreie mich! Ich flehe dich an!";
          case 92:
            return "Besiege meinen Meister und ich gewähre dir den Zutritt in das Verlies.";
          case 93:
            return "Du versuchst, hinter den Ebenstein zu kommen? Warum führst du ihn nicht mit diesen Explosiva zusammen?";
          case 94:
            return "Heh, hast du hier in der Gegend einen Clown gesehen?";
          case 95:
            return "Genau hier war doch eine Bombe und jetzt kann ich sie nicht finden ...";
          case 96:
            return "Ich habe etwas für diese Zombies!";
          case 97:
            return "Sogar " + str4 + " ist scharf auf meine Waren!";
          case 98:
            return "Hättest du lieber das Einschussloch eines Gewehrs oder das einer Granate? Das dachte ich mir.";
          case 99:
            return "Ich bin sicher, dass " + str2 + " dir helfen wird, wenn du versehentlich ein Glied verlierst.";
          case 100:
            return "Warum willst du die Welt reinigen, wenn du sie einfach in die Luft jagen kannst?";
          case 101:
            return "Wenn du das hier in die Badewanne schmeißt und alle Fenster schließt, durchpustet es deine Nasenhöhlen und  dir fliegen die Ohren weg!";
          case 102:
            return "Möchtest du mal Grillhähnchen spielen?";
          case 103:
            return "Könntest du hier unterschreiben, dass du nicht jammern wirst?";
          case 104:
            return "RAUCHEN IST HIER NICHT ERLAUBT!!";
          case 105:
            return "Sprengstoffe sind zur Zeit der Knaller. Kauf dir jetzt welche!";
          case 106:
            return "Ein schöner Tag, um zu sterben!";
          case 107:
            return "Ich frage mich, was passiert, wenn ich ... (BUMM!) ... Oha, sorry, brauchtest du dieses Bein noch?";
          case 108:
            return "Dynamit, mein ganz spezielles Heilmittelchen - für alles, was schmerzt.";
          case 109:
            return "Schau dir meine Waren an - sie haben hochexplosive Preise!";
          case 110:
            return "Ich erinnere mich vage an eine Frau, die ich fesselte und in das Verlies warf.";
          case 111:
            return "... wir haben ein Problem! Es ist Blutmond!";
          case 112:
            return "Wenn ich jünger wäre, würde ich mit " + str2 + " ausgehen wollen. Ich war mal ein Womanizer.";
          case 113:
            return "Dein roter Hut kommt mir bekannt vor ...";
          case 114:
            return "Danke nochmals, dass du mich von meinem Fluch befreit hast. Es fühlte sich an, als hätte mich etwas angesprungen und gebissen.";
          case 115:
            return "Mama sagte immer, dass ich einen guten Schneider abgeben würde.";
          case 116:
            return "Das Leben ist wie ein Kleiderschrank; du weißt nie, was du tragen wirst!";
          case 117:
            return "Natürlich ist die Stickerei schwierig! Wenn es nicht schwierig wäre, würde es niemand machen! Das macht es so großartig.";
          case 118:
            return "Ich weiß alles, was man über das Kleidergeschäft wissen muss.";
          case 119:
            return "Das Leben mit dem Fluch war einsam, deshalb fertigte ich mir aus Leder einen Freund an. Ich nannte ihn Wilson.";
          case 120:
            return "Danke für die Befreiung, Mensch. Ich wurde gefesselt und von den anderen Goblins hier zurückgelassen. Man kann sagen, dass wir nicht besonders gut miteinander auskamen.";
          case 121:
            return "Ich kann nicht glauben, dass sie mich fesselten und hier ließen, nur um klarzumachen, dass sie nicht nach Osten gehen.";
          case 122:
            return "Darf ich nun, da ich zu den Verstoßenen gehöre, meine Stachelkugeln wegwerfen? Sie pieken durch die Taschen.";
          case 123:
            return "Suchst du einen Bastelexperten? Dann bin ich dein Goblin!";
          case 124:
            return "Danke für deine Hilfe. Jetzt muss ich erst mal aufhören, hier ziellos herumzuschreiten. Wir begegnen uns sicher wieder.";
          case 125:
            return "Ich hielt dich für größer.";
          case 126:
            return "Heh ... was macht " + str10 + " so? Hast du ... hast du vielleicht mit ihr gesprochen?";
          case (int) sbyte.MaxValue:
            return "Wäre ein Motor für deinen Hut nicht schick? Ich glaube, ich habe einen Motor, der genau hineinpasst.";
          case 128:
            return "Ja, ich hab schon gehört, dass du Raketen und Laufstiefel magst. Deshalb habe ich ein paar Raketen in deine Laufstiefel montiert.";
          case 129:
            return "Schweigen ist Gold. Klebeband ist Silber.";
          case 130:
            return "Ja! Gold ist stärker als Eisen. Was bringt man den Menschen heutzutage eigentlich bei?";
          case 131:
            return "Diese Bergmanns-Helm-Flossen-Kombination sah auf dem Papier viel besser aus.";
          case 132:
            return "Goblins kann man erstaunlich leicht auf die Palme bringen. Die würden sogar wegen Kleidern einen Krieg anfangen.";
          case 133:
            return "Um ehrlich zu sein, Goblins sind nicht gerade Genies oder Astroforscher. Naja, bis auf ein paar Ausnahmen.";
          case 134:
            return "Weißt du eigentlich, warum wir alle diese Stachelkugeln mit uns herumtragen? Ich weiß es nämlich nicht.";
          case 135:
            return "Meine neuste Erfindung ist fertig! Diese Version explodiert nicht, wenn du sie heftig anhauchst.";
          case 136:
            return "Goblin-Diebe sind nicht besonders gut in ihrem Job. Sie können nicht mal was aus einer unverschlossenen Truhe klauen.";
          case 137:
            return "Danke für die Rettung, mein Freund! Die Fesseln fingen an, zu scheuern.";
          case 138:
            return "Oh, mein Held!";
          case 139:
            return "Oh, wie heroisch! Danke für die Rettung, Lady!";
          case 140:
            return "Oh, wie heroisch! Danke für die Rettung, mein Herr!";
          case 141:
            return "Nun da wir uns kennen, kann ich doch bei dir einziehen, oder?";
          case 142:
            return "Hallo, " + str3 + "! Was kann ich heute für dich tun?";
          case 143:
            return "Hallo, " + str6 + "! Was kann ich heute für dich tun?";
          case 144:
            return "Hallo, " + str8 + "! Was kann ich heute für dich tun?";
          case 145:
            return "Hallo, " + str2 + "! Was kann ich heute für dich tun?";
          case 146:
            return "Hallo, " + str10 + "! Was kann ich heute für dich tun?";
          case 147:
            return "Hallo, " + str5 + "! Was kann ich heute für dich tun?";
          case 148:
            return "Möchtest du, dass ich eine Münze hinter deinem Ohr hervorziehe? Nein? Gut.";
          case 149:
            return "Möchtest du vielleicht magische Süßigkeiten? Nein? Gut.";
          case 150:
            return "Ich braue eine heiße Zauber-Schokolade, wenn du inter ... Nein? Gut.";
          case 151:
            return "Bist du hier, um einen Blick in meine Kristallkugel zu werfen?";
          case 152:
            return "Hast du dir je einen verzauberten Ring gewünscht, der Steine in Schleime verwandelt? Ich auch nicht.";
          case 153:
            return "Jemand sagte mir mal, Freundschaft sei magisch. Das ist lächerlich. Du kannst mit Freundschaft keine Menschen in Frösche verwandeln.";
          case 154:
            return "Jetzt kann ich deine Zukunft sehen ... Du wirst mir eine Menge Items abkaufen!";
          case 155:
            return "Ich habe mal versucht, eine Engelsstatue zu beleben. Hat überhaupt nichts gebracht!";
          case 156:
            return "Danke! Es wäre nur eine Frage der Zeit gewesen, bis aus mir eines der Skelette hier geworden wäre.";
          case 157:
            return "Pass auf, wo du hingehst! Ich war vor einer Weile dort drüben.";
          case 158:
            return "Warte, ich habe es fast geschafft, hier unten WiFi zu installieren.";
          case 159:
            return "Aber ich hatte es fast geschafft, hier oben blinkende Lichter anzubringen.";
          case 160:
            return "BEWEG DICH NICHT. ICH HABE MEINE KONTAKTLINSE VERLOREN.";
          case 161:
            return "Ich möchte nur den Schalter ... Was?!";
          case 162:
            return "Oh, lass mich raten. Nicht genügend Kabel gekauft, Idiot.";
          case 163:
            return "Könntest du vielleicht ... bitte? Ja? Gut. Uff!";
          case 164:
            return "Mir gefällt nicht, wie du mich anschaust. Ich ARBEITE gerade.";
          case 165:
            return "Sag, " + player.name + ", kommst du gerade von " + str8 + "? Hat er vielleicht etwas über mich gesagt?";
          case 166:
            return str4 + " spricht immer davon, auf meine Druckplatten zu drücken. Ich habe ihm gesagt, die ist zum Drauftreten.";
          case 167:
            return "Kaufe immer etwas mehr Kabel als nötig!";
          case 168:
            return "Hast du dich vergewissert, dass dein Gerät angeschlossen ist?";
          case 169:
            return "Oh, weißt du, was dieses Haus noch braucht? Mehr blinkende Lichter.";
          case 170:
            return "Du erkennst den Blutmond an der Rotfärbung des Himmels. Irgendetwas daran lässt Monster ausschwärmen.";
          case 171:
            return "Weißt du vielleicht, wo Todeskraut ist? Nein, es hat keinen Grund. Ich frag mich das bloß.";
          case 172:
            return "Wenn du mal hochschauen würdest, würdest du bemerken, dass der Mond rot ist.";
          case 173:
            return "Du solltest in der Nacht drinnen bleiben. Es ist sehr gefährlich, in der Dunkelheit umherzustreifen.";
          case 174:
            return "Sei gegrüßt, " + player.name + ". Gibt es etwas, das ich für dich tun kann?";
          case 175:
            return "Ich bin hier, um dir zu raten, was du als Nächstes tust. Du solltest immer zu mir kommen, wenn du feststeckst.";
          case 176:
            return "Man sagt, es gibt jemanden, der dir erklaert, wie man in diesem Land überlebt ... oh, Moment. Das bin ja ich.";
          case 177:
            return "Du kannst deine Spitzhacke zum Graben im Dreck verwenden und deine Axt zum Holzfällen. Bewege einfach deinen Zeiger über das Feld und klicke!";
          case 178:
            return "Wenn du überleben willst, musst du Waffen und Zufluchten bauen. Fälle dazu Bäume und sammle das Holz.";
          case 179:
            return "Drücke " + (object) '\x008B' + " zum Aufrufen des Handwerksmenüs. Wenn du genügend Holz hast, stelle eine Werkbank zusammen. Damit kannst du komplexere Sachen herstellen, solange du nahe genug bei ihr stehst.";
          case 180:
            return "Du kannst durch Platzieren von Holz oder anderen Blöcken in der Welt eine Zuflucht bauen. Vergiss dabei nicht, auch Wände zu bauen und aufzustellen.";
          case 181:
            return "Wenn du einmal ein Holzschwert hast, kannst du versuchen, etwas Glibber von den Schleimen zu sammeln. Kombiniere Holz und Glibber zur Herstellung einer Fackel.";
          case 182:
            return "Verwende einen Hammer zum Interagieren mit Hintergründen und platzierten Objekten!";
          case 183:
            return "Du solltest ein bisschen Bergbau betreiben, um Gold zu finden. Du kannst sehr nützliche Dinge damit herstellen.";
          case 184:
            return "Jetzt, da du etwas Gold hast, musst du es in einen Barren verwandeln, um damit Items zu erschaffen. Dazu brauchst du einen Schmelzofen!";
          case 185:
            return "Du kannst einen Schmelzofen aus Fackeln, Holz und Steinen herstellen. Achte dabei darauf, dass du neben einer Werkbank stehst.";
          case 186:
            return "Zum Herstellen der meisten Sachen aus einem Metallbarren wirst du einen Amboss brauchen.";
          case 187:
            return "Ambosse können aus Eisen hergestellt oder von einem Händler gekauft werden.";
          case 188:
            return "Unterirdisch finden sich Kristallherzen, die verwendet werden können, um deine maximale Lebensspanne zu erhöhen. Um sie zu erhalten, benötigst du einen Hammer.";
          case 189:
            return "Wenn du 10 Sternschnuppen gesammelt hast, können sie zur Herstellung eines Items kombiniert werden. Dieses Item erhöht deine magische Fähigkeit.";
          case 190:
            return "Sterne fallen nachts auf der ganzen Welt herunter. Sie können für alle möglichen nützlichen Dinge verwendet werden. Wenn du einen erspäht hast, dann greif ihn dir schnell - sie verschwinden nach Sonnenaufgang.";
          case 191:
            return "Es gibt viele Möglichkeiten, wie du Menschen dazu bewegen kannst, in unsere Stadt zu ziehen. Sie brauchen zuallererst ein Zuhause.";
          case 192:
            return "Damit ein Raum wie ein Heim wirkt, braucht es eine Tür, einen Stuhl, einen Tisch und eine Lichtquelle. Achte darauf, dass das Haus auch Wände hat.";
          case 193:
            return "Zwei Menschen werden nicht im selben Haus leben wollen. Außerdem brauchen sie ein neues Zuhause, wenn ihr Heim zerstört wurde.";
          case 194:
            return "Du kannst das Behausungsinterface verwenden, um ein Haus zuzuweisen und anzuschauen. Öffne dein Inventar und klicke auf das Haus-Symbol.";
          case 195:
            return "Wenn du willst, dass ein Händler einzieht, brauchst du eine Menge Geld. 50 Silbermünzen sollten aber reichen.";
          case 196:
            return "Damit eine Krankenschwester einzieht, solltest du deine maximale Lebensspanne erhöhen.";
          case 197:
            return "Wenn du ein Gewehr hast, taucht garantiert ein Waffenhändler auf, um dir Munition zu verkaufen!";
          case 198:
            return "Du solltest dich selbst testen, indem du ein starkes Monster besiegst. Das wird die Aufmerksamkeit eines Dryaden erregen.";
          case 199:
            return "Erforsche das Verlies wirklich sorgfältig. Tief unten könnte sich ein Gefangener befinden.";
          case 200:
            return "Vielleicht hat der Greis vom Verlies Lust, bei uns mitzumachen - jetzt da sein Fluch aufgehoben wurde.";
          case 201:
            return "Behalte alle Bomben, die du findest. Ein Sprengmeister möchte vielleicht einen Blick darauf werfen.";
          case 202:
            return "Sind Goblins wirklich so anders als wir, dass wir nicht in Frieden zusammenleben können?";
          case 203:
            return "Ich hörte, dass ein mächtiger Zauberer in diesen Gebieten lebt. Achte bei deiner nächsten unterirdischen Expedition auf ihn.";
          case 204:
            return "Wenn du Linsen an einem Dämonenaltar kombinierst, kannst du vielleicht ein mächtiges Monster herbeirufen. Du solltest jedoch bis zur Nacht warten, bevor du es verwendest.";
          case 205:
            return "Du kannst einen Wurmköder mit verfaulten Fleischbrocken und Ekelpulver erzeugen. Achte aber darauf, dass du dich vor der Verwendung in einem verderbten Gebiet befindest.";
          case 206:
            return "Dämonenaltäre sind gewöhnlich im Verderben zu finden. Du musst aber nahe bei ihnen stehen, um Items herstellen zu können.";
          case 207:
            return "Du kannst einen Greifhaken aus einem Haken und 3 Ketten herstellen. Die Skelette tief unter der Erde tragen gewöhnlich Haken bei sich. Die Ketten dazu können aus Eisenbarren gefertigt werden.";
          case 208:
            return "Wenn du einen Topf siehst, so schlage ihn auf. Töpfe enthalten alle möglichen nützlichen Zubehörteile.";
          case 209:
            return "Verborgene Schätze sind auf der ganzen Welt zu finden! Einige erstaunliche Dinge sind auch tief unter der Erde aufzuspüren!";
          case 210:
            return "Beim Zerschlagen einer Schattenkugel fällt mitunter ein Meteor vom Himmel. Schattenkugeln können normalerweise in den Schluchten bei verderbten Gebieten gefunden werden.";
          case 211:
            return "Du solltest dich darauf konzentrieren, mehr Kristallherzen zur Erhöhung deiner maximalen Lebensspanne zu sammeln.";
          case 212:
            return "Deine jetzige Ausrüstung wird einfach nicht ausreichen. Du musst eine bessere Rüstung fertigen.";
          case 213:
            return "Ich denke, du bist bereit für deinen ersten großen Kampf. Sammle in der Nacht ein paar Linsen von den Augäpfeln und bringe sie zum Dämonenaltar.";
          case 214:
            return "Du solltest dein Leben verlängern, bevor du die nächste Herausforderung annimmst. 15 Herzen sollten ausreichen.";
          case 215:
            return "Der Ebenstein im Verderben kann durch Verwendung von etwas Pulver eines Dryaden gereinigt werden oder er kann durch Sprengstoffe zerstört werden.";
          case 216:
            return "Dein nächster Schritt ist, die verderbten Schluchten zu untersuchen. Suche nach Schattenkugeln und zerstöre sie!";
          case 217:
            return "Nicht weit von hier gibt es ein altes Verlies. Dies wäre ein guter Zeitpunkt, es zu untersuchen.";
          case 218:
            return "Du solltest versuchen, deine Lebensspanne auf das Maximum anzuheben. Versuche, 20 Herzen zu finden.";
          case 219:
            return "Im Dschungel lassen sich viele Schätze finden, wenn du bereit bist, tief genug zu graben.";
          case 220:
            return "Die Unterwelt entstand aus einem Material, welches sich Höllenstein nennt. Es ist perfekt geeignet für die Produktion von Waffen und Rüstungen.";
          case 221:
            return "Wenn du bereit bist, den Wächter der Unterwelt herauszufordern, musst du ein Opfer bringen. Alles was du brauchst, findest du in der Unterwelt.";
          case 222:
            return "Zerschlage jeden Dämonenaltar, den du findest. Etwas Gutes wird sich ereignen!";
          case 223:
            return "Seelen können manchmal von gefallenen Kreaturen an Orten extremen Lichts oder extremer Finsternis aufgesammelt werden.";
          case 224:
            return "Ho ho ho, und eine Flasche ... Egg Nog!";
          case 225:
            return "Würdest du mir ein paar Plätzchen backen?";
          case 226:
            return "Was? Du dachtest, ich wäre nicht real?";
          case 227:
            return "Es gelang mir, dein Gesicht wieder anzunähen. Sei beim nächsten Mal vorsichtiger.";
          case 228:
            return "Das wird wahrscheinlich eine Narbe hinterlassen.";
          case 229:
            return "Alles okay. Ich will nicht, dass du nochmal von irgendwelchen Klippen springst.";
          case 230:
            return "Das hat nicht allzu weh getan, oder?";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case 1:
            return "Spero che tra noi e l'Occhio di Cthulhu non ci sia solo un bimbo scarno come te.";
          case 2:
            return "Guarda la pessima armatura che indossi. Faresti meglio a comprare più pozioni curative.";
          case 3:
            return "Ho la sensazione che una presenza malvagia mi stia guardando.";
          case 4:
            return "Spada batte carta! Prendine una oggi.";
          case 5:
            return "Desideri mele? Carote? Ananas? Abbiamo delle torce.";
          case 6:
            return "Bella mattina, no? C'era qualcosa di cui avevi bisogno?";
          case 7:
            return "Presto si farà notte, amico. Fai le tue scelte finché puoi.";
          case 8:
            return "Non immagini quanti blocchi di terra si vendono oltreoceano.";
          case 9:
            return "Ah, racconteranno storie di " + player.name + " un giorno... belle storie ovviamente.";
          case 10:
            return "Guarda i miei blocchi di terra: sono super terrosi.";
          case 11:
            return "Ragazzo, quel sole scotta! Ho un'armatura perfettamente ventilata.";
          case 12:
            return "Il sole è alto, ma i miei prezzi no.";
          case 13:
            return "Fantastico! Da qui sento " + str10 + " e " + str2 + " discutere.";
          case 14:
            return "Hai visto Chith... Shith... Chat... Il grande occhio?";
          case 15:
            return "Ehi, questa casa è sicura, no? Giusto? " + player.name + "?";
          case 16:
            return "Nemmeno una Luna di Sangue può fermare il capitalismo. Facciamo un po' di affari.";
          case 17:
            return "Tieni d'occhio il premio, compra una lente!";
          case 18:
            return "Kosh, kapleck Mog. Oh scusa, in klingon significa 'Compra qualcosa o muori.'";
          case 19:
            return "Sei, " + player.name + ", vero? Ho sentito belle cose su di te!";
          case 20:
            return "Sento che c'è un tesoro segreto... non importa.";
          case 21:
            return "Una Statua D'Angelo, dici? Scusa, non tratto cianfrusaglie.";
          case 22:
            return "L'ultimo ragazzo venuto qui mi lasciò delle cianfrusaglie... o meglio... tesori!";
          case 23:
            return "Mi chiedo se la luna sia fatta di formaggio... Uhm, cosa? Oh sì, compra qualcosa!";
          case 24:
            return "Hai detto oro? Te lo tolgo io.";
          case 25:
            return "Niente sangue su di me.";
          case 26:
            return "Sbrigati e smettila di sanguinare.";
          case 27:
            return "Se stai per morire, fallo fuori.";
          case 28:
            return "Cosa vorresti insinuare?!";
          case 29:
            return "Quel tuo tono non mi piace.";
          case 30:
            return "Che ci fai qui? Se non sanguini, non devi stare qui. Via.";
          case 31:
            return "COSA?!";
          case 32:
            return "Hai visto il vecchio che gira intorno alla segreta? Sembra agitato.";
          case 33:
            return "Vorrei che " + str6 + " fosse più attento.  Mi sto stancando di dovergli ricucire gli arti ogni giorno.";
          case 34:
            return "Ehi, " + str4 + " ha detto di dover andare dal dottore per qualche ragione? Solo per chiedere.";
          case 35:
            return "Devo parlare seriamente con " + str3 + ". Quante volte a settimana si può venire con gravi ustioni da lava?";
          case 36:
            return "Penso che tu stia meglio così.";
          case 37:
            return "Ehm... Che ti è successo alla faccia?";
          case 38:
            return "SANTO CIELO! Sono brava, ma non fino a questo punto.";
          case 39:
            return "Cari amici, siamo qui riuniti, oggi, per congedarci... Oh, ti riprenderai.";
          case 40:
            return "Hai lasciato il braccio laggiù. Te lo prendo io...";
          case 41:
            return "Smettila di fare il bambino! Ho visto di peggio.";
          case 42:
            return "Serviranno dei punti!";
          case 43:
            return "Di nuovo problemi con quei bulli?";
          case 44:
            return "Aspetta, ho i cerotti con i cartoni animati da qualche parte.";
          case 45:
            return "Cammina, " + player.name + " starai bene. Fiuu.";
          case 46:
            return "Ti fa male quando lo fai? Non farlo.";
          case 47:
            return "Sembri mezzo digerito. Hai di nuovo inseguito gli slime?";
          case 48:
            return "Gira la testa e tossisci.";
          case 49:
            return "Non è la ferita più grande che abbia mai visto... Ne ho viste certamente di più grandi.";
          case 50:
            return "Vuoi un lecca-lecca?";
          case 51:
            return "Dimmi dove ti fa male.";
          case 52:
            return "Scusa, ma non puoi permetterti di avermi.";
          case 53:
            return "Avrò bisogno di più soldi.";
          case 54:
            return "Sai che non lavoro gratis.";
          case 55:
            return "Non faccio lieti fini.";
          case 56:
            return "Non posso fare più nulla per te senza chirurgia plastica.";
          case 57:
            return "Smettila di sprecare il mio tempo.";
          case 58:
            return "Ho sentito che c'è una bambola molto simile a " + str3 + " nel sotterraneo. Vorrei metterci dei proiettili.";
          case 59:
            return "Veloce! Ho un appuntamento con " + str2 + " tra un'ora.";
          case 60:
            return "Voglio quello che vende " + str2 + ". In che senso, non vende niente?";
          case 61:
            return str5 + " è uno spettacolo. Peccato sia così bigotta.";
          case 62:
            return "Lascia stare " + str6 + ", qui ho tutto ciò che ti serve.";
          case 63:
            return "Qual è il problema di " + str6 + "? Almeno lo sa che vendiamo oggetti diversi?";
          case 64:
            return "Beh, è una bella notte per non parlare con nessuno, non credi, " + player.name + "?";
          case 65:
            return "Mi piacciono le notti come questa. Non mancano mai cose da uccidere!";
          case 66:
            return "Vedo che stai addocchiando il Minishark... Meglio che non ti dica di cosa è fatto.";
          case 67:
            return "Ehi, non è un film, amico. Le munizioni sono extra.";
          case 68:
            return "Giù le mani dalla mia pistola, amico!";
          case 69:
            return "Hai provato a utilizzare la polvere purificatrice sulla pietra d'ebano della corruzione?";
          case 70:
            return "Vorrei che " + str4 + " la smettesse di flirtare con me. Non sa che ho 500 anni?";
          case 71:
            return "Perché " + str1 + " continua a vendermi statue d'angelo? Lo sanno tutti che non servono a nulla.";
          case 72:
            return "Hai visto il vecchio che gira intorno alla dungeon? Non ha per niente un bell'aspetto...";
          case 73:
            return "Vendo ciò che voglio! Se non ti piace, pazienza.";
          case 74:
            return "Perché devi essere così conflittuale in un momento come questo?";
          case 75:
            return "Non voglio che tu compri la mia roba. Voglio che tu desideri comprarla, ok?";
          case 76:
            return "Amico, sbaglio o ci sono tipo un milione di zombie in giro, stanotte?";
          case 77:
            return "Devi purificare il mondo da questa corruzione.";
          case 78:
            return "Sii cauto: Terraria ha bisogno di te!";
          case 79:
            return "Il tempo vola e tu, ahimé, non stai invecchiando molto bene.";
          case 80:
            return "Cos'è questa storia di me che abbaio, ma non mordo?";
          case 81:
            return "Due goblin entrano in un bar e uno dice all'altro: 'Vuoi un calice di birra?!' ";
          case 82:
            return "Non posso farti entrare finché non mi libererai dalla maledizione.";
          case 83:
            return "Torna di notte se vuoi entrare.";
          case 84:
            return "Il mio padrone non può essere evocato di giorno.";
          case 85:
            return "Sei decisamente troppo debole per sconfiggere la mia maledizione. Torna quando servirai a qualcosa.";
          case 86:
            return "Tu, pazzo patetico. Non puoi sperare di affrontare il mio padrone ora come ora.";
          case 87:
            return "Spero che tu abbia almeno sei amici che ti coprano le spalle.";
          case 88:
            return "No, ti prego, straniero. Finirai per essere ucciso.";
          case 89:
            return "Potresti essere abbastanza forte da liberarmi dalla mia maledizione...";
          case 90:
            return "Straniero, hai la forza per sconfiggere il mio padrone?";
          case 91:
            return "Ti prego! Sconfiggi chi mi ha catturato e liberami, ti supplico!";
          case 92:
            return "Sconfiggi il mio padrone e ti farò passare nella dungeon.";
          case 93:
            return "Stai provando a superare quella pietra d'ebano, eh? Perché non metterci uno di questi esplosivi!";
          case 94:
            return "Ehi, hai visto un clown in giro?";
          case 95:
            return "C'era una bomba qui e ora non riesco a trovarla...";
          case 96:
            return "Ho qualcosa per quegli zombie, altroché!";
          case 97:
            return "Persino " + str4 + " vuole ciò che sto vendendo!";
          case 98:
            return "Preferisci avere un buco da proiettile o granata? Ecco ciò che pensavo.";
          case 99:
            return "Sono sicuro che " + str2 + " ti aiuterà se per caso perderai un arto.";
          case 100:
            return "Perché purificare il mondo quando potresti farlo saltare in aria?";
          case 101:
            return "Se verserai questo nella vasca da bagno e chiuderai tutte le finestre, ti pulirà le cavità nasali e ti sturerà le orecchie.";
          case 102:
            return "Vuoi giocare a Esplodi-Pollo?";
          case 103:
            return "Ehi, potresti firmare questa rinuncia al dolore?";
          case 104:
            return "VIETATO FUMARE QUI DENTRO!!";
          case 105:
            return "Gli esplosivi vanno a ruba di questi tempi. Comprane un po'!";
          case 106:
            return "È un bel giorno per morire!";
          case 107:
            return "Mi chiedo cosa succederà se io... (BUM!) ... Oh, scusa, ti serviva quella gamba?";
          case 108:
            return "La dinamite, la mia cura speciale per tutto ciò che ti affligge.";
          case 109:
            return "Guarda i miei prodotti: hanno prezzi esplosivi!";
          case 110:
            return "Continuo ad avere vaghi ricordi di aver legato una donna e averla gettata nella dungeon.";
          case 111:
            return "... abbiamo un problema! C'è una Luna di Sangue là fuori!";
          case 112:
            return "Fossi più giovane, chiederei a " + str2 + " di uscire. Avevo un successone con le ragazze.";
          case 113:
            return "Quel tuo Cappello rosso mi sembra familiare...";
          case 114:
            return "Grazie ancora per avermi liberato dalla mia maledizione. Sentivo come qualcosa che saltava e mi mordeva.";
          case 115:
            return "Mia mamma mi diceva sempre che sarei stato un grande sarto.";
          case 116:
            return "La vita è come una scatola di vestiti; non sai mai ciò che indosserai!";
          case 117:
            return "Ricamare è difficile! Se non fosse così, nessuno lo farebbe! È ciò che lo rende fantastico.";
          case 118:
            return "So tutto ciò che c'è da sapere riguardo alle attività di sartoria.";
          case 119:
            return "Nella maledizione ero solo, perciò una volta mi creai un amico di pelle. Lo chiamai Wilson.";
          case 120:
            return "Grazie per avermi liberato, umano. Sono stato legato e lasciato qui da altri goblin. Si potrebbe dire che non andavamo proprio d'accordo.";
          case 121:
            return "Non posso credere che mi hanno legato e lasciato qui soltanto per far notare che non andavano verso est!";
          case 122:
            return "Ora che sono un escluso, posso buttar via le palle chiodate? Mi fanno male le tasche.";
          case 123:
            return "Cerchi un esperto di gadget? Sono il tuo goblin!";
          case 124:
            return "Grazie per l'aiuto. Ora devo smetterla di gironzolare senza scopo qui attorno. Sono sicuro che ci incontreremo di nuovo.";
          case 125:
            return "Pensavo fossi più alto.";
          case 126:
            return "Ehi... cosa sta combinando " + str10 + "? Hai... hai parlato con lei, per caso?";
          case (int) sbyte.MaxValue:
            return "Ehi, il tuo cappello ha bisogno di un motore? Credo di averne uno perfettamente adatto.";
          case 128:
            return "Ciao, ho sentito che ti piacciono i razzi e gli stivali da corsa, così ho messo dei missili nei tuoi stivali.";
          case 129:
            return "Il silenzio è d'oro. Il nastro adesivo è d'argento.";
          case 130:
            return "SÌ, l'oro è più forte del ferro. Cosa insegnano al giorno d'oggi a questi umani?";
          case 131:
            return "Sai, quella combinazione casco da minatore-pinne era un'idea molto migliore sulla carta.";
          case 132:
            return "I goblin si irritano molto facilmente. Potrebbero persino scatenare una guerra per i tessuti!";
          case 133:
            return "A dire il vero, la maggior parte dei goblin non sono ingegneri aerospaziali. Beh, alcuni sì.";
          case 134:
            return "Sai perché noi tutti ci portiamo dietro queste palle chiodate? Perché io non lo faccio.";
          case 135:
            return "Ho appena finito la mia ultima creazione! Questa versione non esplode violentemente se ci si respira troppo forte sopra.";
          case 136:
            return "I ladri goblin non sono molto furbi. Non sanno nemmeno rubare da una cassa aperta!";
          case 137:
            return "Grazie per avermi salvato, amico! Questi legacci iniziavano a irritarmi.";
          case 138:
            return "Ohh, mio eroe!";
          case 139:
            return "Oh, eroica! Grazie per avermi salvato, ragazza!";
          case 140:
            return "Oh, eroico!  Grazie per avermi salvato, ragazzo!";
          case 141:
            return "Ora che ci conosciamo, posso trasferirmi da te, vero?";
          case 142:
            return "Bene, ciao, " + str3 + "! Cosa posso fare per te oggi?";
          case 143:
            return "Bene, ciao, " + str6 + "! Cosa posso fare per te oggi?";
          case 144:
            return "Bene, ciao, " + str8 + "! Cosa posso fare per te oggi?";
          case 145:
            return "Bene, ciao, " + str2 + "! Cosa posso fare per te oggi?";
          case 146:
            return "Bene, ciao, " + str10 + "! Cosa posso fare per te oggi?";
          case 147:
            return "Bene, ciao, " + str5 + "! Cosa posso fare per te oggi?";
          case 148:
            return "Vuoi che tiri fuori una moneta da dietro il tuo orecchio? No? Ok.";
          case 149:
            return "Vuoi dei dolci magici? No? Ok.";
          case 150:
            return "Posso preparare una cioccalata calda proprio deliziosa se sei inter...No? Ok.";
          case 151:
            return "Sei qui per dare un'occhiata alla mia sfera di cristallo?";
          case 152:
            return "Mai desiderato un anello incantato che trasforma le rocce in slime? Neanch'io.";
          case 153:
            return "Una volta qualcuno mi disse che l'amicizia è magica. Sciocchezze. Non puoi trasformare le persone in rane con l'amicizia.";
          case 154:
            return "Ora vedo il tuo futuro... Comprerai molti prodotti da me!";
          case 155:
            return "Una volta ho provato a dare la vita a una Statua D'Angelo. Invano.";
          case 156:
            return "Grazie! Era solo questione di tempo prima che facessi la stessa fine degli scheletri laggiù.";
          case 157:
            return "Ehi, guarda dove stai andando! Ero laggiù un attimo fa!";
          case 158:
            return "Resisti, sono quasi riuscito a portare fin qui il Wi-Fi.";
          case 159:
            return "Ma ero quasi riuscito a mettere luci intermittenti quassù!";
          case 160:
            return "NON MUOVERTI. MI È CADUTA UNA LENTE A CONTATTO.";
          case 161:
            return "Tutto ciò che voglio è che l'interruttore faccia... Cosa?!";
          case 162:
            return "Oh, fammi indovinare. Non hai comprato abbastanza cavi. Idiota.";
          case 163:
            return "Soltanto-potresti soltanto... Per favore? Ok? Ok. Puah.";
          case 164:
            return "Non apprezzo il modo in cui mi guardi. Sto LAVORANDO ora.";
          case 165:
            return "Ehi, " + player.name + ", sei appena stato da " + str8 + "? Ha detto qualcosa di me, per caso?";
          case 166:
            return str4 + " continua a dire di aver schiacciato la mia piastra a pressione. Gli ho spiegato che serve proprio a quello.";
          case 167:
            return "Compra sempre più cavi del necessario!";
          case 168:
            return "Ti sei assicurato che il tuo dispositivo fosse collegato?";
          case 169:
            return "Oh, sai di cosa ha bisogno questa casa? Di più luci intermittenti.";
          case 170:
            return "Si può dire che appare una luna di sangue quando il cielo si fa rosso.  C'è qualcosa in lei che ridesta i mostri.";
          case 171:
            return "Ehi, amico, sai dov'è un po' di erba della morte? Scusa, me lo stavo solo chiedendo, tutto qua.";
          case 172:
            return "Se dovessi alzare lo sguardo, vedresti che la luna è rossa ora.";
          case 173:
            return "Dovresti stare dentro di notte. È molto pericoloso girare al buio.";
          case 174:
            return "Saluti, " + player.name + ". Come posso esserti utile?";
          case 175:
            return "Sono qui per darti consigli su cosa fare dopo. Ti consiglio di parlare con me ogni volta che sarai nei guai.";
          case 176:
            return "Si dice ci sia una persona che ti dirà come sopravvivere in questa terra... Aspetta. Sono io.";
          case 177:
            return "Puoi utilizzare il piccone per scavare nell'immondizia e l'ascia per abbattere gli alberi. Posiziona il cursore sulla mattonella e clicca " + (object) '\x0081' + "!";
          case 178:
            return "Se vuoi sopravvivere, dovrai creare armi e un riparo. Inizia abbattendo gli alberi e raccogliendo legna.";
          case 179:
            return "Clicca su " + (object) '\x008B' + "per accedere al menu Creazione Oggetti. Quando avrai abbastanza legna, crea un banco da lavoro. Così potrai creare oggetti più sofisticati, finché sarai vicino ad esso.";
          case 180:
            return "Puoi costruirti un riparo con legna o altri blocchi nel mondo. Non dimenticare di creare e sistemare i muri.";
          case 181:
            return "Una volta che possiederai una spada di legno, puoi provare a raccogliere la gelatina dagli slime. Unisci la legna e la gelatina per creare una torcia!";
          case 182:
            return "Per interagire con gli ambienti e gli oggetti posizionati, usa un martello!";
          case 183:
            return "Devi praticare un po' di estrazione per trovare minerali metallici. Puoi crearci oggetti molto utili.";
          case 184:
            return "Ora che hai un po' di minerale, dovrai trasformarlo in una barra per poterci fare degli oggetti. Per questo serve una fornace!";
          case 185:
            return "Puoi creare una fornace con torce, legna e pietra. Assicurati di essere vicino a un banco da lavoro.";
          case 186:
            return "Avrai bisogno di un'incudine per creare la maggior parte degli oggetti dalle barre metalliche.";
          case 187:
            return "Le incudini possono essere create con del ferro o acquistate da un mercante.";
          case 188:
            return "Nel Sottoterraneo vi sono cuori di cristallo che possono essere utilizzati per aumentare la tua vita massima. Dovrai avere un martello per ottenerli.";
          case 189:
            return "Se raccoglierai 10 stelle cadenti, potrai combinarle per creare un oggetto che aumenterà le tue abilità magiche.";
          case 190:
            return "Le stelle cadono sul mondo di notte. Possono essere utilizzate per ogni tipo di oggetto utile.  Se ne vedi una, cerca di afferrarla, poiché scomparirà dopo l'alba.";
          case 191:
            return "Ci sono diversi modi per convincere le persone a trasferirsi nella tua città. Di sicuro dovranno avere una casa in cui vivere.";
          case 192:
            return "Perché una stanza sia considerata una casa, ha bisogno di una porta, una sedia, un tavolo e una fonte di illuminazione. Assicurati che la casa abbia anche i muri.";
          case 193:
            return "Due persone non possono vivere nella stessa casa. Inoltre, se la loro casa verrà distrutta, cercheranno un nuovo posto in cui vivere.";
          case 194:
            return "Puoi utilizzare l'interfaccia Alloggio per visualizzare e assegnare gli alloggi. Apri l'inventario e clicca sull'icona della casa.";
          case 195:
            return "Se vuoi che un mercante si trasferisca, dovrai raccogliere molto denaro. Servono 50 monete d'argento!";
          case 196:
            return "Se vuoi che un'infermiera si trasferisca, dovrai aumentare la tua vita massima.";
          case 197:
            return "Se avessi una pistola, scommetto che potrebbe apparire un mercante d'armi per venderti munizioni!";
          case 198:
            return "Dovresti metterti alla prova sconfiggendo un mostro forte. Così attirerai l'attenzione di una driade.";
          case 199:
            return "Esplora attentamente tutta la dungeon. Potrebbero esserci prigionieri nelle zone più profonde.";
          case 200:
            return "Forse il vecchio della dungeon vorrebbe unirsi a noi, ora che la maledizione è terminata.";
          case 201:
            return "Arraffa tutte le bombe che potresti trovare. Un esperto di demolizioni potrebbe volerci dare un'occhiata.";
          case 202:
            return "I goblin sono così diversi da noi che non possiamo convivere in maniera pacifica?";
          case 203:
            return "Ho sentito che c'era un potente stregone da queste parti. Tienilo d'occhio la prossima volta che scenderai sottoterra.";
          case 204:
            return "Se unirai le lenti a un altare dei demoni, potresti trovare un modo per evocare un potente mostro. Ma aspetta che si faccia buio prima di utilizzarlo.";
          case 205:
            return "Puoi creare un'esca di vermi con pezzi marci e polvere disgustosa. Assicurati di essere in una zona corrotta prima di utilizzarla.";
          case 206:
            return "Gli altari dei demoni si trovano generalmente nella corruzione. Dovrai essere vicino ad essi per creare oggetti.";
          case 207:
            return "Puoi creare un rampino con un uncino e tre catene. Gli scheletri sottoterra di solito trasportano gli uncini, mentre le catene possono essere ricavate dalle barre di ferro.";
          case 208:
            return "Se vedi un vaso, demoliscilo e aprilo. Contiene una serie di utili provviste.";
          case 209:
            return "Vi sono tesori nascosti in tutto il mondo. Alcuni oggetti fantastici si possono trovare nelle zone sotterranee più profonde.";
          case 210:
            return "Demolire un'orbita d'ombra provocherà a volte la caduta di un meteorite dal cielo. Le orbite d'ombra si possono generalmente trovare negli abissi attorno alle zone distrutte.";
          case 211:
            return "Dovresti cercare di raccogliere più cuori di cristallo per aumentare la tua vita massima.";
          case 212:
            return "Il tuo equipaggiamento attuale non è sufficiente. Hai bisogno di un'armatura migliore.";
          case 213:
            return "Credo tu sia pronto per la tua prima grande battaglia. Raccogli lenti dai bulbi oculari di notte e portale a un altare dei demoni.";
          case 214:
            return "Aumenta la tua vita prima di affrontare la prossima sfida. Quindici cuori dovrebbero bastare.";
          case 215:
            return "La pietra d'ebano nella corruzione può essere purificata con polvere di driade o distrutta con esplosivi.";
          case 216:
            return "La prossima tappa consiste nell'esplorazione degli abissi corrotti. Trova e distruggi ogni orbita d'ombra che incontrerai.";
          case 217:
            return "C'è una vecchia dungeon non lontano da qui. Sarebbe il momento giusto per visitarla.";
          case 218:
            return "Dovresti tentare di massimizzare la vita disponibile. Prova a raccogliere venti cuori.";
          case 219:
            return "Ci sono molti tesori da scroprire nella giungla, se sei disposto a scavare abbastanza in profondità.";
          case 220:
            return "Il sotterraneo è composto da un materiale detto pietra infernale, perfetto per creare armi e armatura.";
          case 221:
            return "Quando sarai pronto a sfidare il custode del sotterraneo, dovrai fare un enorme sacrificio. Tutto ciò che ti serve si trova nel sotterraneo.";
          case 222:
            return "Assicurati di demolire ogni altare dei demoni che incontri. Se lo farai, ti succederà qualcosa di bello!";
          case 223:
            return "A volte è possibile riunire le anime delle creature morte in luoghi estremamente luminosi o bui.";
          case 224:
            return "Ho ho ho e una bottiglia di ... Egg Nog!";
          case 225:
            return "Ti sta a cuore prepararmi dei biscotti?";
          case 226:
            return "Che cosa? Credevi non fosse vero?";
          case 227:
            return "Sono riuscita a cucire di nuovo la tua faccia. Stai più attento la prossima volta.";
          case 228:
            return "Probabilmente ti lascerà una cicatrice.";
          case 229:
            return "I miei migliori auguri. Non voglio vederti saltare da altre scogliere.";
          case 230:
            return "Non ti ha fatto male, vero?";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case 1:
            return "Rassurez-moi, on ne doit pas compter que sur vous pour nous protéger de l'œil de Cthulhu.";
          case 2:
            return "Regardez-moi cette armure bas de gamme que vous avez sur le dos. Vous avez intérêt à acheter davantage de potions de soin.";
          case 3:
            return "Je sens une présence maléfique m'observer.";
          case 4:
            return "L'épée est plus forte que la plume. Achetez-en une dès aujourd'hui.";
          case 5:
            return "Vous voulez des pommes ? Vous voulez des poires ? Vous voulez des scoubidous ? Nous avons des torches.";
          case 6:
            return "Quelle belle matinée, n'est-ce pas ? Vous voulez quelque chose ?";
          case 7:
            return "La nuit va bientôt tomber, alors faites votre choix tant qu'il est encore temps.";
          case 8:
            return "Vous n'avez pas idée du prix des blocs de terre à l'étranger.";
          case 9:
            return "Un jour, des légendes étonnantes circuleront sur " + player.name + ".";
          case 10:
            return "Jetez un œil à mes blocs de terre, c'est de la terre de premier choix.";
          case 11:
            return "Voyez comme le soleil tape. J'ai des armures parfaitement ventilées.";
          case 12:
            return "Le soleil est haut dans le ciel, mais mes prix sont bas.";
          case 13:
            return "Super. J'entends " + str10 + " et " + str2 + " se disputer d'ici.";
          case 14:
            return "Avez-vous vu Chult... Cthuch... Le truc avec le gros œil ?";
          case 15:
            return "Cette maison est sûre, n'est-ce pas ? Hein, " + player.name + "?";
          case 16:
            return "Même la lune sanglante ne peut arrêter le capitalisme. Alors, faisons affaires.";
          case 17:
            return "Pour garder un œil sur les prix, achetez une lentille.";
          case 18:
            return "Kosh, kapleck Mog. Oh désolé, ça veut dire « Achetez-moi quelque chose ou allez au diable » en klingon.";
          case 19:
            return "Vous êtes " + player.name + ", n'est-ce pas ? J'ai entendu de bonnes choses à votre sujet.";
          case 20:
            return "J'ai entendu dire qu'il y avait un trésor caché... Bon, laissez tomber.";
          case 21:
            return "Une statue d'ange, dites-vous ? Désolé, ce n'est pas une boutique de souvenirs ici.";
          case 22:
            return "Le dernier type qui est venu m'a vendu quelques sales... Je veux dire, de vrais trésors.";
          case 23:
            return "Je me demande si la lune est un gros fromage... Hein, quoi ? Oh, bien sûr, achetez ce que vous voulez !";
          case 24:
            return "Vous avez dit or ? Je vais vous en débarrasser.";
          case 25:
            return "Faites attention de ne pas me mettre du sang partout.";
          case 26:
            return "Dépêchez-vous et arrêtez de saigner.";
          case 27:
            return "Si vous comptez mourir, faites-le dehors.";
          case 28:
            return "Qu'est-ce que ça veut dire ?";
          case 29:
            return "Je n'aime pas beaucoup votre ton.";
          case 30:
            return "Qu'est-ce que vous faites là ? Si vous ne saignez pas, sortez d'ici. Dehors !";
          case 31:
            return "QUOI ?!";
          case 32:
            return "Vous avez vu ce vieil homme qui se pressait autour du donjon ? Il semblait avoir des ennuis.";
          case 33:
            return "J'aimerais bien que " + str6 + " fasse plus attention. J'en ai assez de lui faire des points de suture chaque jour.";
          case 34:
            return "Je me demande si " + str4 + " a dit qu'il avait besoin d'un docteur.";
          case 35:
            return "Il va falloir que je discute sérieusement avec " + str3 + ". Combien de fois par semaine allez-vous revenir ici avec des brûlures au second degré ?";
          case 36:
            return "Vous avez meilleure mine comme ça.";
          case 37:
            return "Que vous est-il arrivé au visage ?";
          case 38:
            return "Bon sang, je suis une bonne infirmière, mais pas à ce point.";
          case 39:
            return "Mes chers amis, nous sommes rassemblés aujourd'hui pour faire nos adieux... Bon, tout se passera bien.";
          case 40:
            return "Vous avez laissé votre bras là-bas. Laissez-moi arranger ça.";
          case 41:
            return "Arrêtez de vous comporter comme une mauviette. J'ai déjà vu bien pire.";
          case 42:
            return "Cela va demander quelques points de suture.";
          case 43:
            return "Encore des soucis avec ces brutes ?";
          case 44:
            return "Attendez, je dois avoir quelques pansements pour enfants quelque part.";
          case 45:
            return "Allez faire quelques pas, " + player.name + ", ça devrait aller. Allez, ouste !";
          case 46:
            return "Ça vous fait mal quand vous faites ça ? Eh bien, ne le faites pas.";
          case 47:
            return "On dirait qu'on a commencé à vous digérer. Vous avez encore chassé des slimes ?";
          case 48:
            return "Tournez votre tête et toussez.";
          case 49:
            return "Ce n'est pas la plus grave blessure que j'ai vue... Oui, j'ai déjà vu des blessures bien plus graves que ça.";
          case 50:
            return "Vous voulez une sucette ?";
          case 51:
            return "Montrez-moi où vous avez mal.";
          case 52:
            return "Je suis désolée, mais vous n'avez pas les moyens.";
          case 53:
            return "Il va me falloir plus d'or que cela.";
          case 54:
            return "Je ne travaille pas gratuitement, vous savez.";
          case 55:
            return "Je ne vous garantis pas le résultat.";
          case 56:
            return "Je ne peux rien faire de plus pour vous sans chirurgie esthétique.";
          case 57:
            return "Arrêtez de me faire perdre mon temps.";
          case 58:
            return "J'ai entendu dire qu'il y aurait une poupée qui ressemblerait beaucoup à " + str3 + " dans le monde inférieur. J'aimerais bien lui coller quelques pruneaux.";
          case 59:
            return "Dépêchez-vous, j'ai un rencard avec " + str2 + " dans une heure.";
          case 60:
            return "Je veux ce que vend " + str2 + ". Comment ça, elle ne vend rien !";
          case 61:
            return str5 + " est vraiment canon. Dommage qu'elle soit aussi prude.";
          case 62:
            return "Ne vous embêtez pas avec " + str6 + ", j'ai tout ce qu'il vous faut ici.";
          case 63:
            return "C'est quoi le problème de " + str6 + " ? Est-ce qu'il réalise seulement que l'on vend du matériel complètement différent ?";
          case 64:
            return "Eh bien, c'est la nuit idéale pour ne parler à personne, n'est-ce pas, " + player.name + " ?";
          case 65:
            return "J'adore les nuits comme celle-ci, car il y a toujours des choses à tuer.";
          case 66:
            return "Je vois que vous êtes en train de zieuter le minishark... Mieux vaut ne pas savoir comment c'est fabriqué.";
          case 67:
            return "Eh, c'est pas du cinéma. Les munitions sont superflues.";
          case 68:
            return "Retirez les mains de mon flingue.";
          case 69:
            return "Avez-vous essayé d'utiliser de la poudre de purification sur la pierre d'ébène de corruption ?";
          case 70:
            return "Ce serait bien si " + str4 + " cessait de me courtiser. Il n'a pas l'air de réaliser que j'ai 500 ans.";
          case 71:
            return "Pourquoi " + str1 + " essaie-t-il toujours de me vendre des statues d'ange ? Tout le monde sait qu'elles sont sans intérêt.";
          case 72:
            return "Avez-vous vu le vieil homme en train de marcher autour du donjon ? Il n'avait vraiment pas l'air bien.";
          case 73:
            return "Je vends ce que je veux, et si cela ne vous plaît pas, tant pis pour vous.";
          case 74:
            return "Pourquoi adopter un comportement aussi conflictuel en cette période ?";
          case 75:
            return "Je ne veux pas que vous achetiez mes marchandises, je veux que vous ayez envie de les acheter, vous saisissez la nuance ?";
          case 76:
            return "Dites, c'est moi ou il y a un million de zombies qui déambulent cette nuit ?";
          case 77:
            return "Je veux que vous purifiiez le monde de la corruption.";
          case 78:
            return "Faites attention, Terraria a besoin de vous.";
          case 79:
            return "Les sables du temps s'écoulent et il faut bien avouer que vous vieillissez plutôt mal.";
          case 80:
            return "Comment ça, j'aboie plus que je ne mords ?";
          case 81:
            return "C'est l'histoire de deux gobelins qui entrent dans une taverne et l'un dit à l'autre : « Tu veux un gobelet de bière ? »";
          case 82:
            return "Je ne peux pas vous laisser entrer tant que vous ne m'aurez pas débarrassé de ma malédiction.";
          case 83:
            return "Revenez à la nuit tombée si vous voulez entrer.";
          case 84:
            return "Mon maître ne peut pas être invoqué à la lumière du jour.";
          case 85:
            return "Vous êtes bien trop faible pour me débarrasser de ma malédiction. Revenez quand vous serez de taille.";
          case 86:
            return "C'est pathétique ! Vous n'espérez quand même pas affronter mon maître dans votre état.";
          case 87:
            return "J'espère que vous avez au moins six amis pour vous épauler.";
          case 88:
            return "Je vous en prie, ne faites pas ça. Vous allez vous faire tuer.";
          case 89:
            return "Votre puissance semble suffisante pour me débarrasser de ma malédiction.";
          case 90:
            return "Disposez-vous de la force nécessaire pour vaincre mon maître ?";
          case 91:
            return "S'il vous plaît, je vous en conjure, affrontez mon ravisseur et libérez-moi.";
          case 92:
            return "Terrassez mon maître et je vous ouvrirai la voie du donjon.";
          case 93:
            return "Vous essayez d'écouler cette pierre d'ébène, hein ? Pourquoi ne pas l'intégrer à l'un de ces explosifs ?";
          case 94:
            return "Dites donc, vous n'auriez pas vu un clown dans le coin ?";
          case 95:
            return "Il y avait une bombe juste là et je n'arrive plus à remettre la main dessus.";
          case 96:
            return "J'ai quelque chose dont les zombies raffolent.";
          case 97:
            return "Même " + str4 + " raffole de mes marchandises.";
          case 98:
            return "Vous préférez un trou de balle ou un trou de grenade ? C'est bien ce que je pensais.";
          case 99:
            return str2 + " vous aidera si jamais vous perdez un membre avec ça.";
          case 100:
            return "Pourquoi purifier le monde alors que vous pouvez tout faire sauter ?";
          case 101:
            return "Si vous lancez ça dans votre baignoire et que vous fermez les fenêtres, ça vous débouchera les sinus et les oreilles en moins de deux.";
          case 102:
            return "Vous voulez jouer au poulet-fusée ?";
          case 103:
            return "Pourriez-vous signer cette clause de non-responsabilité ?";
          case 104:
            return "INTERDICTION FORMELLE DE FUMER.";
          case 105:
            return "Les explosifs, c'est de la bombe en ce moment. Achetez-en dès maintenant.";
          case 106:
            return "C'est un bon jour pour mourir.";
          case 107:
            return "Je me demande ce qui va se passer si je... (BOUM !)... Désolé, vous aviez besoin de cette jambe ?";
          case 108:
            return "La dynamite, c'est mon remède spécial à tous vos petits problèmes.";
          case 109:
            return "Jetez un œil à mes marchandises, mes prix sont explosifs.";
          case 110:
            return "J'ai encore le vague souvenir d'avoir attaché une femme et de l'avoir balancée dans un donjon.";
          case 111:
            return "Il y a un problème, c'est la lune sanglante.";
          case 112:
            return "Si j'avais été plus jeune, j'aurais proposé un rencard à " + str2 + ". J'étais un bourreau des cœurs dans le temps.";
          case 113:
            return "Ce chapeau rouge que vous portez me dit quelque chose.";
          case 114:
            return "Merci de m'avoir débarrassé de cette malédiction. J'avais l'impression que quelque chose m'avait mordu et ne me lâchait plus.";
          case 115:
            return "Ma mère m'a toujours dit que je ferais un bon tailleur.";
          case 116:
            return "La vie est comme le chapeau d'un magicien, on ne sait jamais ce qui va en sortir.";
          case 117:
            return "La broderie, c'est très difficile. Si ça ne l'était pas, personne n'en ferait. C'est ce qui la rend si intéressante.";
          case 118:
            return "Le commerce du prêt-à-porter n'a aucun secret pour moi.";
          case 119:
            return "Quand on est maudit, ça n'aide pas à se faire des amis. Alors un jour, je m'en suis fait un avec un morceau de cuir et je l'ai appelé Wilson.";
          case 120:
            return "Merci de m'avoir libéré, humain. J'ai été attaché et laissé ici par les autres gobelins. On peut dire qu'on ne s'entendait pas très bien, eux et moi.";
          case 121:
            return "Je n'arrive pas à croire qu'ils m'aient attaché et planté ici juste pour montrer qu'ils ne voulaient pas aller vers l'est.";
          case 122:
            return "Puisque je suis devenu un paria, puis-je jeter mes boules piquantes ? Mes poches me font mal.";
          case 123:
            return "Vous cherchez un expert en gadgets ? Je suis votre gobelin.";
          case 124:
            return "Merci de votre aide. À présent, je dois continuer à errer sans but dans les environs. Je suis sûr qu'on se reverra.";
          case 125:
            return "Je ne vous imaginais pas comme ça.";
          case 126:
            return "Et comment va " + str10 + " ? Lui auriez-vous parlé, par hasard ?";
          case (int) sbyte.MaxValue:
            return "Est-ce que votre chapeau a besoin d'un moteur ? Je crois en avoir un en stock qui ferait parfaitement l'affaire.";
          case 128:
            return "J'ai entendu dire que vous aimiez les bottes de course et les fusées, du coup, j'ai installé des fusées dans vos bottes de course.";
          case 129:
            return "Le silence est d'or, mais le chatterton reste très efficace.";
          case 130:
            return "Oui, l'or est plus précieux que le fer. Mais qu'est-ce qu'ils vous apprennent chez les humains ?";
          case 131:
            return "C'est vrai que ce casque de mineur combiné à une palme rendait mieux sur le papier.";
          case 132:
            return "Les gobelins sont étonnamment soupe au lait. Ils pourraient déclencher une guerre pour un mot de travers.";
          case 133:
            return "Il faut bien avouer que les gobelins n'ont pas inventé la poudre, mais il y a des exceptions à la règle.";
          case 134:
            return "Savez-vous pourquoi on trimballe toujours ces boules piquantes ? Parce que moi, je n'en sais fichtre rien.";
          case 135:
            return "Je viens de mettre la touche finale à ma dernière invention. Et ce modèle n'explosera pas si vous soufflez trop fort dessus.";
          case 136:
            return "Les voleurs gobelins sont des vrais manchots. Ils ne sont même pas capables de dérober le contenu d'un coffre non verrouillé.";
          case 137:
            return "Merci de m'avoir secouru. Ces liens commençaient à m'irriter la peau.";
          case 138:
            return "Mon héros !";
          case 139:
            return "Quel héroïsme ! Merci de m'avoir sauvé, belle dame.";
          case 140:
            return "Quel héroïsme ! Merci de m'avoir sauvé, fringant jeune homme.";
          case 141:
            return "Maintenant que nous avons fait connaissance, je peux venir avec vous, n'est-ce pas ?";
          case 142:
            return "Bonjour, " + str3 + " ! Que puis-je pour vous, aujourd'hui ?";
          case 143:
            return "Bonjour, " + str6 + " ! Que puis-je pour vous, aujourd'hui ?";
          case 144:
            return "Bonjour, " + str8 + " ! Que puis-je pour vous, aujourd'hui ?";
          case 145:
            return "Bonjour, " + str2 + " ! Que puis-je pour vous, aujourd'hui ?";
          case 146:
            return "Bonjour, " + str10 + " ! Que puis-je pour vous, aujourd'hui ?";
          case 147:
            return "Bonjour, " + str5 + " ! Que puis-je pour vous, aujourd'hui ?";
          case 148:
            return "Voulez-vous que je fasse apparaître une pièce de monnaie de derrière votre oreille ? Non ? Bon.";
          case 149:
            return "Est-ce qu'un berlingot magique vous ferait plaisir ? Non ? Bon.";
          case 150:
            return "Je peux concocter un merveilleux chocolat chaud magique, si cela vous intéresse... Non ? Bon.";
          case 151:
            return "Souhaitez-vous jeter un œil à ma boule de cristal ?";
          case 152:
            return "N'avez-vous jamais rêvé de posséder un anneau magique qui transformerait les rochers en slimes ? Moi non plus, à vrai dire.";
          case 153:
            return "Un jour, quelqu'un m'a dit que l'amitié était quelque chose de magique. C'est n'importe quoi. On ne peut pas transformer quelqu'un en grenouille avec l'amitié.";
          case 154:
            return "À présent, votre avenir m'apparaît clairement... Vous allez m'acheter de nombreux objets.";
          case 155:
            return "Une fois, j'ai tenté de ramener une statue d'ange à la vie. Il ne s'est rien passé.";
          case 156:
            return "Merci. C'était moins une, j'ai failli terminer comme tous ces squelettes.";
          case 157:
            return "Attention où vous mettez les pieds. J'étais encore là-bas il y a peu.";
          case 158:
            return "Attendez, j'ai presque réussi à me connecter au Wi-Fi ici.";
          case 159:
            return "Mais j'avais presque terminé d'installer des stroboscopes là-haut.";
          case 160:
            return "QUE PERSONNE NE BOUGE ! J'AI PERDU UNE LENTILLE !";
          case 161:
            return "Tout ce que je veux, c'est que l'interrupteur... Quoi ?";
          case 162:
            return "Je parie que vous n'avez pas acheté assez de câbles. Décidément, vous n'êtes vraiment pas une lumière.";
          case 163:
            return "Est-ce que vous pourriez juste... S'il vous plaît ? OK ? OK.";
          case 164:
            return "Je n'aime pas trop la façon dont vous me regardez. Je suis en train de travailler, moi.";
          case 165:
            return "Au fait, " + player.name + ", vous venez de voir  " + str8 + " ? Est-ce qu'il aurait parlé de moi, par hasard ?";
          case 166:
            return str4 + " parle toujours de pressuriser mes plaques de pression. Je lui ai dit que c'était pour marcher dessus.";
          case 167:
            return "Il faut toujours acheter plus de câbles que prévu.";
          case 168:
            return "Vous avez bien vérifié que votre matériel était branché ?";
          case 169:
            return "Vous savez ce qu'il faudrait à cette maison ? Plus de stroboscopes.";
          case 170:
            return "La lune sanglante se remarque lorsque le ciel vire au rouge et quelque chose fait que les monstres pullulent.";
          case 171:
            return "Dites donc, vous savez où je peux trouver de la mauvaise herbe morte. Non, pour rien, je me demandais, c'est tout.";
          case 172:
            return "Si vous regardiez en l'air, vous verriez que là, la lune est toute rouge.";
          case 173:
            return "La nuit, vous devriez rester à l'intérieur. C'est très dangereux de se balader dans le noir.";
          case 174:
            return "Bienvenue, " + player.name + ". Je peux faire quelque chose pour vous ?";
          case 175:
            return "Je suis là pour vous conseiller et vous aider dans vos prochaines actions. Vous devriez venir me parler au moindre problème.";
          case 176:
            return "On dit qu'il y a une personne capable de vous aider à survivre sur ces terres... Oh, attendez, c'est moi.";
          case 177:
            return "Vous pouvez utiliser votre pioche pour creuser dans la terre, et votre hache pour abattre des arbres. Placez simplement le curseur à l'emplacement souhaité et cliquez.";
          case 178:
            return "Si vous voulez survivre, vous allez devoir fabriquer des armes et un abri. Commencez par abattre des arbres et récolter du bois.";
          case 179:
            return "Appuyez sur " + (object) '\x008B' + " pour accéder au menu d'artisanat. Lorsque vous avez assez de bois, créez un établi. Tant que vous vous tiendrez à proximité, il vous permettra de fabriquer des objets plus complexes.";
          case 180:
            return "Vous pouvez construire un abri en plaçant du bois ou d'autres blocs dans le monde. N'oubliez pas de créer des murs et de les placer.";
          case 181:
            return "Une fois que vous aurez une épée en bois, vous pourrez essayer de récupérer du gel grâce aux slimes. Combinez ensuite le bois et le gel pour faire une torche.";
          case 182:
            return "Pour interagir avec les arrière-plans et les objets placés, utilisez un marteau.";
          case 183:
            return "Vous devriez creuser pour trouver du minerai. Cela vous permet de fabriquer des objets très utiles.";
          case 184:
            return "Maintenant que vous avez du minerai, vous allez devoir le transformer en lingot pour pouvoir en faire des objets. Il vous faut une fournaise.";
          case 185:
            return "Vous pouvez fabriquer une fournaise avec des torches, du bois et de la pierre. Assurez-vous de vous tenir près d'un établi.";
          case 186:
            return "Vous aurez besoin d'une enclume pour pouvoir fabriquer la plupart des choses à partir des lingots de métal.";
          case 187:
            return "Une enclume peut être fabriquée avec du fer ou bien achetée chez les marchands.";
          case 188:
            return "Le souterrain contient des cœurs de cristal utilisés pour augmenter votre maximum de vie. Il vous faudra un marteau pour les extraire.";
          case 189:
            return "Si vous récupérez dix étoiles filantes, elles peuvent être combinées pour fabriquer un objet qui augmentera votre capacité de magie.";
          case 190:
            return "Les étoiles tombent sur le monde durant la nuit. Elles peuvent être utilisées pour toutes sortes de choses utiles. Si vous en voyez une, dépêchez-vous de la ramasser, car elles disparaissent l'aube venue.";
          case 191:
            return "Il existe de nombreux moyens pour attirer du monde dans notre ville. Bien sûr, une fois sur place, ces nouveaux arrivants auront besoin d'une maison pour s'abriter.";
          case 192:
            return "Pour qu'une pièce puisse être considérée comme un foyer, elle doit comporter une porte, une chaise, une table et une source de lumière. Assurez-vous que la maison dispose également de murs.";
          case 193:
            return "Deux personnes distinctes ne vivront pas dans le même foyer. De plus, si leur foyer est détruit, ils chercheront un nouveau lieu où habiter.";
          case 194:
            return "Vous pouvez utiliser l'interface de logement pour attribuer des logements et les visualiser. Ouvrez votre inventaire et cliquez sur l'icône de maison.";
          case 195:
            return "Si vous souhaitez qu'un marchand emménage, vous devrez avoir une quantité d'argent suffisante. 50 pièces d'argent devraient suffire.";
          case 196:
            return "Pour qu'une infirmière emménage, il vous faudra peut-être augmenter votre maximum de vie.";
          case 197:
            return "Si vous avez un pistolet, il se peut qu'un marchand d'armes fasse son apparition pour vous vendre des munitions.";
          case 198:
            return "Vous devriez montrer de quoi vous êtes capable en triomphant d'un monstre. Cela attirera l'attention d'une dryade.";
          case 199:
            return "Assurez-vous d'explorer minutieusement les donjons. Il pourrait y avoir des prisonniers retenus captifs dans les profondeurs.";
          case 200:
            return "Peut-être que le vieil homme du donjon voudra se joindre à nous maintenant que sa malédiction a été levée.";
          case 201:
            return "Récupérez toutes les bombes que vous pourrez trouver. Un démolisseur voudra sûrement y jeter un œil.";
          case 202:
            return "Les gobelins sont-ils si différents de nous pour que nous ne puissions pas vivre ensemble de manière paisible ?";
          case 203:
            return "J'ai entendu dire qu'un puissant magicien vivait dans les environs. Assurez-vous de le trouver la prochaine fois que vous irez dans le souterrain.";
          case 204:
            return "Si vous combinez des lentilles à un autel de démon, vous pourrez trouver un moyen d'invoquer un monstre très puissant. Cependant, il vous faudra attendre la tombée de la nuit avant de pouvoir l'utiliser.";
          case 205:
            return "Vous pouvez fabriquer de la nourriture pour ver avec des morceaux pourris et de la poudre infecte. Assurez-vous de vous trouver dans une zone corrompue avant de l'utiliser.";
          case 206:
            return "Les autels démoniaques peuvent généralement être trouvés dans la corruption. Il vous faudra vous tenir près d'eux pour fabriquer certains objets.";
          case 207:
            return "Vous pouvez fabriquer un grappin avec un crochet et trois chaînes. Les squelettes trouvés dans les profondeurs portent souvent des crochets sur eux. Les chaînes peuvent être fabriquées à l'aide de lingots de fer.";
          case 208:
            return "Si vous voyez des pots, détruisez-les pour les ouvrir, car ils contiennent souvent des objets très utiles.";
          case 209:
            return "Des trésors sont disséminés un peu partout dans le monde et vous pouvez trouver des objets fantastiques dans les profondeurs.";
          case 210:
            return "Lorsqu'on écrase un orbe d'ombre, il arrive qu'une météorite tombe du ciel. Les orbes d'ombre peuvent généralement être trouvés dans les gouffres des zones corrompues.";
          case 211:
            return "Vous devriez vous employer à récolter davantage de cristaux de cœur pour augmenter votre maximum de vie.";
          case 212:
            return "Votre équipement actuel ne suffira pas. Il vous faut une meilleure armure.";
          case 213:
            return "Je crois que vous pouvez maintenant prendre part à votre première grande bataille. De nuit, rassemblez des lentilles récupérées des globes oculaires et portez-les sur un autel du démon.";
          case 214:
            return "Vous devriez augmenter votre vie avant votre prochaine épreuve. Quinze cœurs devraient suffire.";
          case 215:
            return "La pierre d'ébène dans la corruption peut être purifiée en utilisant de la poudre fournie par une dryade, ou bien peut être détruite avec des explosifs.";
          case 216:
            return "Votre prochaine épreuve sera d'explorer les abîmes corrompus. Trouvez et détruisez tous les orbes d'ombre que vous trouverez.";
          case 217:
            return "Il existe un vieux donjon situé pas très loin d'ici. Vous devriez aller y faire un tour dès maintenant.";
          case 218:
            return "Vous devriez essayer d'augmenter votre vie au maximum. Essayez de rassembler vingt cœurs.";
          case 219:
            return "Si vous pouvez creuser assez profondément, il y a de nombreux trésors à découvrir dans la jungle.";
          case 220:
            return "Le monde des Enfers est fait d'un matériau appelé pierre de l'enfer. Ce matériau est parfait pour la fabrication d'armes et d'armures.";
          case 221:
            return "Lorsque vous voudrez affronter le gardien du monde des Enfers, vous devrez faire le sacrifice d'un être vivant. Tout ce dont vous avez besoin pour cela se trouve dans le monde des Enfers.";
          case 222:
            return "Assurez-vous d'écraser tous les autels de démon que vous trouverez. Vous pourrez en tirer quelque chose de bénéfique.";
          case 223:
            return "Des âmes peuvent être parfois récupérées des créatures déchues dans des lieux de lumière ou d'ombre extrême.";
          case 224:
            return "Ho ho ho et une bouteille de... lait de poule !";
          case 225:
            return "Vous voulez bien me faire des biscuits ?";
          case 226:
            return "Quoi ? Vous pensiez que je n'existais pas ?";
          case 227:
            return "J'ai réussi à recoudre votre visage. Faites plus attention la prochaine fois.";
          case 228:
            return "Cela va probablement laisser une cicatrice.";
          case 229:
            return "Ça va mieux. Je ne veux plus vous voir sauter du sommet des falaises.";
          case 230:
            return "Cela n'a pas fait trop mal, n'est-ce pas ?";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case 1:
            return "Espero que un canijo como tú no sea lo único que se interpone entre nosotros y el Ojo de Cthulu.";
          case 2:
            return "Vaya una armadura más chapucera que llevas. Yo de ti compraría más pociones curativas.";
          case 3:
            return "Siento como si una presencia maligna me observara.";
          case 4:
            return "¡La espada siempre gana! Cómprate una ahora.";
          case 5:
            return "¿Quieres manzanas? ¿Zanahorias? ¿Unas piñas? Tenemos antorchas.";
          case 6:
            return "Una mañana estupenda, ¿verdad? ¿No necesitas nada?";
          case 7:
            return "La noche caerá pronto, amigo. Haz tus compras mientras puedas.";
          case 8:
            return "Ni te imaginas lo bien que se venden los bloques de tierra en el extranjero.";
          case 9:
            return "Oh, algún día narrarán las aventuras de " + player.name + "... y seguro que acaban bien.";
          case 10:
            return "Echa un vistazo a estos bloques de tierra... ¡Tienen extra de tierra!";
          case 11:
            return "¡Oye, cómo pega el sol! Por suerte, tengo armaduras totalmente transpirables.";
          case 12:
            return "El sol está alto, al contrario que mis precios.";
          case 13:
            return "¡Vaya! Desde aquí se oye cómo discuten " + str10 + " y " + str2 + ".";
          case 14:
            return "¿Has visto a Chith... esto... Shith... eh... Chat...? Vamos, ¿al gran Ojo?";
          case 15:
            return "Oye, esta casa es segura, ¿verdad? ¿Verdad? " + player.name + "...";
          case 16:
            return "Ni siquiera una luna de sangre detendría el capitalismo. Así que vamos a hacer negocios.";
          case 17:
            return "No pierdas de vista tus sueños. ¡Compra una lente!";
          case 18:
            return "Kosh, kapleck Mog. Lo siento, hablaba en klingon... quiere decir \"Compra algo o muere\".";
          case 19:
            return "¿Eres tú, " + player.name + "? ¡Me han hablado bien de ti, amigo!";
          case 20:
            return "Dicen que aquí hay un tesoro escondido... Oh, olvídalo...";
          case 21:
            return "¿La estatua de un ángel? Lo siento pero no vendo cosas de segunda mano.";
          case 22:
            return "El último tipo que estuvo aquí me dejó algunos trastos viejos... ¡Bueno, en realidad eran tesoros!";
          case 23:
            return "Me pregunto si la luna estará hecha de queso... Eh... esto... ¿Querías comprar algo?";
          case 24:
            return "¿Has dicho oro? Me lo quedo.";
          case 25:
            return "Será mejor que no me manches de sangre.";
          case 26:
            return "Date prisa... y deja ya de sangrar.";
          case 27:
            return "Si te vas a morir hazlo fuera, por favor.";
          case 28:
            return "¿Y eso qué quiere decir?";
          case 29:
            return "No me gusta el tono que empleas.";
          case 30:
            return "¿Por qué sigues aquí? Si no te estás desangrando, aquí no pintas nada. Lárgate.";
          case 31:
            return "¿¡CÓMO!?";
          case 32:
            return "¿Has visto a ese anciano que deambula por la mazmorra? Parece que tiene problemas.";
          case 33:
            return "Ojalá " + str6 + " tuviera más cuidado. Ya me estoy hartando de tener que coserle las extremidades todos los días.";
          case 34:
            return "Oye, por curiosidad, ¿ha dicho " + str4 + " por qué tiene que ir al médico?";
          case 35:
            return "Debo hablar en serio con " + str3 + ". ¿Cuántas veces crees que puedes venir en una semana con quemaduras de lava graves?";
          case 36:
            return "Creo que así estarás mejor.";
          case 37:
            return "Eh... ¿Qué te ha pasado en la cara?";
          case 38:
            return "¡DIOS MÍO! Soy buena en mi trabajo, pero no tanto.";
          case 39:
            return "Queridos amigos, nos hemos reunido hoy aquí para decir adiós a... ¡Era broma! Saldrás de esta.";
          case 40:
            return "Te dejaste el brazo por ahí. Deja que te ayude...";
          case 41:
            return "¡Deja de comportarte como un bebé! He visto cosas peores.";
          case 42:
            return "¡Voy a tener que darte puntos!";
          case 43:
            return "¿Ya te has vuelto a meter en líos?";
          case 44:
            return "Aguanta, por aquí tengo unas tiritas infantiles chulísimas.";
          case 45:
            return "Anda ya, " + player.name + ", te pondrás bien. Serás nenaza...";
          case 46:
            return "Así que te duele cuando haces eso... Pues no lo hagas.";
          case 47:
            return "Vienes como si estuvieras a medio digerir. ¿Has estado cazando slimes otra vez?";
          case 48:
            return "Gira la cabeza y tose.";
          case 49:
            return "No es de las peores heridas que he visto... Sin duda, he visto heridas más grandes que esta.";
          case 50:
            return "¿Quieres una piruleta, chiquitín?";
          case 51:
            return "A ver... ¿Dónde te duele?";
          case 52:
            return "Lo siento, pero no trabajo por caridad.";
          case 53:
            return "Vas a necesitar más oro del que traes.";
          case 54:
            return "Oye, yo no trabajo gratis.";
          case 55:
            return "No tengo una varita mágica.";
          case 56:
            return "Esto es todo lo que puedo hacer por ti... Necesitas cirugía plástica.";
          case 57:
            return "No me hagas perder el tiempo.";
          case 58:
            return "Dicen que en alguna parte del Inframundo hay una muñeca que se parece mucho a " + str3 + ". Ojalá pudiera usarla para practicar el tiro al blanco.";
          case 59:
            return "¡Date prisa! Tengo una cita con " + str2 + " dentro de una hora.";
          case 60:
            return "Quiero lo que vende " + str2 + ". ¿Cómo dices? ¿Que no vende nada?";
          case 61:
            return str5 + " es una monada. Es una lástima que sea tan mojigata.";
          case 62:
            return "Olvídate de " + str6 + ", yo tengo todo lo que necesitas aquí y ahora.";
          case 63:
            return "¿Qué mosca le ha picado a " + str6 + "? ¿Aún no sabe que vendemos cosas totalmente distintas?";
          case 64:
            return "Oye, hace una noche magnífica para no hablar con nadie, ¿no crees, " + player.name + "?";
          case 65:
            return "Me encantan estas noches. ¡Siempre encuentras algo que matar!";
          case 66:
            return "Veo que le has echado el ojo al Minitiburón. Será mejor que no sepas de qué está hecho.";
          case 67:
            return "Eh, amigo, que esto no es una película. La munición va aparte.";
          case 68:
            return "¡Aparta esas manos de mi pistola, colega!";
          case 69:
            return "¿Has probado a usar polvos de purificación sobre la piedra de ébano corrupta?";
          case 70:
            return "Ojalá " + str4 + " dejara de flirtear conmigo. ¿No se da cuenta de que tengo 500 años?";
          case 71:
            return "¿Por qué se empeña " + str1 + " en intentar venderme una estatua de ángel? Todo el mundo sabe que no sirven para nada.";
          case 72:
            return "¿Has visto a ese anciano que deambula por la mazmorra? No tiene muy buen aspecto...";
          case 73:
            return "¡Yo vendo lo que quiero! Si no te gusta, mala suerte.";
          case 74:
            return "¿Por qué tienes que ser tan beligerante en estos tiempos que corren?";
          case 75:
            return "No quiero que compres mis artículos. Quiero que desees comprar mis artículos, ¿entiendes?";
          case 76:
            return "Oye, ¿soy yo o esta noche han salido de juerga un millón de zombis?";
          case 77:
            return "Debes erradicar la corrupción de este mundo.";
          case 78:
            return "Ponte a salvo; ¡Terraria te necesita!";
          case 79:
            return "Fluyen las arenas del tiempo. Y la verdad, no estás envejeciendo con mucha elegancia.";
          case 80:
            return "¿Qué tiene que ver conmigo eso de perro ladrador?";
          case 81:
            return "Entra un duende en un bar y dice el dueño: \"A ver, quiero control, ¿eh?\". Y dice el duende: \"No, sin trol, sin trol\".";
          case 82:
            return "No puedo dejarte entrar hasta que me liberes de esta maldición.";
          case 83:
            return "Si quieres entrar, vuelve por la noche.";
          case 84:
            return "No se puede invocar al maestro a la luz del día.";
          case 85:
            return "Eres demasiado débil para romper esta maldición. Vuelve cuando seas de más utilidad.";
          case 86:
            return "Eres patético. No esperes presentarte ante el maestro tal como eres.";
          case 87:
            return "Espero que hayas venido con varios amigos...";
          case 88:
            return "No lo hagas, forastero. Sería un suicidio.";
          case 89:
            return "Tal vez seas lo bastante fuerte para poder librarme de esta maldición...";
          case 90:
            return "Forastero, ¿te crees con fuerzas para derrotar al maestro?";
          case 91:
            return "¡Por favor! ¡Lucha con mi raptor y libérame! ¡Te lo suplico!";
          case 92:
            return "Derrota al maestro y te permitiré entrar a la mazmorra.";
          case 93:
            return "¿Conque intentando librarte de esa piedra de ébano, eh? ¿Por qué pruebas con estos explosivos?";
          case 94:
            return "Eh, ¿has visto a un payaso por aquí?";
          case 95:
            return "Había una bomba aquí mismo, y ahora no soy capaz de encontrarla...";
          case 96:
            return "¡Yo les daré a esos zombis lo que necesitan!";
          case 97:
            return "¡Incluso " + str4 + " quiere lo que vendo!";
          case 98:
            return "Y pensé: ¿Qué prefieres? ¿Un agujero de bala o de granada?";
          case 99:
            return "Seguro que " + str2 + " te ayudará si pierdes una extremidad jugando con estas monadas...";
          case 100:
            return "¿Por qué purificar el mundo cuando puedes volarlo en pedazos?";
          case 101:
            return "¡Si lanzas uno de estos en la bañera y cierras todas las ventanas, te despejará la nariz y los oídos!";
          case 102:
            return "¿Quieres jugar con fuego, gallina?";
          case 103:
            return "Oye, ¿firmarías esta renuncia de daños y perjuicios?";
          case 104:
            return "¡AQUÍ NO SE PUEDE FUMAR!";
          case 105:
            return "Los explosivos están de moda hoy en día. ¡Llévate unos cuantos!";
          case 106:
            return "¡Es un buen día para morir!";
          case 107:
            return "Y qué pasa si... (¡BUM!)... Oh, lo siento, ¿usabas mucho esa pierna?";
          case 108:
            return "Dinamita, mi propia panacea para todos los males.";
          case 109:
            return "Echa un vistazo a este género; ¡los precios son una bomba!";
          case 110:
            return "Recuerdo vagamente haber atado a una mujer y haberla arrojado a una mazmorra.";
          case 111:
            return "¡Tenemos un problema! ¡Hoy tenemos luna de sangre!";
          case 112:
            return "Si fuera más joven, invitaría a " + str2 + " a salir. Yo antes era todo un galán.";
          case 113:
            return "Ese sombrero rojo me resulta familiar...";
          case 114:
            return "Gracias otra vez por librarme de esta maldición. Sentí como si algo me hubiera saltado encima y me hubiera mordido.";
          case 115:
            return "Mamá siempre dijo que yo sería un buen sastre.";
          case 116:
            return "La vida es como un cajón de la ropa; ¡nunca sabes qué te vas a poner!";
          case 117:
            return "¡Desde luego bordar es una tarea difícil! ¡Si no fuera así, nadie lo haría! Eso es lo que la hace tan genial.";
          case 118:
            return "Sé todo lo que hay que saber sobre el negocio de la confección.";
          case 119:
            return "La maldición me ha convertido en un ser solitario; una vez me hice amigo de un muñeco de cuero. Lo llamaba Wilson.";
          case 120:
            return "Gracias por liberarme, humano. Los otros duendes me ataron y me dejaron aquí. Te puedes imaginar que no nos llevamos muy bien.";
          case 121:
            return "¡No puedo creer que me ataran y me dejaran aquí solo por decirles que no se dirigían al este!";
          case 122:
            return "Ahora que soy un proscrito, ¿puedo tirar ya estas bolas de pinchos? Tengo los bolsillos destrozados.";
          case 123:
            return "¿Buscas un experto en artilugios? ¡Yo soy tu duende!";
          case 124:
            return "Gracias por tu ayuda. Tengo que dejar de vagar por ahí sin rumbo. Seguro que nos volvemos a ver.";
          case 125:
            return "Creía que eras más alto.";
          case 126:
            return "Oye... ¿Qué trama " + str10 + "? ¿Tú... has hablado con ella, por un casual?";
          case (int) sbyte.MaxValue:
            return "Eh, ¿quieres un motor para tu sombrero? Creo que tengo un motor que quedaría de perlas en ese sombrero.";
          case 128:
            return "Oye, he oído que te gustan los cohetes y las botas de correr, así que he puesto unos cohetes en tus botas.";
          case 129:
            return "Mi reino por un poco de cinta adhesiva...";
          case 130:
            return "Pues claro, el oro es más resistente que el hierro. ¿Pero qué os enseñan estos humanos de hoy?";
          case 131:
            return "En fin, la idea de un casco de minero con alas quedaba mucho mejor sobre el papel.";
          case 132:
            return "Los duendes tienen una increíble predisposición al enfado. ¡De hecho, podrían declarar una guerra por una discusión sobre ropa!";
          case 133:
            return "Sinceramente, la mayoría de los duendes no son precisamente unos genios. Bueno, algunos sí.";
          case 134:
            return "¿Tú sabes por qué llevamos estas bolas con pinchos? Porque yo no.";
          case 135:
            return "¡Acabo de terminar mi última creación! Esta versión no explota con violencia si respiras encima.";
          case 136:
            return "Los duendes ladrones no son muy buenos en lo suyo. ¡Ni siquiera saben robar un cofre abierto!";
          case 137:
            return "¡Gracias por salvarme! Estas ataduras me estaban haciendo rozaduras.";
          case 138:
            return "¡Oh, te debo la vida!";
          case 139:
            return "¡Oh, qué heroico! ¡Gracias por salvarme, jovencita!";
          case 140:
            return "¡Oh, qué heroico por tu parte! ¡Gracias por salvarme, jovencito!";
          case 141:
            return "Ahora que nos conocemos, ¿me puedo ir a vivir contigo, verdad?";
          case 142:
            return "¡Eh, hola, " + str3 + "! ¿Qué puedo hacer hoy por ti?";
          case 143:
            return "¡Eh, hola, " + str6 + "! ¿Qué puedo hacer hoy por ti?";
          case 144:
            return "¡Eh, hola, " + str8 + "! ¿Qué puedo hacer hoy por ti?";
          case 145:
            return "¡Eh, hola, " + str2 + "! ¿Qué puedo hacer hoy por ti?";
          case 146:
            return "¡Eh, hola, " + str10 + "! ¿Qué puedo hacer hoy por ti?";
          case 147:
            return "¡Eh, hola, " + str5 + "! ¿Qué puedo hacer hoy por ti?";
          case 148:
            return "¿Quieres que saque un conejo de tu chistera? ¿No? Pues nada.";
          case 149:
            return "¿Quieres un caramelo mágico? ¿No? Vale.";
          case 150:
            return "Si te gusta, te puedo hacer un delicioso chocolate calentito... ¿Tampoco? Vale, está bien.";
          case 151:
            return "¿Has venido a echar un ojo a mi bola de cristal?";
          case 152:
            return "¿Nunca has deseado tener un anillo mágico que convierta las piedras en slimes? La verdad es que yo tampoco.";
          case 153:
            return "Una vez me dijeron que la amistad es algo mágico. ¡Ridículo! No puedes convertir a nadie en rana con la amistad.";
          case 154:
            return "Veo tu futuro... ¡Vas a comprarme un montón de artículos!";
          case 155:
            return "En cierta ocasión intenté devolverle la vida a una estatua de ángel. Pero no pasó nada.";
          case 156:
            return "¡Gracias! Un poco más y habría acabado como los demás esqueletos de ahí abajo.";
          case 157:
            return "¡Eh, mira por dónde vas! ¡Llevo ahí desde hace... un rato!";
          case 158:
            return "Espera un momento, ya casi he conseguido que funcione el wifi.";
          case 159:
            return "¡Casi había acabado de poner luces intermitentes aquí arriba!";
          case 160:
            return "¡No te muevas! ¡Se me ha caído una lentilla!";
          case 161:
            return "Lo único que quiero es que el conmutador haga... ¿Qué?";
          case 162:
            return "A ver si lo adivino. No has comprado suficiente cable. ¡Ya te vale!";
          case 163:
            return "¿Podrías...? Solo... ¿Por favor...? ¿Vale? Está bien. Arrg.";
          case 164:
            return "No me gusta cómo me miras. Ahora estoy TRABAJANDO.";
          case 165:
            return "Eh, " + player.name + ", ¿acabas de llegar de la casa de " + str8 + "? ¿Por casualidad no te hablaría de mí?";
          case 166:
            return str4 + " sigue insistiendo en pulir mi place de presión. Ya le he dicho que funciona pisándola.";
          case 167:
            return "¡Siempre compras más cable del que necesitas!";
          case 168:
            return "¿Has comprobado si tu dispositivo está enchufado?";
          case 169:
            return "Oh, ¿sabes lo que necesita esta casa? Más luces intermitentes.";
          case 170:
            return "Sabrás que se avecina una luna de sangre cuando el cielo se tiña de rojo. Hay algo en ella que hace que los monstruos ataquen en grupo.";
          case 171:
            return "Eh, amigo, ¿sabes dónde hay por aquí malahierba? Oh, no es por nada, solo preguntaba, nada más.";
          case 172:
            return "Si miraras hacia arriba, verías que ahora mismo la luna está roja.";
          case 173:
            return "Deberías quedarte en casa por la noche. Es muy peligroso andar por ahí en la oscuridad.";
          case 174:
            return "Saludos, " + player.name + ". ¿Te puedo ayudar en algo?";
          case 175:
            return "Estoy aquí para aconsejarte sobre lo que debes ir haciendo. Te aconsejo que hables conmigo cuando estés atascado.";
          case 176:
            return "Dicen que hay una persona que te dirá cómo sobrevivir en esta tierra... ¡Oh, espera, sí soy yo!";
          case 177:
            return "Puedes usar el pico para cavar en la tierra y el hacha para talar árboles. Sitúa el cursor sobre el ladrillo y pulsa " + (object) '\x0081' + ".";
          case 178:
            return "Si quieres sobrevivir, tendrás que crear armas y un cobijo. Empieza talando árboles y recogiendo madera.";
          case 179:
            return "Pulsa  " + (object) '\x008B' + " para acceder al menú de creación. Cuando tengas suficiente madera, crea un banco de trabajo. De este modo podrás crear objetos más elaborados siempre que permanezcas cerca del banco.";
          case 180:
            return "Puedes construir un cobijo juntando madera y otros bloques que hay por el mundo. No olvides levantar y colocar paredes.";
          case 181:
            return "En cuanto tengas una espada de madera, puedes intentar recoger el gel de los slimes. Mezcla madera y gel para hacer una antorcha.";
          case 182:
            return "Usa un martillo para interactuar con el entorno y colocar objetos.";
          case 183:
            return "Deberías cavar una mina para encontrar vetas de mineral. Así podrás crear objetos muy útiles.";
          case 184:
            return "Ahora que tienes minerales, tendrás que convertirlos en un lingote para fabricar objetos con ellos. Para ello necesitas una forja.";
          case 185:
            return "Puedes construir una forja con antorchas, madera y piedra. Asegúrate de no alejarte del banco de trabajo.";
          case 186:
            return "Necesitarás un yunque para crear objetos con los lingotes de metal.";
          case 187:
            return "Los yunques se pueden hacer de hierro o bien comprarse a un mercader.";
          case 188:
            return "En el subsuelo hay cristales de corazón que puedes usar para aumentar al máximo tu vida. Para recogerlos, necesitarás un martillo.";
          case 189:
            return "Si recoges 10 estrellas fugaces, podrás combinarlas para crear un objeto que aumente tu poder mágico.";
          case 190:
            return "Las estrellas fugaces caen del cielo a la tierra por la noche. Se pueden utilizar para toda clase de objetos útiles. Si ves una date prisa en cogerla, ya que desaparecen al amanecer.";
          case 191:
            return "Hay muchas formas de hacer que los demás se muden a nuestra ciudad. Por supuesto, necesitarán una casa en la que vivir.";
          case 192:
            return "Para que una habitación pueda ser considerada un hogar, debe tener una puerta, una silla, una mesa y una fuente de luz. Y paredes, claro.";
          case 193:
            return "En la misma casa no pueden vivir dos personas. Además, si se destruye una casa, esa persona deberá buscar un nuevo lugar donde vivir.";
          case 194:
            return "En la interfaz de Cobijo puedes ver y asignar viviendas. Abre tu inventario y haz clic en el icono de casa.";
          case 195:
            return "Si quieres que un mercader se mude a una casa, deberás recoger una gran cantidad de dinero. Bastará con 50 monedas de plata.";
          case 196:
            return "Para que se mude una enfermera, tendrías que aumentar al máximo tu nivel de vida.";
          case 197:
            return "Si tuvieras alguna pistola, seguro que aparecería algún traficante de armas para venderte municiones.";
          case 198:
            return "Deberías ponerte a prueba y derrotar a un monstruo corpulento. Eso llamaría la atención de una dríada.";
          case 199:
            return "Asegúrate de explorar la mazmorra a fondo. Podría haber prisioneros retenidos en la parte más profunda.";
          case 200:
            return "Quizás el anciano de la mazmorra quiera unirse a nosotros ahora que su maldición ha desaparecido.";
          case 201:
            return "Guarda bien las bombas que encuentres. Algún demoledor querrá echarles un vistazo.";
          case 202:
            return "¿En realidad los duendes son tan distintos a nosotros que no podríamos vivir juntos en paz?";
          case 203:
            return "He oído que por esta región vive un poderoso mago. Estate muy atento por si lo ves la próxima vez que viajes al subsuelo.";
          case 204:
            return "Si juntas varias lentes en un altar demoníaco, tal vez encuentres la forma de invocar a un monstruo poderoso. Aunque te conviene esperar hasta la noche para hacerlo.";
          case 205:
            return "Puedes hacer cebo de gusanos con trozos podridos y polvo vil. Asegúrate de estar en una zona corrompida antes de usarlo.";
          case 206:
            return "Los altares demoníacos se suelen encontrar en territorio corrompido. Deberás estar cerca de ellos para crear ciertos objetos.";
          case 207:
            return "Puedes hacerte un garfio de escalada con un garfio y tres cadenas. Los esqueletos se encuentran en las profundidades del subsuelo y suelen llevar ganchos. En cuanto a las cadenas, se pueden fabricar con lingotes de hierro.";
          case 208:
            return "Si ves un jarrón, ábrelo aunque sea a golpes. Contienen toda clase de suministros de utilidad.";
          case 209:
            return "Hay tesoros escondidos por todo el mundo. ¡En las profundidades del subsuelo se pueden encontrar objetos maravillosos!";
          case 210:
            return "Romper un orbe sombrío a veces provoca la caída de un meteorito del cielo. Los orbes sombríos se suelen encontrar en los abismos que rodean las zonas corrompidas";
          case 211:
            return "Deberías dedicarte a recoger más cristal de corazón para aumentar tu nivel de vida hasta el máximo.";
          case 212:
            return "El equipo que llevas sencillamente no sirve. Debes mejorar tu armadura.";
          case 213:
            return "Creo que ya estás listo para tu primera gran batalla. Recoge de noche algunas lentes de los ojos y llévalas a un altar demoníaco.";
          case 214:
            return "Te conviene aumentar tu nivel de vida antes de enfrentarte al siguiente desafío. Con 15 corazones bastará.";
          case 215:
            return "La piedra de ébano que se encuentra en el territorio corrompido se puede purificar usando un poco de polvo de dríada, o destruirla con explosivos.";
          case 216:
            return "El siguiente paso debería ser explorar los abismos corrompidos. Encuentra y destruye todos los orbes sombríos que encuentres.";
          case 217:
            return "No muy lejos de aquí hay una antigua mazmorra. Ahora sería un buen momento para ir a echar un vistazo.";
          case 218:
            return "Deberías intentar aumentar al máximo tu nivel de vida. Intenta conseguir 20 corazones.";
          case 219:
            return "Hay muchos tesoros por descubrir en la selva si estás dispuesto a cavar a suficiente profundidad.";
          case 220:
            return "El Inframundo se compone de un material llamado piedra infernal, perfecto para hacer armas y armaduras.";
          case 221:
            return "Cuando estés preparado para desafiar al guardián del Inframundo, tendrás que hacer un sacrificio viviente. Todo lo que necesitas para hacerlo lo encontrarás en el Inframundo.";
          case 222:
            return "No dejes de destruir todos los altares demoníacos que encuentres. ¡Algo bueno te sucederá si lo haces!";
          case 223:
            return "A veces puedes recuperar el alma de las criaturas caídas en lugares de extrema luminosidad u oscuridad.";
          case 224:
            return "Ho, ho, ho y una botella de... ¡ponche de huevo!";
          case 225:
            return "¿Me preparas unas galletitas?";
          case 226:
            return "¿Qué? ¿Creías que no existía?";
          case 227:
            return "Me las arreglé para coserte la cara de nuevo. Ten más cuidado la próxima vez.";
          case 228:
            return "Seguramente te quede una cicatriz.";
          case 229:
            return "Ya está. No quiero verte saltar por más acantilados.";
          case 230:
            return "No ha sido para tanto, ¿verdad?";
        }
      }
      return (string) null;
    }

    public static string setBonus(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case 0:
            return "2 defense";
          case 1:
            return "3 defense";
          case 2:
            return "15% increased movement speed";
          case 3:
            return "Space Gun costs 0 mana";
          case 4:
            return "20% chance to not consume ammo";
          case 5:
            return "16% reduced mana usage";
          case 6:
            return "17% extra melee damage";
          case 7:
            return "20% increased mining speed";
          case 8:
            return "14% reduced mana usage";
          case 9:
            return "15% increased melee speed";
          case 10:
            return "20% chance to not consume ammo";
          case 11:
            return "17% reduced mana usage";
          case 12:
            return "5% increased melee critical strike chance";
          case 13:
            return "20% chance to not consume ammo";
          case 14:
            return "19% reduced mana usage";
          case 15:
            return "18% increased melee and movement speed";
          case 16:
            return "25% chance to not consume ammo";
          case 17:
            return "20% reduced mana usage";
          case 18:
            return "19% increased melee and movement speed";
          case 19:
            return "25% chance to not consume ammo";
          case 20:
            return "23% reduced mana usage";
          case 21:
            return "21% increased melee and movement speed";
          case 22:
            return "28% chance to not consume ammo";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case 0:
            return "2 Abwehr";
          case 1:
            return "3 Abwehr";
          case 2:
            return "Um 15% erhöhtes Bewegungstempo";
          case 3:
            return "Weltraumpistole kostet 0 Mana";
          case 4:
            return "20%ige Chance, keine Munition zu verbrauchen";
          case 5:
            return "Um 16% reduzierte Mananutzung";
          case 6:
            return "17% extra Nahkampfschaden";
          case 7:
            return "Um 20% erhöhtes Abbautempo";
          case 8:
            return "Um 14% reduzierte Mananutzung";
          case 9:
            return "Um 15% erhöhtes Nahkampftempo";
          case 10:
            return "20%ige Chance, keine Munition  zu verbrauchen";
          case 11:
            return "Um 17% reduzierte Mananutzung";
          case 12:
            return "5% Erhöhte kritische Nahkampf-Trefferchance";
          case 13:
            return "20%ige Chance, keine Munition zu verbrauchen";
          case 14:
            return "Um 19% reduzierte Mananutzung";
          case 15:
            return "18% Erhöhtes Nahkampf-und Bewegungstempo";
          case 16:
            return "25%ige Chance, keine Munition  zu verbrauchen";
          case 17:
            return "Um 20% reduzierte Mananutzung";
          case 18:
            return "19% Erhöhtes Nahkampf-und Bewegungstempo";
          case 19:
            return "25%ige Chance, keine Munition zu verbrauchen";
          case 20:
            return "Um 23% reduzierte Mananutzung";
          case 21:
            return "21% Erhöhtes Nahkampf-und Bewegungstempo";
          case 22:
            return "28%ige Chance, keine Munition zu verbrauchen";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case 0:
            return "2 difesa";
          case 1:
            return "3 difesa";
          case 2:
            return "Velocità di movimento aumentata del 15%";
          case 3:
            return "La pistola spaziale costa 0 mana";
          case 4:
            return "20% di possibilità di non consumare munizioni";
          case 5:
            return "Consumo mana ridotto del 16%";
          case 6:
            return "17% danni da mischia in più";
          case 7:
            return "Velocità di estrazione aumentata del 20%";
          case 8:
            return "Consumo mana ridotto del 14%";
          case 9:
            return "Velocità del corpo a corpo aumentata del 15%";
          case 10:
            return "20% di possibilità di non consumare munizioni";
          case 11:
            return "Consumo mana ridotto del 17%";
          case 12:
            return "Possibilità di colpo critico nel corpo a corpo aumentata del 5%";
          case 13:
            return "20% di possibilità di non consumare munizioni";
          case 14:
            return "Consumo mana ridotto del 19%";
          case 15:
            return "Velocità di corpo a corpo e movimento aumentata del 18%";
          case 16:
            return "25% di possibilità di non consumare munizioni";
          case 17:
            return "Consumo mana ridotto del 20%";
          case 18:
            return "Velocità di corpo a corpo e movimento aumentate del 19%";
          case 19:
            return "25% di possibilità di non consumare munizioni";
          case 20:
            return "Consumo mana ridotto del 23%";
          case 21:
            return "Velocità di corpo a corpo e movimento aumentate del 21%";
          case 22:
            return "28% di possibilità di non consumare munizioni";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case 0:
            return "2 de défense";
          case 1:
            return "3 de défense";
          case 2:
            return "Vitesse de déplacement augmentée de 15 %";
          case 3:
            return "Le fusil de l'espace coûte 0 mana";
          case 4:
            return "20 % de chance de n'utiliser aucune munition";
          case 5:
            return "Utilisation de mana réduite de 16 %";
          case 6:
            return "17% de dégâts de mêlée supplémentaires";
          case 7:
            return "Vitesse d'extraction minière augmentée de 20 %";
          case 8:
            return "Utilisation de mana réduite de 14 %";
          case 9:
            return "Vitesse de mêlée augmentée de 15 %";
          case 10:
            return "20 % de chance de n'utiliser aucune munition";
          case 11:
            return "Utilisation de mana réduite de 17 %";
          case 12:
            return "Chance de coup critique de mêlée augmentée de 5 %";
          case 13:
            return "20 % de chance de n'utiliser aucune munition";
          case 14:
            return "Utilisation de mana réduite de 19 %";
          case 15:
            return "Vitesse de déplacement et de mêlée augmentée de 18 %";
          case 16:
            return "25 % de chance de n'utiliser aucune munition";
          case 17:
            return "Utilisation de mana réduite de 20 %";
          case 18:
            return "Vitesse de déplacement et de mêlée augmentée de 19 %";
          case 19:
            return "25 % de chance de n'utiliser aucune munition";
          case 20:
            return "Utilisation de mana réduite de 23 %";
          case 21:
            return "Vitesse de déplacement et de mêlée augmentée de 21 %";
          case 22:
            return "28 % de chance de n'utiliser aucune munition";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case 0:
            return "2 defensa";
          case 1:
            return "3 defensa";
          case 2:
            return "Aumenta en un 15% la velocidad de movimiento";
          case 3:
            return "La pistola espacial no cuesta maná";
          case 4:
            return "Probabilidad del 20% de no gastar munición";
          case 5:
            return "Reduce el uso de maná en un 16%";
          case 6:
            return "Aumenta en un 17% el daño de los ataques cuerpo a cuerpo";
          case 7:
            return "Aumenta en un 20% la velocidad de excavación";
          case 8:
            return "Reduce el uso de maná en un 14%";
          case 9:
            return "Aumenta un 15% la velocidad de los ataques cuerpo a cuerpo";
          case 10:
            return "Probabilidad del 20% de no gastar munición";
          case 11:
            return "Reduce el uso de maná en un 17%";
          case 12:
            return "Aumenta la probabilidad de conseguir ataques críticos cuerpo a cuerpo";
          case 13:
            return "Probabilidad del 20% de no gastar munición";
          case 14:
            return "Reduce el uso de maná en un 19%";
          case 15:
            return "Aumenta en un 18% la velocidad de movimiento y de los ataques cuerpo a cuerpo";
          case 16:
            return "Probabilidad del 25% de no gastar munición";
          case 17:
            return "Reduce el uso de maná en un 20%";
          case 18:
            return "19% Aumenta la velocidad de movimiento y en el cuerpo a cuerpo";
          case 19:
            return "Probabilidad del 25% de no gastar munición";
          case 20:
            return "Reduce el uso de maná en un 23%";
          case 21:
            return "21% Aumenta la velocidad de movimiento y en el cuerpo a cuerpo";
          case 22:
            return "Probabilidad del 28% de no gastar munición";
        }
      }
      return (string) null;
    }

    public static string npcName(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case -18:
          case -1:
            return "Slimeling";
          case -17:
            return "Big Stinger";
          case -16:
            return "Little Stinger";
          case -15:
            return "Heavy Skeleton";
          case -14:
            return "Big Boned";
          case -13:
            return "Short Bones";
          case -12:
            return "Big Eater";
          case -11:
            return "Little Eater";
          case -10:
            return "Jungle Slime";
          case -9:
            return "Yellow Slime";
          case -8:
            return "Red Slime";
          case -7:
            return "Purple Slime";
          case -6:
            return "Black Slime";
          case -5:
            return "Baby Slime";
          case -4:
            return "Pinky";
          case -3:
            return "Green Slime";
          case -2:
            return "Slimer";
          case 1:
            return "Blue Slime";
          case 2:
            return "Demon Eye";
          case 3:
            return "Zombie";
          case 4:
            return "Eye of Cthulhu";
          case 5:
            return "Servant of Cthulhu";
          case 6:
            return "Eater of Souls";
          case 7:
          case 8:
          case 9:
            return "Devourer";
          case 10:
          case 11:
          case 12:
            return "Giant Worm";
          case 13:
          case 14:
          case 15:
            return "Eater of Worlds";
          case 16:
            return "Mother Slime";
          case 17:
            return "Merchant";
          case 18:
            return "Nurse";
          case 19:
            return "Arms Dealer";
          case 20:
            return "Dryad";
          case 21:
            return "Skeleton";
          case 22:
            return "Guide";
          case 23:
            return "Meteor Head";
          case 24:
            return "Fire Imp";
          case 25:
            return "Burning Sphere";
          case 26:
            return "Goblin Peon";
          case 27:
            return "Goblin Thief";
          case 28:
            return "Goblin Warrior";
          case 29:
            return "Goblin Sorcerer";
          case 30:
            return "Chaos Ball";
          case 31:
            return "Angry Bones";
          case 32:
            return "Dark Caster";
          case 33:
            return "Water Sphere";
          case 34:
            return "Cursed Skull";
          case 35:
          case 36:
            return "Skeletron";
          case 37:
            return "Old Man";
          case 38:
            return "Demolitionist";
          case 39:
          case 40:
          case 41:
            return "Bone Serpent";
          case 42:
            return "Hornet";
          case 43:
            return "Man Eater";
          case 44:
            return "Undead Miner";
          case 45:
            return "Tim";
          case 46:
            return "Bunny";
          case 47:
            return "Corrupt Bunny";
          case 48:
            return "Harpy";
          case 49:
            return "Cave Bat";
          case 50:
            return "King Slime";
          case 51:
            return "Jungle Bat";
          case 52:
            return "Doctor Bones";
          case 53:
            return "The Groom";
          case 54:
            return "Clothier";
          case 55:
            return "Goldfish";
          case 56:
            return "Snatcher";
          case 57:
            return "Corrupt Goldfish";
          case 58:
            return "Piranha";
          case 59:
            return "Lava Slime";
          case 60:
            return "Hellbat";
          case 61:
            return "Vulture";
          case 62:
            return "Demon";
          case 63:
            return "Blue Jellyfish";
          case 64:
            return "Pink Jellyfish";
          case 65:
            return "Shark";
          case 66:
            return "Voodoo Demon";
          case 67:
            return "Crab";
          case 68:
            return "Dungeon Guardian";
          case 69:
            return "Antlion";
          case 70:
            return "Spike Ball";
          case 71:
            return "Dungeon Slime";
          case 72:
            return "Blazing Wheel";
          case 73:
            return "Goblin Scout";
          case 74:
            return "Bird";
          case 75:
            return "Pixie";
          case 77:
            return "Armored Skeleton";
          case 78:
            return "Mummy";
          case 79:
            return "Dark Mummy";
          case 80:
            return "Light Mummy";
          case 81:
            return "Corrupt Slime";
          case 82:
            return "Wraith";
          case 83:
            return "Cursed Hammer";
          case 84:
            return "Enchanted Sword";
          case 85:
            return "Mimic";
          case 86:
            return "Unicorn";
          case 87:
          case 88:
          case 89:
          case 90:
          case 91:
          case 92:
            return "Wyvern";
          case 93:
            return "Giant Bat";
          case 94:
            return "Corruptor";
          case 95:
          case 96:
          case 97:
            return "Digger";
          case 98:
          case 99:
          case 100:
            return "World Feeder";
          case 101:
            return "Clinger";
          case 102:
            return "Angler Fish";
          case 103:
            return "Green Jellyfish";
          case 104:
            return "Werewolf";
          case 105:
            return "Bound Goblin";
          case 106:
            return "Bound Wizard";
          case 107:
            return "Goblin Tinkerer";
          case 108:
            return "Wizard";
          case 109:
            return "Clown";
          case 110:
            return "Skeleton Archer";
          case 111:
            return "Goblin Archer";
          case 112:
            return "Vile Spit";
          case 113:
          case 114:
            return "Wall of Flesh";
          case 115:
          case 116:
            return "The Hungry";
          case 117:
          case 118:
          case 119:
            return "Leech";
          case 120:
            return "Chaos Elemental";
          case 121:
            return "Slimer";
          case 122:
            return "Gastropod";
          case 123:
            return "Bound Mechanic";
          case 124:
            return "Mechanic";
          case 125:
            return "Retinazer";
          case 126:
            return "Spazmatism";
          case (int) sbyte.MaxValue:
            return "Skeletron Prime";
          case 128:
            return "Prime Cannon";
          case 129:
            return "Prime Saw";
          case 130:
            return "Prime Vice";
          case 131:
            return "Prime Laser";
          case 132:
            return "Zombie";
          case 133:
            return "Wandering Eye";
          case 134:
          case 135:
          case 136:
            return "The Destroyer";
          case 137:
            return "Illuminant Bat";
          case 138:
            return "Illuminant Slime";
          case 139:
            return "Probe";
          case 140:
            return "Possessed Armor";
          case 141:
            return "Toxic Sludge";
          case 142:
            return "Santa Claus";
          case 143:
            return "Snowman Gangsta";
          case 144:
            return "Mister Stabby";
          case 145:
            return "Snow Balla";
          case 147:
            return "Albino Antlion";
          case 148:
            return "Orca";
          case 149:
            return "Vampire Miner";
          case 150:
            return "Shadow Slime";
          case 151:
            return "Shadow Hammer";
          case 152:
            return "Shadow Mummy";
          case 153:
            return "Spectral Gastropod";
          case 154:
            return "Spectral Elemental";
          case 155:
            return "Spectral Mummy";
          case 156:
            return "Dragon Snatcher";
          case 157:
            return "Dragon Hornet";
          case 158:
            return "Dragon Skull";
          case 159:
          case 160:
          case 161:
          case 162:
          case 163:
          case 164:
            return "Arch Wyvern";
          case 165:
            return "Arch Demon";
          case 166:
            return "Ocram";
          case 167:
            return "Servant of Ocram";
          default:
            return "";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case -18:
          case -1:
            return "Schleimling";
          case -17:
            return "Riesenhornisse";
          case -16:
            return "Minihornisse";
          case -15:
            return "Mammutskelett";
          case -14:
            return "Großknochen";
          case -13:
            return "Kleinknochen";
          case -12:
            return "Maxifresser";
          case -11:
            return "Minifresser";
          case -10:
            return "Dschungelschleim";
          case -9:
            return "Gelber Schleim";
          case -8:
            return "Roter Schleim";
          case -7:
            return "Lila Schleim";
          case -6:
            return "Schwarzer Schleim";
          case -5:
            return "Schleimbaby";
          case -4:
            return "Pinky";
          case -3:
            return "Grüner Schleim";
          case -2:
            return "Flugschleimi";
          case 1:
            return "Blauer Schleim";
          case 2:
            return "Dämonenauge";
          case 3:
            return "Zombie";
          case 4:
            return "Auge von Cthulhu";
          case 5:
            return "Diener von Cthulhu";
          case 6:
            return "Seelenfresser";
          case 7:
          case 8:
          case 9:
            return "Verschlinger";
          case 10:
          case 11:
          case 12:
            return "Riesenwurm";
          case 13:
          case 14:
          case 15:
            return "Weltenfresser";
          case 16:
            return "Schleimmami";
          case 17:
            return "Händler";
          case 18:
            return "Krankenschwester";
          case 19:
            return "Waffenhändler";
          case 20:
            return "Dryade";
          case 21:
            return "Skelett";
          case 22:
            return "Fremdenführer";
          case 23:
            return "Meteorenkopf";
          case 24:
            return "Feuer-Imp";
          case 25:
            return "Flammenkugel";
          case 26:
            return "Goblin-Arbeiter";
          case 27:
            return "Goblin-Dieb";
          case 28:
            return "Goblin-Krieger";
          case 29:
            return "Goblin-Hexer";
          case 30:
            return "Chaoskugel";
          case 31:
            return "Wutknochen";
          case 32:
            return "Düstermagier";
          case 33:
            return "Wasserkugel";
          case 34:
            return "Fluchschädel";
          case 35:
          case 36:
            return "Skeletron";
          case 37:
            return "Greis";
          case 38:
            return "Sprengmeister";
          case 39:
          case 40:
          case 41:
            return "Knochenschlange";
          case 42:
            return "Hornisse";
          case 43:
            return "Menschenfresser";
          case 44:
            return "Untoter Minenarbeiter";
          case 45:
            return "Tim";
          case 46:
            return "Hase";
          case 47:
            return "Verderbnishase";
          case 48:
            return "Harpyie";
          case 49:
            return "Höhlenfledermaus";
          case 50:
            return "Schleimkönig";
          case 51:
            return "Dschungelfledermaus";
          case 52:
            return "Doktor Bones";
          case 53:
            return "Bräutigam";
          case 54:
            return "Schneider";
          case 55:
            return "Goldfisch";
          case 56:
            return "Schnapper";
          case 57:
            return "Verderbnisgoldfisch";
          case 58:
            return "Piranha";
          case 59:
            return "Lavaschleim";
          case 60:
            return "Höllenfledermaus";
          case 61:
            return "Geier";
          case 62:
            return "Dämon";
          case 63:
            return "Blauqualle";
          case 64:
            return "Pinkqualle";
          case 65:
            return "Hai";
          case 66:
            return "Voodoo-Dämon";
          case 67:
            return "Krabbe";
          case 68:
            return "Verlies-Wächter";
          case 69:
            return "Ameisenlöwe";
          case 70:
            return "Nagelball";
          case 71:
            return "Verliesschleim";
          case 72:
            return "Flammenrad";
          case 73:
            return "Goblin-Späher";
          case 74:
            return "Vogel";
          case 75:
            return "Pixie";
          case 77:
            return "Gepanzertes Skelett";
          case 78:
            return "Mumie";
          case 79:
            return "Dunkle Mumie";
          case 80:
            return "Helle Mumie";
          case 81:
            return "Verderbnisschleimi";
          case 82:
            return "Monstergeist";
          case 83:
            return "Verfluchter Hammer";
          case 84:
            return "Verzaubertes Schwert";
          case 85:
            return "Mimic";
          case 86:
            return "Einhorn";
          case 87:
          case 88:
          case 89:
          case 90:
          case 91:
          case 92:
            return "Lindwurm";
          case 93:
            return "Riesenfledermaus";
          case 94:
            return "Verderber";
          case 95:
          case 96:
          case 97:
            return "Gräber";
          case 98:
          case 99:
          case 100:
            return "Weltspeiser";
          case 101:
            return "Klette";
          case 102:
            return "Seeteufel";
          case 103:
            return "Grüne Qualle";
          case 104:
            return "Werwolf";
          case 105:
            return "Gebundener Goblin";
          case 106:
            return "Gebundener Zauberer";
          case 107:
            return "Goblin-Tüftler";
          case 108:
            return "Zauberer";
          case 109:
            return "Clown";
          case 110:
            return "Skelettbogenschütze";
          case 111:
            return "Goblin-Bogenschütze";
          case 112:
            return "Ekelspeichel";
          case 113:
          case 114:
            return "Fleischwand";
          case 115:
          case 116:
            return "Fressmaul";
          case 117:
          case 118:
          case 119:
            return "Blutegel";
          case 120:
            return "Chaos Elementar";
          case 121:
            return "Flugschleim";
          case 122:
            return "Bauchfüßler";
          case 123:
            return "Gebundene Mechanikerin";
          case 124:
            return "Mechanikerin";
          case 125:
            return "Retinazer";
          case 126:
            return "Spazmatism";
          case (int) sbyte.MaxValue:
            return "Skeletron Prime";
          case 128:
            return "Super-Kanone";
          case 129:
            return "Super-Säge";
          case 130:
            return "Super-Zange";
          case 131:
            return "Super-Laser";
          case 132:
            return "Zombie";
          case 133:
            return "Wanderndes Auge";
          case 134:
          case 135:
          case 136:
            return "Der Zerstörer";
          case 137:
            return "Leuchtfledermaus";
          case 138:
            return "Leuchtender Schleim";
          case 139:
            return "Sonde";
          case 140:
            return "Geisterrüstung";
          case 141:
            return "Giftiger Schlamm";
          case 142:
            return "Weihnachtsmann";
          case 143:
            return "Gangster Schneemann";
          case 144:
            return "Herr Stabby";
          case 145:
            return "Schnee Balla";
          case 147:
            return "Albino Ameisenlöwe";
          case 148:
            return "Orca";
          case 149:
            return "Vampire Miner";
          case 150:
            return "Schattenschleim";
          case 151:
            return "Schattenhammer";
          case 152:
            return "Schattenmumie";
          case 153:
            return "Gespenstischer Bauchfüßler";
          case 154:
            return "Spectral Elemental";
          case 155:
            return "Gespenstische Mumie";
          case 156:
            return "Drachen-Schnapper";
          case 157:
            return "Drachenhornisse";
          case 158:
            return "Drachenschädel";
          case 159:
          case 160:
          case 161:
          case 162:
          case 163:
          case 164:
            return "Erz-Lindwurm";
          case 165:
            return "Erz-Dämon";
          case 166:
            return "Ocram";
          case 167:
            return "Diener von Ocram";
          default:
            return "";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case -18:
          case -1:
            return "Slimeling";
          case -17:
            return "Vespa grande";
          case -16:
            return "Vespa piccola";
          case -15:
            return "Scheletro pesante";
          case -14:
            return "Disossato";
          case -13:
            return "Ossa corte";
          case -12:
            return "Grande mangiatore";
          case -11:
            return "Piccolo mangiatore";
          case -10:
            return "Slime della giungla";
          case -9:
            return "Slime giallo";
          case -8:
            return "Slime rosso";
          case -7:
            return "Slime viola";
          case -6:
            return "Slime nero";
          case -5:
            return "Slime baby";
          case -4:
            return "Mignolo";
          case -3:
            return "Slime verde";
          case -2:
            return "Slimer";
          case 1:
            return "Slime blu";
          case 2:
            return "Occhio del Demone";
          case 3:
            return "Zombie";
          case 4:
            return "Occhio di Cthulhu";
          case 5:
            return "Servo di Cthulhu";
          case 6:
            return "Mangiatore di anime";
          case 7:
          case 8:
          case 9:
            return "Divoratore";
          case 10:
          case 11:
          case 12:
            return "Verme gigante";
          case 13:
          case 14:
          case 15:
            return "Mangiatore di mondi";
          case 16:
            return "Slime madre";
          case 17:
            return "Mercante";
          case 18:
            return "Infermiera";
          case 19:
            return "Mercante di armi";
          case 20:
            return "Driade";
          case 21:
            return "Scheletro";
          case 22:
            return "Guida";
          case 23:
            return "Testa di meteorite";
          case 24:
            return "Diavoletto di fuoco";
          case 25:
            return "Sfera infuocata";
          case 26:
            return "Goblin operaio";
          case 27:
            return "Goblin ladro";
          case 28:
            return "Goblin guerriero";
          case 29:
            return "Goblin stregone";
          case 30:
            return "Palla del caos";
          case 31:
            return "Ossa arrabbiate";
          case 32:
            return "Lanciatore oscuro";
          case 33:
            return "Sfera d'acqua";
          case 34:
            return "Teschio maledetto";
          case 35:
          case 36:
            return "Skeletron";
          case 37:
            return "Vecchio";
          case 38:
            return "Esperto in demolizioni";
          case 39:
          case 40:
          case 41:
            return "Serpente di ossa";
          case 42:
            return "Calabrone";
          case 43:
            return "Mangiauomini";
          case 44:
            return "Minatore non-morto";
          case 45:
            return "Tim";
          case 46:
            return "Coniglio";
          case 47:
            return "Coniglio corrotto";
          case 48:
            return "Arpia";
          case 49:
            return "Pipistrello della caverna";
          case 50:
            return "Slime re";
          case 51:
            return "Pipistrello della giungla";
          case 52:
            return "Dottor ossa";
          case 53:
            return "Lo sposo";
          case 54:
            return "Mercante di abiti";
          case 55:
            return "Pesce rosso";
          case 56:
            return "Pianta afferratrice";
          case 57:
            return "Pesce rosso corrotto";
          case 58:
            return "Piranha";
          case 59:
            return "Slime di lava";
          case 60:
            return "Pipistrello dell'inferno";
          case 61:
            return "Avvoltoio";
          case 62:
            return "Demone";
          case 63:
            return "Medusa blu";
          case 64:
            return "Medusa rosa";
          case 65:
            return "Squalo";
          case 66:
            return "Demone voodoo";
          case 67:
            return "Granchio";
          case 68:
            return "Guardiano della Dungeon";
          case 69:
            return "Formicaleone";
          case 70:
            return "Sfera con spuntoni";
          case 71:
            return "Slime della Dungeon";
          case 72:
            return "Ruota ardente";
          case 73:
            return "Goblin ricognitore";
          case 74:
            return "Uccello";
          case 75:
            return "Folletto";
          case 76:
            return "";
          case 77:
            return "Scheletro corazzato";
          case 78:
            return "Mummia";
          case 79:
            return "Mummia oscura";
          case 80:
            return "Mummia chiara";
          case 81:
            return "Slime corrotto";
          case 82:
            return "Fantasma";
          case 83:
            return "Martello maledetto";
          case 84:
            return "Spada incantata";
          case 85:
            return "Sosia";
          case 86:
            return "Unicorno";
          case 87:
          case 88:
          case 89:
          case 90:
          case 91:
          case 92:
            return "Viverna";
          case 93:
            return "Pipistrello gigante";
          case 94:
            return "Corruttore";
          case 95:
          case 96:
          case 97:
            return "Scavatore";
          case 98:
          case 99:
          case 100:
            return "Alimentatore del mondo";
          case 101:
            return "Appiccicoso";
          case 102:
            return "Rana pescatrice";
          case 103:
            return "Medusa verde";
          case 104:
            return "Lupo mannaro";
          case 105:
            return "Goblin legato";
          case 106:
            return "Stregone legato";
          case 107:
            return "Goblin inventore";
          case 108:
            return "Stregone";
          case 109:
            return "Clown";
          case 110:
            return "Scheletro arciere";
          case 111:
            return "Goblin arciere";
          case 112:
            return "Bava disgustosa";
          case 113:
          case 114:
            return "Muro di carne";
          case 115:
          case 116:
            return "L'Affamato";
          case 117:
          case 118:
          case 119:
            return "Sanguisuga";
          case 120:
            return "Elementale del caos";
          case 121:
            return "Slimer";
          case 122:
            return "Gasteropodo";
          case 123:
            return "Meccanico legato";
          case 124:
            return "Meccanico";
          case 125:
            return "Retinazer";
          case 126:
            return "Spazmatism";
          case (int) sbyte.MaxValue:
            return "Skeletron primario";
          case 128:
            return "Cannone primario";
          case 129:
            return "Sega primaria";
          case 130:
            return "Morsa primaria";
          case 131:
            return "Laser primario";
          case 132:
            return "Zombie";
          case 133:
            return "Occhio errante";
          case 134:
          case 135:
          case 136:
            return "Il Distruttore";
          case 137:
            return "Pipistrello illuminante";
          case 138:
            return "Slime illuminante";
          case 139:
            return "Sonda";
          case 140:
            return "Armatura posseduta";
          case 141:
            return "Fango tossico";
          case 142:
            return "Babbo Natale";
          case 143:
            return "Pupazzo di neve Gangsta";
          case 144:
            return "Signor Stabby";
          case 145:
            return "Neve Balla";
          case 147:
            return "Formicaleone albino";
          case 148:
            return "Orca";
          case 149:
            return "Minatore vampiro";
          case 150:
            return "Slime ombra";
          case 151:
            return "Mummia ombra";
          case 152:
            return "Shadow Mummy";
          case 153:
            return "Gasteropode spettrale";
          case 154:
            return "Elementale spettrale";
          case 155:
            return "Mummia spettrale";
          case 156:
            return "Pianta afferratrice del Drago";
          case 157:
            return "Calabrone del Drago";
          case 158:
            return "Teschio del Drago";
          case 159:
          case 160:
          case 161:
          case 162:
          case 163:
          case 164:
            return "Arciviverna";
          case 165:
            return "Arcidiavolo";
          case 166:
            return "Ocram";
          case 167:
            return "Servo di Ocram";
          default:
            return "";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case -18:
          case -1:
            return "Slimeling";
          case -17:
            return "Gros frelon";
          case -16:
            return "Petit frelon";
          case -15:
            return "Squelette lourd";
          case -14:
            return "Grand squelette";
          case -13:
            return "Petit squelette";
          case -12:
            return "Grand dévoreur";
          case -11:
            return "Petit dévoreur";
          case -10:
            return "Slime de la jungle";
          case -9:
            return "Slime jaune";
          case -8:
            return "Slime rouge";
          case -7:
            return "Slime violet";
          case -6:
            return "Slime noir";
          case -5:
            return "Bébé slime";
          case -4:
            return "Pinky";
          case -3:
            return "Slime vert";
          case -2:
            return "Slimer";
          case 1:
            return "Slime bleu";
          case 2:
            return "Œil de démon";
          case 3:
            return "Zombie";
          case 4:
            return "Œil de Cthulhu";
          case 5:
            return "Servant de Cthulhu";
          case 6:
            return "Dévoreur d'âmes";
          case 7:
          case 8:
          case 9:
            return "Dévoreur";
          case 10:
          case 11:
          case 12:
            return "Ver géant";
          case 13:
          case 14:
          case 15:
            return "Dévoreur de mondes";
          case 16:
            return "Mère slime";
          case 17:
            return "Marchand";
          case 18:
            return "Infirmière";
          case 19:
            return "Marchand d'armes";
          case 20:
            return "Dryade";
          case 21:
            return "Squelette";
          case 22:
            return "Guide";
          case 23:
            return "Tête de météorite";
          case 24:
            return "Diablotin de feu";
          case 25:
            return "Sphère brûlante";
          case 26:
            return "Péon gobelin";
          case 27:
            return "Voleur gobelin";
          case 28:
            return "Guerrier gobelin";
          case 29:
            return "Sorcier gobelin";
          case 30:
            return "Boule de chaos";
          case 31:
            return "Squelette furieux";
          case 32:
            return "Magicien noir";
          case 33:
            return "Sphère d'eau";
          case 34:
            return "Crâne maudit";
          case 35:
            return "Squeletron";
          case 36:
            return "Squeletron";
          case 37:
            return "Vieil homme";
          case 38:
            return "Démolisseur";
          case 39:
          case 40:
          case 41:
            return "Serpent d'os";
          case 42:
            return "Frelon";
          case 43:
            return "Mangeur d'hommes";
          case 44:
            return "Mineur mort-vivant";
          case 45:
            return "Tim";
          case 46:
            return "Lapin";
          case 47:
            return "Lapin corrompu";
          case 48:
            return "Harpie";
          case 49:
            return "Chauve-souris";
          case 50:
            return "Roi slime";
          case 51:
            return "Chauve-souris de la jungle";
          case 52:
            return "Docteur Bones";
          case 53:
            return "Le jeune marié";
          case 54:
            return "Tailleur";
          case 55:
            return "Poisson rouge";
          case 56:
            return "Ravisseur";
          case 57:
            return "Poisson rouge corrompu";
          case 58:
            return "Piranha";
          case 59:
            return "Slime de l'enfer";
          case 60:
            return "Chauve-souris de l'enfer";
          case 61:
            return "Vautour";
          case 62:
            return "Démon";
          case 63:
            return "Méduse bleue";
          case 64:
            return "Méduse rose";
          case 65:
            return "Requin";
          case 66:
            return "Démon vaudou";
          case 67:
            return "Crabe";
          case 68:
            return "Gardien du donjon";
          case 69:
            return "Fourmilion";
          case 70:
            return "Boule piquante";
          case 71:
            return "Slime des donjons";
          case 72:
            return "Roue de feu";
          case 73:
            return "Scout gobelin";
          case 74:
            return "Oiseau";
          case 75:
            return "Lutin";
          case 76:
            return "";
          case 77:
            return "Squelette en armure";
          case 78:
            return "Momie";
          case 79:
            return "Momie de l'ombre";
          case 80:
            return "Momie de lumière";
          case 81:
            return "Slime corrompu";
          case 82:
            return "Spectre";
          case 83:
            return "Marteau maudit";
          case 84:
            return "Épée enchantée";
          case 85:
            return "Imitateur";
          case 86:
            return "Licorne";
          case 87:
          case 88:
          case 89:
          case 90:
          case 91:
          case 92:
            return "Wyverne";
          case 93:
            return "Chauve-souris géante";
          case 94:
            return "Corrupteur";
          case 95:
          case 96:
          case 97:
            return "Fouisseur";
          case 98:
          case 99:
          case 100:
            return "Nourricier";
          case 101:
            return "Accrocheur";
          case 102:
            return "Baudroie";
          case 103:
            return "Méduse verte";
          case 104:
            return "Loup-garou";
          case 105:
            return "Gobelin attaché";
          case 106:
            return "Magicien attaché";
          case 107:
            return "Gobelin bricoleur";
          case 108:
            return "Magicien";
          case 109:
            return "Clown";
          case 110:
            return "Archer squelette";
          case 111:
            return "Archer gobelin";
          case 112:
            return "Immonde crachat";
          case 113:
          case 114:
            return "Mur de chair";
          case 115:
          case 116:
            return "L'affamé";
          case 117:
          case 118:
          case 119:
            return "Sangsue";
          case 120:
            return "Élémentaire du chaos";
          case 121:
            return "Slimer";
          case 122:
            return "Gastropode";
          case 123:
            return "Mécanicienne attachée";
          case 124:
            return "Mécanicienne";
          case 125:
            return "Rétinazer";
          case 126:
            return "Spazmatisme";
          case (int) sbyte.MaxValue:
            return "Skeletron Prime";
          case 128:
            return "Canon primaire";
          case 129:
            return "Scie primaire";
          case 130:
            return "Étau principal";
          case 131:
            return "Laser principal";
          case 132:
            return "Zombie";
          case 133:
            return "Œil vagabond";
          case 134:
          case 135:
          case 136:
            return "Le destructeur";
          case 137:
            return "Chauve-souris illuminée";
          case 138:
            return "Slime illuminé";
          case 139:
            return "Sonde";
          case 140:
            return "Armure possédée";
          case 141:
            return "Boue toxique";
          case 142:
            return "Père Noël";
          case 143:
            return "Snowman Gangsta";
          case 144:
            return "Monsieur Stabby";
          case 145:
            return "Neige Balla";
          case 147:
            return "Fourmilion albinos";
          case 148:
            return "Orca";
          case 149:
            return "Mineur vampire";
          case 150:
            return "Slime de l'ombre";
          case 151:
            return "Marteau de l'ombre";
          case 152:
            return "Momie de l'ombre";
          case 153:
            return "Gastropode spectral";
          case 154:
            return "Élémentaire spectral";
          case 155:
            return "Momie spectrale";
          case 156:
            return "Dragon ravisseur";
          case 157:
            return "Frelon dragon";
          case 158:
            return "Crâne de dragon";
          case 159:
          case 160:
          case 161:
          case 162:
          case 163:
          case 164:
            return "Arche Wyvern";
          case 165:
            return "Arche démon";
          case 166:
            return "Ocram";
          case 167:
            return "Serviteur d'Ocram";
          default:
            return "";
        }
      }
      else
      {
        if (Lang.lang != 5)
          return (string) null;
        switch (l)
        {
          case -18:
          case -1:
            return "Slimeling";
          case -17:
            return "Gran avispa";
          case -16:
            return "Avispa pequeña";
          case -15:
            return "Esqueleto pesado";
          case -14:
            return "Gran huesitos";
          case -13:
            return "Pequeño huesitos";
          case -12:
            return "Gran devorador";
          case -11:
            return "Pequeño devorador";
          case -10:
            return "Slime selvático";
          case -9:
            return "Slime amarillo";
          case -8:
            return "Slime rojo";
          case -7:
            return "Slime morado";
          case -6:
            return "Slime negro";
          case -5:
            return "Bebé slime";
          case -4:
            return "Slime rosa";
          case -3:
            return "Slime verde";
          case -2:
            return "Slimer";
          case 1:
            return "Slime azul";
          case 2:
            return "Ojo demoníaco";
          case 3:
            return "Zombi";
          case 4:
            return "Ojo Cthulhu";
          case 5:
            return "Siervo de Cthulhu";
          case 6:
            return "Devoraalmas";
          case 7:
          case 8:
          case 9:
            return "Gusano devorador";
          case 10:
          case 11:
          case 12:
            return "Gusano gigante";
          case 13:
          case 14:
          case 15:
            return "Devoramundos";
          case 16:
            return "Mamá slime";
          case 17:
            return "Mercader";
          case 18:
            return "Enfermera";
          case 19:
            return "Traficante de armas";
          case 20:
            return "Dríada";
          case 21:
            return "Esqueleto";
          case 22:
            return "Guía";
          case 23:
            return "Cabeza meteorito";
          case 24:
            return "Diablillo de fuego";
          case 25:
            return "Esfera ardiente";
          case 26:
            return "Duende peón";
          case 27:
            return "Duende ladrón";
          case 28:
            return "Duende guerrero";
          case 29:
            return "Duende hechicero";
          case 30:
            return "Bola del caos";
          case 31:
            return "Huesitos furioso";
          case 32:
            return "Mago siniestro";
          case 33:
            return "Esfera de agua";
          case 34:
            return "Cráneo maldito";
          case 35:
            return "Esqueletrón";
          case 36:
            return "Esqueletrón";
          case 37:
            return "Anciano";
          case 38:
            return "Demoledor";
          case 39:
          case 40:
          case 41:
            return "Esqueleto de serpiente";
          case 42:
            return "Avispón";
          case 43:
            return "Devorahombres";
          case 44:
            return "Minero zombi";
          case 45:
            return "Tim";
          case 46:
            return "Conejito";
          case 47:
            return "Conejito corrompido";
          case 48:
            return "Arpía";
          case 49:
            return "Murciélago de cueva";
          case 50:
            return "Rey slime";
          case 51:
            return "Murciélago de selva";
          case 52:
            return "Doctor Látigo";
          case 53:
            return "El novio zombi";
          case 54:
            return "Buhonero";
          case 55:
            return "Pececillo";
          case 56:
            return "Atrapadora";
          case 57:
            return "Pececillo corrompido";
          case 58:
            return "Piraña";
          case 59:
            return "Babosa de lava";
          case 60:
            return "Murciélago infernal";
          case 61:
            return "Buitre";
          case 62:
            return "Demonio";
          case 63:
            return "Medusa azul";
          case 64:
            return "Medusa rosa";
          case 65:
            return "Tiburón";
          case 66:
            return "Demonio vudú";
          case 67:
            return "Cangrejo";
          case 68:
            return "Guardián de la mazmorra";
          case 69:
            return "Hormiga león";
          case 70:
            return "Bola de pinchos";
          case 71:
            return "Slime de las mazmorras";
          case 72:
            return "Rueda ardiente";
          case 73:
            return "Duende explorador";
          case 74:
            return "Pájaro";
          case 75:
            return "Duendecillo";
          case 77:
            return "Esqueleto con armadura";
          case 78:
            return "Momia";
          case 79:
            return "Momia de la oscuridad";
          case 80:
            return "Momia de la luz";
          case 81:
            return "Slime corrompido";
          case 82:
            return "Espectro";
          case 83:
            return "Martillo maldito";
          case 84:
            return "Espada encantada";
          case 85:
            return "Cofre falso";
          case 86:
            return "Unicornio";
          case 87:
          case 88:
          case 89:
          case 90:
          case 91:
          case 92:
            return "Guiverno";
          case 93:
            return "Murciélago gigante";
          case 94:
            return "Corruptor";
          case 95:
          case 96:
          case 97:
            return "Excavador";
          case 98:
          case 99:
          case 100:
            return "Tragamundos";
          case 101:
            return "Lapa";
          case 102:
            return "Pez abisal";
          case 103:
            return "Medusa verde";
          case 104:
            return "Hombre lobo";
          case 105:
            return "Duende cautivo";
          case 106:
            return "Mago cautivo";
          case 107:
            return "Duende chapucero";
          case 108:
            return "Mago";
          case 109:
            return "Payaso";
          case 110:
            return "Esqueleto arquero";
          case 111:
            return "Duende arquero";
          case 112:
            return "Escupitajo vil";
          case 113:
          case 114:
            return "Muro carnoso";
          case 115:
          case 116:
            return "El Famélico";
          case 117:
          case 118:
          case 119:
            return "Sanguijuela";
          case 120:
            return "Caos elemental";
          case 121:
            return "Slimer";
          case 122:
            return "Gasterópodo";
          case 123:
            return "Mecánico cautivo";
          case 124:
            return "Mecánico";
          case 125:
            return "Retinator";
          case 126:
            return "Espasmatizador";
          case (int) sbyte.MaxValue:
            return "Esqueletrón mayor";
          case 128:
            return "Cañón mayor";
          case 129:
            return "Sierra mayor";
          case 130:
            return "Torno mayor";
          case 131:
            return "Láser mayor";
          case 132:
            return "Zombi";
          case 133:
            return "Ojo errante";
          case 134:
          case 135:
          case 136:
            return "El Destructor";
          case 137:
            return "Murciélago luminoso";
          case 138:
            return "Slime luminoso";
          case 139:
            return "Sonda";
          case 140:
            return "Armadura poseída";
          case 141:
            return "Fango tóxico";
          case 142:
            return "Papá Noel";
          case 143:
            return "Muñeco de nieve malote";
          case 144:
            return "Señor Stabby";
          case 145:
            return "Triunfador de nieve";
          case 147:
            return "Hormiga león albina";
          case 148:
            return "Orca";
          case 149:
            return "Minero vampiro";
          case 150:
            return "Slime sombrío";
          case 151:
            return "Martillo sombrío";
          case 152:
            return "Momia sombría";
          case 153:
            return "Gasterópodo espectral";
          case 154:
            return "Elemental espectral";
          case 155:
            return "Momia espectral";
          case 156:
            return "Raptor de dragones";
          case 157:
            return "Avispa dragón";
          case 158:
            return "Calavera de dragón";
          case 159:
          case 160:
          case 161:
          case 162:
          case 163:
          case 164:
            return "Archiguiverno";
          case 165:
            return "Archidemonio";
          case 166:
            return "Ocram";
          case 167:
            return "Siervo de Ocram";
          default:
            return "";
        }
      }
    }

    public static string toolTip(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case 434:
            return "Three round burst";
          case 485:
            return "Turns the holder into a werewolf on full moons";
          case 486:
            return "Creates a grid on screen for block placement";
          case 489:
            return "15% increased magic damage";
          case 490:
            return "15% increased melee damage";
          case 491:
            return "15% increased ranged damage";
          case 492:
          case 493:
            return "Allows flight and slow fall";
          case 495:
            return "Casts a controllable rainbow";
          case 496:
            return "Summons a block of ice";
          case 497:
            return "Transforms the holder into merfolk when entering water";
          case 506:
            return "Uses gel for ammo";
          case 509:
            return "Places wire";
          case 510:
            return "Removes wire";
          case 515:
            return "Creates several crystal shards on impact";
          case 516:
            return "Summons falling stars on impact";
          case 517:
            return "A magical returning dagger";
          case 518:
            return "Summons rapid fire crystal shards";
          case 519:
            return "Summons unholy fire balls";
          case 520:
            return "'The essence of light creatures'";
          case 521:
            return "'The essence of dark creatures'";
          case 522:
            return "'Not even water can put the flame out'";
          case 523:
            return "Can be placed in water";
          case 524:
            return "Used to smelt adamantite ore";
          case 525:
            return "Used to craft items from mythril and adamantite bars";
          case 526:
            return "'Sharp and magical!'";
          case 527:
            return "'Sometimes carried by creatures in corrupt deserts'";
          case 528:
            return "'Sometimes carried by creatures in light deserts'";
          case 529:
            return "Activates when stepped on";
          case 531:
            return "Can be enchanted";
          case 532:
            return "Causes stars to fall when injured";
          case 533:
            return "50% chance to not consume ammo";
          case 534:
            return "Fires a spread of bullets";
          case 535:
            return "Reduces the cooldown of healing potions";
          case 536:
            return "Increases melee knockback";
          case 541:
          case 542:
          case 543:
            return "Activates when stepped on";
          case 544:
            return "Summons The Twins";
          case 547:
            return "'The essence of pure terror'";
          case 548:
            return "'The essence of the destroyer'";
          case 549:
            return "'The essence of omniscient watchers'";
          case 551:
            return "7% increased critical strike chance";
          case 552:
            return "7% increased damage";
          case 553:
            return "15% increased ranged damage";
          case 554:
            return "Increases length of invincibility after taking damage";
          case 555:
            return "8% reduced mana usage";
          case 556:
            return "Summons Destroyer";
          case 557:
            return "Summons Skeletron Prime";
          case 558:
            return "Increases maximum mana by 100";
          case 559:
            return "10% increased melee damage and critical strike chance";
          case 560:
            return "Summons King Slime";
          case 561:
            return "Stacks up to 5";
          case 575:
            return "'The essence of powerful flying creatures'";
          case 576:
            return "Has a chance to record songs";
          case 579:
            return "'Not to be confused with a hamsaw'";
          case 580:
            return "Explodes when activated";
          case 581:
            return "Sends water to outlet pumps";
          case 582:
            return "Receives water from inlet pumps";
          case 583:
            return "Activates every second";
          case 584:
            return "Activates every 3 seconds";
          case 585:
            return "Activates every 5 seconds";
          case 599:
          case 600:
          case 601:
            return "Press " + (object) '\x0081' + " to open";
          case 602:
            return "Summons the Frost Legion";
          case 603:
            return "Summons a pet guinea pig";
          case 604:
            return "15% increased melee damage and critical strike chance";
          case 605:
            return "15% increased ranged damage, 5% chance to not consume ammo";
          case 606:
            return "Increases maximum mana by 120";
          case 607:
            return "10% increased critical strike chance";
          case 608:
            return "5% increased ranged damage, 5% chance to not consume ammo";
          case 609:
            return "5% increased magical damage, 10% reduced mana use";
          case 610:
            return "12% increased movement speed";
          case 611:
            return "10% increased movement speed and ranged damage";
          case 612:
            return "10% increased movement speed and magical damage";
          case 613:
            return "Has a chance to cause bleeding";
          case 614:
            return "A legendary Japanese spear coated in venom";
          case 615:
            return "Transforms any suitable ammo into Spectral Arrows";
          case 617:
            return "Transforms any suitable ammo into Vulcan Bolts";
          case 619:
            return "Summons Ocram";
          case 620:
            return "'The essence of infected creatures'";
          case 621:
            return "Summons a pet slime";
          case 622:
            return "Summons a pet tiphia";
          case 623:
            return "Summons a pet bat";
          case 624:
            return "Summons a pet werewolf";
          case 625:
            return "Summons a pet zombie";
          case 357:
            return "Minor improvements to all stats";
          case 361:
            return "Summons a Goblin Army";
          case 363:
            return "Used for advanced wood crafting";
          case 367:
            return "Strong enough to destroy Demon Altars";
          case 371:
            return "Increases maximum mana by 40";
          case 372:
            return "7% increased movement speed";
          case 373:
            return "10% increased ranged damage";
          case 376:
            return "Increases maximum mana by 60";
          case 377:
            return "5% increased melee critical strike chance";
          case 378:
            return "12% increased ranged damage";
          case 385:
            return "Can mine Mythril";
          case 386:
            return "Can mine Adamantite";
          case 389:
            return "Has a chance to confuse";
          case 393:
            return "Shows horizontal position";
          case 394:
            return "Grants the ability to swim";
          case 395:
            return "Shows position";
          case 396:
            return "Negates fall damage";
          case 397:
            return "Grants immunity to knockback";
          case 398:
            return "Allows the combining of some accessories";
          case 399:
            return "Allows the holder to double jump";
          case 400:
            return "Increases maximum mana by 80";
          case 401:
            return "7% increased melee critical strike chance";
          case 402:
            return "14% increased ranged damage";
          case 403:
            return "6% increased damage";
          case 404:
            return "4% increased critical strike chance";
          case 405:
            return "Allows flight";
          case 407:
            return "Increases block placement range";
          case 422:
            return "Spreads the Hallow to some blocks";
          case 423:
            return "Spreads the corruption to some blocks";
          case 425:
            return "Summons a magical fairy";
          case 327:
            return "Opens one Gold Chest";
          case 329:
            return "Opens all Shadow Chests";
          case 332:
            return "Used for crafting cloth";
          case 352:
            return "Used for brewing ale";
          case 261:
            return "'It's smiling, might be a good snack'";
          case 266:
            return "'This is a good idea!'";
          case 267:
            return "'You are a terrible person.'";
          case 268:
            return "Greatly extends underwater breathing";
          case 272:
            return "Casts a demon scythe";
          case 281:
            return "Allows the collection of seeds for ammo";
          case 282:
            return "Works when wet";
          case 283:
            return "For use with Blowpipe";
          case 285:
            return "5% increased movement speed";
          case 288:
            return "Provides immunity to lava";
          case 289:
            return "Provides life regeneration";
          case 290:
            return "25% increased movement speed";
          case 291:
            return "Breathe water instead of air";
          case 292:
            return "Increase defense by 8";
          case 293:
            return "Increased mana regeneration";
          case 294:
            return "20% increased magic damage";
          case 295:
            return "Slows falling speed";
          case 296:
            return "Shows the location of treasure and ore";
          case 297:
            return "Grants invisibility";
          case 298:
            return "Emits an aura of light";
          case 299:
            return "Increases night vision";
          case 300:
            return "Increases enemy spawn rate";
          case 301:
            return "Attackers also take damage";
          case 302:
            return "Allows the ability to walk on water";
          case 303:
            return "20% increased arrow speed and damage";
          case 304:
            return "Shows the location of enemies";
          case 305:
            return "Allows the control of gravity";
          case 324:
            return "'Banned in most places'";
          case 222:
            return "Grows plants";
          case 223:
            return "6% reduced mana usage";
          case 228:
          case 229:
          case 230:
            return "Increases maximum mana by 20";
          case 235:
            return "'Tossing may be difficult.'";
          case 237:
            return "'Makes you look cool!'";
          case 238:
            return "15% increased magic damage";
          case 193:
            return "Grants immunity to fire blocks";
          case 197:
            return "Shoots fallen stars";
          case 208:
            return "'It's pretty, oh so pretty'";
          case 211:
            return "12% increased melee speed";
          case 212:
            return "10% increased movement speed";
          case 213:
            return "Creates grass on dirt";
          case 215:
            return "'May annoy others'";
          case 218:
            return "Summons a controllable ball of fire";
          case 175:
            return "'Hot to the touch'";
          case 186:
            return "'Because not drowning is kinda nice'";
          case 187:
            return "Grants the ability to swim";
          case 98:
            return "33% chance to not consume ammo";
          case 100:
          case 101:
          case 102:
            return "7% increased melee speed";
          case 103:
            return "Able to mine Hellstone";
          case 109:
            return "Permanently increases maximum mana by 20";
          case 111:
            return "Increases maximum mana by 20";
          case 112:
            return "Throws balls of fire";
          case 113:
            return "Casts a controllable missile";
          case 114:
            return "Magically moves dirt";
          case 115:
            return "Creates a magical orb of light";
          case 117:
            return "'Warm to the touch'";
          case 118:
            return "Sometimes dropped by Skeletons and Piranha";
          case 120:
            return "Lights wooden arrows ablaze";
          case 121:
            return "'It's made out of fire!'";
          case 123:
          case 124:
          case 125:
            return "5% increased magic damage";
          case 128:
            return "Allows flight";
          case 148:
            return "Holding this may attract unwanted attention";
          case 149:
            return "'It contains strange symbols'";
          case 151:
          case 152:
          case 153:
            return "4% increased ranged damage.";
          case 156:
            return "Grants immunity to knockback";
          case 157:
            return "Sprays out a shower of water";
          case 158:
            return "Negates fall damage";
          case 159:
            return "Increases jump height";
          case 165:
            return "Casts a slow moving bolt of water";
          case 166:
            return "A small explosion that will destroy some tiles";
          case 167:
            return "A large explosion that will destroy most tiles";
          case 168:
            return "A small explosion that will not destroy tiles";
          case 75:
            return "Disappears after the sunrise";
          case 84:
            return "'Get over here!'";
          case 88:
            return "Provides light when worn";
          case 43:
            return "Summons the Eye of Cthulhu";
          case 49:
            return "Slowly regenerates life";
          case 50:
            return "Gaze in the mirror to return home";
          case 53:
            return "Allows the holder to double jump";
          case 54:
            return "The wearer can run super fast";
          case 56:
          case 57:
            return "'Pulsing with dark energy'";
          case 64:
            return "Summons a vile thorn";
          case 65:
            return "Causes stars to rain from the sky";
          case 66:
            return "Cleanses the corruption";
          case 67:
            return "Removes the Hallow";
          case 68:
            return "'Looks tasty!'";
          case 70:
            return "Summons the Eater of Worlds";
          case 29:
            return "Permanently increases maximum life by 20";
          case 33:
            return "Used for smelting ore";
          case 35:
            return "Used to craft items from metal bars";
          case 36:
            return "Used for basic crafting";
          case -1:
            return "Can mine Meteorite";
          case 8:
            return "Provides light";
          case 15:
          case 16:
          case 17:
            return "Tells the time";
          case 18:
            return "Shows depth";
          case 23:
            return "'Both tasty and flammable'";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case 434:
            return "Dreifachschuss";
          case 485:
            return "Verwandelt den Inhaber bei Vollmond in einen Werwolf";
          case 486:
            return "Erstellt ein Raster auf dem Bildschirm zum Platzieren der Blöcke";
          case 489:
            return "Um 15% erhöhter magischer Schaden";
          case 490:
            return "Um 15% erhöhter Nahkampfschaden";
          case 491:
            return "Um 15% erhöhter Fernkampfschaden";
          case 492:
            return "Ermoeglicht Flug und langsamen Fall";
          case 493:
            return "Ermöglicht Flug und langsamen Fall";
          case 495:
            return "Wirft einen steuerbaren Regenbogen aus";
          case 496:
            return "Ruft einen Eisblock herbei";
          case 497:
            return "Verwandelt den Besitzer beim Hineingehen ins Wasser in Meermenschen";
          case 506:
            return "Verwendet Glibber als Munition";
          case 509:
            return "Platziert Kabel";
          case 510:
            return "Entfernt Kabel";
          case 515:
            return "Erzeugt beim Aufprall mehrere Kristallscherben";
          case 516:
            return "Ruft beim Aufprall Sternschnuppen herbei";
          case 517:
            return "Ein Dolch, der magisch zurückkehrt";
          case 518:
            return "Ruft schnelle Feuerkristallscherben herbei";
          case 519:
            return "Ruft unheilige Feuerbälle herbei";
          case 520:
            return "'Die Essenz von Lichtkreaturen'";
          case 521:
            return "'Die Essenz von Finsterkreaturen'";
          case 522:
            return "'Nicht einmal Wasser löscht diese Flamme'";
          case 523:
            return "Kann in Wasser platziert werden";
          case 524:
            return "Zum Schmelzen von Adamantiterz";
          case 525:
            return "Zur Herstellung von Items aus Mithril- und Adamantitbarren";
          case 526:
            return "'Scharf und magisch!'";
          case 527:
            return "'Kreaturen in verderbten Wüsten tragen sie mitunter'";
          case 528:
            return "'Werden mitunter von Kreaturen in Lichtwüsten getragen'";
          case 529:
            return "Wird beim Betreten aktiviert";
          case 531:
            return "Zum Zaubern";
          case 532:
            return "Lässt Sterne bei Verletzung herabfallen";
          case 533:
            return "50%ige Chance, keine Munition zu verbrauchen";
          case 534:
            return "Feuert einen Kugelregen ab";
          case 535:
            return "Verringert die Abklingzeit von Heiltränken";
          case 536:
            return "Erhöht Nahkampf-Rückstoss";
          case 541:
            return "Wird beim Betreten aktiviert";
          case 542:
            return "Wird beim Betreten aktiviert";
          case 543:
            return "Wird beim Betreten aktiviert";
          case 544:
            return "Ruft die Zwillinge herbei";
          case 547:
            return "'Die Essenz reinen Schreckens'";
          case 548:
            return "'Die Essenz des Zerstörers'";
          case 549:
            return "'Die Essenz der allwissenden Beobachter'";
          case 551:
            return "Um 7% erhöhte kritische Trefferchance";
          case 552:
            return "Um 7% erhöhter Schaden";
          case 553:
            return "Um 15% erhöhter Fernkampfschaden";
          case 554:
            return "Verlängert die Unbesiegbarkeit nach erlittenem Schaden";
          case 555:
            return "Um 8% reduzierte Mananutzung";
          case 556:
            return "Ruft den Zerstörer";
          case 557:
            return "Ruft Skeletron Prime herbei";
          case 558:
            return "Erhöht die maximale Mana um 100";
          case 559:
            return "Nahkampfschaden und kritische Trefferchance um 10% erhöht";
          case 560:
            return "Ruft Schleimkönig herbei";
          case 561:
            return "Kann bis zu 5 stapeln";
          case 575:
            return "'Essenz mächtiger fliegender Kreaturen'";
          case 576:
            return "Kann Songs aufzeichnen";
          case 579:
            return "'Nicht mit einer Hamsäge zu verwechseln'";
          case 580:
            return "Explodiert bei Aktivierung";
          case 581:
            return "Sendet Wasser zu Auslasspumpen";
          case 582:
            return "Empfängt Wasser von Einlasspumpen";
          case 583:
            return "Aktiviert jede Sekunde";
          case 584:
            return "Aktiviert alle 3 Sekunden";
          case 585:
            return "Aktiviert alle 5 Sekunden";
          case 599:
          case 600:
          case 601:
            return "Drücke " + (object) '\x0081' + " zum Öffnen";
          case 602:
            return "Beschwört die Frost Legion";
          case 603:
            return "Ruft ein Haustier-Meerschweinchen herbei";
          case 604:
            return "Nahkampfschaden und kritische Trefferchance um 15% erhöht";
          case 605:
            return "Um 15% erhöhter Fernkampf-Schaden, 5%ige Chance, keine Munition zu verbrauchen";
          case 606:
            return "Erhöht maximales Mana um 120";
          case 607:
            return "Kritische Trefferchance um 10% erhöht";
          case 608:
            return "Um 5% erhöhter Fernkampf-Schaden, 5%ige Chance, keine Munition zu verbrauchen";
          case 609:
            return "Um 5% erhöhter Magieschaden, um 10% reduzierte Mana-Nutzung";
          case 610:
            return "Um 10% erhöhtes Bewegungstempo";
          case 611:
            return "Um 10% erhöhtes Bewegungstempo und Fernkampf-Schaden";
          case 612:
            return "Um 10% erhöhtes Bewegungstempo und Magieschaden";
          case 613:
            return "Kann Blutungen verursachen";
          case 614:
            return "Ein legendärer japanischer Speer, der in Gift getaucht wurde";
          case 615:
            return "Verwandelt jede passende Munition in Spektralpfeile";
          case 617:
            return "Verwandelt jede passende Munition in Vulkanbolzen";
          case 619:
            return "Ruft Ocram herbei";
          case 620:
            return "'Die Essenz von infizierten Kreaturen'";
          case 621:
            return "Ruft einen Haustier-Schleim herbei";
          case 622:
            return "Ruft eine Haustier-Tiphia herbei";
          case 623:
            return "Ruft eine Haustier-Fledermaus herbei";
          case 624:
            return "Ruft einen Haustier-Werwolf herbei";
          case 625:
            return "Ruft einen Haustier-Zombie herbei";
          case 357:
            return "Geringe Anhebung aller Werte";
          case 361:
            return "Ruft eine Goblin-Armee herbei";
          case 363:
            return "Für fortgeschrittene Holzherstellung";
          case 367:
            return "Stark genug, um Dämonenaltäre zu zerstören";
          case 371:
            return "Erhöht die maximale Mana um 40";
          case 372:
            return "Um 7% erhöhtes Bewegungstempo";
          case 373:
            return "Um 10% erhöhter Fernkampfschaden";
          case 376:
            return "Erhöht die maximale Mana um 60";
          case 377:
            return "Um 5% erhöhte kritische Nahkampf-Trefferchance";
          case 378:
            return "Um 12% erhöhter Fernkampf-Schaden";
          case 385:
            return "Kann Mithril abbauen";
          case 386:
            return "Kann Adamantit abbauen";
          case 389:
            return "Kann Verwirrung stiften";
          case 393:
            return "Zeigt horizontale Position";
          case 394:
            return "Befähigt zum Schwimmen";
          case 395:
            return "Zeigt Position an";
          case 396:
            return "Hebt Sturzschaden auf";
          case 397:
            return "Macht immun gegen Rückstoß";
          case 398:
            return "Ermöglicht die Kombination von Zubehör";
          case 399:
            return "Berechtigt den Inhaber zum Doppelsprung";
          case 400:
            return "Erhöht die maximale Mana um 80";
          case 401:
            return "Um 7% erhöhte kritische Nahkampf-Trefferchance";
          case 402:
            return "Um 14% erhöhter Fernkampfschaden";
          case 403:
            return "Um 6% erhöhter Schaden";
          case 404:
            return "Um 4% erhöhte kritische Trefferchance";
          case 405:
            return "Lässt fliegen";
          case 407:
            return "Erweitert den Platzierbereich von Blöcken";
          case 422:
            return "Verspritzt Heil auf einige Blöcke";
          case 423:
            return "Verteilt Verderben auf einige Blöcke";
          case 425:
            return "Ruft eine magische Fee herbei";
          case 327:
            return "Öffnet eine Goldtruhe";
          case 329:
            return "Öffnet alle Schattentruhen";
          case 332:
            return "Verwendet für die Herstellung von Kleidung";
          case 352:
            return "Zum Bierbrauen";
          case 261:
            return "'Er lächelt - vielleicht schmeckt er auch gut...'";
          case 266:
            return "'Das ist eine gute Idee!'";
          case 267:
            return "'Du bist ein schrecklicher Mensch.'";
          case 268:
            return "Verleiht deutlich mehr Atemluft unter Wasser";
          case 272:
            return "Wirft eine Dämonensense aus";
          case 281:
            return "Zum Erstellen einer Saatsammlung als Munition";
          case 282:
            return "Funktioniert bei Naesse";
          case 283:
            return "Zur Verwendung im Blasrohr";
          case 285:
            return "Um 5% erhöhtes Bewegungstempo";
          case 288:
            return "Macht immun gegen Lava";
          case 289:
            return "Belebt wieder";
          case 290:
            return "Erhöht Bewegungstempo um 25%";
          case 291:
            return "Wasser statt Luft atmen";
          case 292:
            return "Erhöht die Abwehr um 8";
          case 293:
            return "Erhöhte Mana-Wiederherstellung";
          case 294:
            return "Erhöht magischen Schaden um 20%";
          case 295:
            return "Verlangsamt das Sturztempo";
          case 296:
            return "Zeigt den Fundort von Schätzen und Erz";
          case 297:
            return "Macht unsichtbar";
          case 298:
            return "Verströmt eine Aura aus Licht";
          case 299:
            return "Erhöht die Nachtsicht";
          case 300:
            return "Erhöht Feind-Spawnquote";
          case 301:
            return "Auch die Angreifer erleiden Schaden";
          case 302:
            return "Befähigt, auf dem Wasser zu gehen";
          case 303:
            return "Erhöht Pfeiltempo und Schaden um 20%";
          case 304:
            return "Zeigt die Position von Feinden";
          case 305:
            return "Zur Steuerung der Schwerkraft";
          case 324:
            return "'An den meisten Orten verboten'";
          case 222:
            return "Lässt Pflanzen wachsen";
          case 223:
            return "Um 6% reduzierte Mana-Nutzung";
          case 228:
            return "Erhoeht die maximale Mana um 20";
          case 229:
            return "Erhoeht die maximale Mana um 20";
          case 230:
            return "Erhöht die maximale Mana um 20";
          case 235:
            return "'Werfen könnte schwierig werden.'";
          case 237:
            return "'Damit siehst du cool aus!'";
          case 238:
            return "Um 15% erhöhter magischer Schaden";
          case 193:
            return "Macht immun gegen Feuer-Blöcke";
          case 197:
            return "Schießt Sternschnuppen herunter";
          case 208:
            return "'Oh, ist das hübsch!'";
          case 211:
            return "Um 12% erhöhtes Nahkampftempo";
          case 212:
            return "Um 10% erhöhtes Bewegungstempo";
          case 213:
            return "Lässt Gras auf Schmutz wachsen";
          case 215:
            return "'Kann Ärger erregen'";
          case 218:
            return "Ruft einen steuerbaren Feuerball herbei";
          case 175:
            return "'Heiß, heiß, heiß!'";
          case 186:
            return "'Ganz nett, nicht ertrinken zu müssen'";
          case 187:
            return "Befähigt zum Schwimmen";
          case 98:
            return "33%ige Chance, keine Munition zu verbrauchen";
          case 100:
            return "Um 7% erhoehtes Nahkampftempo";
          case 101:
            return "Um 7% erhoehtes Nahkampftempo";
          case 102:
            return "Um 7% erhoehtes Nahkampftempo";
          case 103:
            return "Kann Höllenstein abbauen";
          case 109:
            return "Erhöht maximales Mana um 20";
          case 111:
            return "Erhöht die maximale Mana um 20";
          case 112:
            return "Schießt Feuerbälle ab";
          case 113:
            return "Wirft eine steuerbare Rakete aus";
          case 114:
            return "Bewegt magisch Dreck";
          case 115:
            return "Erschafft eine magische Lichtkugel";
          case 117:
            return "'Fühlt sich warm an'";
          case 118:
            return "Fällt mitunter von Skeletten und Piranhas herab";
          case 120:
            return "Entfacht lodernde Holzpfeile";
          case 121:
            return "'Ist ganz aus Feuer!'";
          case 123:
            return "Um 5% erhoehter magischer Schaden";
          case 124:
            return "Um 5% erhoehter magischer Schaden";
          case 125:
            return "Um 5% erhöhter magischer Schaden";
          case 128:
            return "Lässt fliegen";
          case 148:
            return "Kann unerwünschte Aufmerksamkeit erwecken";
          case 149:
            return "'Es enthält seltsame Symbole'";
          case 151:
            return "Um 4% erhöhter Fernkampf-Schaden";
          case 152:
            return "Um 4% erhöhter Fernkampf-Schaden";
          case 153:
            return "Um 4% erhöhter Fernkampf-Schaden";
          case 156:
            return "Macht immun gegen Rückstoß";
          case 157:
            return "Versprüht eine Wasserdusche";
          case 158:
            return "Hebt Sturzschaden auf";
          case 159:
            return "Vergrößert die Sprunghöhe";
          case 165:
            return "Wirft einen sich langsam bewegenden Wasserbolzen aus";
          case 166:
            return "Eine kleine Explosion, die einige Felder zerstören wird";
          case 167:
            return "Eine große Explosion, die die meisten Felder zerstört";
          case 168:
            return "Eine kleine Explosion, die keine Felder zerstört";
          case 75:
            return "Verschwindet nach Sonnenaufgang";
          case 84:
            return "'Komm hier rüber!'";
          case 88:
            return "Verströmt beim Tragen Licht";
          case 43:
            return "Ruft das Auge von Cthulhu herbei";
          case 49:
            return "Belebt langsam wieder";
          case 50:
            return "Ein Blick in den Spiegel bringt einen zurück nach Hause";
          case 53:
            return "Berechtigt den Inhaber zum Doppelsprung";
          case 54:
            return "Der Träger kann superschnell rennen";
          case 56:
            return "'Durchpulst von dunkler Energie'";
          case 57:
            return "'Durchpulst von dunkler Energie'";
          case 64:
            return "Ruft einen Ekeldorn herbei";
          case 65:
            return "Lässt Sterne vom Himmel regnen";
          case 66:
            return "Reinigt das Verderben";
          case 67:
            return "Entfernt das Heilige";
          case 68:
            return "'Sieht lecker aus!'";
          case 70:
            return "Ruft den Weltenfresser herbei";
          case 29:
            return "Erhöht dauerhaft die maximale Lebensspanne um 20";
          case 33:
            return "Wird für die Verhüttung von Erz verwendet";
          case 35:
            return "Wird verwendet, um Items aus Metallbarren herzustellen";
          case 36:
            return "Wird zur einfachen Herstellung verwendet";
          case -1:
            return "Kann Meteorite abbauen";
          case 8:
            return "Verströmt Licht";
          case 15:
            return "Zeigt die Zeit an";
          case 16:
            return "Zeigt die Zeit an";
          case 17:
            return "Zeigt die Zeit an";
          case 18:
            return "Zeigt die Tiefe an";
          case 23:
            return "'Lecker und brennbar'";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case 434:
            return "Tre raffiche";
          case 485:
            return "Durante la luna piena trasforma il portatore in un lupo mannaro";
          case 486:
            return "Crea una griglia sullo schermo per posizionare i blocchi";
          case 489:
            return "Danno magico aumentato del 15%";
          case 490:
            return "Danno da mischia aumentato del 15%";
          case 491:
            return "Danno boomerang aumentato del 15%";
          case 492:
            return "Permettono il volo e la caduta lenta";
          case 493:
            return "Permettono il volo e la caduta lenta";
          case 495:
            return "Genera un arcobaleno guidato";
          case 496:
            return "Evoca un blocco di ghiaccio";
          case 497:
            return "Trasforma il portatore in Tritone quando entra in acqua";
          case 506:
            return "Utilizza la gelatina come munizione";
          case 509:
            return "Posiziona i cavi";
          case 510:
            return "Rimuove i cavi";
          case 515:
            return "Crea svariati frammenti di cristallo all'impatto";
          case 516:
            return "Evoca stelle cadenti all'impatto";
          case 517:
            return "Un pugnale magico che ritorna";
          case 518:
            return "Evoca veloci frammenti di cristallo infuocati";
          case 519:
            return "Evoca sfere di fuoco profane";
          case 520:
            return "'L'essenza delle creature della luce'";
          case 521:
            return "'L'essenza delle creature oscure'";
          case 522:
            return "'Neanche l'acqua può spegnere la fiamma'";
          case 523:
            return "Può essere messa in acqua";
          case 524:
            return "Utilizzata per fondere il minerale adamantio";
          case 525:
            return "Utilizzata per creare oggetti da barre di mitrilio e adamantio";
          case 526:
            return "'Appuntito e magico!'";
          case 527:
            return "'A volte portato dalle creature nei deserti corrotti'";
          case 528:
            return "'A volte portato dalle creature nei deserti di luce'";
          case 529:
            return "Si attiva quando calpestata";
          case 531:
            return "Può essere incantato";
          case 532:
            return "Causa la caduta delle stelle quando colpito";
          case 533:
            return "50% di possibilità di non consumare munizioni";
          case 534:
            return "Spara una rosa di proiettili";
          case 535:
            return "Riduce la ricarica della pozione curativa";
          case 536:
            return "Aumenta lo spintone nel corpo a corpo";
          case 541:
            return "Si attiva quando calpestata";
          case 542:
            return "Si attiva quando calpestata";
          case 543:
            return "Si attiva quando calpestata";
          case 544:
            return "Evoca i Gemelli";
          case 547:
            return "'L'essenza del terrore puro'";
          case 548:
            return "'L'essenza del distruttore'";
          case 549:
            return "'L'essenza degli osservatori onniscienti'";
          case 551:
            return "Possibilità di colpo critico aumentata del 7%";
          case 552:
            return "Danno aumentato del 7%";
          case 553:
            return "Danno boomerang aumentato del 15%";
          case 554:
            return "Aumenta la durata dell'invincibilità dopo aver subito danni";
          case 555:
            return "Consumo mana ridotto del 8%";
          case 556:
            return "Evoca il Distruttore";
          case 557:
            return "Evoca lo Skeletron primario";
          case 558:
            return "Aumenta il mana massimo di 100";
          case 559:
            return "Possibilità di danno da mischia critico aumentate del 10%";
          case 560:
            return "Evoca lo Slime re";
          case 561:
            return "Raccoglie fino a 5";
          case 575:
            return "'L'essenza delle potenti creature volanti'";
          case 576:
            return "Ha una possibilità di registrare canzoni";
          case 579:
            return "'Da non confondere con il Segartello'";
          case 580:
            return "Esplodono quando attivati";
          case 581:
            return "Invia acqua alle pompe esterne";
          case 582:
            return "Riceve acqua dalle pompe interne";
          case 583:
            return "Si attiva ogni secondo";
          case 584:
            return "Si attiva ogni 3 secondi";
          case 585:
            return "Si attiva ogni 5 secondi";
          case 599:
          case 600:
          case 601:
            return "Premi " + (object) '\x0081' + " per aprire";
          case 602:
            return "Evoca la Legione gelo";
          case 603:
            return "Evoca un porcellino d'India ";
          case 604:
            return "Danno da mischia e possibilità di colpo critico aumentati del 15%";
          case 605:
            return "Danno boomerang aumentato del 15%, 5% di possibilità di non consumare munizioni";
          case 606:
            return "Aumenta il mana massimo di 120";
          case 607:
            return "Possibilità di colpo critico aumentata del 10%";
          case 608:
            return "Danno boomerang aumentato del 5%, 5% di possibilità di non consumare munizioni";
          case 609:
            return "Danno magico aumentato del 5%, consumo del mana ridotto del 10%";
          case 610:
            return "Velocità di movimento aumentata del 12%";
          case 611:
            return "Velocità di movimento e danno boomerang aumentati del 10%";
          case 612:
            return "Velocità di movimento e danno magico aumentati del 10%";
          case 613:
            return "Ha la possibilità di provocare un sanguinamento";
          case 614:
            return "Una leggendaria lancia giapponese ricoperta di veleno";
          case 615:
            return "Trasforma qualsiasi munizione adatta in Frecce spettrali";
          case 617:
            return "Trasforma qualsiasi munizione adatta in Balestre vulcaniche";
          case 619:
            return "Evoca Ocram";
          case 620:
            return "'L'essenza delle creature contaminate'";
          case 621:
            return "Evoca uno slime";
          case 622:
            return "Evoca una vespa";
          case 623:
            return "Evoca un pipistrello";
          case 624:
            return "Evoca un lupo mannaro";
          case 625:
            return "Evoca uno zombie";
          case 357:
            return "Migliorie minori a tutti i parametri";
          case 361:
            return "Evoca un Esercito dei Goblin";
          case 363:
            return "Utilizzata per una lavorazione del legno avanzata";
          case 367:
            return "Abbastanza forte per distruggere gli Altari dei demoni";
          case 371:
            return "Aumenta il mana massimo di 40";
          case 372:
            return "Velocità di movimento aumentata del 7%";
          case 373:
            return "Danno boomerang aumentato del 10%";
          case 376:
            return "Aumenta il mana massimo di 60";
          case 377:
            return "Possibilità di colpo critico nel corpo a corpo aumentata del 5%";
          case 378:
            return "Danno boomerang aumentato del 12%";
          case 385:
            return "Può estrarre Mitrilio";
          case 386:
            return "Può estrarre Adamantio";
          case 389:
            return "Può confondere";
          case 393:
            return "Mostra posizione orizzontale";
          case 394:
            return "Abilita al nuoto";
          case 395:
            return "Mostra posizione";
          case 396:
            return "Annulla i danni da caduta";
          case 397:
            return "Permette immunità allo spintone";
          case 398:
            return "Permette la combinazione di alcuni accessori";
          case 399:
            return "Permette il salto doppio";
          case 400:
            return "Aumenta il mana massimo di 80";
          case 401:
            return "Possibilità di colpo critico nel corpo a corpo aumentata del 7%";
          case 402:
            return "Danno boomerang aumentato del 14%";
          case 403:
            return "Danno aumentato del 6%";
          case 404:
            return "Possibilità di colpo critico aumetata del 4%";
          case 405:
            return "Permettono di volare";
          case 407:
            return "Aumenta la possibilità di posizionamento dei blocchi";
          case 422:
            return "Spruzza acquasanta su alcuni blocchi";
          case 423:
            return "Diffonde la corruzione su alcuni blocchi";
          case 425:
            return "Evoca una fata magica";
          case 327:
            return "Apre una Cassa d'oro";
          case 329:
            return "Apre tutte le Casse ombra";
          case 332:
            return "Utilizzato per creare abiti";
          case 352:
            return "Utilizzato per produrre birra";
          case 261:
            return "'Sta ridendo, potrebbe essere uno spuntino appetitoso'";
          case 266:
            return "'Buona idea!'";
          case 267:
            return "'Sei una persona terribile.'";
          case 268:
            return "Aumenta moltissimo il respiro sott'acqua";
          case 272:
            return "Evoca una falce demoniaca";
          case 281:
            return "Permette la raccolta di semi come munizioni";
          case 282:
            return "Funziona da bagnato";
          case 283:
            return "Da utilizzare con la Cerbottana";
          case 285:
            return "Velocità di movimento aumentata del 5%";
          case 288:
            return "Fornisce immunità alla lava";
          case 289:
            return "Rigenera la vita";
          case 290:
            return "Velocità di movimento aumentata del 25%";
          case 291:
            return "Respira acqua invece di aria";
          case 292:
            return "Aumenta la difesa di 8";
          case 293:
            return "Aumenta la rigenerazione del mana";
          case 294:
            return "Danno magico aumentato del 20%";
          case 295:
            return "Velocità di caduta lenta";
          case 296:
            return "Mostra l'ubicazione di tesori e dei minerali";
          case 297:
            return "Rende invisibili";
          case 298:
            return "Emette un'aura di luce";
          case 299:
            return "Migliora la visione notturna";
          case 300:
            return "Aumenta il ritmo di generazone dei nemici";
          case 301:
            return "Anche gli aggressori subiscono danni";
          case 302:
            return "Consente di camminare sull'acqua";
          case 303:
            return "Velocità e danni della freccia aumentati del 20%";
          case 304:
            return "Mostra la posizione dei nemici";
          case 305:
            return "Permette il controllo della gravità";
          case 324:
            return "'Bandita in molti luoghi'";
          case 222:
            return "Fa crescere le piante";
          case 223:
            return "Consumo mana ridotto del 6%";
          case 228:
            return "Aumenta il mana massimo di 20";
          case 229:
            return "Aumenta il mana massimo di 20";
          case 230:
            return "Aumenta il mana massimo di 20";
          case 235:
            return "'Lanciare potrebbe essere difficile.'";
          case 237:
            return "'Migliora il tuo look!'";
          case 238:
            return "Danno magico aumentato del 15%";
          case 193:
            return "Permette immunità ai blocchi di fuoco";
          case 197:
            return "Spara stelle cadenti";
          case 208:
            return "'Graziosa, oh com'è graziosa'";
          case 211:
            return "Velocità del corpo a corpo aumentata del 12%";
          case 212:
            return "Velocità di movimento aumentata del 10%";
          case 213:
            return "Crea erba dalla terra";
          case 215:
            return "'Può disturbare gli altri'";
          case 218:
            return "Evoca una palla di fuoco guidata";
          case 175:
            return "'Calda al tocco'";
          case 186:
            return "'Perché non annegare è alquanto piacevole'";
          case 187:
            return "Abilita al nuoto";
          case 98:
            return "33% di possibilità di non consumare munizioni";
          case 100:
            return "Velocità del corpo a corpo aumentata del 7%";
          case 101:
            return "Velocità del corpo a corpo aumentata del 7%";
          case 102:
            return "Velocità del corpo a corpo aumentata del 7%";
          case 103:
            return "In grado di estrarre la pietra infernale";
          case 109:
            return "Aumenta in maniera permanente il mana massimo di 20";
          case 111:
            return "Aumenta il mana massimo di 20";
          case 112:
            return "Tira palle di fuoco";
          case 113:
            return "Scaglia un missile guidato";
          case 114:
            return "Muovi magicamente la terra";
          case 115:
            return "Crea una sfera di luce magica";
          case 117:
            return "'Calda al tocco'";
          case 118:
            return "Lanciato a volte da Scheletri e Piranha";
          case 120:
            return "Incendia le frecce di legno";
          case 121:
            return "'Creato dal fuoco!'";
          case 123:
            return "Danno magico aumentato del 5%";
          case 124:
            return "Danno magico aumentato del 5%";
          case 125:
            return "Danno magico aumentato del 5%";
          case 128:
            return "Permettono di volare";
          case 148:
            return "Avere questo oggetto potrebbe attirare attenzione non desiderata";
          case 149:
            return "'Contiene simboli strani'";
          case 151:
            return "Danno boomerang aumentato del 4%";
          case 152:
            return "Danno boomerang aumentato del 4%";
          case 153:
            return "Danno boomerang aumentato del 4%";
          case 156:
            return "Permette immunità allo spintone";
          case 157:
            return "Spruzza una cascata d'acqua";
          case 158:
            return "Annulla i danni da caduta";
          case 159:
            return "Aumenta l'altezza del salto";
          case 165:
            return "Lancia un dardo di acqua lento";
          case 166:
            return "Una piccola esplosione che distruggerà alcune mattonelle";
          case 167:
            return "Una grande esplosione che distruggerà molte mattonelle";
          case 168:
            return "Una piccola esplosione che non distruggerà mattonelle";
          case 75:
            return "Sparisce dopo l'alba";
          case 84:
            return "'Vieni qui!'";
          case 88:
            return "Fa luce una volta indossato";
          case 43:
            return "Evoca l'Occhio di Cthulhu";
          case 49:
            return "Rigenera la vita lentamente";
          case 50:
            return "Guarda nello specchio per tornare a casa";
          case 53:
            return "Permette il salto doppio";
          case 54:
            return "Colui che li indossa può correre velocissimo";
          case 56:
            return "'Pulsa di energia oscura'";
          case 57:
            return "'Pulsa di energia oscura'";
          case 64:
            return "Evoca una spina vile";
          case 65:
            return "Fa piovere le stelle dal cielo";
          case 66:
            return "Ripulisce la corruzione";
          case 67:
            return "Rimuove il consacrato";
          case 68:
            return "'Gustoso!'";
          case 70:
            return "Evoca il Mangiatore di Mondi";
          case 29:
            return "Aumenta in maniera permanente la vita massima di 20";
          case 33:
            return "Utilizzato per fondere i minerali";
          case 35:
            return "Utilizzato per creare oggetti dalle barre di metallo";
          case 36:
            return "Utilizzato per la creazione di base";
          case -1:
            return "Può estrarre meteorite";
          case 8:
            return "Fornisce luce";
          case 15:
            return "Indica il tempo";
          case 16:
            return "Indica il tempo";
          case 17:
            return "Indica il tempo";
          case 18:
            return "Mostra la profondità";
          case 23:
            return "'Sia gustoso che infiammabile'";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case 434:
            return "Tire des rafales de trois coups";
          case 485:
            return "Transforme le porteur en loup-garou à la pleine lune";
          case 486:
            return "Crée une grille à l'écran pour le placement des blocs";
          case 489:
            return "Dégâts magiques augmentés de 15 %";
          case 490:
            return "Dégâts de mêlée augmentés de 15 %";
          case 491:
            return "Dégâts à distance augmentés de 15 %";
          case 492:
            return "Permet de voler et de ralentir la chute";
          case 493:
            return "Permet de voler et de ralentir la chute";
          case 495:
            return "Lance un arc-en-ciel contrôlable";
          case 496:
            return "Invoque un bloc de glace";
          case 497:
            return "Transforme le porteur en sirène lorsqu'il entre dans l'eau";
          case 506:
            return "Utilise du gel comme carburant";
          case 509:
            return "Joint les câbles";
          case 510:
            return "Coupe les câbles";
          case 515:
            return "Crée plusieurs éclats de cristal à l'impact";
          case 516:
            return "Invoque des étoiles déchues à l'impact";
          case 517:
            return "Une dague qui revient magiquement à son possesseur";
          case 518:
            return "Invoque des éclats rapides de cristal de feu";
          case 519:
            return "Invoque des boules de feu maudites";
          case 520:
            return "« L'essence des créatures de lumière »";
          case 521:
            return "« L'essence des créatures sombres »";
          case 522:
            return "« Même l'eau ne peut l'éteindre »";
          case 523:
            return "Peut être placée dans l'eau";
          case 524:
            return "Utilisée pour fondre le minerai d'adamantine";
          case 525:
            return "Utilisée pour forger des objets avec du mythril et de l'adamantite";
          case 526:
            return "« Magique et coupante »";
          case 527:
            return "« Porté parfois par les créatures dans le désert corrompu »";
          case 528:
            return "« Porté parfois par les créatures dans le désert de lumière »";
          case 529:
            return "S'active en marchant dessus";
          case 531:
            return "Peut être enchanté";
          case 532:
            return "Des étoiles tombent lorsque le porteur est blessé";
          case 533:
            return "50 % de chance de n'utiliser aucune munition";
          case 534:
            return "Disperse une salve de balles";
          case 535:
            return "Réduit le temps d'utilisation entre les potions de soin";
          case 536:
            return "Accroît le recul en mêlée";
          case 541:
            return "S'active en marchant dessus";
          case 542:
            return "S'active en marchant dessus";
          case 543:
            return "S'active en marchant dessus";
          case 544:
            return "Invoque les Jumeaux";
          case 547:
            return "« L'essence de la terreur pure »";
          case 548:
            return "« L'essence du destructeur »";
          case 549:
            return "« L'essence des observateurs omniscients »";
          case 551:
            return "Chance de coup critique augmentée de 7 %";
          case 552:
            return "Dégâts augmentés de 7 %";
          case 553:
            return "Dégâts à distance augmentés de 15 %";
          case 554:
            return "Augmente la durée d'invincibilité après avoir subi des dégâts";
          case 555:
            return "Utilisation de mana réduite de 8 %";
          case 556:
            return "Invoque le destructeur";
          case 557:
            return "Invoque le Skeletron Prime";
          case 558:
            return "Augmente le maximum de mana de 100";
          case 559:
            return "Chance de coup critique et dégâts de mêlée augmentés de 10 %";
          case 560:
            return "Invoque le roi slime";
          case 561:
            return "Possibilité d'en empiler jusqu'à 5";
          case 575:
            return "« L'essence des puissantes créatures volantes »";
          case 576:
            return "A une chance d'enregistrer un morceau";
          case 579:
            return "« À ne pas confondre avec le marteau-scie »";
          case 580:
            return "Explosent lorsqu'ils sont activés";
          case 581:
            return "Envoie de l'eau aux sorties de pompage";
          case 582:
            return "Reçoit de l'eau des postes de pompage";
          case 583:
            return "S'active chaque seconde";
          case 584:
            return "S'active toutes les 3 secondes";
          case 585:
            return "S'active toutes les 5 secondes";
          case 599:
          case 600:
          case 601:
            return "Appuyez sur" + (object) '\x0081' + "pour ouvrir";
          case 602:
            return "Invoque la Légion gel";
          case 603:
            return "Invoque un cochon d'Inde de compagnie";
          case 604:
            return "Dégâts de mêlée et chance de coup critique, augmentés de 15 %";
          case 605:
            return "Dégâts à distance augmentés de 15 %, 5 % de chance de n'utiliser aucune munition";
          case 606:
            return "Maximum de mana augmenté de 120";
          case 607:
            return "Chance de coup critique augmentée de 10 %";
          case 608:
            return "Dégâts à distance augmentés de 5 %, 5 % de chance de n'utiliser aucune munition";
          case 609:
            return "Dégâts magiques augmentés de 5 %, utilisation du mana réduite de 10 %";
          case 610:
            return "Vitesse de déplacement augmentée de 12 %";
          case 611:
            return "Vitesse de déplacement et dégâts à distance augmentés de 10 %";
          case 612:
            return "Vitesse de déplacement et dégâts magiques augmentés de 10 %";
          case 613:
            return "A une chance de provoquer des saignements";
          case 614:
            return "Une lance japonaise légendaire couverte de venin";
          case 615:
            return "Transforme toute munition appropriée en flèches spectrales";
          case 617:
            return "Transforme toute munition appropriée en traits de Vulcain";
          case 619:
            return "Invoque Ocram";
          case 620:
            return "L'essence de créatures infectes";
          case 621:
            return "Invoque un slime de compagnie";
          case 622:
            return "Invoque un tiphia de compagnie";
          case 623:
            return "Invoque une chauve-souris de compagnie";
          case 624:
            return "Invoque un loup-garou de compagnie";
          case 625:
            return "Invoque un zombie de compagnie";
          case 357:
            return "Amélioration mineure de toutes les stats.";
          case 361:
            return "Invoque une armée de gobelins";
          case 363:
            return "Permet un travail avancé du bois";
          case 367:
            return "Suffisamment puissant pour détruire les autels de démon";
          case 371:
            return "Augmente le maximum de mana de 40";
          case 372:
            return "Vitesse de déplacement augmentée de 7 %";
          case 373:
            return "Dégâts à distance augmentés de 10 %";
          case 376:
            return "Augmente le maximum de mana de 60";
          case 377:
            return "Chance de coup critique de mêlée augmentée de 5 %";
          case 378:
            return "Dégâts à distance augmentés de 12 %";
          case 385:
            return "Permet d'extraire du mythril";
          case 386:
            return "Permet d'extraire de l'adamantine";
          case 389:
            return "Peut étourdir les ennemis";
          case 393:
            return "Indique la position horizontale";
          case 394:
            return "Permet de nager";
          case 395:
            return "Indique la position";
          case 396:
            return "Annule les dégâts de chute";
          case 397:
            return "Annule tout effet de recul";
          case 398:
            return "Permet de combiner certains accessoires";
          case 399:
            return "Permet de faire un double saut";
          case 400:
            return "Augmente le maximum de mana de 80";
          case 401:
            return "Chance de coup critique de mêlée augmentée de 7 %";
          case 402:
            return "Dégâts à distance augmentés de 14 %";
          case 403:
            return "Dégâts augmentés de 6 %";
          case 404:
            return "Chance de coup critique augmentée de 4 %";
          case 405:
            return "Permet de voler";
          case 407:
            return "Permet de construire un bloc plus loin";
          case 422:
            return "Purifie certains blocs";
          case 423:
            return "Corrompt certains blocs";
          case 425:
            return "Invoque une fée magique";
          case 327:
            return "Ouvre un coffre d'or";
          case 329:
            return "Ouvre tous les coffres sombres";
          case 332:
            return "Utilisé pour la fabrication de vêtements";
          case 352:
            return "Utilisé pour brasser la bière.";
          case 261:
            return "'Il sourit, ça ferait un casse-croûte sympa.'";
          case 266:
            return "'Super idée !'";
          case 267:
            return "'Vous êtes vraiment terrible.'";
          case 268:
            return "Améliore grandement la respiration sous l'eau";
          case 272:
            return "Lance une faux de démon";
          case 281:
            return "Permet de récupérer des graines comme munitions";
          case 282:
            return "Fonctionne même humide";
          case 283:
            return "Utilisable avec la sarbacane";
          case 285:
            return "La vitesse de déplacement est augmentée de 5 %";
          case 288:
            return "Procure l'immunité à la lave";
          case 289:
            return "Régénère la vie";
          case 290:
            return "Augmente la vitesse de déplacement de 25 %";
          case 291:
            return "Permet de respirer sous l'eau comme dans l'air";
          case 292:
            return "Augmente la défense de 8";
          case 293:
            return "Régénération de mana augmentée";
          case 294:
            return "Dégâts magiques augmentés de 20 %";
          case 295:
            return "Réduit la vitesse de chute";
          case 296:
            return "Indique l'emplacement des trésors et du minerai";
          case 297:
            return "Procure l'invisibilité";
          case 298:
            return "Émet une aura de lumière";
          case 299:
            return "Augmente la vision nocturne";
          case 300:
            return "Augmente la fréquence d'apparition des ennemis";
          case 301:
            return "Les attaquants subissent aussi des dégâts";
          case 302:
            return "Permet de marcher sur l'eau";
          case 303:
            return "Vitesse des flèches et leurs dégâts augmentés de 20 %";
          case 304:
            return "Indique l'emplacement des ennemis";
          case 305:
            return "Permet de contrôler la gravité";
          case 324:
            return "'Interdit quasiment partout'";
          case 222:
            return "Fait pousser les plantes";
          case 223:
            return "Réduit le coût de mana de 6 %";
          case 228:
            return "Augmente le maximum de mana de 20";
          case 229:
            return "Augmente le maximum de mana de 20";
          case 230:
            return "Augmente le maximum de mana de 20";
          case 235:
            return "'Peut s'avérer difficile à lancer'";
          case 237:
            return "'Pour un look de star !'";
          case 238:
            return "Dégâts magiques augmentés de 15 %";
          case 193:
            return "Permet de résister aux blocs de feu";
          case 197:
            return "Tire des étoiles filantes";
          case 208:
            return "'Comme c'est joli !'";
          case 211:
            return "Vitesse de mêlée augmentée de 12 %";
          case 212:
            return "Vitesse de déplacement augmentée de 10 %";
          case 213:
            return "Fait pousser de l'herbe sur la terre";
          case 215:
            return "'Peut être incommodant'";
          case 218:
            return "Invoque une boule de feu contrôlable";
          case 175:
            return "'Chaude au toucher'";
          case 186:
            return "'Ne pas se noyer, c'est quand même cool !'";
          case 187:
            return "Permet de nager";
          case 98:
            return "33 % de chance de n'utiliser aucune munition";
          case 100:
            return "Vitesse de mêlée augmentée de 7 %";
          case 101:
            return "Vitesse de mêlée augmentée de 7 %";
          case 102:
            return "Vitesse de mêlée augmentée de 7 %";
          case 103:
            return "Permet d'extraire de la pierre de l'enfer";
          case 109:
            return "Augmente le maximum de mana de 20 de façon permanente";
          case 111:
            return "Augmente le maximum de mana de 20";
          case 112:
            return "Lance des boules de feu";
          case 113:
            return "Lance un missile contrôlable";
          case 114:
            return "Déplace la terre par magie";
          case 115:
            return "Crée un orbe magique de lumière";
          case 117:
            return "'Chaude au toucher'";
          case 118:
            return "Trouvé parfois sur les squelettes et les piranhas";
          case 120:
            return "Transforme les flèches en bois tirées en flèches enflammées";
          case 121:
            return "'Elle pète le feu !'";
          case 123:
            return "Dégâts magiques augmentés de 5 %";
          case 124:
            return "Dégâts magiques augmentés de 5 %";
          case 125:
            return "Dégâts magiques augmentés de 5 %";
          case 128:
            return "Permet de voler";
          case 148:
            return "Cet objet peut attirer une attention non désirée";
          case 149:
            return "« Il contient d'étranges symboles »";
          case 151:
            return "Dégâts à distance augmentés de 4 %";
          case 152:
            return "Dégâts à distance augmentés de 4 %";
          case 153:
            return "Dégâts à distance augmentés de 4 %";
          case 156:
            return "Annule tout effet de recul";
          case 157:
            return "Lance de l'eau en continu";
          case 158:
            return "Annule les dégâts de chute";
          case 159:
            return "Augmente la hauteur des sauts";
          case 165:
            return "Invoque une boule d'eau se déplaçant lentement";
          case 166:
            return "Une petite explosion détruisant quelques blocs";
          case 167:
            return "Une grosse explosion détruisant la plupart des blocs";
          case 168:
            return "Une petite explosion ne détruisant pas de blocs";
          case 75:
            return "Disparaît au coucher du soleil";
          case 84:
            return "« Viens ici ! »";
          case 88:
            return "Procure de la lumière lorsqu'il est porté";
          case 43:
            return "Invoque l'œil de Cthulhu";
          case 49:
            return "Régénère lentement la vie";
          case 50:
            return "Fixer le miroir pour regagner son foyer";
          case 53:
            return "Permet de faire un double saut";
          case 54:
            return "Le porteur peur courir super vite";
          case 56:
            return "'Vibre d'une énergie sombre'";
          case 57:
            return "'Vibre d'une énergie sombre'";
          case 64:
            return "Invoque une vileronce";
          case 65:
            return "Provoque une pluie d'étoiles";
          case 66:
            return "Purifie la corruption";
          case 67:
            return "Corrompt la sainteté";
          case 68:
            return "'Ça a l'air bon !'";
          case 70:
            return "Invoque le dévoreur de mondes";
          case 29:
            return "Augmente le maximum de vie de 20 de façon permanente";
          case 33:
            return "Utilisé pour fondre le minerai";
          case 35:
            return "Permet de forger des objets à partir de métal";
          case 36:
            return "Utilisé pour l'artisanat de base";
          case -1:
            return "Permet d'extraire la météorite";
          case 8:
            return "Procure de la lumière";
          case 15:
            return "Donne l'heure";
          case 16:
            return "Donne l'heure";
          case 17:
            return "Donne l'heure";
          case 18:
            return "Indique la profondeur";
          case 23:
            return "'À la fois savoureux et inflammable'";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case 434:
            return "Dispara tres ráfagas";
          case 485:
            return "Convierte a su portador en hombre lobo durante la luna llena";
          case 486:
            return "Dibuja una rejilla en pantalla para colocar los bloques";
          case 489:
            return "Aumenta el daño de los ataques mágicos en un 15%";
          case 490:
            return "Aumenta el daño de los ataques cuerpo a cuerpo en un 15%";
          case 491:
            return "Aumenta el daño de los ataques a distancia en un 15%";
          case 492:
            return "Permite volar y caer lentamente";
          case 493:
            return "Permite volar y caer lentamente";
          case 495:
            return "Lanza un arco iris dirigido";
          case 496:
            return "Invoca un bloque de hielo";
          case 497:
            return "Transforma a su portador en un tritón al sumergirse en el agua";
          case 506:
            return "Utiliza gel como munición";
          case 509:
            return "Permite colocar alambre";
          case 510:
            return "Permite cortar alambre";
          case 515:
            return "Crea varios fragmentos de cristal al impactar";
          case 516:
            return "Invoca estrellas fugaces al impactar";
          case 517:
            return "Una daga mágica que vuelve al arrojarse";
          case 518:
            return "Lanza fragmentos de cristal a toda velocidad";
          case 519:
            return "Lanza bolas de fuego impuras";
          case 520:
            return "La esencia de las criaturas de la luz";
          case 521:
            return "La esencia de las criaturas de la oscuridad";
          case 522:
            return "Ni siquiera el agua puede apagarla";
          case 523:
            return "Se puede meter en el agua";
          case 524:
            return "Se usa para fundir mineral de adamantita";
          case 525:
            return "Se usa para fabricar objetos con lingotes de mithril y adamantita";
          case 526:
            return "'¡Puntiagudo y mágico!'";
          case 527:
            return "A veces lo llevan las criaturas de los desiertos corrompidos";
          case 528:
            return "A veces lo llevan las criaturas de los desiertos de luz";
          case 529:
            return "Se activa al pisarla";
          case 531:
            return "Se puede hechizar";
          case 532:
            return "Hace que las estrellas caigan al recibir heridas";
          case 533:
            return "Probabilidad del 50% de no gastar munición";
          case 534:
            return "Dispara una ráfaga dispersa de balas";
          case 535:
            return "Reduce el tiempo de espera para usar pociones curativas";
          case 536:
            return "Aumenta el retroceso en el cuerpo a cuerpo";
          case 541:
            return "Se activa al pisarla";
          case 542:
            return "Se activa al pisarla";
          case 543:
            return "Se activa al pisarla";
          case 544:
            return "Invoca a los Gemelos";
          case 547:
            return "La esencia del terror en estado puro";
          case 548:
            return "La esencia del Destructor";
          case 549:
            return "La esencia de los observadores omniscientes";
          case 551:
            return "Aumenta la probabilidad de conseguir ataques críticos en un 7%";
          case 552:
            return "Aumenta el daño de los ataques en un 7%";
          case 553:
            return "Aumenta el daño a de los ataques a distancia en un 15%";
          case 554:
            return "Aumenta el tiempo de invencibilidad tras recibir daños";
          case 555:
            return "Reduce el uso de maná en un 8%";
          case 556:
            return "Invoca al Destructor";
          case 557:
            return "Invoca al Esqueletrón mayor";
          case 558:
            return "Aumenta el maná máximo en 100";
          case 559:
            return "Aumenta en un 10% el daño de los ataques cuerpo a cuerpo y la posibilidad de causar ataques críticos";
          case 560:
            return "Invoca al rey slime";
          case 561:
            return "No apilar más de 5";
          case 575:
            return "La esencia de poderosas criaturas que vuelan";
          case 576:
            return "Permite grabar canciones";
          case 579:
            return "No confundir con un cuchillo jamonero";
          case 580:
            return "Explota al activarse";
          case 581:
            return "Envía agua a los colectores de salida";
          case 582:
            return "Recibe agua de los colectores de entrada";
          case 583:
            return "Se activa cada segundo";
          case 584:
            return "Se activa cada 3 segundos";
          case 585:
            return "Se activa cada 5 segundos";
          case 599:
          case 600:
          case 601:
            return "Pulsa " + (object) '\x0081' + " para abrir";
          case 602:
            return "Convoca a la Legión del hielo";
          case 603:
            return "Invoca a un conejillo de Indias de mascota";
          case 604:
            return "15% de aumento en daño por ataque en grupo y posibilidad de ataque mortal";
          case 605:
            return "15% de aumento de daño a distancia, 5% de posibilidad de no gastar munición";
          case 606:
            return "Aumenta el maná máximo en 120";
          case 607:
            return "10% de aumento en posibilidad de ataque mortal";
          case 608:
            return "5% de aumento de daño a distancia, 5% de posibilidad de no gastar munición";
          case 609:
            return "5% de aumento en daño por magia, 10% de reducción en uso de maná";
          case 610:
            return "12% de aumento en la velocidad de movimiento";
          case 611:
            return "10% de aumento en la velocidad de movimiento y el daño a distancia";
          case 612:
            return "10% de aumento en la velocidad de movimiento y el daño por magia";
          case 613:
            return "Tiene la posibilidad de causar hemorragia";
          case 614:
            return "Una legendaria lanza japonesa empapada de veneno";
          case 615:
            return "Transforma cualquier munición adecuada en flechas espectrales";
          case 617:
            return "Transforma cualquier munición adecuada en relámpagos volcánicos";
          case 619:
            return "Invoca a Ocram";
          case 620:
            return "'La esencia de las criaturas infectadas'";
          case 621:
            return "Invoca a un slime mascota";
          case 622:
            return "Invoca a una avispa mascota";
          case 623:
            return "Invoca a un murciélago mascota";
          case 624:
            return "Invoca a un hombre lobo mascota";
          case 625:
            return "Invoca a un zombi mascota";
          case 357:
            return "Proporciona pequeñas mejoras a todas las estadísticas";
          case 361:
            return "Invoca a un ejército de duendes";
          case 363:
            return "Se usa para fabricar artículos de madera avanzados";
          case 367:
            return "Lo bastante sólido para destruir los altares demoníacos";
          case 371:
            return "Aumenta el maná máximo en 40";
          case 372:
            return "Aumenta en un 7% la velocidad de movimiento";
          case 373:
            return "Aumenta el daño de los ataques a distancia en un 10%";
          case 376:
            return "Aumenta el maná máximo en 60";
          case 377:
            return "Aumenta un 5% la probabilidad de ataque crítico en el cuerpo a cuerpo";
          case 378:
            return "Aumenta el daño de los ataques a distancia en un 12%";
          case 385:
            return "Permite extraer mithril";
          case 386:
            return "Permite extraer adamantita";
          case 389:
            return "Puede llegar a confundir";
          case 393:
            return "Indica el horizonte";
          case 394:
            return "Permite nadar";
          case 395:
            return "Indica la posición";
          case 396:
            return "Anula el daño al caer";
          case 397:
            return "Anula el retroceso";
          case 398:
            return "Permite combinar varios accesorios";
          case 399:
            return "Su portador puede realizar dobles saltos";
          case 400:
            return "Aumenta el maná máximo en 80";
          case 401:
            return "Aumenta un 7% la probabilidad de ataque crítico en el cuerpo a cuerpo";
          case 402:
            return "Aumenta el daño de los ataques a distancia en un 14%";
          case 403:
            return "Aumenta el daño de los ataques en un 6%";
          case 404:
            return "Aumenta la probabilidad de conseguir ataques críticos en un 4%";
          case 405:
            return "Permite volar";
          case 407:
            return "Aumenta la distancia de colocación de bloques";
          case 422:
            return "Convierte los bloques cercanos en bloques sagrados";
          case 423:
            return "Extiende la corrupción a algunos bloques";
          case 425:
            return "Invoca a una hada mágica";
          case 327:
            return "Abre un cofre de oro";
          case 329:
            return "Abre todos los cofres de las sombras";
          case 332:
            return "Se usa para confeccionar ropa";
          case 352:
            return "Se usa para elaborar cerveza";
          case 261:
            return "Sonríe y además es un buen aperitivo";
          case 266:
            return "'¡Una buena idea!'";
          case 267:
            return "'Eres mala persona'";
          case 268:
            return "Permite respirar bajo el agua mucho más tiempo";
          case 272:
            return "Lanza una guadaña demoníaca";
          case 281:
            return "Permite recoger semillas como munición";
          case 282:
            return "Funciona con humedad";
          case 283:
            return "Para la cerbatana";
          case 285:
            return "Aumenta en un 5% la velocidad de movimiento";
          case 288:
            return "Ofrece inmunidad ante la lava";
          case 289:
            return "Regenera la vida";
          case 290:
            return "Aumenta en un 25% la velocidad de movimiento";
          case 291:
            return "Permite respirar agua en lugar de aire";
          case 292:
            return "Aumenta la defensa en 8";
          case 293:
            return "Aumenta la regeneración de maná";
          case 294:
            return "Aumenta el daño de los ataques mágicos en un 20%";
          case 295:
            return "Disminuye la velocidad de caída";
          case 296:
            return "Muestra la ubicación de tesoros y minerales";
          case 297:
            return "Proporciona invisibilidad";
          case 298:
            return "Emite un aura de luz";
          case 299:
            return "Mejora la visión nocturna";
          case 300:
            return "Aumenta la velocidad de regeneración del enemigo";
          case 301:
            return "Los atacantes también sufren daños";
          case 302:
            return "Permite caminar sobre el agua";
          case 303:
            return "Aumenta en un 20% la velocidad de las flechas y el daño que causan";
          case 304:
            return "Muestra la ubicación de los enemigos";
          case 305:
            return "Permite controlar la gravedad";
          case 324:
            return "'Prohibidos en casi todas partes'";
          case 222:
            return "Cultiva plantas";
          case 223:
            return "Reduce el uso de maná en un 6%";
          case 228:
            return "Aumenta el maná máximo en 20";
          case 229:
            return "Aumenta el maná máximo en 20";
          case 230:
            return "Aumenta el maná máximo en 20";
          case 235:
            return "'Puede costar lanzarla'";
          case 237:
            return "'¡Te quedan muy bien!'";
          case 238:
            return "Aumenta el daño de los ataques mágicos en un 15%";
          case 193:
            return "Ofrece inmunidad ante los bloques de fuego";
          case 197:
            return "Dispara estrellas fugaces";
          case 208:
            return "'Hermosa, muy hermosa'";
          case 211:
            return "Aumenta un 12% la velocidad en el cuerpo a cuerpo";
          case 212:
            return "Aumenta en un 10% la velocidad de movimiento";
          case 213:
            return "Genera césped sobre la tierra";
          case 215:
            return "'Una molestia para los demás'";
          case 218:
            return "Lanza una bola de fuego dirigida";
          case 175:
            return "Caliente al tacto";
          case 186:
            return "'Está bien eso de no ahogarse'";
          case 187:
            return "Permite nadar";
          case 98:
            return "Probabilidad del 33% de no gastar munición";
          case 100:
            return "Aumenta un 7% la velocidad de los ataques cuerpo a cuerpo";
          case 101:
            return "Aumenta un 7% la velocidad de los ataques cuerpo a cuerpo";
          case 102:
            return "Aumenta un 7% la velocidad de los ataques cuerpo a cuerpo";
          case 103:
            return "Permite excavar la piedra infernal";
          case 109:
            return "Aumenta el maná máximo en 20 de forma permanente";
          case 111:
            return "Aumenta el maná máximo en 20";
          case 112:
            return "Arroja bolas de fuego";
          case 113:
            return "Lanza un proyectil dirigido";
          case 114:
            return "Desplaza la tierra por arte de magia";
          case 115:
            return "Crea un orbe mágico de luz";
          case 117:
            return "Caliente al tacto";
          case 118:
            return "A veces lo sueltan esqueletos y pirañas";
          case 120:
            return "Enciende las flechas de madera";
          case 121:
            return "'¡Hecha de fuego!'";
          case 123:
            return "Aumenta el daño de los ataques mágicos en un 5%";
          case 124:
            return "Aumenta el daño de los ataques mágicos en un 5%";
          case 125:
            return "Aumenta el daño de los ataques mágicos en un 5%";
          case 128:
            return "Permite volar";
          case 148:
            return "Su portador llamará la atención de los indeseables";
          case 149:
            return "'Contiene extraños símbolos'";
          case 151:
            return "Aumenta el daño de los ataques a distancia en un 4%";
          case 152:
            return "Aumenta el daño de los ataques a distancia en un 4%";
          case 153:
            return "Aumenta el daño de los ataques a distancia en un 4%";
          case 156:
            return "Anula el retroceso";
          case 157:
            return "Lanza un chorro de agua";
          case 158:
            return "Anula el daño al caer";
          case 159:
            return "Aumenta la altura de los saltos";
          case 165:
            return "Lanza un proyectil de agua a baja velocidad";
          case 166:
            return "Pequeña explosión capaz de romper varios ladrillos";
          case 167:
            return "Gran explosión capaz de romper casi todos los ladrillos";
          case 168:
            return "Pequeña explosión que no rompe ningún ladrillo";
          case 75:
            return "Desaparece al amanecer";
          case 84:
            return "'¡Te atrapé!'";
          case 88:
            return "Da luz a su portador";
          case 43:
            return "Invoca al Ojo de Cthulhu";
          case 49:
            return "Regenera la vida poco a poco";
          case 50:
            return "Al mirarte en él regresarás a tu hogar";
          case 53:
            return "Su portador puede realizar dobles saltos";
          case 54:
            return "Permite correr superrápido";
          case 56:
            return "La energía oscura fluye en su interior";
          case 57:
            return "La energía oscura fluye en su interior";
          case 64:
            return "Lanza una espina vil";
          case 65:
            return "Hace que lluevan estrellas del cielo";
          case 66:
            return "Limpia la corrupción";
          case 67:
            return "Devuelve el territorio sagrado a la normalidad";
          case 68:
            return "¡Qué delicia!";
          case 70:
            return "Invoca al Devoramundos";
          case 29:
            return "Aumenta el nivel máximo de vida en 20 de forma permanente";
          case 33:
            return "Se usa para fundir mineral";
          case 35:
            return "Se usa para fabricar objetos con lingotes de metal";
          case 36:
            return "Se usa para creaciones básicas";
          case -1:
            return "Permite excavar meteoritos";
          case 8:
            return "Da luz";
          case 15:
            return "Da la hora";
          case 16:
            return "Da la hora";
          case 17:
            return "Da la hora";
          case 18:
            return "Indica la profundidad";
          case 23:
            return "Sabroso a la par que inflamable";
        }
      }
      return (string) null;
    }

    public static string toolTip2(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case 552:
            return "8% increased movement speed";
          case 553:
            return "8% increased ranged critical strike chance";
          case 555:
            return "Automatically use mana potions when needed";
          case 558:
            return "12% increased magic damage and critical strike chance";
          case 559:
            return "10% increased melee speed";
          case 604:
            return "15% increased critical strike chance";
          case 605:
            return "10% increased ranged critical strike chance";
          case 606:
            return "15% increased magic damage and critical strike chance";
          case 607:
            return "5% increased melee damage";
          case 608:
            return "10% increased ranged critical strike chance";
          case 609:
            return "10% increased magic critical strike chance";
          case 610:
            return "2% increased melee speed";
          case 611:
            return "10% chance to not consume ammo";
          case 612:
            return "Increases maximum mana by 30";
          case 434:
            return "Only the first shot consumes ammo";
          case 533:
            return "'Minishark's older brother'";
          case 228:
            return "3% increased magic critical strike chance";
          case 229:
            return "3% increased magic critical strike chance";
          case 230:
            return "3% increased magic critical strike chance";
          case 371:
            return "9% increased magic critical strike chance";
          case 372:
            return "12% increased melee speed";
          case 373:
            return "6% increased ranged critical strike chance";
          case 374:
            return "3% increased critical strike chance";
          case 375:
            return "10% increased movement speed";
          case 376:
            return "15% increased magic damage";
          case 377:
            return "10% increased melee damage";
          case 378:
            return "7% increased ranged critical strike chance";
          case 379:
            return "5% increased damage";
          case 380:
            return "3% increased critical strike chance";
          case 389:
            return "'Find your inner pieces'";
          case 394:
            return "Greatly extends underwater breathing";
          case 395:
            return "Tells the time";
          case 396:
            return "Grants immunity to fire blocks";
          case 397:
            return "Grants immunity to fire blocks";
          case 399:
            return "Increases jump height";
          case 400:
            return "11% increased magic damage and critical strike chance";
          case 401:
            return "14% increased melee damage";
          case 402:
            return "8% increased ranged critical strike chance";
          case 404:
            return "5% increased movement speed";
          case 405:
            return "The wearer can run super fast";
          case 65:
            return "'Forged with the fury of heaven'";
          case 98:
            return "'Half shark, half gun, completely awesome.'";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case 552:
            return "Um 8% erhöhtes Bewegungstempo";
          case 553:
            return "Um 8% erhöhte kritische Fernkampf-Trefferchance";
          case 555:
            return "Bei Bedarf automatisch Manatränke verwenden";
          case 558:
            return "Magischer Schaden und kritische Trefferchance um 12% erhöht";
          case 559:
            return "Um 10% erhöhtes Nahkampftempo";
          case 604:
            return "Kritische Trefferchance um 15% erhöht";
          case 605:
            return "Um 10% erhöhte kritische Fernkampf-Trefferchance";
          case 606:
            return "Magieschaden und kritische Trefferchance um 15% erhöht";
          case 607:
            return "Um 5% erhöhter Nahkampfschaden";
          case 608:
            return "Um 10% erhöhte kritische Fernkampf-Trefferchance";
          case 609:
            return "10% erhöhte Chance auf kritischen Magietreffer";
          case 610:
            return "Um 2% erhöhtes Nahkampftempo";
          case 611:
            return "10%ige Chance, keine Munition zu verbrauchen";
          case 612:
            return "Erhöht maximales Mana um 30";
          case 434:
            return "Nur der erste Schuss verbraucht Munition ";
          case 533:
            return "'Minihais großer Bruder'";
          case 228:
            return "Um 3% erhöhte kritische Magietrefferchance";
          case 229:
            return "Um 3% erhöhte kritische Magietrefferchance";
          case 230:
            return "Um 3% erhöhte kritische Magietrefferchance";
          case 371:
            return "Um 9% erhöhte kritische Magietrefferchance";
          case 372:
            return "Um 12% erhöhtes Nahkampftempo";
          case 373:
            return "Um 6% erhöhte kritische Fernkampf-Trefferchance";
          case 374:
            return "Um 3% erhöhte kritische Trefferchance";
          case 375:
            return "Um 10% erhöhtes Bewegungstempo";
          case 376:
            return "Um 15% erhöhter magischer Schaden";
          case 377:
            return "Um 10% erhöhter Nahkampfschaden";
          case 378:
            return "Um 7% erhöhte kritische Fernkampf-Trefferchance";
          case 379:
            return "Um 5% erhöhter Schaden";
          case 380:
            return "Um 3% erhöhte kritische Trefferchance";
          case 389:
            return "'Sammle dich!'";
          case 394:
            return "Verleiht deutlich mehr Atemluft unter Wasser";
          case 395:
            return "Zeigt die Zeit an";
          case 396:
            return "Macht immun gegen Feuer-Blöcke";
          case 397:
            return "Macht immun gegen Feuer-Blöcke";
          case 399:
            return "Vergrössert die Sprunghöhe";
          case 400:
            return "Magischer Schaden und kritische Trefferchance um 11% erhöht";
          case 401:
            return "Um 14% erhöhter Nahkampfschaden";
          case 402:
            return "Um 8% erhöhte kritische Fernkampf-Trefferchance";
          case 404:
            return "Um 5% erhöhtes Bewegungstempo";
          case 405:
            return "Der Träger kann superschnell rennen";
          case 65:
            return "'Geschmiedet mit Himmelswut'";
          case 98:
            return "'Halb Hai, halb Pistole - einfach toll!'";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case 552:
            return "Velocità di movimento aumentata del 8%";
          case 553:
            return "Possibilità di colpo critico a distanza aumentata dell'8%";
          case 555:
            return "Utilizza le pozioni mana automaticamente in caso di bisogno";
          case 558:
            return "Possibilità di danno magico e colpo critico aumentate del 12%";
          case 559:
            return "Velocità del corpo a corpo aumentata del 10%";
          case 604:
            return "Possibilità di colpo critico aumentata del 15%";
          case 605:
            return "Possibilità di colpo critico boomerang aumentata del 10%";
          case 606:
            return "Possibilità di colpo critico e del danno magico aumentati del 15%";
          case 607:
            return "Danno da mischia aumentato del 5%";
          case 608:
            return "Possibilità di colpo critico boomerang aumentata del 10%";
          case 609:
            return "Possibilità di colpo critico magico aumentata del 10%";
          case 610:
            return "Velocità del corpo a corpo aumentata del 2%";
          case 611:
            return "10% di possibilità di non consumare munizioni";
          case 612:
            return "Aumenta il mana massimo di 30";
          case 434:
            return "Solo il primo colpo consuma munizioni";
          case 533:
            return "'Fratello maggiore del Minishark'";
          case 228:
            return "Aumenta la possibilità di colpo critico magico del 3%";
          case 229:
            return "Aumenta la possibilità di colpo critico magico del 3%";
          case 230:
            return "Aumenta la possibilità di colpo critico magico del 3%";
          case 371:
            return "Possibilità colpo critico magico aumentate del 9%";
          case 372:
            return "Velocità del corpo a corpo aumentata del 12%";
          case 373:
            return "Possibilità di colpo critico magico aumentata del 6%";
          case 374:
            return "Possibilità di colpo critico aumentata del 3%";
          case 375:
            return "Velocità di movimento aumentata del 10%";
          case 376:
            return "Danno magico aumentato del 15%";
          case 377:
            return "Danno da mischia aumentato del 10%";
          case 378:
            return "Possibilità di colpo critico a distanza aumentata del 7%";
          case 379:
            return "Danno aumentato del 5%";
          case 380:
            return "Possibilità di colpo critico aumentata del 3%";
          case 389:
            return "'Trova i pezzi interni'";
          case 394:
            return "Aumenta moltissimo il respiro sott'acqua";
          case 395:
            return "Indica il tempo";
          case 396:
            return "Permette immunità ai blocchi di fuoco";
          case 397:
            return "Permette immunità ai blocchi di fuoco";
          case 399:
            return "Aumenta l'altezza del salto";
          case 400:
            return "Possibilità di colpo critico e danno magico aumentate del 11%";
          case 401:
            return "Danno da mischia aumentato del 14%";
          case 402:
            return "Possibilità di colpo critico a distanza aumentata dell'8%";
          case 404:
            return "Velocità di movimento aumentata del 5%";
          case 405:
            return "Colui che li indossa può correre velocissimo";
          case 65:
            return "'Forgiato con la furia del cielo'";
          case 98:
            return "'Mezzo squalo, mezza arma, assolutamente terrificante.'";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case 552:
            return "Vitesse de mouvement augmentée de 8 %";
          case 553:
            return "Chance de coup critique à distance augmentée de 8 %";
          case 555:
            return "Utilise des potions de mana automatiquement si besoin";
          case 558:
            return "Chance de coup critique et dégâts magiques augmentés de 12 %";
          case 559:
            return "Vitesse de mêlée augmentée de 10 %";
          case 604:
            return "Chance de coup critique augmentée de 15 %";
          case 605:
            return "Chance de coup critique à distance augmentée de 10 %";
          case 606:
            return "Dégâts magiques et chance de coup critique augmentés de 15 %";
          case 607:
            return "Dégâts de mêlée augmentés de 5 %";
          case 608:
            return "Chance de coup critique à distance augmentée de 10 %";
          case 609:
            return "Chance de coup critique magique augmentée de 10 %";
          case 610:
            return "Vitesse de mêlée augmentée de 2 %";
          case 611:
            return "10 % de chance de n'utiliser aucune munition";
          case 612:
            return "Maximum de mana augmenté de 30";
          case 434:
            return "Seul le premier tir utilise des munitions";
          case 533:
            return "'La version améliorée du minishark'";
          case 228:
            return "Chance de coup critique magique augmentée de 3 %";
          case 229:
            return "Chance de coup critique magique augmentée de 3 %";
          case 230:
            return "Chance de coup critique magique augmentée de 3 %";
          case 371:
            return "Chance de coup critique magique augmentée de 9 %";
          case 372:
            return "Vitesse de mêlée augmentée de 12 %";
          case 373:
            return "Chance de coup critique à distance augmentée de 6 %";
          case 374:
            return "Chance de coup critique augmentée de 3 %";
          case 375:
            return "Vitesse de déplacement augmentée de 10 %";
          case 376:
            return "Dégâts magiques augmentés de 15 %";
          case 377:
            return "Dégâts de mêlée  augmentés de 10 %";
          case 378:
            return "Chance de coup critique à distance augmentée de 7 %";
          case 379:
            return "Dégâts augmentés de 5 %";
          case 380:
            return "Chance de coup critique augmentée de 3 %";
          case 389:
            return "« Pour trouver la paix intérieure »";
          case 394:
            return "Améliore grandement la respiration sous l'eau";
          case 395:
            return "Donne l'heure";
          case 396:
            return "Permet de résister aux blocs de feu";
          case 397:
            return "Permet de résister aux blocs de feu";
          case 399:
            return "Augmente la hauteur des sauts";
          case 400:
            return "Dégâts magiques et chance de coup critique augmentés de 11 %";
          case 401:
            return "Dégâts de mêlée augmentés de 14 %";
          case 402:
            return "Chance de coup critique à distance augmentée de 8 %";
          case 404:
            return "Vitesse de déplacement augmentée de 5 %";
          case 405:
            return "Le porteur peur courir super vite";
          case 65:
            return "'Forgée dans la furie du ciel'";
          case 98:
            return "'Moitié requin, moitié fusil, c'est de la balle !'";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case 552:
            return "Aumenta en un 8% la velocidad de movimiento";
          case 553:
            return "Aumenta la probabilidad de ataque a distancia crítico en un 8%";
          case 555:
            return "Usa de forma automática pociones de maná cuando se necesitan";
          case 558:
            return "Aumenta en un 12% el daño de los ataques mágicos y la posibilidad de causar ataques críticos";
          case 559:
            return "Aumenta en un 10% la velocidad de los ataques cuerpo a cuerpo";
          case 604:
            return "15% de aumento en posibilidad de ataque mortal";
          case 605:
            return "10% de aumento en posibilidad de ataque mortal a distancia";
          case 606:
            return "15% de aumento en daño por magia y posibilidad de ataque mortal";
          case 607:
            return "5% de aumento en daño por ataque en grupo";
          case 608:
            return "10% de aumento en posibilidad de ataque mortal a distancia";
          case 609:
            return "10% de aumento en posibilidad de ataque mágico mortal";
          case 610:
            return "2% de aumento en la velocidad de ataque en grupo";
          case 611:
            return "10% de posibilidad de no gastar munición";
          case 612:
            return "Aumenta el maná máximo en 30";
          case 434:
            return "Solo gasta munición el primer disparo";
          case 533:
            return "'El hermano mayor del minitiburón'";
          case 228:
            return "Aumenta la probabilidad de ataque mágico crítico en un 3%";
          case 229:
            return "Aumenta la probabilidad de ataque mágico crítico en un 3%";
          case 230:
            return "Aumenta la probabilidad de ataque mágico crítico en un 3%";
          case 371:
            return "Aumenta la probabilidad de ataque mágico crítico en un 9%";
          case 372:
            return "Aumenta un 12% la velocidad de los ataques cuerpo a cuerpo";
          case 373:
            return "Aumenta la probabilidad de ataque a distancia crítico en un 6%";
          case 374:
            return "Aumenta la probabilidad de conseguir ataques críticos en un 3%";
          case 375:
            return "Aumenta en un 10% la velocidad de movimiento";
          case 376:
            return "Aumenta el daño de los ataques mágicos en un 15%";
          case 377:
            return "Aumenta el daño de los ataques cuerpo a cuerpo en un 10%";
          case 378:
            return "Aumenta la probabilidad de ataque a distancia crítico en un 7%";
          case 379:
            return "Aumenta el daño en un 5%";
          case 380:
            return "Aumenta la probabilidad de conseguir ataques críticos en un 3%";
          case 389:
            return "Busca en tu interior";
          case 394:
            return "Permite respirar bajo el agua mucho más tiempo";
          case 395:
            return "Da la hora";
          case 396:
            return "Ofrece inmunidad ante los bloques de fuego";
          case 397:
            return "Ofrece inmunidad ante los bloques de fuego";
          case 399:
            return "Aumenta la altura de los saltos";
          case 400:
            return "Aumenta en un 11% el daño de los ataques mágicos y la posibilidad de causar ataques críticos";
          case 401:
            return "Aumenta el daño de los ataques cuerpo a cuerpo en un 14%";
          case 402:
            return "Aumenta la probabilidad de ataque a distancia crítico en un 8%";
          case 404:
            return "Aumenta en un 5% la velocidad de movimiento";
          case 405:
            return "Permite correr superrápido";
          case 65:
            return "'Forjada por la furia del cielo'";
          case 98:
            return "'Mitad tiburón, mitad arma; realmente asombroso'";
        }
      }
      return (string) null;
    }

    public static string itemName(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case -24:
            return "Yellow Phasesaber";
          case -23:
            return "White Phasesaber";
          case -22:
            return "Purple Phasesaber";
          case -21:
            return "Green Phasesaber";
          case -20:
            return "Red Phasesaber";
          case -19:
            return "Blue Phasesaber";
          case -18:
            return "Copper Bow";
          case -17:
            return "Copper Hammer";
          case -16:
            return "Copper Axe";
          case -15:
            return "Copper Shortsword";
          case -14:
            return "Copper Broadsword";
          case -13:
            return "Copper Pickaxe";
          case -12:
            return "Silver Bow";
          case -11:
            return "Silver Hammer";
          case -10:
            return "Silver Axe";
          case -9:
            return "Silver Shortsword";
          case -8:
            return "Silver Broadsword";
          case -7:
            return "Silver Pickaxe";
          case -6:
            return "Gold Bow";
          case -5:
            return "Gold Hammer";
          case -4:
            return "Gold Axe";
          case -3:
            return "Gold Shortsword";
          case -2:
            return "Gold Broadsword";
          case -1:
            return "Gold Pickaxe";
          case 1:
            return "Iron Pickaxe";
          case 2:
            return "Dirt Block";
          case 3:
            return "Stone Block";
          case 4:
            return "Iron Broadsword";
          case 5:
            return "Mushroom";
          case 6:
            return "Iron Shortsword";
          case 7:
            return "Iron Hammer";
          case 8:
            return "Torch";
          case 9:
            return "Wood";
          case 10:
            return "Iron Axe";
          case 11:
            return "Iron Ore";
          case 12:
            return "Copper Ore";
          case 13:
            return "Gold Ore";
          case 14:
            return "Silver Ore";
          case 15:
            return "Copper Watch";
          case 16:
            return "Silver Watch";
          case 17:
            return "Gold Watch";
          case 18:
            return "Depth Meter";
          case 19:
            return "Gold Bar";
          case 20:
            return "Copper Bar";
          case 21:
            return "Silver Bar";
          case 22:
            return "Iron Bar";
          case 23:
            return "Gel";
          case 24:
            return "Wooden Sword";
          case 25:
            return "Wooden Door";
          case 26:
            return "Stone Wall";
          case 27:
            return "Acorn";
          case 28:
            return "Lesser Healing Potion";
          case 29:
            return "Life Crystal";
          case 30:
            return "Dirt Wall";
          case 31:
            return "Bottle";
          case 32:
            return "Wooden Table";
          case 33:
            return "Furnace";
          case 34:
            return "Wooden Chair";
          case 35:
            return "Iron Anvil";
          case 36:
            return "Work Bench";
          case 37:
            return "Goggles";
          case 38:
            return "Lens";
          case 39:
            return "Wooden Bow";
          case 40:
            return "Wooden Arrow";
          case 41:
            return "Flaming Arrow";
          case 42:
            return "Shuriken";
          case 43:
            return "Suspicious Looking Eye";
          case 44:
            return "Demon Bow";
          case 45:
            return "War Axe of the Night";
          case 46:
            return "Light's Bane";
          case 47:
            return "Unholy Arrow";
          case 48:
            return "Chest";
          case 49:
            return "Band of Regeneration";
          case 50:
            return "Magic Mirror";
          case 51:
            return "Jester's Arrow";
          case 52:
            return "Angel Statue";
          case 53:
            return "Cloud in a Bottle";
          case 54:
            return "Hermes Boots";
          case 55:
            return "Enchanted Boomerang";
          case 56:
            return "Demonite Ore";
          case 57:
            return "Demonite Bar";
          case 58:
            return "Heart";
          case 59:
            return "Corrupt Seeds";
          case 60:
            return "Vile Mushroom";
          case 61:
            return "Ebonstone Block";
          case 62:
            return "Grass Seeds";
          case 63:
            return "Sunflower";
          case 64:
            return "Vilethorn";
          case 65:
            return "Starfury";
          case 66:
            return "Purification Powder";
          case 67:
            return "Vile Powder";
          case 68:
            return "Rotten Chunk";
          case 69:
            return "Worm Tooth";
          case 70:
            return "Worm Food";
          case 71:
            return "Copper Coin";
          case 72:
            return "Silver Coin";
          case 73:
            return "Gold Coin";
          case 74:
            return "Platinum Coin";
          case 75:
            return "Fallen Star";
          case 76:
            return "Copper Greaves";
          case 77:
            return "Iron Greaves";
          case 78:
            return "Silver Greaves";
          case 79:
            return "Gold Greaves";
          case 80:
            return "Copper Chainmail";
          case 81:
            return "Iron Chainmail";
          case 82:
            return "Silver Chainmail";
          case 83:
            return "Gold Chainmail";
          case 84:
            return "Grappling Hook";
          case 85:
            return "Iron Chain";
          case 86:
            return "Shadow Scale";
          case 87:
            return "Piggy Bank";
          case 88:
            return "Mining Helmet";
          case 89:
            return "Copper Helmet";
          case 90:
            return "Iron Helmet";
          case 91:
            return "Silver Helmet";
          case 92:
            return "Gold Helmet";
          case 93:
            return "Wood Wall";
          case 94:
            return "Wood Platform";
          case 95:
            return "Flintlock Pistol";
          case 96:
            return "Musket";
          case 97:
            return "Musket Ball";
          case 98:
            return "Minishark";
          case 99:
            return "Iron Bow";
          case 100:
            return "Shadow Greaves";
          case 101:
            return "Shadow Scalemail";
          case 102:
            return "Shadow Helmet";
          case 103:
            return "Nightmare Pickaxe";
          case 104:
            return "The Breaker";
          case 105:
            return "Candle";
          case 106:
            return "Copper Chandelier";
          case 107:
            return "Silver Chandelier";
          case 108:
            return "Gold Chandelier";
          case 109:
            return "Mana Crystal";
          case 110:
            return "Lesser Mana Potion";
          case 111:
            return "Band of Starpower";
          case 112:
            return "Flower of Fire";
          case 113:
            return "Magic Missile";
          case 114:
            return "Dirt Rod";
          case 115:
            return "Orb of Light";
          case 116:
            return "Meteorite";
          case 117:
            return "Meteorite Bar";
          case 118:
            return "Hook";
          case 119:
            return "Flamarang";
          case 120:
            return "Molten Fury";
          case 121:
            return "Fiery Greatsword";
          case 122:
            return "Molten Pickaxe";
          case 123:
            return "Meteor Helmet";
          case 124:
            return "Meteor Suit";
          case 125:
            return "Meteor Leggings";
          case 126:
            return "Bottled Water";
          case (int) sbyte.MaxValue:
            return "Space Gun";
          case 128:
            return "Rocket Boots";
          case 129:
            return "Gray Brick";
          case 130:
            return "Gray Brick Wall";
          case 131:
            return "Red Brick";
          case 132:
            return "Red Brick Wall";
          case 133:
            return "Clay Block";
          case 134:
            return "Blue Brick";
          case 135:
            return "Blue Brick Wall";
          case 136:
            return "Chain Lantern";
          case 137:
            return "Green Brick";
          case 138:
            return "Green Brick Wall";
          case 139:
            return "Pink Brick";
          case 140:
            return "Pink Brick Wall";
          case 141:
            return "Gold Brick";
          case 142:
            return "Gold Brick Wall";
          case 143:
            return "Silver Brick";
          case 144:
            return "Silver Brick Wall";
          case 145:
            return "Copper Brick";
          case 146:
            return "Copper Brick Wall";
          case 147:
            return "Spike";
          case 148:
            return "Water Candle";
          case 149:
            return "Book";
          case 150:
            return "Cobweb";
          case 151:
            return "Necro Helmet";
          case 152:
            return "Necro Breastplate";
          case 153:
            return "Necro Greaves";
          case 154:
            return "Bone";
          case 155:
            return "Muramasa";
          case 156:
            return "Cobalt Shield";
          case 157:
            return "Aqua Scepter";
          case 158:
            return "Lucky Horseshoe";
          case 159:
            return "Shiny Red Balloon";
          case 160:
            return "Harpoon";
          case 161:
            return "Spiky Ball";
          case 162:
            return "Ball O' Hurt";
          case 163:
            return "Blue Moon";
          case 164:
            return "Handgun";
          case 165:
            return "Water Bolt";
          case 166:
            return "Bomb";
          case 167:
            return "Dynamite";
          case 168:
            return "Grenade";
          case 169:
            return "Sand Block";
          case 170:
            return "Glass";
          case 171:
            return "Sign";
          case 172:
            return "Ash Block";
          case 173:
            return "Obsidian";
          case 174:
            return "Hellstone";
          case 175:
            return "Hellstone Bar";
          case 176:
            return "Mud Block";
          case 177:
            return "Sapphire";
          case 178:
            return "Ruby";
          case 179:
            return "Emerald";
          case 180:
            return "Topaz";
          case 181:
            return "Amethyst";
          case 182:
            return "Diamond";
          case 183:
            return "Glowing Mushroom";
          case 184:
            return "Star";
          case 185:
            return "Ivy Whip";
          case 186:
            return "Breathing Reed";
          case 187:
            return "Flipper";
          case 188:
            return "Healing Potion";
          case 189:
            return "Mana Potion";
          case 190:
            return "Blade of Grass";
          case 191:
            return "Thorn Chakram";
          case 192:
            return "Obsidian Brick";
          case 193:
            return "Obsidian Skull";
          case 194:
            return "Mushroom Grass Seeds";
          case 195:
            return "Jungle Grass Seeds";
          case 196:
            return "Wooden Hammer";
          case 197:
            return "Star Cannon";
          case 198:
            return "Blue Phaseblade";
          case 199:
            return "Red Phaseblade";
          case 200:
            return "Green Phaseblade";
          case 201:
            return "Purple Phaseblade";
          case 202:
            return "White Phaseblade";
          case 203:
            return "Yellow Phaseblade";
          case 204:
            return "Meteor Hamaxe";
          case 205:
            return "Empty Bucket";
          case 206:
            return "Water Bucket";
          case 207:
            return "Lava Bucket";
          case 208:
            return "Jungle Rose";
          case 209:
            return "Stinger";
          case 210:
            return "Vine";
          case 211:
            return "Feral Claws";
          case 212:
            return "Anklet of the Wind";
          case 213:
            return "Staff of Regrowth";
          case 214:
            return "Hellstone Brick";
          case 215:
            return "Whoopie Cushion";
          case 216:
            return "Shackle";
          case 217:
            return "Molten Hamaxe";
          case 218:
            return "Flamelash";
          case 219:
            return "Phoenix Blaster";
          case 220:
            return "Sunfury";
          case 221:
            return "Hellforge";
          case 222:
            return "Clay Pot";
          case 223:
            return "Nature's Gift";
          case 224:
            return "Bed";
          case 225:
            return "Silk";
          case 226:
            return "Lesser Restoration Potion";
          case 227:
            return "Restoration Potion";
          case 228:
            return "Jungle Hat";
          case 229:
            return "Jungle Shirt";
          case 230:
            return "Jungle Pants";
          case 231:
            return "Molten Helmet";
          case 232:
            return "Molten Breastplate";
          case 233:
            return "Molten Greaves";
          case 234:
            return "Meteor Shot";
          case 235:
            return "Sticky Bomb";
          case 236:
            return "Black Lens";
          case 237:
            return "Sunglasses";
          case 238:
            return "Wizard Hat";
          case 239:
            return "Top Hat";
          case 240:
            return "Tuxedo Shirt";
          case 241:
            return "Tuxedo Pants";
          case 242:
            return "Summer Hat";
          case 243:
            return "Bunny Hood";
          case 244:
            return "Plumber's Hat";
          case 245:
            return "Plumber's Shirt";
          case 246:
            return "Plumber's Pants";
          case 247:
            return "Hero's Hat";
          case 248:
            return "Hero's Shirt";
          case 249:
            return "Hero's Pants";
          case 250:
            return "Fish Bowl";
          case 251:
            return "Archaeologist's Hat";
          case 252:
            return "Archaeologist's Jacket";
          case 253:
            return "Archaeologist's Pants";
          case 254:
            return "Black Dye";
          case (int) byte.MaxValue:
            return "Purple Dye";
          case 256:
            return "Ninja Hood";
          case 257:
            return "Ninja Shirt";
          case 258:
            return "Ninja Pants";
          case 259:
            return "Leather";
          case 260:
            return "Red Hat";
          case 261:
            return "Goldfish";
          case 262:
            return "Robe";
          case 263:
            return "Robot Hat";
          case 264:
            return "Gold Crown";
          case 265:
            return "Hellfire Arrow";
          case 266:
            return "Sandgun";
          case 267:
            return "Guide Voodoo Doll";
          case 268:
            return "Diving Helmet";
          case 269:
            return "Familiar Shirt";
          case 270:
            return "Familiar Pants";
          case 271:
            return "Familiar Wig";
          case 272:
            return "Demon Scythe";
          case 273:
            return "Night's Edge";
          case 274:
            return "Dark Lance";
          case 275:
            return "Coral";
          case 276:
            return "Cactus";
          case 277:
            return "Trident";
          case 278:
            return "Silver Bullet";
          case 279:
            return "Throwing Knife";
          case 280:
            return "Spear";
          case 281:
            return "Blowpipe";
          case 282:
            return "Glowstick";
          case 283:
            return "Seed";
          case 284:
            return "Wooden Boomerang";
          case 285:
            return "Aglet";
          case 286:
            return "Sticky Glowstick";
          case 287:
            return "Poisoned Knife";
          case 288:
            return "Obsidian Skin Potion";
          case 289:
            return "Regeneration Potion";
          case 290:
            return "Swiftness Potion";
          case 291:
            return "Gills Potion";
          case 292:
            return "Ironskin Potion";
          case 293:
            return "Mana Regeneration Potion";
          case 294:
            return "Magic Power Potion";
          case 295:
            return "Featherfall Potion";
          case 296:
            return "Spelunker Potion";
          case 297:
            return "Invisibility Potion";
          case 298:
            return "Shine Potion";
          case 299:
            return "Night Owl Potion";
          case 300:
            return "Battle Potion";
          case 301:
            return "Thorns Potion";
          case 302:
            return "Water Walking Potion";
          case 303:
            return "Archery Potion";
          case 304:
            return "Hunter Potion";
          case 305:
            return "Gravitation Potion";
          case 306:
            return "Gold Chest";
          case 307:
            return "Daybloom Seeds";
          case 308:
            return "Moonglow Seeds";
          case 309:
            return "Blinkroot Seeds";
          case 310:
            return "Deathweed Seeds";
          case 311:
            return "Waterleaf Seeds";
          case 312:
            return "Fireblossom Seeds";
          case 313:
            return "Daybloom";
          case 314:
            return "Moonglow";
          case 315:
            return "Blinkroot";
          case 316:
            return "Deathweed";
          case 317:
            return "Waterleaf";
          case 318:
            return "Fireblossom";
          case 319:
            return "Shark Fin";
          case 320:
            return "Feather";
          case 321:
            return "Tombstone";
          case 322:
            return "Mime Mask";
          case 323:
            return "Antlion Mandible";
          case 324:
            return "Illegal Gun Parts";
          case 325:
            return "The Doctor's Shirt";
          case 326:
            return "The Doctor's Pants";
          case 327:
            return "Golden Key";
          case 328:
            return "Shadow Chest";
          case 329:
            return "Shadow Key";
          case 330:
            return "Obsidian Brick Wall";
          case 331:
            return "Jungle Spores";
          case 332:
            return "Loom";
          case 333:
            return "Piano";
          case 334:
            return "Dresser";
          case 335:
            return "Bench";
          case 336:
            return "Bathtub";
          case 337:
            return "Red Banner";
          case 338:
            return "Green Banner";
          case 339:
            return "Blue Banner";
          case 340:
            return "Yellow Banner";
          case 341:
            return "Lamp Post";
          case 342:
            return "Tiki Torch";
          case 343:
            return "Barrel";
          case 344:
            return "Chinese Lantern";
          case 345:
            return "Cooking Pot";
          case 346:
            return "Safe";
          case 347:
            return "Skull Lantern";
          case 348:
            return "Trash Can";
          case 349:
            return "Candelabra";
          case 350:
            return "Pink Vase";
          case 351:
            return "Mug";
          case 352:
            return "Keg";
          case 353:
            return "Ale";
          case 354:
            return "Bookcase";
          case 355:
            return "Throne";
          case 356:
            return "Bowl";
          case 357:
            return "Bowl of Soup";
          case 358:
            return "Toilet";
          case 359:
            return "Grandfather Clock";
          case 360:
            return "Armor Statue";
          case 361:
            return "Goblin Battle Standard";
          case 362:
            return "Tattered Cloth";
          case 363:
            return "Sawmill";
          case 364:
            return "Cobalt Ore";
          case 365:
            return "Mythril Ore";
          case 366:
            return "Adamantite Ore";
          case 367:
            return "Pwnhammer";
          case 368:
            return "Excalibur";
          case 369:
            return "Hallowed Seeds";
          case 370:
            return "Ebonsand Block";
          case 371:
            return "Cobalt Hat";
          case 372:
            return "Cobalt Helmet";
          case 373:
            return "Cobalt Mask";
          case 374:
            return "Cobalt Breastplate";
          case 375:
            return "Cobalt Leggings";
          case 376:
            return "Mythril Hood";
          case 377:
            return "Mythril Helmet";
          case 378:
            return "Mythril Hat";
          case 379:
            return "Mythril Chainmail";
          case 380:
            return "Mythril Greaves";
          case 381:
            return "Cobalt Bar";
          case 382:
            return "Mythril Bar";
          case 383:
            return "Cobalt Chainsaw";
          case 384:
            return "Mythril Chainsaw";
          case 385:
            return "Cobalt Drill";
          case 386:
            return "Mythril Drill";
          case 387:
            return "Adamantite Chainsaw";
          case 388:
            return "Adamantite Drill";
          case 389:
            return "Dao of Pow";
          case 390:
            return "Mythril Halberd";
          case 391:
            return "Adamantite Bar";
          case 392:
            return "Glass Wall";
          case 393:
            return "Compass";
          case 394:
            return "Diving Gear";
          case 395:
            return "GPS";
          case 396:
            return "Obsidian Horseshoe";
          case 397:
            return "Obsidian Shield";
          case 398:
            return "Tinkerer's Workshop";
          case 399:
            return "Cloud in a Balloon";
          case 400:
            return "Adamantite Headgear";
          case 401:
            return "Adamantite Helmet";
          case 402:
            return "Adamantite Mask";
          case 403:
            return "Adamantite Breastplate";
          case 404:
            return "Adamantite Leggings";
          case 405:
            return "Spectre Boots";
          case 406:
            return "Adamantite Glaive";
          case 407:
            return "Toolbelt";
          case 408:
            return "Pearlsand Block";
          case 409:
            return "Pearlstone Block";
          case 410:
            return "Mining Shirt";
          case 411:
            return "Mining Pants";
          case 412:
            return "Pearlstone Brick";
          case 413:
            return "Iridescent Brick";
          case 414:
            return "Mudstone Brick";
          case 415:
            return "Cobalt Brick";
          case 416:
            return "Mythril Brick";
          case 417:
            return "Pearlstone Brick Wall";
          case 418:
            return "Iridescent Brick Wall";
          case 419:
            return "Mudstone Brick Wall";
          case 420:
            return "Cobalt Brick Wall";
          case 421:
            return "Mythril Brick Wall";
          case 422:
            return "Holy Water";
          case 423:
            return "Unholy Water";
          case 424:
            return "Silt Block";
          case 425:
            return "Fairy Bell";
          case 426:
            return "Breaker Blade";
          case 427:
            return "Blue Torch";
          case 428:
            return "Red Torch";
          case 429:
            return "Green Torch";
          case 430:
            return "Purple Torch";
          case 431:
            return "White Torch";
          case 432:
            return "Yellow Torch";
          case 433:
            return "Demon Torch";
          case 434:
            return "Clockwork Assault Rifle";
          case 435:
            return "Cobalt Repeater";
          case 436:
            return "Mythril Repeater";
          case 437:
            return "Dual Hook";
          case 438:
            return "Star Statue";
          case 439:
            return "Sword Statue";
          case 440:
            return "Slime Statue";
          case 441:
            return "Goblin Statue";
          case 442:
            return "Shield Statue";
          case 443:
            return "Bat Statue";
          case 444:
            return "Fish Statue";
          case 445:
            return "Bunny Statue";
          case 446:
            return "Skeleton Statue";
          case 447:
            return "Reaper Statue";
          case 448:
            return "Woman Statue";
          case 449:
            return "Imp Statue";
          case 450:
            return "Gargoyle Statue";
          case 451:
            return "Gloom Statue";
          case 452:
            return "Hornet Statue";
          case 453:
            return "Bomb Statue";
          case 454:
            return "Crab Statue";
          case 455:
            return "Hammer Statue";
          case 456:
            return "Potion Statue";
          case 457:
            return "Spear Statue";
          case 458:
            return "Cross Statue";
          case 459:
            return "Jellyfish Statue";
          case 460:
            return "Bow Statue";
          case 461:
            return "Boomerang Statue";
          case 462:
            return "Boot Statue";
          case 463:
            return "Chest Statue";
          case 464:
            return "Bird Statue";
          case 465:
            return "Axe Statue";
          case 466:
            return "Corrupt Statue";
          case 467:
            return "Tree Statue";
          case 468:
            return "Anvil Statue";
          case 469:
            return "Pickaxe Statue";
          case 470:
            return "Mushroom Statue";
          case 471:
            return "Eyeball Statue";
          case 472:
            return "Pillar Statue";
          case 473:
            return "Heart Statue";
          case 474:
            return "Pot Statue";
          case 475:
            return "Sunflower Statue";
          case 476:
            return "King Statue";
          case 477:
            return "Queen Statue";
          case 478:
            return "Piranha Statue";
          case 479:
            return "Planked Wall";
          case 480:
            return "Wooden Beam";
          case 481:
            return "Adamantite Repeater";
          case 482:
            return "Adamantite Sword";
          case 483:
            return "Cobalt Sword";
          case 484:
            return "Mythril Sword";
          case 485:
            return "Moon Charm";
          case 486:
            return "Ruler";
          case 487:
            return "Crystal Ball";
          case 488:
            return "Disco Ball";
          case 489:
            return "Sorcerer Emblem";
          case 490:
            return "Warrior Emblem";
          case 491:
            return "Ranger Emblem";
          case 492:
            return "Demon Wings";
          case 493:
            return "Angel Wings";
          case 494:
            return "Magical Harp";
          case 495:
            return "Rainbow Rod";
          case 496:
            return "Ice Rod";
          case 497:
            return "Neptune's Shell";
          case 498:
            return "Mannequin";
          case 499:
            return "Greater Healing Potion";
          case 500:
            return "Greater Mana Potion";
          case 501:
            return "Pixie Dust";
          case 502:
            return "Crystal Shard";
          case 503:
            return "Clown Hat";
          case 504:
            return "Clown Shirt";
          case 505:
            return "Clown Pants";
          case 506:
            return "Flamethrower";
          case 507:
            return "Bell";
          case 508:
            return "Harp";
          case 509:
            return "Wrench";
          case 510:
            return "Wire Cutter";
          case 511:
            return "Active Stone Block";
          case 512:
            return "Inactive Stone Block";
          case 513:
            return "Lever";
          case 514:
            return "Laser Rifle";
          case 515:
            return "Crystal Bullet";
          case 516:
            return "Holy Arrow";
          case 517:
            return "Magic Dagger";
          case 518:
            return "Crystal Storm";
          case 519:
            return "Cursed Flames";
          case 520:
            return "Soul of Light";
          case 521:
            return "Soul of Night";
          case 522:
            return "Cursed Flame";
          case 523:
            return "Cursed Torch";
          case 524:
            return "Adamantite Forge";
          case 525:
            return "Mythril Anvil";
          case 526:
            return "Unicorn Horn";
          case 527:
            return "Dark Shard";
          case 528:
            return "Light Shard";
          case 529:
            return "Red Pressure Plate";
          case 530:
            return "Wire";
          case 531:
            return "Spell Tome";
          case 532:
            return "Star Cloak";
          case 533:
            return "Megashark";
          case 534:
            return "Shotgun";
          case 535:
            return "Philosopher's Stone";
          case 536:
            return "Titan Glove";
          case 537:
            return "Cobalt Naginata";
          case 538:
            return "Switch";
          case 539:
            return "Dart Trap";
          case 540:
            return "Boulder";
          case 541:
            return "Green Pressure Plate";
          case 542:
            return "Gray Pressure Plate";
          case 543:
            return "Brown Pressure Plate";
          case 544:
            return "Mechanical Eye";
          case 545:
            return "Cursed Arrow";
          case 546:
            return "Cursed Bullet";
          case 547:
            return "Soul of Fright";
          case 548:
            return "Soul of Might";
          case 549:
            return "Soul of Sight";
          case 550:
            return "Gungnir";
          case 551:
            return "Hallowed Plate Mail";
          case 552:
            return "Hallowed Greaves";
          case 553:
            return "Hallowed Helmet";
          case 554:
            return "Cross Necklace";
          case 555:
            return "Mana Flower";
          case 556:
            return "Mechanical Worm";
          case 557:
            return "Mechanical Skull";
          case 558:
            return "Hallowed Headgear";
          case 559:
            return "Hallowed Mask";
          case 560:
            return "Slime Crown";
          case 561:
            return "Light Disc";
          case 562:
            return "Music Box (Overworld Day)";
          case 563:
            return "Music Box (Eerie)";
          case 564:
            return "Music Box (Night)";
          case 565:
            return "Music Box (Title)";
          case 566:
            return "Music Box (Underground)";
          case 567:
            return "Music Box (Boss 1)";
          case 568:
            return "Music Box (Jungle)";
          case 569:
            return "Music Box (Corruption)";
          case 570:
            return "Music Box (Underground Corruption)";
          case 571:
            return "Music Box (The Hallow)";
          case 572:
            return "Music Box (Boss 2)";
          case 573:
            return "Music Box (Underground Hallow)";
          case 574:
            return "Music Box (Boss 3)";
          case 575:
            return "Soul of Flight";
          case 576:
            return "Music Box";
          case 577:
            return "Demonite Brick";
          case 578:
            return "Hallowed Repeater";
          case 579:
            return "Hamdrax";
          case 580:
            return "Explosives";
          case 581:
            return "Inlet Pump";
          case 582:
            return "Outlet Pump";
          case 583:
            return "1 Second Timer";
          case 584:
            return "3 Second Timer";
          case 585:
            return "5 Second Timer";
          case 586:
            return "Candy Cane Block";
          case 587:
            return "Candy Cane Wall";
          case 588:
            return "Santa Hat";
          case 589:
            return "Santa Shirt";
          case 590:
            return "Santa Pants";
          case 591:
            return "Green Candy Cane Block";
          case 592:
            return "Green Candy Cane Wall";
          case 593:
            return "Snow Block";
          case 594:
            return "Snow Brick";
          case 595:
            return "Snow Brick Wall";
          case 596:
            return "Blue Light";
          case 597:
            return "Red Light";
          case 598:
            return "Green Light";
          case 599:
            return "Blue Present";
          case 600:
            return "Green Present";
          case 601:
            return "Yellow Present";
          case 602:
            return "Snow Globe";
          case 603:
            return "Cabbage";
          case 604:
            return "Dragon Mask";
          case 605:
            return "Titan Helmet";
          case 606:
            return "Spectral Headgear";
          case 607:
            return "Dragon Breastplate";
          case 608:
            return "Titan Mail";
          case 609:
            return "Spectral Armor";
          case 610:
            return "Dragon Greaves";
          case 611:
            return "Titan Leggings";
          case 612:
            return "Spectral Subligar";
          case 613:
            return "Tizona";
          case 614:
            return "Tonbogiri";
          case 615:
            return "Sharanga";
          case 616:
            return "Spectral Arrow";
          case 617:
            return "Vulcan Repeater";
          case 618:
            return "Vulcan Bolt";
          case 619:
            return "Suspicious Looking Skull";
          case 620:
            return "Soul of Blight";
          case 621:
            return "Petri Dish";
          case 622:
            return "Honeycomb";
          case 623:
            return "Vial of Blood";
          case 624:
            return "Wolf Fang";
          case 625:
            return "Brain";
          case 626:
            return "Music Box (Desert)";
          case 627:
            return "Music Box (Space)";
          case 628:
            return "Music Box (Tutorial)";
          case 629:
            return "Music Box (Boss 4)";
          case 630:
            return "Music Box (Ocean)";
          case 631:
            return "Music Box (Snow)";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case -24:
            return "Gelbes Laserschwert";
          case -23:
            return "Weißes Laserschwert";
          case -22:
            return "Lila Laserschwert";
          case -21:
            return "Grünes Laserschwert";
          case -20:
            return "Rotes Laserschwert";
          case -19:
            return "Blaues Laserschwert";
          case -18:
            return "Kupferbogen";
          case -17:
            return "Kupferhammer";
          case -16:
            return "Kupferaxt";
          case -15:
            return "Kupferkurzschwert";
          case -14:
            return "Kupferbreitschwert";
          case -13:
            return "Kupferspitzhacke";
          case -12:
            return "Silberbogen";
          case -11:
            return "Silberhammer";
          case -10:
            return "Silberaxt";
          case -9:
            return "Silberkurzschwert";
          case -8:
            return "Silberbreitschwert";
          case -7:
            return "Silberspitzhacke";
          case -6:
            return "Goldbogen";
          case -5:
            return "Goldhammer";
          case -4:
            return "Goldaxt";
          case -3:
            return "Goldkurzschwert";
          case -2:
            return "Goldbreitschwert";
          case -1:
            return "Goldspitzhacke";
          case 1:
            return "Eisenspitzhacke";
          case 2:
            return "Dreckblock";
          case 3:
            return "Steinblock";
          case 4:
            return "Eisenbreitschwert";
          case 5:
            return "Pilz";
          case 6:
            return "Eisenkurzschwert";
          case 7:
            return "Eisenhammer";
          case 8:
            return "Fackel";
          case 9:
            return "Holz";
          case 10:
            return "Eisenaxt";
          case 11:
            return "Eisenerz";
          case 12:
            return "Kupfererz";
          case 13:
            return "Golderz";
          case 14:
            return "Silbererz";
          case 15:
            return "Kupferuhr";
          case 16:
            return "Silberuhr";
          case 17:
            return "Golduhr";
          case 18:
            return "Taucheruhr";
          case 19:
            return "Goldbarren";
          case 20:
            return "Kupferbarren";
          case 21:
            return "Silberbarren";
          case 22:
            return "Eisenbarren";
          case 23:
            return "Glibber";
          case 24:
            return "Holzschwert";
          case 25:
            return "Holztür";
          case 26:
            return "Steinwand";
          case 27:
            return "Eichel";
          case 28:
            return "Schwacher Heiltrank";
          case 29:
            return "Lebenskristall";
          case 30:
            return "Dreckwand";
          case 31:
            return "Flasche";
          case 32:
            return "Holztisch";
          case 33:
            return "Schmelzofen";
          case 34:
            return "Holzstuhl";
          case 35:
            return "Eisenamboss";
          case 36:
            return "Werkbank";
          case 37:
            return "Schutzbrille";
          case 38:
            return "Linse";
          case 39:
            return "Holzbogen";
          case 40:
            return "Holzpfeil";
          case 41:
            return "Flammenpfeil";
          case 42:
            return "Shuriken";
          case 43:
            return "Verdächtig aussehendes Auge";
          case 44:
            return "Dämonenbogen";
          case 45:
            return "Kriegsaxt der Nacht";
          case 46:
            return "Schrecken des Tages";
          case 47:
            return "Unheiliger Pfeil";
          case 48:
            return "Truhe";
          case 49:
            return "Wiederbelebungsband";
          case 50:
            return "Magischer Spiegel";
          case 51:
            return "Jester's Pfeil";
          case 52:
            return "Engelsstatue";
          case 53:
            return "Wolke in einer Flasche";
          case 54:
            return "Hermes-Stiefel";
          case 55:
            return "Verzauberter Bumerang";
          case 56:
            return "Dämoniterz";
          case 57:
            return "Dämonitbarren";
          case 58:
            return "Herz";
          case 59:
            return "Verderbte Saat";
          case 60:
            return "Ekelpilz";
          case 61:
            return "Ebensteinblock";
          case 62:
            return "Grassaat";
          case 63:
            return "Sonnenblume";
          case 64:
            return "Ekeldorn";
          case 65:
            return "Sternenwut";
          case 66:
            return "Reinigungspulver";
          case 67:
            return "Ekelpulver";
          case 68:
            return "Verfaulter Fleischbrocken";
          case 69:
            return "Wurmzahn";
          case 70:
            return "Wurmköder";
          case 71:
            return "Kupfermünze";
          case 72:
            return "Silbermünze";
          case 73:
            return "Goldmünze";
          case 74:
            return "Platinmünze";
          case 75:
            return "Sternschnuppe";
          case 76:
            return "Kupferbeinschützer";
          case 77:
            return "Eisenbeinschützer";
          case 78:
            return "Silberbeinschützer";
          case 79:
            return "Goldbeinschützer";
          case 80:
            return "Kupferkettenhemd";
          case 81:
            return "Eisenkettenhemd";
          case 82:
            return "Silberkettenhemd";
          case 83:
            return "Goldkettenhemd";
          case 84:
            return "Greifhaken ";
          case 85:
            return "Eisenkette";
          case 86:
            return "Schattenschuppe";
          case 87:
            return "Sparschwein";
          case 88:
            return "Bergmannshelm";
          case 89:
            return "Kupferhelm";
          case 90:
            return "Eisenhelm";
          case 91:
            return "Silberhelm";
          case 92:
            return "Goldhelm";
          case 93:
            return "Holzwand";
          case 94:
            return "Holzklappe";
          case 95:
            return "Steinschlosspistole";
          case 96:
            return "Muskete";
          case 97:
            return "Musketenkugel";
          case 98:
            return "Minihai";
          case 99:
            return "Eisenbogen";
          case 100:
            return "Schattenbeinschützer";
          case 101:
            return "Schattenschuppenhemd";
          case 102:
            return "Schattenhelm";
          case 103:
            return "Albtraum-Spitzhacke";
          case 104:
            return "Zerschmetterer";
          case 105:
            return "Kerze";
          case 106:
            return "Kupferkronleuchter";
          case 107:
            return "Silberkronleuchter";
          case 108:
            return "Goldkronleuchter";
          case 109:
            return "Mana-Kristall";
          case 110:
            return "Schwacher Manatrank";
          case 111:
            return "Sternenkraftband";
          case 112:
            return "Feuerblume";
          case 113:
            return "Magische Rakete";
          case 114:
            return "Dreckrute";
          case 115:
            return "Lichtkugel";
          case 116:
            return "Meteorit";
          case 117:
            return "Meteoritenbarren";
          case 118:
            return "Haken";
          case 119:
            return "Flamarang";
          case 120:
            return "Geschmolzene Wut";
          case 121:
            return "Feuriges Großschwert";
          case 122:
            return "Geschmolzene Spitzhacke";
          case 123:
            return "Meteorhelm";
          case 124:
            return "Meteoranzug";
          case 125:
            return "Meteor Leggings";
          case 126:
            return "Flaschenwasser";
          case (int) sbyte.MaxValue:
            return "Weltraumpistole";
          case 128:
            return "Raketenstiefel";
          case 129:
            return "Grauer Ziegel";
          case 130:
            return "Graue Ziegelwand";
          case 131:
            return "Roter Ziegel";
          case 132:
            return "Rote Ziegelwand";
          case 133:
            return "Lehmblock";
          case 134:
            return "Blauer Ziegel";
          case 135:
            return "Blaue Ziegelwand";
          case 136:
            return "Kettenlaterne";
          case 137:
            return "Grüner Ziegel";
          case 138:
            return "Grüne Ziegelwand";
          case 139:
            return "Rosa Ziegel";
          case 140:
            return "Rosa Ziegelwand";
          case 141:
            return "Goldziegel";
          case 142:
            return "Goldene Ziegelwand";
          case 143:
            return "Silberziegel";
          case 144:
            return "Silberne Ziegelwand";
          case 145:
            return "Kupferziegel";
          case 146:
            return "Kupferne Ziegelwand";
          case 147:
            return "Stachel";
          case 148:
            return "Wasserkerze";
          case 149:
            return "Buch";
          case 150:
            return "Spinnennetz";
          case 151:
            return "Nekrohelm";
          case 152:
            return "Nekro-Brustplatte";
          case 153:
            return "Nekro-Beinschützer";
          case 154:
            return "Knochen";
          case 155:
            return "Muramasa";
          case 156:
            return "Kobaltschild";
          case 157:
            return "Aqua-Zepter";
          case 158:
            return "Glückshufeisen";
          case 159:
            return "Leuchtend roter Ballon";
          case 160:
            return "Harpune";
          case 161:
            return "Stachelball";
          case 162:
            return "Ball des Schmerzes";
          case 163:
            return "Blauer Mond";
          case 164:
            return "Pistole";
          case 165:
            return "Wasserbolzen";
          case 166:
            return "Bombe";
          case 167:
            return "Dynamit";
          case 168:
            return "Granate";
          case 169:
            return "Sandblock";
          case 170:
            return "Glas";
          case 171:
            return "Spruchschild";
          case 172:
            return "Aschenblock";
          case 173:
            return "Obsidian";
          case 174:
            return "Höllenstein";
          case 175:
            return "Höllenstein-Barren";
          case 176:
            return "Schlammblock";
          case 177:
            return "Saphir";
          case 178:
            return "Rubin";
          case 179:
            return "Smaragd";
          case 180:
            return "Topas";
          case 181:
            return "Amethyst";
          case 182:
            return "Diamant";
          case 183:
            return "Glühender Pilz";
          case 184:
            return "Stern";
          case 185:
            return "Efeupeitsche";
          case 186:
            return "Schilfrohr";
          case 187:
            return "Flosse";
          case 188:
            return "Heiltrank";
          case 189:
            return "Manatrank";
          case 190:
            return "Grasklinge";
          case 191:
            return "Dornen-Chakram";
          case 192:
            return "Obsidianziegel";
          case 193:
            return "Obsidianschädel";
          case 194:
            return "Pilzgras-Saat";
          case 195:
            return "Dschungelgras-Saat";
          case 196:
            return "Holzhammer";
          case 197:
            return "Sternenkanone";
          case 198:
            return "Blaue Laserklinge";
          case 199:
            return "Rote Laserklinge";
          case 200:
            return "Grüne Laserklinge";
          case 201:
            return "Lila Laserklinge";
          case 202:
            return "Weiße Laserklinge";
          case 203:
            return "Gelbe Laserklinge";
          case 204:
            return "Meteor-Hamaxt";
          case 205:
            return "Leerer Eimer";
          case 206:
            return "Wassereimer";
          case 207:
            return "Lavaeimer";
          case 208:
            return "Dschungelrose";
          case 209:
            return "Hornissenstachel";
          case 210:
            return "Weinrebe";
          case 211:
            return "Wilde Klauen";
          case 212:
            return "Fusskette des Windes";
          case 213:
            return "Stab des Nachwachsens";
          case 214:
            return "Höllensteinziegel";
          case 215:
            return "Furzkissen";
          case 216:
            return "Fessel";
          case 217:
            return "Geschmolzene Hamaxt";
          case 218:
            return "Flammenpeitsche";
          case 219:
            return "Phoenix-Blaster";
          case 220:
            return "Sonnenwut";
          case 221:
            return "Höllenschmiede";
          case 222:
            return "Tontopf";
          case 223:
            return "Geschenk der Natur";
          case 224:
            return "Bett";
          case 225:
            return "Seide";
          case 226:
            return "Schwacher Wiederherstellungstrank";
          case 227:
            return "Wiederherstellungstrank";
          case 228:
            return "Dschungelhut";
          case 229:
            return "Dschungelhemd";
          case 230:
            return "Dschungelhosen";
          case 231:
            return "Geschmolzener Helm";
          case 232:
            return "Geschmolzene Brustplatte";
          case 233:
            return "Geschmolzene Beinschützer";
          case 234:
            return "Meteorenschuss";
          case 235:
            return "Haftbombe";
          case 236:
            return "Schwarze Linsen";
          case 237:
            return "Sonnenbrille";
          case 238:
            return "Zaubererhut";
          case 239:
            return "Zylinderhut";
          case 240:
            return "Smokinghemd";
          case 241:
            return "Smokinghosen";
          case 242:
            return "Sommerhut";
          case 243:
            return "Hasenkapuze";
          case 244:
            return "Klempnerhut";
          case 245:
            return "Klempnerhemd";
          case 246:
            return "Klempnerhosen";
          case 247:
            return "Heldenhut";
          case 248:
            return "Heldenhemd";
          case 249:
            return "Heldenhosen";
          case 250:
            return "Fischglas";
          case 251:
            return "Archäologenhut";
          case 252:
            return "Archäologenjacke";
          case 253:
            return "Archäologenhosen";
          case 254:
            return "Schwarzer Farbstoff";
          case (int) byte.MaxValue:
            return "Violetter Farbstoff";
          case 256:
            return "Ninja-Kapuze";
          case 257:
            return "Ninjahemd";
          case 258:
            return "Ninjahosen";
          case 259:
            return "Leder";
          case 260:
            return "Roter Hut";
          case 261:
            return "Goldfisch";
          case 262:
            return "Robe";
          case 263:
            return "Roboterhut";
          case 264:
            return "Goldkrone";
          case 265:
            return "Höllenfeuer-Pfeil";
          case 266:
            return "Sandgewehr";
          case 267:
            return "Guide-Voodoopuppe";
          case 268:
            return "Taucherhelm";
          case 269:
            return "Vertrautes Hemd";
          case 270:
            return "Vertraute Hosen";
          case 271:
            return "Vertraute Frisur";
          case 272:
            return "Dämonensense";
          case 273:
            return "Klinge der Nacht";
          case 274:
            return "Dunkle Lanze";
          case 275:
            return "Koralle";
          case 276:
            return "Kaktus";
          case 277:
            return "Dreizack";
          case 278:
            return "Silbergeschoss";
          case 279:
            return "Wurfmesser";
          case 280:
            return "Speer";
          case 281:
            return "Blasrohr";
          case 282:
            return "Leuchtstab";
          case 283:
            return "Saat";
          case 284:
            return "Holzbumerang";
          case 285:
            return "Schnürsenkelkappe";
          case 286:
            return "Klebriger Leuchtstab";
          case 287:
            return "Giftmesser";
          case 288:
            return "Obsidianhaut-Trank";
          case 289:
            return "Wiederbelebungstrank";
          case 290:
            return "Flinkheitstrank";
          case 291:
            return "Kiementrank";
          case 292:
            return "Eisenhaut-Trank";
          case 293:
            return "Mana-Wiederherstellungstrank";
          case 294:
            return "Magiekraft-Trank";
          case 295:
            return "Federsturz-Trank";
          case 296:
            return "Höhlenforschertrank";
          case 297:
            return "Unsichtbarkeitstrank";
          case 298:
            return "Strahlentrank";
          case 299:
            return "Nachteulentrank";
          case 300:
            return "Kampftrank";
          case 301:
            return "Dornentrank";
          case 302:
            return "Wasserlauftrank";
          case 303:
            return "Bogenschießtrank";
          case 304:
            return "Jägertrank";
          case 305:
            return "Gravitationstrank";
          case 306:
            return "Goldtruhe";
          case 307:
            return "Tagesblumensaat";
          case 308:
            return "Mondscheinsaat";
          case 309:
            return "Leuchtwurzel-Saat";
          case 310:
            return "Todeskraut-Saat";
          case 311:
            return "Wasserblatt-Saat";
          case 312:
            return "Feuerblüten-Saat";
          case 313:
            return "Tagesblume";
          case 314:
            return "Mondglanz";
          case 315:
            return "Leuchtwurzel";
          case 316:
            return "Todeskraut";
          case 317:
            return "Wasserblatt";
          case 318:
            return "Feuerblüte";
          case 319:
            return "Haifinne";
          case 320:
            return "Feder";
          case 321:
            return "Grabstein";
          case 322:
            return "Pantomimen-Maske";
          case 323:
            return "Ameisenlöwenkiefer";
          case 324:
            return "Illegale Gewehrteile";
          case 325:
            return "Hemd des Arztes";
          case 326:
            return "Hosen des Arztes";
          case 327:
            return "Goldener Schlüssel";
          case 328:
            return "Schattentruhe";
          case 329:
            return "Schattenschlüssel";
          case 330:
            return "Obsidianziegelwand";
          case 331:
            return "Dschungelsporen";
          case 332:
            return "Webstuhl";
          case 333:
            return "Piano";
          case 334:
            return "Kommode";
          case 335:
            return "Sitzbank";
          case 336:
            return "Badewanne";
          case 337:
            return "Rotes Banner";
          case 338:
            return "Grünes Banner";
          case 339:
            return "Blaues Banner";
          case 340:
            return "Gelbes Banner";
          case 341:
            return "Laternenpfahl";
          case 342:
            return "Petroleumfackel";
          case 343:
            return "Fass";
          case 344:
            return "Chinesische Laterne";
          case 345:
            return "Kochtopf";
          case 346:
            return "Tresor";
          case 347:
            return "Schädellaterne";
          case 348:
            return "Mülleimer";
          case 349:
            return "Kandelaber";
          case 350:
            return "Rosa Vase";
          case 351:
            return "Krug";
          case 352:
            return "Gärbottich";
          case 353:
            return "Bier";
          case 354:
            return "Bücherregal";
          case 355:
            return "Thron";
          case 356:
            return "Schüssel";
          case 357:
            return "Schüssel mit Suppe";
          case 358:
            return "Toilette";
          case 359:
            return "Standuhr";
          case 360:
            return "Rüstungsstatue";
          case 361:
            return "Goblin-Kampfstandarte";
          case 362:
            return "Zerfetzter Stoff";
          case 363:
            return "Sägewerk";
          case 364:
            return "Kobalterz";
          case 365:
            return "Mithrilerz";
          case 366:
            return "Adamantiterz";
          case 367:
            return "Pwnhammer";
          case 368:
            return "Excalibur";
          case 369:
            return "Heilige Saat";
          case 370:
            return "Ebensandblock";
          case 371:
            return "Kobalthut";
          case 372:
            return "Kobalthelm";
          case 373:
            return "Kobalt-Maske";
          case 374:
            return "Kobalt-Brustplatte";
          case 375:
            return "Kobalt-Gamaschen";
          case 376:
            return "Mithril-Kapuze";
          case 377:
            return "Mithril-Helm";
          case 378:
            return "Mithrilhut";
          case 379:
            return "Mithril-Kettenhemd";
          case 380:
            return "Mithril-Beinschützer";
          case 381:
            return "Kobaltbarren";
          case 382:
            return "Mithrilbarren";
          case 383:
            return "Kobalt-Kettensäge";
          case 384:
            return "Mithril-Kettensäge";
          case 385:
            return "Kobaltbohrer";
          case 386:
            return "Mithrilbohrer";
          case 387:
            return "Adamantit-Kettensäge";
          case 388:
            return "Adamantitbohrer";
          case 389:
            return "Dao von Pow";
          case 390:
            return "Mithril-Hellebarde";
          case 391:
            return "Adamantitbarren";
          case 392:
            return "Glaswand";
          case 393:
            return "Kompass";
          case 394:
            return "Tauchausrüstung";
          case 395:
            return "GPS";
          case 396:
            return "Obsidian-Hufeisen";
          case 397:
            return "Obsidianschild";
          case 398:
            return "Tüftler-Werkstatt";
          case 399:
            return "Wolke in einem Ballon";
          case 400:
            return "Adamantit-Kopfschutz";
          case 401:
            return "Adamantit-Helm";
          case 402:
            return "Adamantit-Maske";
          case 403:
            return "Adamantit-Brustplatte";
          case 404:
            return "Adamantit-Gamaschen";
          case 405:
            return "Geisterstiefel";
          case 406:
            return "Adamantit-Gleve";
          case 407:
            return "Werkzeuggürtel";
          case 408:
            return "Perlsandblock";
          case 409:
            return "Perlsteinblock";
          case 410:
            return "Bergbauhemd";
          case 411:
            return "Bergbauhosen";
          case 412:
            return "Perlsteinziegel";
          case 413:
            return "Schillernder Ziegel";
          case 414:
            return "Schlammsteinziegel";
          case 415:
            return "Kobaltziegel";
          case 416:
            return "Mithrilziegel";
          case 417:
            return "Perlstein-Ziegelwand";
          case 418:
            return "Schillernde Ziegelwand";
          case 419:
            return "Schlammstein-Ziegelwand";
          case 420:
            return "Kobalt-Ziegelwand";
          case 421:
            return "Mithril-Ziegelwand";
          case 422:
            return "Heiliges Wasser";
          case 423:
            return "Unheiliges Wasser";
          case 424:
            return "Schlickblock";
          case 425:
            return "Feenglocke";
          case 426:
            return "Schmetterklinge";
          case 427:
            return "Blaue Fackel";
          case 428:
            return "Rote Fackel";
          case 429:
            return "Grüne Fackel";
          case 430:
            return "Lila Fackel";
          case 431:
            return "Weiße Fackel";
          case 432:
            return "Gelbe Fackel";
          case 433:
            return "Dämonenfackel";
          case 434:
            return "Automatiksturmwaffe";
          case 435:
            return "Kobaltrepetierer";
          case 436:
            return "Mithrilrepetierer";
          case 437:
            return "Doppel-Greifhaken";
          case 438:
            return "Sternstatue";
          case 439:
            return "Schwertstatue";
          case 440:
            return "Schleimstatue";
          case 441:
            return "Goblinstatue";
          case 442:
            return "Schildstatue";
          case 443:
            return "Fledermausstatue";
          case 444:
            return "Fischstatue";
          case 445:
            return "Hasenstatue";
          case 446:
            return "Skelettstatue";
          case 447:
            return "Sensenmannstatue";
          case 448:
            return "Frauenstatue";
          case 449:
            return "Impstatue";
          case 450:
            return "Wasserspeier-Statue";
          case 451:
            return "Vanitasstatue";
          case 452:
            return "Hornissenstatue";
          case 453:
            return "Bombenstatue";
          case 454:
            return "Krabbenstatue";
          case 455:
            return "Hammerstatue";
          case 456:
            return "Trankstatue";
          case 457:
            return "Speerstatue";
          case 458:
            return "Kreuzstatue";
          case 459:
            return "Quallenstatue";
          case 460:
            return "Bogenstatue";
          case 461:
            return "Bumerangstatue";
          case 462:
            return "Stiefelstatue";
          case 463:
            return "Truhenstatue";
          case 464:
            return "Vogelstatue";
          case 465:
            return "Axtstatue";
          case 466:
            return "Verderbnisstatue";
          case 467:
            return "Baumstatue";
          case 468:
            return "Amboss-Statue";
          case 469:
            return "Spitzhackenstatue";
          case 470:
            return "Pilzstatue";
          case 471:
            return "Augapfelstatue";
          case 472:
            return "Säulenstatue";
          case 473:
            return "Herzstatue";
          case 474:
            return "Topfstatue";
          case 475:
            return "Sonnenblumenstatue";
          case 476:
            return "Königstatue";
          case 477:
            return "Königinstatue";
          case 478:
            return "Piranhastatue";
          case 479:
            return "Plankenwand";
          case 480:
            return "Holzbalken";
          case 481:
            return "Adamantitrepetierer";
          case 482:
            return "Adamantitschwert";
          case 483:
            return "Kobaltschwert";
          case 484:
            return "Mithrilschwert";
          case 485:
            return "Mondzauber";
          case 486:
            return "Lineal";
          case 487:
            return "Kristallkugel";
          case 488:
            return "Diskokugel";
          case 489:
            return "Siegel des Magiers";
          case 490:
            return "Siegel des Kriegers";
          case 491:
            return "Siegel des Bogenschützen";
          case 492:
            return "Dämonenflügel";
          case 493:
            return "Engelsflügel";
          case 494:
            return "Magische Harfe";
          case 495:
            return "Regenbogenrute";
          case 496:
            return "Eisrute";
          case 497:
            return "Neptuns Muschel";
          case 498:
            return "Schaufensterpuppe";
          case 499:
            return "Großer Heiltrank";
          case 500:
            return "Großer Manatrank";
          case 501:
            return "Pixie-Staub";
          case 502:
            return "Kristallscherbe";
          case 503:
            return "Clownshut";
          case 504:
            return "Clownshemd";
          case 505:
            return "Clownshosen";
          case 506:
            return "Flammenwerfer";
          case 507:
            return "Glocke";
          case 508:
            return "Harfe";
          case 509:
            return "Schraubenschlüssel";
          case 510:
            return "Kabelcutter";
          case 511:
            return "Aktiver Steinblock";
          case 512:
            return "Inaktiver Steinblock";
          case 513:
            return "Hebel";
          case 514:
            return "Lasergewehr";
          case 515:
            return "Kristallgeschoss";
          case 516:
            return "Heiliger Pfeil";
          case 517:
            return "Magischer Dolch";
          case 518:
            return "Kristallsturm";
          case 519:
            return "Verfluchte Flammen";
          case 520:
            return "Seele des Lichts";
          case 521:
            return "Seele der Nacht";
          case 522:
            return "Verfluchte Flamme";
          case 523:
            return "Verfluchte Fackel";
          case 524:
            return "Adamantitschmiede";
          case 525:
            return "Mithrilamboss";
          case 526:
            return "Horn des Einhorns";
          case 527:
            return "Dunkle Scherbe";
          case 528:
            return "Lichtscherbe";
          case 529:
            return "Rote Druckplatte";
          case 530:
            return "Kabel";
          case 531:
            return "Buch der Flüche";
          case 532:
            return "Sternenumhang";
          case 533:
            return "Maxihai";
          case 534:
            return "Schrotflinte";
          case 535:
            return "Stein der Weisen";
          case 536:
            return "Titanhandschuh";
          case 537:
            return "Kobalt-Naginata";
          case 538:
            return "Schalter";
          case 539:
            return "Pfeilfalle";
          case 540:
            return "Felsbrocken";
          case 541:
            return "Grüne Druckplatte";
          case 542:
            return "Graue Druckplatte";
          case 543:
            return "Braune Druckplatte";
          case 544:
            return "Mechanisches Auge";
          case 545:
            return "Verfluchter Pfeil";
          case 546:
            return "Verfluchtes Geschoss";
          case 547:
            return "Seele des Schreckens";
          case 548:
            return "Seele der Macht";
          case 549:
            return "Seele der Einsicht";
          case 550:
            return "Gungnir";
          case 551:
            return "Heiliger Plattenpanzer";
          case 552:
            return "Heilige Beinschützer";
          case 553:
            return "Heiliger Helm";
          case 554:
            return "Kreuzhalskette";
          case 555:
            return "Mana-Blume";
          case 556:
            return "Mechanischer Wurm";
          case 557:
            return "Mechanischer Schaedel";
          case 558:
            return "Heiliger Kopfschutz";
          case 559:
            return "Heilige Maske";
          case 560:
            return "Schleimkrone";
          case 561:
            return "Lichtscheibe";
          case 562:
            return "Musikbox (Tag in der Oberwelt)";
          case 563:
            return "Musikbox (Gespenstisch)";
          case 564:
            return "Musikbox (Nacht)";
          case 565:
            return "Musikbox (Titel)";
          case 566:
            return "Musikbox (Unterirdisch)";
          case 567:
            return "Musikbox (Boss 1)";
          case 568:
            return "Musikbox (Dschungel)";
          case 569:
            return "Musikbox (Verderben)";
          case 570:
            return "Musikbox (Unterirdisches Verderben)";
          case 571:
            return "Musikbox (Das Heilige)";
          case 572:
            return "Musikbox (Boss 2)";
          case 573:
            return "Musikbox (Unterirdisches Heiliges)";
          case 574:
            return "Musikbox (Boss 3)";
          case 575:
            return "Seele des Flugs";
          case 576:
            return "Musikbox";
          case 577:
            return "Dämonitziegel";
          case 578:
            return "Heiliger Repetierer";
          case 579:
            return "Hamdrax";
          case 580:
            return "Sprengstoffe";
          case 581:
            return "Einlasspumpe";
          case 582:
            return "Auslasspumpe";
          case 583:
            return "1-Sekunden-Timer";
          case 584:
            return "3-Sekunden-Timer";
          case 585:
            return "5-Sekunden-Timer";
          case 586:
            return "Candy Cane-Block";
          case 587:
            return "Candy Cane-Wand";
          case 588:
            return "Weihnachtsmütze";
          case 589:
            return "Santa Shirt";
          case 590:
            return "von Santa Pants";
          case 591:
            return "Grüner Candy Cane-Block";
          case 592:
            return "Grüne Candy Cane-Wand";
          case 593:
            return "Schnee-Block";
          case 594:
            return "Schneeziegel";
          case 595:
            return "Schnee-Ziegelwand";
          case 596:
            return "Blaues Licht";
          case 597:
            return "Rotes Licht";
          case 598:
            return "Grünes Licht";
          case 599:
            return "Blaue Gegenwart";
          case 600:
            return "Grüne Gegenwart";
          case 601:
            return "Gelbe Gegenwart";
          case 602:
            return "Schneekugel";
          case 603:
            return "Kohl";
          case 604:
            return "Drachenmaske";
          case 605:
            return "Titanhelm";
          case 606:
            return "Spektral-Kopfbedeckung";
          case 607:
            return "Drachen-Brustpanzer";
          case 608:
            return "Titanrüstung";
          case 609:
            return "Spektralrüstung";
          case 610:
            return "Drachen-Beinschienen";
          case 611:
            return "Titanleggings";
          case 612:
            return "Spektralschurz";
          case 613:
            return "Tizona";
          case 614:
            return "Tonbogiri";
          case 615:
            return "Sharanga";
          case 616:
            return "Spektralpfeil";
          case 617:
            return "Vulkan Repeater";
          case 618:
            return "Vulkanbolzen";
          case 619:
            return "Verdächtig aussehender Schädel";
          case 620:
            return "Seele des Verderbens";
          case 621:
            return "Petrischale";
          case 622:
            return "Bienenwabe";
          case 623:
            return "Phiole mit Blut";
          case 624:
            return "Wolfszahn";
          case 625:
            return "Gehirn";
          case 626:
            return "Spieluhr (Wüste)";
          case 627:
            return "Spieluhr (Weltall)";
          case 628:
            return "Spieluhr (Tutorial)";
          case 629:
            return "Spieluhr (Boss 4)";
          case 630:
            return "Spieluhr (Ozean)";
          case 631:
            return "Spieluhr (Schnee)";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case -24:
            return "Spada laser gialla";
          case -23:
            return "Spada laser bianca";
          case -22:
            return "Spada laser viola";
          case -21:
            return "Spada laser verde";
          case -20:
            return "Spada laser rossa";
          case -19:
            return "Spada laser blu";
          case -18:
            return "Arco di rame";
          case -17:
            return "Martello di rame";
          case -16:
            return "Ascia di rame";
          case -15:
            return "Spada corta di rame";
          case -14:
            return "Spadone di rame";
          case -13:
            return "Piccone di rame";
          case -12:
            return "Arco d'argento";
          case -11:
            return "Martello d'argento";
          case -10:
            return "Ascia d'argento";
          case -9:
            return "Spada corta d'argento";
          case -8:
            return "Spadone d'argento";
          case -7:
            return "Piccone d'argento";
          case -6:
            return "Arco d'oro";
          case -5:
            return "Martello d'oro";
          case -4:
            return "Ascia d'oro";
          case -3:
            return "Spada corta d'oro";
          case -2:
            return "Spadone d'oro";
          case -1:
            return "Piccone d'oro";
          case 1:
            return "Piccone di ferro";
          case 2:
            return "Blocco di terra";
          case 3:
            return "Blocco di pietra";
          case 4:
            return "Spadone di ferro";
          case 5:
            return "Fungo";
          case 6:
            return "Spada corta di ferro";
          case 7:
            return "Martello di ferro";
          case 8:
            return "Torcia";
          case 9:
            return "Legno";
          case 10:
            return "Ascia di ferro";
          case 11:
            return "Minerale di ferro";
          case 12:
            return "Minerale di rame";
          case 13:
            return "Minerale d'oro";
          case 14:
            return "Minerale d'argento";
          case 15:
            return "Orologio di rame";
          case 16:
            return "Orologio d'argento";
          case 17:
            return "Orologio d'oro";
          case 18:
            return "Misuratore di profondità";
          case 19:
            return "Barra d'oro";
          case 20:
            return "Barra di rame";
          case 21:
            return "Barra d'argento";
          case 22:
            return "Barra di ferro";
          case 23:
            return "Gelatina";
          case 24:
            return "Spada di legno";
          case 25:
            return "Porta di legno";
          case 26:
            return "Muro di pietra";
          case 27:
            return "Ghianda";
          case 28:
            return "Pozione curativa inferiore";
          case 29:
            return "Cristallo di vita";
          case 30:
            return "Muro di terra";
          case 31:
            return "Bottiglia";
          case 32:
            return "Tavolo di legno";
          case 33:
            return "Fornace";
          case 34:
            return "Sedia di legno";
          case 35:
            return "Incudine di ferro";
          case 36:
            return "Banco da lavoro";
          case 37:
            return "Occhiali protettivi";
          case 38:
            return "Lenti";
          case 39:
            return "Arco di legno";
          case 40:
            return "Freccia di legno";
          case 41:
            return "Freccia infuocata";
          case 42:
            return "Shuriken";
          case 43:
            return "Occhio dallo sguardo sospetto";
          case 44:
            return "Arco demoniaco";
          case 45:
            return "Ascia da guerra della notte";
          case 46:
            return "Flagello di luce";
          case 47:
            return "Freccia empia";
          case 48:
            return "Cassa";
          case 49:
            return "Benda di rigenerazione";
          case 50:
            return "Specchio magico";
          case 51:
            return "Freccia del giullare";
          case 52:
            return "Statua dell'angelo";
          case 53:
            return "Nuvola in bottiglia";
          case 54:
            return "Stivali di Ermes";
          case 55:
            return "Boomerang incantato";
          case 56:
            return "Minerale demoniaco";
          case 57:
            return "Barra demoniaca";
          case 58:
            return "Cuore";
          case 59:
            return "Semi corrotti";
          case 60:
            return "Fungo disgustoso";
          case 61:
            return "Blocco pietra d'ebano";
          case 62:
            return "Semi d'erba";
          case 63:
            return "Girasole";
          case 64:
            return "Spina vile";
          case 65:
            return "Furia stellare";
          case 66:
            return "Polvere purificatrice";
          case 67:
            return "Polvere disgustosa";
          case 68:
            return "Ceppo marcio";
          case 69:
            return "Dente di verme";
          case 70:
            return "Esca di verme";
          case 71:
            return "Moneta di rame";
          case 72:
            return "Moneta d'argento";
          case 73:
            return "Moneta d'oro";
          case 74:
            return "Moneta di platino";
          case 75:
            return "Stella cadente";
          case 76:
            return "Schiniere di rame ";
          case 77:
            return "Schiniere di ferro";
          case 78:
            return "Schiniere d'argento";
          case 79:
            return "Schiniere d'oro";
          case 80:
            return "Maglia metallica di rame";
          case 81:
            return "Maglia metallica di ferro";
          case 82:
            return "Maglia metallica d'argento";
          case 83:
            return "Maglia metallica d'oro";
          case 84:
            return "Rampino";
          case 85:
            return "Catena di ferro";
          case 86:
            return "Scaglia d'ombra";
          case 87:
            return "Salvadanaio";
          case 88:
            return "Casco da minatore";
          case 89:
            return "Casco di rame";
          case 90:
            return "Casco di ferro";
          case 91:
            return "Casco d'argento";
          case 92:
            return "Casco d'oro";
          case 93:
            return "Muro di legno";
          case 94:
            return "Piattaforma di legno";
          case 95:
            return "Pistola a pietra focaia";
          case 96:
            return "Moschetto";
          case 97:
            return "Palla di moschetto";
          case 98:
            return "Minishark";
          case 99:
            return "Arco di ferro";
          case 100:
            return "Schiniere ombra";
          case 101:
            return "Armatura a scaglie ombra";
          case 102:
            return "Casco ombra";
          case 103:
            return "Piccone dell'incubo";
          case 104:
            return "Il Distruttore";
          case 105:
            return "Candela";
          case 106:
            return "Lampadario di rame";
          case 107:
            return "Lampadario d'argento";
          case 108:
            return "Lampadario d'oro";
          case 109:
            return "Cristallo mana";
          case 110:
            return "Pozione mana inferiore";
          case 111:
            return "Benda della forza stellare";
          case 112:
            return "Fiore di fuoco";
          case 113:
            return "Missile magico";
          case 114:
            return "Bastone di terra";
          case 115:
            return "Orbita di luce";
          case 116:
            return "Meteorite";
          case 117:
            return "Barra di meteorite";
          case 118:
            return "Uncino";
          case 119:
            return "Flamarang";
          case 120:
            return "Furia fusa";
          case 121:
            return "Spadone di fuoco";
          case 122:
            return "Piccone fuso";
          case 123:
            return "Casco meteorite";
          case 124:
            return "Tunica di meteorite";
          case 125:
            return "Gambali di meteorite";
          case 126:
            return "Acqua imbottigliata";
          case (int) sbyte.MaxValue:
            return "Spazio pistola";
          case 128:
            return "Stivali razzo";
          case 129:
            return "Mattone grigio";
          case 130:
            return "Muro grigio";
          case 131:
            return "Mattone rosso";
          case 132:
            return "Muro rosso";
          case 133:
            return "Blocco d'argilla";
          case 134:
            return "Mattone blu";
          case 135:
            return "Muro blu";
          case 136:
            return "Lanterna con catena";
          case 137:
            return "Mattone verde";
          case 138:
            return "Muro verde";
          case 139:
            return "Mattone rosa";
          case 140:
            return "Muro rosa";
          case 141:
            return "Mattone d'oro";
          case 142:
            return "Muro d'oro";
          case 143:
            return "Mattone d'argento";
          case 144:
            return "Muro d'argento";
          case 145:
            return "Mattone di rame";
          case 146:
            return "Muro di rame";
          case 147:
            return "Spina";
          case 148:
            return "Candela d'acqua";
          case 149:
            return "Libro";
          case 150:
            return "Ragnatela";
          case 151:
            return "Casco funebre";
          case 152:
            return "Pettorale funebre";
          case 153:
            return "Gambali funebri";
          case 154:
            return "Osso";
          case 155:
            return "Muramasa";
          case 156:
            return "Scudo di cobalto";
          case 157:
            return "Scettro d'acqua";
          case 158:
            return "Ferro di cavallo fortunato";
          case 159:
            return "Palloncino rosso brillante";
          case 160:
            return "Arpione";
          case 161:
            return "Palla chiodata";
          case 162:
            return "Palla del dolore";
          case 163:
            return "Luna blu";
          case 164:
            return "Pistola";
          case 165:
            return "Dardo d'acqua";
          case 166:
            return "Bomba";
          case 167:
            return "Dinamite";
          case 168:
            return "Granata";
          case 169:
            return "Blocco di sabbia";
          case 170:
            return "Vetro";
          case 171:
            return "Cartello";
          case 172:
            return "Blocco di cenere";
          case 173:
            return "Ossidiana";
          case 174:
            return "Pietra infernale";
          case 175:
            return "Barra di pietra infernale";
          case 176:
            return "Blocco di fango";
          case 177:
            return "Zaffiro";
          case 178:
            return "Rubino";
          case 179:
            return "Smeraldo";
          case 180:
            return "Topazio";
          case 181:
            return "Ametista";
          case 182:
            return "Diamante";
          case 183:
            return "Fungo luminoso";
          case 184:
            return "Stella";
          case 185:
            return "Frusta di edera";
          case 186:
            return "Canna per la respirazione";
          case 187:
            return "Pinna";
          case 188:
            return "Pozione curativa";
          case 189:
            return "Pozione mana";
          case 190:
            return "Spada di erba";
          case 191:
            return "Artiglio di Chakram";
          case 192:
            return "Mattone di ossidiana";
          case 193:
            return "Teschio di ossidiana";
          case 194:
            return "Semi di fungo";
          case 195:
            return "Semi dell'erba della giungla";
          case 196:
            return "Martello di legno";
          case 197:
            return "Cannone stellare";
          case 198:
            return "Spada laser blu";
          case 199:
            return "Spada laser rossa";
          case 200:
            return "Spada laser verde";
          case 201:
            return "Spada laser viola";
          case 202:
            return "Spada laser bianca";
          case 203:
            return "Spada laser gialla";
          case 204:
            return "Maglio di meteorite";
          case 205:
            return "Secchio vuoto";
          case 206:
            return "Secchio d'acqua";
          case 207:
            return "Secchio di lava";
          case 208:
            return "Rosa della giungla";
          case 209:
            return "Artiglio";
          case 210:
            return "Vite";
          case 211:
            return "Artigli bestiali";
          case 212:
            return "Cavigliera del vento";
          case 213:
            return "Bastone della ricrescita";
          case 214:
            return "Mattone di pietra infernale";
          case 215:
            return "Cuscino rumoroso";
          case 216:
            return "Grillo";
          case 217:
            return "Maglio fuso";
          case 218:
            return "Lanciatore di fiamma";
          case 219:
            return "Blaster della fenice";
          case 220:
            return "Furia del sole";
          case 221:
            return "Creazione degli inferi";
          case 222:
            return "Vaso di argilla";
          case 223:
            return "Dono della natura";
          case 224:
            return "Letto";
          case 225:
            return "Seta";
          case 226:
            return "Pozione di ripristino inferiore";
          case 227:
            return "Pozione di ripristino";
          case 228:
            return "Cappello della giungla";
          case 229:
            return "Camicia della giungla";
          case 230:
            return "Pantaloni della giungla";
          case 231:
            return "Casco fuso";
          case 232:
            return "Pettorale fuso";
          case 233:
            return "Schiniere fuso";
          case 234:
            return "Sparo di meteorite";
          case 235:
            return "Bomba appiccicosa";
          case 236:
            return "Lenti nere";
          case 237:
            return "Occhiali da sole";
          case 238:
            return "Cappello dello stregone";
          case 239:
            return "Cilindro";
          case 240:
            return "Camicia da smoking";
          case 241:
            return "Pantaloni da smoking";
          case 242:
            return "Cappello estivo";
          case 243:
            return "Cappuccio da coniglio";
          case 244:
            return "Cappello da idraulico";
          case 245:
            return "Camicia da idraulico";
          case 246:
            return "Pantaloni da idraulico";
          case 247:
            return "Cappello da eroe";
          case 248:
            return "Camicia da eroe";
          case 249:
            return "Pantaloni da eroe";
          case 250:
            return "Boccia dei pesci rossi";
          case 251:
            return "Cappello da archeologo";
          case 252:
            return "Giacca da archeologo";
          case 253:
            return "Pantaloni da archeologo";
          case 254:
            return "Tintura nera";
          case (int) byte.MaxValue:
            return "Tintura viola";
          case 256:
            return "Cappuccio ninja";
          case 257:
            return "Camicia ninja";
          case 258:
            return "Pantaloni ninja";
          case 259:
            return "Pelle";
          case 260:
            return "Cappello rosso";
          case 261:
            return "Pesce rosso";
          case 262:
            return "Mantello";
          case 263:
            return "Cappello da robot";
          case 264:
            return "Corona d'oro";
          case 265:
            return "Freccia di fuoco infernale";
          case 266:
            return "Pistola di sabbia";
          case 267:
            return "Bambola voodoo della guida";
          case 268:
            return "Casco da sommozzatore";
          case 269:
            return "Camicia comune";
          case 270:
            return "Pantaloni comuni";
          case 271:
            return "Parrucca comune";
          case 272:
            return "Falce demoniaca";
          case 273:
            return "Confine della notte";
          case 274:
            return "Lancia oscura";
          case 275:
            return "Corallo";
          case 276:
            return "Cactus";
          case 277:
            return "Tridente";
          case 278:
            return "Proiettile d'argento";
          case 279:
            return "Coltello da lancio";
          case 280:
            return "Lancia";
          case 281:
            return "Cerbottana";
          case 282:
            return "Bastone luminoso";
          case 283:
            return "Seme";
          case 284:
            return "Boomerang di legno";
          case 285:
            return "Aghetto";
          case 286:
            return "Bastone luminoso appiccicoso";
          case 287:
            return "Coltello avvelenato";
          case 288:
            return "Pozione pelle d'ossidiana";
          case 289:
            return "Pozione rigeneratrice";
          case 290:
            return "Pozione della rapidità";
          case 291:
            return "Pozione branchie";
          case 292:
            return "Pozione pelle di ferro";
          case 293:
            return "Pozione rigenerazione mana";
          case 294:
            return "Pozione potenza magica";
          case 295:
            return "Pozione caduta dolce";
          case 296:
            return "Pozione speleologo";
          case 297:
            return "Pozione invisibilità";
          case 298:
            return "Pozione splendore";
          case 299:
            return "Pozione civetta";
          case 300:
            return "Pozione battaglia";
          case 301:
            return "Pozione spine";
          case 302:
            return "Pozione per camminare sull'acqua";
          case 303:
            return "Pozione arciere";
          case 304:
            return "Pozione cacciatore";
          case 305:
            return "Pozione gravità";
          case 306:
            return "Cassa d'oro";
          case 307:
            return "Semi Fiordigiorno";
          case 308:
            return "Semi Splendiluna";
          case 309:
            return "Semi Lampeggiaradice";
          case 310:
            return "Semi Erbamorte";
          case 311:
            return "Semi Acquafoglia";
          case 312:
            return "Semi Fiordifuoco";
          case 313:
            return "Fiordigiorno";
          case 314:
            return "Splendiluna";
          case 315:
            return "Lampeggiaradice";
          case 316:
            return "Erbamorte";
          case 317:
            return "Acquafoglia";
          case 318:
            return "Fiordifuoco";
          case 319:
            return "Pinna di squalo";
          case 320:
            return "Piuma";
          case 321:
            return "Lapide";
          case 322:
            return "Maschera sosia";
          case 323:
            return "Mandibola di formicaleone";
          case 324:
            return "Parti di pistola illegale";
          case 325:
            return "Camicia da medico";
          case 326:
            return "Pantaloni da medico";
          case 327:
            return "Chiave d'oro";
          case 328:
            return "Cassa ombra";
          case 329:
            return "Chiave ombra";
          case 330:
            return "Muro di ossidiana";
          case 331:
            return "Spore della giungla";
          case 332:
            return "Telaio";
          case 333:
            return "Pianoforte";
          case 334:
            return "Cassettone";
          case 335:
            return "Panca";
          case 336:
            return "Vasca da bagno";
          case 337:
            return "Stendardo rosso";
          case 338:
            return "Stendardo verde";
          case 339:
            return "Stendardo blu";
          case 340:
            return "Stendardo giallo";
          case 341:
            return "Lampione";
          case 342:
            return "Torcia tiki";
          case 343:
            return "Barile";
          case 344:
            return "Lanterna cinese";
          case 345:
            return "Pentola";
          case 346:
            return "Caveau";
          case 347:
            return "Lanterna-teschio";
          case 348:
            return "Bidone";
          case 349:
            return "Candelabro";
          case 350:
            return "Vaso rosa";
          case 351:
            return "Boccale";
          case 352:
            return "Barilotto";
          case 353:
            return "Birra";
          case 354:
            return "Scaffale";
          case 355:
            return "Trono";
          case 356:
            return "Ciotola";
          case 357:
            return "Ciotola di zuppa";
          case 358:
            return "Toilette";
          case 359:
            return "Pendola";
          case 360:
            return "Statua armatura";
          case 361:
            return "Insegna di battaglia dei goblin";
          case 362:
            return "Abito a brandelli";
          case 363:
            return "Segheria";
          case 364:
            return "Minerale cobalto";
          case 365:
            return "Minerale mitrilio";
          case 366:
            return "Minerale adamantio";
          case 367:
            return "Martellone";
          case 368:
            return "Excalibur";
          case 369:
            return "Semi consacrati";
          case 370:
            return "Blocco sabbia d'ebano";
          case 371:
            return "Cappello di cobalto";
          case 372:
            return "Casco di cobalto";
          case 373:
            return "Maschera di cobalto";
          case 374:
            return "Corrazza di cobalto";
          case 375:
            return "Gambali di cobalto";
          case 376:
            return "Cappuccio di mitrilio";
          case 377:
            return "Casco di mitrilio";
          case 378:
            return "Cappello di mitrilio";
          case 379:
            return "Maglia metallica di mitrilio";
          case 380:
            return "Schiniere di mitrilio";
          case 381:
            return "Barra di cobalto";
          case 382:
            return "Barra di mitrilio";
          case 383:
            return "Motosega di cobalto";
          case 384:
            return "Motosega di mitrilio";
          case 385:
            return "Perforatrice di cobalto";
          case 386:
            return "Perforatrice di mitrilio";
          case 387:
            return "Motosega di adamantio";
          case 388:
            return "Perforatrice di adamantio";
          case 389:
            return "Frustona";
          case 390:
            return "Alabarda di mitrilio";
          case 391:
            return "Barra di adamantio";
          case 392:
            return "Muro di vetro";
          case 393:
            return "Bussola";
          case 394:
            return "Muta da sub";
          case 395:
            return "GPS";
          case 396:
            return "Ferro di cavallo di ossidiana";
          case 397:
            return "Scudo di ossidiana";
          case 398:
            return "Laboratorio dell'inventore";
          case 399:
            return "Nuvola in un palloncino";
          case 400:
            return "Copricapo di adamantio";
          case 401:
            return "Casco di adamantio";
          case 402:
            return "Maschera di adamantio";
          case 403:
            return "Corrazza di adamantio";
          case 404:
            return "Gambali di adamantio";
          case 405:
            return "Stivali da fantasma";
          case 406:
            return "Alabarda di adamantio";
          case 407:
            return "Cintura porta attrezzi";
          case 408:
            return "Blocco sabbiaperla";
          case 409:
            return "Blocco pietraperla";
          case 410:
            return "Camicia da minatore";
          case 411:
            return "Pantaloni da minatore";
          case 412:
            return "Mattone pietraperla";
          case 413:
            return "Mattone iridescente";
          case 414:
            return "Mattone pietrafango";
          case 415:
            return "Mattone cobalto";
          case 416:
            return "Mattone mitrilio";
          case 417:
            return "Muro di pietraperla";
          case 418:
            return "Muro di mattoni iridescenti";
          case 419:
            return "Muro di pietrafango";
          case 420:
            return "Muro di mattoni di cobalto";
          case 421:
            return "Muro di mattoni di mitrilio";
          case 422:
            return "Acquasanta";
          case 423:
            return "Acqua profana";
          case 424:
            return "Blocco insabbiato";
          case 425:
            return "Campana della fata";
          case 426:
            return "Lama del distruttore";
          case 427:
            return "Torcia blu";
          case 428:
            return "Torcia rossa";
          case 429:
            return "Torcia verde";
          case 430:
            return "Torcia viola";
          case 431:
            return "Torcia bianca";
          case 432:
            return "Torcia gialla";
          case 433:
            return "Torcia demoniaca";
          case 434:
            return "Fucile d'assalto automatico";
          case 435:
            return "Balestra automatica di cobalto";
          case 436:
            return "Balestra automatica di mitrilio";
          case 437:
            return "Gancio doppio";
          case 438:
            return "Statua stella";
          case 439:
            return "Statua spada";
          case 440:
            return "Statua slime";
          case 441:
            return "Statua goblin";
          case 442:
            return "Statua scudo";
          case 443:
            return "Statua pipistrello";
          case 444:
            return "Statua pesce";
          case 445:
            return "Statua coniglio";
          case 446:
            return "Statua scheletro";
          case 447:
            return "Statua mietitore";
          case 448:
            return "Statua donna";
          case 449:
            return "Statua diavoletto";
          case 450:
            return "Statua gargoyle";
          case 451:
            return "Statua tenebre";
          case 452:
            return "Statua calabrone";
          case 453:
            return "Statua bomba";
          case 454:
            return "Statua granchio";
          case 455:
            return "Statua martello";
          case 456:
            return "Statua pozione";
          case 457:
            return "Statua arpione";
          case 458:
            return "Statua croce";
          case 459:
            return "Statua medusa";
          case 460:
            return "Statua arco";
          case 461:
            return "Statua boomerang";
          case 462:
            return "Statua stivali";
          case 463:
            return "Statua cassa";
          case 464:
            return "Statua Uccello";
          case 465:
            return "Statua ascia";
          case 466:
            return "Statua corruzione";
          case 467:
            return "Statua albero";
          case 468:
            return "Statua incudine";
          case 469:
            return "Statua piccone";
          case 470:
            return "Statua fungo";
          case 471:
            return "Statua bulbo oculare";
          case 472:
            return "Statua colonna";
          case 473:
            return "Statua cuore";
          case 474:
            return "Statua pentola";
          case 475:
            return "Statua girasole";
          case 476:
            return "Statua re";
          case 477:
            return "Statua regina";
          case 478:
            return "Statua piranha";
          case 479:
            return "Muro impalcato";
          case 480:
            return "Trave di legno";
          case 481:
            return "Mietitore di adamantio";
          case 482:
            return "Spada di adamantio";
          case 483:
            return "Spada di cobalto";
          case 484:
            return "Spada di mitrilio";
          case 485:
            return "Amuleto della luna";
          case 486:
            return "Righello";
          case 487:
            return "Sfera di cristallo";
          case 488:
            return "Palla disco";
          case 489:
            return "Emblema dell'incantatore";
          case 490:
            return "Emblema del guerriero";
          case 491:
            return "Emblema del guardiaboschi";
          case 492:
            return "Ali del demone";
          case 493:
            return "Ali dell'angelo";
          case 494:
            return "Arpa magica";
          case 495:
            return "Bastone dell'arcobaleno";
          case 496:
            return "Bastone di ghiaccio";
          case 497:
            return "Conchiglia di Nettuno";
          case 498:
            return "Manichino";
          case 499:
            return "Pozione curativa superiore";
          case 500:
            return "Pozione mana superiore";
          case 501:
            return "Polvere di fata";
          case 502:
            return "Frammento di cristallo";
          case 503:
            return "Cappello da clown";
          case 504:
            return "Camicia da clown";
          case 505:
            return "Pantaloni da clown";
          case 506:
            return "Lanciafiamme";
          case 507:
            return "Campana";
          case 508:
            return "Arpa";
          case 509:
            return "Chiave inglese";
          case 510:
            return "Tagliacavi";
          case 511:
            return "Blocco di pietra attivo";
          case 512:
            return "Blocco di pietra non attivo";
          case 513:
            return "Leva";
          case 514:
            return "Fucile laser";
          case 515:
            return "Proiettile di cristallo";
          case 516:
            return "Freccia sacra";
          case 517:
            return "Pugnale magico";
          case 518:
            return "Tempesta di cristallo";
          case 519:
            return "Fiamme maledette";
          case 520:
            return "Anima della luce";
          case 521:
            return "Anima della notte";
          case 522:
            return "Fiamma maledetta";
          case 523:
            return "Torcia maledetta";
          case 524:
            return "Forgia di adamantio";
          case 525:
            return "Incudine di mitrilio";
          case 526:
            return "Corno di unicorno";
          case 527:
            return "Frammento oscuro";
          case 528:
            return "Frammento di luce";
          case 529:
            return "Piastra a pressione rossa";
          case 530:
            return "Cavo";
          case 531:
            return "Tomo incantato";
          case 532:
            return "Mantello stellato";
          case 533:
            return "Megashark";
          case 534:
            return "Fucile";
          case 535:
            return "Pietra filosofale";
          case 536:
            return "Guanto del Titano";
          case 537:
            return "Naginata di cobalto";
          case 538:
            return "Interruttore";
          case 539:
            return "Trappola dardi";
          case 540:
            return "Masso";
          case 541:
            return "Piastra a pressione verde";
          case 542:
            return "Piastra a pressione grigia";
          case 543:
            return "Piastra a pressione marrone";
          case 544:
            return "Occhio meccanico";
          case 545:
            return "Freccia maledetta";
          case 546:
            return "Proiettile maledetto";
          case 547:
            return "Anima del terrore";
          case 548:
            return "Anima del potere";
          case 549:
            return "Anima della visione";
          case 550:
            return "Gungnir";
          case 551:
            return "Armatura sacra";
          case 552:
            return "Schiniere sacro";
          case 553:
            return "Casco sacro";
          case 554:
            return "Collana con croce";
          case 555:
            return "Fiore di mana";
          case 556:
            return "Verme meccanico";
          case 557:
            return "Teschio meccanico";
          case 558:
            return "Copricapo sacro";
          case 559:
            return "Maschera sacra";
          case 560:
            return "Corona slime";
          case 561:
            return "Disco di luce";
          case 562:
            return "Carillon (Giornata mondiale)";
          case 563:
            return "Carillon (Mistero)";
          case 564:
            return "Carillon (Notte)";
          case 565:
            return "Carillon (Titolo)";
          case 566:
            return "Carillon (Sotterraneo)";
          case 567:
            return "Carillon (Boss 1)";
          case 568:
            return "Carillon (Giungla)";
          case 569:
            return "Carillon (Corruzione)";
          case 570:
            return "Carillon (Corruzione sotterranea)";
          case 571:
            return "Carillon (La Consacrazione)";
          case 572:
            return "Carillon (Boss 2)";
          case 573:
            return "Carillon (Consacrazione sotterranea)";
          case 574:
            return "Carillon (Boss 3)";
          case 575:
            return "Anima del volo";
          case 576:
            return "Carillon";
          case 577:
            return "Mattone demoniaco";
          case 578:
            return "Balestra automatica consacrata";
          case 579:
            return "Perforascia";
          case 580:
            return "Esplosivi";
          case 581:
            return "Pompa interna";
          case 582:
            return "Pompa esterna";
          case 583:
            return "Timer 1 secondo";
          case 584:
            return "Timer 3 secondi";
          case 585:
            return "Timer 5 secondi";
          case 586:
            return "Blocco Candy Cane";
          case 587:
            return "Muro Candy Cane";
          case 588:
            return "Cappello di Babbo Natale";
          case 589:
            return "Camicia di Babbo Natale";
          case 590:
            return "Pantaloni di Babbo Natale";
          case 591:
            return "Blocco verde Candy Cane";
          case 592:
            return "Muro verde Candy Cane";
          case 593:
            return "Blocco di neve";
          case 594:
            return "Mattone di neve";
          case 595:
            return "Muro di mattoni di neve";
          case 596:
            return "Luce blu";
          case 597:
            return "Luce rossa";
          case 598:
            return "Luce verde";
          case 599:
            return "Regalo blu";
          case 600:
            return "Regalo verde";
          case 601:
            return "Regalo giallo ";
          case 602:
            return "Sfera di neve";
          case 603:
            return "Cavolo";
          case 604:
            return "Maschera del Drago";
          case 605:
            return "Casco del Titano";
          case 606:
            return "Copricapo spettrale";
          case 607:
            return "Corazza del Drago";
          case 608:
            return "Armatura del Titano";
          case 609:
            return "Armatura spettrale";
          case 610:
            return "Schinieri del Drago";
          case 611:
            return "Gambali del Titano";
          case 612:
            return "Subligar spettrale";
          case 613:
            return "Tizona";
          case 614:
            return "Tonbogiri";
          case 615:
            return "Sharanga";
          case 616:
            return "Freccia spettrale";
          case 617:
            return "Balestra vulcanica";
          case 618:
            return "Dardo vulcanico";
          case 619:
            return "Teschio dallo sguardo sospetto";
          case 620:
            return "Anima della luce";
          case 621:
            return "Capsula di Petri";
          case 622:
            return "Nido d'ape";
          case 623:
            return "Fiala di sangue";
          case 624:
            return "Zanna di lupo";
          case 625:
            return "Cervello";
          case 626:
            return "Carillon (Deserto)";
          case 627:
            return "Carillon (Spazio)";
          case 628:
            return "Carillon (Tutorial)";
          case 629:
            return "Carillon (Boss 4)";
          case 630:
            return "Carillon (Oceano)";
          case 631:
            return "Carillon (Neve)";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case -24:
            return "Sabre laser jaune";
          case -23:
            return "Sabre laser blanc";
          case -22:
            return "Sabre laser violet";
          case -21:
            return "Sabre laser vert";
          case -20:
            return "Sabre laser rouge";
          case -19:
            return "Sabre laser bleu";
          case -18:
            return "Arc en cuivre";
          case -17:
            return "Marteau en cuivre";
          case -16:
            return "Hache en cuivre";
          case -15:
            return "Épée courte en cuivre";
          case -14:
            return "Épée longue en cuivre";
          case -13:
            return "Pioche en cuivre";
          case -12:
            return "Arc en argent";
          case -11:
            return "Marteau en argent";
          case -10:
            return "Hache en argent";
          case -9:
            return "Épée courte en argent";
          case -8:
            return "Épée longue en argent";
          case -7:
            return "Pioche en argent";
          case -6:
            return "Arc en or";
          case -5:
            return "Marteau en or";
          case -4:
            return "Hache en or";
          case -3:
            return "Épée courte en or";
          case -2:
            return "Épée longue en or";
          case -1:
            return "Pioche en or";
          case 1:
            return "Pioche en fer";
          case 2:
            return "Bloc de terre";
          case 3:
            return "Bloc de pierre";
          case 4:
            return "Épée longue en fer";
          case 5:
            return "Champignon";
          case 6:
            return "Épée courte en fer";
          case 7:
            return "Marteau en fer";
          case 8:
            return "Torche";
          case 9:
            return "Bois";
          case 10:
            return "Hache en fer";
          case 11:
            return "Minerai de fer";
          case 12:
            return "Minerai de cuivre";
          case 13:
            return "Minerai d'or";
          case 14:
            return "Minerai d'argent";
          case 15:
            return "Montre en cuivre";
          case 16:
            return "Montre en argent";
          case 17:
            return "Montre en or";
          case 18:
            return "Altimètre";
          case 19:
            return "Lingot d'or";
          case 20:
            return "Lingot de cuivre";
          case 21:
            return "Lingot d'argent";
          case 22:
            return "Lingot de fer";
          case 23:
            return "Gel";
          case 24:
            return "Épée en bois";
          case 25:
            return "Porte en bois";
          case 26:
            return "Mur en pierre";
          case 27:
            return "Gland";
          case 28:
            return "Faible potion de soin";
          case 29:
            return "Cristal de vie";
          case 30:
            return "Mur en terre";
          case 31:
            return "Bouteille";
          case 32:
            return "Table en bois";
          case 33:
            return "Fournaise";
          case 34:
            return "Chaise en bois";
          case 35:
            return "Enclume";
          case 36:
            return "Établi";
          case 37:
            return "Lunettes";
          case 38:
            return "Lentille";
          case 39:
            return "Arc en bois";
          case 40:
            return "Flèche en bois";
          case 41:
            return "Flèche enflammée";
          case 42:
            return "Shuriken";
          case 43:
            return "Œil observateur suspicieux";
          case 44:
            return "Arc démoniaque";
          case 45:
            return "Hache de guerre de la nuit";
          case 46:
            return "Fléau de lumière";
          case 47:
            return "Flèche impie";
          case 48:
            return "Coffre";
          case 49:
            return "Anneau de régénération";
          case 50:
            return "Miroir magique";
          case 51:
            return "Flèche du bouffon";
          case 52:
            return "Statue d'ange";
          case 53:
            return "Nuage en bouteille";
          case 54:
            return "Bottes d'Hermès";
          case 55:
            return "Boomerang enchanté";
          case 56:
            return "Barre de démonite";
          case 57:
            return "Lingot de démonite";
          case 58:
            return "Pilier";
          case 59:
            return "Graines corrompues";
          case 60:
            return "Champignon infect";
          case 61:
            return "Bloc d'ébonite";
          case 62:
            return "Graines d'herbe";
          case 63:
            return "Tournesols";
          case 64:
            return "Vileronce";
          case 65:
            return "Furie stellaire";
          case 66:
            return "Poudre de purification";
          case 67:
            return "Poudre infecte";
          case 68:
            return "Morceau pourri";
          case 69:
            return "Dent de ver";
          case 70:
            return "Nourriture pour ver";
          case 71:
            return "Pièce de cuivre";
          case 72:
            return "Pièce d'argent";
          case 73:
            return "Pièce d'or";
          case 74:
            return "Pièce de platine";
          case 75:
            return "Étoile filante";
          case 76:
            return "Jambières en cuivre";
          case 77:
            return "Jambières en fer";
          case 78:
            return "Jambières en argent";
          case 79:
            return "Jambière en or";
          case 80:
            return "Cotte de mailles en cuivre";
          case 81:
            return "Cotte de mailles en fer";
          case 82:
            return "Cotte de mailles en argent";
          case 83:
            return "Cotte de mailles en or";
          case 84:
            return "Grappin";
          case 85:
            return "Chaîne en fer";
          case 86:
            return "Écaille sombre";
          case 87:
            return "Tirelire";
          case 88:
            return "Casque de mineur";
          case 89:
            return "Casque en cuivre";
          case 90:
            return "Casque en fer";
          case 91:
            return "Casque en argent";
          case 92:
            return "Casque en or";
          case 93:
            return "Mur en bois";
          case 94:
            return "Plateforme en bois";
          case 95:
            return "Pistolet à silex";
          case 96:
            return "Mousquet";
          case 97:
            return "Balle de mousquet";
          case 98:
            return "Minishark";
          case 99:
            return "Arc en fer";
          case 100:
            return "Jambières de l'ombre";
          case 101:
            return "Armure d'écailles de l'ombre";
          case 102:
            return "Casque de l'ombre";
          case 103:
            return "Pioche cauchemardesque";
          case 104:
            return "Le briseur";
          case 105:
            return "Bougie";
          case 106:
            return "Chandelier en cuivre";
          case 107:
            return "Chandelier en argent";
          case 108:
            return "Chandelier en or";
          case 109:
            return "Cristal de mana";
          case 110:
            return "Faible potion de mana";
          case 111:
            return "Anneau de pouvoir stellaire";
          case 112:
            return "Fleur de feu";
          case 113:
            return "Missile magique";
          case 114:
            return "Bâtonnet de terre";
          case 115:
            return "Orbe de lumière";
          case 116:
            return "Météorite";
          case 117:
            return "Barre de météorite";
          case 118:
            return "Crochet";
          case 119:
            return "Flamarang";
          case 120:
            return "Furie en fusion";
          case 121:
            return "Grande épée ardente";
          case 122:
            return "Pioche en fusion";
          case 123:
            return "Casque de météore";
          case 124:
            return "Costume de météore";
          case 125:
            return "Leggings de météores";
          case 126:
            return "Eau en bouteille";
          case (int) sbyte.MaxValue:
            return "Arme d'espace";
          case 128:
            return "Bottes-fusées";
          case 129:
            return "Brique grise";
          case 130:
            return "Mur de briques grises";
          case 131:
            return "Brique rouge";
          case 132:
            return "Mur de briques rouges";
          case 133:
            return "Bloc d'argile";
          case 134:
            return "Brique bleue";
          case 135:
            return "Mur de briques bleues";
          case 136:
            return "Lanterne à chaîne";
          case 137:
            return "Brique verte";
          case 138:
            return "Mur de briques vertes";
          case 139:
            return "Brique rose";
          case 140:
            return "Mur de briques roses";
          case 141:
            return "Brique dorée";
          case 142:
            return "Mur de briques dorées";
          case 143:
            return "Brique argentée";
          case 144:
            return "Mur de briques argentées";
          case 145:
            return "Brique cuivrée";
          case 146:
            return "Mur de briques cuivrées";
          case 147:
            return "Pointe";
          case 148:
            return "Bougie d'eau";
          case 149:
            return "Livre";
          case 150:
            return "Toile d'araignée";
          case 151:
            return "Casque nécro";
          case 152:
            return "Plastron nécro";
          case 153:
            return "Jambières nécro";
          case 154:
            return "Os";
          case 155:
            return "Muramasa";
          case 156:
            return "Bouclier de cobalt";
          case 157:
            return "Sceptre aquatique";
          case 158:
            return "Fer à cheval porte-bonheur";
          case 159:
            return "Ballon rouge brillant";
          case 160:
            return "Harpon";
          case 161:
            return "Balle hérissée";
          case 162:
            return "Ball O' Hurt";
          case 163:
            return "Lune bleue";
          case 164:
            return "Pistolet";
          case 165:
            return "Trait d'eau";
          case 166:
            return "Bombe";
          case 167:
            return "Dynamite";
          case 168:
            return "Grenade";
          case 169:
            return "Bloc de sable";
          case 170:
            return "Verre";
          case 171:
            return "Panneau";
          case 172:
            return "Bloc de cendre";
          case 173:
            return "Obsidienne";
          case 174:
            return "Pierre de l'enfer";
          case 175:
            return "Barre de pierre de l'enfer";
          case 176:
            return "Bloc de boue";
          case 177:
            return "Saphir";
          case 178:
            return "Rubis";
          case 179:
            return "Émeraude";
          case 180:
            return "Topaze";
          case 181:
            return "Améthyste";
          case 182:
            return "Diamant";
          case 183:
            return "Champignon lumineux";
          case 184:
            return "Étoile";
          case 185:
            return "Grappin à lianes";
          case 186:
            return "Tuba";
          case 187:
            return "Palmes";
          case 188:
            return "Potion de soins";
          case 189:
            return "Potion de mana";
          case 190:
            return "Lame d'herbe";
          case 191:
            return "Chakram d'épines";
          case 192:
            return "Brique d'obsidienne";
          case 193:
            return "Crâne d'obsidienne";
          case 194:
            return "Graines de champignon";
          case 195:
            return "Graines de la jungle";
          case 196:
            return "Marteau en bois";
          case 197:
            return "Canon à étoiles";
          case 198:
            return "Sabre laser bleu";
          case 199:
            return "Sabre laser rouge";
          case 200:
            return "Sabre laser vert";
          case 201:
            return "Sabre laser violet";
          case 202:
            return "Sabre laser blanc";
          case 203:
            return "Sabre laser jaune";
          case 204:
            return "Martache en météorite";
          case 205:
            return "Seau vide";
          case 206:
            return "Seau d'eau";
          case 207:
            return "Seau de lave";
          case 208:
            return "Rose de la jungle";
          case 209:
            return "Dard";
          case 210:
            return "Vigne";
          case 211:
            return "Griffes sauvages";
          case 212:
            return "Bracelet du vent";
          case 213:
            return "Crosse de repousse";
          case 214:
            return "Brique de pierre de l'enfer";
          case 215:
            return "Coussin péteur";
          case 216:
            return "Manille";
          case 217:
            return "Martache en fusion";
          case 218:
            return "Mèche enflammée";
          case 219:
            return "Blaster phénix";
          case 220:
            return "Furie solaire";
          case 221:
            return "Forge infernale";
          case 222:
            return "Pot d'argile";
          case 223:
            return "Don de la nature";
          case 224:
            return "Lit";
          case 225:
            return "Soie";
          case 226:
            return "Faible potion de restauration";
          case 227:
            return "Potion de restauration";
          case 228:
            return "Casque de la jungle";
          case 229:
            return "Plastron de la jungle";
          case 230:
            return "Jambières de la jungle";
          case 231:
            return "Casque en fusion";
          case 232:
            return "Plastron en fusion";
          case 233:
            return "Jambières en fusion";
          case 234:
            return "Balle météore";
          case 235:
            return "Bombe collante";
          case 236:
            return "Lentille noire";
          case 237:
            return "Lunettes de soleil";
          case 238:
            return "Chapeau de magicien";
          case 239:
            return "Haut de forme";
          case 240:
            return "Veste de smoking";
          case 241:
            return "Pantalon de smoking";
          case 242:
            return "Chapeau d'été";
          case 243:
            return "Capuche de lapin";
          case 244:
            return "Casquette de plombier";
          case 245:
            return "Veste de plombier";
          case 246:
            return "Pantalon de plombier";
          case 247:
            return "Capuche de héros";
          case 248:
            return "Veste de héros";
          case 249:
            return "Pantalon de héros";
          case 250:
            return "Bocal à poissons";
          case 251:
            return "Chapeau d'archéologue";
          case 252:
            return "Veste d'archéologue";
          case 253:
            return "Pantalon d'archéologue";
          case 254:
            return "Teinture noire";
          case (int) byte.MaxValue:
            return "Teinture mauve";
          case 256:
            return "Cagoule de ninja";
          case 257:
            return "Veste de ninja";
          case 258:
            return "Pantalon de ninja";
          case 259:
            return "Cuir";
          case 260:
            return "Chapeau rouge";
          case 261:
            return "Poisson rouge";
          case 262:
            return "Robe";
          case 263:
            return "Chapeau de robot";
          case 264:
            return "Couronne d'or";
          case 265:
            return "Flèche du feu de l'enfer";
          case 266:
            return "Canon à sable";
          case 267:
            return "Poupée vaudou du guide";
          case 268:
            return "Casque de plongée";
          case 269:
            return "Chemise familière";
          case 270:
            return "Pantalon familier";
          case 271:
            return "Perruque familière";
          case 272:
            return "Faux de démon";
          case 273:
            return "Fil des Ténèbres";
          case 274:
            return "Lance sombre";
          case 275:
            return "Corail";
          case 276:
            return "Cactus";
          case 277:
            return "Trident";
          case 278:
            return "Balle d'argent";
          case 279:
            return "Couteau de lancer";
          case 280:
            return "Lance";
          case 281:
            return "Sarbacane";
          case 282:
            return "Bâton lumineux";
          case 283:
            return "Graine";
          case 284:
            return "Boomerang en bois";
          case 285:
            return "Embout de lacet";
          case 286:
            return "Bâton lumineux collant";
          case 287:
            return "Couteau empoisonné";
          case 288:
            return "Potion de peau d'obsidienne";
          case 289:
            return "Potion de régénération";
          case 290:
            return "Potion de rapidité";
          case 291:
            return "Potion de branchies";
          case 292:
            return "Potion de peau de fer";
          case 293:
            return "Potion de régénération de mana";
          case 294:
            return "Potion de pouvoir magique";
          case 295:
            return "Potion de poids plume";
          case 296:
            return "Potion de spéléologue";
          case 297:
            return "Potion d'invisibilité";
          case 298:
            return "Potion de brillance";
          case 299:
            return "Potion de vision nocturne";
          case 300:
            return "Potion de bataille";
          case 301:
            return "Potion d'épines";
          case 302:
            return "Potion de marche sur l'eau";
          case 303:
            return "Potion de tir à l'arc";
          case 304:
            return "Potion du chasseur";
          case 305:
            return "Potion de gravité";
          case 306:
            return "Coffre d'or";
          case 307:
            return "Graines de floraison du jour";
          case 308:
            return "Graines de lueur de lune";
          case 309:
            return "Graines de racine clignotante";
          case 310:
            return "Graines de mauvaise herbe morte";
          case 311:
            return "Graines de feuilles de l'eau";
          case 312:
            return "Graines de fleur de feu";
          case 313:
            return "Floraison du jour";
          case 314:
            return "Lueur de lune";
          case 315:
            return "Racine clignotante";
          case 316:
            return "Mauvaise herbe morte";
          case 317:
            return "Feuille de l'eau";
          case 318:
            return "Fleur de feu";
          case 319:
            return "Aileron de requin";
          case 320:
            return "Plume";
          case 321:
            return "Pierre tombale";
          case 322:
            return "Masque du mime";
          case 323:
            return "Mandibule de fourmilion";
          case 324:
            return "Pièces détachées";
          case 325:
            return "Veste du docteur";
          case 326:
            return "Pantalon du docteur";
          case 327:
            return "Clé dorée";
          case 328:
            return "Coffre sombre";
          case 329:
            return "Clé sombre";
          case 330:
            return "Mur de briques d'obsidienne";
          case 331:
            return "Spores de la jungle";
          case 332:
            return "Métier à tisser";
          case 333:
            return "Piano";
          case 334:
            return "Commode";
          case 335:
            return "Banc";
          case 336:
            return "Baignoire";
          case 337:
            return "Bannière rouge";
          case 338:
            return "Bannière verte";
          case 339:
            return "Bannière bleue";
          case 340:
            return "Bannière jaune";
          case 341:
            return "Lampadaire";
          case 342:
            return "Torche de tiki";
          case 343:
            return "Baril";
          case 344:
            return "Lanterne chinoise";
          case 345:
            return "Marmite";
          case 346:
            return "Coffre-fort";
          case 347:
            return "Lanterne crâne";
          case 348:
            return "Poubelle";
          case 349:
            return "Candélabre";
          case 350:
            return "Vase rose";
          case 351:
            return "Chope";
          case 352:
            return "Tonnelet";
          case 353:
            return "Bière";
          case 354:
            return "Bibliothèque";
          case 355:
            return "Trône";
          case 356:
            return "Bol";
          case 357:
            return "Bol de soupe";
          case 358:
            return "Toilettes";
          case 359:
            return "Horloge de grand-père";
          case 360:
            return "Statue d'armure";
          case 361:
            return "Étendard de bataille gobelin";
          case 362:
            return "Vêtements en lambeaux";
          case 363:
            return "Scierie";
          case 364:
            return "Minerai de cobalt";
          case 365:
            return "Minerai de mythril";
          case 366:
            return "Minerai d'adamantine";
          case 367:
            return "Pwnhammer";
          case 368:
            return "Excalibur";
          case 369:
            return "Graines sacrées";
          case 370:
            return "Bloc de sable d'ébène";
          case 371:
            return "Chapeau de cobalt";
          case 372:
            return "Casque de cobalt";
          case 373:
            return "Masque de cobalt";
          case 374:
            return "Plastron de cobalt";
          case 375:
            return "Jambières de cobalt";
          case 376:
            return "Capuche de mythril";
          case 377:
            return "Casque de mythril";
          case 378:
            return "Chapeau de mythril";
          case 379:
            return "Cotte de mailles de mythril";
          case 380:
            return "Jambières de mythril";
          case 381:
            return "Barre de cobalt";
          case 382:
            return "Barre de mythril";
          case 383:
            return "Tronçonneuse de cobalt";
          case 384:
            return "Tronçonneuse de mythril";
          case 385:
            return "Perceuse de cobalt";
          case 386:
            return "Perceuse de mythril";
          case 387:
            return "Tronçonneuse d'adamantine";
          case 388:
            return "Perceuse d'adamantine";
          case 389:
            return "Dao de Pow";
          case 390:
            return "Hallebarde de mythril";
          case 391:
            return "Barre d'amantine";
          case 392:
            return "Mur de verre";
          case 393:
            return "Boussole";
          case 394:
            return "Équipement de plongée";
          case 395:
            return "GPS";
          case 396:
            return "Fer à cheval d'obsidienne";
          case 397:
            return "Bouclier d'obsidienne";
          case 398:
            return "Atelier du bricoleur";
          case 399:
            return "Nuage dans un ballon";
          case 400:
            return "Coiffe d'adamantine";
          case 401:
            return "Casque d'adamantine";
          case 402:
            return "Masque d'adamantine";
          case 403:
            return "Plastron d'adamantine";
          case 404:
            return "Jambières en adamantine";
          case 405:
            return "Bottes spectrales";
          case 406:
            return "Glaive d'adamantine";
          case 407:
            return "Ceinture à outils";
          case 408:
            return "Bloc de sable de perle";
          case 409:
            return "Bloc de pierre de perle";
          case 410:
            return "Veste de mineur";
          case 411:
            return "Pantalon de mineur";
          case 412:
            return "Brique de pierre de perle";
          case 413:
            return "Brique iridescente";
          case 414:
            return "Brique de pierre de terre";
          case 415:
            return "Brique de cobalt";
          case 416:
            return "Brique de mythril";
          case 417:
            return "Mur de briques de pierre de perle";
          case 418:
            return "Mur de briques iridescentes";
          case 419:
            return "Mur de briques de pierre de terre";
          case 420:
            return "Mur de briques de cobalt";
          case 421:
            return "Mur de briques de mythril";
          case 422:
            return "Eau bénite";
          case 423:
            return "Eau impie";
          case 424:
            return "Bloc de limon";
          case 425:
            return "Clochette de fée";
          case 426:
            return "Lame du briseur";
          case 427:
            return "Torche bleue";
          case 428:
            return "Torche rouge";
          case 429:
            return "Torche verte";
          case 430:
            return "Torche violette";
          case 431:
            return "Torche blanche";
          case 432:
            return "Torche jaune";
          case 433:
            return "Torche du démon";
          case 434:
            return "Fusil d'assaut mécanique";
          case 435:
            return "Arbalète en cobalt";
          case 436:
            return "Arbalète en mythril";
          case 437:
            return "Crochet Double";
          case 438:
            return "Statue d'étoile";
          case 439:
            return "Statue d'épée";
          case 440:
            return "Statue de slime";
          case 441:
            return "Statue de gobelin";
          case 442:
            return "Statue de bouclier";
          case 443:
            return "Statue de chauve-souris";
          case 444:
            return "Statue de poisson";
          case 445:
            return "Statue de lapin";
          case 446:
            return "Statue de squelette";
          case 447:
            return "Statue de faucheur";
          case 448:
            return "Statue de femme";
          case 449:
            return "Statue de diablotin";
          case 450:
            return "Statue de gargouille";
          case 451:
            return "Statue de morosité";
          case 452:
            return "Statue de frelon";
          case 453:
            return "Statue de bombe";
          case 454:
            return "Statue de crabe";
          case 455:
            return "Statue de marteau";
          case 456:
            return "Statue de potion";
          case 457:
            return "Statue de lance";
          case 458:
            return "Statue de croix";
          case 459:
            return "Statue de méduse";
          case 460:
            return "Statue d'arc";
          case 461:
            return "Statue de boomerang";
          case 462:
            return "Statue de botte";
          case 463:
            return "Statue de coffre";
          case 464:
            return "Statue d'oiseau";
          case 465:
            return "Statue de hache";
          case 466:
            return "Statue corrompue";
          case 467:
            return "Statue d'arbre";
          case 468:
            return "Statue d'enclume";
          case 469:
            return "Statue de pioche";
          case 470:
            return "Statue de champignon";
          case 471:
            return "Statue d'œil";
          case 472:
            return "Statue de pilier";
          case 473:
            return "Statue de cœur";
          case 474:
            return "Statue de pot";
          case 475:
            return "Statue de tournesol";
          case 476:
            return "Statue de roi";
          case 477:
            return "Statue de reine";
          case 478:
            return "Statue de piranha";
          case 479:
            return "Mur de planches";
          case 480:
            return "Poutre de bois";
          case 481:
            return "Arbalète d'adamantine";
          case 482:
            return "Épée d'adamantine";
          case 483:
            return "Épée de cobalt";
          case 484:
            return "Épée de mythril";
          case 485:
            return "Sortilège lunaire";
          case 486:
            return "Règle";
          case 487:
            return "Boule de cristal";
          case 488:
            return "Boule à facettes";
          case 489:
            return "Emblème sorcier";
          case 490:
            return "Emblème guerrier";
          case 491:
            return "Emblème ranger";
          case 492:
            return "Ailes de démon";
          case 493:
            return "Ailes d'ange";
          case 494:
            return "Harpe magique";
          case 495:
            return "Bâton d'arc-en-ciel";
          case 496:
            return "Bâton de glace";
          case 497:
            return "Coquillage de Neptune";
          case 498:
            return "Mannequin";
          case 499:
            return "Potion de soins supérieure";
          case 500:
            return "Potion de mana supérieure";
          case 501:
            return "Poudre de fée";
          case 502:
            return "Éclat de cristal";
          case 503:
            return "Chapeau de clown";
          case 504:
            return "Veste de clown";
          case 505:
            return "Pantalon de clown";
          case 506:
            return "Lance-flammes";
          case 507:
            return "Cloche";
          case 508:
            return "Harpe";
          case 509:
            return "Clé à molette";
          case 510:
            return "Pince coupante";
          case 511:
            return "Bloc de pierre actif";
          case 512:
            return "Bloc de pierre inactif";
          case 513:
            return "Levier";
          case 514:
            return "Fusil laser";
          case 515:
            return "Balle de cristal";
          case 516:
            return "Flèche bénite";
          case 517:
            return "Dague magique";
          case 518:
            return "Tempête de cristal";
          case 519:
            return "Flammes maudites";
          case 520:
            return "Âme de lumière";
          case 521:
            return "Âme de la nuit";
          case 522:
            return "Flamme maudite";
          case 523:
            return "Torche maudite";
          case 524:
            return "Forge en adamantine";
          case 525:
            return "Enclume en mythril";
          case 526:
            return "Corne de licorne";
          case 527:
            return "Éclat sombre";
          case 528:
            return "Éclat de lumière";
          case 529:
            return "Plaque de pression rouge";
          case 530:
            return "Câble";
          case 531:
            return "Livre de sorts";
          case 532:
            return "Cape stellaire";
          case 533:
            return "Mégashark";
          case 534:
            return "Fusil à pompe";
          case 535:
            return "Pierre du philosophe";
          case 536:
            return "Gant du titan";
          case 537:
            return "Naginata en cobalt";
          case 538:
            return "Interrupteur";
          case 539:
            return "Piège à fléchette";
          case 540:
            return "Rocher";
          case 541:
            return "Plaque de pression verte";
          case 542:
            return "Plaque de pression grise";
          case 543:
            return "Plaque de pression marron";
          case 544:
            return "Œil mécanique";
          case 545:
            return "Flèche maudite";
          case 546:
            return "Balle maudite";
          case 547:
            return "Âme d'effroi";
          case 548:
            return "Âme de pouvoir";
          case 549:
            return "Âme de vision";
          case 550:
            return "Gungnir";
          case 551:
            return "Armure de plaques sacrée";
          case 552:
            return "Jambières sacrées";
          case 553:
            return "Casque sacré";
          case 554:
            return "Pendentif en croix";
          case 555:
            return "Fleur de mana";
          case 556:
            return "Ver mécanique";
          case 557:
            return "Crâne mécanique";
          case 558:
            return "Coiffe sacrée";
          case 559:
            return "Masque sacré";
          case 560:
            return "Couronne de slime";
          case 561:
            return "Disque de lumière";
          case 562:
            return "Boîte à musique (Jour du monde supérieur)";
          case 563:
            return "Boîte à musique (Surnaturel)";
          case 564:
            return "Boîte à musique (Nuit)";
          case 565:
            return "Boîte à musique (Titre)";
          case 566:
            return "Boîte à musique (Souterrain)";
          case 567:
            return "Boîte à musique (Boss 1)";
          case 568:
            return "Boîte à musique (Jungle)";
          case 569:
            return "Boîte à musique(Corruption)";
          case 570:
            return "Boîte à musique (Corruption du souterrain)";
          case 571:
            return "Boîte à musique (La Sainteté)";
          case 572:
            return "Boîte à musique (Boss 2)";
          case 573:
            return "Boîte à musique (Sainteté du souterrain)";
          case 574:
            return "Boîte à musique (Boss 3)";
          case 575:
            return "Âme du vol";
          case 576:
            return "Boîte à musique";
          case 577:
            return "Brique de démonite";
          case 578:
            return "Arbalète bénie";
          case 579:
            return "Martache-perce";
          case 580:
            return "Explosifs";
          case 581:
            return "Poste de pompage";
          case 582:
            return "Sortie de pompage";
          case 583:
            return "Minuteur d'une seconde";
          case 584:
            return "Minuteur de 3 secondes";
          case 585:
            return "Minuteur de 5 secondes";
          case 586:
            return "Bloc de sucrerie";
          case 587:
            return "Mur de sucrerie";
          case 588:
            return "Bonnet de père Noël";
          case 589:
            return "Veste de père Noël";
          case 590:
            return "Pantalon de père Noël";
          case 591:
            return "Bloc de sucrerie vert";
          case 592:
            return "Mur de sucrerie vert ";
          case 593:
            return "bloc de neige";
          case 594:
            return "brique de neige";
          case 595:
            return "Mur de briques de neige";
          case 596:
            return "Lumière bleue";
          case 597:
            return "Lumière rouge";
          case 598:
            return "Lumière verte";
          case 599:
            return "Cadeau bleu";
          case 600:
            return "Cadeau vert";
          case 601:
            return "Cadeau jaune";
          case 602:
            return "Globe de neige";
          case 603:
            return "Chou";
          case 604:
            return "Masque de dragon";
          case 605:
            return "Casque de titan";
          case 606:
            return "Coiffe spectrale";
          case 607:
            return "Plastron de dragon";
          case 608:
            return "Cotte de mailles de titan";
          case 609:
            return "Armure spectrale";
          case 610:
            return "Jambières de dragon";
          case 611:
            return "Jambières de titan";
          case 612:
            return "Subligar spectral";
          case 613:
            return "Tizona";
          case 614:
            return "Tonbogiri";
          case 615:
            return "Sharanga";
          case 616:
            return "Flèche spectrale";
          case 617:
            return "Arbalète de Vulcain";
          case 618:
            return "Éclair de Vulcain";
          case 619:
            return "Crâne à l'air douteux";
          case 620:
            return "Âme du fléau";
          case 621:
            return "Boîte de Petri";
          case 622:
            return "Nid d'abeille";
          case 623:
            return "Fiole de sang";
          case 624:
            return "Croc de loup";
          case 625:
            return "Cervelle";
          case 626:
            return "Boîte à musique (Désert)";
          case 627:
            return "Boîte à musique (Espace)";
          case 628:
            return "Boîte à musique (Tutoriel)";
          case 629:
            return "Boîte à musique (Boss 4)";
          case 630:
            return "Boîte à musique (Océan)";
          case 631:
            return "Boîte à musique (Neige)";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case -24:
            return "Sable de luz amarillo";
          case -23:
            return "Sable de luz blanco";
          case -22:
            return "Sable de luz morado";
          case -21:
            return "Sable de luz verde";
          case -20:
            return "Sable de luz rojo";
          case -19:
            return "Sable de luz azul";
          case -18:
            return "Arco de cobre";
          case -17:
            return "Martillo de cobre";
          case -16:
            return "Hacha de cobre";
          case -15:
            return "Espada corta de cobre";
          case -14:
            return "Espada larga de cobre";
          case -13:
            return "Pico de cobre";
          case -12:
            return "Arco de plata";
          case -11:
            return "Martillo de plata";
          case -10:
            return "Hacha de plata";
          case -9:
            return "Espada corta de plata";
          case -8:
            return "Espada larga de plata";
          case -7:
            return "Pico de plata";
          case -6:
            return "Arco de oro";
          case -5:
            return "Martillo de oro";
          case -4:
            return "Hacha de oro";
          case -3:
            return "Espada corta de oro";
          case -2:
            return "Espada larga de oro";
          case -1:
            return "Pico de oro";
          case 1:
            return "Pico de hierro";
          case 2:
            return "Bloque de tierra";
          case 3:
            return "Bloque de piedra";
          case 4:
            return "Espada larga de hierro";
          case 5:
            return "Champiñón";
          case 6:
            return "Espada corta de hierro";
          case 7:
            return "Martillo de hierro";
          case 8:
            return "Antorcha";
          case 9:
            return "Madera";
          case 10:
            return "Hacha de hierro";
          case 11:
            return "Mineral de hierro";
          case 12:
            return "Mineral de cobre";
          case 13:
            return "Mineral de oro";
          case 14:
            return "Mineral de plata";
          case 15:
            return "Reloj de cobre";
          case 16:
            return "Reloj de plata";
          case 17:
            return "Reloj de oro";
          case 18:
            return "Medidor de profundidad";
          case 19:
            return "Lingote de oro";
          case 20:
            return "Lingote de cobre";
          case 21:
            return "Lingote de plata";
          case 22:
            return "Lingote de hierro";
          case 23:
            return "Gel";
          case 24:
            return "Espada de madera";
          case 25:
            return "Puerta de madera";
          case 26:
            return "Pared de piedra";
          case 27:
            return "Bellota";
          case 28:
            return "Poción curativa menor";
          case 29:
            return "Cristal de vida";
          case 30:
            return "Pared de tierra";
          case 31:
            return "Botella";
          case 32:
            return "Mesa de madera";
          case 33:
            return "Forja";
          case 34:
            return "Silla de madera";
          case 35:
            return "Yunque de hierro";
          case 36:
            return "Banco de trabajo";
          case 37:
            return "Gafas de protección";
          case 38:
            return "Lentes";
          case 39:
            return "Arco de madera";
          case 40:
            return "Flecha de madera";
          case 41:
            return "Flecha ardiente";
          case 42:
            return "Estrellas ninja";
          case 43:
            return "Ojo de aspecto sospechoso";
          case 44:
            return "Arco demoníaco";
          case 45:
            return "Hacha de la noche";
          case 46:
            return "Azote de la luz";
          case 47:
            return "Flecha infame";
          case 48:
            return "Cofre";
          case 49:
            return "Banda de regeneración";
          case 50:
            return "Espejo mágico";
          case 51:
            return "Flecha de bufón";
          case 52:
            return "Estatua de ángel";
          case 53:
            return "Nube en botella";
          case 54:
            return "Botas de Hermes";
          case 55:
            return "Bumerán encantado";
          case 56:
            return "Mineral endemoniado";
          case 57:
            return "Lingote endemoniado";
          case 58:
            return "Corazón";
          case 59:
            return "Semillas corrompidas";
          case 60:
            return "Champiñón vil";
          case 61:
            return "Bloque de piedra de ébano";
          case 62:
            return "Semillas de césped";
          case 63:
            return "Girasol";
          case 64:
            return "Lanzador de espina vil";
          case 65:
            return "Furia de estrellas";
          case 66:
            return "Polvo de purificación";
          case 67:
            return "Polvo vil";
          case 68:
            return "Trozo podrido";
          case 69:
            return "Diente de gusano";
          case 70:
            return "Cebo de gusanos";
          case 71:
            return "Moneda de cobre";
          case 72:
            return "Moneda de plata";
          case 73:
            return "Moneda de oro";
          case 74:
            return "Moneda de platino";
          case 75:
            return "Estrella fugaz";
          case 76:
            return "Grebas de cobre";
          case 77:
            return "Grebas de hierro";
          case 78:
            return "Grebas de plata";
          case 79:
            return "Grebas de oro";
          case 80:
            return "Cota de malla de cobre";
          case 81:
            return "Cota de malla de hierro";
          case 82:
            return "Cota de malla de plata";
          case 83:
            return "Cota de malla de oro";
          case 84:
            return "Garfio de escalada";
          case 85:
            return "Cadena de hierro";
          case 86:
            return "Escama de las sombras";
          case 87:
            return "Hucha";
          case 88:
            return "Casco de minero";
          case 89:
            return "Casco de cobre";
          case 90:
            return "Casco de hierro";
          case 91:
            return "Casco de plata";
          case 92:
            return "Casco de oro";
          case 93:
            return "Pared de madera";
          case 94:
            return "Plataforma de madera";
          case 95:
            return "Pistola de pedernal";
          case 96:
            return "Mosquete";
          case 97:
            return "Bala de mosquete";
          case 98:
            return "Minitiburón";
          case 99:
            return "Arco de hierro";
          case 100:
            return "Grebas de las sombras";
          case 101:
            return "Cota de escamas de las sombras";
          case 102:
            return "Casco de las sombras";
          case 103:
            return "Pico de pesadilla";
          case 104:
            return "La Despedazadora";
          case 105:
            return "Vela";
          case 106:
            return "Lámpara araña de cobre";
          case 107:
            return "Lámpara araña de plata";
          case 108:
            return "Lámpara araña de oro";
          case 109:
            return "Cristal de maná";
          case 110:
            return "Poción de maná menor";
          case 111:
            return "Banda de polvo de estrellas";
          case 112:
            return "Flor de fuego";
          case 113:
            return "Proyectil mágico";
          case 114:
            return "Varita de tierra";
          case 115:
            return "Orbe de luz";
          case 116:
            return "Meteorito";
          case 117:
            return "Lingote de meteorito";
          case 118:
            return "Gancho";
          case 119:
            return "Bumerán de llamas";
          case 120:
            return "Furia fundida";
          case 121:
            return "Espadón ardiente";
          case 122:
            return "Pico fundido";
          case 123:
            return "Casco de meteorito";
          case 124:
            return "Cota de meteorito";
          case 125:
            return "Perneras de meteorito";
          case 126:
            return "Agua embotellada";
          case (int) sbyte.MaxValue:
            return "Pistola espacial";
          case 128:
            return "Botas cohete";
          case 129:
            return "Ladrillo gris";
          case 130:
            return "Pared de ladrillo gris";
          case 131:
            return "Ladrillo rojo";
          case 132:
            return "Pared de ladrillo rojo";
          case 133:
            return "Bloque de arcilla";
          case 134:
            return "Ladrillo azul";
          case 135:
            return "Pared de ladrillo azul";
          case 136:
            return "Farolillo";
          case 137:
            return "Ladrillo verde";
          case 138:
            return "Pared de ladrillo verde";
          case 139:
            return "Ladrillo rosa";
          case 140:
            return "Pared de ladrillo rosa";
          case 141:
            return "Ladrillo dorado";
          case 142:
            return "Pared de ladrillo dorado";
          case 143:
            return "Ladrillo plateado";
          case 144:
            return "Pared de ladrillo plateado";
          case 145:
            return "Ladrillo cobrizo";
          case 146:
            return "Pared de ladrillo cobrizo";
          case 147:
            return "Púa";
          case 148:
            return "Vela de agua";
          case 149:
            return "Libro";
          case 150:
            return "Telaraña";
          case 151:
            return "Casco de los muertos";
          case 152:
            return "Peto de los muertos";
          case 153:
            return "Grebas de los muertos";
          case 154:
            return "Hueso";
          case 155:
            return "Muramasa";
          case 156:
            return "Escudo de cobalto";
          case 157:
            return "Cetro de agua";
          case 158:
            return "Herradura de la suerte";
          case 159:
            return "Globo rojo brillante";
          case 160:
            return "Arpón";
          case 161:
            return "Bola con pinchos";
          case 162:
            return "Flagelo con bola";
          case 163:
            return "Luna azul";
          case 164:
            return "Pistola";
          case 165:
            return "Proyectil de agua";
          case 166:
            return "Bomba";
          case 167:
            return "Dinamita";
          case 168:
            return "Granada";
          case 169:
            return "Bloque de arena";
          case 170:
            return "Cristal";
          case 171:
            return "Cartel";
          case 172:
            return "Bloque de ceniza";
          case 173:
            return "Obsidiana";
          case 174:
            return "Piedra infernal";
          case 175:
            return "Lingote de piedra infernal";
          case 176:
            return "Bloque de lodo";
          case 177:
            return "Zafiro";
          case 178:
            return "Rubí";
          case 179:
            return "Esmeralda";
          case 180:
            return "Topacio";
          case 181:
            return "Amatista";
          case 182:
            return "Diamante";
          case 183:
            return "Champiñón brillante";
          case 184:
            return "Estrella";
          case 185:
            return "Látigo de hiedra";
          case 186:
            return "Caña para respirar";
          case 187:
            return "Aletas";
          case 188:
            return "Poción curativa";
          case 189:
            return "Poción de maná";
          case 190:
            return "Espada de hierba";
          case 191:
            return "Chakram de espinas";
          case 192:
            return "Ladrillo de obsidiana";
          case 193:
            return "Calavera obsidiana";
          case 194:
            return "Semillas de césped-champiñón";
          case 195:
            return "Semillas de césped selvático";
          case 196:
            return "Martillo de madera";
          case 197:
            return "Cañón de estrellas";
          case 198:
            return "Espada de luz azul";
          case 199:
            return "Espada de luz roja";
          case 200:
            return "Espada de luz verde";
          case 201:
            return "Espada de luz morada";
          case 202:
            return "Espada de luz blanca";
          case 203:
            return "Espada de luz amarilla";
          case 204:
            return "Hacha-martillo de meteorito";
          case 205:
            return "Cubo vacío";
          case 206:
            return "Cubo de agua";
          case 207:
            return "Cubo de lava";
          case 208:
            return "Rosa de la selva";
          case 209:
            return "Aguijón";
          case 210:
            return "Enredadera";
          case 211:
            return "Garras de bestia";
          case 212:
            return "Tobillera de viento";
          case 213:
            return "Báculo de regeneración";
          case 214:
            return "Ladrillo de piedra infernal";
          case 215:
            return "Cojín flatulento";
          case 216:
            return "Argolla";
          case 217:
            return "Hacha-martillo fundido";
          case 218:
            return "Látigo de llamas";
          case 219:
            return "Desintegrador Fénix";
          case 220:
            return "Furia solar";
          case 221:
            return "Forja infernal";
          case 222:
            return "Recipiente de barro";
          case 223:
            return "Don de la naturaleza";
          case 224:
            return "Cama";
          case 225:
            return "Seda";
          case 226:
            return "Poción de recuperación menor";
          case 227:
            return "Poción de recuperación";
          case 228:
            return "Casco para la selva";
          case 229:
            return "Camisa para la selva";
          case 230:
            return "Pantalones para la selva";
          case 231:
            return "Casco fundido";
          case 232:
            return "Peto fundido";
          case 233:
            return "Grebas fundidas";
          case 234:
            return "Proyectil de meteorito";
          case 235:
            return "Bomba lapa";
          case 236:
            return "Lentes negras";
          case 237:
            return "Gafas de sol";
          case 238:
            return "Sombrero de mago";
          case 239:
            return "Sombrero de copa";
          case 240:
            return "Camisa de esmoquin";
          case 241:
            return "Pantalones de esmoquin";
          case 242:
            return "Sombrero veraniego";
          case 243:
            return "Máscara de conejito";
          case 244:
            return "Gorra de fontanero";
          case 245:
            return "Camisa de fontanero";
          case 246:
            return "Pantalones de fontanero";
          case 247:
            return "Gorro de héroe";
          case 248:
            return "Camisa de héroe";
          case 249:
            return "Pantalones de héroe";
          case 250:
            return "Pecera";
          case 251:
            return "Sombrero de arqueólogo";
          case 252:
            return "Chaqueta de arqueólogo";
          case 253:
            return "Pantalones de arqueólogo";
          case 254:
            return "Tinte negro";
          case (int) byte.MaxValue:
            return "Tinte violeta";
          case 256:
            return "Gorro de ninja";
          case 257:
            return "Camisa de ninja";
          case 258:
            return "Pantalones de ninja";
          case 259:
            return "Cuero";
          case 260:
            return "Sombrero rojo";
          case 261:
            return "Pececillo";
          case 262:
            return "Vestido";
          case 263:
            return "Sombrero de robot";
          case 264:
            return "Corona de oro";
          case 265:
            return "Flecha de fuego infernal";
          case 266:
            return "Pistola de arena";
          case 267:
            return "Muñeco vudú del guía";
          case 268:
            return "Casco de buceo";
          case 269:
            return "Camisa informal";
          case 270:
            return "Pantalones informales";
          case 271:
            return "Peluca informal";
          case 272:
            return "Guadaña demoníaca";
          case 273:
            return "Espada de la noche";
          case 274:
            return "Lanza de la oscuridad";
          case 275:
            return "Coral";
          case 276:
            return "Cactus";
          case 277:
            return "Tridente";
          case 278:
            return "Bala de plata";
          case 279:
            return "Cuchillo arrojadizo";
          case 280:
            return "Lanza";
          case 281:
            return "Cerbatana";
          case 282:
            return "Varita luminosa";
          case 283:
            return "Semilla";
          case 284:
            return "Bumerán de madera";
          case 285:
            return "Herrete";
          case 286:
            return "Varita luminosa adhesiva";
          case 287:
            return "Cuchillo envenenado";
          case 288:
            return "Poción de piel obsidiana";
          case 289:
            return "Poción de regeneración";
          case 290:
            return "Poción de rapidez";
          case 291:
            return "Poción de agallas";
          case 292:
            return "Poción de piel de hierro";
          case 293:
            return "Poción de regeneración de maná";
          case 294:
            return "Poción de poder mágico";
          case 295:
            return "Poción de caída de pluma";
          case 296:
            return "Poción de espeleólogo";
          case 297:
            return "Poción de invisibilidad";
          case 298:
            return "Poción de brillo";
          case 299:
            return "Poción de noctámbulo";
          case 300:
            return "Poción de batalla";
          case 301:
            return "Poción de espinas";
          case 302:
            return "Poción de flotación";
          case 303:
            return "Poción de tiro con arco";
          case 304:
            return "Poción de cazador";
          case 305:
            return "Poción de gravedad";
          case 306:
            return "Cofre de oro";
          case 307:
            return "Semillas de resplandor diurno";
          case 308:
            return "Semillas de luz de luna";
          case 309:
            return "Semillas de raíz intermitente";
          case 310:
            return "Semillas de malahierba";
          case 311:
            return "Semillas de hoja de agua";
          case 312:
            return "Semillas de resplandor de fuego";
          case 313:
            return "Resplandor diurno";
          case 314:
            return "Luz de luna";
          case 315:
            return "Raíz intermitente";
          case 316:
            return "Malahierba";
          case 317:
            return "Hoja de agua";
          case 318:
            return "Resplandor de fuego";
          case 319:
            return "Aleta de tiburón";
          case 320:
            return "Pluma";
          case 321:
            return "Lápida";
          case 322:
            return "Máscara de mimo";
          case 323:
            return "Mandíbula de hormiga león";
          case 324:
            return "Piezas de arma ilegales";
          case 325:
            return "Camisa del doctor";
          case 326:
            return "Pantalones del doctor";
          case 327:
            return "Llave dorada";
          case 328:
            return "Cofre de las sombras";
          case 329:
            return "Llave de las sombras";
          case 330:
            return "Pared de ladrillo de obsidiana";
          case 331:
            return "Esporas de la selva";
          case 332:
            return "Telar";
          case 333:
            return "Piano";
          case 334:
            return "Aparador";
          case 335:
            return "Banco";
          case 336:
            return "Bañera";
          case 337:
            return "Estandarte rojo";
          case 338:
            return "Estandarte verde";
          case 339:
            return "Estandarte azul";
          case 340:
            return "Estandarte amarillo";
          case 341:
            return "Farola";
          case 342:
            return "Antorcha tiki";
          case 343:
            return "Barril";
          case 344:
            return "Farolillo de papel";
          case 345:
            return "Perol";
          case 346:
            return "Caja fuerte";
          case 347:
            return "Cráneo con vela";
          case 348:
            return "Cubo de basura";
          case 349:
            return "Candelabro";
          case 350:
            return "Recipiente rosa";
          case 351:
            return "Taza";
          case 352:
            return "Barrica";
          case 353:
            return "Cerveza";
          case 354:
            return "Librería";
          case 355:
            return "Trono";
          case 356:
            return "Cuenco";
          case 357:
            return "Cuenco de sopa";
          case 358:
            return "Retrete";
          case 359:
            return "Reloj de pie";
          case 360:
            return "Estatua de armadura";
          case 361:
            return "Estandarte de batalla duende";
          case 362:
            return "Harapos";
          case 363:
            return "Serrería";
          case 364:
            return "Mineral de cobalto";
          case 365:
            return "Mineral de mithril";
          case 366:
            return "Mineral de adamantita";
          case 367:
            return "Gran martillo";
          case 368:
            return "Excalibur";
          case 369:
            return "Semillas sagradas";
          case 370:
            return "Bloque de arena de ébano";
          case 371:
            return "Gorro de cobalto";
          case 372:
            return "Casco de cobalto";
          case 373:
            return "Máscara de cobalto";
          case 374:
            return "Peto de cobalto";
          case 375:
            return "Perneras de cobalto";
          case 376:
            return "Caperuza de mithril";
          case 377:
            return "Casco de mithril";
          case 378:
            return "Gorro de mithril";
          case 379:
            return "Cota de malla de mithril";
          case 380:
            return "Grebas de mithril";
          case 381:
            return "Lingote de cobalto";
          case 382:
            return "Lingote de mithril";
          case 383:
            return "Motosierra de cobalto";
          case 384:
            return "Motosierra de mithril";
          case 385:
            return "Taladro de cobalto";
          case 386:
            return "Taladro de mithril";
          case 387:
            return "Motosierra de adamantita";
          case 388:
            return "Taladro de adamantita";
          case 389:
            return "Flagelo Taoísta";
          case 390:
            return "Alabarda de mithril";
          case 391:
            return "Lingote de adamantita";
          case 392:
            return "Pared de cristal";
          case 393:
            return "Brújula";
          case 394:
            return "Equipo de buceo";
          case 395:
            return "GPS";
          case 396:
            return "Herradura de obsidiana";
          case 397:
            return "Escudo de obsidiana";
          case 398:
            return "Taller de chapuzas";
          case 399:
            return "Nube en globo";
          case 400:
            return "Tocado de adamantita";
          case 401:
            return "Casco de adamantita";
          case 402:
            return "Máscara de adamantita";
          case 403:
            return "Peto de adamantita";
          case 404:
            return "Polainas de adamantita";
          case 405:
            return "Botas de espectro";
          case 406:
            return "Guja de adamantita";
          case 407:
            return "Cinturón de herramientas";
          case 408:
            return "Bloque de arena perlada";
          case 409:
            return "Bloque de piedra perlada";
          case 410:
            return "Camisa de minero";
          case 411:
            return "Pantalones de minero";
          case 412:
            return "Ladrillo de piedra perlada";
          case 413:
            return "Ladrillo tornasol";
          case 414:
            return "Ladrillo de lutita";
          case 415:
            return "Ladrillo de cobalto";
          case 416:
            return "Ladrillo de mithril";
          case 417:
            return "Pared de ladrillo de piedra perlada";
          case 418:
            return "Pared de ladrillo tornasol";
          case 419:
            return "Pared de ladrillo de lutita";
          case 420:
            return "Pared de ladrillo de cobalto";
          case 421:
            return "Pared de ladrillo de mithril";
          case 422:
            return "Agua sagrada";
          case 423:
            return "Agua impura";
          case 424:
            return "Bloque de limo";
          case 425:
            return "Campana de hada";
          case 426:
            return "Espada despedazadora";
          case 427:
            return "Antorcha azul";
          case 428:
            return "Antorcha roja";
          case 429:
            return "Antorcha verde";
          case 430:
            return "Antorcha morada";
          case 431:
            return "Antorcha blanca";
          case 432:
            return "Antorcha amarilla";
          case 433:
            return "Antorcha demoníaca";
          case 434:
            return "Fusil de asalto de precisión";
          case 435:
            return "Repetidor de cobalto";
          case 436:
            return "Repetidor de mithril";
          case 437:
            return "Gancho doble";
          case 438:
            return "Estatua de estrella";
          case 439:
            return "Estatua de espada";
          case 440:
            return "Estatua de slime";
          case 441:
            return "Estatua de duende";
          case 442:
            return "Estatua de escudo";
          case 443:
            return "Estatua de murciélago";
          case 444:
            return "Estatua de pez";
          case 445:
            return "Estatua de conejito";
          case 446:
            return "Estatua de esqueleto";
          case 447:
            return "Estatua de la Muerte";
          case 448:
            return "Estatua de mujer";
          case 449:
            return "Estatua de diablillo";
          case 450:
            return "Estatua de gárgola";
          case 451:
            return "Estatua melancólica";
          case 452:
            return "Estatua de avispón";
          case 453:
            return "Estatua de bomba";
          case 454:
            return "Estatua de cangrejo";
          case 455:
            return "Estatua de martilla";
          case 456:
            return "Estatua de poción";
          case 457:
            return "Estatua de lanza";
          case 458:
            return "Estatua de cruz";
          case 459:
            return "Estatua de medusa";
          case 460:
            return "Estatua de arco";
          case 461:
            return "Estatua de bumerán";
          case 462:
            return "Estatua de bota";
          case 463:
            return "Estatua de cofre";
          case 464:
            return "Estatua de pájaro";
          case 465:
            return "Estatua de hacha";
          case 466:
            return "Estatua de corrupción";
          case 467:
            return "Estatua de árbol";
          case 468:
            return "Estatua de yunque";
          case 469:
            return "Estatua de pico";
          case 470:
            return "Estatua de champiñón";
          case 471:
            return "Estatua de ojo";
          case 472:
            return "Estatua de columna";
          case 473:
            return "Estatua de corazón";
          case 474:
            return "Estatua de marmita";
          case 475:
            return "Estatua de girasol";
          case 476:
            return "Estatua de rey";
          case 477:
            return "Estatua de reina";
          case 478:
            return "Estatua de piraña";
          case 479:
            return "Pared de tablones";
          case 480:
            return "Viga de madera";
          case 481:
            return "Repetidor de adamantita";
          case 482:
            return "Espada de adamantita";
          case 483:
            return "Espada de cobalto";
          case 484:
            return "Espada de mithril";
          case 485:
            return "Hechizo de luna";
          case 486:
            return "Regla";
          case 487:
            return "Bola de cristal";
          case 488:
            return "Bola de discoteca";
          case 489:
            return "Emblema de hechicero";
          case 490:
            return "Emblema de guerrero";
          case 491:
            return "Emblema de guardián";
          case 492:
            return "Alas demoníacas";
          case 493:
            return "Alas de ángel";
          case 494:
            return "Arpa mágica";
          case 495:
            return "Varita multicolor";
          case 496:
            return "Varita helada";
          case 497:
            return "Concha de Neptuno";
          case 498:
            return "Maniquí";
          case 499:
            return "Poción curativa mayor";
          case 500:
            return "Poción de maná mayor";
          case 501:
            return "Polvo de hada";
          case 502:
            return "Fragmento de cristal";
          case 503:
            return "Sombrero de payaso";
          case 504:
            return "Camisa de payaso";
          case 505:
            return "Pantalones de payaso";
          case 506:
            return "Lanzallamas";
          case 507:
            return "Campana";
          case 508:
            return "Arpa";
          case 509:
            return "Llave inglesa";
          case 510:
            return "Alicates";
          case 511:
            return "Bloque de piedra activo";
          case 512:
            return "Bloque de piedra inactivo";
          case 513:
            return "Palanca";
          case 514:
            return "Fusil láser";
          case 515:
            return "Bala de cristal";
          case 516:
            return "Flecha sagrada";
          case 517:
            return "Daga mágica";
          case 518:
            return "Tormenta de cristal";
          case 519:
            return "Llamas malditas";
          case 520:
            return "Alma de luz";
          case 521:
            return "Alma de noche";
          case 522:
            return "Llama maldita";
          case 523:
            return "Antorcha maldita";
          case 524:
            return "Forja de adamantita";
          case 525:
            return "Yunque de mithril";
          case 526:
            return "Cuerno de unicornio";
          case 527:
            return "Fragmento de oscuridad";
          case 528:
            return "Fragmento de luz";
          case 529:
            return "Placa de presión roja";
          case 530:
            return "Alambre";
          case 531:
            return "Tomo encantado";
          case 532:
            return "Manto de estrellas";
          case 533:
            return "Megatiburón";
          case 534:
            return "Escopeta";
          case 535:
            return "Piedra filosofal";
          case 536:
            return "Guante de titán";
          case 537:
            return "Naginata de cobalto";
          case 538:
            return "Interruptor";
          case 539:
            return "Trampa de dardos";
          case 540:
            return "Roca";
          case 541:
            return "Placa de presión verde";
          case 542:
            return "Placa de presión gris";
          case 543:
            return "Placa de presión marrón";
          case 544:
            return "Ojo mecánico";
          case 545:
            return "Flecha maldita";
          case 546:
            return "Bala maldita";
          case 547:
            return "Alma de terror";
          case 548:
            return "Alma de poder";
          case 549:
            return "Alma de visión";
          case 550:
            return "Gungnir";
          case 551:
            return "Cota de placas sagrada";
          case 552:
            return "Grebas sagradas";
          case 553:
            return "Casco sagrado";
          case 554:
            return "Collar con cruz";
          case 555:
            return "Flor de maná";
          case 556:
            return "Gusano mecánico";
          case 557:
            return "Cráneo mecánico";
          case 558:
            return "Tocado sagrado";
          case 559:
            return "Máscara sagrada";
          case 560:
            return "Corona de slime";
          case 561:
            return "Disco de luz";
          case 562:
            return "Caja de música (Superficie de día)";
          case 563:
            return "Caja de música (Sobrecogedor)";
          case 564:
            return "Caja de música (Noche)";
          case 565:
            return "Caja de música (Título)";
          case 566:
            return "Caja de música (Subsuelo)";
          case 567:
            return "Caja de música (Jefe 1)";
          case 568:
            return "Caja de música (Selva)";
          case 569:
            return "Caja de música (Corrupción)";
          case 570:
            return "Caja de música (Corrupción en el subsuelo)";
          case 571:
            return "Caja de música (Terreno sagrado)";
          case 572:
            return "Caja de música (Jefe 2)";
          case 573:
            return "Caja de música (Subsuelo sagrado)";
          case 574:
            return "Caja de música (Jefe 3)";
          case 575:
            return "Alma de vuelo";
          case 576:
            return "Caja de música";
          case 577:
            return "Ladrillo endemoniado";
          case 578:
            return "Repetidor sagrado";
          case 579:
            return "Martitaladrahacha";
          case 580:
            return "Explosivos";
          case 581:
            return "Colector de entrada";
          case 582:
            return "Colector de salida";
          case 583:
            return "Temporizador de 1 segundo";
          case 584:
            return "Temporizador de 3 segundos";
          case 585:
            return "Temporizador de 5 segundos";
          case 586:
            return "Bloque de caramelo";
          case 587:
            return "Pared de caramelo";
          case 588:
            return "Gorro de Papá Noel";
          case 589:
            return "Camisa de Papá Noel";
          case 590:
            return "Pantalones Papá Noel";
          case 591:
            return "Bloque de caramelo verde";
          case 592:
            return "Pared de caramelo verde";
          case 593:
            return "Bloque de nieve";
          case 594:
            return "Ladrillo de nieve";
          case 595:
            return "Pared de ladrillos de nieve";
          case 596:
            return "Luz azul";
          case 597:
            return "Luz roja";
          case 598:
            return "Luz verde";
          case 599:
            return "Regalo azul";
          case 600:
            return "Regalo verde";
          case 601:
            return "Regalo amarillo";
          case 602:
            return "Globo de nieve";
          case 603:
            return "Repollo";
          case 604:
            return "Máscara de dragón";
          case 605:
            return "Casco de titán";
          case 606:
            return "Tocado espectral";
          case 607:
            return "Peto de dragón";
          case 608:
            return "Malla de titán";
          case 609:
            return "Armadura espectral";
          case 610:
            return "Grebas de dragón";
          case 611:
            return "Perneras de titán";
          case 612:
            return "Liguero espectral";
          case 613:
            return "Tizona";
          case 614:
            return "Tonbogiri";
          case 615:
            return "Sharanga";
          case 616:
            return "Flecha espectral";
          case 617:
            return "Repetidor volcánico";
          case 618:
            return "Relámpago volcánico";
          case 619:
            return "Calavera de aspecto sospechoso";
          case 620:
            return "Alma enfermiza";
          case 621:
            return "Placa de Petri";
          case 622:
            return "Panal";
          case 623:
            return "Vial de sangre";
          case 624:
            return "Colmillo de lobo";
          case 625:
            return "Cerebro";
          case 626:
            return "Caja de música (Desierto)";
          case 627:
            return "Caja de música (Espacio)";
          case 628:
            return "Caja de música (Tutorial)";
          case 629:
            return "Caja de música (Enemigo final 4)";
          case 630:
            return "Caja de música (Océano)";
          case 631:
            return "Caja de música (Nieve)";
        }
      }
      return (string) null;
    }

    public static string itemAffixName(int prefix, int netID)
    {
      string str = Lang.itemName(netID);
      if (prefix != 0)
        str = Lang.lang > 1 ? str + " (" + Lang.itemPrefix(prefix) + (object) ')' : Lang.itemPrefix(prefix) + (object) ' ' + str;
      return str;
    }

    public static string evilGood()
    {
      string str1 = (string) null;
      if (Lang.lang <= 1)
      {
        string str2;
        if ((int) WorldGen.tGood == 0)
          str2 = string.Concat(new object[4]
          {
            (object) Main.worldName,
            (object) " is ",
            (object) WorldGen.tEvil,
            (object) "% corrupt."
          });
        else if ((int) WorldGen.tEvil == 0)
          str2 = string.Concat(new object[4]
          {
            (object) Main.worldName,
            (object) " is ",
            (object) WorldGen.tGood,
            (object) "% hallow."
          });
        else
          str2 = Main.worldName + (object) " is " + (string) (object) WorldGen.tGood + "% hallow, and " + (string) (object) WorldGen.tEvil + "% corrupt.";
        return (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || (int) WorldGen.tEvil <= 20 ? str2 + " You should try harder." : str2 + " Things are grim indeed.") : str2 + " Keep up the good work!";
      }
      else
      {
        if (Lang.lang == 2)
        {
          string str2;
          if ((int) WorldGen.tGood == 0)
            str2 = string.Concat(new object[4]
            {
              (object) Main.worldName,
              (object) " ist zu ",
              (object) WorldGen.tEvil,
              (object) "% verderbt."
            });
          else if ((int) WorldGen.tEvil == 0)
            str2 = string.Concat(new object[4]
            {
              (object) Main.worldName,
              (object) " ist zu ",
              (object) WorldGen.tGood,
              (object) "% geheiligt."
            });
          else
            str2 = Main.worldName + (object) " ist zu " + (string) (object) WorldGen.tGood + "% geheiligt und zu " + (string) (object) WorldGen.tEvil + "% verderbt.";
          str1 = (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || (int) WorldGen.tEvil <= 20 ? str2 + " Streng dich mehr an!" : str2 + " Es sieht in der Tat nicht gut aus.") : str2 + " Gute Arbeit, weiter so!";
        }
        else if (Lang.lang == 3)
        {
          string str2;
          if ((int) WorldGen.tGood == 0)
            str2 = string.Concat(new object[4]
            {
              (object) Main.worldName,
              (object) " è corrotto ",
              (object) WorldGen.tEvil,
              (object) "%."
            });
          else if ((int) WorldGen.tEvil == 0)
            str2 = string.Concat(new object[4]
            {
              (object) Main.worldName,
              (object) " è consacrato ",
              (object) WorldGen.tGood,
              (object) "%."
            });
          else
            str2 = Main.worldName + (object) " è consacrato " + (string) (object) WorldGen.tGood + "% e corrotto " + (string) (object) WorldGen.tEvil + "%.";
          str1 = (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || (int) WorldGen.tEvil <= 20 ? str2 + " Dovresti impegnarti di più." : str2 + " Le cose vanno male.") : str2 + " Continua così!";
        }
        else if (Lang.lang == 4)
        {
          string str2;
          if ((int) WorldGen.tGood == 0)
            str2 = string.Concat(new object[4]
            {
              (object) Main.worldName,
              (object) " est corrompu à ",
              (object) WorldGen.tEvil,
              (object) " %."
            });
          else if ((int) WorldGen.tEvil == 0)
            str2 = string.Concat(new object[4]
            {
              (object) Main.worldName,
              (object) " est purifié à ",
              (object) WorldGen.tGood,
              (object) " %."
            });
          else
            str2 = Main.worldName + (object) " est purifié à " + (string) (object) WorldGen.tGood + "% et corrompu à " + (string) (object) WorldGen.tEvil + " %.";
          str1 = (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || (int) WorldGen.tEvil <= 20 ? str2 + " Essayez encore." : str2 + " En effet, c'est pas la joie.") : str2 + " Continuez comme ça.";
        }
        else if (Lang.lang == 5)
        {
          string str2;
          if ((int) WorldGen.tGood == 0)
            str2 = string.Concat(new object[4]
            {
              (object) Main.worldName,
              (object) " ha sido corrompido por ",
              (object) WorldGen.tEvil,
              (object) "%."
            });
          else if ((int) WorldGen.tEvil == 0)
            str2 = string.Concat(new object[4]
            {
              (object) Main.worldName,
              (object) " ha sido bendecido por ",
              (object) WorldGen.tGood,
              (object) "%."
            });
          else
            str2 = Main.worldName + (object) " ha sido bendecido por " + (string) (object) WorldGen.tGood + "% y corrompido por " + (string) (object) WorldGen.tEvil + "%.";
          str1 = (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || (int) WorldGen.tEvil <= 20 ? str2 + " Deberías esforzarte más." : str2 + " Es bastante desalentador.") : str2 + " ¡Sigue haciéndolo bien!";
        }
        return str1;
      }
    }

    public static void setLang(int language)
    {
      if (Lang.lang == language)
        return;
      Lang.lang = language;
      if (Lang.lang <= 1)
      {
        Lang.misc[0] = "A goblin army has been defeated!";
        Lang.misc[1] = "A goblin army is approaching from the west!";
        Lang.misc[2] = "A goblin army is approaching from the east!";
        Lang.misc[3] = "A goblin army has arrived!";
        Lang.misc[4] = "The Frost Legion has been defeated!";
        Lang.misc[5] = "The Frost Legion is approaching from the west!";
        Lang.misc[6] = "The Frost Legion is approaching from the east!";
        Lang.misc[7] = "The Frost Legion has arrived!";
        Lang.misc[8] = "The Blood Moon is rising...";
        Lang.misc[9] = "You feel an evil presence watching you...";
        Lang.misc[10] = "A horrible chill goes down your spine...";
        Lang.misc[11] = "Screams echo around you...";
        Lang.misc[12] = "Your world has been blessed with Cobalt!";
        Lang.misc[13] = "Your world has been blessed with Mythril!";
        Lang.misc[14] = "Your world has been blessed with Adamantite!";
        Lang.misc[15] = "The ancient spirits of light and dark have been released.";
        Lang.misc[16] = " has awoken!";
        Lang.misc[17] = " has been defeated!";
        Lang.misc[18] = " has arrived!";
        Lang.misc[19] = " was slain...";
        Lang.misc[20] = "The Twins";
        Lang.misc[21] = "Invalid operation at this state.";
        Lang.misc[22] = "You are not using the same version as this server.";
        Lang.misc[23] = "Current players: ";
        Lang.misc[24] = " has enabled PvP!";
        Lang.misc[25] = " has disabled PvP!";
        Lang.misc[26] = " is no longer on a party.";
        Lang.misc[27] = " has joined the red party.";
        Lang.misc[28] = " has joined the green party.";
        Lang.misc[29] = " has joined the blue party.";
        Lang.misc[30] = " has joined the yellow party.";
        Lang.misc[31] = "Welcome, ";
        Lang.misc[32] = " has joined.";
        Lang.misc[33] = " has left.";
        Lang.misc[34] = "The Twins have awoken!";
        Lang.misc[35] = "The Twins have been defeated!";
        Lang.misc[36] = "A meteorite has landed!";
        Lang.menu[0] = "Ingredients";
        Lang.menu[1] = " in your inventory)";
        Lang.menu[2] = "Disconnect";
        Lang.menu[3] = "Attention!";
        Lang.menu[4] = "<c>When this icon is visible\n\n\nthe game is <i>saving</i> data.";
        Lang.menu[5] = "Error!";
        Lang.menu[6] = "Play Online";
        Lang.menu[7] = "Invite Only";
        Lang.menu[8] = "Found server...";
        Lang.menu[9] = "Load failed!";
        Lang.menu[10] = "Start Game";
        Lang.menu[11] = "Create World";
        Lang.menu[12] = "Corrupted character data was found and has been deleted.";
        Lang.menu[13] = "Play Game";
        Lang.menu[14] = "Settings";
        Lang.menu[15] = "Exit Game";
        Lang.menu[16] = "Create Character";
        Lang.menu[17] = (string) (object) '\x008A' + (object) "Delete";
        Lang.menu[18] = "Hair";
        Lang.menu[19] = "Eyes";
        Lang.menu[20] = "Skin";
        Lang.menu[21] = "Clothes";
        Lang.menu[22] = "Male";
        Lang.menu[23] = "Female";
        Lang.menu[24] = "Hardcore";
        Lang.menu[25] = "Difficult";
        Lang.menu[26] = "Normal";
        Lang.menu[27] = "Random";
        Lang.menu[28] = "Create";
        Lang.menu[29] = "Death is permanent";
        Lang.menu[30] = "Drop all items on death";
        Lang.menu[31] = "Drop money on death";
        Lang.menu[32] = "Select difficulty";
        Lang.menu[33] = "Shirt";
        Lang.menu[34] = "Undershirt";
        Lang.menu[35] = "Pants";
        Lang.menu[36] = "Shoes";
        Lang.menu[37] = "Hair";
        Lang.menu[38] = "Hair Color";
        Lang.menu[39] = "Eye Color";
        Lang.menu[40] = "Skin Color";
        Lang.menu[41] = "Shirt Color";
        Lang.menu[42] = "Undershirt Color";
        Lang.menu[43] = "Pants Color";
        Lang.menu[44] = "Shoe Color";
        Lang.menu[45] = "Enter Character Name:";
        Lang.menu[46] = "Delete ";
        Lang.menu[47] = "Credits";
        Lang.menu[48] = "Enter World Name:";
        Lang.menu[49] = "Leave without creating a character?";
        Lang.menu[50] = "Select Character";
        Lang.menu[51] = "Waiting for game to start...";
        Lang.menu[52] = "Press START";
        Lang.menu[53] = "Character name";
        Lang.menu[54] = "Saving Character...";
        Lang.menu[55] = "World name";
        Lang.menu[56] = "World";
        Lang.menu[57] = "Spawn point set!";
        Lang.menu[58] = "Distance traveled";
        Lang.menu[59] = "Resources mined and gathered";
        Lang.menu[60] = "Items crafted";
        Lang.menu[61] = "Items used";
        Lang.menu[62] = "Normal bosses defeated";
        Lang.menu[63] = "Hard Mode bosses defeated";
        Lang.menu[64] = "Times died";
        Lang.menu[65] = "Volume";
        Lang.menu[66] = "No Storage Device has been selected. Saving has been disabled.";
        Lang.menu[67] = "Autosave On";
        Lang.menu[68] = "Autosave Off";
        Lang.menu[69] = "No Storage Device";
        Lang.menu[70] = "The Storage Device has been removed. Saving has been disabled.";
        Lang.menu[71] = "Pickup Text On";
        Lang.menu[72] = "Pickup Text Off";
        Lang.menu[73] = "Requesting world information...";
        Lang.menu[74] = "Requesting tile data...";
        Lang.menu[75] = "Accepting invitation...";
        Lang.menu[76] = "Searching...";
        Lang.menu[77] = "No games found";
        Lang.menu[78] = "Players: ";
        Lang.menu[79] = "~ EMPTY ~";
        Lang.menu[80] = "Joining game...";
        Lang.menu[81] = "PvP";
        Lang.menu[82] = "Team";
        Lang.menu[83] = "Your Worlds";
        Lang.menu[84] = "Join Game";
        Lang.menu[85] = "Depth: ";
        Lang.menu[86] = "m below";
        Lang.menu[87] = "m above";
        Lang.menu[88] = "level";
        Lang.menu[89] = "Tutorial";
        Lang.menu[90] = "Ok";
        Lang.menu[91] = "Choose world size:";
        Lang.menu[92] = "Small";
        Lang.menu[93] = "Medium";
        Lang.menu[94] = "Large";
        Lang.menu[95] = "Position: ";
        Lang.menu[96] = "m east";
        Lang.menu[97] = "m west";
        Lang.menu[98] = "center";
        Lang.menu[99] = "Save Game";
        Lang.menu[100] = "Exit to Main Menu";
        Lang.menu[101] = "Main Menu";
        Lang.menu[102] = "Settings data was corrupted and has been deleted.";
        Lang.menu[103] = "Corrupted world data was found and has been deleted.";
        Lang.menu[104] = "Yes";
        Lang.menu[105] = "No";
        Lang.menu[106] = "Leaderboards";
        Lang.menu[107] = "Achievements";
        Lang.menu[108] = "Help & Options";
        Lang.menu[109] = "Unlock Full Game";
        Lang.menu[110] = "How to Play";
        Lang.menu[111] = "Controls";
        Lang.menu[112] = "Resume Game";
        Lang.gen[0] = "Generating world terrain...";
        Lang.gen[1] = "Adding sand...";
        Lang.gen[2] = "Generating hills...";
        Lang.gen[3] = "Puttin dirt behind dirt...";
        Lang.gen[4] = "Placing rocks in the dirt...";
        Lang.gen[5] = "Placing dirt in the rocks...";
        Lang.gen[6] = "Adding clay...";
        Lang.gen[7] = "Making random holes...";
        Lang.gen[8] = "Generating small caves...";
        Lang.gen[9] = "Generating large caves...";
        Lang.gen[10] = "Generating surface caves...";
        Lang.gen[11] = "Generating jungle...";
        Lang.gen[12] = "Generating floating islands...";
        Lang.gen[13] = "Adding mushroom patches...";
        Lang.gen[14] = "Placing mud in the dirt...";
        Lang.gen[15] = "Adding silt...";
        Lang.gen[16] = "Adding shinies...";
        Lang.gen[17] = "Adding webs...";
        Lang.gen[18] = "Creating underworld...";
        Lang.gen[19] = "Adding water bodies...";
        Lang.gen[20] = "Making the world evil...";
        Lang.gen[21] = "Generating mountain caves...";
        Lang.gen[22] = "Creating beaches...";
        Lang.gen[23] = "Adding gems...";
        Lang.gen[24] = "Gravitating sand...";
        Lang.gen[25] = "Cleaning up dirt backgrounds...";
        Lang.gen[26] = "Placing altars...";
        Lang.gen[27] = "Settling liquids...";
        Lang.gen[28] = "Placing life crystals...";
        Lang.gen[29] = "Placing statues...";
        Lang.gen[30] = "Hiding treasure...";
        Lang.gen[31] = "Hiding more treasure...";
        Lang.gen[32] = "Hiding jungle treasure...";
        Lang.gen[33] = "Hiding water treasure...";
        Lang.gen[34] = "Placing traps...";
        Lang.gen[35] = "Placing breakables...";
        Lang.gen[36] = "Placing hellforges...";
        Lang.gen[37] = "Spreading grass...";
        Lang.gen[38] = "Growing cacti...";
        Lang.gen[39] = "Planting sunflowers...";
        Lang.gen[40] = "Planting trees...";
        Lang.gen[41] = "Planting herbs...";
        Lang.gen[42] = "Planting weeds...";
        Lang.gen[43] = "Growing vines...";
        Lang.gen[44] = "Planting flowers...";
        Lang.gen[45] = "Planting mushrooms...";
        Lang.gen[46] = "The connection to the host has been lost.";
        Lang.gen[47] = "Resetting game objects...";
        Lang.gen[48] = "Setting hard mode...";
        Lang.gen[49] = "Saving world data...";
        Lang.gen[50] = "Backing up world file...";
        Lang.gen[51] = "Loading world data...";
        Lang.gen[52] = "Checking tile alignment...";
        Lang.gen[53] = "An error occurred while reading from the Storage Device.";
        Lang.gen[54] = "An error occurred while writing to the Storage Device.";
        Lang.gen[55] = "Finding tile frames...";
        Lang.gen[56] = "Adding snow...";
        Lang.gen[57] = "Waiting for a player to leave...";
        Lang.gen[58] = "Creating dungeon...";
        Lang.inter[0] = "Cancel";
        Lang.inter[1] = "Exit without saving";
        Lang.inter[2] = "Save and Exit";
        Lang.inter[3] = "Trash Can";
        Lang.inter[4] = "Inventory";
        Lang.inter[5] = "Do you want to return to the Main Menu?";
        Lang.inter[6] = "Buffs";
        Lang.inter[7] = "Housing";
        Lang.inter[8] = "This housing is not suitable.";
        Lang.inter[9] = "Accessories";
        Lang.inter[10] = " Defense";
        Lang.inter[11] = "Vanity";
        Lang.inter[12] = "Helmet";
        Lang.inter[13] = "Shirt";
        Lang.inter[14] = "Pants";
        Lang.inter[15] = " platinum ";
        Lang.inter[16] = " gold ";
        Lang.inter[17] = " silver ";
        Lang.inter[18] = " copper";
        Lang.inter[19] = "Reforge";
        Lang.inter[20] = "Failed to create a network session.";
        Lang.inter[21] = "Failed to join the session. The session either is full or cannot be found.";
        Lang.inter[22] = "Required objects:";
        Lang.inter[23] = "None";
        Lang.inter[24] = "Alternate grappling mode";
        Lang.inter[25] = "Crafting";
        Lang.inter[26] = "Coins";
        Lang.inter[27] = "Ammo";
        Lang.inter[28] = "Shop";
        Lang.inter[29] = (string) (object) '\x008C' + (object) "Loot All";
        Lang.inter[30] = (string) (object) '\x008C' + (object) "Deposit All";
        Lang.inter[31] = (string) (object) '\x008C' + (object) "Quick Stack";
        Lang.inter[32] = "Piggy Bank";
        Lang.inter[33] = "Safe";
        Lang.inter[34] = "Time: ";
        Lang.inter[35] = "Are you sure you want to quit?";
        Lang.inter[36] = "The connection to Xbox LIVE has been lost.";
        Lang.inter[37] = "Number of entries: ";
        Lang.inter[38] = "You were slain...";
        Lang.inter[39] = "This housing is suitable.";
        Lang.inter[40] = "This is not valid housing.";
        Lang.inter[41] = "This housing is already occupied.";
        Lang.inter[42] = "This housing is corrupted.";
        Lang.inter[43] = "This gamer profile does not have suitable privileges to join. You may require a LIVE Gold account, or need to change your parental control settings.";
        Lang.inter[44] = "Receiving tile data";
        Lang.inter[45] = "Equip";
        Lang.inter[46] = "Cost: ";
        Lang.inter[47] = "Save";
        Lang.inter[48] = "Edit";
        Lang.inter[49] = "Status";
        Lang.inter[50] = "Curse";
        Lang.inter[51] = "Help";
        Lang.inter[52] = "Close";
        Lang.inter[53] = "Water";
        Lang.inter[54] = "Heal";
        Lang.inter[55] = "Provides tips and crafting advice.";
        Lang.inter[56] = "Sells basic goods.";
        Lang.inter[57] = "Heals wounds and debuffs.";
        Lang.inter[58] = "Sells explosives.";
        Lang.inter[59] = "Sells natural goods and tells you the state of the World.";
        Lang.inter[60] = "Sells guns and ammo.";
        Lang.inter[61] = "Sells vanity clothes.";
        Lang.inter[62] = "Sells tools and wires.";
        Lang.inter[63] = "Sells handy gadgets and reforges items.";
        Lang.inter[64] = "Sells magic items and accessories.";
        Lang.inter[65] = "A jolly old fellow.";
        Lang.inter[66] = "Game Ended";
        Lang.inter[67] = "The game was ended by the host.";
        Lang.inter[68] = "Unable to join due to privileges blocked on one of the signed in profiles.";
        Lang.inter[69] = "You are currently playing the trial version. Please buy the full version to play online.";
        Lang.inter[70] = "There is insufficient space available on the selected storage device.";
        Lang.inter[71] = "Playing split-screen in a Standard Definition video mode will result in game text that is difficult to read. High Definition (HD) is strongly recommended for an optimal gameplay experience.";
        Lang.inter[72] = "Ban World";
        Lang.inter[73] = "Add this world to your Banned Worlds list?";
        Lang.inter[74] = "This world is in your Banned Worlds list.";
        Lang.inter[75] = "Continue (remove from list)";
        Lang.inter[76] = "(Awaiting approval)";
        Lang.inter[77] = "(Censored)";
        Lang.inter[78] = "The Saved Game \"{0}\" was transferred from another profile and will be deleted.";
        Lang.inter[79] = "The game will end due to the Member Content settings of one of the signed in profiles.";
        Lang.tip[0] = "Equipped in vanity slot";
        Lang.tip[1] = "No stats will be gained";
        Lang.tip[2] = " melee damage";
        Lang.tip[3] = " ranged damage";
        Lang.tip[4] = " magic damage";
        Lang.tip[5] = "% critical strike chance";
        Lang.tip[6] = "Insanely fast speed";
        Lang.tip[7] = "Very fast speed";
        Lang.tip[8] = "Fast speed";
        Lang.tip[9] = "Average speed";
        Lang.tip[10] = "Slow speed";
        Lang.tip[11] = "Very slow speed";
        Lang.tip[12] = "Extremely slow speed";
        Lang.tip[13] = "Snail speed";
        Lang.tip[14] = "No knockback";
        Lang.tip[15] = "Extremely weak knockback";
        Lang.tip[16] = "Very weak knockback";
        Lang.tip[17] = "Weak knockback";
        Lang.tip[18] = "Average knockback";
        Lang.tip[19] = "Strong knockback";
        Lang.tip[20] = "Very strong knockback";
        Lang.tip[21] = "Extremely strong knockback";
        Lang.tip[22] = "Insane knockback";
        Lang.tip[23] = "Equipable";
        Lang.tip[24] = "Vanity Item";
        Lang.tip[25] = " defense";
        Lang.tip[26] = "% pickaxe power";
        Lang.tip[27] = "% axe power";
        Lang.tip[28] = "% hammer power";
        Lang.tip[29] = "Restores ";
        Lang.tip[30] = " life";
        Lang.tip[31] = " mana";
        Lang.tip[32] = "Uses ";
        Lang.tip[33] = "Can be placed";
        Lang.tip[34] = "Ammo";
        Lang.tip[35] = "Consumable";
        Lang.tip[36] = "Material";
        Lang.tip[37] = " minute duration";
        Lang.tip[38] = " second duration";
        Lang.tip[39] = "% damage";
        Lang.tip[40] = "% speed";
        Lang.tip[41] = "% critical strike chance";
        Lang.tip[42] = "% mana cost";
        Lang.tip[43] = "% size";
        Lang.tip[44] = "% velocity";
        Lang.tip[45] = "% knockback";
        Lang.tip[46] = "% movement speed";
        Lang.tip[47] = "% melee speed";
        Lang.tip[48] = "Set bonus: ";
        Lang.tip[49] = "Sell price: ";
        Lang.tip[50] = "Buy price: ";
        Lang.tip[51] = "No value";
        Lang.dt[0] = " couldn't find the antidote.";
        Lang.dt[1] = " couldn't put the fire out.";
        Lang.dt[2] = " tried to escape.";
        Lang.dt[3] = " was licked.";
        Buff.buffName[1] = "Obsidian Skin";
        Buff.buffTip[1] = "Immune to lava";
        Buff.buffName[2] = "Regeneration";
        Buff.buffTip[2] = "Provides life regeneration";
        Buff.buffName[3] = "Swiftness";
        Buff.buffTip[3] = "25% increased movement speed";
        Buff.buffName[4] = "Gills";
        Buff.buffTip[4] = "Breathe water instead of air";
        Buff.buffName[5] = "Ironskin";
        Buff.buffTip[5] = "Increase defense by 8";
        Buff.buffName[6] = "Mana Regeneration";
        Buff.buffTip[6] = "Increased mana regeneration";
        Buff.buffName[7] = "Magic Power";
        Buff.buffTip[7] = "20% increased magic damage";
        Buff.buffName[8] = "Featherfall";
        Buff.buffTip[8] = "Press UP or DOWN to control speed of descent";
        Buff.buffName[9] = "Spelunker";
        Buff.buffTip[9] = "Shows the location of treasure and ore";
        Buff.buffName[10] = "Invisibility";
        Buff.buffTip[10] = "Grants invisibility";
        Buff.buffName[11] = "Shine";
        Buff.buffTip[11] = "Emitting light";
        Buff.buffName[12] = "Night Owl";
        Buff.buffTip[12] = "Increased night vision";
        Buff.buffName[13] = "Battle";
        Buff.buffTip[13] = "Increased enemy spawn rate";
        Buff.buffName[14] = "Thorns";
        Buff.buffTip[14] = "Attackers also take damage";
        Buff.buffName[15] = "Water Walking";
        Buff.buffTip[15] = "Press DOWN to enter water";
        Buff.buffName[16] = "Archery";
        Buff.buffTip[16] = "20% increased arrow damage and speed";
        Buff.buffName[17] = "Hunter";
        Buff.buffTip[17] = "Shows the location of enemies";
        Buff.buffName[18] = "Gravitation";
        Buff.buffTip[18] = "Press UP or DOWN to reverse gravity";
        Buff.buffName[19] = "Orb of Light";
        Buff.buffTip[19] = "A magical orb that provides light";
        Buff.buffName[20] = "Poisoned";
        Buff.buffTip[20] = "Slowly losing life";
        Buff.buffName[21] = "Potion Sickness";
        Buff.buffTip[21] = "Cannot consume anymore healing items";
        Buff.buffName[22] = "Darkness";
        Buff.buffTip[22] = "Decreased light vision";
        Buff.buffName[23] = "Cursed";
        Buff.buffTip[23] = "Cannot use any items";
        Buff.buffName[24] = "On Fire!";
        Buff.buffTip[24] = "Slowly losing life";
        Buff.buffName[25] = "Tipsy";
        Buff.buffTip[25] = "Increased melee abilities, lowered defense";
        Buff.buffName[26] = "Well Fed";
        Buff.buffTip[26] = "Minor improvements to all stats";
        Buff.buffName[27] = "Fairy";
        Buff.buffTip[27] = "A fairy is following you";
        Buff.buffName[28] = "Werewolf";
        Buff.buffTip[28] = "Physical abilities are increased";
        Buff.buffName[29] = "Clairvoyance";
        Buff.buffTip[29] = "Magic powers are increased";
        Buff.buffName[30] = "Bleeding";
        Buff.buffTip[30] = "Cannot regenerate life";
        Buff.buffName[31] = "Confused";
        Buff.buffTip[31] = "Movement is reversed";
        Buff.buffName[32] = "Slow";
        Buff.buffTip[32] = "Movement speed is reduced";
        Buff.buffName[33] = "Weak";
        Buff.buffTip[33] = "Physical abilities are decreased";
        Buff.buffName[34] = "Merfolk";
        Buff.buffTip[34] = "Can breathe and move easily underwater";
        Buff.buffName[35] = "Silenced";
        Buff.buffTip[35] = "Cannot use items that require mana";
        Buff.buffName[36] = "Broken Armor";
        Buff.buffTip[36] = "Defense is cut in half";
        Buff.buffName[37] = "Horrified";
        Buff.buffTip[37] = "You have seen something nasty, there is no escape.";
        Buff.buffName[38] = "The Tongue";
        Buff.buffTip[38] = "You are being sucked into the mouth";
        Buff.buffName[39] = "Cursed Inferno";
        Buff.buffTip[39] = "Losing life";
        Buff.buffName[40] = "Pet Guinea Pig";
        Buff.buffTip[40] = "Simply adorable";
        Buff.buffName[41] = "Pet Slime";
        Buff.buffTip[41] = "A real slime ball";
        Buff.buffName[42] = "Pet Tiphia";
        Buff.buffTip[42] = "Wants all the honeys";
        Buff.buffName[43] = "Pet Bat";
        Buff.buffTip[43] = "Out for blood";
        Buff.buffName[44] = "Pet Werewolf";
        Buff.buffTip[44] = "Man's best friend";
        Buff.buffName[45] = "Pet Zombie";
        Buff.buffTip[45] = "Eats brains";
        Main.tileName[13] = "Bottle";
        Main.tileName[14] = "Table";
        Main.tileName[15] = "Chair";
        Main.tileName[16] = "Anvil";
        Main.tileName[17] = "Furnace";
        Main.tileName[18] = "Work Bench";
        Main.tileName[26] = "Demon Altar";
        Main.tileName[77] = "Hellforge";
        Main.tileName[86] = "Loom";
        Main.tileName[94] = "Keg";
        Main.tileName[96] = "Cooking Pot";
        Main.tileName[101] = "Bookcase";
        Main.tileName[106] = "Sawmill";
        Main.tileName[114] = "Tinkerer's Workshop";
        Main.tileName[133] = "Adamantite Forge";
        Main.tileName[134] = "Mythril Anvil";
      }
      else if (Lang.lang == 2)
      {
        Lang.misc[0] = "Die Goblin-Armee wurde besiegt!";
        Lang.misc[1] = "Eine Goblin-Armee nähert sich von Westen!";
        Lang.misc[2] = "Eine Goblin-Armee nähert sich von Osten!";
        Lang.misc[3] = "Ein Goblin-Armee ist da!";
        Lang.misc[4] = "Die Frost-Legion wurde besiegt!";
        Lang.misc[5] = "Die Frost-Legion nähert sich aus dem Westen!";
        Lang.misc[6] = "Die Frost-Legion nähert sich aus dem Osten!";
        Lang.misc[7] = "Die Frost-Legion ist da!";
        Lang.misc[8] = "Der Blutmond steigt auf ...";
        Lang.misc[9] = "Du fühlst dich von einer bösen Kraft beobachtet ...";
        Lang.misc[10] = "Eine Eiseskälte steigt in dir hoch ...";
        Lang.misc[11] = "Du hoerst das Echo von Schreien um dich herum ...";
        Lang.misc[12] = "Deine Welt wurde mit Kobalt gesegnet!";
        Lang.misc[13] = "Deine Welt wurde mit Mithril gesegnet!";
        Lang.misc[14] = "Deine Welt wurde mit Adamantit gesegnet!";
        Lang.misc[15] = "Die uralten Geister des Lichts und der Finsternis wurden freigelassen.";
        Lang.misc[16] = " ist aufgewacht!";
        Lang.misc[17] = " wurde besiegt!";
        Lang.misc[18] = " ist eingetroffen!";
        Lang.misc[19] = " wurde getötet von ...";
        Lang.misc[20] = "Die Zwillinge";
        Lang.misc[21] = "Ungültige Operation in diesem Zustand.";
        Lang.misc[22] = "Du verwendest nicht die gleiche Version wie der Server.";
        Lang.misc[23] = "Aktuelle Spieler: ";
        Lang.misc[24] = " hat PvP aktiviert!";
        Lang.misc[25] = " hat PvP deaktiviert!";
        Lang.misc[26] = " ist in keiner Gruppe mehr.";
        Lang.misc[27] = " ist der roten Gruppe beigetreten.";
        Lang.misc[28] = " ist der gruenen Gruppe beigetreten.";
        Lang.misc[29] = " ist der blauen Gruppe beigetreten.";
        Lang.misc[30] = " ist der gelben Gruppe beigetreten.";
        Lang.misc[31] = "Willkommen, ";
        Lang.misc[32] = " ist dazugekommen.";
        Lang.misc[33] = " hat das Spiel verlassen.";
        Lang.misc[34] = "Die Zwillinge sind erwacht!";
        Lang.misc[35] = "Die Zwillinge wurden besiegt!";
        Lang.misc[36] = "Ein Meteorit ist gelandet!";
        Lang.menu[0] = "Bestandteile";
        Lang.menu[1] = " deines Inventars)";
        Lang.menu[2] = "Trennen";
        Lang.menu[3] = "Achtung!";
        Lang.menu[4] = "<c>Wenn dieses Symbol erscheint,\n\n\n<i>speichert</i> das Spiel Daten.";
        Lang.menu[5] = "Fehler!";
        Lang.menu[6] = "Online spielen";
        Lang.menu[7] = "Nur mit Einladung";
        Lang.menu[8] = "Server gefunden ...";
        Lang.menu[9] = "Laden fehlgeschlagen!";
        Lang.menu[10] = "Spiel beginnen";
        Lang.menu[11] = "Welt erstellen";
        Lang.menu[12] = "Beschädigte Zeichendaten wurden gefunden und gelöscht.";
        Lang.menu[13] = "Spiel spielen";
        Lang.menu[14] = "Einstellungen";
        Lang.menu[15] = "Spiel verlassen";
        Lang.menu[16] = "Charakter erstellen";
        Lang.menu[17] = (string) (object) '\x008A' + (object) "Löschen";
        Lang.menu[18] = "Haar";
        Lang.menu[19] = "Augen";
        Lang.menu[20] = "Haut";
        Lang.menu[21] = "Kleidung";
        Lang.menu[22] = "Männlich";
        Lang.menu[23] = "Weiblich";
        Lang.menu[24] = "Hardcore";
        Lang.menu[25] = "Schwierig";
        Lang.menu[26] = "Normal";
        Lang.menu[27] = "Zufällig";
        Lang.menu[28] = "Erstellen";
        Lang.menu[29] = "Der Tod ist für immer";
        Lang.menu[30] = "Lass alle Items auf den Tod fallen";
        Lang.menu[31] = "Lass Geld auf den Tod fallen";
        Lang.menu[32] = "Schwierigkeitsgrad wählen";
        Lang.menu[33] = "Hemd";
        Lang.menu[34] = "Unterhemd";
        Lang.menu[35] = "Hose";
        Lang.menu[36] = "Schuhe";
        Lang.menu[37] = "Haar";
        Lang.menu[38] = "Haarfarbe";
        Lang.menu[39] = "Augenfarbe";
        Lang.menu[40] = "Hautfarbe";
        Lang.menu[41] = "Hemdfarbe";
        Lang.menu[42] = "Unterhemdfarbe";
        Lang.menu[43] = "Hosenfarbe";
        Lang.menu[44] = "Schuhfarbe";
        Lang.menu[45] = "Charaktername eingeben:";
        Lang.menu[46] = "Löschen ";
        Lang.menu[47] = "Mitwirkende";
        Lang.menu[48] = "Weltnamen eingeben:";
        Lang.menu[49] = "Verlassen, ohne einen Charakter zu erstellen?";
        Lang.menu[50] = "Wähle einen Charakter aus";
        Lang.menu[51] = "Das Spiel wird gestartet ...";
        Lang.menu[52] = "Drücke auf START";
        Lang.menu[53] = "Charaktername";
        Lang.menu[54] = "Charakter speichern ...";
        Lang.menu[55] = "Name der Welt";
        Lang.menu[56] = "Welt";
        Lang.menu[57] = "Spawnpoint gesetzt!";
        Lang.menu[58] = "Zurückgelegte Strecke";
        Lang.menu[59] = "Ressourcen abgebaut und gesammelt";
        Lang.menu[60] = "Hergestellte Items";
        Lang.menu[61] = "Genutzte Items";
        Lang.menu[62] = "Normale Bosse wurden besiegt";
        Lang.menu[63] = "Hardmode-Bosse wurden besiegt";
        Lang.menu[64] = "Zeiten erloschen";
        Lang.menu[65] = "Lautstärke";
        Lang.menu[66] = "Es wurde kein Speichermedium ausgewählt. Die Speicherung wurde deaktiviert.";
        Lang.menu[67] = "Automat. sichern an";
        Lang.menu[68] = "Automat. sichern aus";
        Lang.menu[69] = "Keine Speichermedium";
        Lang.menu[70] = "Das Speichermedium wurde entfernt. Die Speicherung wurde deaktiviert.";
        Lang.menu[71] = "Pickup-Text an";
        Lang.menu[72] = "Pickup-Text aus";
        Lang.menu[73] = "Informationen über die Welt werden angefordert ...";
        Lang.menu[74] = "Tile-Daten werden angefordert ...";
        Lang.menu[75] = "Einladung annehmen ...";
        Lang.menu[76] = "Suchen ...";
        Lang.menu[77] = "Keine Spiele gefunden";
        Lang.menu[78] = "Spieler:";
        Lang.menu[79] = "~ LEER ~";
        Lang.menu[80] = "Spiel beitreten ...";
        Lang.menu[81] = "PvP";
        Lang.menu[82] = "Team";
        Lang.menu[83] = "Deine Welten";
        Lang.menu[84] = "Spiel beitreten";
        Lang.menu[85] = "Tiefe: ";
        Lang.menu[86] = "m unterhalb";
        Lang.menu[87] = "m oberhalb";
        Lang.menu[88] = "Level";
        Lang.menu[89] = "Tutorial";
        Lang.menu[90] = "OK";
        Lang.menu[91] = "Weltgröße wählen:";
        Lang.menu[92] = "Klein";
        Lang.menu[93] = "Mittel";
        Lang.menu[94] = "Groß";
        Lang.menu[95] = "Position: ";
        Lang.menu[96] = "m östlich";
        Lang.menu[97] = "m westlich";
        Lang.menu[98] = "zentral";
        Lang.menu[99] = "Spiel speichern";
        Lang.menu[100] = "Zum Hauptmenü zurückkehren";
        Lang.menu[101] = "Hauptmenü";
        Lang.menu[102] = "Die Einstellungsdaten waren beschädigt und wurden gelöscht.";
        Lang.menu[103] = "Beschädigte Weltdaten wurden gefunden und gelöscht.";
        Lang.menu[104] = "Ja";
        Lang.menu[105] = "Nein";
        Lang.menu[106] = "Bestenlisten";
        Lang.menu[107] = "Erfolge";
        Lang.menu[108] = "Hilfe und Optionen";
        Lang.menu[109] = "Vollständiges Spiel freischalten";
        Lang.menu[110] = "So wird gespielt";
        Lang.menu[111] = "Steuerung";
        Lang.menu[112] = "Spiel fortsetzen";
        Lang.gen[0] = "Generieren des Weltgeländes ...";
        Lang.gen[1] = "Sand wird hinzugefügt ...";
        Lang.gen[2] = "Hügel werden generiert ...";
        Lang.gen[3] = "Dreck wird hinter Dreck geschoben ...";
        Lang.gen[4] = "Felsen werden in den Dreck gesetzt ...";
        Lang.gen[5] = "Dreck wird in Felsen platziert ...";
        Lang.gen[6] = "Lehm wird hinzugefügt ...";
        Lang.gen[7] = "Zufällig platzierte Löcher werden geschaffen:";
        Lang.gen[8] = "Generieren kleiner Höhlen ...";
        Lang.gen[9] = "Generieren großer Höhlen ...";
        Lang.gen[10] = "Höhlenoberflächen werden generiert ...";
        Lang.gen[11] = "Generieren des Dschungels:";
        Lang.gen[12] = "Schwimmende Inseln werden generiert ...";
        Lang.gen[13] = "Pilzflecken werden generiert ...";
        Lang.gen[14] = "Schlamm wird in Dreck gefügt ...";
        Lang.gen[15] = "Schlick wird hinzugefügt ...";
        Lang.gen[16] = "Glitzer wird hinzugefügt ...";
        Lang.gen[17] = "Spinnweben werden hinzugefügt ...";
        Lang.gen[18] = "Erstellen der Unterwelt ...";
        Lang.gen[19] = "Gewässer wird hinzugefügt ...";
        Lang.gen[20] = "Macht die Welt böse ...";
        Lang.gen[21] = "Berghöhlen werden generiert ...";
        Lang.gen[22] = "Strände werden erstellt ...";
        Lang.gen[23] = "Edelsteine werden hinzugefügt ...";
        Lang.gen[24] = "Gravitieren von Sand ...";
        Lang.gen[25] = "Reinigung von Dreckhintergrund ...";
        Lang.gen[26] = "Platzieren von Altären ...";
        Lang.gen[27] = "Gewässer verteilen ...";
        Lang.gen[28] = "Lebenskristalle platzieren ...";
        Lang.gen[29] = "Platzieren von Statuen ...";
        Lang.gen[30] = "Verstecken von Schätzen ...";
        Lang.gen[31] = "Verstecken von mehr Schätzen ...";
        Lang.gen[32] = "Verstecken von Dschungelschätzen ...";
        Lang.gen[33] = "Verstecken von Wasserschätzen ...";
        Lang.gen[34] = "Platzieren von Fallen ...";
        Lang.gen[35] = "Platzieren von Zerbrechlichem ...";
        Lang.gen[36] = "Platzieren von Höllenschmieden ...";
        Lang.gen[37] = "Gras wird verteilt ...";
        Lang.gen[38] = "Kakteen wachsen ...";
        Lang.gen[39] = "Sonnenblumen werden gepflanzt ...";
        Lang.gen[40] = "Bäume werden gepflanzt ...";
        Lang.gen[41] = "Kräuter werden gepflanzt ...";
        Lang.gen[42] = "Unkraut wird gepflanzt ...";
        Lang.gen[43] = "Wein wird angebaut ...";
        Lang.gen[44] = "Blumen werden gepflanzt ...";
        Lang.gen[45] = "Pilze werden gesät ...";
        Lang.gen[46] = "Die Verbindung zum Host wurde unterbrochen";
        Lang.gen[47] = "Spielobjekte werden zurückgesetzt ...";
        Lang.gen[48] = "Schwerer Modus wird eingestellt ...";
        Lang.gen[49] = "Weltdaten werden gesichert ...";
        Lang.gen[50] = "Backup von Weltdatei wird erstellt ...";
        Lang.gen[51] = "Weltdaten werden geladen ...";
        Lang.gen[52] = "Überprüfen der Feld-Ausrichtung ...";
        Lang.gen[53] = "Fehler beim Lesen vom Datenträger";
        Lang.gen[54] = "Fehler beim Schreiben auf den Datenträger";
        Lang.gen[55] = "Suchen von Feld-Frames ...";
        Lang.gen[56] = "Schnee hinzufügen ...";
        Lang.gen[57] = "Welt";
        Lang.gen[58] = "Verlies erstellen ...";
        Lang.inter[0] = "Abbrechen";
        Lang.inter[1] = "Vorgang ohne Speichern beenden";
        Lang.inter[2] = "Speichern und beenden";
        Lang.inter[3] = "Mülleimer";
        Lang.inter[4] = "Inventar";
        Lang.inter[5] = "Möchtest du zum Hauptmenü zurückkehren?";
        Lang.inter[6] = "Buffs";
        Lang.inter[7] = "Behausung";
        Lang.inter[8] = "Diese Behausung ist ungeeignet.";
        Lang.inter[9] = "Zusaetze";
        Lang.inter[10] = " Abwehr";
        Lang.inter[11] = "Vanity";
        Lang.inter[12] = "Helm";
        Lang.inter[13] = "Hemd";
        Lang.inter[14] = "Hose";
        Lang.inter[15] = " platin ";
        Lang.inter[16] = " gold ";
        Lang.inter[17] = " silber ";
        Lang.inter[18] = " kupfer";
        Lang.inter[19] = "Nachschmieden";
        Lang.inter[20] = "Das Erstellen einer Netzwerksitzung ist fehlgeschlagen.";
        Lang.inter[21] = "Der Versuch, der Sitzung beizutreten, ist fehlgeschlagen. Die Sitzung ist entweder voll oder kann nicht gefunden werden.";
        Lang.inter[22] = "Erforderliche Objekte:";
        Lang.inter[23] = "Keine";
        Lang.inter[24] = "Greifhaken-Modus ändern";
        Lang.inter[25] = "Herstellen";
        Lang.inter[26] = "Münzen";
        Lang.inter[27] = "Munition";
        Lang.inter[28] = "Geschäft";
        Lang.inter[29] = (string) (object) '\x008C' + (object) "Alle ausräumen";
        Lang.inter[30] = (string) (object) '\x008C' + (object) "Alle ablegen";
        Lang.inter[31] = (string) (object) '\x008C' + (object) "Schnellstapeln";
        Lang.inter[32] = "Sparschwein";
        Lang.inter[33] = "Tresor";
        Lang.inter[34] = "Zeit: ";
        Lang.inter[35] = "Bist du dir sicher, dass du aufhören möchtest?";
        Lang.inter[36] = "Die Verbindung zu Xbox LIVE wurde unterbrochen.";
        Lang.inter[37] = "Anzahl von Eintragungen: ";
        Lang.inter[38] = "Du wurdest getötet ...";
        Lang.inter[39] = "Diese Behausung ist geeignet.";
        Lang.inter[40] = "Das ist keine zulässige Behausung";
        Lang.inter[41] = "Diese Behausung ist bereits belegt.";
        Lang.inter[42] = "Diese Behausung ist beschädigt.";
        Lang.inter[43] = "Dieses Spielerprofil hat nicht die passenden Zugangsberechtigungen für eine Teilnahme. Um teilnehmen zu können, benötigst du entweder einen LIVE Gold Account oder du musst deine Jugendschutzeinstellungen ändern.";
        Lang.inter[44] = "Felddaten werden empfangen";
        Lang.inter[45] = "Ausrüsten";
        Lang.inter[46] = "Kosten: ";
        Lang.inter[47] = "Sparen";
        Lang.inter[48] = "Bearbeiten";
        Lang.inter[49] = "Status";
        Lang.inter[50] = "Fluch";
        Lang.inter[51] = "Hilfe";
        Lang.inter[52] = "Schließen";
        Lang.inter[53] = "Wasser";
        Lang.inter[54] = "Heilen";
        Lang.inter[55] = "Stellt Tipps und Handwerksvorschläge bereit.";
        Lang.inter[56] = "Verkauft reguläre Waren.";
        Lang.inter[57] = "Heilt Wunden und Debuffs.";
        Lang.inter[58] = "Verkauft Sprengstoff.";
        Lang.inter[59] = "Verkauft Naturwaren und informiert dich über den Zustand der Welt.";
        Lang.inter[60] = "Verkauft Pistolen und Munition.";
        Lang.inter[61] = "Verkauft Vanity-Kleidung.";
        Lang.inter[62] = "Verkauft Werkzeuge und Kabel.";
        Lang.inter[63] = "Verkauft praktisches Zubehör und schmiedet Items zusammen.";
        Lang.inter[64] = "Verkauft magische Items und Zubehör.";
        Lang.inter[65] = "Ein lustiger alter Kerl.";
        Lang.inter[66] = "Spiel beendet";
        Lang.inter[67] = "Das Spiel wurde vom Host beendet.";
        Lang.inter[68] = "Es kann nicht beitreten werden, da die Rechte auf einem der Profile geblockt sind.";
        Lang.inter[69] = "Du spielst zur Zeit auf der Testversion. Bitte kaufe die Vollversion, um online zu spielen.";
        Lang.inter[70] = "Die Speicherkapazität des ausgewählten Speichermediums reicht nicht aus.";
        Lang.inter[71] = "Das Spiel auf einem geteilten Bildschirm in einem Videomodus mit Standardauflösung führt zu einer schlechten Lesbarkeit des Spieltexts. Für eine optimale Spielerfahrung wird High Definition (HD) dringend empfohlen.";
        Lang.inter[72] = "Verbanne Welt";
        Lang.inter[73] = "Bist du dir sicher, dass du diese Welt deiner \"Verbannte Welten\" Liste hinzufügen möchtest?\n\nWenn du OK auswählst, beendest du gleichzeitig dieses Spiel.";
        Lang.inter[74] = "WARNUNG! Die Welt, die du gerade betrittst, befindet sich auf deiner \"Verbannte Welten\" Liste.\n\nWenn du dich dafür entscheidest, diese Welt zu besuchen, wird sie von deiner \"Verbannte Welten\" Liste gestrichen.";
        Lang.inter[75] = "Fortfahren";
        Lang.inter[76] = "(In Erwartung der Bestaetigung)";
        Lang.inter[77] = "(Zensiert)";
        Lang.inter[78] = "Das gespeicherte Spiel \"{0}\" wurde von einem anderen Profil übertragen und wird nun gelöscht.";
        Lang.inter[79] = "Durch die Nutzerinhalt-Einstellungen von einem der Profile wird das Spiel nun beendet.";
        Lang.tip[0] = "Ausgerüstet im Vanity-Slot";
        Lang.tip[1] = "Keine Werte werden gewonnen";
        Lang.tip[2] = " Nahkampfschaden";
        Lang.tip[3] = " Fernkampfschaden";
        Lang.tip[4] = " Magischer Schaden";
        Lang.tip[5] = "% kritische Trefferchance";
        Lang.tip[6] = "Wahnsinnig schnell";
        Lang.tip[7] = "Sehr schnell";
        Lang.tip[8] = "Schnell";
        Lang.tip[9] = "Durchschnittlich";
        Lang.tip[10] = "Langsam";
        Lang.tip[11] = "Sehr langsam";
        Lang.tip[12] = "Extrem langsam";
        Lang.tip[13] = "Schneckentempo";
        Lang.tip[14] = "Kein Rückstoß";
        Lang.tip[15] = "Extrem schwacher Rückstoß";
        Lang.tip[16] = "Sehr schwacher Rückstoß";
        Lang.tip[17] = "Schwacher Rückstoß";
        Lang.tip[18] = "Mittlerer Rückstoß";
        Lang.tip[19] = "Starker Rückstoß";
        Lang.tip[20] = "Sehr starker Rückstoß";
        Lang.tip[21] = "Extrem starker Rückstoß";
        Lang.tip[22] = "Wahnsinniger Rückstoß";
        Lang.tip[23] = "Ausrüstbar";
        Lang.tip[24] = "Mode-Items";
        Lang.tip[25] = " Abwehr";
        Lang.tip[26] = "% Spitzhackenkraft";
        Lang.tip[27] = "% Axtkraft";
        Lang.tip[28] = "% Hammerkraft";
        Lang.tip[29] = "Stellt ";
        Lang.tip[30] = " Leben wieder her";
        Lang.tip[31] = " Mana wieder her";
        Lang.tip[32] = "Verwendet ";
        Lang.tip[33] = "Kann platziert werden";
        Lang.tip[34] = "Munition";
        Lang.tip[35] = "Verbrauchbar";
        Lang.tip[36] = "Material";
        Lang.tip[37] = " Minuten Dauer";
        Lang.tip[38] = " Sekunden Dauer";
        Lang.tip[39] = "% Schaden";
        Lang.tip[40] = "% Tempo";
        Lang.tip[41] = "% kritische Trefferchance";
        Lang.tip[42] = "% Manakosten";
        Lang.tip[43] = "% Größe";
        Lang.tip[44] = "% Projektiltempo";
        Lang.tip[45] = "% Rückstoß";
        Lang.tip[46] = "% Bewegungstempo";
        Lang.tip[47] = "% Nahkampftempo";
        Lang.tip[48] = "Bonus-Set: ";
        Lang.tip[49] = "Verkaufspreis: ";
        Lang.tip[50] = "Kaufpreis: ";
        Lang.tip[51] = "Kein Wert";
        Lang.dt[0] = " konnte das Antidot nicht finden.";
        Lang.dt[1] = " konnte das Feuer nicht löschen.";
        Lang.dt[2] = " hat versucht, zu fliehen";
        Lang.dt[3] = " wurde abgeleckt";
        Buff.buffName[1] = "Obsidianhaut";
        Buff.buffTip[1] = "Immun gegen Lava";
        Buff.buffName[2] = "Wiederbelebung";
        Buff.buffTip[2] = "Belebt wieder";
        Buff.buffName[3] = "Wendigkeit";
        Buff.buffTip[3] = "Erhöht Bewegungstempo um 25%";
        Buff.buffName[4] = "Kiemen";
        Buff.buffTip[4] = "Wasser statt Luft atmen";
        Buff.buffName[5] = "Eisenhaut";
        Buff.buffTip[5] = "Erhöht die Abwehr um 8";
        Buff.buffName[6] = "Mana-Wiederherstellung";
        Buff.buffTip[6] = "Erhöhte Mana-Wiederherstellung";
        Buff.buffName[7] = "Magiekraft";
        Buff.buffTip[7] = "Erhöht magischen Schaden um 20%";
        Buff.buffName[8] = "Federsturz";
        Buff.buffTip[8] = "Zur Kontrolle der Sinkgeschwindigkeit Hoch oder Hinunter drücken";
        Buff.buffName[9] = "Höhlenforscher";
        Buff.buffTip[9] = "Zeigt den Fundort von Schatz und Erz";
        Buff.buffName[10] = "Unsichtbarkeit";
        Buff.buffTip[10] = "Macht unsichtbar";
        Buff.buffName[11] = "Glanz";
        Buff.buffTip[11] = "Strahlt Licht aus";
        Buff.buffName[12] = "Nachteule";
        Buff.buffTip[12] = "Erhöhte Nachtsicht";
        Buff.buffName[13] = "Kampf";
        Buff.buffTip[13] = "Erhöhte Feind-Spawnrate";
        Buff.buffName[14] = "Dornen";
        Buff.buffTip[14] = "Auch die Angreifer erleiden Schaden";
        Buff.buffName[15] = "Wasserlaufen";
        Buff.buffTip[15] = "HINUNTER drücken, um aufs Wasser zu gehen";
        Buff.buffName[16] = "Bogenschießen";
        Buff.buffTip[16] = "Um 20% erhöhter Pfeilschaden und -tempo";
        Buff.buffName[17] = "Jäger";
        Buff.buffTip[17] = "Zeigt die Position von Feinden";
        Buff.buffName[18] = "Gravitation";
        Buff.buffTip[18] = "Zum Umkehren der Schwerkraft HOCH oder HINUNTER drücken";
        Buff.buffName[19] = "Lichtkugel";
        Buff.buffTip[19] = "Eine magische Kugel, die Licht verströmt";
        Buff.buffName[20] = "Vergiftet";
        Buff.buffTip[20] = "Langsam entweicht das Leben";
        Buff.buffName[21] = "Krankheitstrank";
        Buff.buffTip[21] = "Kann keine Heil-Items mehr verbrauchen";
        Buff.buffName[22] = "Dunkelheit";
        Buff.buffTip[22] = "Schlechtere Sicht durch weniger Licht";
        Buff.buffName[23] = "Verflucht";
        Buff.buffTip[23] = "Kann keine Items verwenden";
        Buff.buffName[24] = "Flammenmeer!";
        Buff.buffTip[24] = "Langsam entweicht das Leben";
        Buff.buffName[25] = "Beschwipst";
        Buff.buffTip[25] = "Erhöhte Nahkampffähigkeiten, verminderte Abwehr";
        Buff.buffName[26] = "Kleine Stärkung";
        Buff.buffTip[26] = "Geringe Anhebung aller Werte";
        Buff.buffName[27] = "Fee";
        Buff.buffTip[27] = "Eine Fee folgt dir";
        Buff.buffName[28] = "Werwolf";
        Buff.buffTip[28] = "Körperliche Fähigkeiten sind gestiegen";
        Buff.buffName[29] = "Hellsehen";
        Buff.buffTip[29] = "Magiekräfte werden erhöht";
        Buff.buffName[30] = "Bluted";
        Buff.buffTip[30] = "Kann sich nicht mehr erholen";
        Buff.buffName[31] = "Verwirrt";
        Buff.buffTip[31] = "Bewegt sich in die falsche Richtung";
        Buff.buffName[32] = "Langsam";
        Buff.buffTip[32] = "Bewegungstempo ist herabgesetzt";
        Buff.buffName[33] = "Schwach";
        Buff.buffTip[33] = "Körperliche Leistungsfähigkeit ist reduziert";
        Buff.buffName[34] = "Meermenschen";
        Buff.buffTip[34] = "Können unter Wasser leicht atmen und sich bewegen ";
        Buff.buffName[35] = "Zum Schweigen gebracht";
        Buff.buffTip[35] = "Kann keine Items nutzen, die Mana erfordern";
        Buff.buffName[36] = "Beschädigte Rüstung";
        Buff.buffTip[36] = "Die Abwehr ist um die Hälfte reduziert";
        Buff.buffName[37] = "Entsetzt";
        Buff.buffTip[37] = "Du hast etwas Schlimmes gesehen. Da gibt es keinen Weg dran vorbei.";
        Buff.buffName[38] = "Die Zunge";
        Buff.buffTip[38] = "Du wirst in den Mund gesogen";
        Buff.buffName[39] = "Verfluchtes Inferno";
        Buff.buffTip[39] = "Leben geht verloren";
        Buff.buffName[40] = "Haustier-Meerschweinchen";
        Buff.buffTip[40] = "Zum Verlieben";
        Buff.buffName[41] = "Haustier-Schleim";
        Buff.buffTip[41] = "Ein echter Schleimball";
        Buff.buffName[42] = "Haustier-Tiphia";
        Buff.buffTip[42] = "Will alles, was süß ist";
        Buff.buffName[43] = "Haustier-Fledermaus";
        Buff.buffTip[43] = "Auf der Jagd nach Blut";
        Buff.buffName[44] = "Haustier-Werwolf";
        Buff.buffTip[44] = "Der beste Freund des Menschen";
        Buff.buffName[45] = "Haustier-Zombie";
        Buff.buffTip[45] = "Verspeist Gehirne";
        Main.tileName[13] = "Flasche";
        Main.tileName[14] = "Tabelle";
        Main.tileName[15] = "Stuhl";
        Main.tileName[16] = "Amboss";
        Main.tileName[17] = "Schmelzofen";
        Main.tileName[18] = "Werkbank";
        Main.tileName[26] = "Dämon-Altar";
        Main.tileName[77] = "Höllenschmiede";
        Main.tileName[86] = "Webstuhl";
        Main.tileName[94] = "Gärbottich";
        Main.tileName[96] = "Kochtopf";
        Main.tileName[101] = "Bücherregal";
        Main.tileName[106] = "Sägewerk";
        Main.tileName[114] = "Tüftler-Werkstatt";
        Main.tileName[133] = "Adamantitschmiede";
        Main.tileName[134] = "Mithrilamboss";
      }
      else if (Lang.lang == 3)
      {
        Lang.misc[0] = "L'esercito dei goblin è stato sconfitto!";
        Lang.misc[1] = "L'esercito dei goblin si sta avvicinando da ovest!";
        Lang.misc[2] = "L'esercito dei goblin si sta avvicinando da est!";
        Lang.misc[3] = "L'esercito dei goblin è arrivato!";
        Lang.misc[4] = "La Legione gelo è stata sconfitta!";
        Lang.misc[5] = "La Legione gelo si sta avvicinando da ovest!";
        Lang.misc[6] = "La Legione gelo si sta avvicinando da est!";
        Lang.misc[7] = "La Legione gelo è arrivata!";
        Lang.misc[8] = "La Luna di Sangue sta sorgendo...";
        Lang.misc[9] = "Senti una presenza malvagia che ti sta guardando...";
        Lang.misc[10] = "Un freddo terribile ti attraversa la spina dorsale...";
        Lang.misc[11] = "Intorno a te echeggiano urla... ";
        Lang.misc[12] = "Il tuo mondo è stato benedetto con cobalto! ";
        Lang.misc[13] = "Il tuo mondo è stato benedetto con mitrilio! ";
        Lang.misc[14] = "Il tuo mondo è stato benedetto con adamantio!";
        Lang.misc[15] = "I vecchi spiriti di luce e tenebre sono stati liberati.  ";
        Lang.misc[16] = " si è svegliato!";
        Lang.misc[17] = " è stato sconfitto!";
        Lang.misc[18] = " è arrivato!";
        Lang.misc[19] = " è stato ucciso...";
        Lang.misc[20] = "I gemelli";
        Lang.misc[21] = "Operazione non valida in questo stato.";
        Lang.misc[22] = "Non stai utilizzando la stessa versione del server.";
        Lang.misc[23] = "Giocatori correnti: ";
        Lang.misc[24] = " ha attivato il PvP!";
        Lang.misc[25] = " ha disattivato il PvP!";
        Lang.misc[26] = " non è più in un gruppo.";
        Lang.misc[27] = " si è unito al gruppo rosso.";
        Lang.misc[28] = " si è unito al gruppo verde.";
        Lang.misc[29] = " si è unito al gruppo blu.";
        Lang.misc[30] = " si è unito al gruppo giallo.";
        Lang.misc[31] = "Benevenuto, ";
        Lang.misc[32] = " ha aderito.";
        Lang.misc[33] = " ha smesso di.";
        Lang.misc[34] = "I Gemelli si sono svegliati!";
        Lang.misc[35] = "I Gemelli sono stati sconfitti!";
        Lang.misc[36] = "Un meteorite è atterrato!";
        Lang.menu[0] = "Ingredienti";
        Lang.menu[1] = " nel tuo inventario)";
        Lang.menu[2] = "Disconnetti";
        Lang.menu[3] = "Attenzione!";
        Lang.menu[4] = "<c>Quando questa icona è visibile\n\n\nla partita sta <i>salvando</i> i dati.";
        Lang.menu[5] = "Errore!";
        Lang.menu[6] = "Gioca online";
        Lang.menu[7] = "Solo su invito";
        Lang.menu[8] = "Server trovato...";
        Lang.menu[9] = "Caricamento non riuscito!";
        Lang.menu[10] = "Inizia partita";
        Lang.menu[11] = "Crea Mondo";
        Lang.menu[12] = "Sono stati trovati ed eliminati dati del personaggio danneggiati.";
        Lang.menu[13] = "Gioca";
        Lang.menu[14] = "Impostazioni";
        Lang.menu[15] = "Esci dal gioco";
        Lang.menu[16] = "Crea personaggio";
        Lang.menu[17] = (string) (object) '\x008A' + (object) "Elimina";
        Lang.menu[18] = "Capelli";
        Lang.menu[19] = "Occhi";
        Lang.menu[20] = "Pelle";
        Lang.menu[21] = "Abiti";
        Lang.menu[22] = "Maschio";
        Lang.menu[23] = "Femmina";
        Lang.menu[24] = "Hardcore";
        Lang.menu[25] = "Difficile";
        Lang.menu[26] = "Normale";
        Lang.menu[27] = "Casuale";
        Lang.menu[28] = "Crea";
        Lang.menu[29] = "Si muore per sempre";
        Lang.menu[30] = "Alla morte tutti gli oggetti vengono lasciati";
        Lang.menu[31] = "Alla morte tutte le monete vengono lasciate";
        Lang.menu[32] = "Livello di difficoltà";
        Lang.menu[33] = "Camicia";
        Lang.menu[34] = "Maglietta";
        Lang.menu[35] = "Pantaloni";
        Lang.menu[36] = "Scarpe";
        Lang.menu[37] = "Capelli";
        Lang.menu[38] = "Colore capelli";
        Lang.menu[39] = "Colore occhi";
        Lang.menu[40] = "Colore pelle";
        Lang.menu[41] = "Colore camicia";
        Lang.menu[42] = "Colore maglietta";
        Lang.menu[43] = "Colore pantaloni";
        Lang.menu[44] = "Colore scarpe";
        Lang.menu[45] = "Inserisci nome personaggio:";
        Lang.menu[46] = "Elimina ";
        Lang.menu[47] = "Riconoscimenti";
        Lang.menu[48] = "Inserisci nome mondo:";
        Lang.menu[49] = "Te ne vai senza aver creato un personaggio?";
        Lang.menu[50] = "Seleziona personaggio";
        Lang.menu[51] = "Caricamento partita";
        Lang.menu[52] = "Premi START";
        Lang.menu[53] = "Nome personaggio";
        Lang.menu[54] = "Salvataggio personaggio";
        Lang.menu[55] = "Nome Mondo";
        Lang.menu[56] = "Mondo";
        Lang.menu[57] = "Punto di rigenerazione impostato!";
        Lang.menu[58] = "Distanza percorsa";
        Lang.menu[59] = "Risorse estratte e raccolte";
        Lang.menu[60] = "Oggetti creati";
        Lang.menu[61] = "Oggetti utilizzati";
        Lang.menu[62] = "Boss sconfitti in modalità normale";
        Lang.menu[63] = "Boss sconfitti in modalità hardmode";
        Lang.menu[64] = "Volte in cui sei morto";
        Lang.menu[65] = "Volume";
        Lang.menu[66] = "Non è stato selezionato nessun supporto di memoria. Il salvataggio è stato disabilitato.";
        Lang.menu[67] = "Salvataggio automatico On";
        Lang.menu[68] = "Salvataggio automatico Off";
        Lang.menu[69] = "Nessun supporto di memoria";
        Lang.menu[70] = "Il supporto di memoria è stato rimosso. Il salvataggio è stato disabilitato.";
        Lang.menu[71] = "Testo di collegamento On";
        Lang.menu[72] = "Testo di collegamento Off";
        Lang.menu[73] = "Richiesta informazioni mondo...";
        Lang.menu[74] = "Richiesta dati in cascata...";
        Lang.menu[75] = "Accettazione invito...";
        Lang.menu[76] = "Ricerca...";
        Lang.menu[77] = "Nessuna partita trovata";
        Lang.menu[78] = "Giocatori:";
        Lang.menu[79] = "~ VUOTO ~";
        Lang.menu[80] = "Entrando...";
        Lang.menu[81] = "PvP";
        Lang.menu[82] = "Squadra";
        Lang.menu[83] = "I tuoi Mondi";
        Lang.menu[84] = "Entra nella partita";
        Lang.menu[85] = "Profondità: ";
        Lang.menu[86] = "m sotto";
        Lang.menu[87] = "m sopra";
        Lang.menu[88] = "livello";
        Lang.menu[89] = "Tutorial";
        Lang.menu[90] = "Ok";
        Lang.menu[91] = "Scegli grandezza del mondo:";
        Lang.menu[92] = "Piccolo";
        Lang.menu[93] = "Medio";
        Lang.menu[94] = "Grande";
        Lang.menu[95] = "Posizione: ";
        Lang.menu[96] = "m ad est";
        Lang.menu[97] = "m ad ovest";
        Lang.menu[98] = "centro ";
        Lang.menu[99] = "Salva gioco";
        Lang.menu[100] = "Esci dal menu principale";
        Lang.menu[101] = "Menu principale";
        Lang.menu[102] = "Sono stati trovati ed eliminati dati di impostazione danneggiati.";
        Lang.menu[103] = "Sono stati trovati ed eliminati dati del mondo danneggiati.";
        Lang.menu[104] = "Sì";
        Lang.menu[105] = "No";
        Lang.menu[106] = "Classifiche";
        Lang.menu[107] = "Obiettivi";
        Lang.menu[108] = "Guida e opzioni";
        Lang.menu[109] = "Sblocca gioco completo";
        Lang.menu[110] = "Come giocare";
        Lang.menu[111] = "Comandi";
        Lang.menu[112] = "Riprendi gioco";
        Lang.gen[0] = "Crea terreno del mondo...";
        Lang.gen[1] = "Aggiungi sabbia...";
        Lang.gen[2] = "Crea colline...";
        Lang.gen[3] = "Aggiungi terra dietro la terra...";
        Lang.gen[4] = "Posiziona rocce nella terra...";
        Lang.gen[5] = "Posiziona terra nelle rocce...";
        Lang.gen[6] = "Aggiungi argilla...";
        Lang.gen[7] = "Crea fori casuali...";
        Lang.gen[8] = "Crea piccole grotte: ";
        Lang.gen[9] = "Crea grandi grotte...";
        Lang.gen[10] = "Crea grotte superficiali...";
        Lang.gen[11] = "Crea giungla...";
        Lang.gen[12] = "Crea isole fluttuanti...";
        Lang.gen[13] = "Aggiungi campi di funghi...";
        Lang.gen[14] = "Posiziona fango nella terra...";
        Lang.gen[15] = "Aggiungi fango...";
        Lang.gen[16] = "Aggiungi elementi luminosi...";
        Lang.gen[17] = "Aggiungi ragnatele...";
        Lang.gen[18] = "Crea sotterraneo...";
        Lang.gen[19] = "Aggiungi creature acquatiche...";
        Lang.gen[20] = "Rendi il mondo malvagio...";
        Lang.gen[21] = "Crea grotte montuose...";
        Lang.gen[22] = "Crea spiagge...";
        Lang.gen[23] = "Aggiungi gemme";
        Lang.gen[24] = "Ruota sabbia...";
        Lang.gen[25] = "Pulisci sfondi terra...";
        Lang.gen[26] = "Posiziona altari...";
        Lang.gen[27] = "Versa liquidi...";
        Lang.gen[28] = "Posiziona cristalli di vita...";
        Lang.gen[29] = "Posiziona statue...";
        Lang.gen[30] = "Nascondi tesori...";
        Lang.gen[31] = "Nascondi più tesori...";
        Lang.gen[32] = "Nascondi tesori nella giungla...";
        Lang.gen[33] = "Nascondi tesori in acqua...";
        Lang.gen[34] = "Disponi trappole...";
        Lang.gen[35] = "Disponi oggetti fragili...";
        Lang.gen[36] = "Disponi creazioni degli inferi...";
        Lang.gen[37] = "Estensione erba...";
        Lang.gen[38] = "Crescita cactus...";
        Lang.gen[39] = "Pianta girasoli...";
        Lang.gen[40] = "Pianta alberi...";
        Lang.gen[41] = "Pianta erbe...";
        Lang.gen[42] = "Pianta erbacce...";
        Lang.gen[43] = "Coltiva viti...";
        Lang.gen[44] = "Pianta fiori...";
        Lang.gen[45] = "Pianta funghi...";
        Lang.gen[46] = "Connessione all'host perduta.";
        Lang.gen[47] = "Resetta oggetti di gioco...";
        Lang.gen[48] = "Imposta modalità difficile...";
        Lang.gen[49] = "Salva dati del mondo...";
        Lang.gen[50] = "Backup file mondo...";
        Lang.gen[51] = "Carica dati del mondo...";
        Lang.gen[52] = "Controlla l'allineamento delle mattonelle...";
        Lang.gen[53] = "Si è verificato un errore durante la lettura del supporto di memoria.";
        Lang.gen[54] = "Si è verificato un errore durante la scrittura sul supporto di memoria.";
        Lang.gen[55] = "Trova cornici delle mattonelle...";
        Lang.gen[56] = "Aggiungi neve ...";
        Lang.gen[57] = "Mondo";
        Lang.gen[58] = "Crea la dungeon...";
        Lang.inter[0] = "Cancella";
        Lang.inter[1] = "Esci senza salvare";
        Lang.inter[2] = "Salva ed esci";
        Lang.inter[3] = "Cestino";
        Lang.inter[4] = "Inventario";
        Lang.inter[5] = "Vuoi tornare al menu principale?";
        Lang.inter[6] = "Bonus";
        Lang.inter[7] = "Alloggio";
        Lang.inter[8] = "Questo alloggio non è adatto.";
        Lang.inter[9] = "Accessori";
        Lang.inter[10] = " Difesa";
        Lang.inter[11] = "Estetica";
        Lang.inter[12] = "Casco";
        Lang.inter[13] = "Camicia";
        Lang.inter[14] = "Pantaloni";
        Lang.inter[15] = " platino ";
        Lang.inter[16] = " oro ";
        Lang.inter[17] = " argento ";
        Lang.inter[18] = " rame";
        Lang.inter[19] = "Riforgiare";
        Lang.inter[20] = "Creazione sessione di rete non riuscita.";
        Lang.inter[21] = "Partecipazione alla sessione non riuscita. La sessione è completa o non è stata trovata.";
        Lang.inter[22] = "Oggetti richiesti:";
        Lang.inter[23] = "Nessuno";
        Lang.inter[24] = "Alterna la modalità di lotta";
        Lang.inter[25] = "Creazione Oggetti";
        Lang.inter[26] = "Monete";
        Lang.inter[27] = "Munizioni";
        Lang.inter[28] = "Negozio";
        Lang.inter[29] = (string) (object) '\x008C' + (object) "Saccheggia tutto";
        Lang.inter[30] = (string) (object) '\x008C' + (object) "Deposita tutto";
        Lang.inter[31] = (string) (object) '\x008C' + (object) "Raggruppamento rapido";
        Lang.inter[32] = "Salvadanaio";
        Lang.inter[33] = "Caveau";
        Lang.inter[34] = "Tempo: ";
        Lang.inter[35] = "Sei sicuro di voler uscire?";
        Lang.inter[36] = "Connessione a Xbox LIVE perduta";
        Lang.inter[37] = "Numero di entrate: ";
        Lang.inter[38] = "Sei morto...";
        Lang.inter[39] = "Questo alloggio è adatto.";
        Lang.inter[40] = "Questo alloggio non è valido.";
        Lang.inter[41] = "Questo alloggio è già occupato.";
        Lang.inter[42] = "Questo alloggio è corrotto.";
        Lang.inter[43] = "Questo profilo non possiede i privilegi adatti per entrare. È necessario avere un account LIVE Gold o cambiare le impostazioni per il controllo genitori. ";
        Lang.inter[44] = "Ricezione dati in cascata";
        Lang.inter[45] = "Equipaggiamento";
        Lang.inter[46] = "Costo: ";
        Lang.inter[47] = "Salva";
        Lang.inter[48] = "Modifica";
        Lang.inter[49] = "Stato";
        Lang.inter[50] = "Maledizione";
        Lang.inter[51] = "Aiuto";
        Lang.inter[52] = "Chiudi";
        Lang.inter[53] = "Acqua";
        Lang.inter[54] = "Guarire";
        Lang.inter[55] = "Offre consigli e suggerimenti sulla creazione.";
        Lang.inter[56] = "Vende merce base.";
        Lang.inter[57] = "Guarisce ferite e malus.";
        Lang.inter[58] = "Vende esplosivi.";
        Lang.inter[59] = "Vende merce naturale e indica lo stato del Mondo.";
        Lang.inter[60] = "Vende pistole e munizioni.";
        Lang.inter[61] = "Vende abiti.";
        Lang.inter[62] = "Vende cavi e attrezzi.";
        Lang.inter[63] = "Vende merce utile e riforgia oggetti.";
        Lang.inter[64] = "Vende oggetti e accessori magici.";
        Lang.inter[65] = "Un vecchio simpaticone.";
        Lang.inter[66] = "Partita terminata";
        Lang.inter[67] = "La partita è stata terminata dall'host.";
        Lang.inter[68] = "Impossibile connettersi a causa delle impostazioni di privacy di uno dei profili connessi.";
        Lang.inter[69] = "Stai giocando in versione prova. Acquista la versione completa per giocare online.";
        Lang.inter[70] = "Spazio insufficiente sul supporto di memoria selezionato.";
        Lang.inter[71] = "Con la condivisione dello schermo in definizione standard è difficile leggere il testo durante la partita. Raccomandiamo quindi, di utilizzare l'alta definizione (HD) per un'esperienza di gioco migliore.";
        Lang.inter[72] = "Blocca Mondo";
        Lang.inter[73] = "Sei sicuro di voler aggiungere questo Mondo alla tua lista dei Mondi bloccati?\n\nUscirai inoltre dalla partita, selezionando OK.";
        Lang.inter[74] = "ATTENZIONE! Il Mondo in cui stai entrando, è presente nella tua lista dei Mondi bloccati.\n\nSe decidi di partecipare a questa partita, il Mondo verrà rimosso dalla tua lista dei Mondi bloccati.";
        Lang.inter[75] = "Continua";
        Lang.inter[76] = "(In attesa di approvazione)";
        Lang.inter[77] = "(Censurato)";
        Lang.inter[78] = "Il Gioco Salvato \"{0}\" è stato trasferito da un altro profilo e sarà cancellato.";
        Lang.inter[79] = "La partita finirà a causa delle impostazioni familiari di uno dei profili connessi.";
        Lang.tip[0] = "Equipaggiato nella sezione di estetica";
        Lang.tip[1] = "Nessun parametro incrementato";
        Lang.tip[2] = " Danno da mischia";
        Lang.tip[3] = " Danno boomerang";
        Lang.tip[4] = " Danno magico";
        Lang.tip[5] = "% Possibilità colpo critico";
        Lang.tip[6] = "Velocità matta";
        Lang.tip[7] = "Extra velocità";
        Lang.tip[8] = "Alta velocità";
        Lang.tip[9] = "Media velocità";
        Lang.tip[10] = "Bassa velocità";
        Lang.tip[11] = "Velocità molto bassa";
        Lang.tip[12] = "Velocità extra bassa";
        Lang.tip[13] = "Velocità lumaca";
        Lang.tip[14] = "Nessuno spintone";
        Lang.tip[15] = "Spintone extra debole";
        Lang.tip[16] = "Spintone molto debole";
        Lang.tip[17] = "Spintone debole";
        Lang.tip[18] = "Spintone medio";
        Lang.tip[19] = "Spintone forte";
        Lang.tip[20] = "Spintone molto forte";
        Lang.tip[21] = "Spintone extra forte";
        Lang.tip[22] = "Spintone matto";
        Lang.tip[23] = "Equipaggiabili";
        Lang.tip[24] = "Oggetti di estetica";
        Lang.tip[25] = " Difesa";
        Lang.tip[26] = "% Potenza piccone";
        Lang.tip[27] = "% Potenza ascia";
        Lang.tip[28] = "% Potenza martello";
        Lang.tip[29] = "Risana ";
        Lang.tip[30] = " vita";
        Lang.tip[31] = " mana";
        Lang.tip[32] = "Utilizza ";
        Lang.tip[33] = "Può essere posizionato";
        Lang.tip[34] = "Munizioni";
        Lang.tip[35] = "Consumabile";
        Lang.tip[36] = "Materiale";
        Lang.tip[37] = " Durata minuto";
        Lang.tip[38] = " Durata secondo";
        Lang.tip[39] = "% Danno";
        Lang.tip[40] = "% Velocità";
        Lang.tip[41] = "% Possibilità colpo critico";
        Lang.tip[42] = "% Costo mana";
        Lang.tip[43] = "% Dimensione";
        Lang.tip[44] = "% Velocità del proiettile";
        Lang.tip[45] = "% Spintone";
        Lang.tip[46] = "% Velocità movimento";
        Lang.tip[47] = "% Velocità corpo a corpo";
        Lang.tip[48] = "Imposta bonus: ";
        Lang.tip[49] = "Prezzo di vendita: ";
        Lang.tip[50] = "Prezzo di acquisto: ";
        Lang.tip[51] = "Nessun valore";
        Lang.dt[0] = " non ha trovato l'antidoto.";
        Lang.dt[1] = " non ha spento il fuoco.";
        Lang.dt[2] = " ha tentato di scappare.";
        Lang.dt[3] = "è stato battuto. ";
        Buff.buffName[1] = "Pelle ossidiana";
        Buff.buffTip[1] = "Immune alla lava";
        Buff.buffName[2] = "Rigenerazione";
        Buff.buffTip[2] = "Rigenera la vita";
        Buff.buffName[3] = "Velocità";
        Buff.buffTip[3] = "Velocità di movimento aumentata del 25%";
        Buff.buffName[4] = "Branchie";
        Buff.buffTip[4] = "Respira acqua invece di aria";
        Buff.buffName[5] = "Pelle di ferro";
        Buff.buffTip[5] = "Aumenta la difesa di 8";
        Buff.buffName[6] = "Rigenerazione mana";
        Buff.buffTip[6] = "Aumenta la rigenerazione del mana";
        Buff.buffName[7] = "Potere magico";
        Buff.buffTip[7] = "Danno magico aumentato del 20%";
        Buff.buffName[8] = "Cascata di piume";
        Buff.buffTip[8] = "Premi UP o DOWN per controllare la velocità di discesa";
        Buff.buffName[9] = "Speleologo";
        Buff.buffTip[9] = "Mostra l'ubicazione di tesori e minerali";
        Buff.buffName[10] = "Invisibilità";
        Buff.buffTip[10] = "Rende invisibili";
        Buff.buffName[11] = "Brillantezza";
        Buff.buffTip[11] = "Emette luce";
        Buff.buffName[12] = "Civetta notturna";
        Buff.buffTip[12] = "Visione notturna aumentata";
        Buff.buffName[13] = "Battaglia";
        Buff.buffTip[13] = "Ritmo generazione nemici aumentato";
        Buff.buffName[14] = "Spine";
        Buff.buffTip[14] = "Anche gli aggressori subiscono danni";
        Buff.buffName[15] = "Camminata nell'acqua";
        Buff.buffTip[15] = "Premi DOWN per entrare nell'acqua";
        Buff.buffName[16] = "Arco";
        Buff.buffTip[16] = "Danno e velocià freccia aumentati del 20%";
        Buff.buffName[17] = "Cacciatore";
        Buff.buffTip[17] = "Mostra la posizione dei nemici";
        Buff.buffName[18] = "Gravità";
        Buff.buffTip[18] = "Premi UP o DOWN per invertire la gravità";
        Buff.buffName[19] = "Orbita di luce";
        Buff.buffTip[19] = "Sfera magica che fornisce luce";
        Buff.buffName[20] = "Avvelenato";
        Buff.buffTip[20] = "Perdi lentamente la vita";
        Buff.buffName[21] = "Malattia pozione";
        Buff.buffTip[21] = "Non si possono più consumare oggetti curativi";
        Buff.buffName[22] = "Oscurità";
        Buff.buffTip[22] = "Visione della luce diminuita";
        Buff.buffName[23] = "Maledetto";
        Buff.buffTip[23] = "Non si possono più utilizzare oggetti";
        Buff.buffName[24] = "A fuoco!";
        Buff.buffTip[24] = "Perdi lentamente la vita";
        Buff.buffName[25] = "Brillo";
        Buff.buffTip[25] = "Abilità corpo a corpo aumentata, difesa abbassata";
        Buff.buffName[26] = "Ben nutrito";
        Buff.buffTip[26] = "Migliorie minori a tutti i parametri";
        Buff.buffName[27] = "Fata";
        Buff.buffTip[27] = "Una fata ti sta seguendo";
        Buff.buffName[28] = "Lupo mannaro";
        Buff.buffTip[28] = "Abilità fisiche aumentate";
        Buff.buffName[29] = "Chiaroveggenza";
        Buff.buffTip[29] = "Poteri magici aumentati";
        Buff.buffName[30] = "Sanguinamento";
        Buff.buffTip[30] = "Impossibile rigenerare vita";
        Buff.buffName[31] = "Confuso";
        Buff.buffTip[31] = "Movimento invertito";
        Buff.buffName[32] = "Lento";
        Buff.buffTip[32] = "Velocità movimento ridotta";
        Buff.buffName[33] = "Debole";
        Buff.buffTip[33] = "Abilità fisiche diminuite";
        Buff.buffName[34] = "Tritone";
        Buff.buffTip[34] = "Può respirare e muoversi facilmente sott'acqua";
        Buff.buffName[35] = "Tacere";
        Buff.buffTip[35] = "Non possono utilizzare gli elementi che richiedono mana";
        Buff.buffName[36] = "Armatura rotta";
        Buff.buffTip[36] = "La difesa è dimezzata";
        Buff.buffName[37] = "Inorridito";
        Buff.buffTip[37] = "Hai visto qualcosa di orribile, non c'è via di scampo.";
        Buff.buffName[38] = "La Lingua";
        Buff.buffTip[38] = "Sei stato succhiato nella bocca";
        Buff.buffName[39] = "Inferno maledetto";
        Buff.buffTip[39] = "Perdi la vita";
        Buff.buffName[40] = "Porcellino d'India";
        Buff.buffTip[40] = "Semplicemente adorabile";
        Buff.buffName[41] = "Slime";
        Buff.buffTip[41] = "Una vera palla di slime";
        Buff.buffName[42] = "Vespa";
        Buff.buffTip[42] = "Vuole tutto il miele";
        Buff.buffName[43] = "Pipistrello";
        Buff.buffTip[43] = "A caccia di sangue";
        Buff.buffName[44] = "Lupo mannaro";
        Buff.buffTip[44] = "Il migliore amico dell'uomo";
        Buff.buffName[45] = "Zombie";
        Buff.buffTip[45] = "Mangia cervelli";
        Main.tileName[13] = "Bottiglia";
        Main.tileName[14] = "Tavolo";
        Main.tileName[15] = "Sedia";
        Main.tileName[16] = "Incudine";
        Main.tileName[17] = "Fornace";
        Main.tileName[18] = "Banco da lavoro";
        Main.tileName[26] = "Altare dei demoni";
        Main.tileName[77] = "Creazione degli inferi";
        Main.tileName[86] = "Telaio";
        Main.tileName[94] = "Barilotto";
        Main.tileName[96] = "Pentola";
        Main.tileName[101] = "Scaffale";
        Main.tileName[106] = "Segheria";
        Main.tileName[114] = "Laboratorio dell'inventore";
        Main.tileName[133] = "Forgia di adamantio";
        Main.tileName[134] = "Incudine di mitrilio";
      }
      else if (Lang.lang == 4)
      {
        Lang.misc[0] = "L'armée des gobelins a été vaincue.";
        Lang.misc[1] = "Une armée de gobelins approche par l'ouest.";
        Lang.misc[2] = "Une armée de gobelins approche par l'est.";
        Lang.misc[3] = "Une armée de gobelins est arrivée !";
        Lang.misc[4] = "La Légion gel a été vaincue !";
        Lang.misc[5] = "La Légion gel approche l'ouest !";
        Lang.misc[6] = "La Légion gel approche par l'est !";
        Lang.misc[7] = "La Légion gel est arrivée !";
        Lang.misc[8] = "La lune sanglante se lève...";
        Lang.misc[9] = "Vous sentez une présence maléfique vous observer...";
        Lang.misc[10] = "Un frisson vous parcourt le dos...";
        Lang.misc[11] = "Des cris retentissent autour de vous...";
        Lang.misc[12] = "Votre monde a la chance de profiter de ressources de cobalt.";
        Lang.misc[13] = "Votre monde a la chance de profiter de ressources de mythril.";
        Lang.misc[14] = "Votre monde a la chance de profiter de ressources d'adamantine.";
        Lang.misc[15] = "Les anciens esprits de l'ombre et de la lumière ont été relâchés.";
        Lang.misc[16] = " est réveillé.";
        Lang.misc[17] = " a été vaincue.";
        Lang.misc[18] = " est arrivée.";
        Lang.misc[19] = " s'est fait éliminer...";
        Lang.misc[20] = "Les jumeaux";
        Lang.misc[21] = "Opération non valable en l'état.";
        Lang.misc[22] = "Vous n'utilisez pas la même version que ce serveur.";
        Lang.misc[23] = "Joueurs actuels : ";
        Lang.misc[24] = " a activé le PvP.";
        Lang.misc[25] = " a désactivé le PvP.";
        Lang.misc[26] = " n'est plus dans une équipe.";
        Lang.misc[27] = " a rejoint l'équipe rouge.";
        Lang.misc[28] = " a rejoint l'équipe verte.";
        Lang.misc[29] = " a rejoint l'équipe bleue.";
        Lang.misc[30] = " a rejoint l'équipe jaune.";
        Lang.misc[31] = "Bienvenue, ";
        Lang.misc[32] = " a rejoint.";
        Lang.misc[33] = " a quitté.";
        Lang.misc[34] = "Les Jumeaux se sont réveillés !";
        Lang.misc[35] = "Les Jumeaux ont été vaincus !";
        Lang.misc[36] = "Une météorite a atterri !";
        Lang.menu[0] = "Ingrédients";
        Lang.menu[1] = "dans votre inventaire)";
        Lang.menu[2] = "Déconnexion";
        Lang.menu[3] = "Attention !";
        Lang.menu[4] = "<c>Lorsque cette icône apparaît,\n\n\nle jeu est en cours de <i>sauvegarde</i> de données.";
        Lang.menu[5] = "Erreur !";
        Lang.menu[6] = "Jouer en ligne";
        Lang.menu[7] = "Sur invitation seulement";
        Lang.menu[8] = "Serveur trouvé...";
        Lang.menu[9] = "Le chargement a échoué.";
        Lang.menu[10] = "Démarrer jeu";
        Lang.menu[11] = "Créer un monde";
        Lang.menu[12] = "Des données avec des caractères corrompus ont été détectées et supprimées.";
        Lang.menu[13] = "Jouer";
        Lang.menu[14] = "Paramètres";
        Lang.menu[15] = "Quitter le jeu";
        Lang.menu[16] = "Créer un personnage";
        Lang.menu[17] = (string) (object) '\x008A' + (object) "Supprimer";
        Lang.menu[18] = "Cheveux";
        Lang.menu[19] = "Yeux";
        Lang.menu[20] = "Peau";
        Lang.menu[21] = "Vêtements";
        Lang.menu[22] = "Homme";
        Lang.menu[23] = "Femme";
        Lang.menu[24] = "Hardcore";
        Lang.menu[25] = "Difficile";
        Lang.menu[26] = "Normal";
        Lang.menu[27] = "Aléatoire";
        Lang.menu[28] = "Créer";
        Lang.menu[29] = "La mort est définitive";
        Lang.menu[30] = "Perdre tous ses objets à la mort";
        Lang.menu[31] = "Perdre son argent à la mort";
        Lang.menu[32] = "Choisir la difficulté";
        Lang.menu[33] = "Chemise";
        Lang.menu[34] = "Maillot de corps";
        Lang.menu[35] = "Pantalon";
        Lang.menu[36] = "Chaussures";
        Lang.menu[37] = "Cheveux";
        Lang.menu[38] = "Couleur des cheveux";
        Lang.menu[39] = "Couleur des yeux";
        Lang.menu[40] = "Couleur de peau";
        Lang.menu[41] = "Couleur de chemise";
        Lang.menu[42] = "Couleur de maillot de corps";
        Lang.menu[43] = "Couleur de pantalon";
        Lang.menu[44] = "Couleur des chaussures";
        Lang.menu[45] = "Saisir le nom du personnage :";
        Lang.menu[46] = "Supprimer ";
        Lang.menu[47] = "Crédits";
        Lang.menu[48] = "Saisir un nom de monde :";
        Lang.menu[49] = "Quitter sans créer de personnage ?";
        Lang.menu[50] = "Sélectionner un personnage";
        Lang.menu[51] = "En attente du démarrage du jeu...";
        Lang.menu[52] = "Appuyez sur START";
        Lang.menu[53] = "Nom du personnage";
        Lang.menu[54] = "Sauvegarde du personnage...";
        Lang.menu[55] = "Nom du monde";
        Lang.menu[56] = "Monde";
        Lang.menu[57] = "Point d'apparition défini !";
        Lang.menu[58] = "Distance parcourue";
        Lang.menu[59] = "Ressources extraites et collectées";
        Lang.menu[60] = "Objets fabriqués";
        Lang.menu[61] = "Objets utilisés";
        Lang.menu[62] = "Boss normaux vaincus";
        Lang.menu[63] = "Boss difficiles vaincus";
        Lang.menu[64] = "Nombre de fois mort(e)";
        Lang.menu[65] = "Volume";
        Lang.menu[66] = "La sauvegarde a été désactivée, car aucun périphérique de stockage n'a été sélectionné. ";
        Lang.menu[67] = "Sauvegarde auto activée";
        Lang.menu[68] = "Sauvegarde auto désactivée";
        Lang.menu[69] = "Aucun périphérique de stockage";
        Lang.menu[70] = "La sauvegarde a été désactivée, car le périphérique de stockage a été retiré.";
        Lang.menu[71] = "Affichage du texte activé";
        Lang.menu[72] = "Affichage du texte désactivé";
        Lang.menu[73] = "Demande d'informations du monde...";
        Lang.menu[74] = "Demande des données de tuiles...";
        Lang.menu[75] = "Acceptation de l'invitation...";
        Lang.menu[76] = "Recherche...";
        Lang.menu[77] = "Aucune partie trouvée";
        Lang.menu[78] = "Joueurs : ";
        Lang.menu[79] = "~ VIDE ~";
        Lang.menu[80] = "Connexion à la partie...";
        Lang.menu[81] = "PvP";
        Lang.menu[82] = "Équipe";
        Lang.menu[83] = "Vos mondes";
        Lang.menu[84] = "Rejoindre la partie";
        Lang.menu[85] = "Profondeur : ";
        Lang.menu[86] = "m en-dessous";
        Lang.menu[87] = "m au-dessus";
        Lang.menu[88] = "niveau";
        Lang.menu[89] = "Tutoriel";
        Lang.menu[90] = "OK";
        Lang.menu[91] = "Choisir la taille du monde :";
        Lang.menu[92] = "Petit";
        Lang.menu[93] = "Moyen";
        Lang.menu[94] = "Grand";
        Lang.menu[95] = "Position : ";
        Lang.menu[96] = "m est";
        Lang.menu[97] = "m ouest";
        Lang.menu[98] = "centre";
        Lang.menu[99] = "Sauvegarder la partie";
        Lang.menu[100] = "Retour au menu principal";
        Lang.menu[101] = "Menu principal";
        Lang.menu[102] = "Les données des paramètres étaient corrompues et ont été supprimées.";
        Lang.menu[103] = "Des données corrompues du monde ont été trouvées et supprimées.";
        Lang.menu[104] = "Oui";
        Lang.menu[105] = "Pas";
        Lang.menu[106] = "Classements";
        Lang.menu[107] = "Succès";
        Lang.menu[108] = "Aide et options";
        Lang.menu[109] = "Déverrouiller le jeu complet";
        Lang.menu[110] = "Comment jouer";
        Lang.menu[111] = "Commandes";
        Lang.menu[112] = "Reprendre le jeu";
        Lang.gen[0] = "Création du terrain...";
        Lang.gen[1] = "Ajout de sable...";
        Lang.gen[2] = "Création des collines...";
        Lang.gen[3] = "Placement de la boue derrière la boue...";
        Lang.gen[4] = "Placement des rochers dans la boue...";
        Lang.gen[5] = "Placement de boue dans les rochers...";
        Lang.gen[6] = "Ajout d'argile...";
        Lang.gen[7] = "Création de trous aléatoires...";
        Lang.gen[8] = "Création de petites cavernes...";
        Lang.gen[9] = "Création de grandes cavernes...";
        Lang.gen[10] = "Création des cavernes en surface...";
        Lang.gen[11] = "Création de jungle...";
        Lang.gen[12] = "Création d'îles flottantes...";
        Lang.gen[13] = "Ajout des parcelles de champignons...";
        Lang.gen[14] = "Placement de la terre dans la boue...";
        Lang.gen[15] = "Ajout de limon...";
        Lang.gen[16] = "Ajout des brillances...";
        Lang.gen[17] = "Ajout de toiles d'araignées...";
        Lang.gen[18] = "Création du monde inférieur...";
        Lang.gen[19] = "Ajout d'étendues d'eau...";
        Lang.gen[20] = "Corruption du monde...";
        Lang.gen[21] = "Création de cavernes montagneuses...";
        Lang.gen[22] = "Création de plages...";
        Lang.gen[23] = "Ajout de gemmes...";
        Lang.gen[24] = "Gravitation du sable...";
        Lang.gen[25] = "Nettoyage d'arrière-plans de boue...";
        Lang.gen[26] = "Placement d'autels...";
        Lang.gen[27] = "Mise en place des points d'eau...";
        Lang.gen[28] = "Placement de cristaux de vie...";
        Lang.gen[29] = "Placement de statues...";
        Lang.gen[30] = "Dissimulation de trésors...";
        Lang.gen[31] = "Dissimulation de trésors supplémentaires...";
        Lang.gen[32] = "Dissimulation de trésors de jungle...";
        Lang.gen[33] = "Dissimulation de trésors d'eau...";
        Lang.gen[34] = "Placement de pièges...";
        Lang.gen[35] = "Placement d'objets cassables...";
        Lang.gen[36] = "Placement de forges infernales...";
        Lang.gen[37] = "Création de zone d'herbe...";
        Lang.gen[38] = "Faire pousser des cactus...";
        Lang.gen[39] = "Plantation de tournesols...";
        Lang.gen[40] = "Plantation d'arbres...";
        Lang.gen[41] = "Plantation d'herbe...";
        Lang.gen[42] = "Plantation de mauvaises herbes...";
        Lang.gen[43] = "Faire pousser des vignes...";
        Lang.gen[44] = "Plantation de fleurs...";
        Lang.gen[45] = "Plantation de champignons...";
        Lang.gen[46] = "La connexion à l'hôte a été perdue.";
        Lang.gen[47] = "Réinitialisation des objets du jeu...";
        Lang.gen[48] = "Installation du mode difficile...";
        Lang.gen[49] = "Sauvegarde des données du monde...";
        Lang.gen[50] = "Sauvegarde du fichier du monde...";
        Lang.gen[51] = "Chargement des données du monde...";
        Lang.gen[52] = "Vérification de l'alignement des blocs...";
        Lang.gen[53] = "Une erreur est survenue lors de la lecture du périphérique de stockage.";
        Lang.gen[54] = "Une erreur est survenue lors de l'écriture sur le périphérique de stockage.";
        Lang.gen[55] = "Trouver les images de blocs...";
        Lang.gen[56] = "Ajout de neige...";
        Lang.menu[56] = "Monde";
        Lang.gen[58] = "Création de donjon...";
        Lang.inter[0] = "Annuler";
        Lang.inter[1] = "Quitter sans sauvegarder";
        Lang.inter[2] = "Sauvegarder et quitter";
        Lang.inter[3] = "Poubelle";
        Lang.inter[4] = "Inventaire";
        Lang.inter[5] = "Voulez-vous retourner au menu principal ?";
        Lang.inter[6] = "Buffs";
        Lang.inter[7] = "Logement";
        Lang.inter[8] = "Ce logement n'est pas approprié.";
        Lang.inter[9] = "Accessoires";
        Lang.inter[10] = " Défense";
        Lang.inter[11] = "Vanité";
        Lang.inter[12] = "Casque";
        Lang.inter[13] = "Chemise";
        Lang.inter[14] = "Pantalon";
        Lang.inter[15] = " Platine ";
        Lang.inter[16] = " Or ";
        Lang.inter[17] = " Argent ";
        Lang.inter[18] = " Cuivre";
        Lang.inter[19] = "Reforger";
        Lang.inter[20] = "La création d'une session en réseau a échoué.";
        Lang.inter[21] = "Impossible de rejoindre la session, car elle est pleine ou introuvable.";
        Lang.inter[22] = "Objets requis :";
        Lang.inter[23] = "Aucun";
        Lang.inter[24] = "Alterner le mode grappin";
        Lang.inter[25] = "Artisanat";
        Lang.inter[26] = "Pièces";
        Lang.inter[27] = "Munitions";
        Lang.inter[28] = "Magasin";
        Lang.inter[29] = (string) (object) '\x008C' + (object) "Tout récupérer";
        Lang.inter[30] = (string) (object) '\x008C' + (object) "Tout déposer";
        Lang.inter[31] = (string) (object) '\x008C' + (object) "Pile rapide";
        Lang.inter[32] = "Tirelire";
        Lang.inter[33] = "Coffre-fort";
        Lang.inter[34] = "Temps : ";
        Lang.inter[35] = "Voulez-vous vraiment quitter ?";
        Lang.inter[36] = "La connexion à la Xbox LIVE a été perdue";
        Lang.inter[37] = "Nombre d'entrées : ";
        Lang.inter[38] = "Vous vous êtes fait exterminer...";
        Lang.inter[39] = "Ce logement convient.";
        Lang.inter[40] = "Ce logement ne convient pas.";
        Lang.inter[41] = "Ce logement est déjà occupé.";
        Lang.inter[42] = "Ce logement est corrompu.";
        Lang.inter[43] = "Ce profil du joueur ne dispose pas des privilèges pour se connecter. Il est possible qu'un compte LIVE Gold soit requis, ou que vous deviez changer les paramètres de contrôle parental.";
        Lang.inter[44] = "Réception de données de blocs";
        Lang.inter[45] = "équiper";
        Lang.inter[46] = "Coût: ";
        Lang.inter[47] = "Enregistrer";
        Lang.inter[48] = "Modifier";
        Lang.inter[49] = "État";
        Lang.inter[50] = "Malédiction";
        Lang.inter[51] = "Aide";
        Lang.inter[52] = "Proches";
        Lang.inter[53] = "De l'eau";
        Lang.inter[54] = "Guérir";
        Lang.inter[55] = "Fournit des astuces et des conseils d'artisanat.";
        Lang.inter[56] = "Vend des marchandises de base.";
        Lang.inter[57] = "Guérit les blessures et les debuffs.";
        Lang.inter[58] = "Vend des explosifs.";
        Lang.inter[59] = "Vend des produits naturels et renseigne sur l'état du monde.";
        Lang.inter[60] = "Vend des armes à feu et des munitions.";
        Lang.inter[61] = "Vend des vêtements de vanité.";
        Lang.inter[62] = "Vend des outils et des câbles.";
        Lang.inter[63] = "Vend des gadgets utiles et reforge des objets.";
        Lang.inter[64] = "Vend des objets et accessoires magiques.";
        Lang.inter[65] = "Un vieu bonhomme joyeux.";
        Lang.inter[66] = "Partie terminée";
        Lang.inter[67] = "L'hôte a mis fin à la partie.";
        Lang.inter[68] = "Impossible de rejoindre la partie, car les privilèges sont bloqués pour l'un des profils connectés.";
        Lang.inter[69] = "Vous jouez actuellement à la version d'essai. Veuillez acheter le jeu complet pour pouvoir jouer en ligne.";
        Lang.inter[70] = "Il n'y a pas assez d'espace libre sur le périphérique de stockage sélectionné.";
        Lang.inter[71] = "Jouer sur un écran divisé en mode vidéo définition standard rendra le texte du jeu difficile à lire. Pour une expérience de jeu optimale, la haute définition (HD) est fortement conseillée.";
        Lang.inter[72] = "Bannir un monde";
        Lang.inter[73] = "Voulez-vous vraiment ajouter ce monde à votre liste de mondes bannis?\n\nSi vous sélectionnez OK, vous quitterez cette partie.";
        Lang.inter[74] = "AVERTISSEMENT ! Le monde auquel vous vous joignez est sur votre liste de mondes bannis.\n\nSi vous décidez de rejoindre cette partie, le monde sera supprimé de votre liste.";
        Lang.inter[75] = "Continuer";
        Lang.inter[76] = "(En attente d'approbation)";
        Lang.inter[77] = "(Censuré)";
        Lang.inter[78] = "La partie enregistrée \"{0}\" a été transféré d'un autre profil et sera supprimée.";
        Lang.inter[79] = "La partie va se terminer en raison des paramètres de contenu des membres de l'un des profils connectés.";
        Lang.tip[0] = "Équipé dans un emplacement Vanité";
        Lang.tip[1] = "Ne procure pas de stats";
        Lang.tip[2] = " de dégâts de mêlée";
        Lang.tip[3] = " de dégâts à distance";
        Lang.tip[4] = " de dégâts magiques";
        Lang.tip[5] = "% de chance de coup critique";
        Lang.tip[6] = "Vitesse insensée";
        Lang.tip[7] = "Vitesse très rapide";
        Lang.tip[8] = "Vitesse rapide";
        Lang.tip[9] = "Vitesse moyenne";
        Lang.tip[10] = "Vitesse lente";
        Lang.tip[11] = "Vitesse très lente";
        Lang.tip[12] = "Vitesse extrêmement lente";
        Lang.tip[13] = "Vitesse d'escargot";
        Lang.tip[14] = "Pas de recul";
        Lang.tip[15] = "Recul extrêmement faible";
        Lang.tip[16] = "Recul très faible";
        Lang.tip[17] = "Recul faible";
        Lang.tip[18] = "Recul moyen";
        Lang.tip[19] = "Fort recul";
        Lang.tip[20] = "Très fort recul";
        Lang.tip[21] = "Recul extrêmement fort";
        Lang.tip[22] = "Recul ahurissant";
        Lang.tip[23] = "Équipable";
        Lang.tip[24] = "Objets de vanité";
        Lang.tip[25] = " de défense";
        Lang.tip[26] = "% de puissance de pioche";
        Lang.tip[27] = "% de puissance de hache";
        Lang.tip[28] = "% de puissance de marteau";
        Lang.tip[29] = "Redonne ";
        Lang.tip[30] = " de vie";
        Lang.tip[31] = " de mana";
        Lang.tip[32] = "Consomme ";
        Lang.tip[33] = "Peut être placé";
        Lang.tip[34] = "Munitions";
        Lang.tip[35] = "Consommable";
        Lang.tip[36] = "Matériau";
        Lang.tip[37] = " Durée minute";
        Lang.tip[38] = " Durée seconde";
        Lang.tip[39] = "% de dégâts";
        Lang.tip[40] = "% de vélocité";
        Lang.tip[41] = "% de chance de coup critique";
        Lang.tip[42] = "% de coût de mana";
        Lang.tip[43] = "% de taille";
        Lang.tip[44] = "% de vitesse de projectile";
        Lang.tip[45] = "% de recul";
        Lang.tip[46] = "% de vitesse de déplacement";
        Lang.tip[47] = "% de vitesse de mêlée";
        Lang.tip[48] = "Bonus de collection : ";
        Lang.tip[49] = "Prix de vente : ";
        Lang.tip[50] = "Prix d'achat : ";
        Lang.tip[51] = "Aucune valeur";
        Lang.dt[0] = " n'a pas trouvé l'antidote.";
        Lang.dt[1] = " n'a pas réussi à éteindre l'incendie.";
        Lang.dt[2] = " a essayé de s'échapper.";
        Lang.dt[3] = " s'est fait lécher.";
        Buff.buffName[1] = "Peau d'obsidienne";
        Buff.buffTip[1] = "Immunise contre la lave";
        Buff.buffName[2] = "Régénération";
        Buff.buffTip[2] = "Régénère la vie";
        Buff.buffName[3] = "Rapidité";
        Buff.buffTip[3] = "Vitesse de déplacement augmentée de 25 %";
        Buff.buffName[4] = "Branchies";
        Buff.buffTip[4] = "Permet de respirer sous l'eau comme dans l'air";
        Buff.buffName[5] = "Peau de fer";
        Buff.buffTip[5] = "Augmente la défense de 8";
        Buff.buffName[6] = "Régénération de mana";
        Buff.buffTip[6] = "Régénération de mana augmentée";
        Buff.buffName[7] = "Pouvoir magique";
        Buff.buffTip[7] = "Dégâts magiques augmentés de 20 %";
        Buff.buffName[8] = "Poids plume";
        Buff.buffTip[8] = "Appuyer sur Bas ou Haut pour contrôler la vitesse de descente";
        Buff.buffName[9] = "Spéléologue";
        Buff.buffTip[9] = "Indique l'emplacement des trésors et du minerai";
        Buff.buffName[10] = "Invisibilité";
        Buff.buffTip[10] = "Procure l'invisibilité";
        Buff.buffName[11] = "Brillance";
        Buff.buffTip[11] = "Émet une aura de lumière";
        Buff.buffName[12] = "Vision nocturne";
        Buff.buffTip[12] = "Améliore la vision de nuit";
        Buff.buffName[13] = "Bataille";
        Buff.buffTip[13] = "Augmente la vitesse d'apparition des ennemis";
        Buff.buffName[14] = "Épines";
        Buff.buffTip[14] = "Les attaquants subissent aussi des dégâts";
        Buff.buffName[15] = "Marche sur l'eau";
        Buff.buffTip[15] = "Appuyer sur Bas pour entrer dans l'eau";
        Buff.buffName[16] = "Tir à l'arc";
        Buff.buffTip[16] = "La vitesse et les dégâts des flèches augmentent de 20 %";
        Buff.buffName[17] = "Chasseur";
        Buff.buffTip[17] = "Indique l'emplacement des ennemis";
        Buff.buffName[18] = "Gravitation";
        Buff.buffTip[18] = "Appuyer sur Haut ou Bas pour inverser la gravité";
        Buff.buffName[19] = "Orbe de lumière";
        Buff.buffTip[19] = "Un orbe magique qui émet de la lumière";
        Buff.buffName[20] = "Empoisonnement";
        Buff.buffTip[20] = "Perte lente de vie";
        Buff.buffName[21] = "Maladie des potions";
        Buff.buffTip[21] = "Ne peut plus consommer de potions de soin";
        Buff.buffName[22] = "Obscurité";
        Buff.buffTip[22] = "Diminue la vision de nuit";
        Buff.buffName[23] = "Malédiction";
        Buff.buffTip[23] = "Ne peut utiliser aucun objet";
        Buff.buffName[24] = "En feu !";
        Buff.buffTip[24] = "Perte lente de vie";
        Buff.buffName[25] = "Ivresse";
        Buff.buffTip[25] = "Aptitudes de mêlée augmentées, défense réduite";
        Buff.buffName[26] = "Bien nourri";
        Buff.buffTip[26] = "Amélioration mineure de toutes les stats.";
        Buff.buffName[27] = "Fée";
        Buff.buffTip[27] = "Une fée vous suit";
        Buff.buffName[28] = "Loup-garou";
        Buff.buffTip[28] = "Les aptitudes physiques sont augmentées";
        Buff.buffName[29] = "Clairvoyance";
        Buff.buffTip[29] = "Les pouvoirs magiques sont augmentés";
        Buff.buffName[30] = "Saignement";
        Buff.buffTip[30] = "Ne peut régénérer la vie";
        Buff.buffName[31] = "Confusion";
        Buff.buffTip[31] = "Les mouvements sont inversés";
        Buff.buffName[32] = "Ralentissement";
        Buff.buffTip[32] = "La vitesse de déplacement est réduite";
        Buff.buffName[33] = "Faiblesse";
        Buff.buffTip[33] = "Les aptitudes physiques sont diminuées";
        Buff.buffName[34] = "Peuple des mers";
        Buff.buffTip[34] = "Peut respirer et se déplacer sous l'eau facilement";
        Buff.buffName[35] = "Silencieux";
        Buff.buffTip[35] = "Ne peut pas utiliser des éléments qui nécessitent de mana";
        Buff.buffName[36] = "Armure brisée";
        Buff.buffTip[36] = "La défense est réduite de moitié";
        Buff.buffName[37] = "Peur panique";
        Buff.buffTip[37] = "Vous avez vu quelque chose de terrible et vous ne pouvez vous échapper.";
        Buff.buffName[38] = "La langue";
        Buff.buffTip[38] = "Vous vous êtes fait aspirer dans la bouche";
        Buff.buffName[39] = "Brasier maudit";
        Buff.buffTip[39] = "Perte de vie";
        Buff.buffName[40] = "Cochon d'Inde de compagnie";
        Buff.buffTip[40] = "Simplement adorable";
        Buff.buffName[41] = "Slime de compagnie";
        Buff.buffTip[41] = "Un vrai pot de colle";
        Buff.buffName[42] = "Tiphia de compagnie";
        Buff.buffTip[42] = "Veut récupérer tout le miel";
        Buff.buffName[43] = "Chauve-souris de compagnie";
        Buff.buffTip[43] = "Veut du sang";
        Buff.buffName[44] = "Loup-garou de compagnie";
        Buff.buffTip[44] = "Le meilleur ami de l'homme";
        Buff.buffName[45] = "Zombie de compagnie";
        Buff.buffTip[45] = "Mange de la cervelle";
        Main.tileName[13] = "Bouteille";
        Main.tileName[14] = "Table";
        Main.tileName[15] = "Chaise";
        Main.tileName[16] = "Enclume";
        Main.tileName[17] = "Fournaise";
        Main.tileName[18] = "Établi";
        Main.tileName[26] = "Autel de démon";
        Main.tileName[77] = "Forge infernale";
        Main.tileName[86] = "Métier à tisser";
        Main.tileName[94] = "Tonnelet";
        Main.tileName[96] = "Marmite";
        Main.tileName[101] = "Bibliothèque";
        Main.tileName[106] = "Scierie";
        Main.tileName[114] = "Atelier du bricoleur";
        Main.tileName[133] = "Forge en adamantine";
        Main.tileName[134] = "Enclume en mythril";
      }
      else
      {
        if (Lang.lang != 5)
          return;
        Lang.misc[0] = "¡El ejército de duendes ha sido derrotado!";
        Lang.misc[1] = "¡Un ejército de duendes se aproxima por el oeste!";
        Lang.misc[2] = "¡Un ejército de duendes se aproxima por el este!";
        Lang.misc[3] = "¡Un ejército duende ha llegado!";
        Lang.misc[4] = "¡La Legión de hielo ha sido derrotada!";
        Lang.misc[5] = "¡La Legión de hielo se aproxima desde el oeste!";
        Lang.misc[6] = "¡La Legión de hielo se aproxima desde el este!";
        Lang.misc[7] = "¡La Legión de hielo ha llegado!";
        Lang.misc[8] = "La luna de sangre está saliendo...";
        Lang.misc[9] = "Sientes que una presencia maligna te observa...";
        Lang.misc[10] = "Sientes un horrible escalofrío por la espalda...";
        Lang.misc[11] = "El eco de los alaridos suena por todas partes...";
        Lang.misc[12] = "¡Tu mundo ha sido bendecido con cobalto!";
        Lang.misc[13] = "¡Tu mundo ha sido bendecido con mithril!";
        Lang.misc[14] = "¡Tu mundo ha sido bendecido con adamantita!";
        Lang.misc[15] = "Los ancestrales espíritus de la luz y la oscuridad han sido liberados.";
        Lang.misc[16] = " se despertó.";
        Lang.misc[17] = " ha caído en combate.";
        Lang.misc[18] = " llegó.";
        Lang.misc[19] = " fue asesinado...";
        Lang.misc[20] = "Los Gemelos";
        Lang.misc[21] = "Operación no válida en este estado.";
        Lang.misc[22] = "No tienes la misma versión que este servidor.";
        Lang.misc[23] = "Jugadores conectados: ";
        Lang.misc[24] = " ha activado PvP!";
        Lang.misc[25] = " ha desactivado PvP!";
        Lang.misc[26] = " ya no pertenece a ningún bando.";
        Lang.misc[27] = " se ha unido al bando rojo.";
        Lang.misc[28] = " se ha unido al bando verde.";
        Lang.misc[29] = " se ha unido al bando azul.";
        Lang.misc[30] = " se ha unido al bando amarillo.";
        Lang.misc[31] = "Bienvenido, ";
        Lang.misc[32] = " se ha unido.";
        Lang.misc[33] = " se ha marchado.";
        Lang.misc[34] = "¡Los gemelos se han despertado!";
        Lang.misc[35] = "¡Los gemelos han sido derrotados!";
        Lang.misc[36] = "¡Ha caído un meteorito!";
        Lang.menu[0] = "Ingredientes";
        Lang.menu[1] = " en el inventario)";
        Lang.menu[2] = "Desconectar";
        Lang.menu[3] = "¡Atención!";
        Lang.menu[4] = "<c>Cuando veas este icono\n\n\nel juego está <i>guardando</i> datos.";
        Lang.menu[5] = "¡Error!";
        Lang.menu[6] = "Jugar en línea";
        Lang.menu[7] = "Solo por invitación";
        Lang.menu[8] = "Se ha encontrado un servidor...";
        Lang.menu[9] = "¡Error al cargar!";
        Lang.menu[10] = "Iniciar juego";
        Lang.menu[11] = "Crear mundo";
        Lang.menu[12] = "Se ha encontrado un personaje dañado y se ha eliminado.";
        Lang.menu[13] = "Jugar";
        Lang.menu[14] = "Configuración";
        Lang.menu[15] = "Salir del juego";
        Lang.menu[16] = "Crear personaje";
        Lang.menu[17] = (string) (object) '\x008A' + (object) "Eliminar";
        Lang.menu[18] = "Pelo";
        Lang.menu[19] = "Ojos";
        Lang.menu[20] = "Piel";
        Lang.menu[21] = "Ropa";
        Lang.menu[22] = "Hombre";
        Lang.menu[23] = "Mujer";
        Lang.menu[24] = "Hardcore";
        Lang.menu[25] = "Dificultad";
        Lang.menu[26] = "Normal";
        Lang.menu[27] = "Al azar";
        Lang.menu[28] = "Crear";
        Lang.menu[29] = "La muerte es para siempre";
        Lang.menu[30] = "Suelta todos los objetos al morir";
        Lang.menu[31] = "Suelta el dinero al morir";
        Lang.menu[32] = "Seleccionar dificultad";
        Lang.menu[33] = "Camisa";
        Lang.menu[34] = "Camiseta";
        Lang.menu[35] = "Pantalones";
        Lang.menu[36] = "Zapatos";
        Lang.menu[37] = "Pelo";
        Lang.menu[38] = "Color de pelo";
        Lang.menu[39] = "Color de ojos";
        Lang.menu[40] = "Color de piel";
        Lang.menu[41] = "Color de la camisa";
        Lang.menu[42] = "Color de la camiseta";
        Lang.menu[43] = "Color de los pantalones";
        Lang.menu[44] = "Color de los zapatos";
        Lang.menu[45] = "Escribir nombre del personaje:";
        Lang.menu[46] = "Eliminar ";
        Lang.menu[47] = "Créditos";
        Lang.menu[48] = "Escribir nombre del mundo:";
        Lang.menu[49] = "¿Quieres salir sin crear un personaje?";
        Lang.menu[50] = "Elige un personaje";
        Lang.menu[51] = "Esperando que empiece el juego...";
        Lang.menu[52] = "Pulsa START";
        Lang.menu[53] = "Nombre del personaje";
        Lang.menu[54] = "Guardando personaje...";
        Lang.menu[55] = "Nombre del mundo";
        Lang.menu[56] = "Mundo";
        Lang.menu[57] = "¡Punto de resurreción establecido!";
        Lang.menu[58] = "Distancia recorrida";
        Lang.menu[59] = "Recursos extraídos de la mina y almacenados";
        Lang.menu[60] = "Objetos creados";
        Lang.menu[61] = "Objetos usados";
        Lang.menu[62] = "Enemigos finales normales derrotados";
        Lang.menu[63] = "Enemigos finales del modo difícil derrotados";
        Lang.menu[64] = "Número de muertes";
        Lang.menu[65] = "Volumen";
        Lang.menu[66] = "No se ha seleccionado ningún dispositivo de almacenamiento.";
        Lang.menu[67] = "Autoguardado activado";
        Lang.menu[68] = "Autoguardado desactivado";
        Lang.menu[69] = "No hay dispositivo de almacenamiento";
        Lang.menu[70] = "Se ha extraído el dispositivo de almacenamiento. Se ha desactivado la función de guardado.";
        Lang.menu[71] = "Sugerencias activadas";
        Lang.menu[72] = "Sugerencias desactivadas";
        Lang.menu[73] = "Obteniendo información del mundo...";
        Lang.menu[74] = "Obteniendo datos del título...";
        Lang.menu[75] = "Aceptando invitación...";
        Lang.menu[76] = "Buscando...";
        Lang.menu[77] = "No se han encontrado juegos";
        Lang.menu[78] = "Jugadores: ";
        Lang.menu[79] = "~ VACÍO ~";
        Lang.menu[80] = "Uniéndose al juego...";
        Lang.menu[81] = "PvP";
        Lang.menu[82] = "Equipo";
        Lang.menu[83] = "Tus mundos";
        Lang.menu[84] = "Unirse al juego";
        Lang.menu[85] = "Profundidad: ";
        Lang.menu[86] = "m. hacia abajo";
        Lang.menu[87] = "m. hacia arriba";
        Lang.menu[88] = "nivel";
        Lang.menu[89] = "Tutorial";
        Lang.menu[90] = "Aceptar";
        Lang.menu[91] = "Elegir tamaño del mundo:";
        Lang.menu[92] = "Pequeño";
        Lang.menu[93] = "Mediano";
        Lang.menu[94] = "Grande";
        Lang.menu[95] = "Posición: ";
        Lang.menu[96] = "m este";
        Lang.menu[97] = "m oeste";
        Lang.menu[98] = "centro";
        Lang.menu[99] = "Guardar juego";
        Lang.menu[100] = "Salir al menú principal";
        Lang.menu[101] = "Menú principal";
        Lang.menu[102] = "Los datos de configuración estaban dañados y se han eliminado.";
        Lang.menu[103] = "Se han encontrado datos de mundo dañados y se han eliminado.";
        Lang.menu[104] = "Sí";
        Lang.menu[105] = "No";
        Lang.menu[106] = "Marcadores";
        Lang.menu[107] = "Logros";
        Lang.menu[108] = "Ayuda y opciones";
        Lang.menu[109] = "Desbloquear juego completo";
        Lang.menu[110] = "Cómo se juega";
        Lang.menu[111] = "Controles";
        Lang.menu[112] = "Reanudar juego";
        Lang.gen[0] = "Generando terreno del mundo...";
        Lang.gen[1] = "Añadiendo arena...";
        Lang.gen[2] = "Generando colinas...";
        Lang.gen[3] = "Amontonando tierra...";
        Lang.gen[4] = "Añadiendo rocas a la tierra...";
        Lang.gen[5] = "Añadiendo tierra a las rocas...";
        Lang.gen[6] = "Añadiendo arcilla...";
        Lang.gen[7] = "Generando agujeros aleatorios...";
        Lang.gen[8] = "Generando cuevas pequeñas...";
        Lang.gen[9] = "Generando cuevas grandes...";
        Lang.gen[10] = "Generando cuevas en la superficie...";
        Lang.gen[11] = "Generando selva...";
        Lang.gen[12] = "Generando islas flotantes...";
        Lang.gen[13] = "Añadiendo parcelas de champiñones...";
        Lang.gen[14] = "Añadiendo lodo a la tierra...";
        Lang.gen[15] = "Añadiendo cieno...";
        Lang.gen[16] = "Añadiendo tesoros...";
        Lang.gen[17] = "Añadiendo telas de araña...";
        Lang.gen[18] = "Creando Inframundo...";
        Lang.gen[19] = "Añadiendo cursos de agua...";
        Lang.gen[20] = "Corrompiendo el mundo...";
        Lang.gen[21] = "Generando cuevas en montañas...";
        Lang.gen[22] = "Creando playas...";
        Lang.gen[23] = "Añadiendo gemas...";
        Lang.gen[24] = "Gravitando arena...";
        Lang.gen[25] = "Limpiando de tierra los entornos...";
        Lang.gen[26] = "Colocando altares...";
        Lang.gen[27] = "Distribuyendo líquidos...";
        Lang.gen[28] = "Colocando cristales de vida...";
        Lang.gen[29] = "Colocando estatuas...";
        Lang.gen[30] = "Ocultando tesoro...";
        Lang.gen[31] = "Ocultando más tesoros...";
        Lang.gen[32] = "Ocultando tesoro en la selva...";
        Lang.gen[33] = "Ocultando tesoro en el agua...";
        Lang.gen[34] = "Colocando trampas...";
        Lang.gen[35] = "Colocando objetos quebradizos...";
        Lang.gen[36] = "Colocando forjas infernales...";
        Lang.gen[37] = "Plantando césped...";
        Lang.gen[38] = "Plantando cactus...";
        Lang.gen[39] = "Plantando girasoles...";
        Lang.gen[40] = "Plantando árboles...";
        Lang.gen[41] = "Plantando hierbas...";
        Lang.gen[42] = "Plantando hierbajos...";
        Lang.gen[43] = "Plantando enredaderas...";
        Lang.gen[44] = "Plantando flores...";
        Lang.gen[45] = "Cultivando champiñones...";
        Lang.gen[46] = "Se ha perdido la conexión con el anfitrión.";
        Lang.gen[47] = "Reiniciando objetos del juego...";
        Lang.gen[48] = "Estableciendo modo Difícil...";
        Lang.gen[49] = "Guardando datos del mundo...";
        Lang.gen[50] = "Copia de seguridad del archivo del mundo...";
        Lang.gen[51] = "Cargando datos del mundo...";
        Lang.gen[52] = "Comprobando alineación de la cuadrícula...";
        Lang.gen[53] = "Se ha producido un error al leer del dispositivo de almacenamiento.";
        Lang.gen[54] = "Se ha producido un error al escribir en el dispositivo de almacenamiento.";
        Lang.gen[55] = "Encontrando bordes de la cuadrícula...";
        Lang.gen[56] = "Adición de nieve ...";
        Lang.gen[57] = "Mundo";
        Lang.gen[58] = "Creando mazmorra...";
        Lang.inter[0] = "Cancelar";
        Lang.inter[1] = "Salir sin guardar";
        Lang.inter[2] = "Guardar y salir";
        Lang.inter[3] = "Papelera";
        Lang.inter[4] = "Inventario";
        Lang.inter[5] = "¿Quieres volver al menú principal?";
        Lang.inter[6] = "Potenciadores";
        Lang.inter[7] = "Vivienda";
        Lang.inter[8] = "Esta casa no cumple los requisitos.";
        Lang.inter[9] = "Accesorios";
        Lang.inter[10] = " Defensa";
        Lang.inter[11] = "Vanidad";
        Lang.inter[12] = "Casco";
        Lang.inter[13] = "Camisa";
        Lang.inter[14] = "Pantalones";
        Lang.inter[15] = " platino ";
        Lang.inter[16] = " oro ";
        Lang.inter[17] = " plata ";
        Lang.inter[18] = " cobre";
        Lang.inter[19] = "Reciclar";
        Lang.inter[20] = "No ha sido posible crear una sesión de red.";
        Lang.inter[21] = "No ha sido posible unirse a la sesión. La sesión está completa o no se puede encontrar.";
        Lang.inter[22] = "Objetos necesarios:";
        Lang.inter[23] = "Ninguno";
        Lang.inter[24] = "Alternar el modo de agarre";
        Lang.inter[25] = "Creación";
        Lang.inter[26] = "Monedas";
        Lang.inter[27] = "Munición";
        Lang.inter[28] = "Tienda";
        Lang.inter[29] = (string) (object) '\x008C' + (object) "Saquearlo todo";
        Lang.inter[30] = (string) (object) '\x008C' + (object) "Depositarlo todo";
        Lang.inter[31] = (string) (object) '\x008C' + (object) "Apilamiento rápido";
        Lang.inter[32] = "Hucha";
        Lang.inter[33] = "Caja fuerte";
        Lang.inter[34] = "Hora: ";
        Lang.inter[35] = "¿Seguro que quieres abandonar?";
        Lang.inter[36] = "Se ha perdido la conexión con Xbox LIVE.";
        Lang.inter[37] = "Número de entradas: ";
        Lang.inter[38] = "Te han matado...";
        Lang.inter[39] = "Esta vivienda es válida.";
        Lang.inter[40] = "Esta vivienda no es válida.";
        Lang.inter[41] = "Esta vivienda ya está ocupada.";
        Lang.inter[42] = "Esta vivienda está corrompida.";
        Lang.inter[43] = "Este perfil de jugador no posee los privilegios necesarios para unirse. Puede que necesites una suscripción LIVE Gold o tengas que cambiar los ajustes parentales.";
        Lang.inter[44] = "Recibiendo datos de casillas";
        Lang.inter[45] = "Equipar";
        Lang.inter[46] = "Coste: ";
        Lang.inter[47] = "Guardar";
        Lang.inter[48] = "Editar";
        Lang.inter[49] = "Estado";
        Lang.inter[50] = "Maldición";
        Lang.inter[51] = "Ayuda";
        Lang.inter[52] = "Cerrar";
        Lang.inter[53] = "Agua";
        Lang.inter[54] = "Sanar";
        Lang.inter[55] = "Proporciona consejos y notas sobre cómo crear objetos.";
        Lang.inter[56] = "Vende objetos básicos.";
        Lang.inter[57] = "Cura las heridas y los suavizadores.";
        Lang.inter[58] = "Vende explosivos.";
        Lang.inter[59] = "Vende objetos naturales y te informa del estado del mundo.";
        Lang.inter[60] = "Vende armas y munición.";
        Lang.inter[61] = "Vende ropa de moda.";
        Lang.inter[62] = "Vende herramientas y cables.";
        Lang.inter[63] = "Vende artilugios útiles y vuelve a forjar objetos.";
        Lang.inter[64] = "Vende objetos y accesorios mágicos.";
        Lang.inter[65] = "Un viejo amigo muy simpático.";
        Lang.inter[66] = "La partida ha terminado";
        Lang.inter[67] = "La partida ha sido finalizada por el anfitrión.";
        Lang.inter[68] = "No es posible unirse debido a los privilegios de uno de los jugadores.";
        Lang.inter[69] = "Actualmente estás jugando a la versión de prueba. Compra la versión completa del juego para jugar en línea.";
        Lang.inter[70] = "No hay espacio suficiente en el dispositivo de almacenamiento seleccionado.";
        Lang.inter[71] = "Jugar en el modo pantalla dividida con el ajuste de vídeo de definición estándar provocará que el texto de la pantalla de juego sea difícil de leer. Recomendamos usar el ajuste de alta definición para disfrutar al máximo de la experiencia de juego.";
        Lang.inter[72] = "Prohibir Mundo";
        Lang.inter[73] = "¿Seguro que quieres añadir este mundo a tu lista de Mundos Prohibidos?\n\nSi seleccionas Aceptar también saldrás de esta partida.";
        Lang.inter[74] = "¡ATENCIÓN! El mundo al que te intentas unir está en tu lista de Mundos Prohibidos.\n\nSi decides unirte a esta partida este mundo será eliminado de tu lista de Mundos Prohibidos.";
        Lang.inter[75] = "Continuar";
        Lang.inter[76] = "(En espera de aprobación)";
        Lang.inter[77] = "(Censurado)";
        Lang.inter[78] = "La partida guardada \"{0}\" fue trasladada desde otro perfil y será eliminado.";
        Lang.inter[79] = "El juego finalizará debido a los ajustes de contenido creado por los miembros de uno de los perfiles que ha iniciado sesión.";
        Lang.tip[0] = "Equipado en la ranura de vanidad";
        Lang.tip[1] = "No aumentará ninguna estadística";
        Lang.tip[2] = " daño en el cuerpo a cuerpo";
        Lang.tip[3] = " daño a distancia";
        Lang.tip[4] = " daño por magia";
        Lang.tip[5] = "% probabilidad de ataque crítico";
        Lang.tip[6] = "Velocidad de vértigo";
        Lang.tip[7] = "Gran velocidad";
        Lang.tip[8] = "Veloz";
        Lang.tip[9] = "Velocidad normal";
        Lang.tip[10] = "Lento";
        Lang.tip[11] = "Muy lento";
        Lang.tip[12] = "Exageradamente lento";
        Lang.tip[13] = "Velocidad de tortuga";
        Lang.tip[14] = "Sin retroceso";
        Lang.tip[15] = "Retroceso sumamente débil";
        Lang.tip[16] = "Retroceso muy débil";
        Lang.tip[17] = "Retroceso débil";
        Lang.tip[18] = "Retroceso normal";
        Lang.tip[19] = "Retroceso fuerte";
        Lang.tip[20] = "Retroceso muy fuerte";
        Lang.tip[21] = "Retroceso tremendamente fuerte";
        Lang.tip[22] = "Retroceso descomunal";
        Lang.tip[23] = "Equipable";
        Lang.tip[24] = "Objeto decorativo";
        Lang.tip[25] = " defensa";
        Lang.tip[26] = "% potencia de pico";
        Lang.tip[27] = "% potencia de hacha";
        Lang.tip[28] = "% potencia de martillo";
        Lang.tip[29] = "Restablece ";
        Lang.tip[30] = " vida";
        Lang.tip[31] = " maná";
        Lang.tip[32] = "Consume ";
        Lang.tip[33] = "Se puede colocar";
        Lang.tip[34] = "Munición";
        Lang.tip[35] = "Consumible";
        Lang.tip[36] = "Material";
        Lang.tip[37] = " minuto/s de duración";
        Lang.tip[38] = " segundo/s de duración";
        Lang.tip[39] = "% daño";
        Lang.tip[40] = "% velocidad";
        Lang.tip[41] = "% probabilidad de ataque crítico";
        Lang.tip[42] = "% coste de maná";
        Lang.tip[43] = "% tamaño";
        Lang.tip[44] = "% velocidad de proyectil";
        Lang.tip[45] = "% retroceso";
        Lang.tip[46] = "% velocidad de movimiento";
        Lang.tip[47] = "% velocidad en el cuerpo a cuerpo";
        Lang.tip[48] = "Bonus conjunto: ";
        Lang.tip[49] = "Precio de venta: ";
        Lang.tip[50] = "Precio de compra: ";
        Lang.tip[51] = "Sin valor";
        Lang.dt[0] = " no logró encontrar el antídoto.";
        Lang.dt[1] = " no pudo extinguir el fuego.";
        Lang.dt[2] = " intentó escapar.";
        Lang.dt[3] = " recibió una paliza.";
        Buff.buffName[1] = "Piel obsidiana";
        Buff.buffTip[1] = "Inmune a la lava";
        Buff.buffName[2] = "Regeneración";
        Buff.buffTip[2] = "Regenera la vida";
        Buff.buffName[3] = "Rapidez";
        Buff.buffTip[3] = "Aumenta en un 25% la velocidad de movimiento";
        Buff.buffName[4] = "Agallas";
        Buff.buffTip[4] = "Permite respirar agua en lugar de aire";
        Buff.buffName[5] = "Piel de hierro";
        Buff.buffTip[5] = "Aumenta la defensa en 8";
        Buff.buffName[6] = "Regeneración de maná";
        Buff.buffTip[6] = "Aumenta la regeneración de maná";
        Buff.buffName[7] = "Poder mágico";
        Buff.buffTip[7] = "Aumenta el daño mágico en un 20%";
        Buff.buffName[8] = "Caída de pluma";
        Buff.buffTip[8] = "Pulsa ARRIBA o ABAJO para controlar la velocidad de descenso";
        Buff.buffName[9] = "Espeleólogo";
        Buff.buffTip[9] = "Muestra la ubicación de tesoros y minerales";
        Buff.buffName[10] = "Invisibilidad";
        Buff.buffTip[10] = "Proporciona invisibilidad";
        Buff.buffName[11] = "Brillo";
        Buff.buffTip[11] = "Emite luz";
        Buff.buffName[12] = "Noctámbulo";
        Buff.buffTip[12] = "Mejora la visión nocturna";
        Buff.buffName[13] = "Batalla";
        Buff.buffTip[13] = "Aumenta la velocidad de regeneración del enemigo";
        Buff.buffName[14] = "Espinas";
        Buff.buffTip[14] = "Los atacantes también sufren daños";
        Buff.buffName[15] = "Flotación";
        Buff.buffTip[15] = "Pulsa ABAJO para sumergirte";
        Buff.buffName[16] = "Tiro con arco";
        Buff.buffTip[16] = "Aumenta en un 20% la velocidad y el daño de las flechas";
        Buff.buffName[17] = "Cazador";
        Buff.buffTip[17] = "Muestra la ubicación de los enemigos";
        Buff.buffName[18] = "Gravedad";
        Buff.buffTip[18] = "Pulsa ARRIBA o ABAJO para invertir la gravedad";
        Buff.buffName[19] = "Orbe de luz";
        Buff.buffTip[19] = "Orbe mágico que proporciona luz";
        Buff.buffName[20] = "Veneno";
        Buff.buffTip[20] = "Reduce el nivel de vida lentamente";
        Buff.buffName[21] = "Enfermedad de poción";
        Buff.buffTip[21] = "Impide seguir consumiendo remedios curativos";
        Buff.buffName[22] = "Oscuridad";
        Buff.buffTip[22] = "Disminuye la claridad";
        Buff.buffName[23] = "Maldición";
        Buff.buffTip[23] = "No se puede usar ningún objeto";
        Buff.buffName[24] = "Llamas";
        Buff.buffTip[24] = "Reduce el nivel de vida lentamente";
        Buff.buffName[25] = "Beodo";
        Buff.buffTip[25] = "Mejora el ataque cuerpo a cuerpo pero reduce la defensa";
        Buff.buffName[26] = "Bien alimentado";
        Buff.buffTip[26] = "Pequeñas mejoras a todas las estadísticas";
        Buff.buffName[27] = "Hada";
        Buff.buffTip[27] = "Un hada te acompaña";
        Buff.buffName[28] = "Hombre lobo";
        Buff.buffTip[28] = "Aumenta la capacidad física";
        Buff.buffName[29] = "Clarividencia";
        Buff.buffTip[29] = "Aumenta los poderes mágicos";
        Buff.buffName[30] = "Hemorragia";
        Buff.buffTip[30] = "No se puede recuperar vida";
        Buff.buffName[31] = "Confusión";
        Buff.buffTip[31] = "Invierte los movimientos";
        Buff.buffName[32] = "Lentitud";
        Buff.buffTip[32] = "Disminuye la velocidad de movimiento";
        Buff.buffName[33] = "Debilidad";
        Buff.buffTip[33] = "Disminuye la capacidad física";
        Buff.buffName[34] = "Tritón";
        Buff.buffTip[34] = "Respira y se mueve bajo el agua con facilidad";
        Buff.buffName[35] = "Silencio";
        Buff.buffTip[35] = "No puede utilizar los artículos que requieren maná";
        Buff.buffName[36] = "Armadura rota";
        Buff.buffTip[36] = "La defensa disminuye hasta la mitad";
        Buff.buffName[37] = "Terror";
        Buff.buffTip[37] = "Has visto algo horrible... ¡No hay escapatoria!";
        Buff.buffName[38] = "La Lengua";
        Buff.buffTip[38] = "Te succiona hacia la Boca";
        Buff.buffName[39] = "El Averno";
        Buff.buffTip[39] = "Reduce el nivel de vida progresivamente";
        Buff.buffName[40] = "Conejilla de Indias mascota";
        Buff.buffTip[40] = "Simplementa entrañable";
        Buff.buffName[41] = "Slime mascota";
        Buff.buffTip[41] = "Una verdadera pelotita slime";
        Buff.buffName[42] = "Avispa mascota";
        Buff.buffTip[42] = "Quiere toda la miel";
        Buff.buffName[43] = "Murciélago mascota";
        Buff.buffTip[43] = "En busca de sangre";
        Buff.buffName[44] = "Hombre lobo mascota";
        Buff.buffTip[44] = "El mejor amigo del hombre";
        Buff.buffName[45] = "Zombi mascota";
        Buff.buffTip[45] = "Come cerebros";
        Main.tileName[13] = "Botella";
        Main.tileName[14] = "Mesa";
        Main.tileName[15] = "Silla";
        Main.tileName[16] = "Yunque";
        Main.tileName[17] = "Forja";
        Main.tileName[18] = "Banco de trabajo";
        Main.tileName[26] = "Altar demoníaco";
        Main.tileName[77] = "Forja infernal";
        Main.tileName[86] = "Telar";
        Main.tileName[94] = "Barrica";
        Main.tileName[96] = "Perol";
        Main.tileName[101] = "Librería";
        Main.tileName[106] = "Serrería";
        Main.tileName[114] = "Taller de chapuzas";
        Main.tileName[133] = "Forja de adamantita";
        Main.tileName[134] = "Yunque de mithril";
      }
    }

    public static uint deathMsg(int plr = -1, int npc = 0, int proj = 0, int other = -1)
    {
      return (uint) (plr & (int) byte.MaxValue | (npc & 1023) << 8 | (proj & (int) byte.MaxValue) << 18 | (other & 63) << 26);
    }

    public static string deathMsgString(uint encoded)
    {
      uint num1 = encoded >> 26 & 63U;
      if (num1 >= 3U && num1 < 63U)
        return Lang.dt[(IntPtr) (num1 - 3U)];
      uint num2 = encoded & (uint) byte.MaxValue;
      int l = (int) encoded << 14 >> 22;
      uint num3 = encoded >> 18 & (uint) byte.MaxValue;
      string str1 = (string) null;
      if (Lang.lang <= 1)
      {
        string str2;
        switch (Main.rand.Next(26))
        {
          case 0:
            str2 = " was slain";
            break;
          case 1:
            str2 = " was eviscerated";
            break;
          case 2:
            str2 = " was murdered";
            break;
          case 3:
            str2 = "'s face was torn off";
            break;
          case 4:
            str2 = "'s entrails were ripped out";
            break;
          case 5:
            str2 = " was destroyed";
            break;
          case 6:
            str2 = "'s skull was crushed";
            break;
          case 7:
            str2 = " got massacred";
            break;
          case 8:
            str2 = " got impaled";
            break;
          case 9:
            str2 = " was torn in half";
            break;
          case 10:
            str2 = " was decapitated";
            break;
          case 11:
            str2 = " let their arms get torn off";
            break;
          case 12:
            str2 = " watched their innards become outards";
            break;
          case 13:
            str2 = " was brutally dissected";
            break;
          case 14:
            str2 = "'s extremities were detached";
            break;
          case 15:
            str2 = "'s body was mangled";
            break;
          case 16:
            str2 = "'s vital organs were ruptured";
            break;
          case 17:
            str2 = " was turned into a pile of flesh";
            break;
          case 18:
            str2 = " was removed from " + Main.worldName;
            break;
          case 19:
            str2 = " got snapped in half";
            break;
          case 20:
            str2 = " was cut down the middle";
            break;
          case 21:
            str2 = " was chopped up";
            break;
          case 22:
            str2 = "'s plead for death was answered";
            break;
          case 23:
            str2 = "'s meat was ripped off the bone";
            break;
          case 24:
            str2 = "'s flailing about was finally stopped";
            break;
          default:
            str2 = "'s head was removed";
            break;
        }
        if (num2 < 8U)
        {
          if ((int) num3 != 0)
            str1 = str2 + " by " + Main.player[(IntPtr) num2].name + "'s " + Lang.PROJECTILE_NAMES[(IntPtr) num3] + ".";
          else
            str1 = str2 + " by " + Main.player[(IntPtr) num2].name + "'s " + Lang.itemName((int) Main.player[(IntPtr) num2].inventory[(int) Main.player[(IntPtr) num2].selectedItem].netID) + ".";
        }
        else if (l != 0)
          str1 = str2 + " by " + Lang.npcName(l) + ".";
        else if ((int) num3 != 0)
          str1 = str2 + " by " + Lang.PROJECTILE_NAMES[(IntPtr) num3] + ".";
        else if ((int) num1 == 0)
          str1 = Main.rand.Next(2) != 0 ? " didn't bounce." : " fell to their death.";
        else if ((int) num1 == 1)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " forgot to breathe.";
              break;
            case 1:
              str1 = " is sleeping with the fish.";
              break;
            case 2:
              str1 = " drowned.";
              break;
            case 3:
              str1 = " is shark food.";
              break;
          }
        }
        else if ((int) num1 == 2)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " got melted.";
              break;
            case 1:
              str1 = " was incinerated.";
              break;
            case 2:
              str1 = " tried to swim in lava.";
              break;
            case 3:
              str1 = " likes to play in magma.";
              break;
          }
        }
        else
          str1 = str2 + ".";
      }
      else if (Lang.lang == 2)
      {
        string str2;
        switch (Main.rand.Next(15))
        {
          case 0:
            str2 = " wurde getötet von";
            break;
          case 1:
            str2 = " wurde vernichtet";
            break;
          case 2:
            str2 = " wurde ermordet";
            break;
          case 3:
            str2 = " wurde das Gesicht heruntergerissen";
            break;
          case 4:
            str2 = " wurden die Eingeweide herausgerissen";
            break;
          case 5:
            str2 = " wurde zerstört";
            break;
          case 6:
            str2 = " wurde der Schädel eingeschlagen";
            break;
          case 7:
            str2 = " wurde massakriert";
            break;
          case 8:
            str2 = " wurde gepfählt";
            break;
          case 9:
            str2 = " wurde in zwei Hälften gerissen";
            break;
          case 10:
            str2 = " wurde geköpft";
            break;
          case 11:
            str2 = "wurden die Arme ausgerissen";
            break;
          case 12:
            str2 = " sah dabei zu, wie die eigenen Eingeweide herausquollen";
            break;
          case 13:
            str2 = " wurde brutal seziert";
            break;
          default:
            str2 = " liess sich den Kopf wegreissen";
            break;
        }
        if ((int) num1 == 0)
          str1 = Main.rand.Next(2) != 0 ? " ist nicht gesprungen." : " stürzte in den Tod.";
        else if ((int) num1 == 1)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " hat vergessen zu atmen.";
              break;
            case 1:
              str1 = " hat jetzt ein feuchtes Grab bei den Fischen.";
              break;
            case 2:
              str1 = " ist ertrunken.";
              break;
            case 3:
              str1 = " ist jetzt Fischfutter.";
              break;
          }
        }
        else if ((int) num1 == 2)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " ist geschmolzen.";
              break;
            case 1:
              str1 = " wurde eingeäschert.";
              break;
            case 2:
              str1 = " versuchte, in Lava zu baden.";
              break;
            case 3:
              str1 = " spielt gern mit Magma.";
              break;
          }
        }
        else
          str1 = str2 + ".";
      }
      else if (Lang.lang == 3)
      {
        int num4 = Main.rand.Next(13);
        if (num4 == 0)
          ;
        string str2 = num4 != 0 ? (num4 != 1 ? (num4 != 2 ? (num4 != 3 ? (num4 != 4 ? (num4 != 5 ? (num4 != 6 ? (num4 != 7 ? (num4 != 8 ? (num4 != 9 ? (num4 != 10 ? (num4 != 11 ? " è stato tagliato a metà" : " le braccia sono state spezzate") : " è stato decapitato") : " è stato spezzato a metà") : " ha visto uscire le sue interiora ") : " è stato massacrato") : " il cranio è stato spappolato") : " è stato distrutto") : " è stato massacrato") : " è stato distrutto") : " è stato assassinato") : " è stato sventrato") : " è stato ucciso";
        if ((int) num1 == 0)
          str1 = Main.rand.Next(2) != 0 ? " non poteva rimbalzare." : " sente la sua morte.";
        else if ((int) num1 == 1)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " ha dimenticato di respirare.";
              break;
            case 1:
              str1 = " sta dormendo con i pesci.";
              break;
            case 2:
              str1 = " è affogato.";
              break;
            case 3:
              str1 = " è un pasto dello squalo.";
              break;
          }
        }
        else if ((int) num1 == 2)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " si è sciolto.";
              break;
            case 1:
              str1 = " si è incenerito.";
              break;
            case 2:
              str1 = " ha provato a nuotare nella lava.";
              break;
            case 3:
              str1 = " piace giocare nel magma.";
              break;
          }
        }
        else
          str1 = str2 + ".";
      }
      else if (Lang.lang == 4)
      {
        string str2;
        switch (Main.rand.Next(14))
        {
          case 0:
            str2 = " s'est fait massacrer";
            break;
          case 1:
            str2 = " s'est fait éviscérer";
            break;
          case 2:
            str2 = " s'est fait assassiner";
            break;
          case 3:
            str2 = " s'est fait défigurer";
            break;
          case 4:
            str2 = " a vu ses entrailles tomber à ses pieds";
            break;
          case 5:
            str2 = " s'est fait détruire";
            break;
          case 6:
            str2 = " s'est fait arracher la tête";
            break;
          case 7:
            str2 = " s'est fait tuer";
            break;
          case 8:
            str2 = " s'est fait empaler";
            break;
          case 9:
            str2 = " s'est fait brutalement découper";
            break;
          case 10:
            str2 = " a été décapité";
            break;
          case 11:
            str2 = " s'est fait déchiqueter les bras";
            break;
          case 12:
            str2 = " s'est fait couper en tranches";
            break;
          default:
            str2 = " a perdu la tête";
            break;
        }
        if ((int) num1 == 0)
          str1 = Main.rand.Next(2) != 0 ? " ne bouge plus." : " a cassé sa pipe.";
        else if ((int) num1 == 1)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " a cessé de respirer.";
              break;
            case 1:
              str1 = " mange les pissenlits par la racine.";
              break;
            case 2:
              str1 = " a coulé à pic.";
              break;
            case 3:
              str1 = " nourrit les requins.";
              break;
          }
        }
        else if ((int) num1 == 2)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " a fondu.";
              break;
            case 1:
              str1 = " s'est fait incinérer.";
              break;
            case 2:
              str1 = " a tenté de nager dans la lave.";
              break;
            case 3:
              str1 = " aime barboter dans le magma.";
              break;
          }
        }
        else
          str1 = str2 + ".";
      }
      else if (Lang.lang == 5)
      {
        string str2 = " fue asesinado";
        if ((int) num1 == 0)
          str1 = Main.rand.Next(2) != 0 ? " no saltó a tiempo." : " ha caído al vacío.";
        else if ((int) num1 == 1)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " se olvidó de respirar.";
              break;
            case 1:
              str1 = " duerme con los peces.";
              break;
            case 2:
              str1 = " se ha ahogado.";
              break;
            case 3:
              str1 = " es pasto de los tiburones.";
              break;
          }
        }
        else if ((int) num1 == 2)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str1 = " se ha calcinado.";
              break;
            case 1:
              str1 = " se ha chamuscado.";
              break;
            case 2:
              str1 = " ha intentado nadar en lava.";
              break;
            case 3:
              str1 = " le gusta jugar con el magma.";
              break;
          }
        }
        else
          str1 = str2 + ".";
      }
      return str1;
    }

    public static string setSystemLang()
    {
      Lang.languageId = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
      int language = 1;
      if (Lang.languageId == "de")
        language = 2;
      else if (Lang.languageId == "fr")
        language = 4;
      else if (Lang.languageId == "es")
        language = 5;
      else if (Lang.languageId == "it")
        language = 3;
      Lang.setLang(language);
      if (GuideExtensions.get_ConsoleRegion() == 0)
        return "ESRB";
      else
        return (string) null;
    }

    public static string tutorial(Tutorial t)
    {
      int index = (int) t;
      switch (Lang.lang)
      {
        case 2:
          return Lang.TUTORIAL_DE[index];
        case 3:
          return Lang.TUTORIAL_IT[index];
        case 4:
          return Lang.TUTORIAL_FR[index];
        case 5:
          return Lang.TUTORIAL_ES[index];
        default:
          return Lang.TUTORIAL_EN[index];
      }
    }

    public enum ID
    {
      NONE,
      ENGLISH,
      GERMAN,
      ITALIAN,
      FRENCH,
      SPANISH,
    }

    public enum CONTROLS
    {
      SELECT,
      BACK,
      CLOSE,
      CHANGE_STORAGE,
      SHOW_PARTY,
      TOGGLE_GRAPPLE_MODE,
      BLACKLIST,
      MOVE_MAP,
      ZOOM,
      TOGGLE_PVP,
      SELECT_TEAM,
      INVITE_PLAYER,
      INVITE_PARTY,
      SHOW_GAMERCARD,
      CREATE_WORLD,
      JOIN,
      X_SHOW_GAMERCARD,
      CHANGE_ITEM,
      CHANGE_MENU,
      GRAPPLE,
      GRAPPLE_ALT,
      INTERACT,
      TALK,
      JUMP,
      INVENTORY,
      DROP,
      TRASH,
      SELL,
      USE,
      DIG,
      CHOP,
      ATTACK,
      HIT,
      BUILD,
      SELECT_ONE,
      SELECT_ALL,
      PLACE,
      PLACE_EQUIPMENT,
      SWAP,
      EQUIP,
      OPEN,
      REFORGE,
      SHOW_RECIPES,
      CRAFT,
      SHOW_ALL,
      SHOW_AVAILABLE,
      INGREDIENTS,
      RECIPES,
      CRAFTING_CATEGORY,
      BUY_ONE,
      BUY_ALL,
      SELL_ITEM_IN_HAND,
      CANCEL_BUFF,
      ASSIGN_TO_ROOM,
      CHECK_HOUSING,
      SHOW_BANNERS,
      HIDE_BANNERS,
      GENDER,
      DIFFICULTY,
      HAIR_TYPE,
      HAIR_COLOR,
      VEST_COLOR,
      SHIRT_COLOR,
      UNDERSHIRT_COLOR,
      PANTS_COLOR,
      SHOE_COLOR,
      SKIN_COLOR,
      EYE_COLOR,
      RANDOMIZE,
      CREATE_CHARACTER,
      CHANGE_CATEGORY,
      SELECT_COLOR,
      SELECT_TYPE,
      SELECT_GENDER,
      SELECT_DIFFICULTY,
      CHANGE_SOUND_VOLUME,
      CHANGE_MUSIC_VOLUME,
      NEXT_PAGE,
      PREVIOUS_PAGE,
      SCROLL_TEXT,
      SWITCH_LEADERBOARD,
      SHOW_TOP,
      SHOW_MYSELF,
      SHOW_FRIENDS,
      EXIT,
      BACK_TO_GAME,
      UNLOCK_FULL_GAME,
    }
  }
}
