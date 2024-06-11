using Services.A.Core.Events;
using Services.A.Core.Interfaces;

namespace Services.A.Core.Repositories
{
    public class ServiceRepo : RepoBase, IServiceRepo
    {
        #region *** private

        private readonly IDBRepo _dbManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly IEventBus _bus;

        #endregion
        #region *** ctor

        public ServiceRepo(IDBRepo dbManager,
            IJwtFactory jwtFactory,
            IEventBus bus,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _jwtFactory = jwtFactory;
            _dbManager = dbManager;
            _bus = bus;
        }

        #endregion
        #region *** public

        public Task<bool> SendMessage()
        {
            _bus.Publish(new ServiceBEvent()
            {
                Message = "delivered to service B"
            }, Enums.ExchangeTypes.Direct);

            return Task.FromResult(true);
        }

        #endregion
    }
}