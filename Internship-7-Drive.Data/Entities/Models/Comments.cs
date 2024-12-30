﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Internship_7_Drive.Data.Entities.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string OwnerMail { get; set; }
        public int FileId { get; set; }

        public User Owner { get; set; } = null!;
        public File File { get; set; } = null!;
    }
}
