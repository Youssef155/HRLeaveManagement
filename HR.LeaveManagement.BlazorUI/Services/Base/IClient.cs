namespace HR.LeaveManagement.BlazorUI.Services.Base
{
    public partial interface IClient
    {
        public HttpClient _httpClient { get; }
    }
}
