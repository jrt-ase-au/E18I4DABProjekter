﻿using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models1
{
    public partial class Vaerktoejskasse
    {
        public Vaerktoejskasse()
        {
            Vaerktoej = new HashSet<Vaerktoej>();
        }

        public int VkasseId { get; set; }
        public DateTime Anskaffet { get; set; }
        public string Fabrikat { get; set; }
        public int? EjesAf { get; set; }
        public string Model { get; set; }
        public string Serienummer { get; set; }
        public string Farve { get; set; }

        public Haandvaerker EjesAfNavigation { get; set; }
        public ICollection<Vaerktoej> Vaerktoej { get; set; }
    }
}
