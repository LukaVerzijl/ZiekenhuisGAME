using System;
using Pepersistence;

namespace Code.Utils.SaveData
{
    [Serializable]
    public class SaveData : ISaveData
    {
        public KindSafeData KindSafeData;
    }
}