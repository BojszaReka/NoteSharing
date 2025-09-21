using System;

namespace class_library.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } = 0;
        public string? Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public object? Data { get; set; }
    }
}
