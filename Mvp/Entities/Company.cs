namespace Mvp.Entities
{
    public sealed class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public Address? Location { get; set; }

        public bool IsActive { get; set; }

        public string Website { get; set; }

        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
