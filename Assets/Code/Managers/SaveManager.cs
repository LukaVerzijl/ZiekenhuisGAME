using Code.Utils;
using Pepersistence;

namespace Code.Managers
{
    //class om persitanceManager bij te houden
    public class SaveManager : Singleton<SaveManager>
    {
        public PersistenceManager persistenceManager { get; private set; }

        /// <summary>
        /// init de persistence manager en laad de data, als er nog geen data is sla deze dan op zodat er een save file word gemaakt
        /// </summary>
        public void Start()
        {
            persistenceManager = new PersistenceManager(new LocalSaveSource());
            persistenceManager.Register(SaveDataManager.Instance);
            persistenceManager.Load();
            if (SaveDataManager.Instance.KindNaam != "" && SaveDataManager.Instance.KindNaam == null ){
                persistenceManager.Save();
            }
            
        }
        
        
    }
}