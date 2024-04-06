﻿namespace HR.LeaveManagement.BlazorUI.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; }
        public string validationError { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
