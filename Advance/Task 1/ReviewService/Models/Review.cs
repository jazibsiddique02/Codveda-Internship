﻿namespace ReviewService.Models
{ 
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Reviewer { get; set; }
        public string Comment { get; set; }
    }


}
