namespace API.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole
                {
                    Name = "ProductOwner",
                    NormalizedName = "PRODUCTOWNER",
                    Description = "owns a product"
                },
                new AppRole
                {
                    Name = "Developer",
                    NormalizedName = "DEVELOPER",
                    Description = "has Developer access"
                },
                new AppRole
                {
                    Name = "Tester",
                    NormalizedName = "TESTER",
                    Description = "has Testing access"
                });
        }
    }
}