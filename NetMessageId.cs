internal enum NetMessageId
{
	CLIENT_SAY_HELLO = 1,
	CLIENT_NAME_HEAD = 4,
	CLIENT_INVENTORY = 5,
	CLIENT_INVENTORY_END = 6,
	CLIENT_REQ_STARTING_DATA = 8,
	CLIENT_REQ_RESYNC = 0xF,
	MSG_PLAYER_LIFE = 0x10,
	MSG_WORLD_CHANGED = 17,
	MSG_PLAYER_DAMAGE = 26,
	MSG_PROJECTILE_INTO = 27,
	MSG_HIT_NPC = 28,
	MSG_KILL_PROJECTILE = 29,
	MSG_PLAYER_VS_PLAYER = 30,
	MSG_REQ_CHEST_ITEM = 0x1F,
	MSG_CHEST_ITEM = 0x20,
	MSG_PLAYER_CHEST_VAR = 33,
	CLIENT_REQ_KILL_TILE = 34,
	MSG_PLAYER_HEAL_EFFECT = 35,
	MSG_PLAYER_ZONE_INFO = 36,
	MSG_PASSWORD = 38,
	MSG_PLAYER_NPC_TALK = 40,
	MSG_PLAYER_GUN_ROTATION = 41,
	MSG_PLAYER_MANA = 42,
	MSG_PLAYER_BUFFS = 50
}
