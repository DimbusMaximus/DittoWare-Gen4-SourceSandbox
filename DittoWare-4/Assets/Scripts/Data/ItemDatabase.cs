//Original Scripts by IIColour (IIColour_Spectrum)

using UnityEngine;
using System.Collections;

public static class ItemDatabase
{
    //		Description Box Width 	(i is 0.2 width, l and space are 0.4 width, j is 0.6 width)
    // Until Description Boxes use the Canvas UI System, auto wrapping text is not possible
    //WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW            //the W's represent the width text should be before a new line
    //WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW1234567890  
    //    e.g.
    //It restores the PP of a Pokemon's
    //moves by 10 points at most each.

    private static ItemData[] items = new ItemData[]
    {
        //Poké Balls
        new ItemData("Poké Ball", ItemData.ItemType.ITEM, ItemData.BattleType.POKEBALLS,
            "A device for capturing wild Pokémon.\nIt is designed as a capsule system.", 200, ItemData.ItemEffect.BALL,
            1f),
        new ItemData("Great Ball", ItemData.ItemType.ITEM, ItemData.BattleType.POKEBALLS,
            "A high-performance Ball, providing a\nbetter catch rate than a Poké Ball.", 600, ItemData.ItemEffect.BALL,
            1.5f),
        new ItemData("Ultra Ball", ItemData.ItemType.ITEM, ItemData.BattleType.POKEBALLS,
            "An ultra-performance Ball, providing\nhigher catch rates than a Great Ball.", 1200,
            ItemData.ItemEffect.BALL, 2f),
        new ItemData("Master Ball", ItemData.ItemType.ITEM, ItemData.BattleType.POKEBALLS,
            "The best Ball with the ultimate level of\nperformance. It will never fail to catch.", 0,
            ItemData.ItemEffect.BALL, 255f),

        //Type-Enhancers
        new ItemData("Miracle Seed", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "An item to be held by Pokémon. It is a life\nimbued seed that boosts Grass moves.", 100),
        new ItemData("Charcoal", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "An item to be held by Pokémon. It is a\ncombustible fuel that boosts Fire moves.", 9800),
        new ItemData("Mystic Water", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "An item to be held by Pokémon. It is a\nteardrop gem that boosts Water moves.", 100),

        //Escape Items
        new ItemData("Escape Rope", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "A long, durable rope. Use it to escape\ninstantly from a cave or a dungeon.", 550,
            ItemData.ItemEffect.UNIQUE),
        new ItemData("Poké Doll", ItemData.ItemType.ITEM, ItemData.BattleType.BATTLEITEMS,
            "A doll that attracts Pokémon. Use it to\nflee from any battle with a wild Pokémon.", 1000,
            ItemData.ItemEffect.FLEE),

        //Valuable Items
        new ItemData("Nugget", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "A nugget of pure gold with a lustrous\ngleam. It can be sold at a high price.", 10000),
        new ItemData("Stardust", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "Lovely, red-colored sand with a loose,\nsilky feel. It can be sold at a high price.", 2000),

        //Evolutionary Stones
        new ItemData("Fire Stone", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "A peculiar stone that will evolve certain\nPokémon. It seems to flicker like flame.", 2100,
            ItemData.ItemEffect.EVOLVE),
        new ItemData("Water Stone", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "A peculiar stone that will evolve certain\nPokémon. It is a clear shimmering blue.", 2100,
            ItemData.ItemEffect.EVOLVE),
        new ItemData("Thunder Stone", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "A peculiar stone that will evolve certain\nPokémon. It seems to glow and crackle.", 2100,
            ItemData.ItemEffect.EVOLVE),
        new ItemData("Leaf Stone", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "A peculiar stone that will evolve certain\nPokémon. It has an odd, soft texture.", 2100,
            ItemData.ItemEffect.EVOLVE),
        new ItemData("Moon Stone", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "A peculiar stone that will evolve certain\nPokémon. It is as black as the night sky.", 10000,
            ItemData.ItemEffect.EVOLVE),
        new ItemData("Dusk Stone", ItemData.ItemType.ITEM, ItemData.BattleType.NONE,
            "A peculiar stone that will evolve certain\nPokémon. It is as dark as dark can be.", 10000,
            ItemData.ItemEffect.EVOLVE),

        //Potions
        new ItemData("Potion", ItemData.ItemType.MEDICINE, ItemData.BattleType.HPPPRESTORE,
            "A spray-type medicine for wounds. It\nrestores a Pokémon's HP by 20 points.", 300, ItemData.ItemEffect.HP,
            20f),
        new ItemData("Super Potion", ItemData.ItemType.MEDICINE, ItemData.BattleType.HPPPRESTORE,
            "A spray-type medicine for wounds. It\nrestores a Pokémon's HP by 50 points.", 700, ItemData.ItemEffect.HP,
            50f),
        new ItemData("Hyper Potion", ItemData.ItemType.MEDICINE, ItemData.BattleType.HPPPRESTORE,
            "A spray-type medicine for wounds. It\nrestores a Pokémon's HP by 200 points.", 1200, ItemData.ItemEffect.HP,
            200f),
        new ItemData("Max Potion", ItemData.ItemType.MEDICINE, ItemData.BattleType.HPPPRESTORE,
            "A spray-type medicine for wounds. It\ncompletely restores a Pokémon's HP.", 2500, ItemData.ItemEffect.HP,
            1f),

        //PP Restore
        new ItemData("Ether", ItemData.ItemType.MEDICINE, ItemData.BattleType.HPPPRESTORE,
            "It restores the PP of a Pokémon's\nselected move by 10 points at most.", 1200, ItemData.ItemEffect.PP, 10f),
        new ItemData("Elixir", ItemData.ItemType.MEDICINE, ItemData.BattleType.HPPPRESTORE,
            "It restores the PP of all of a Pokemon's\nmoves by 10 points at most each.", 3000, ItemData.ItemEffect.PP,
            "ALL", 10f),

        //Status Restore
        new ItemData("Antidote", ItemData.ItemType.MEDICINE, ItemData.BattleType.STATUSHEALER, "A spray-type medicine. ",
            100, ItemData.ItemEffect.STATUS, "POISONED"),
        new ItemData("Paralyze Heal", ItemData.ItemType.MEDICINE, ItemData.BattleType.STATUSHEALER,
            "A spray-type medicine. ", 200, ItemData.ItemEffect.STATUS, "PARALYZED"),
        new ItemData("Awakening", ItemData.ItemType.MEDICINE, ItemData.BattleType.STATUSHEALER,
            "A spray-type medicine. ", 250, ItemData.ItemEffect.STATUS, "ASLEEP"),
        new ItemData("Burn Heal", ItemData.ItemType.MEDICINE, ItemData.BattleType.STATUSHEALER,
            "A spray-type medicine. ", 250, ItemData.ItemEffect.STATUS, "BURNED"),
        new ItemData("Ice Heal", ItemData.ItemType.MEDICINE, ItemData.BattleType.STATUSHEALER, "A spray-type medicine. ",
            250, ItemData.ItemEffect.STATUS, "FROZEN"),
        new ItemData("Full Heal", ItemData.ItemType.MEDICINE, ItemData.BattleType.STATUSHEALER,
            "A spray-type medicine. ", 600, ItemData.ItemEffect.STATUS, "ALL"),

        //TMs
        new ItemData(1,"Work Up", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(2,"Dragon Claw", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(3,"Psyshock", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(4,"Calm Mind", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(5,"Roar", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(6,"Toxic", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(7,"Hail", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(8,"Bulk Up", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(9,"Venoshock", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(10,"Hidden Power", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(11,"Sunny Day", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(12,"Taunt", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(13,"Ice Beam", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(14,"Blizzard", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(15,"Hyper Beam", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(16,"Light Screen", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(17,"Protect", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(18,"Rain Dance", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(19,"Roost", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(20,"Safeguard", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(21,"Frustration", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(22,"Solar Beam", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(23,"Smack Down", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(24,"Thunderbolt", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(25,"Thunder", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(26,"Earthquake", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(27,"Return", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(28,"Leech Life", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(29,"Psychic", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(30,"Shadow Ball", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(31,"Brick Break", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(32,"Double Team", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(33,"Reflect", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(34,"Sludge Wave", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(35,"Flamethrower", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(36,"Sludge Bomb", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(37,"Sandstorm", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(38,"Fire Blast", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(39,"Rock Tomb", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(40,"Aerial Ace", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(41,"Torment", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(42,"Facade", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(43,"Flame Charge", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(44,"Rest", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(45,"Attract", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(46,"Thief", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(47,"Low Sweep", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(48,"Round", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(49,"Echoed Voice", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(50,"Overheat", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(51,"Steel Wing", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(52,"Focus Blast", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(53,"Energy Ball", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(54,"False Swipe", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(55,"Scald", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(56,"Fling", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(57,"Charge Beam", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(58,"Sky Drop", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(59,"Brutal Swing", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(60,"Quash", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(61,"Will-O-Wisp", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(62,"Acrobatics", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(63,"Embargo", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(64,"Explosion", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(65,"Shadow Claw", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(66,"Payback", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(67,"Smart Strike", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(68,"Giga Impact", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(69,"Rock Polish", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(70,"Aurora Veil", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(71,"Stone Edge", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(72,"Volt Switch", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(73,"Thunder Wave", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(74,"Gyro Ball", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(75,"Swords Dance", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(76,"Fly", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(77,"Psych Up", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(78,"Bulldoze", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(79,"Frost Breath", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(80,"Rock Slide", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(81,"X-Scissor", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(82,"Dragon Tail", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(83,"Infestation", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(84,"Poison Jab", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(85,"Dream Eater", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(86,"Grass Knot", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(87,"Swagger", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(88,"Sleep Talk", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(89,"U-turn", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(90,"Substitute", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(91,"Flash Cannon", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(92,"Trick Room", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(93,"Wild Charge", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(94,"Surf", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(95,"Snarl", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(96,"Nature Power", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(97,"Dark Pulse", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(98,"Waterfall", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(99,"Dazzling Gleam", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),
        new ItemData(100,"Confide", ItemData.ItemType.TM, ItemData.BattleType.NONE, "An Attack.", 0),

        //Vitamins
        new ItemData("Rare Candy", ItemData.ItemType.MEDICINE, ItemData.BattleType.NONE,
            "A candy that is packed with energy. It\nraises the level of a single Pokémon.", 4800,
            ItemData.ItemEffect.UNIQUE)
    };

    public static int getItemsLength()
    {
        return items.Length;
    }

    public static ItemData[] getItemTypeArray(ItemData.ItemType itemType)
    {
        ItemData[] result = new ItemData[items.Length];
        int resultPos = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].getItemType() == itemType)
            {
                result[resultPos] = items[i];
                resultPos += 1;
            }
        }
        ItemData[] cleanedResult = new ItemData[resultPos];
        for (int i = 0; i < cleanedResult.Length; i++)
        {
            cleanedResult[i] = result[i];
        }
        string debug = "";
        for (int i = 0; i < cleanedResult.Length; i++)
        {
            debug += cleanedResult[i].getName() + ", ";
        }
        Debug.Log(debug);

        return cleanedResult;
    }

    public static ItemData[] getBattleTypeArray(ItemData.BattleType battleType)
    {
        ItemData[] result = new ItemData[items.Length];
        int resultPos = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].getBattleType() == battleType)
            {
                result[resultPos] = items[i];
                resultPos += 1;
            }
        }
        ItemData[] cleanedResult = new ItemData[resultPos];
        for (int i = 0; i < cleanedResult.Length; i++)
        {
            cleanedResult[i] = result[i];
        }
        string debug = "";
        for (int i = 0; i < cleanedResult.Length; i++)
        {
            debug += cleanedResult[i].getName() + ", ";
        }
        Debug.Log(debug);

        return cleanedResult;
    }

    public static ItemData getItem(int index)
    {
        if (index < items.Length)
        {
            return items[index];
        }
        return null;
    }

    public static ItemData getItem(string name)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].getName() == name)
            {
                return items[i];
            }
        }
        return null;
    }

    public static int getIndexOf(string name)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].getName() == name)
            {
                return i;
            }
        }
        return -1;
    }
}