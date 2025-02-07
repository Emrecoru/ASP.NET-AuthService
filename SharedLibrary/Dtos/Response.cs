﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class Response<T> where T : class
    {
        public T Data { get; set; }

        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsSuccessful { get; set; }

        public ErrorDto Error { get; set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Data = data, IsSuccessful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T>() { StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(ErrorDto error, int statusCode)
        {
            return new Response<T>() { Error = error, StatusCode = statusCode, IsSuccessful = false };
        }

        public static Response<T> Fail(string error, int statusCode, bool isShow)
        {
            return new Response<T>() { Error = new ErrorDto(error, isShow), StatusCode = statusCode, IsSuccessful = false };
        }
    }
}
