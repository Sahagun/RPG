using RPGGameLogic.Util;
using System.Collections.Generic;


namespace RPGGameLogic
{

    public class Restriction
    {
        public enum RestrictionTypes { Voiceless, Vision, Eat, Attack, Flee, Erections, MaleCum, FemaleCum, AnalInsertion, VaginalInsertion };
//        public enum RestrictionTypes { Voiceless, Vision, Eat, Attack, Flee };

        public struct RestrictionContainer
        {
            /// <summary>
            /// The EquipmentType of the item that is causing the restriction.
            /// </summary>
            public Items.EquipmentType EquiptType { get; set; }

            /// <summary>
            /// The name of the item that is causing the restriction.
            /// </summary>
            public string ID { get; set; }

            public RestrictionContainer(string id, Items.EquipmentType equipmentType)
            {
                ID = id;
                EquiptType = equipmentType;
            }
        }

        private Dictionary<RestrictionTypes, List<RestrictionContainer>> _restictions = new Dictionary<RestrictionTypes, List<RestrictionContainer>>();

        public Restriction()
        {
            foreach (RestrictionTypes type in EnumUtil.GetValues<RestrictionTypes>())
            {
                _restictions.Add(type, new List<RestrictionContainer>());
            }
        }

        public void Add(RestrictionTypes[] restrictionTypes, string id, Items.EquipmentType equipmentType)
        {
            foreach (RestrictionTypes type in restrictionTypes)
            {
                _restictions[type].Add(new RestrictionContainer(id, equipmentType));
            }
        }

        public bool Restricted(RestrictionTypes restrictionTypes)
        {
            return _restictions[restrictionTypes].Count > 0;
        }

        public bool Contains(string id, Items.EquipmentType type)
        {
            foreach (KeyValuePair<RestrictionTypes, List<RestrictionContainer>> keypair in _restictions)
            {
                if (keypair.Value.Contains(new RestrictionContainer(id, type)))
                {
                    return true;
                }
            }
            return false;
        }

        public int Remove(string id)
        {
            int count = 0;
            foreach (KeyValuePair<RestrictionTypes, List<RestrictionContainer>> keypair in _restictions)
            {
                count += keypair.Value.RemoveAll(x => x.ID.Equals(id));
            }
            return count;
        }


        public void Clear()
        {
            foreach (KeyValuePair<RestrictionTypes, List<RestrictionContainer>> keypair in _restictions)
            {
                keypair.Value.Clear();
            }
        }

    }
}