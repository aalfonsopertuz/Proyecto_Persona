﻿namespace Api.Core.Dtos
{
    public class ResponseDto<T>
    {
        public int? Code { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
