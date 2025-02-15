﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class ErrorDto
    {
        public List<string> Errors { get; set; } = new List<string>();

        public bool IsShow { get; set; }

        public ErrorDto()
        {
            Errors = new List<string>();
        }

        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }

        public ErrorDto(string error, bool isShow)
        {
            Errors = new List<string> { error };
            IsShow = isShow;
        }
    }
}
