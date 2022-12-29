using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFProject.Models
{
    internal class PlaceInfo
    {
        public string? CountryName { get; set; }

        public Point Location { get; set; }

        public IEnumerable<ConfirmedCount>? Counts { get; set; }
    }

}
