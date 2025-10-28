using System;
using Laborator5.Models; 

namespace Laborator5.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        
        // RELAȚIA: Cheia Externă (Foreign Key)
        public int CategoryId { get; set; } 
        
        // RELAȚIA: Proprietate de Navigație
        public Category Category { get; set; } 
    }
}