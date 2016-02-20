namespace PartyMate.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Club> Clubs { get; set; }

        public IDbSet<ClubAnonymousReview> ClubAnonymousReviews { get; set; }

        public IDbSet<ClubHiddenImage> ClubHiddenImages { get; set; }

        public IDbSet<ClubHiddenImageVote> ClubHiddenImageVotes { get; set; }

        public IDbSet<ClubReview> ClubReviews { get; set; }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<EventComment> EventComments { get; set; }

        public IDbSet<EventLike> EventLike { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<MusicGenre> MusicGenres { get; set; }

        public override IDbSet<User> Users { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
