using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


enum ItemTypes { Equpabple, Consumable, KeyItem }
enum EquipSlots { None, Primary, Secondary, Head, Body, Accessory}

class Item
{
    public string Name { get; set; }
    public string ID { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public ItemTypes Type { get; set; }

}


class Consumable : Item
{

}

class KeyItem : Item
{

}

class Equipable : Item
{

}

class Armor : Equipable
{

}

