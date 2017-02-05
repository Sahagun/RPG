using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class StatSheet
{

    protected struct StatModifier
    {
        private readonly string id;
        private readonly string stat;

        public StatModifier(string id, string stat) : this()
        {
            this.id = id;
            this.stat = stat;
        }

        public string ID { get { return id; } }
        public string BaseStat { get { return stat; } }
    }

    protected Dictionary<string, double> _baseStats = new Dictionary<string, double>();
    protected Dictionary<StatModifier, double> _additiveStatsModifiers = new Dictionary<StatModifier, double>();
    protected Dictionary<StatModifier, double> _multiplicativeStatsModifiers = new Dictionary<StatModifier, double>();

    /// <summary>
    /// Gets the unmodified base stat.
    /// </summary>
    /// <param name="statName">
    /// The name of the stat that will be returned.
    /// </param>
    /// <returns>
    /// The method returns an the stat as a double.
    /// </returns>
    public double GetBaseStat(string statName)
    {
        double statValue = -1;
        _baseStats.TryGetValue(statName, out statValue);
        return statValue;
    }

    /// <summary>
    /// Adds a new base stat.
    /// </summary>
    /// <param name="statName">
    /// The name of the stat that will be added.
    /// </param>
    /// <param name="statValue">
    /// The value that will be added.
    /// </param>
    /// <returns>
    /// The method returns true if that stat was not in the dictionary.
    /// </returns>
    public bool AddBaseStat(string statName, float statValue)
    {
        if (!_baseStats.ContainsKey(statName))
        {
            _baseStats.Add(statName, statValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Sets the unmodified base stat.
    /// </summary>
    /// <param name="statName">
    /// The name of the stat that will be set.
    /// </param>
    /// <param name="statValue">
    /// The value that will be set.
    /// </param>
    /// <returns>
    /// The method returns true if that stat was in the dictionary.
    /// </returns>
    public bool SetBaseStat(string statName, float statValue)
    {
        if (_baseStats.ContainsKey(statName))
        {
            _baseStats[statName] = statValue;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Gets the modified stat.
    /// </summary>
    /// <param name="statName">
    /// The name of the stat that will be set.
    /// </param>
    /// <returns>
    /// The method returns the value of stat with all modifications as a double.
    /// </returns>
    public double GetStat(string statName)
    {
        double statValue = -1;
        if (_baseStats.TryGetValue(statName, out statValue))
        {
            foreach (StatModifier sm in _multiplicativeStatsModifiers.Keys)
            {
                if (sm.BaseStat.Equals(statName))
                {
                    statValue *= _multiplicativeStatsModifiers[sm];
                }
            }

            foreach (StatModifier sm in _additiveStatsModifiers.Keys)
            {
                if (sm.BaseStat.Equals(statName))
                {
                    statValue += _additiveStatsModifiers[sm];
                }
            }
        }
        return statValue;
    }

    /// <summary>
    /// Addes a new additive modifier. The ID and statname must be unique to be added.
    /// </summary>
    /// <param name="id">
    /// The id of the modifier.
    /// </param>
    /// <param name="statName">
    /// The name of the stat that will be modified.
    /// </param>
    /// <param name="statValue">
    /// The value amount that modify.
    /// </param>
    /// <returns>
    /// The method returns true if added.
    /// </returns>
    public bool AddAdditiveStatsModifier(string id, string statName, double statModifier)
    {
        StatModifier sm = new StatModifier(id, statName);
        if (_additiveStatsModifiers.ContainsKey(sm))
        {
            return false;
        }
        _additiveStatsModifiers.Add(sm, statModifier);
        return true;
    }

    /// <summary>
    /// Addes a new multiplicative modifier. The ID and statname must be unique to be added.
    /// </summary>
    /// <param name="id">
    /// The id of the modifier.
    /// </param>
    /// <param name="statName">
    /// The name of the stat that will be modified.
    /// </param>
    /// <param name="statValue">
    /// The value amount that modify.
    /// </param>
    /// <returns>
    /// The method returns true if added.
    /// </returns>
    public bool AddMultiplicativeStatsModifier(string id, string statName, double statModifier)
    {
        StatModifier sm = new StatModifier(id, statName);
        if (_multiplicativeStatsModifiers.ContainsKey(sm))
        {
            return false;
        }
        _multiplicativeStatsModifiers.Add(sm, statModifier);
        return true;
    }

    /// <summary>
    /// Changes an existing additive modifier. The ID and statname must be unique to be added.
    /// </summary>
    /// <param name="id">
    /// The id of the modifier.
    /// </param>
    /// <param name="statName">
    /// The name of the stat that will be modified.
    /// </param>
    /// <param name="statValue">
    /// The value amount that modify.
    /// </param>
    /// <returns>
    /// The method returns true if a modification happened.
    /// </returns>
    public bool ChangeAdditiveStatsModifier(string id, string statName, double statModifier)
    {
        StatModifier sm = new StatModifier(id, statName);
        if (_additiveStatsModifiers.ContainsKey(sm))
        {
            _additiveStatsModifiers[sm] = statModifier;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Changes an existing multiplicative modifier. The ID and statname must be unique to be added.
    /// </summary>
    /// <param name="id">
    /// The id of the modifier.
    /// </param>
    /// <param name="statName">
    /// The name of the stat that will be modified.
    /// </param>
    /// <param name="statValue">
    /// The value amount that modify.
    /// </param>
    /// <returns>
    /// The method returns true if a modification happened.
    /// </returns>
    public bool ChangeMultiplicativeStatsModifier(string id, string statName, double statModifier)
    {
        StatModifier sm = new StatModifier(id, statName);
        if (_multiplicativeStatsModifiers.ContainsKey(sm))
        {
            _multiplicativeStatsModifiers[sm] = statModifier;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Remove all modifiers.
    /// </summary>
    public void RemoveAllModifiers()
    {
        _additiveStatsModifiers.Clear();
        _multiplicativeStatsModifiers.Clear();
    }

    /// <summary>
    /// Remove all modifiers with the id.
    /// </summary>
    /// <param name="id">
    /// The id of the modifier.
    /// </param>
    public void RemoveModifiers(string id)
    {
        /* // This block clauses an error because you are changing the dictionary as we iterate through it.
        foreach (StatModifier sm in _additiveStatsModifiers.Keys)
        {
            if (sm.ID.Equals(id)) { _additiveStatsModifiers.Remove(sm); }
        }

        foreach (StatModifier sm in _multiplicativeStatsModifiers.Keys)
        {
            if (sm.ID.Equals(id)) { _multiplicativeStatsModifiers.Remove(sm); }
        }
        */

        foreach (StatModifier sm in _additiveStatsModifiers.Keys.ToList())
        {
            if (sm.ID.Equals(id)) { _additiveStatsModifiers.Remove(sm); }
        }

        foreach (StatModifier sm in _multiplicativeStatsModifiers.Keys.ToList())
        {
            if (sm.ID.Equals(id)) { _multiplicativeStatsModifiers.Remove(sm); }
        }

    }




    public List<KeyValuePair<string, double>> GetBaseStats()
    {
        List<KeyValuePair<string, double>> stats = new List<KeyValuePair<string, double>>();
        foreach (KeyValuePair<string, double> pair in _baseStats)
        {
            stats.Add(pair);
        }
        return stats;
    }

    public List<KeyValuePair<string, double>> GetStats()
    {
        List<KeyValuePair<string, double>> stats = new List<KeyValuePair<string, double>>();
        foreach (KeyValuePair<string, double> pair in _baseStats)
        {
            stats.Add(new KeyValuePair<string, double>(pair.Key, GetStat(pair.Key)));
        }
        return stats;
    }
}
