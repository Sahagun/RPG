using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Inventory
{
    List<Item> KeyItems = new List<Item>();
    BackPack backPack = new BackPack();
    Storage storage = new Storage();

    private int _gold;
    public int Gold
    {
        get { return _gold; }
        set { _gold = value < 0 ? 0 : value; }
    }


    // Carrying
    public class BackPack
    {
        int _slots = 3;
        int _maxslots = 5;
        int _itemsPerSlot = 10;
        bool _isHidden;

        bool Hidden { get { return _isHidden; } }

        // Item quantitiy
        Dictionary<Item, int> items = new Dictionary<Item, int>();

        void Hide() { _isHidden = true; }
        void Unhide() { _isHidden = false; }

        bool Add() { return false; }
        bool Remove() { return false; }
        bool Use() { return false; } // consume or equip
        bool Sell() { return false; } // consume or equip


        void Clear() { items.Clear(); } // removes all items

    }

    // Storage
    public class Storage
    {
        int _slots = 5;
        int _maxslots = 100;
        int _itemsPerSlot = 99;

        Dictionary<Item, int> items = new Dictionary<Item, int>();

        bool Add() { return false; }
        bool Remove() { return false; }
        void Clear() { items.Clear(); } // removes all items
    }

}
