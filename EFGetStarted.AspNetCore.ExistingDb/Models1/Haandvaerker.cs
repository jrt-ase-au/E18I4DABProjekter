﻿using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models1
{
    public partial class Haandvaerker
    {
        public Haandvaerker()
        {
            Vaerktoejskasse = new HashSet<Vaerktoejskasse>();
        }

        public int HaandvaerkerId { get; set; }
        public DateTime Ansaettelsedato { get; set; }
        public string Efternavn { get; set; }
        public string Fagomraade { get; set; }
        public string Fornavn { get; set; }

        public ICollection<Vaerktoejskasse> Vaerktoejskasse { get; set; }
    }
}
