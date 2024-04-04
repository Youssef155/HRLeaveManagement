

namespace HR.LeaveManagement.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        private IClient _client;

        public BaseHttpService(IClient client)
        {
            _client = client;
        }

    }
}
