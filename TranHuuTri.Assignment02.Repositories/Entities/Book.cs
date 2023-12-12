using System;
using System.Collections.Generic;

namespace TranHuuTri.Assignment02.Repositories.Entities
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? PubId { get; set; }
        public decimal Price { get; set; }
        public string? Advance { get; set; }
        public string? Royalty { get; set; }
        public string? Notes { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Status { get; set; }
        public virtual Publisher? Pub { get; set; }
    }
}
