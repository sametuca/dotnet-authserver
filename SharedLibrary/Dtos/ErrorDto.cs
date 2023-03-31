using System;
using System.Collections.Generic;

namespace SharedLibrary.Dtos
{
    public class ErrorDto
    {
        public List<string> Errors { get; }
        public bool IsShow { get; set; }

        public ErrorDto()
        {
            Errors = new List<string>();
        }

        public ErrorDto(string error, bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }

        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}