using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BandsOfSuncoast
{
    class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }
        public Band Band { get; set; }
        public string Description()
        {
            var descriptionOfAlbums = ($"{Title} was release around {ReleaseDate}");

            return descriptionOfAlbums;
        }
    }
}