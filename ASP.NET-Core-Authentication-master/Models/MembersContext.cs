
using Microsoft.EntityFrameworkCore;
using Authentication.Models;

namespace Authentication.Models
{
    public class MembersContext : DbContext
    {
        public MembersContext(DbContextOptions<MembersContext> options)
            : base(options)
        { }
        public DbSet<Members> Parent { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<ParentChild> Family { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Child>().HasData(
                new Child { ID = 1, FirstName = "Adam", LastName = "Anderson", Birthday = new System.DateTime(2018, 10, 31) },
                new Child { ID = 2, FirstName = "Taylor", LastName = "Anderson", Birthday = new System.DateTime(2017, 06, 10) },
                new Child { ID = 3, FirstName = "Leighton", LastName = "Topaz", Birthday = new System.DateTime(2018, 12, 25) },
                new Child { ID = 4, FirstName = "Sasha", LastName = "Mathers", Birthday = new System.DateTime(2018, 08, 01) },
                new Child { ID = 5, FirstName = "Braydon", LastName = "Blossom", Birthday = new System.DateTime(2018, 01, 01) },
                new Child { ID = 6, FirstName = "Levon", LastName = "Anderson", Birthday = new System.DateTime(2018, 12, 31) },
                new Child { ID = 7, FirstName = "Sage", LastName = "Goldstein", Birthday = new System.DateTime(2018, 07, 04) },
                new Child { ID = 8, FirstName = "Rosemary", LastName = "Goldstein", Birthday = new System.DateTime(2018, 02, 14) },
                new Child { ID = 9, FirstName = "Thyme", LastName = "Goldstein", Birthday = new System.DateTime(2018, 9, 9) },
                new Child { ID = 10, FirstName = "Marcus", LastName = "Blossom", Birthday = new System.DateTime(2018, 4, 17) }
                );
            modelBuilder.Entity<Members>().HasData(
                new Members { ID = 1, FirstName = "Becky", LastName = "Bozwell", Address = "100 Oak Ave", City = "Traverse City", State = "MI", Zip = "49696", MobilePhone = "(231)123-4567" },
                new Members { ID = 2, FirstName = "Albert", LastName = "Anderson", Address = "2010 Greenway Ave, Apt 202", City = "Traverse City", State = "MI", Zip = "49696", MobilePhone = "(231)123-4444" },
                new Members { ID = 3, FirstName = "Taylor", LastName = "Topaz", Address = "1600 Park Place", City = "Traverse City", State = "MI", Zip = "49696", MobilePhone = "(231)123-9874" },
                new Members { ID = 4, FirstName = "Magnolia", LastName = "Blossom", Address = "2 Flowing Park Drive", City = "Traverse City", State = "MI", Zip = "49696", MobilePhone = "(231)123-1111" },
                new Members { ID = 5, FirstName = "Jerry", LastName = "Mathers", Address = "1950 Beaver Drive", City = "Traverse City", State = "MI", Zip = "49696", MobilePhone = "(231)123-4433" },
                new Members { ID = 6, FirstName = "Pepper", LastName = "Goldstein", Address = "6 Hwy 5", City = "Traverse City", State = "MI", Zip = "49696", MobilePhone = "(231)123-6898" }
                );
            modelBuilder.Entity<ParentChild>().HasData(
                 new ParentChild { ID=1, MembersID = 1, ChildID = 1 },
                 new ParentChild { ID = 2, MembersID = 2, ChildID = 1 },
                 new ParentChild { ID = 3, MembersID = 2, ChildID = 2 },
                 new ParentChild { ID = 4, MembersID = 2, ChildID = 6 },
                 new ParentChild { ID = 5, MembersID = 3, ChildID = 3 },
                 new ParentChild { ID = 6, MembersID = 5, ChildID = 4 },
                 new ParentChild { ID = 7, MembersID = 4, ChildID = 5 },
                 new ParentChild { ID = 8, MembersID = 4, ChildID = 10 },
                 new ParentChild { ID = 9, MembersID = 6, ChildID = 7 },
                 new ParentChild { ID = 10, MembersID = 6, ChildID = 8 },
                 new ParentChild { ID = 11, MembersID = 6, ChildID = 9 }
             );
        }
    }
}
