using System;
using Pepersistence;

namespace Code.Utils.SaveData
{
    //class als interface om meerdere types op te slaan ouder zou een andere class kunnen zijn bijvoorbeeld
    [Serializable]
    public class SaveData : ISaveData
    {
        public KindSafeData KindSafeData;
    }
}