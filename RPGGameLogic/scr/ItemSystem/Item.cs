using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPGGameLogic.Items
{
    public enum ItemTypes { Equpabple, Consumable, KeyItem }
    public enum EquipSlots { None, Primary, Secondary, Head, Body, Accessory }
    public enum EquipmentType { Gag, Collar, Weapon, HandCuffs, LegCuffs, CockRing, ChastityBelt, ChastityCage, AnalPlug, VaginalPlug, Blind, Armor }
    //    public enum EquipmentType { Gag, Collar, Weapon, HandCuffs, LegCuffs, Armor, Helmet, clothing, Undergarment, Accesory, Percings }
    public enum WeaponType { Sword }
    public enum ArmorType { Light, Heavy, Skimpy }

    class Item
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
//        public ItemTypes Type { get; set; }

    }


    interface IConsumable
    {
        bool Consume(Creature c);
    }

    interface IKeyItem
    {
        bool IsUnique{get; set;}
    }

    interface IEquipable
    {
        EquipSlots[] Slots { get; }
        EquipmentType[] EquipType { get; }
        bool Equip(Creature c);
        bool Unequip(Creature c);
    }

    interface IPercing : IEquipable
    {
        int Might { get; }
        int Weight { get; }
        WeaponType[] Type { get; }
    }
    interface IWeapon : IEquipable
    {
        int Might { get; }
        int Weight { get; }
        WeaponType[] Type { get; }
    }

    interface IArmor : IEquipable
    {
        int Defence { get; }
        int Weight { get; }
        ArmorType[] Type { get; }
    }

    interface IBattleItem
    {
        bool BattleConsume(Creature c);
        bool BattleUse(Creature source, Creature target);
    }

}