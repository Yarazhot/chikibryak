using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Souls_Builder.User_Classes
{

    [Serializable]
    abstract class Weapon
    {
        public string name { set; get; }
        public int damage { set; get; }
        public int stamina_consumption { set; get; }
        public int vigour_req { set; get; }
        public int agility_req { set; get; }
        public int magic_req { set; get; }
        public Weapon()
        {
            name = "empty";
            /*damage = 0;
            stamina_consumption = 0;
            vigour_req = 0;
            agility_req = 0;
            magic_req = 0;*/
        }
    }

    [Serializable]
    class Melee : Weapon
    {
        public int crit_factor { set; get; }
        public int crit_chance { set; get; }

        public Melee()// : base()
        {
            name = "Melee";
            crit_factor = 0;
            crit_chance = 0;
        }
    }

    [Serializable]
    class Rifle : Weapon
    {
        public int range { get; set; }
        public int ammo_damage { get; set; }
        public Rifle()// : base()
        {
            name = "Rifle";
            range = 0;
            ammo_damage = 0;
        }
    }

    [Serializable]
    class Magic_Сatalyst : Weapon
    {
        public int mana_consumption { set; get; }
        public int range { get; set; }
        public Magic_Сatalyst()// : base()
        {
            name = "Magic_Сatalyst";
            range = 0;
            mana_consumption = 0;
        }
    }

    [Serializable]
    abstract class Character
    {
        public string name { get; set; }
        public int health { get; set; }
        public int resistance { get; set; }
        public Character()
        {
            name = "empty";
            health = 0;
            resistance = 0;
        }
    }

    [Serializable]
    class Simple_NPC : Character
    {
        public int damage { get; set; }
        public Simple_NPC() : base()
        {
            name = "Simple_NPC";
            damage = 0;
        }

    }

    [Serializable]
    class Player_Like_NPC : Character
    {
        public int armor { get; set; }
        public Weapon weapon { get; set; }
        public int stamina { get; set; }
        public int mana { get; set; }
        public Player_Like_NPC() : base()
        {
            name = "Player_Like_NPC";
            armor = 0;
            stamina = 0;
            mana = 0;
            weapon = null;
        }
    }

    [Serializable]
    class Player : Player_Like_NPC
    {
        public int vigour { get; set; }
        public int agility { get; set; }
        public int magic { get; set; }
        public Player() : base()
        {
            name = "Player";
            vigour = 0;
            agility = 0;
            magic = 0;
        }
    }

    [Serializable]
    class Quest_Player_Like_NPC : Player_Like_NPC
    {
        public string dialogs { get; set; }
        public Quest_Player_Like_NPC() : base()
        {
            name = "Quest_Player_Like_NPC";
            dialogs = "empty";
        }
    }

    [Serializable]
    class Quest_SimpleNPC : Simple_NPC
    {
        public string dialogs { get; set; }
        public Quest_SimpleNPC() : base()
        {
            name = "Quest_SimpleNPC";
            dialogs = "empty";
        }
    }
}