using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace TranHuuTri.Assignment02.Repositories.Entities
{
    public partial class BookAuthor
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string? AuthorOrder { get; set; }
        public int? RoyalityPercentage { get; set; }
        public int Status { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
