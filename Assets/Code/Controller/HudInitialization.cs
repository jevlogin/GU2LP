namespace JevLogin
{
    public class HudInitialization : IInitialization
    {
        private readonly HudFactory _hudFactory;
        public HpView HpView;


        public HudInitialization(HudFactory hudFactory)
        {
            _hudFactory = hudFactory;
            HpView = _hudFactory.HpView;
            
        }

        public void Initialization()
        {
            HpView.Initialize(new HpViewModel(new HpModel(3)));
        }
    }
}